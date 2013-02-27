//***********************************************************************
// Assembly         : Orbita.Controles.Grid
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Grid
{
    public class OColumnaSumario
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
        public OColumnaSumario(string mascara)
        {
            this.mascara = mascara;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Sumario.
        /// </summary>
        /// <param name="mascara">Máscara de sumario.</param>
        /// <param name="operacion">Operación a aplicar.</param>
        public OColumnaSumario(string mascara, Infragistics.Win.UltraWinGrid.SummaryType operacion)
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
