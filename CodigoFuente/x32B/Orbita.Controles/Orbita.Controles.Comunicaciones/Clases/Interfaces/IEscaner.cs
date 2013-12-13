using System;
using System.ComponentModel;
namespace Orbita.Controles.Comunicaciones
{
    #region Delegados
    /// <summary>
    /// Delegado del evento NuevoCodigoEventHandler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="codigo">código leído</param>
    public delegate void NuevoCodigoEventHandler(object sender, string codigo);
    #endregion

    /// <summary>
    /// Interfaz de lectoras de códigos
    /// </summary>
    interface IEscaner
    {
        #region Propiedades
        [Description("Identificador del dispositivo")]
        [Browsable(true), DisplayName("ODispositivoID")]
        [DefaultValue("")]
        string DispositivoID
        {
            get;
            set;
        }
        /// <summary>
        /// Resultado codigo de barras
        /// </summary>
        [Category("GateSuite"),
        Description("Resultado código de barras.")]
        string Codigo
        {
            get;
        }
        /// <summary>
        /// Tiempo pulsación
        /// </summary>
        [Category("GateSuite"),
        Description("Tiempo pulsación."),
        DefaultValue(500)]
        int TiempoAdquisicion
        {
            get;
            set;
        }
        /// <summary>
        /// Longitud código de barras
        /// </summary>
        [Category("GateSuite"),
        Description("Longitud código de barras."),
        DefaultValue(20)]
        int LongitudCodigo
        {
            get;
            set;
        }
        /// <summary>
        /// Validez del código
        /// </summary>
        [Category("GateSuite"),
        Description("Validez del código"),
        DefaultValue(false)]
        bool CodigoValido
        {
            get;
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Se lanza al obtener un código de barras
        /// </summary>
        [Category("GateSuite"),
        Description("Se lanza al obtener un código de barras.")]
        event NuevoCodigoEventHandler NuevoCodigo;
        #endregion

        #region Métodos
        /// <summary>
        /// Si pasa el tiempo definido en TiempoAdquisición anula el código
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TimerTickHandler(object sender, EventArgs e);
        /// <summary>
        /// Agrega un carácter
        /// </summary>
        /// <param name="caracter"></param>
        void AgregarCaracter(char caracter);
        /// <summary>
        /// método que comprueba la comunicación con el lector de códigos de barra
        /// </summary>
        /// <returns></returns>
        bool CompruebaComunicacionLectorCodigoBarras();
        #endregion
    }
}