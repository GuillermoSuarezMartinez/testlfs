//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aiba�ez
// Created          : 06-09-2012
//
// Last Modified By : aiba�ez
// Last Modified On : 16-11-2012
// Description      : Borrada la implementaci�n de InicioSistema y ParoSistema
//                    Declarados como virtuales los m�todos InicioSistema y ParoSistema
//                     Es necesario heredarlos e implemenarlos en las clases hijas para dotarlos de funcionalidad
//                    Se ha extraido el atributo OpcionesEscritorio del fichero de configuraci�n
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;
using Orbita.Utiles;
using Orbita.Xml;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase est�tica encargada de dar acceso a toda la aplicaci�n al control del inicio y la detenci�n de los m�dulos instalados en el sistema
    /// </summary>
    public static class OSistemaManager
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de par�metros de entrada de la aplicaci�n
        /// </summary>
        public static string[] ListaParametrosEntradaAplicacion;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Campo del sistema que se ha arrancado
        /// </summary>
        private static OSistema _Sistema;
        /// <summary>
        /// Campo del sistema que se ha arrancado
        /// </summary>
        public static OSistema Sistema
        {
            get { return _Sistema; }
        }

        /// <summary>
        /// Enumerado que describe el estado del sistema
        /// </summary>
        public static EstadoSistema EstadoSistema
        {
            get { return _Sistema.EstadoSistema; }
        }

        /// <summary>
        /// Par�metros de la aplicaci�n
        /// </summary>
        public static ConfiguracionSistema Configuracion
        {
            get { return _Sistema.Configuracion; }
        }

        /// <summary>
        /// Modo de inicio del sistema
        /// </summary>
        private static ModoInicio _ModoInicio;
        /// <summary>
        /// Modo de inicio del sistema
        /// </summary>
        public static ModoInicio ModoInicio
        {
            get { return _ModoInicio; }
        }

        /// <summary>
        /// Informa de la integraci�n de la funcionalidad de m�quinas de estados dentro del sistema
        /// </summary>
        private static bool _IntegraMaquinaEstados;
        /// <summary>
        /// Informa de la integraci�n de la funcionalidad de m�quinas de estados dentro del sistema
        /// </summary>
        public static bool IntegraMaquinaEstados
        {
            get { return _IntegraMaquinaEstados; }
        }
        #endregion

        #region M�todo(s) privado(s)
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);
        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Constructor de los campos est�ticos de la clase
        /// </summary>
        public static bool Constructor(OSistema sistema, Form mainForm, bool instanciaUnica, bool integraMaquinasEstados)
        {
            _Sistema = sistema;

            bool resultado = true;
            if (instanciaUnica)
            {
                resultado = OInstanciaUnicaAplicacion.Execute();
            }

            App.FormularioPrincipal = mainForm;
            _IntegraMaquinaEstados = integraMaquinasEstados;

            return resultado;
        }
        /// <summary>
        /// Inicia el sistema de inspecci�n en tiempo real
        /// </summary>
        public static bool IniciarAplicacion(ModoInicio modoInicio, params string[] args)
        {
            // Par�metros de la apliaci�n
            ListaParametrosEntradaAplicacion = args;

            // Modo de inicio
            if (modoInicio == ModoInicio.Defecto)
            {
                if (Parametro("APruebaFallos"))
                {
                    modoInicio = Comun.ModoInicio.APruebaFallos;                    
                }
                else if (Parametro("Simulacion"))
                {
                    modoInicio = Comun.ModoInicio.Simulacion;
                }
            }
            _ModoInicio = modoInicio;

            bool resultado = false;
            if (Sistema is OSistema)
            {
                resultado = Sistema.IniciarAplicacion(true);
            }
            return resultado;
        }
        /// <summary>
        /// Detiene el funcionamiento del inspecci�n en tiempo real
        /// </summary>
        public static bool PararAplicacion()
        {
            bool resultado = false;
            if (Sistema is OSistema)
            {
                resultado = Sistema.PararAplicacion();
            }
            return resultado;
        }
        /// <summary>
        /// Reinicia el sistema de control en tiempo real
        /// </summary>
        public static bool ReiniciarAplicacion()
        {
            bool resultado = false;
            if (Sistema is OSistema)
            {
                resultado = true;

                if (resultado)
                {
                    resultado = Sistema.PararAplicacion();
                }

                if (resultado)
                {
                    resultado = Sistema.IniciarAplicacion(false);
                }
            }
            return resultado;
        }
        /// <summary>
        /// Se muestra un mensaje en el splash screen de la evoluci�n de arranque del sistema
        /// </summary>
        public static void MensajeInfoArranqueAplicacion(string mensaje, bool soloEnModoAPruebaFallos, OTipoMensaje tipoMensaje)
        {
            if (Sistema is OSistema)
            {
                Sistema.MensajeInfoArranqueAplicacion(mensaje, soloEnModoAPruebaFallos, tipoMensaje);
            }
        }

        /// <summary>
        /// Conslta de un par�metro de la aplicaci�n
        /// </summary>
        /// <returns></returns>
        public static bool Parametro(string textoParametro)
        {
            bool resultado = false;

            if (ListaParametrosEntradaAplicacion != null)
            {
                List<string> listaParametrosEntradaAplicacion = new List<string>(ListaParametrosEntradaAplicacion);

                resultado = listaParametrosEntradaAplicacion.Exists(delegate(string p) { return string.Equals(p, textoParametro, StringComparison.InvariantCultureIgnoreCase); });
            }

            return resultado;
        }

        #region Informaci�n del ordenador
        /// <summary>
        /// Obtiene la version del ensamblado actual
        /// </summary>
        /// <param name="asm">Ensamblado del cual se quiere conocer la versi�n</param>
        /// <returns>Versi�n del ensamblado</returns>
        public static string ObtenerVersion(System.Reflection.Assembly asm)
        {
            Version v = asm.GetName().Version;
            return (v.Major + "." + v.Minor + "." + v.Build + "." + v.Revision);
        } 
        /// <summary>
        /// Devuelve el espacio libre la unidad que contiene la ruta especificada en bytes , aunque sea de RED
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        public static long AvailableFreeSpace(string ruta)
        {
            long space = 0;

            try
            {
                if (Path.IsPathRooted(ruta))
                {
                    string root = Path.GetPathRoot(ruta);

                    if (!ruta.Contains(@"\\"))
                    {
                        DriveInfo[] DI = DriveInfo.GetDrives();
                        foreach (DriveInfo drive in DI)
                        {
                            if (drive.Name == root)
                            {
                                space = drive.AvailableFreeSpace;
                            }
                        }
                    }
                    else
                    {
                        ulong FreeBytesAvailable;
                        ulong TotalNumberOfBytes;
                        ulong TotalNumberOfFreeBytes;

                        bool success = GetDiskFreeSpaceEx(root, out FreeBytesAvailable, out TotalNumberOfBytes,
                                           out TotalNumberOfFreeBytes);
                        space = (long)FreeBytesAvailable;
                    }
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.Comun, "GetDiskSpace", exception);
            }

            return space;

        }
        #endregion

        #region Captura de pantalla
        /// <summary>
        /// Captura de toda la pantalla
        /// </summary>
        public static Bitmap CapturaPantalla()
        {
            Graphics gr = App.FormularioPrincipal.CreateGraphics();
            // Tama�o de lo que queremos copiar En este caso el tama�o de la pantalla principal
            Size fSize = Screen.PrimaryScreen.Bounds.Size;
            // Creamos el bitmap con el �rea que vamos a capturar
            Bitmap bm = new Bitmap(fSize.Width, fSize.Height, gr);
            // Un objeto Graphics a partir del bitmap
            Graphics gr2 = Graphics.FromImage(bm);
            // Copiar todo el �rea de la pantalla
            gr2.CopyFromScreen(0, 0, 0, 0, fSize);

            return bm;
        }
        #endregion
        #endregion
    }

    /// <summary>
    /// Clase que controla el inicio y la detenci�n del resto de m�dulos instalados en el sistema
    /// </summary>
    public class OSistema
    {
        #region Atributo(s)
        /// <summary>
        /// Par�metros de la aplicaci�n
        /// </summary>
        public ConfiguracionSistema Configuracion;
        #endregion

        #region Definicion(es) de evento(s)
        /// <summary>
        /// Evento de referesco de visualizaci�n
        /// </summary>
        public OSimpleMethod OnCambioEstado;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Enumerado que describe el estado del sistema
        /// </summary>
        private EstadoSistema _EstadoSistema;

        /// <summary>
        /// Enumerado que describe el estado del sistema
        /// </summary>
        public EstadoSistema EstadoSistema
        {
            get { return _EstadoSistema; }
            set
            {
                _EstadoSistema = value;
                if (this.OnCambioEstado != null)
                {
                    this.OnCambioEstado();
                }
            }
        }

        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OSistema()
            : this(ConfiguracionSistema.ConfFile)
        {
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OSistema(string configFile)
        {
            this.EstadoSistema = EstadoSistema.Detenido;

            try
            {
                this.Configuracion = (ConfiguracionSistema)(new ConfiguracionSistema(configFile).CargarDatos());
            }
            catch (FileNotFoundException)
            {
                this.MensajeInfoArranqueAplicacion("Imposible abrir el fichero de configuraci�n: " + configFile, true, OTipoMensaje.Error);
                this.Configuracion = new ConfiguracionSistema();
                this.Configuracion.Guardar();
            }
        }

        #endregion

        #region M�todo(s) virtual(es)
        /// <summary>
        /// Inicia el sistema de inspecci�n en tiempo real
        /// </summary>
        public virtual bool IniciarAplicacion(bool incial)
        {
            // A implementar en heredados
            return false;
        }
        /// <summary>
        /// Detiene el sistema de inspecci�n en tiempo real
        /// </summary>
        public virtual bool PararAplicacion()
        {
            // A implementar en heredados
            return false;
        }
        /// <summary>
        /// Se muestra un mensaje en el splash screen de la evoluci�n de arranque del sistema
        /// </summary>
        public virtual void MensajeInfoArranqueAplicacion(string mensaje, bool soloEnModoAPruebaFallos, OTipoMensaje tipoMensaje)
        {
            if (this.EstadoSistema == EstadoSistema.Arrancando)
            {
                if ((OSistemaManager.ModoInicio == ModoInicio.APruebaFallos) && (ODebug.IsWinForms()))
                {
                    OMensajes.Mostrar(mensaje, tipoMensaje);
                }
            }

            // A continuar implementando en heredados
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
    public class ConfiguracionSistema: OAlmacenXML
    {
        #region Atributo(s) est�ticos
        /// <summary>
        /// Ruta por defecto del fichero xml de configuraci�n
        /// </summary>
        public static string ConfFile = Path.Combine(ORutaParametrizable.AppFolder, "Configuracion" + Application.ProductName + ".xml");
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
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public ConfiguracionSistema()
            : base(ConfFile)
        {
            this.ListaInformacionBasesDatos = new List<InformacionBasesDatos>();
            this.OpcionesLogs = new OpcionesLogs();
        }

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public ConfiguracionSistema(string rutaFichero)
            : base(rutaFichero)
        {
        }
        #endregion Constructor
    }

    /// <summary>
    /// Informa del origen de los datos
    /// </summary>
    public enum OrigenDatos
    {
        /// <summary>
        /// Los datos perteneces a una base de datos
        /// </summary>
        [OAtributoEnumerado("Origen de base de datos")]
        OrigenBBDD = 0,
        /// <summary>
        /// Los datos pertenecen a un archivo xml
        /// </summary>
        [OAtributoEnumerado("Origen de fichero XML")]
        OrigenXML = 1
    }

    /// <summary>
    /// Indica el modo de inicio de la aplicaci�n
    /// </summary>
    public enum ModoInicio
    {
        /// <summary>
        /// Modo de inicio normal
        /// </summary>
        [OAtributoEnumerado("Modo de inicio por defecto")]
        Defecto = 0,
        /// <summary>
        /// Modo de inicio normal
        /// </summary>
        [OAtributoEnumerado("Modo de inicio normal")]
        Normal = 1,
        /// <summary>
        /// Modo de inicio a prueba de fallos
        /// </summary>
        [OAtributoEnumerado("Modo de inicio a prueba de fallos")]
        APruebaFallos = 2,
        /// <summary>
        /// Modo de inicio de simulaci�n
        /// </summary>
        [OAtributoEnumerado("Modo de inicio de simulaci�n")]
        Simulacion = 3
    }
}
