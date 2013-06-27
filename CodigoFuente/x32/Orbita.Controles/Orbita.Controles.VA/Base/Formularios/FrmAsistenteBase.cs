//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Orbita.Controles.Combo;
using Orbita.Controles.Comunes;
using Orbita.Controles.Contenedores;
using Orbita.Controles.Grid;
using Orbita.Utiles;
using Orbita.VA.Comun;

namespace Orbita.Controles.VA
{
    /// <summary>
    /// Constructor de la clase
    /// </summary>
    public partial class FrmAsistenteBase : OrbitaForm, IOrbitaForm, IDisposable
    {
        #region Atributo(s)
        /// <summary>
        /// Indica si se ha modificado algo
        /// </summary>
        protected bool AlgoModificado;
        /// <summary>
        /// Indica si se está en la fase de inicialización de los controles del formulario
        /// </summary>
        protected bool Inicio;
        /// <summary>
        /// Informa si el motivo del cierre es por decisión el usuario o interna del código
        /// </summary>
        protected bool CierrePorUsuario;
        /// <summary>
        /// Estado del formulario por defecto
        /// </summary>
        private FormWindowState DefaultWindowState;
        /// <summary>
        /// Borde del formulario por defecto
        /// </summary>
        private FormBorderStyle DefaultFormBorderStyle;
        /// <summary>
        /// Área de visualización por defecto
        /// </summary>
        private Rectangle DefatulRectangle;
        #endregion Campos

        #region Propiedad(es)
        /// <summary>
        /// Establece el estilo de los botones de la barra de título del formulario
        /// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ExStyle |= 0x02000000;
        //        return myCp;
        //    }
        //}

        /// <summary>
        /// Posibilita la apertura de múltiples instancias del formulario
        /// </summary>
        private bool _MultiplesInstancias;
        /// <summary>
        /// Posibilita la apertura de múltiples instancias del formulario
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Posibilita la apertura de múltiples instancias del formulario")]
        public bool MultiplesInstancias
        {
            get { return _MultiplesInstancias; }
            set { _MultiplesInstancias = value; }
        }

        /// <summary>
        /// Si se activa, se está indicando que el propio formulario debe monitorizar la entrada de datos del usuario para saber cuando
        /// han sido modificados, y por lo tanto realizar las tareas apropiadas.
        /// </summary>
        private bool _ControlDatosModificados;
        /// <summary>
        /// Si se activa, se está indicando que el propio formulario debe monitorizar la entrada de datos del usuario para saber cuando
        /// han sido modificados, y por lo tanto realizar las tareas apropiadas.
        /// </summary>
        [Browsable(true),
        DefaultValueAttribute(true),
        Category("Orbita"),
        Description("Indica que la información contenida en el formulario debe ser monitorizada para saber cuando el usuario la ha modificado")]
        public bool ControlDatosModificados
        {
            get { return _ControlDatosModificados; }
            set { _ControlDatosModificados = value; }
        }

        /// <summary>
        /// Se activa a verdadero cuando se han guardado correctamten los datos del formulario,
        /// bien en la base de datos o bien en formulario invocante.
        /// </summary>
        private bool _FormularioModificado;
        /// <summary>
        /// Se activa a verdadero cuando se han guardado correctamten los datos del formulario,
        /// bien en la base de datos o bien en formulario invocante.
        /// </summary>
        [Browsable(false)]
        public bool FormularioModificado
        {
            get { return _FormularioModificado; }
        }

        /// <summary>
        /// Indica si se ha de restaurar la posición del formulario a la última guardada
        /// </summary>
        private bool _RecordarPosicion;
        /// <summary>
        /// Indica si se ha de restaurar la posición del formulario a la última guardada
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de restaurar la posición del formulario a la última guardada")]
        public bool RecordarPosicion
        {
            get { return _RecordarPosicion; }
            set { _RecordarPosicion = value; }
        }

        /// <summary>
        /// Muestra los botones de acción situados en la parte inferior del formulario
        /// </summary>
        private bool _MostrarBotones = true;
        /// <summary>
        /// Muestra los botones de acción situados en la parte inferior del formulario
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Muestra los botones de acción situados en la parte inferior del formulario"),
        DefaultValue(true)]
        public bool MostrarBotones
        {
            get { return _MostrarBotones; }
            set { _MostrarBotones = value; }
        }

