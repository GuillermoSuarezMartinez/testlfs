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
    public partial class OrbitaUltraMaskedEdit : Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraMaskedEdit.
        /// </summary>
        public OrbitaUltraMaskedEdit()
            : base()
        {
            InitializeComponent();
        }
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado Enter del control.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void OrbEnterHandler(object sender, System.EventArgs e);
        /// <summary>
        /// Delegado Click del control.
        /// </summary>
        public delegate void OrbClickHandler(object sender, System.EventArgs e);
        #endregion

        #region Eventos
        /// <summary>
        /// Cuando el control se activa por tabulación o .focus().
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Enter del control")]
        public event OrbEnterHandler OrbEnterControl;
        /// <summary>
        /// Cuando se hace click en el control.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Click en el control")]
        public event OrbClickHandler OrbClickControl;
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Enter.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void OrbitaUltraMaskedEdit_Enter(object sender, System.EventArgs e)
        {
            try
            {
                this.SelectAll();
                if (OrbEnterControl != null)
                {
                    OrbEnterControl(this, e);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// Click.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void OrbitaUltraMaskedEdit_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.Text.Trim()))
                {
                    this.SelectAll();
                }
                if (OrbClickControl != null)
                {
                    OrbClickControl(this, e);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        #endregion
    }
}