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
using System.ComponentModel;
namespace Orbita.Controles.Comunes
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OTextBox
    {
        #region Atributos
        OrbitaTextBox control;
        bool autoScrollBar;
        #endregion

        #region Constructor
        public OTextBox(object control)
            : base()
        {
            this.control = (OrbitaTextBox)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaTextBox Control
        {
            get { return this.control; }
        }
        [System.ComponentModel.Description("")]
        public bool AutoScrollBar
        {
            get { return this.autoScrollBar; }
            set { this.autoScrollBar = value; }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeAutoScrollBar()
        {
            return (this.AutoScrollBar != Configuracion.DefectoAutoScrollBar);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetAutoScrollBar()
        {
            this.AutoScrollBar = Configuracion.DefectoAutoScrollBar;
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