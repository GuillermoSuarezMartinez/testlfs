//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aiba�ez
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
        /// Indica si se est� en la fase de inicializaci�n de los controles del formulario
        /// </summary>
        protected bool Inicio;
        /// <summary>
        /// Informa si el motivo del cierre es por decisi�n el usuario o interna del c�digo
        /// </summary>
        protected bool CierrePorUsuario;
        /// <summary>
        /// Objeto DockAreaPane utilizado para anclar en las ventanas en modo monitorizaci�n
        /// </summary>
        private DockAreaPane DockAreaPane;
        /// <summary>
        /// Objeto DockableWindow utilizado para anclar en las ventanas en modo monitorizaci�n
        /// </summary>
        private DockableWindow DockableWindow;
        /// <summary>
        /// Objeto DockableControlPane para anclar en la ventanas en modo monitorizaci�n
        /// </summary>
        private DockableControlPane DockableControlPane;
        /// <summary>
        /// Estado del formulario por defecto
        /// </summary>
        private FormWindowState DefaultWindowState;
        /// <summary>
        /// Borde del formulario por defecto
        /// </summary>
        private FormBorderStyle DefaultFormBorderStyle;
        /// <summary>
        /// �rea de visualizaci�n por defecto
        /// </summary>
        private Rectangle DefatulRectangle;
        #endregion Campos

        #region Propiedad(es)
        /// <summary>
        /// Posibilita la apertura de m�ltiples instancias del formulario
        /// </summary>
        private bool _MultiplesInstancias;
        /// <summary>
        /// Posibilita la apertura de m�ltiples instancias del formulario
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Posibilita la apertura de m�ltiples instancias del formulario")]
        public bool MultiplesInstancias
        {
            get { return _MultiplesInstancias; }
            set { _MultiplesInstancias = value; }
        }

        /// <summary>
        /// Si se activa, se est� indicando que el propio formulario debe monitorizar la entrada de datos del usuario para saber cuando
        /// han sido modificados, y por lo tanto realizar las tareas apropiadas.
        /// </summary>
        private bool _ControlDatosModificados;
        /// <summary>
        /// Si se activa, se est� indicando que el propio formulario debe monitorizar la entrada de datos del usuario para saber cuando
        /// han sido modificados, y por lo tanto realizar las tareas apropiadas.
        /// </summary>
        [Browsable(true),
        DefaultValueAttribute(true),
        Category("Orbita"),
        Description("Indica que la informaci�n contenida en el formulario debe ser monitorizada para saber cuando el usuario la ha modificado")]
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
        /// Almacena el modo con el que se ha abierto el formulario: Nuevo o Modificar
        /// </summary>
        protected ModoAperturaFormulario _ModoAperturaFormulario;
        /// <summary>
        /// Indica el modo de apertura del formulario. Edicion, Visualizacion, Monitorizacion, Sistema
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica el modo de apertura del formulario. Edicion, Visualizacion, Monitorizacion, Sistema")]
        public ModoAperturaFormulario ModoAperturaFormulario
        {
            get { return _ModoAperturaFormulario; }
            set { _ModoAperturaFormulario = value; }
        }

        /// <summary>
        /// Indica si se ha de restaurar la posici�n del formulario a la �ltima guardada
        /// </summary>
        private bool _RecordarPosicion;
        /// <summary>
        /// Indica si se ha de restaurar la posici�n del formulario a la �ltima guardada
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de restaurar la posici�n del formulario a la �ltima guardada")]
        public bool RecordarPosicion
        {
            get { return _RecordarPosicion; }
            set { _RecordarPosicion = value; }
        }

        /// <summary>
        /// Muestra los botones de acci�n situados en la parte inferior del formulario
        /// </summary>
        private bool _MostrarBotones = true;
        /// <summary>
        /// Muestra los botones de acci�n situados en la parte inferior del formulario
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Muestra los botones de acci�n situados en la parte inferior del formulario"),
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
        /// Localizaci�n del formulario
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
        /// Tama�o del formulario
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
        /// Indica que el formulario est� maximizado
        /// </summary>
        [Browsable(false)]
        public bool Maximized
        {
            get
            {
                bool resultado = false;
                if (this.Anclado && this.IsDockedMDIChild && (this.DockableWindow is DockableWindow) && (this.DockableWindow.ParentForm is MdiChildForm))
                {
                    resultado = this.DockableWindow.ParentForm.WindowState == FormWindowState.Maximized;
                }
                if (!Anclado)
                {
                    resultado = this.WindowState == FormWindowState.Maximized;
                }
                return resultado;
            }
            set
            {
                FormWindowState windowsState = value ? FormWindowState.Maximized : FormWindowState.Normal;

                if (this.Anclado && this.IsDockedMDIChild && (this.DockableWindow is DockableWindow) && (this.DockableWindow.ParentForm is MdiChildForm))
                {
                    this.DockableWindow.ParentForm.WindowState = windowsState;
                }
                if (!Anclado)
                {
                    this.WindowState = windowsState;
                }
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
        /// Indica que el formulario est� anclado o no
        /// </summary>
        private bool _Anclado = false;
        /// <summary>
        /// Indica que el formulario est� anclado o no
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
        /// Rectangulo de visualizaci�n del fomrulario MDI de tipo anclable
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
        /// Rectangulo de visualizaci�n del fomrulario anclado
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
        /// Informa si la la ventana anclada est� puesta para no oculatarse autom�ticamente
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
        /// Localizaci�n del anclaje
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
        #endregion Propiedades

        #region Constructor(es)
        /// <summary>
        /// Constructor vacio de la clase (es necesario para que el dise�ador construya el formulario heredado en tiempo de dise�o)
        /// </summary>		
        public FrmAsistenteBase()
        {
            InitializeComponent();
            this._ModoAperturaFormulario = VA.ModoAperturaFormulario.Modificacion;

            // Inicialiaci�n de campos
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

        #region M�todo(s) privado(s)
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
        /// Se a�ade el evento de monitorizaci�n a los controles del formulario
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
        /// Se elimina el evento de monitorizaci�n a los controles del formulario
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
        /// M�todo usado para solucionar el problemas de los componentes orbita con los tooltips
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
        /// Se establecen los controles como accesibles por el usuario dependiendo del modo
        /// </summary>
        private void InternoEstablecerModo(Control control)
        {
            foreach (Control controlInterno in control.Controls)
            {
                if (controlInterno is OrbitaUltraCombo)
                {
                    ((OrbitaUltraCombo)controlInterno).ReadOnly = this.ModoAperturaFormulario == ModoAperturaFormulario.Visualizacion;
                }
                else if (controlInterno is OrbitaTextBox)
                {
                    ((OrbitaTextBox)controlInterno).ReadOnly = this.ModoAperturaFormulario == ModoAperturaFormulario.Visualizacion;
                }
                else if (controlInterno is OrbitaUltraNumericEditor)
                {
                    ((OrbitaUltraNumericEditor)controlInterno).ReadOnly = this.ModoAperturaFormulario == ModoAperturaFormulario.Visualizacion;
                }
                else if (controlInterno is OrbitaUltraCheckEditor)
                {
                    ((OrbitaUltraCheckEditor)controlInterno).Enabled = this.ModoAperturaFormulario != ModoAperturaFormulario.Visualizacion;
                }
                else if (controlInterno is OrbitaUltraGrid)
                {
                    ((OrbitaUltraGrid)controlInterno).OI.Editable = this.ModoAperturaFormulario != ModoAperturaFormulario.Visualizacion;
                }
                else if (controlInterno is OrbitaUltraGridToolBar)
                {
                    ((OrbitaUltraGridToolBar)controlInterno).OI.Editable = this.ModoAperturaFormulario != ModoAperturaFormulario.Visualizacion;
                }
                else if (controlInterno is OrbitaUltraDateTimeEditor)
                {
                    ((OrbitaUltraDateTimeEditor)controlInterno).ReadOnly = this.ModoAperturaFormulario == ModoAperturaFormulario.Visualizacion;
                }
                else if (controlInterno is OrbitaUltraButton)
                {
                    ((OrbitaUltraButton)controlInterno).Enabled = this.ModoAperturaFormulario != ModoAperturaFormulario.Visualizacion;
                }

                // Recursivo
                this.InternoEstablecerModo(controlInterno);
            }
        }

        /// <summary>
        /// Permite que el formulario pueda ser manejado por OrbitaUltraDockManager
        /// </summary>
        private void CrearAnclaje()
        {
            if (OEscritoriosManager.PermiteAnclajes)
            {
                this.SuspendLayout();
                OTrabajoControles.DockManager.SuspendLayout();

                FormWindowState windowState = this.WindowState;

                // Creaci�n del �rea de anclaje
                this.DockAreaPane = OTrabajoControles.DockManager.DockControls(new Control[] { this }, DockedLocation.DockedRight, ChildPaneStyle.TabGroup);
                this.DockAreaPane.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);
                this.DockAreaPane.Key = this.Handle.ToString();
                this.DockAreaPane.Text = this.Text;
                this.DockAreaPane.Settings.AllowDockLeft = DefaultableBoolean.False;
                this.DockAreaPane.Settings.AllowDockTop = DefaultableBoolean.False;

                // Creaci�n del furmulario MDI de anclaje
                this.DockableControlPane = (DockableControlPane)this.DockAreaPane.Panes[0];
                this.DockableControlPane.Text = this.Text;
                this.DockableControlPane.IsMdiChild = true;

                // Personalizaci�n del formulario MDI de anclaje
                this.DockableControlPane.MdiChildIcon = this.Icon;
                this.DockableWindow = (DockableWindow)this.Parent;
                if (this.DockableWindow.ParentForm is MdiChildForm)
                {
                    ((MdiChildForm)this.DockableWindow.ParentForm).Text = this.Text;
                    ((MdiChildForm)this.DockableWindow.ParentForm).Left = this.DefatulRectangle.Left;
                    ((MdiChildForm)this.DockableWindow.ParentForm).Width = this.DefatulRectangle.Width;
                    ((MdiChildForm)this.DockableWindow.ParentForm).Top = this.DefatulRectangle.Top;
                    ((MdiChildForm)this.DockableWindow.ParentForm).Height = this.DefatulRectangle.Height;
                    ((MdiChildForm)this.DockableWindow.ParentForm).FormBorderStyle = this.DefaultFormBorderStyle;
                    ((MdiChildForm)this.DockableWindow.ParentForm).WindowState = this.DefaultWindowState;
                    ((MdiChildForm)this.DockableWindow.ParentForm).FormClosing += this.FrmBase_FormClosing;
                    ((MdiChildForm)this.DockableWindow.ParentForm).FormClosed += this.FrmBase_FormClosed;
                    ((MdiChildForm)this.DockableWindow.ParentForm).WindowState = windowState;
                    this.DockAreaPane.DefaultPaneSettings.AllowClose = Infragistics.Win.DefaultableBoolean.True;
                }

                // Eventos para controlar la salida del formulario
                OTrabajoControles.DockManager.AfterPaneButtonClick += this.FrmBase_AfterPaneButtonClick;
                OTrabajoControles.DockManager.AfterDockChange += this.FrmBase_AfterDockChange;

                // Se establece el formulario para ser visualizado como un control
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Dock = DockStyle.Fill;
                this._Anclado = true;

                OTrabajoControles.DockManager.ResumeLayout();
                this.ResumeLayout();
            }
        }

        /// <summary>
        /// Permite resituar un formulario anclado
        /// </summary>
        private void RehacerAnclaje(DockedLocation dockedLocation)
        {
            if (OEscritoriosManager.PermiteAnclajes)
            {
                this.SuspendLayout();
                OTrabajoControles.DockManager.SuspendLayout();

                DockAreaPane dockAreaPane = new DockAreaPane(dockedLocation);
                dockAreaPane.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);
                dockAreaPane.Key = this.Text;
                dockAreaPane.Settings.AllowDockLeft = DefaultableBoolean.False;
                dockAreaPane.Settings.AllowDockTop = DefaultableBoolean.False;

                this.DockableControlPane.Pin();

                switch (dockedLocation)
                {
                    case DockedLocation.DockedBottom:
                        this.DockableControlPane.Dock(DockedSide.Bottom);
                        break;
                    case DockedLocation.DockedLeft:
                        this.DockableControlPane.Dock(DockedSide.Left);
                        break;
                    case DockedLocation.DockedRight:
                        this.DockableControlPane.Dock(DockedSide.Right);
                        break;
                    case DockedLocation.DockedTop:
                        this.DockableControlPane.Dock(DockedSide.Top);
                        break;
                }

                this.DestroyClosedPanes();
                this.DockAreaPane = this.DockableControlPane.DockAreaPane;

                OTrabajoControles.DockManager.ResumeLayout();
                this.ResumeLayout();
            }
        }

        /// <summary>
        /// Permite que el formulario pueda ser manejado por OrbitaUltraDockManager
        /// </summary>
        private void EliminarAnclaje()
        {
            if (OEscritoriosManager.PermiteAnclajes)
            {
                this.SuspendLayout();
                OTrabajoControles.DockManager.SuspendLayout();

                // Eventos para controlar la salida del formulario
                OTrabajoControles.DockManager.AfterPaneButtonClick -= this.FrmBase_AfterPaneButtonClick;
                OTrabajoControles.DockManager.AfterDockChange -= this.FrmBase_AfterDockChange;

                if (this.DockableWindow.ParentForm is MdiChildForm)
                {
                    ((MdiChildForm)this.DockableWindow.ParentForm).FormClosing -= this.FrmBase_FormClosing;
                    ((MdiChildForm)this.DockableWindow.ParentForm).FormClosed -= this.FrmBase_FormClosed;
                }

                this.DockableControlPane.Close();
                this.DestroyClosedPanes();

                OTrabajoControles.DockManager.ResumeLayout();
                this.ResumeLayout();
            }
        }

        /// <summary>
        /// Destruye los anclajes cerrados
        /// </summary>
        private void DestroyClosedPanes()
        {
            foreach (DockableControlPane pane in OTrabajoControles.DockManager.ControlPanes)
            {
                if (pane.Closed)
                {
                    if (pane.Control != null)
                        pane.Control.Dispose(); //removes from DockManager collections
                    pane.Dispose();
                }
            }
        }
        #endregion M�todos privados

        #region M�todo(s) protegidos
        /// <summary>
        /// Inicializa todos los componentes del formulario, cargando los datos si procede
        /// </summary>
        protected void IniciarFormulario()
        {
            this.Inicio = true;
            this.btnCancelar.Select();

            this.CargarDatosComunes();

            switch (this._ModoAperturaFormulario)
            {
                case ModoAperturaFormulario.Modificacion:
                    this.CargarDatosModoModificacion();
                    this.EstablecerModoModificacion();
                    break;
                default:
                    OLogsControlesVA.ControlesVA.Error("Inicio de formulario", "La ejecucion no deber�a pasar por este punto del c�digo: switch/default");
                    break;
            }

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
                switch (this._ModoAperturaFormulario)
                {
                    case ModoAperturaFormulario.Modificacion:
                        //Llamada a la funcion de guardado de datos
                        if (!this.GuardarDatosModoModificacion())
                        {
                            //Si han habido errores...
                            return false;
                        }
                        //Si no han habido errores...
                        this.ResetDeteccionModificaciones();
                        return true;
                    default:
                        OLogsControlesVA.ControlesVA.Error("Inicio de formulario", "La ejecucion no deber�a pasar por este punto del c�digo: switch/default");
                        return false;
                }
            }
            else //No se pueden guardar los datos por las restricciones impuestas
            {
                return false;
            }
        }
        /// <summary>
        /// Cambia el texto del bot�n aceptar
        /// </summary>
        /// <param name="nuevoTexto">Nuevo texto que tendr� el bot�n aceptar</param>
        protected void CambiarTextoBotonGuardar(string nuevoTexto)
        {
            this.btnSiguienteFinalizar.Text = nuevoTexto;
        }
        /// <summary>
        /// Cambia el texto del bot�n cancelar
        /// </summary>
        /// <param name="nuevoTexto">Nuevo texto que tendr� el bot�n cancelar</param>
        protected void CambiarTextoBotonCancelar(string nuevoTexto)
        {
            this.btnCancelar.Text = nuevoTexto;
        }
        /// <summary>
        /// Cambia la propiedad Visible del bot�n aceptar
        /// </summary>
        protected void OcultarBotonAceptar()
        {
            this.CambiarTextoBotonCancelar("Cerrar");
            this.btnSiguienteFinalizar.Visible = false;
        }
        /// <summary>
        /// Cambia la propiedad Visible del bot�n cancelar
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
        /// <summary>
        /// Establece el estilo de los botones de la barra de t�tulo del formulario
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                if (this._ModoAperturaFormulario == ModoAperturaFormulario.Sistema)
                {
                    myCp.ClassStyle = myCp.ClassStyle | 0x200;
                }
                return myCp;
            }
        }

        #endregion M�todos protegidos

        #region M�todo(s) virtual(es)
        /// <summary>
        /// Carga y muestra datos del formulario comunes para los modos de funcionamiento
        /// </summary>
        protected virtual void CargarDatosComunes()
        {
        }
        /// <summary>
        /// Carga y muestra datos del formulario en modo Modificaci�n. Se cargan todos datos que se muestran en 
        /// el formulario: grids, combos, etc... Cada carga de elementos estar� encapsulada en un m�todo
        /// </summary>
        protected virtual void CargarDatosModoModificacion()
        {
        }
        /// <summary>
        /// Establece la habiliacion adecuada de los controles para el modo Modificacion
        /// </summary>
        protected virtual void EstablecerModoModificacion()
        {
            this.SuspendLayout();
            this.ChkToolTip.Checked = false;
            this.toolTip.Active = false;
            this.InternoEstablecerModo(this.PnlPanelPrincipalPadre);
            this.ResumeLayout();
        }
        /// <summary>
        /// Guarda los datos cuando el formulario est� abierto en modo Modificaci�n
        /// </summary>
        /// <returns>True si la operaci�n de guardado de datos ha tenido �xito; false en caso contrario</returns>
        protected virtual bool GuardarDatosModoModificacion()
        {
            this._FormularioModificado = true;
            return true;
        }
        /// <summary>
        /// Se a�ade el evento de monitorizaci�n a los controles del formulario
        /// </summary>
        protected virtual void IniciarMonitorizarModificaciones()
        {
            this.InternoIniciarMonitorizarModificaciones(this);
        }
        /// <summary>
        /// Se elimina el evento de monitorizaci�n a los controles del formulario
        /// </summary>
        protected virtual void FinalizarMonitorizarModificaciones()
        {
            this.InternoFinalizarMonitorizarModificaciones(this);
        }
        /// <summary>
        /// Comprueba si se ha modificado alg�n dato en alg�n campo del formulario
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
        /// <returns>True si todo est� correcto para ser guardado; false en caso contrario</returns>
        protected virtual bool ComprobacionesDeCampos()
        {
            return true;
        }
        /// <summary>
        ///  M�todo para que sea sobreescrito en el hijo y realizar funciones si el usuario no desea guardar los cambios 
        /// </summary>
        protected virtual void AccionesNoGuardar()
        {

        }
        /// <summary>
        ///  M�todo  para que sea sobreescrito en el hijo y realizar funciones al salir del formulario
        /// </summary>
        protected virtual void AccionesSalir()
        {
        }
        #endregion M�todos virtuales

        #region M�todo(s) heredado(s)
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
                    OTrabajoControles.FormularioPrincipalMDI.OI.MostrarFormulario(this);

                    // Posici�n por defecto del formulario
                    this.DefatulRectangle = new Rectangle(this.Left, this.Top, this.Width, this.Height);

                    // Situa la posici�n del formulario
                    IOrbitaForm frmBase = this;

                    FrmBase.ListaFormsAbiertos.Add(this.Name);

                    //base.Show();
                    this.Visible = true;

                    // Dock para los formularios de monitorizaci�n
                    this._Anclado = false;
                    if ((this.ModoAperturaFormulario == ModoAperturaFormulario.Monitorizacion) ||
                        ((this.ModoAperturaFormulario == ModoAperturaFormulario.Sistema) &&
                        (this.MostrarBotones)))
                    {
                        this.CrearAnclaje();
                    }

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
        /// <param name="sender">Objeto que env�a el evento</param>
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
        /// <param name="sender">Objeto que env�a el evento</param>
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
        /// <param name="sender">Objeto que env�a el evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected virtual void btnSiguienteFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.GuardarDatos())
                {
                    //Si se han guardado los datos correctamente, cerramos el formulario
                    this.Close();
                }
            }
            catch (System.Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Guardar datos");
            }
        }
        /// <summary>
        /// Evento de cambio de anclaje sobre el control de anclaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAnterior_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Evento que se produce cuando se cierra el formulario, antes de cerrarlo
        /// </summary>
        /// <param name="sender">Objeto que env�a el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void FrmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if ((this.ModoAperturaFormulario == ModoAperturaFormulario.Sistema) && (e.CloseReason == CloseReason.UserClosing) && (!this.CierrePorUsuario))
                {
                    e.Cancel = true;
                }
                else
                {
                    this.btnCancelar.Focus();

                    if (this.ComprobarDatosModificados())
                    {
                        //Si hay datos modificados en el formulario, avisar y preguntar qu� hacer
                        switch (OMensajes.MostrarPreguntaSiNoCancelar("�Desea guardar los cambios realizados?", MessageBoxDefaultButton.Button3))
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
            }
            catch (System.Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Cierre de formulario");
            }
        }
        /// <summary>
        /// Evento que se produce cuando se cierra el formulario, despues de cerrarlo
        /// </summary>
        /// <param name="sender">Objeto que env�a el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void FrmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.FinalizarMonitorizarModificaciones();
                this.AccionesSalir();

                // Eliminamos el formulario de la lista de formularios abiertos
                FrmBase.ListaFormsAbiertos.Remove(this.Name);

                if ((this.ModoAperturaFormulario == ModoAperturaFormulario.Monitorizacion) ||
                    ((this.ModoAperturaFormulario == ModoAperturaFormulario.Sistema) &&
                    (this.MostrarBotones)))
                {
                    this.EliminarAnclaje();
                }
            }
            catch (System.Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Cierre de formulario");
            }
        }
        /// <summary>
        /// Evento que se produce cuando se activa el formulario, despues de mostrarse
        /// </summary>
        /// <param name="sender">Objeto que env�a el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void FrmBase_Activated(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Activaci�n de formulario");
            }
        }
        /// <summary>
        /// Cambio de valor en un componente
        /// </summary>
        /// <param name="sender">Objeto que env�a el evento</param>
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
        /// <param name="sender">Objeto que env�a el evento</param>
        /// <param name="celda">Argumentos del evento</param>
        private void EventoCeldaCambioValor(object sender, CellEventArgs celda)
        {
            this.EventoCambioValor(sender, new EventArgs());
        }
        /// <summary>
        /// Muestra o oculta los tooltips
        /// </summary>
        /// <param name="sender">Objeto que env�a el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void ChkToolTip_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.toolTip.Active = ChkToolTip.Checked;
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Clic en bot�n de ToolTips");
            }
        }
        /// <summary>
        /// Evento de clic sobre los botones del control de anclaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBase_AfterPaneButtonClick(object sender, PaneButtonEventArgs e)
        {
            try
            {
                if (e.Pane is DockableControlPane)
                {
                    Control c = ((DockableControlPane)e.Pane).Control;
                    if (((DockableControlPane)e.Pane).Control == this)
                    {
                        if (e.Button == PaneButton.Close)
                        {
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Clic en bot�n cerrar del anclaje");
            }
        }
        /// <summary>
        /// Evento de cambio de anclaje sobre el control de anclaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBase_AfterDockChange(object sender, PaneEventArgs e)
        {
            try
            {
                if (this.DockableControlPane.Control == this)
                {
                    if (this.DockableControlPane.IsMdiChild)
                    {
                        ((MdiChildForm)this.DockableWindow.ParentForm).Text = this.Text;
                        ((MdiChildForm)this.DockableWindow.ParentForm).Left = this.DefatulRectangle.Left;
                        ((MdiChildForm)this.DockableWindow.ParentForm).Width = this.DefatulRectangle.Width;
                        ((MdiChildForm)this.DockableWindow.ParentForm).Top = this.DefatulRectangle.Top;
                        ((MdiChildForm)this.DockableWindow.ParentForm).Height = this.DefatulRectangle.Height;
                        ((MdiChildForm)this.DockableWindow.ParentForm).FormBorderStyle = this.DefaultFormBorderStyle;
                        ((MdiChildForm)this.DockableWindow.ParentForm).WindowState = this.DefaultWindowState;
                        ((MdiChildForm)this.DockableWindow.ParentForm).FormClosing += this.FrmBase_FormClosing;
                        ((MdiChildForm)this.DockableWindow.ParentForm).FormClosed += this.FrmBase_FormClosed;
                        this.DockAreaPane.DefaultPaneSettings.AllowClose = Infragistics.Win.DefaultableBoolean.True;
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Formulario cambiado de anclaje");
            }
        }
        #endregion Manejadores de eventos
    }
}