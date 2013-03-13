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
    public class OListView
    {
        #region Atributos
        OrbitaListView control;
        /// <summary>
        /// Colección de todos los encabezados de columna que aparecen en el control.
        /// </summary>
        OColumnHeaderCollection columnas;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OListView.
        /// </summary>
        /// <param name="control"></param>
        public OListView(object control)
            : base()
        {
            this.control = (OrbitaListView)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaListView Control
        {
            get { return this.control; }
        }
        /// <summary>
        /// Obtiene la colección de todos los encabezados de columna que aparecen en el control.
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public OColumnHeaderCollection Columnas
        {
            get { return this.columnas; }
            set { this.columnas = value; }
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