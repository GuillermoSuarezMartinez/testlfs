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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
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
    public partial class FrmDialogoBase : OrbitaForm, IOrbitaForm, IDisposable
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
        #endregion Campos

        #region Propiedad(es)
        /// <summary>
        /// Establece el estilo de los botones de la barra de t�tulo del formulario
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                //myCp.ExStyle |= 0x02000000;
                if (this._ModoAperturaFormulario == ModoAperturaFormulario.Sistema)
                {
                    myCp.ClassStyle |= 0x0200;
                }
                return myCp;
            }
        }

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
        /// Se activa a verdadero cuando se han guardado correctamten los datos del formulario,
        /// bien en la base de datos o bien en formulario invocante.
        /// </summary>
        private bool _FormularioModificado;
        /// <summary>
        /// Se activa a verdadero cuando se han guardado correctamente los datos del formulario,
        /// bien en la base de datos o bien en formulario invocante.
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica que la informaci�n contenida en el formulario ha sido modificada o que debe ser modificada")]
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
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de restaurar la posici�n del formulario a la �ltima guardada")]
        public bool RecordarPosicion
        {
            get { return false; }
            set { ; }
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
        Description("Muestra los botones de acci�n situados en la parte inferior del formulario")]
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
                return this.WindowState == FormWindowState.Maximized;
            }
            set
            {
                if (value)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
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
        [Browsable(false)]
        public bool Anclado
        {
            get { return false; }
        }

        /// <summary>
        /// Is Docked MDIChild
        /// </summary>
        [Browsable(false)]
        public bool IsDockedMDIChild
        {
            get { return false; }
            set { ;}
        }

        /// <summary>
        /// Rectangulo de visualizaci�n del fomrulario MDI de tipo anclable
        /// </summary>
        [Browsable(false)]
        public Rectangle DockedMDIRectangle
        {
            get { return new Rectangle(); }
            set { ;}
        }

        /// <summary>
        /// Rectangulo de visualizaci�n del fomrulario anclado
        /// </summary>
        [Browsable(false)]
        public Size DockedPaneSize
        {
            get { return new Size(); }
            set { ;}
        }

        /// <summary>
        /// Informa si la la ventana anclada est� puesta para no oculatarse autom�ticamente
        /// </summary>
        [Browsable(false)]
        public bool DockedPined
        {
            get { return false; }
            set { ;}
        }

        /// <summary>
        /// Localizaci�n del anclaje
        /// </summary>
        [Browsable(false)]
        public DockedLocation DockedLocation
        {
            get { return DockedLocation.DockedRight; }
            set { ;}
        }
        #endregion Propiedades

        #region Constructor(es)
        /// <summary>
        /// Constructor vacio de la clase (es necesario para que el dise�ador construya el formulario heredado en tiempo de dise�o)
        /// </summary>		
        public FrmDialogoBase()
        {
            InitializeComponent();

            // Inicialiaci�n de campos
            this.AlgoModificado = false;
            this._FormularioModificado = false;
            this.CierrePorUsuario = false;
        }
        /// <summary>
        /// Constructor de la clase (No existe bloqueo de registro)
        /// </summary>
        /// <param name="modoFormulario">Modo de apertura del formulario (Nuevo, Visualizacion, Modificacion, Ninguno)</param>
        public FrmDialogoBase(ModoAperturaFormulario modoFormulario)
        {
            InitializeComponent();
            this._ModoAperturaFormulario = modoFormulario;

            // Inicialiaci�n de campos
            this.AlgoModificado = false;
            this._FormularioModificado = false;
            this.CierrePorUsuario = false;
        }
        #endregion Constructores

        #region Destructores
        /// <summary>
        /// Destructor de la clase
        /// </summary>
        public new void Dispose()
        {
            base.Dispose();
            //GC.Collect();
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
                    this.toolTip.SetToolTip(((OrbitaUltraGridToolBar)controlInterno).Grid, this.toolTip.GetToolTip(((OrbitaUltraGridToolBar)controlInterno)));
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
                case ModoAperturaFormulario.Nuevo:
                    this.CargarDatosModoNuevo();
                    this.EstablecerModoNuevo();
                    break;
                case ModoAperturaFormulario.Modificacion:
                    this.CargarDatosModoModificacion();
                    this.EstablecerModoModificacion();
                    break;
                case ModoAperturaFormulario.Visualizacion:
                    this.OcultarBotonCancelar();
                    this.CargarDatosModoVisualizacion();
                    this.EstablecerModoVisualizacion();
                    break;
                case ModoAperturaFormulario.Monitorizacion:
                    this.OcultarBotones();
                    this.OcultarBotonAceptar();
                    this.CargarDatosModoMonitorizacion();
                    this.EstablecerModoMonitorizacion();
                    break;
                case ModoAperturaFormulario.Sistema:
                    this.OcultarBotones();
                    this.OcultarBotonCancelar();
                    this.OcultarBotonAceptar();
                    this.CargarDatosModoSistema();
                    this.EstablecerModoSistema();
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
                    case ModoAperturaFormulario.Nuevo:
                        //Llamada a la funcion de guardado de datos
                        if (!this.GuardarDatosModoNuevo())
                        {
                            //Si han habido errores...
                            return false;
                        }
                        //Si no han habido errores...
                        this.ResetDeteccionModificaciones();
                        return true;
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
                    case ModoAperturaFormulario.Visualizacion:
                        //Llamada a la funcion de guardado de datos
                        if (!this.GuardarDatosModoVisualizacion())
                        {
                            //Si han habido errores...
                            return false;
                        }
                        //Si no han habido errores...
                        this.ResetDeteccionModificaciones();
                        return true;
                    case ModoAperturaFormulario.Monitorizacion:
                        //Llamada a la funcion de guardado de datos
                        if (!this.GuardarDatosModoMonitorizacion())
                        {
                            //Si han habido errores...
                            return false;
                        }
                        //Si no han habido errores...
                        this.ResetDeteccionModificaciones();
                        return true;
                    case ModoAperturaFormulario.Sistema:
                        //Llamada a la funcion de guardado de datos
                        if (!this.GuardarDatosModoSistema())
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
            this.btnGuardar.Text = nuevoTexto;
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
            this.btnGuardar.Visible = false;
        }
        /// <summary>
        /// Cambia la propiedad Visible del bot�n cancelar
        /// </summary>
        protected void OcultarBotonCancelar()
        {
            this.CambiarTextoBotonGuardar("Aceptar");
            this.btnCancelar.Visible = false;
            this.btnGuardar.Location = this.btnCancelar.Location;
            this.btnGuardar.Select();
        }
        /// <summary>
        /// Cambia la propiedad Visible de la barra de botones
        /// </summary>
        protected void OcultarBotones()
        {
            this.PnlInferiorPadre.Visible = this._MostrarBotones;
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
        /// Carga y muestra datos del formulario en modo edici�n. Se cargan todos datos que se muestran en 
        /// el formulario: grids, combos, etc... Cada carga de elementos estar� encapsulada en un m�todo
        /// </summary>
        protected virtual void CargarDatosModoNuevo()
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
        /// Carga y muestra datos del formulario en modo visualizaci�n. Se cargan todos datos que se muestran en 
        /// el formulario: grids, combos, etc... Cada carga de elementos estar� encapsulada en un m�todo
        /// </summary>
        protected virtual void CargarDatosModoVisualizacion()
        {
        }
        /// <summary>
        /// Carga y muestra datos del formulario en modo Monitorizaci�n. Se cargan todos datos que se muestran en 
        /// el formulario: grids, combos, etc... Cada carga de elementos estar� encapsulada en un m�todo
        /// </summary>
        protected virtual void CargarDatosModoMonitorizacion()
        {
        }
        /// <summary>
        /// Carga y muestra datos del formulario en modo sistema. Se cargan todos datos que se muestran en 
        /// el formulario: grids, combos, etc... Cada carga de elementos estar� encapsulada en un m�todo
        /// </summary>
        protected virtual void CargarDatosModoSistema()
        {
        }
        /// <summary>
        /// Establece la habiliacion adecuada de los controles para el modo Nuevo
        /// </summary>
        protected virtual void EstablecerModoNuevo()
        {
            this.SuspendLayout();
            this.ChkToolTip.Checked = false;
            this.toolTip.Active = false;
            this.InternoEstablecerModo(this.PnlPanelPrincipalPadre);
            this.ResumeLayout();
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
        /// Establece la habiliacion adecuada de los controles para el modo visualizacion
        /// </summary>
        protected virtual void EstablecerModoVisualizacion()
        {
            this.SuspendLayout();
            this.ChkToolTip.Checked = false;
            this.toolTip.Active = false;
            this.InternoEstablecerModo(this.PnlPanelPrincipalPadre);
            this.ResumeLayout();
        }
        /// <summary>
        /// Establece la habiliacion adecuada de los controles para el modo monitorizaci�n
        /// </summary>
        protected virtual void EstablecerModoMonitorizacion()
        {
            this.SuspendLayout();
            this.ChkToolTip.Checked = false;
            this.toolTip.Active = false;
            this.InternoEstablecerModo(this.PnlPanelPrincipalPadre);
            this.ResumeLayout();
        }
        /// <summary>
        /// Establece la habiliacion adecuada de los controles para el modo sistema
        /// </summary>
        protected virtual void EstablecerModoSistema()
        {
            this.SuspendLayout();
            this.ChkToolTip.Checked = false;
            this.toolTip.Active = false;
            this.InternoEstablecerModo(this.PnlPanelPrincipalPadre);
            this.ResumeLayout();
        }
        /// <summary>
        /// Guarda los datos cuando el formulario est� abierto en modo Creaci�n
        /// </summary>
        /// <returns>True si la operaci�n de guardado de datos ha tenido �xito; false en caso contrario</returns>
        protected virtual bool GuardarDatosModoNuevo()
        {
            this._FormularioModificado = true;
            return true;
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
        /// Guarda los datos cuando el formulario est� abierto en modo visualizacion
        /// </summary>
        /// <returns>True si la operaci�n de guardado de datos ha tenido �xito; false en caso contrario</returns>
        protected virtual bool GuardarDatosModoVisualizacion()
        {
            return true;
        }
        /// <summary>
        /// Guarda los datos cuando el formulario est� abierto en modo monitorizaci�n
        /// </summary>
        /// <returns>True si la operaci�n de guardado de datos ha tenido �xito; false en caso contrario</returns>
        protected virtual bool GuardarDatosModoMonitorizacion()
        {
            return true;
        }
        /// <summary>
        /// Guarda los datos cuando el formulario est� abierto en modo sistema
        /// </summary>
        /// <returns>True si la operaci�n de guardado de datos ha tenido �xito; false en caso contrario</returns>
        protected virtual bool GuardarDatosModoSistema()
        {
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

                    // Situa la posici�n del formulario
                    IOrbitaForm frm = this;

                    FrmBase.ListaFormsAbiertos.Add(this.Name);

                    base.ShowDialog();
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
        protected virtual void btnGuardar_Click(object sender, EventArgs e)
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
                if (!this.Inicio)
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
        #endregion Manejadores de eventos
    }
}