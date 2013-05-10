using System.Windows.Forms;
namespace Orbita.Controles.Comunicaciones
{
    /// <summary>
    /// Interfaz encargada de apagar y encender un monitor
    /// </summary>
    /// <summary>
    /// Interfaz encargada de apagar y encender un monitor
    /// </summary>
    interface IMonitor
    {
        #region Métodos
        /// <summary>
        /// método que apaga la pantalla
        /// </summary>
        /// <param name="formulario">formulario</param>
        void ApagaPantalla(Form formulario);
        /// <summary>
        /// método que enciende la pantalla
        /// </summary>
        /// <param name="formulario">formulario</param>
        void EncenderPantalla(Form formulario);
        #endregion
    }
}