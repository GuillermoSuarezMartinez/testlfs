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
namespace Orbita.Controles.Contenedores
{
    /// <summary>
    /// Orbita.Controles.Contenedores.OrbitaDialog.
    /// </summary>
    public partial class OrbitaDialog : System.Windows.Forms.Form
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.OrbitaDialog.
        /// </summary>
        public OrbitaDialog()
        {
            InitializeComponent();
            InitializeProperties();
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializar propiedades.
        /// </summary>
        void InitializeProperties()
        {
            this.OrbToolTip.Active = OConfiguracion.OrbFormVerToolTips;
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// KeyPress.
		/// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected virtual void OnKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
			try
			{
                if (e == null)
                {
                    return;
                }
                if (e.KeyChar == (char)System.ConsoleKey.Escape)
				{
					this.Close();
				}
			}
            catch (Orbita.Controles.Shared.OExcepcion ex)
			{
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
			}
        }
        #endregion
    }
}