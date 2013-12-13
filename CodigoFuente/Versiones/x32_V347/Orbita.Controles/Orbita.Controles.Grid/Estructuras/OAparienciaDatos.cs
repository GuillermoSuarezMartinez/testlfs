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
    public struct OAparienciaDatos
    {
        #region Atributos
        /// <summary>
        /// Color de borde.
        /// </summary>
        System.Drawing.Color colorBorde;
        /// <summary>
        /// Color de fondo.
        /// </summary>
        System.Drawing.Color colorFondo;
        /// <summary>
        /// Color de texto.
        /// </summary>
        System.Drawing.Color colorTexto;
        /// <summary>
        /// Estilo de borde.
        /// </summary>
        EstiloBorde estiloBorde;
        /// <summary>
        /// Alineación de texto horizontal.
        /// </summary>
        AlineacionHorizontal alineacionTextoHorizontal;
        /// <summary>
        /// Alineación de texto vertical.
        /// </summary>
        AlineacionVertical alineacionTextoVertical;
        /// <summary>
        /// Adorno de texto.
        /// </summary>
        AdornoTexto adornoTexto;
        #endregion

        #region Propiedades
        /// <summary>
        /// Color de borde.
        /// </summary>
        public System.Drawing.Color ColorBorde
        {
            get { return this.colorBorde; }
            set { this.colorBorde = value; }
        }
        /// <summary>
        /// Color de fondo.
        /// </summary>
        public System.Drawing.Color ColorFondo
        {
            get { return this.colorFondo; }
            set { this.colorFondo = value; }
        }
        /// <summary>
        /// Color de texto.
        /// </summary>
        public System.Drawing.Color ColorTexto
        {
            get { return this.colorTexto; }
            set { this.colorTexto = value; }
        }
        /// <summary>
        /// Estilo de borde.
        /// </summary>
        public EstiloBorde EstiloBorde
        {
            get { return this.estiloBorde; }
            set { this.estiloBorde = value; }
        }
        /// <summary>
        /// Alineación de texto horizontal.
        /// </summary>
        public AlineacionHorizontal AlineacionTextoHorizontal
        {
            get { return this.alineacionTextoHorizontal; }
            set { this.alineacionTextoHorizontal = value; }
        }
        /// <summary>
        /// Alineación de texto vertical.
        /// </summary>
        public AlineacionVertical AlineacionTextoVertical
        {
            get { return this.alineacionTextoVertical; }
            set { this.alineacionTextoVertical = value; }
        }
        /// <summary>
        /// Adorno de texto.
        /// </summary>
        public AdornoTexto AdornoTexto
        {
            get { return this.adornoTexto; }
            set { this.adornoTexto = value; }
        }
        #endregion
    }
}