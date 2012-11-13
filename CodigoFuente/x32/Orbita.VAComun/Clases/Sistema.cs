//***********************************************************************
// Assembly         : Orbita.VAComun
// Author           : aiba�ez
// Created          : 06-09-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Orbita.Utiles;

namespace Orbita.VAComun
{
    /// <summary>
    /// Clase est�tica encargada de dar acceso a toda la aplicaci�n al control del inicio y la detenci�n de los m�dulos instalados en el sistema
    /// </summary>
    public static class SystemRuntime
    {
        #region Atributo(s)
        /// <summary>
        /// Campo del sistema que se ha arrancado
        /// </summary>
        public static Sistema Sistema;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Enumerado que describe el estado del sistema
        /// </summary>
        public static EstadoSistema EstadoSistema
        {
            get { return Sistema.EstadoSistema; }
            set { Sistema.EstadoSistema = value; }
        }

        /// <summary>
        /// Par�metros de la aplicaci�n
        /// </summary>
        public static Configuracion Configuracion
        {
            get { return Sistema.Configuracion; }
            set { Sistema.Configuracion = value; }
        }
        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Constructor de los campos est�ticos de la clase
        /// </summary>
        public static void Constructor(Sistema sistema)
        {
            Sistema = sistema;
        }
        /// <summary>
        /// Inicia el sistema de inspecci�n en tiempo real
        /// </summary>
        public static bool IniciarSistema()
        {
            return Sistema.IniciarSistema(true);
        }
        /// <summary>
        /// Detiene el funcionamiento del inspecci�n en tiempo real
        /// </summary>
        public static bool PararSistema()
        {
            return Sistema.PararSistema();
        }
        /// <summary>
        /// Reinicia el sistema de control en tiempo real
        /// </summary>
        public static bool ReiniciarSistema()
        {

            bool resultado = true;

            if (resultado)
            {
                resultado = Sistema.PararSistema();
            }

            if (resultado)
            {
                resultado = Sistema.IniciarSistema(false);
            }

            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Clase que controla el inicio y la detenci�n del resto de m�dulos instalados en el sistema
    /// </summary>
    public class Sistema
    {
        #region Atributo(s)
        /// <summary>
        /// Enumerado que describe el estado del sistema
        /// </summary>
        public EstadoSistema EstadoSistema;

        /// <summary>
        /// Par�metros de la aplicaci�n
        /// </summary>
        public Configuracion Configuracion;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Sistema()
            : this(Configuracion.ConfFile)
        {
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Sistema(string configFile)
        {
            this.EstadoSistema = EstadoSistema.Detenido;

            try
            {
                this.Configuracion = (Configuracion)(new Configuracion(configFile).CargarDatos());
            }
            catch (FileNotFoundException exception)
            {
                LogsRuntime.Error(ModulosSistema.Sistema, "Constructor", exception);

                this.Configuracion = new Configuracion();
                this.Configuracion.Guardar();
            }
        }

        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Inicia el sistema de inspecci�n en tiempo real
        /// </summary>
        internal bool IniciarSistema(bool incial)
        {
            bool resultado;

            // Mostramos el formulario Splash
            SplashRuntime.Contructor();

            resultado = this.InicioSistema();
            this.FinInicioSistema(ref resultado);

            // Ocultamos el formulario splash
            SplashRuntime.Destructor();

            if (!resultado)
            {
                OMensajes.MostrarAviso("El sistema no se ha podido iniciar con �xito.");
            }

            return resultado;
        }
        /// <summary>
        /// Detiene el sistema de inspecci�n en tiempo real
        /// </summary>
        internal bool PararSistema()
        {
            bool resultado;

            resultado = this.ParoSistema();
            this.FinParoSistema(ref resultado);

            // Se limpian todos los objetos eliminados
            GC.Collect();

            return resultado;
        }
        /// <summary>
        /// Conslta de un par�metro de la aplicaci�n
        /// </summary>
        /// <returns></returns>
        public bool Parametro(string textoParametro)
        {
            bool resultado = false;

            if (App.ListaParametrosEntradaAplicacion != null)
            {
                List<string> listaParametrosEntradaAplicacion = new List<string>(App.ListaParametrosEntradaAplicacion);

                resultado = listaParametrosEntradaAplicacion.Exists(delegate(string p) { return string.Equals(p, textoParametro, StringComparison.InvariantCultureIgnoreCase); });
            }

            return resultado;
        }

        #endregion

        #region M�todo(s) virtual(es)
        /// <summary>
        /// Inicia el sistema de inspecci�n en tiempo real
        /// </summary>
        protected virtual bool InicioSistema()
        {
            bool resultado = false;

            if (this.EstadoSistema == EstadoSistema.Detenido)
            {
                this.EstadoSistema = EstadoSistema.Arrancando;
                resultado = true;

                // Fase 1: Se obtiene la conexi�n con la BBDD y se inicia el registro de eventos
                if (resultado)
                {
                    try
                    {
                        // Conexi�n con la base de datos
                        if (this.Configuracion.UtilizaBaseDeDatos)
                        {
                            SplashRuntime.Mensaje("Conectando con las bases de datos");
                            BaseDatosRuntime.Constructor();
                            BaseDatosRuntime.Inicializar();
                            BaseDatosParam.Conectar();
                            BaseDatosAlmacen.Conectar();
                        }

                        // Creaci�n de los threads del sistema
                        SplashRuntime.Mensaje("Creando log los hilos de ejecuci�n");
                        ThreadRuntime.Constructor();
                        ThreadRuntime.Inicializar();

                        // Creaci�n del log de eventos
                        SplashRuntime.Mensaje("Creando log de eventos");
                        LogsRuntime.Constructor();
                        LogsRuntime.Inicializar();
                        LogsRuntime.Info(ModulosSistema.Sistema, "IniciarSistema", "Inicio del sistema");

                        // Creaci�n de la monitorizaci�n del sistema
                        MonitorizacionSistemaRuntime.Constructor();
                        MonitorizacionSistemaRuntime.NuevaMonitorizacion(TipoMonitorizacion.MonitorizacionCpuRam);
                        MonitorizacionSistemaRuntime.NuevaMonitorizacion(TipoMonitorizacion.MonitorizacionDiscos);
                        MonitorizacionSistemaRuntime.NuevaMonitorizacion(TipoMonitorizacion.MonitorizacionProcesos);
                        MonitorizacionSistemaRuntime.NuevaMonitorizacion(TipoMonitorizacion.MonitorizacionConexiones);
                        MonitorizacionSistemaRuntime.Inicializar();
                    }
                    catch (Exception exception)
                    {
                        LogsRuntime.Error(ModulosSistema.Sistema, "IniciarSistema", exception);
                        resultado = false;
                    }
                }

                // Fase 2: Se inician, uno a uno, los m�dulos b�sicos del sistema
                if (resultado)
                {
                    try
                    {
                        // Creaci�n del manejo avanzado de ventanas
                        SplashRuntime.Mensaje("Construyendo el escritorio");
                        EscritoriosRuntime.Constructor();

                        // Creaci�n de los cron�metros del sistema
                        SplashRuntime.Mensaje("Construyendo el control de tiempos");
                        CronometroRuntime.Constructor();
                        CronometroRuntime.Inicializar();

                        // Creaci�n del almacen de objetos visuales
                        AlmacenVisualRuntime.Constructor();
                        AlmacenVisualRuntime.Inicializar();
                    }
                    catch (Exception exception)
                    {
                        LogsRuntime.Error(ModulosSistema.Sistema, "IniciarSistema", "Error: " + exception.ToString());
                        resultado = false;
                    }
                }

            }
            else
            {
                OMensajes.MostrarError("No se puede iniciar el sistema porque este no se encuentra parado.");
            }

            return resultado;
        }
        /// <summary>
        /// Se ejecuta al finalizar el inicio del sistema
        /// </summary>
        protected virtual void FinInicioSistema(ref bool resultado)
        {
            if (resultado)
            {
                try
                {
                    // Inicializaci�n del escritorio actual
                    SplashRuntime.Mensaje("Inicializado el escritorio");
                    EscritoriosRuntime.Inicializar();

                    // Monitorizaci�n inicial para ver el estado del sistema en el momento del arranque
                    MonitorizacionSistemaRuntime.SiguienteMonitorizacion();
                    MonitorizacionSistemaRuntime.Log();

                    // Se finaliza el modo inicializaci�n de los logs (tienen un comportamiento dinstinto)
                    LogsRuntime.FinInicializacion();

                    // Ocultamos el formulario Splash
                    SplashRuntime.Mensaje("Inicio finalizado con �xito");
                    LogsRuntime.Info(ModulosSistema.Sistema, "IniciarSistema", "Inicio finalizado con �xito");
                }
                catch (Exception exception)
                {
                    LogsRuntime.Error(ModulosSistema.Sistema, "IniciarSistema", "Error: " + exception.ToString());
                    resultado = false;
                }
            }

            // Cambiamos el estado del sistema seg�n el resultado del arranque
            if (resultado)
            {
                this.EstadoSistema = EstadoSistema.Iniciado;
            }
            else
            {
                this.EstadoSistema = EstadoSistema.Detenido;
            }
        }
        /// <summary>
        /// Detiene el funcionamiento del inspecci�n en tiempo real
        /// </summary>
        protected virtual bool ParoSistema()
        {
            bool resultado = false;

            if (this.EstadoSistema == EstadoSistema.Iniciado)
            {
                this.EstadoSistema = EstadoSistema.Deteniendo;
                resultado = true;

                try
                {
                    LogsRuntime.Info(ModulosSistema.Sistema, "PararSistema", "Paro del sistema");

                    // Finalizaci�n manejo avanzado de ventanas                    
                    EscritoriosRuntime.Finalizar();
                    EscritoriosRuntime.Destructor();
                }
                catch (Exception exception)
                {
                    LogsRuntime.Error(ModulosSistema.Sistema, "PararSistema", "Error: " + exception.ToString());
                    resultado = false;
                }
            }
            else
            {
                OMensajes.MostrarError("No se puede detener el sistema porque este no se encuentra iniciado.");
            }

            return resultado;
        }
        /// <summary>
        /// Se ejecuta al finalizar la detenci�n del sistema
        /// </summary>
        protected virtual void FinParoSistema(ref bool resultado)
        {
            if (resultado)
            {
                try
                {
                    // Creaci�n del almacen de objetos visuales
                    AlmacenVisualRuntime.Finalizar();
                    AlmacenVisualRuntime.Destructor();

                    // Finalizaci�n de los cron�metros del sistema
                    CronometroRuntime.Finalizar();
                    CronometroRuntime.Destructor();
                }
                catch (Exception exception)
                {
                    LogsRuntime.Error(ModulosSistema.Sistema, "PararSistema", "Error: " + exception.ToString());
                    resultado = false;
                }

                try
                {
                    // Finalizaaci�n de las bases de datos
                    BaseDatosRuntime.Finalizar();
                    BaseDatosRuntime.Destructor();

                    // Finalizaci�n del log de eventos
                    LogsRuntime.Info(ModulosSistema.Sistema, "PararSistema", "Paro del sistema finalizado con �xito");
                    LogsRuntime.Finalizar();
                    LogsRuntime.Destructor();

                    // Finalizaci�n de los threads del sistema
                    SplashRuntime.Mensaje("Creando log los hilos de ejecuci�n");
                    ThreadRuntime.Finalizar();
                    ThreadRuntime.Destructor();

                    // Liberaci�n de memoria
                    GC.Collect();
                }
                catch (Exception exception)
                {
                    OMensajes.MostrarError(exception.ToString());
                    resultado = false;
                }

                // Cambiamos el estado del sistema seg�n el resultado del arranque
                if (resultado)
                {
                    this.EstadoSistema = EstadoSistema.Detenido;
                }
                else
                {
                    this.EstadoSistema = EstadoSistema.Iniciado;
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Enumerado que describe el estado del sistema
    /// </summary>
    public enum EstadoSistema
    {
        /// <summary>
        /// El sistema se encuentra detenido
        /// </summary>
        Detenido,
        /// <summary>
        /// El sistema se encuentra en transici�n de parado a iniciado
        /// </summary>
        Arrancando,
        /// <summary>
        /// El sistema se encuentra en transici�n de iniciado a parado
        /// </summary>
        Deteniendo,
        /// <summary>
        /// El sistema se encuentra iniciado
        /// </summary>
        Iniciado
    }

    /// <summary>
    /// Par�metros de la aplicaci�n
    /// </summary>
    [Serializable]
    public class Configuracion: OAlmacenXML
    {
        #region Atributo(s) est�ticos
        /// <summary>
        /// Ruta por defecto del fichero xml de configuraci�n
        /// </summary>
        public static string ConfFile = Path.Combine(RutaParametrizable.AppFolder, "Configuracion" + Application.ProductName + ".xml");
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Tiempo entre refresco de monitorizaci�n
        /// </summary>
        [XmlIgnore]
        public TimeSpan CadenciaMonitorizacion = TimeSpan.FromMilliseconds(200);

        /// <summary>
        /// Tiempo entre refresco de monitorizaci�n
        /// </summary>
        public int CadenciaMonitorizacionMilisegundos
        {
            get { return (int)Math.Round(this.CadenciaMonitorizacion.TotalMilliseconds); }
            set { this.CadenciaMonitorizacion = TimeSpan.FromMilliseconds(value); }
        }

        /// <summary>
        /// Indica si el sistema utiliza o no base de datos SQLServer o por el contrario ataca a ficheros XML
        /// </summary>
        public bool UtilizaBaseDeDatos = true;

        /// <summary>
        /// Lista de informaciones de las bases de datos existentes en el sistema
        /// </summary>
        public List<InformacionBasesDatos> ListaInformacionBasesDatos;

        /// <summary>
        /// Opciones de configuraci�n del registro de eventos
        /// </summary>
        public OpcionesLogs OpcionesLogs;

        /// <summary>
        /// Opciones de configuraci�n del gestor de escritorios
        /// </summary>
        public OpcionesEscritorios OpcionesEscritorio;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public Configuracion()
            : base(ConfFile)
        {
            this.ListaInformacionBasesDatos = new List<InformacionBasesDatos>();
            this.OpcionesEscritorio = new OpcionesEscritorios();
            this.OpcionesLogs = new OpcionesLogs();
        }

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public Configuracion(string rutaFichero)
            : base(rutaFichero)
        {
        }
        #endregion Constructor
    }
}