        /// <summary>
        /// Nombre del formulario
        /// </summary>
        [Browsable(false)]
        public new string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }

        /// <summary>
        /// Localización del formulario
        /// </summary>
        [Browsable(false)]
        public new Point Location
        {
            get
            {
                return base.Location;
            }
            set
            {
                base.Location = value;
            }
        }

        /// <summary>
        /// Tamaño del formulario
        /// </summary>
        [Browsable(false)]
        public new Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                base.Size = value;
            }
        }

        /// <summary>
        /// Indica que el formulario está maximizado
        /// </summary>
        [Browsable(false)]
        public bool Maximized
        {
            get
            {
                bool resultado = this.WindowState == FormWindowState.Maximized;
                return resultado;
            }
            set
            {
                FormWindowState windowsState = value ? FormWindowState.Maximized : FormWindowState.Normal;
                this.WindowState = windowsState;
            }
        }

        /// <summary>
        /// Indica que el formulario puede anclarse o no
        /// </summary>
        [Browsable(false)]
        public bool Anclable
        {
            get { return false; }
        }

        /// <summary>
        /// Indica que el formulario está anclado o no
        /// </summary>
        private bool _Anclado = false;
        /// <summary>
        /// Indica que el formulario está anclado o no
        /// </summary>
        [Browsable(false)]
        public bool Anclado
        {
            get { return false; }
            set { }
        }

        /// <summary>
        /// Is Docked MDIChild
        /// </summary>
        [Browsable(false)]
        public bool IsDockedMDIChild
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// Rectangulo de visualización del fomrulario MDI de tipo anclable
        /// </summary>
        [Browsable(false)]
        public Rectangle DockedMDIRectangle
        {
            get
            {
                return new Rectangle();
            }
            set
            {
            }
        }

        /// <summary>
        /// Rectangulo de visualización del fomrulario anclado
        /// </summary>
        [Browsable(false)]
        public Size DockedPaneSize
        {
            get
            {
                return new Size();
            }
            set
            {
            }
        }

        /// <summary>
        /// Informa si la la ventana anclada está puesta para no oculatarse automáticamente
        /// </summary>
        [Browsable(false)]
        public bool DockedPined
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// Localización del anclaje
        /// </summary>
        [Browsable(false)]
        public DockedLocation DockedLocation
        {
            get
            {
                return DockedLocation.DockedRight; ;
            }
            set
            {
            }
        }

        /// <summary>
        /// Paso Actual
        /// </summary>
        [Browsable(true)]
        public int PasoActual
        {
            get
            {
                return this.TabControl.SelectedTab.Index;
            }
        }

        /// <summary>
        /// Paso Actual
        /// </summary>
        [Browsable(true)]
        public int TotalPasos
        {
            get
            {
                return this.TabControl.Tabs.Count;
            }
        }

        /// <summary>
        /// Indica el tipo de paso actual
        /// </summary>
        private TipoPasoAsistente _TipoPasoActual = TipoPasoAsistente.PasoInicial;
        /// <summary>
        /// Indica el tipo de paso actual
        /// </summary>
        [Browsable(false)]
        public TipoPasoAsistente TipoPasoActual
        {
            get { return _TipoPasoActual; }
            set { _TipoPasoActual = value; }
        }
        #endregion Propiedades

        #region Constructor(es)
        /// <summary>
        /// Constructor vacio de la clase (es necesario para que el diseñador construya el formulario heredado en tiempo de diseño)
        /// </summary>		
        public FrmAsistenteBase()
        {
            InitializeComponent();

            // Inicialiación de campos
            this.AlgoModificado = false;
            this._FormularioModificado = false;
            this.CierrePorUsuario = false;
            this.DefaultWindowState = this.WindowState;
            this.DefaultFormBorderStyle = this.FormBorderStyle;
        }
        #endregion Constructores

        #region Destructores
        /// <summary>
        /// Destructor de la clase
        /// </summary>
        public new void Dispose()
        {
            base.Dispose();
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Informa de que el formulario puede abrirse, bien porque se permiten multiples intancias o bien porque no existe niguna instancia abierta
        /// </summary>
        /// <returns>Verdadero si el formulario puede abrirse</returns>
        private bool VisualizacionPermitida()
        {
            bool puedeAbrirse = true;

            // Si no permite abrir multiples instancias...
            if (!this._MultiplesInstancias)
            {
                foreach (string nombreForm in FrmBase.ListaFormsAbiertos)
                {
                    if (nombreForm == this.Name)
                    {
                        puedeAbrirse = false;
                        break;
                    }
                }
            }

            return puedeAbrirse;
        }

        /// <summary>
        /// Se añade el evento de monitorización a los controles del formulario
        /// </summary>
        private void InternoIniciarMonitorizarModificaciones(Control control)
        {
            foreach (Control controlInterno in control.Controls)
            {
                if (controlInterno != this.PnlInferiorPadre)
                {
                    if (controlInterno is OrbitaUltraCombo)
                    {
                        ((OrbitaUltraCombo)controlInterno).ValueChanged += this.EventoCambioValor;
                    }
                    else if (controlInterno is OrbitaTextBox)
                    {
                        ((OrbitaTextBox)controlInterno).TextChanged += this.EventoCambioValor;
                    }
                    else if (controlInterno is OrbitaUltraNumericEditor)
                    {
                        ((OrbitaUltraNumericEditor)controlInterno).ValueChanged += this.EventoCambioValor;
                    }
                    else if (controlInterno is OrbitaUltraCheckEditor)
                    {
                        ((OrbitaUltraCheckEditor)controlInterno).CheckedChanged += this.EventoCambioValor;
                    }
                    else if (controlInterno is OrbitaUltraGrid)
                    {
                        ((OrbitaUltraGrid)controlInterno).CellChange += this.EventoCeldaCambioValor;
                    }
                    else if (controlInterno is OrbitaUltraGridToolBar)
                    {
                        ((OrbitaUltraGridToolBar)controlInterno).CellChange += this.EventoCeldaCambioValor;
                    }
                    else if (controlInterno is OrbitaUltraDateTimeEditor)
                    {
                        ((OrbitaUltraDateTimeEditor)controlInterno).ValueChanged += this.EventoCambioValor;
                    }

                    // Recursivo
                    this.InternoIniciarMonitorizarModificaciones(controlInterno);
                }
            }
        }

        /// <summary>
        /// Se elimina el evento de monitorización a los controles del formulario
        /// </summary>
        private void InternoFinalizarMonitorizarModificaciones(Control control)
        {
            foreach (Control controlInterno in control.Controls)
            {
                if (controlInterno != this.PnlInferiorPadre)
                {
                    if (controlInterno is OrbitaUltraCombo)
                    {
                        ((OrbitaUltraCombo)controlInterno).ValueChanged -= this.EventoCambioValor;
                    }
                    else if (controlInterno is OrbitaTextBox)
                    {
                        ((OrbitaTextBox)controlInterno).TextChanged -= this.EventoCambioValor;
                    }
                    else if (controlInterno is OrbitaUltraNumericEditor)
                    {
                        ((OrbitaUltraNumericEditor)controlInterno).ValueChanged -= this.EventoCambioValor;
                    }
                    else if (controlInterno is OrbitaUltraCheckEditor)
                    {
                        ((OrbitaUltraCheckEditor)controlInterno).CheckedChanged -= this.EventoCambioValor;
                    }
                    else if (controlInterno is OrbitaUltraGrid)
                    {
                        ((OrbitaUltraGrid)controlInterno).CellChange -= this.EventoCeldaCambioValor;
                    }
                    else if (controlInterno is OrbitaUltraGridToolBar)
                    {
                        ((OrbitaUltraGridToolBar)controlInterno).Grid.CellChange += this.EventoCeldaCambioValor;
                    }
                    else if (controlInterno is OrbitaUltraDateTimeEditor)
                    {
                        ((OrbitaUltraDateTimeEditor)controlInterno).ValueChanged -= this.EventoCambioValor;
                    }

                    // Recursivo
                    this.InternoFinalizarMonitorizarModificaciones(controlInterno);
                }
            }
        }

        /// <summary>
        /// Método usado para solucionar el problemas de los componentes orbita con los tooltips
        /// </summary>
        private void SolucionarToolTips(Control control)
        {
            foreach (Control controlInterno in control.Controls)
            {
                if (controlInterno is OrbitaUltraGridToolBar)
                {
                    this.toolTip.SetToolTip(((OrbitaUltraGridToolBar)controlInterno).Grid, this.toolTip.GetToolTip(((OrbitaUltraGrid)controlInterno)));
                }

                // Recursivo
                this.SolucionarToolTips(controlInterno);
            }
        }

        /// <summary>
        /// Cambia la visualización del botón siguiente/finalizar dependiendo del paso en el que nos encontramos
        /// </summary>
        private void VisualizarBotonAnteriorSiguienteFinalizar(TipoPasoAsistente tipoPaso)
        {
            switch (tipoPaso)
            {
                case TipoPasoAsistente.PasoInicial:
                    this.BtnAnterior.Enabled = false;
                    this.btnSiguienteFinalizar.Appearance.Image = global::Orbita.Controles.VA.Properties.Resources.BtnSiguiente24;
                    this.btnSiguienteFinalizar.Text = "Siguiente";
                    break;
                case TipoPasoAsistente.PasoIntermedio:
                    this.BtnAnterior.Enabled = true;
                    this.btnSiguienteFinalizar.Appearance.Image = global::Orbita.Controles.VA.Properties.Resources.BtnSiguiente24;
                    this.btnSiguienteFinalizar.Text = "Siguiente";
                    break;
                case TipoPasoAsistente.PasoFinal:
                    this.BtnAnterior.Enabled = true;
                    this.btnSiguienteFinalizar.Appearance.Image = global::Orbita.Controles.VA.Properties.Resources.btnOk24;
                    this.btnSiguienteFinalizar.Text = "Finalizar";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Visualiza el texto del paso actual
        /// </summary>
        /// <param name="paso"></param>
        private void VisualizarPasoActual(int pasoActual, int totalPasos)
        {
            this.LblNumeroPaso.Text = string.Format("Paso {0} de {1}", pasoActual + 1, totalPasos);
        }

        /// <summary>
        /// Acciones para ir al paso siguiente
        /// </summary>
        private void AccionesIrAPasoSiguiente()
        {
            if (this.ValidarDatosPaso(this.PasoActual))
            {
                TipoPasoAsistente tipoPasoActualLocal = this.TipoPasoActual;
                switch (tipoPasoActualLocal)
                {
                    case TipoPasoAsistente.PasoInicial:
                    case TipoPasoAsistente.PasoIntermedio:
                        TipoPasoAsistente tipoPasoSiguiente;
                        int pasoSiguiente;
                        this.GetInformacionPasoSiguiente(out pasoSiguiente, out tipoPasoSiguiente);
                        if (pasoSiguiente != this.PasoActual)
                        {
                            this.AccionesAlSalirDelPaso(this.PasoActual);
                            this.AccionesAlAceptarElPaso(this.PasoActual);
                            this.TabControl.SelectedTab = this.TabControl.Tabs[pasoSiguiente];
                            this.TipoPasoActual = tipoPasoSiguiente;
                            this.AccionesAlIniciarPaso(this.PasoActual);
                            this.AccionesAlEntrarEnPaso(this.PasoActual);
                            this.VisualizarBotonAnteriorSiguienteFinalizar(tipoPasoSiguiente);
                            this.VisualizarPasoActual(this.PasoActual, this.TotalPasos);
                        }
                        break;
                    case TipoPasoAsistente.PasoFinal:
                            if (this.GuardarDatos())
                            {
                                //Si se han guardado los datos correctamente, cerramos el formulario
                                this.Close();
                            }
                        break;
                }
            }
        }

        /// <summary>
        /// Acciones para ir al paso siguiente
        /// </summary>
        private void AccionesIrAPasoAnterior()
        {
            TipoPasoAsistente tipoPasoAnterior;
            int pasoAnterior;
            this.GetInformacionPasoAnterior(out pasoAnterior, out tipoPasoAnterior);
            if (pasoAnterior != this.PasoActual)
            {
                this.AccionesAlSalirDelPaso(this.PasoActual);
                this.TabControl.SelectedTab = this.TabControl.Tabs[pasoAnterior];
                this.TipoPasoActual = tipoPasoAnterior;
                this.AccionesAlEntrarEnPaso(this.PasoActual);
                this.VisualizarBotonAnteriorSiguienteFinalizar(tipoPasoAnterior);
                this.VisualizarPasoActual(this.PasoActual, this.TotalPasos);
            }
        }
        #endregion Métodos privados

        #region Método(s) protegido(s)
        /// <summary>
        /// Inicializa todos los componentes del formulario, cargando los datos si procede
        /// </summary>
        protected void IniciarFormulario()
        {
            this.Inicio = true;
            this.btnCancelar.Select();

            this.VisualizarBotonAnteriorSiguienteFinalizar(TipoPasoAsistente.PasoInicial);
            this.VisualizarPasoActual(this.PasoActual, this.TotalPasos);

            this.CargarDatosAsistente();
            this.EstablecerModoAsistente();
            this.AccionesAlIniciarPaso(this.PasoActual);
            this.AccionesAlEntrarEnPaso(this.PasoActual);

            this.IniciarMonitorizarModificaciones();
            this.SolucionarToolTips(this);
            this.ResetDeteccionModificaciones();
            this.Inicio = false;
        }
        /// <summary>
        /// Guarda los datos
        /// </summary>
        protected bool GuardarDatos()
        {
            if (this.ComprobacionesDeCampos())
            {
                //Llamada a la funcion de guardado de datos
                if (!this.GuardarDatosAsistente())
                {
                    //Si han habido errores...
                    return false;
                }
                //Si no han habido errores...
                this.ResetDeteccionModificaciones();
                return true;
    }
            else //No se pueden guardar los datos por las restricciones impuestas
            {
                return false;
            }
        }
        /// <summary>
        /// Cambia el texto del botón aceptar
        /// </summary>
        /// <param name="nuevoTexto">Nuevo texto que tendrá el botón aceptar</param>
        protected void CambiarTextoBotonGuardar(string nuevoTexto)
        {
            this.btnSiguienteFinalizar.Text = nuevoTexto;
        }
        /// <summary>
        /// Cambia el texto del botón cancelar
        /// </summary>
        /// <param name="nuevoTexto">Nuevo texto que tendrá el botón cancelar</param>
        protected void CambiarTextoBotonCancelar(string nuevoTexto)
        {
            this.btnCancelar.Text = nuevoTexto;
        }
        /// <summary>
        /// Cambia la propiedad Visible del botón aceptar
        /// </summary>
        protected void OcultarBotonAceptar()
        {
            this.CambiarTextoBotonCancelar("Cerrar");
            this.btnSiguienteFinalizar.Visible = false;
        }
        /// <summary>
        /// Cambia la propiedad Visible del botón cancelar
        /// </summary>
        protected void OcultarBotonCancelar()
        {
            this.CambiarTextoBotonGuardar("Aceptar");
            this.btnCancelar.Visible = false;
            this.btnSiguienteFinalizar.Location = this.btnCancelar.Location;
            this.btnSiguienteFinalizar.Select();
        }
        /// <summary>
        /// Cambia la propiedad Visible de la barra de botones
        /// </summary>
        protected void OcultarBotones()
        {
            this.PnlInferiorPadre.Visible = this._MostrarBotones;
        }
        #endregion Métodos protegidos

        #region Método(s) virtual(es)
        /// <summary>
        /// Carga y muestra datos del formulario en modo Modificación. Se cargan todos datos que se muestran en 
        /// el formulario: grids, combos, etc... Cada carga de elementos estará encapsulada en un método
        /// </summary>
        protected virtual void CargarDatosAsistente()
        {
        }
        /// <summary>
        /// Establece la habiliacion adecuada de los controles para el modo Modificacion
        /// </summary>
        protected virtual void EstablecerModoAsistente()
        {
            this.SuspendLayout();
            this.ChkToolTip.Checked = false;
            this.toolTip.Active = false;
            this.ResumeLayout();
        }
        /// <summary>
        /// Guarda los datos cuando el formulario está abierto en modo Modificación
        /// </summary>
        /// <returns>True si la operación de guardado de datos ha tenido éxito; false en caso contrario</returns>
        protected virtual bool GuardarDatosAsistente()
        {
            this._FormularioModificado = true;
            return true;
        }
        /// <summary>
        /// Se añade el evento de monitorización a los controles del formulario
        /// </summary>
        protected virtual void IniciarMonitorizarModificaciones()
        {
            this.InternoIniciarMonitorizarModificaciones(this);
        }
        /// <summary>
        /// Se elimina el evento de monitorización a los controles del formulario
        /// </summary>
        protected virtual void FinalizarMonitorizarModificaciones()
        {
            this.InternoFinalizarMonitorizarModificaciones(this);
        }
        /// <summary>
        /// Comprueba si se ha modificado algún dato en algún campo del formulario
        /// </summary>
        /// <returns>True si se han modificado datos; false en caso contrario</returns>
        protected virtual bool ComprobarDatosModificados()
        {
            if (this.AlgoModificado)
                return true;

            return false;
        }
        /// <summary>
        /// Resetea el mecanismo de modificaciones indicando que se han procesado los cambios
        /// </summary>
        protected virtual void ResetDeteccionModificaciones()
        {
            this.AlgoModificado = false;
        }
        /// <summary>
        /// Realiza las comprobaciones pertinentes antes de realizar un guardado de los datos. Se usa para el caso en que hayan restricciones en el momento de guardar los datos
        /// </summary>
        /// <returns>True si todo está correcto para ser guardado; false en caso contrario</returns>
        protected virtual bool ComprobacionesDeCampos()
        {
            return true;
        }
        /// <summary>
        ///  Método para que sea sobreescrito en el hijo y realizar funciones si el usuario no desea guardar los cambios 
        /// </summary>
        protected virtual void AccionesNoGuardar()
        {

        }
        /// <summary>
        ///  Método  para que sea sobreescrito en el hijo y realizar funciones al salir del formulario
        /// </summary>
        protected virtual void AccionesSalir()
        {
        }
        /// <summary>
        /// Devuelve la información del paso anterior
        /// </summary>
        /// <param name="pasoAnterior"></param>
        /// <param name="tipoPasoAnterior"></param>
        protected virtual void GetInformacionPasoAnterior(out int pasoAnterior, out TipoPasoAsistente tipoPasoAnterior)
        {
            pasoAnterior = this.PasoActual > 0 ? this.PasoActual - 1 : 0;
            tipoPasoAnterior = pasoAnterior == 0 ? TipoPasoAsistente.PasoInicial : TipoPasoAsistente.PasoIntermedio;
        }
        /// <summary>
        /// Devuelve la información del paso sioguiente
        /// </summary>
        /// <param name="pasoSiguiente"></param>
        /// <param name="tipoPasoSiguiente"></param>
        protected virtual void GetInformacionPasoSiguiente(out int pasoSiguiente, out TipoPasoAsistente tipoPasoSiguiente)
        {
            pasoSiguiente = this.PasoActual < this.TotalPasos - 1 ? this.PasoActual + 1 : this.TotalPasos - 1;
            tipoPasoSiguiente = pasoSiguiente == this.TotalPasos - 1 ? TipoPasoAsistente.PasoFinal: TipoPasoAsistente.PasoIntermedio;
        }
        /// <summary>
        /// Acciones al entrar en el paso desde el paso anterior
        /// </summary>
        /// <param name="paso"></param>
        protected virtual void AccionesAlIniciarPaso(int paso)
        {

        }
        /// <summary>
        /// Acciones al entrar en el paso desde cualquier paso
        /// </summary>
        /// <param name="paso"></param>
        protected virtual void AccionesAlEntrarEnPaso(int paso)
        {

        }
        /// <summary>
        /// Validación de aceptación del paso
        /// </summary>
        /// <param name="paso"></param>
        protected virtual void AccionesAlAceptarElPaso(int paso)
        {
        }
        /// <summary>
        /// Acciones al salir del paso a cualquier paso
        /// </summary>
        /// <param name="paso"></param>
        protected virtual void AccionesAlSalirDelPaso(int paso)
        {

        }
        /// <summary>
        /// Consulta sobre la validez de los datos introducidos en el paso
        /// </summary>
        /// <param name="paso"></param>
        protected virtual bool ValidarDatosPaso(int paso)
        {
            return true;
        }
        #endregion Métodos virtuales

        #region Método(s) heredado(s)
        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        public new void Show()
        {
            if (this.VisualizacionPermitida())
            {
                try
                {
                    // Apertura del formulario
                    this.CierrePorUsuario = false;

                    // Posición por defecto del formulario
                    this.DefatulRectangle = new Rectangle(this.Left, this.Top, this.Width, this.Height);

                    //OTrabajoControles.FormularioPrincipalMDI.OI.MostrarFormulario(this);
                    this.MdiParent = OTrabajoControles.FormularioPrincipalMDI;
                    base.Show();

                    FrmBase.ListaFormsAbiertos.Add(this.Name);

                    // Situa la posición del formulario
                    IOrbitaForm frmBase = this;
                    OEscritoriosManager.SituarFormulario(ref frmBase);
                }
                catch (Exception exception)
                {
                    OLogsControlesVA.ControlesVA.Error(exception, "Apertura de formulario");
                }
            }
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        public new void Close()
        {
            this.CierrePorUsuario = true;
            base.Close();
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Evento que se produce al cargar el formulario, antes de aparecer
        /// </summary>
        /// <param name="sender">Objeto que envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void FrmBase_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.DesignMode)
                {
                    this.IniciarFormulario();
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Carga de formulario");
            }
        }
        /// <summary>
        /// Manejador de evento click del boton btnCancelar
        /// </summary>
        /// <param name="sender">Objeto que envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected virtual void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (System.Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Cancelar formulario");
            }
        }
        /// <summary>
        /// Manejador de evento click del boton btnAceptar
        /// </summary>
        /// <param name="sender">Objeto que envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected virtual void btnSiguienteFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.AccionesIrAPasoSiguiente();
            }
            catch (System.Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Siguiente Finalizar");
            }
        }
        /// <summary>
        /// Evento de cambio de anclaje sobre el control de anclaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                this.AccionesIrAPasoAnterior();
            }
            catch (System.Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Anterior");
            }
        }
        /// <summary>
        /// Evento que se produce cuando se cierra el formulario, antes de cerrarlo
        /// </summary>
        /// <param name="sender">Objeto que envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void FrmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.btnCancelar.Focus();

                if (this.ComprobarDatosModificados())
                {
                    //Si hay datos modificados en el formulario, avisar y preguntar qué hacer
                    switch (OMensajes.MostrarPreguntaSiNoCancelar("¿Desea guardar los cambios realizados?", MessageBoxDefaultButton.Button3))
                    {
                        case DialogResult.Yes:
                            if (!this.GuardarDatos())
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                        case DialogResult.No:
                            this.AccionesNoGuardar();
                            //Cerrar el formulario, es decir, seguir con la ejecucion
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                }
            }
            catch (System.Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Cierre de formulario");
            }
        }
        /// <summary>
        /// Evento que se produce cuando se cierra el formulario, despues de cerrarlo
        /// </summary>
        /// <param name="sender">Objeto que envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void FrmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.FinalizarMonitorizarModificaciones();
                this.AccionesSalir();

                // Eliminamos el formulario de la lista de formularios abiertos
                FrmBase.ListaFormsAbiertos.Remove(this.Name);
            }
            catch (System.Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Cierre de formulario");
            }
        }
        /// <summary>
        /// Cambio de valor en un componente
        /// </summary>
        /// <param name="sender">Objeto que envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        public void EventoCambioValor(object sender, EventArgs e)
        {
            try
            {
                if (!this.Inicio && this.ControlDatosModificados)
                {
                    this.AlgoModificado = true;
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Cambio de valor");
            }
        }
        /// <summary>
        /// Cambio de valor en un componente
        /// </summary>
        /// <param name="sender">Objeto que envía el evento</param>
        /// <param name="celda">Argumentos del evento</param>
        private void EventoCeldaCambioValor(object sender, CellEventArgs celda)
        {
            this.EventoCambioValor(sender, new EventArgs());
        }
        /// <summary>
        /// Muestra o oculta los tooltips
        /// </summary>
        /// <param name="sender">Objeto que envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void ChkToolTip_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.toolTip.Active = ChkToolTip.Checked;
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Clic en botón de ToolTips");
            }
        }
        #endregion Manejadores de eventos
    }

    /// <summary>
    /// Indica el tipo de paso del asistente
    /// </summary>
    public enum TipoPasoAsistente
    {
        PasoInicial,
        PasoIntermedio,
        PasoFinal
    }
}