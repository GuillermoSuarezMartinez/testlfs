namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Clase que encapsula información de un puerto de comunicaciones
    /// </summary>
    public class OInformacionPuerto
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="idPuerto">Identificador númerico del puerto de comunicaciones</param>
        /// <param name="tipoPuerto">Tipo del puerto de comunicaciones</param>
        public OInformacionPuerto(int idPuerto, string tipoPuerto)
        {
            this.IdPuerto = idPuerto;
            this.TipoPuerto = tipoPuerto;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Identificador númerico del puerto de comunicaciones.
        /// </summary>
        public int IdPuerto { get; private set; }
        /// <summary>
        /// Identificador textual del puerto de comunicaciones.
        /// </summary>
        public string TipoPuerto { get; private set; }
        #endregion
    }
}