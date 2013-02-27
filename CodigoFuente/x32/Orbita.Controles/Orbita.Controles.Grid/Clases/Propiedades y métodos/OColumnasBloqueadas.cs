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
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OColumnasBloqueadas : OControlBase
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OBloqueadas.
        /// </summary>
        public OColumnasBloqueadas()
            : base() { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina la apariencia de columnas bloqueadas.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        #endregion

        #region Métodos públicos
        public void AsignarEstilo(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna)
        {
            if (columna.Bloqueado)
            {
                this.AsignarEstilo(banda, columna.Nombre);
            }
        }
        public void AsignarEstilo(Infragistics.Win.UltraWinGrid.UltraGridBand banda, string columna)
        {
            if (banda != null && banda.Columns.Exists(columna))
            {
                // Columnas no accesibles mediante el ratón.
                banda.Columns[columna].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                // Estilos: colores.
                banda.Columns[columna].CellAppearance.BackColor = this.Apariencia.ColorFondo;
                banda.Columns[columna].FilterCellAppearance.BackColor = System.Drawing.Color.Transparent;
            }
        }
        #endregion
    }
}
