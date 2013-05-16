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
    /// <summary>
    /// Orbita.Controles.Combo.Configuracion.
    /// </summary>
    public static class OConfiguracion
    {
        #region Atributos privados estáticos
        /// <summary>
        /// ColorBorde.
        /// </summary>
        static System.Drawing.Color CboColorBorde = System.Drawing.Color.DimGray;
        /// <summary>
        /// ColorFondo.
        /// </summary>
        static System.Drawing.Color CboColorFondo = System.Drawing.Color.FromArgb(248, 197, 129);
        /// <summary>
        /// ColorFila.
        /// </summary>
        static System.Drawing.Color CboColorFila = System.Drawing.Color.White;
        /// <summary>
        /// ColorTextoFila.
        /// </summary>
        static System.Drawing.Color CboColorTextoFila = System.Drawing.Color.Black;
        /// <summary>
        /// ColorFilaActiva.
        /// </summary>
        static System.Drawing.Color CboColorFilaActiva = System.Drawing.Color.DarkOrange;
        /// <summary>
        /// ColorTextoFilaActiva.
        /// </summary>
        static System.Drawing.Color CboColorTextoFilaActiva = System.Drawing.Color.White;
        /// <summary>
        /// ColorFilaAlterna.
        /// </summary>
        static System.Drawing.Color CboColorFilaAlterna = System.Drawing.Color.FromArgb(255, 243, 223);
        /// <summary>
        /// ColorTextoFilaAlterna.
        /// </summary>
        static System.Drawing.Color CboColorTextoFilaAlterna = System.Drawing.Color.Black;
        /// <summary>
        /// ColorCabecera.
        /// </summary>
        static System.Drawing.Color CboColorCabecera = System.Drawing.Color.DarkOrange;
        #endregion

        #region Propiedades públicas estáticas
        /// <summary>
        /// ColorBorde.
        /// </summary>
        public static System.Drawing.Color OrbCboColorBorde
        {
            get { return OConfiguracion.CboColorBorde; }
            set { OConfiguracion.CboColorBorde = value; }
        }
        /// <summary>
        /// ColorFondo.
        /// </summary>
        public static System.Drawing.Color OrbCboColorFondo
        {
            get { return OConfiguracion.CboColorFondo; }
            set { OConfiguracion.CboColorFondo = value; }
        }
        /// <summary>
        /// ColorFila.
        /// </summary>
        public static System.Drawing.Color OrbCboColorFila
        {
            get { return OConfiguracion.CboColorFila; }
            set { OConfiguracion.CboColorFila = value; }
        }
        /// <summary>
        /// ColorTextoFila.
        /// </summary>
        public static System.Drawing.Color OrbCboColorTextoFila
        {
            get { return OConfiguracion.CboColorTextoFila; }
            set { OConfiguracion.CboColorTextoFila = value; }
        }
        /// <summary>
        /// ColorFilaActiva.
        /// </summary>
        public static System.Drawing.Color OrbCboColorFilaActiva
        {
            get { return OConfiguracion.CboColorFilaActiva; }
            set { OConfiguracion.CboColorFilaActiva = value; }
        }
        /// <summary>
        /// ColorTextoFilaActiva.
        /// </summary>
        public static System.Drawing.Color OrbCboColorTextoFilaActiva
        {
            get { return OConfiguracion.CboColorTextoFilaActiva; }
            set { OConfiguracion.CboColorTextoFilaActiva = value; }
        }
        /// <summary>
        /// ColorFilaAlterna.
        /// </summary>
        public static System.Drawing.Color OrbCboColorFilaAlterna
        {
            get { return OConfiguracion.CboColorFilaAlterna; }
            set { OConfiguracion.CboColorFilaAlterna = value; }
        }
        /// <summary>
        /// ColorTextoFilaAlterna.
        /// </summary>
        public static System.Drawing.Color OrbCboColorTextoFilaAlterna
        {
            get { return OConfiguracion.CboColorTextoFilaAlterna; }
            set { OConfiguracion.CboColorTextoFilaAlterna = value; }
        }
        /// <summary>
        /// ColorCabecera.
        /// </summary>
        public static System.Drawing.Color OrbCboColorCabecera
        {
            get { return OConfiguracion.CboColorCabecera; }
            set { OConfiguracion.CboColorCabecera = value; }
        }
        #endregion
    }
}