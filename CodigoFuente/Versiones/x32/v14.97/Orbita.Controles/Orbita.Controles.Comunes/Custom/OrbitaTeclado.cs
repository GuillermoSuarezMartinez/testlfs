//***********************************************************************
// Assembly         : Orbita.Controles.Comunes
// Author           : aibañez
// Created          : 29-04-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Orbita.Controles.Comunes
{
    /// <summary>
    /// Teclado en pantalla
    /// </summary>
    public partial class OrbitaTeclado : UserControl, ITeclado
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
        /// Indica que se ha de visualizar la tecla de espacio
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel. Description("Indica que se ha de visualizar la tecla de espacio")]
        [System.ComponentModel. DefaultValue(true)]
        public bool VisualizarSpace
        {
            get { return this.btnSpace.Visible; }
            set { this.btnSpace.Visible = value; }
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

        /// <summary>
        /// Fuente del textbox
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Fuente del textbox")]
        public Font FuenteTexto
        {
            get { return this.txtResultado.Font; }
            set 
            {
                this.txtResultado.Font = value;
                this.GridView.Font = value; 
            }
        }

        /// <summary>
        /// Imagen de la cámara desconectada
        /// </summary>
        private Bitmap _ImagenTecla = global::Orbita.Controles.Comunes.Properties.Resources.ImgComputerKey90;
        /// <summary>
        /// Imagen de la cámara desconectada
        /// </summary>
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Orbita"),
        System.ComponentModel.Description("Imagen de fondo de cada tecla")]
        public Bitmap ImagenTecla
        {
            get { return _ImagenTecla; }
            set 
            {
                _ImagenTecla = value;

                // Rellenado del fondo de cada tecla
                btnRetrocede.Image = this.ImagenTecla;
                BtnDropDown.Image = this.ImagenTecla;
                BtnEsc.Image = this.ImagenTecla;
                btn1.Image = this.ImagenTecla;
                btnA.Image = this.ImagenTecla;
                btnIntro.Image = this.ImagenTecla;
                btnZ.Image = this.ImagenTecla;
                btnSpace.Image = this.ImagenTecla;
                btnX.Image = this.ImagenTecla;
                btnL.Image = this.ImagenTecla;
                btnC.Image = this.ImagenTecla;
                btnK.Image = this.ImagenTecla;
                btnV.Image = this.ImagenTecla;
                btnJ.Image = this.ImagenTecla;
                btnB.Image = this.ImagenTecla;
                btnH.Image = this.ImagenTecla;
                btnN.Image = this.ImagenTecla;
                btnG.Image = this.ImagenTecla;
                btnM.Image = this.ImagenTecla;
                btnF.Image = this.ImagenTecla;
                btnQ.Image = this.ImagenTecla;
                btnD.Image = this.ImagenTecla;
                btn2.Image = this.ImagenTecla;
                btnS.Image = this.ImagenTecla;
                btn3.Image = this.ImagenTecla;
                btnP.Image = this.ImagenTecla;
                btn4.Image = this.ImagenTecla;
                btnO.Image = this.ImagenTecla;
                btn5.Image = this.ImagenTecla;
                btnI.Image = this.ImagenTecla;
                btn6.Image = this.ImagenTecla;
                btnU.Image = this.ImagenTecla;
                btn7.Image = this.ImagenTecla;
                btnY.Image = this.ImagenTecla;
                btn8.Image = this.ImagenTecla;
                btnT.Image = this.ImagenTecla;
                btn9.Image = this.ImagenTecla;
                btnR.Image = this.ImagenTecla;
                btn0.Image = this.ImagenTecla;
                btnE.Image = this.ImagenTecla;
                btnW.Image = this.ImagenTecla;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OrbitaTeclado()
        {
            InitializeComponent();
            this.PnlTop.Visible = true;
            this.btnIntro.Visible = true;
            this.btnSpace.Visible = true;
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
            añadir |= char.IsLetterOrDigit(e.KeyChar);
            añadir |= char.IsWhiteSpace(e.KeyChar) && this.VisualizarSpace;
            añadir |= (e.KeyChar == '\b') && this.VisualizarRet;
            
            e.Handled = !añadir;
        }
        #endregion
    }

    /// <summary>
    /// Interfaz para todos los teclados de pantalla
    /// </summary>
    public interface ITeclado
    {
        #region Propiedad(es)
        /// <summary>
        /// Resultado de la introducción de texto
        /// </summary>
        string Resultado
        {
            get;
        }

        /// <summary>
        /// Indica que se ha de visualizar el editor
        /// </summary>
        bool VisualizarEditor
        {
            get;
            set;
        }
        /// <summary>
        /// Indica que se ha de visualizar la tecla de intro
        /// </summary>
        bool VisualizarIntro
        {
            get;
            set;
        }
        /// <summary>
        /// Indica que se ha de visualizar la tecla de escape
        /// </summary>
        bool VisualizarEsc
        {
            get;
            set;
        }
        /// <summary>
        /// Indica que se ha de visualizar la tecla de retroceso
        /// </summary>
        bool VisualizarRet
        {
            get;
            set;
        }
        /// <summary>
        /// Indica que se ha de visualizar la tecla del desplegable
        /// </summary>
        bool VisualizarDropDown
        {
            get;
            set;
        }
        
        /// <summary>
        /// Lista de seleccion
        /// </summary>
        DataTable ListaDesplegable
        {
            get;
            set;
        }
        /// <summary>
        /// Clave de la lista de seleccion
        /// </summary>
        string ClaveDesplegable
        {
            get;
            set;
        }

        /// <summary>
        /// Fuente del textbox
        /// </summary>
        Font FuenteTexto
        {
            get;
            set;
        }
        /// <summary>
        /// Imagen de la cámara desconectada
        /// </summary>
        Bitmap ImagenTecla
        {
            get;
            set;
        } 
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Método para rellenar la lista desplegable de los carins
        /// </summary>
        void RellenarDesplegable();
        #endregion
    }

    /// <summary>
    /// Evento de devolución de texto
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void TextEventHandler(object sender, TextEventArgs e);
    /// <summary>
    /// Argumentos del evento de devolución de texto
    /// </summary>
    public class TextEventArgs
    {
        #region Propiedades
        /// <summary>
        /// Nueva imagen
        /// </summary>
        private string texto;
        /// <summary>
        /// Nueva imagen
        /// </summary>
        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codigo">Código identificativo de la variable</param>
        /// <param name="valor">Valor de la variable</param>
        public TextEventArgs(string texto)
        {
            this.texto = texto;
        }
        #endregion
    }
}