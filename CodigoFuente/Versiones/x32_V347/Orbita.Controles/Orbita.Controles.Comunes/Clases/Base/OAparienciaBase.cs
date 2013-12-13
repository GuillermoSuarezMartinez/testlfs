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
    /// <summary>
    /// Clase base abstracta de apariencia.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public abstract class OAparienciaBase
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OAparienciaBase.
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
        /// Resetear color de borde con el valor predeterminado.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetColorBorde()
        {
            this.ColorBorde = Configuración.DefectoColorBorde;
        }
        /// <summary>
        /// Resetear color de fondo con el valor predeterminado.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetColorFondo()
        {
            this.ColorFondo = Configuración.DefectoColorFondo;
        }
        /// <summary>
        /// Resetear color de texto con el valor predeterminado.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetColorTexto()
        {
            this.ColorTexto = Configuración.DefectoColorTexto;
        }
        /// <summary>
        /// Resetear estilo de borde con el valor predeterminado.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetEstiloBorde()
        {
            this.EstiloBorde = Configuración.DefectoEstiloBorde;
        }
        /// <summary>
        /// Resetear alineación de texto horizontal con el valor predeterminado.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetAlineacionTextoHorizontal()
        {
            this.AlineacionTextoHorizontal = Configuración.DefectoAlineacionTextoHorizontal;
        }
        /// <summary>
        /// Resetear alineación de texto vertical con el valor predeterminado.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetAlineacionTextoVertical()
        {
            this.AlineacionTextoVertical = Configuración.DefectoAlineacionTextoVertical;
        }
        /// <summary>
        /// Resetear adorno de texto con el valor predeterminado.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetAdornoTexto()
        {
            this.AdornoTexto = Configuración.DefectoAdornoTexto;
        }
        /// <summary>
        /// Comprueba si el color de borde ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns>True si el color de borde ha cambiado; en otro caso, retorna false.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeColorBorde()
        {
            return (this.ColorBorde != Configuración.DefectoColorBorde);
        }
        /// <summary>
        /// Comprueba si el color de fondo ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns>True si el color de fondo ha cambiado; en otro caso, retorna false.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeColorFondo()
        {
            return (this.ColorFondo != Configuración.DefectoColorFondo);
        }
        /// <summary>
        /// Comprueba si el color de texto ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns>True si el color de texto ha cambiado; en otro caso, retorna false.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeColorTexto()
        {
            return (this.ColorTexto != Configuración.DefectoColorTexto);
        }
        /// <summary>
        /// Comprueba si el estilo de borde ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns>True si el estilo de borde ha cambiado; en otro caso, retorna false.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeEstiloBorde()
        {
            return (this.EstiloBorde != Configuración.DefectoEstiloBorde);
        }
        /// <summary>
        /// Comprueba si la alineación de texto horizontal ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns>True si la alineación de texto horizontal ha cambiado; en otro caso, retorna false.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeAlineacionTextoHorizontal()
        {
            return (this.AlineacionTextoHorizontal != Configuración.DefectoAlineacionTextoHorizontal);
        }
        /// <summary>
        /// Comprueba si la alineación de texto vertical ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns>True si la alineación de texto vertical ha cambiado; en otro caso, retorna false.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeAlineacionTextoVertical()
        {
            return (this.AlineacionTextoVertical != Configuración.DefectoAlineacionTextoVertical);
        }
        /// <summary>
        /// Comprueba si el adorno de texto ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns>True si el adorno de texto ha cambiado; en otro caso, retorna false.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeAdornoTexto()
        {
            return (this.AdornoTexto != Configuración.DefectoAdornoTexto);
        }
        #endregion
    }
}