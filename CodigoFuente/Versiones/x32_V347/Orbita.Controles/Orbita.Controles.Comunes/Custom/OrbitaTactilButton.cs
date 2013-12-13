//***********************************************************************
// Assembly         : Orbita.Controles.Comunes
// Author           : aibañez
// Created          : 02-07-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Orbita.Controles.Comunes
{
    /// <summary>
    /// Botón táctil
    /// </summary>
    public partial class OrbitaTactilButton : UserControl
    {
        #region Propiedad(es)
        /// <summary>
        /// Indica si el botón está seleccionado
        /// </summary>
        private bool _Seleccionado;
        /// <summary>
        /// Indica si el botón está seleccionado
        /// </summary>
        public bool Seleccionado
        {
            get { return _Seleccionado; }
            set 
            {
                if (value)
                {
                    this.Seleccionar();
                }
                else
                {
                    this.Deseleccionar();
                }
                _Seleccionado = value; 
            }
        }

        /// <summary>
        /// Botonera al que pertenece el botón
        /// </summary>
        private OrbitaTactilListButton _Botonera;
        /// <summary>
        /// Botonera al que pertenece el botón
        /// </summary>
        public OrbitaTactilListButton Botonera
        {
            get { return _Botonera; }
            set { _Botonera = value; }
        }
        #endregion

        #region Delegado(s)
        /// <summary>
        /// Delegado de selección
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEventoClickBotonTactil(object sender, MouseEventArgs e);
        /// <summary>
        /// Delegado de selección
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private DelegadoEventoClickBotonTactil OnEventoClickBotonTactil;
        #endregion

        #region Constuctor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OrbitaTactilButton()
        {
            InitializeComponent();
            this._Seleccionado = false;
            //this.lblDescripcion.Visible = false;
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OrbitaTactilButton(OrbitaTactilListButton contenedor, string texto, string descripcion, Bitmap image, DelegadoEventoClickBotonTactil eventoClick)
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.Transparent;
            this.Margin = new Padding(0);
            this.Botonera = contenedor;
            this.lblTitulo.Text = texto;
            this.lblDescripcion.Text = descripcion;
            this.lblIcono.Appearance.ImageBackground = image;
            this.lblIcono.Appearance.ImageBackgroundAlpha = Infragistics.Win.Alpha.Opaque;
            //this.lblIcono.Appearance.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this._Seleccionado = false;
            //this.lblDescripcion.Visible = false;
            this.OnEventoClickBotonTactil += eventoClick;
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Selecciona el botón, proporcionando la apariencia definida
        /// </summary>
        private void Seleccionar()
        {
            Botonera.DesSeleccionarTodos();
            this._Seleccionado = true;

            this.lblSeleccionado.Visible = true;
            this.PnlFondo.Appearance.AlphaLevel = 35;
        }
        /// <summary>
        /// Deselecciona el botón, proporcionando la apariencia definida
        /// </summary>
        private void Deseleccionar()
        {
            this._Seleccionado = false;

            this.lblSeleccionado.Visible = false;
            this.PnlFondo.Appearance.AlphaLevel = 1;
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Evento de pasar el ratón por encima
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccion_MouseEnter(object sender, EventArgs e)
        {
            //if (!this.Seleccionado)
            //{
            //    this.lblDescripcion.Appearance.AlphaLevel = this.lblTitulo.Appearance.AlphaLevel;
            //    this.lblDescripcion.Visible = true;
            //}
        }
        /// <summary>
        /// Evento de sacar el ratón de encima
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccion_MouseLeave(object sender, EventArgs e)
        {
            //if (!this.Seleccionado)
            //{
            //    this.lblDescripcion.Visible = false;
            //}
        }
        /// <summary>
        /// Click del ratón
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccion_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_Seleccionado)
            {
                //Botonera.DesSeleccionarTodos();
                //this.Seleccionar();

                if (this.OnEventoClickBotonTactil != null)
                {
                    this.OnEventoClickBotonTactil(this, new MouseEventArgs(MouseButtons.Left, 1, this.Location.X, this.Location.Y, 0));
                }
            }
        }
        #endregion
    }
}
