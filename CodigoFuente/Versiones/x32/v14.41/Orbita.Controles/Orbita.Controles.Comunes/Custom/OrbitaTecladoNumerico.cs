//***********************************************************************
// Assembly         : Orbita.Controles.Comunes
// Author           : aibañez
// Created          : 14-05-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.Data;
using System.Windows.Forms;

namespace Orbita.Controles.Comunes
{
    /// <summary>
    /// Teclado numérico en pantalla
    /// </summary>
    public partial class OrbitaTecladoNumerico : UserControl
    {
        #region Eventos
        /// <summary>
        /// Evento de aceptación
        /// </summary>
        public event TextEventHandler BotonIntroClick;
        /// <summary>
        /// Evento de aceptación
        /// </summary>
        public event KeyEventHandler BotonClick;
        /// <summary>
        /// Evento de cancelación
        /// </summary>
        public event System.EventHandler BotonEscClick;
        #endregion

        #region Propiedades
        /// <summary>
        /// Resultado de la introducción de texto
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public string Resultado
        {
            get { return this.txtResultado.Text; }
        }
        /// <summary>
        /// Indica que se ha de visualizar el editor
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Indica que se ha de visualizar el editor")]
        [System.ComponentModel.DefaultValue(true)]
        public bool VisualizarEditor
        {
            get { return this.PnlTop.Visible; }
            set { this.PnlTop.Visible = value; }
        }
        /// <summary>
        /// Indica que se ha de visualizar la tecla de intro
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Indica que se ha de visualizar la tecla de Intro")]
        [System.ComponentModel.DefaultValue(true)]
        public bool VisualizarIntro
        {
            get { return this.btnIntro.Visible; }
            set { this.btnIntro.Visible = value; }
        }
        /// <summary>
        /// Indica que se ha de visualizar la tecla de escape
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Indica que se ha de visualizar la tecla de escape")]
        [System.ComponentModel.DefaultValue(true)]
        public bool VisualizarEsc
        {
            get { return this.BtnEsc.Visible; }
            set { this.BtnEsc.Visible = value; }
        }
        /// <summary>
        /// Indica que se ha de visualizar la tecla de retroceso
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Indica que se ha de visualizar la tecla de retroceso")]
        [System.ComponentModel.DefaultValue(true)]
        public bool VisualizarRet
        {
            get { return this.btnRetrocede.Visible; }
            set { this.btnRetrocede.Visible = value; }
        }
        /// <summary>
        /// Indica que se ha de visualizar la tecla del desplegable
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Indica que se ha de visualizar la tecla del desplegable")]
        [System.ComponentModel.DefaultValue(false)]
        public bool VisualizarDropDown
        {
            get { return this.BtnDropDown.Visible; }
            set { this.BtnDropDown.Visible = value; }
        }
        /// <summary>
        /// Lista de seleccion
        /// </summary>
        private DataTable _ListaDesplegable;
        /// <summary>
        /// Lista de seleccion
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Lista de texto a visualizar")]
        public DataTable ListaDesplegable
        {
            get { return _ListaDesplegable; }
            set { _ListaDesplegable = value; }
        }

        /// <summary>
        /// Clave de la lista de seleccion
        /// </summary>
        private string _ClaveDesplegable;
        /// <summary>
        /// Clave de la lista de seleccion
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Clave de la lista de texto a visualizar")]
        public string ClaveDesplegable
        {
            get { return _ClaveDesplegable; }
            set { _ClaveDesplegable = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OrbitaTecladoNumerico()
        {
            InitializeComponent();
            this.PnlTop.Visible = true;
            this.btnIntro.Visible = true;
            this.BtnEsc.Visible = true;
            this.btnRetrocede.Visible = true;
            this.BtnDropDown.Visible = false;
            this.ListaDesplegable = null;
            this.ClaveDesplegable = string.Empty;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Método para rellenar la lista desplegable de los carins
        /// </summary>
        public void RellenarDesplegable()
        {
            if ((this.ListaDesplegable != null) && (this.ListaDesplegable.Rows.Count > 0))
            {
                this.GridView.SuspendLayout();
                try
                {
                    BindingSource dbs = new BindingSource();
                    dbs.DataSource = this._ListaDesplegable;
                    this.GridView.DataSource = dbs;

                    foreach (DataGridViewColumn column in this.GridView.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
                catch (System.Exception)
                {
                }
                finally
                {
                    this.GridView.ResumeLayout();
                }
            }
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Carga del control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrbitaControlTeclado_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.txtResultado.Text = string.Empty;
                this.RellenarDesplegable();
                this.txtResultado.Focus();
            }
            catch (System.Exception)
            {
                // Do nothing
            }
        }
        /// <summary>
        /// Evento de clic sobre alguna tecla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, System.EventArgs e)
        {
            try
            {
                string texto = ((Button)sender).Tag.ToString();
                if (texto.Length > 0)
                {
                    char caracter = texto[0];
                    this.txtResultado.Text = this.txtResultado.Text + caracter;
                    if (BotonClick != null)
                    {
                        Keys keys = (Keys)(byte)caracter;
                        BotonClick(this, new KeyEventArgs(keys));
                    }
                }
            }
            catch (System.Exception)
            {
                // Do nothing
            }
        }
        /// <summary>
        /// Evento de borrado de caracter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetrocede_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.txtResultado.Text.Length > 0)
                {
                    this.txtResultado.Text = this.txtResultado.Text.Remove(this.txtResultado.Text.Length - 1, 1);
                }
            }
            catch (System.Exception)
            {
                // Do nothing
            }
        }
        /// <summary>
        /// Clic en Intro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIntro_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (BotonIntroClick != null)
                {
                    BotonIntroClick(this, new TextEventArgs(this.Resultado));
                }
            }
            catch (System.Exception)
            {
                // Do nothing
            }
        }
        /// <summary>
        /// Evento de pulsación de la telca de escape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEsc_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (BotonEscClick != null)
                {
                    BotonEscClick(this, e);
                }
            }
            catch (System.Exception)
            {
                // Do nothing
            }
        }
        /// <summary>
        /// Pulsación de la tecla de desplegable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDropDown_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.GridView.Visible = !this.GridView.Visible;
            }
            catch (System.Exception)
            {
                // Do nothing
            }
        }
        /// <summary>
        /// Evento de salida del botón de desplegar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDropDown_Leave(object sender, System.EventArgs e)
        {
            try
            {
                this.GridView.Visible = this.GridView.Focused;
            }
            catch (System.Exception)
            {
                // Do nothing
            }
        }
        /// <summary>
        /// Evento de clic en una celda del grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                if ((row >= 0) && (row < this.GridView.Rows.Count))
                {
                    //this.txtResultado.Text = this.GridView.Rows[row].Cells[0].Value.ToString();
                    this.txtResultado.Text = this.GridView.Rows[row].Cells[this._ClaveDesplegable].Value.ToString();
                    this.GridView.Visible = false;
                }
            }
            catch (System.Exception)
            {
                // Do nothing
            }
        }
        /// <summary>
        /// Evento de escritura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool añadir = false;
            añadir |= char.IsDigit(e.KeyChar);
            añadir |= (e.KeyChar == '\b') && this.VisualizarRet;
            
            e.Handled = !añadir;
        }
        #endregion
    }
}