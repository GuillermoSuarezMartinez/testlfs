//***********************************************************************
// Assembly         : Orbita.Controles.Comunes
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Comunes
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OUltraLabel : OControlBase
    {
        #region Atributos
        /// <summary>
        /// Control (sender).
        /// </summary>
        OrbitaUltraLabel control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OUltraLabel.
        /// </summary>
        /// <param name="control"></param>
        public OUltraLabel(object control)
            : base()
        {
            this.control = (OrbitaUltraLabel)control;
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina la apariencia de OrbitaUltraCombo.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        internal OrbitaUltraLabel Control
        {
            get { return this.control; }
        }
        #endregion

        #region Manejadores de eventos
        protected override void AparienciaChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.Appearance.BackColor = this.Apariencia.ColorFondo;
            this.Control.Appearance.BorderColor = this.Apariencia.ColorBorde;
            this.Control.Appearance.ForeColor = this.Apariencia.ColorTexto;
            this.Control.Appearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.Apariencia.AlineacionTextoHorizontal;
            this.Control.Appearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.Apariencia.AlineacionTextoVertical;
            this.Control.Appearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.Apariencia.AdornoTexto;
        }
        #endregion

        #region Métodos públicos
        public override string ToString()
        {
            return null;
        }
        #endregion
    }
}