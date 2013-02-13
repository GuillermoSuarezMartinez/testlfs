//***********************************************************************
// Assembly         : Orbita.Controles
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Combo
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public abstract class OAparienciaBase
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OAparienciaBase.
        /// </summary>
        protected OAparienciaBase() { }
        #endregion

        #region Propiedades abstractas
        /// <summary>
        /// Determina el color de borde.
        /// </summary>
        public abstract System.Drawing.Color ColorBorde { get; set; }
        /// <summary>
        /// Determina el color de fondo.
        /// </summary>
        public abstract System.Drawing.Color ColorFondo { get; set; }
        /// <summary>
        /// Determina el color de texto.
        /// </summary>
        public abstract System.Drawing.Color ColorTexto { get; set; }
        /// <summary>
        /// Determina el estilo de borde.
        /// </summary>
        public abstract EstiloBorde EstiloBorde { get; set; }
        /// <summary>
        /// Determina la alineación horizontal del texto.
        /// </summary>
        public abstract AlineacionHorizontal AlineacionTextoHorizontal { get; set; }
        /// <summary>
        /// Determina la alineación vertical del texto.
        /// </summary>
        public abstract AlineacionVertical AlineacionTextoVertical { get; set; }
        /// <summary>
        /// Especifica como se reprensentará el texto cuando no hay suficiente espacio para mostrar la cadena completa.
        /// </summary>
        public abstract AdornoTexto AdornoTexto { get; set; }
        #endregion

        #region Métodos protegidos
        /// <summary>
        /// Resetear color de borde.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetColorBorde()
        {
            this.ColorBorde = System.Drawing.Color.Empty;
        }
        /// <summary>
        /// Resetear color de fondo.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetColorFondo()
        {
            this.ColorFondo = System.Drawing.Color.Empty;
        }
        /// <summary>
        /// Resetear color de texto.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetColorTexto()
        {
            this.ColorTexto = System.Drawing.Color.Empty;
        }
        /// <summary>
        /// Resetear estilo de borde.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetEstiloBorde()
        {
            this.EstiloBorde = EstiloBorde.Solido;
        }
        /// <summary>
        /// Resetear alineación de texto horizontal.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetAlineacionTextoHorizontal()
        {
            this.AlineacionTextoHorizontal = Configuracion.DefectoAlineacionTextoHorizontal;
        }
        /// <summary>
        /// Resetear alineación de texto vertical.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetAlineacionTextoVertical()
        {
            this.AlineacionTextoVertical = Configuracion.DefectoAlineacionTextoVertical;
        }
        /// <summary>
        /// Resetear adorno de texto.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetAdornoTexto()
        {
            this.AdornoTexto = Configuracion.DefectoAdornoTexto;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeColorBorde()
        {
            return (this.ColorBorde != System.Drawing.Color.Empty);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeColorFondo()
        {
            return (this.ColorFondo != System.Drawing.Color.Empty);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeColorTexto()
        {
            return (this.ColorTexto != System.Drawing.Color.Empty);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeEstiloBorde()
        {
            return (this.EstiloBorde != EstiloBorde.Solido);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeAlineacionTextoHorizontal()
        {
            return (this.AlineacionTextoHorizontal != Configuracion.DefectoAlineacionTextoHorizontal);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeAlineacionTextoVertical()
        {
            return (this.AlineacionTextoVertical != Configuracion.DefectoAlineacionTextoVertical);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeAdornoTexto()
        {
            return (this.AdornoTexto != Configuracion.DefectoAdornoTexto);
        }
        #endregion
    }
}
