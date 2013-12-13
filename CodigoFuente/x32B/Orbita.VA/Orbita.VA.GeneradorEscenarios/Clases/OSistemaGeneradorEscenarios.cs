using System;
using Orbita.Utiles;
using Orbita.VA.Comun;
using Orbita.BBDD;

namespace Orbita.VA.GeneradorEscenarios
{
    /// <summary>
    /// Clase que controla el inicio y la detención del resto de módulos instalados en el sistema
    /// </summary>
    public class OSistemaGeneradorEscenarios : OSistema
    {
        #region Atributo(s)
        /// <summary>
        /// Fichero de configuración de la base de datos
        /// </summary>
        private static string ConfigFile;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="panelEstadoImg">Panel de imagen en la barra de estado del formulario principal donde se muestra el estado del sistema</param>
        /// <param name="panelEstadoTexto">Panel de texto en la barra de estado del formulario principal donde se muestra el estado del sistema</param>
        /// <param name="menu">Menú del formulario principal</param>
        public OSistemaGeneradorEscenarios(string configFile)
            : base()
        {
            ConfigFile = configFile;
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Inicia el sistema de inspección en tiempo real
        /// </summary>
        protected bool InicioSistema()
        {
            bool resultado = false;

            if (this.EstadoSistema == EstadoSistema.Detenido)
            {
                this.EstadoSistema = EstadoSistema.Arrancando;
                resultado = true;

                // Fase 1: Se obtiene la conexión con la BBDD y se inicia el registro de eventos
                if (resultado)
                {
                    try
                    {
                        // Creación del log de eventos
                        MensajeInfoArranqueAplicacion("Creando log de eventos", false, OTipoMensaje.Info);
                        OLogsVAGeneradorEscenarios.GeneradorCodigo.Info("IniciarSistema", "Inicio del sistema");

                        // Conexión con la base de datos
                        MensajeInfoArranqueAplicacion("Conectando con las bases de datos", false, OTipoMensaje.Info);
                        OBBDDManager.LeerFicheroConfig(ConfigFile);
                        OBaseDatosParam.CompruebaAccesoBasesDatos(TimeSpan.FromSeconds(20));
                    }
                    catch (Exception exception)
                    {
                        OLogsVAGeneradorEscenarios.GeneradorCodigo.Error(exception, "IniciarSistema");
                        resultado = false;
                    }
                }
            }

            return resultado;
        }
        /// <summary>
        /// Se ejecuta al finalizar el inicio del sistema
        /// </summary>
        protected void FinInicioSistema(ref bool resultado)
        {
            if (resultado)
            {
                try
                {
                    // Ocultamos el formulario Splash
                    MensajeInfoArranqueAplicacion("Inicio finalizado con éxito", false, OTipoMensaje.Info);
                    OLogsVAGeneradorEscenarios.GeneradorCodigo.Info("IniciarSistema", "Inicio finalizado con éxito");
                }
                catch (Exception exception)
                {
                    OLogsVAGeneradorEscenarios.GeneradorCodigo.Error(exception, "IniciarSistema", "Error: ".ToString());
                    resultado = false;
                }
            }

            // Cambiamos el estado del sistema según el resultado del arranque
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
        /// Detiene el funcionamiento del inspección en tiempo real
        /// </summary>
        protected bool ParoSistema()
        {
            bool resultado = false;

            if (this.EstadoSistema == EstadoSistema.Iniciado)
            {
                this.EstadoSistema = EstadoSistema.Deteniendo;
                resultado = true;

                OLogsVAGeneradorEscenarios.GeneradorCodigo.Info("PararSistema", "Paro del sistema");
            }

            return resultado;
        }
        /// <summary>
        /// Se ejecuta al finalizar la detención del sistema
        /// </summary>
        protected void FinParoSistema(ref bool resultado)
        {
            if (resultado)
            {
                try
                {
                    // Finalización del log de eventos
                    OLogsVAGeneradorEscenarios.GeneradorCodigo.Info("PararSistema", "Paro del sistema finalizado con éxito");
                    //OLogsVAGeneradorEscenarios.Finalizar();
                    //OLogsVAGeneradorEscenarios.Destructor();
                }
                catch
                {
                    resultado = false;
                }

                // Cambiamos el estado del sistema según el resultado del arranque
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

        #region Método(s) virtual(es)
        /// <summary>
        /// Inicia el sistema de inspección en tiempo real
        /// </summary>
        public override bool IniciarAplicacion(bool incial)
        {
            bool resultado;

            resultado = this.InicioSistema();
            this.FinInicioSistema(ref resultado);

            return resultado;
        }
        /// <summary>
        /// Detiene el sistema de inspección en tiempo real
        /// </summary>
        public override bool PararAplicacion()
        {
            bool resultado;

            resultado = this.ParoSistema();
            this.FinParoSistema(ref resultado);

            return resultado;
        }
        /// <summary>
        /// Se muestra un mensaje en el splash screen de la evolución de arranque del sistema
        /// </summary>
        public override void MensajeInfoArranqueAplicacion(string mensaje, bool soloEnModoAPruebaFallos, OTipoMensaje tipoMensaje)
        {
            base.MensajeInfoArranqueAplicacion(mensaje, soloEnModoAPruebaFallos, tipoMensaje);

            if (this.EstadoSistema == EstadoSistema.Arrancando)
            {
                Console.WriteLine(mensaje);
            }
        }
        #endregion

        #region Eventos
        private void OnShowLogMessage(string message)
        {
            Console.WriteLine(message);
        }

        private void OnShowLogException(Exception excepcion)
        {
            Console.WriteLine(excepcion.ToString());
        }
        #endregion
    }
}
