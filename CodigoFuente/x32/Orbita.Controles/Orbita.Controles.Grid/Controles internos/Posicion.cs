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
    public partial class Posicion : Orbita.Controles.Shared.OrbitaUserControl
    {
        #region Eventos
        public event System.EventHandler<OPropiedadEventArgs> AceptarClick;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.Posicion.
        /// </summary>
        public Posicion()
        {
            InitializeComponent();
        }
        #endregion

        #region Manejadores de eventos
        private void numPosicion_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == System.Convert.ToChar('\r'))
            {
                if (this.btnAceptar.CanFocus)
                {
                    this.btnAceptar.Focus();
                }
            }
        }
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (this.AceptarClick != null)
            {
                OPropiedadEventArgs args = new OPropiedadEventArgs(this.numPosicion.Value.ToString());
                this.AceptarClick(this, args);
            }
        }
        private void btnAceptar_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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