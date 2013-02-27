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
    public partial class FrmGuardarArchivo : Orbita.Controles.Contenedores.OrbitaDialog
    {
        #region Atributos
        bool _nueva = true;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.DialogoGuardarArchivo.
        /// </summary>
        public FrmGuardarArchivo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.DialogoGuardarArchivo.
        /// </summary>
        /// <param name="nombre">Nombre.</param>
        /// <param name="descripcion">Descripción.</param>
        public FrmGuardarArchivo(string nombre, string descripcion)
            : this()
        {
            // Visualizar la posibilidad de crear nueva plantilla en vez de sobreescribir la actual.
            this.chbCrearNuevaPlantilla.Visible = !string.IsNullOrEmpty(nombre);
            this.txtNombre.Text = nombre;
            this.txtDescripcion.Text = descripcion;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Nombre.
        /// </summary>
        public string Nombre
        {
            get { return this.txtNombre.Text; }
        }
        /// <summary>
        /// Descripción.
        /// </summary>
        public string Descripcion
        {
            get { return this.txtDescripcion.Text; }
        }
        /// <summary>
        /// Nueva.
        /// </summary>
        public bool Nueva
        {
            get { return this._nueva; }
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// TextChanged.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void txtNombre_TextChanged(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Nombre.Trim()) && !this.btnAceptar.Enabled)
            {
                this.btnAceptar.Enabled = true;
            }
            else if (string.IsNullOrEmpty(this.Nombre.Trim()) && this.btnAceptar.Enabled)
            {
                this.btnAceptar.Enabled = false;
            }
        }
        /// <summary>
        /// CheckedChanged.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chbCrearNuevaPlantilla_CheckedChanged(object sender, System.EventArgs e)
        {
            this._nueva = (!this.chbCrearNuevaPlantilla.Visible) || ((this.chbCrearNuevaPlantilla.Visible) && this.chbCrearNuevaPlantilla.Checked);
        }
        #endregion
    }
}
