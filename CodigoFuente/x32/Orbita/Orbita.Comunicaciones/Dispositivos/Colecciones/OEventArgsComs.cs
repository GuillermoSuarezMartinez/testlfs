using System;
namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Clase que representa eventos con argumentos adicionales tipados (EventArgs).
    /// </summary>
    [Serializable]
    public class OEventArgsComs : EventArgs
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OEventArgsComs.
        /// </summary>
        public OEventArgsComs() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OEventArgsComs.
        /// </summary>
        /// <param name="idMensaje">Identificador de mensaje.</param>
        public OEventArgsComs(int idMensaje)
        {
            this.Id = idMensaje;
        }
        #endregion Constructores

        #region Propiedades
        /// <summary>
        /// Valores de las variables.
        /// </summary>
        public object Valores { get; set; }
        /// <summary>
        /// Variables del dispositivo.
        /// </summary>
        public object Variables { get; set; }
        /// <summary>
        /// Identificador del mensaje.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identificador del mensaje.
        /// </summary>
        public int IdDispositivo { get; set; }
        #endregion Propiedades
    }
}