namespace Orbita.Controles.Grid
{
    /// <summary>
    /// Orbita.Controles.Sumario.
    /// </summary>
    public class OSumario
    {
        #region Atributos
        /// <summary>
        /// Máscara de sumario.
        /// </summary>
        string mascara = string.Empty;
        /// <summary>
        /// Operación a aplicar.
        /// </summary>
        Infragistics.Win.UltraWinGrid.SummaryType operacion = Infragistics.Win.UltraWinGrid.SummaryType.Sum;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Sumario.
        /// </summary>
        /// <param name="mascara">Máscara de sumario.</param>
        public OSumario(string mascara)
        {
            this.mascara = mascara;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Sumario.
        /// </summary>
        /// <param name="mascara">Máscara de sumario.</param>
        /// <param name="operacion">Operación a aplicar.</param>
        public OSumario(string mascara, Infragistics.Win.UltraWinGrid.SummaryType operacion)
        {
            this.mascara = mascara;
            this.operacion = operacion;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Máscara de sumario.
        /// </summary>
        public string Mascara
        {
            get { return this.mascara; }
            set { this.mascara = value; }
        }
        /// <summary>
        /// Operación a aplicar.
        /// </summary>
        public Infragistics.Win.UltraWinGrid.SummaryType Operacion
        {
            get { return this.operacion; }
            set { this.operacion = value; }
        }
        #endregion
    }
}
