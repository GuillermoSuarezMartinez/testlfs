//***********************************************************************
// Assembly         : Orbita.Controles.Gantt
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Gantt
{
    public class OColumnHeader
    {
        #region Atributos públicos
        /// <summary>
        /// Caption.
        /// </summary>
        string caption = "";
        /// <summary>
        /// Visible.
        /// </summary>
        bool visible = false;
        /// <summary>
        /// Tipo.
        /// </summary>
        System.Type tipo = typeof(object);
        /// <summary>
        /// Ancho.
        /// </summary>
        int ancho = 0;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Columna.
        /// </summary>
        public OColumnHeader() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Columna.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="visible"></param>
        public OColumnHeader(string caption, bool visible)
            : this(caption, visible, 0) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Columna.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="visible"></param>
        /// <param name="ancho"></param>
        public OColumnHeader(string caption, bool visible, int ancho)
        {
            this.Caption = caption;
            this.Visible = visible;
            this.Ancho = ancho;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Caption.
        /// </summary>
        public string Caption
        {
            get { return this.caption; }
            set { this.caption = value; }
        }
        /// <summary>
        /// Visible.
        /// </summary>
        public bool Visible
        {
            get { return this.visible; }
            set { this.visible = value; }
        }
        /// <summary>
        /// Tipo.
        /// </summary>
        public System.Type Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }
        /// <summary>
        /// Ancho.
        /// </summary>
        public int Ancho
        {
            get { return this.ancho; }
            set { this.ancho = value; }
        }
        #endregion
    }
}