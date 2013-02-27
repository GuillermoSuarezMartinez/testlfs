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
using System;
using System.Windows.Forms;
namespace Orbita.Controles.Grid
{
    public partial class Posicion : UserControl
    {
        #region Eventos
        public event EventHandler<OPropiedadEventArgs> AceptarClick;
        #endregion

        #region Constructor
        public Posicion()
        {
            InitializeComponent();
        }
        #endregion

        #region Manejadores de eventos
        private void numPosicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == System.Convert.ToChar('\r'))
            {
                if (this.btnAceptar.CanFocus)
                {
                    this.btnAceptar.Focus();
                }
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.AceptarClick != null)
            {
                OPropiedadEventArgs args = new OPropiedadEventArgs(this.numPosicion.Value.ToString());
                this.AceptarClick(this, args);
            }
        }
        private void btnAceptar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == System.Convert.ToChar('\r'))
            {
                if (this.AceptarClick != null)
                {
                    OPropiedadEventArgs args = new OPropiedadEventArgs(this.numPosicion.Value.ToString());
                    this.AceptarClick(this, args);
                }
            }
        }
        #endregion
    }
}
