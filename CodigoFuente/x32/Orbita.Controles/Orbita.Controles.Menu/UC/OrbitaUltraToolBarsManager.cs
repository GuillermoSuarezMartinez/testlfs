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
namespace Orbita.Controles.Menu
{
    /// <summary>
    /// Orbita.Controles.Menu.OrbitaUltraToolBarsManager.
    /// </summary>
    public partial class OrbitaUltraToolbarsManager : Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Menu.OrbitaUltraToolBarsManager.
        /// </summary>
        public OrbitaUltraToolbarsManager()
            : base()
        {
            InitializeComponent();
            InitializeResourceStrings();
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Menu.OrbitaUltraToolBarsManager.
        /// </summary>
        /// <param name="contenedor">Proporciona funcionalidad para contenedores. Los contenedores son objetos
        /// que contienen cero o más componentes de forma lógica.</param>
        public OrbitaUltraToolbarsManager(System.ComponentModel.IContainer contenedor)
            : base(contenedor)
        {
            if (contenedor == null)
            {
                return;
            }
            contenedor.Add(this);
            InitializeComponent();
            InitializeResourceStrings();
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Hace visible o no un botón de la ToolBar.
        /// </summary>
        /// <param name="clave">Clave del botón.</param>
        /// <param name="mostrar">Indica si se muestra o no el botón.</param>    
        public void BotonVisible(string clave, bool mostrar)
        {
            this.Toolbars[0].Tools[clave].SharedProps.Visible = mostrar;
        }
        /// <summary>
        /// Habilita o deshabilita un botón de la ToolBar.
        /// <param name="clave">Clave del botón.</param>
        /// <param name="habilita">Indica si se habilita o no el botón.</param>     
        /// </summary> 
        public void BotonEnabled(string clave, bool habilita)
        {
            this.Toolbars[0].Tools[clave].SharedProps.Enabled = habilita;
        }
        /// <summary>
        /// Da valor al ToolTipText del botón.
        /// <param name="clave">key del botón.</param>
        /// <param name="texto">texto a mostrar en el botón.</param>     
        /// </summary> 
        public void BotonToolTipText(string clave, string texto)
        {
            this.Toolbars[0].Tools[clave].SharedProps.ToolTipText = texto;
        }
        /// <summary>
        /// Agregar un botón a la ToolBar del tipo BotonesToolbar.TipoBoton.
        /// </summary>
        /// <param name="posicionToolBar">ToolBar correspondiente a la Orbita.Controles.ToolBarManager.</param>
        /// <param name="control">Control a añadir.</param>
        /// <param name="posicion">Posicion del control.</param>
        /// <param name="alFinal">Indicamos si lo ponemos al final.</param>       
        public void AgregarControl(Orbita.Controles.Shared.PosicionToolBar posicionToolBar, System.Windows.Forms.Control control, int posicion, bool alFinal)
        {
            if (control == null)
            {
                return;
            }
            Infragistics.Win.UltraWinToolbars.ControlContainerTool nuevoContainerTool = new Infragistics.Win.UltraWinToolbars.ControlContainerTool(control.Name);
            nuevoContainerTool.SharedProps.Visible = true;
            nuevoContainerTool.Control = control;
            this.Tools.Add(nuevoContainerTool);
            if (alFinal || posicion > this.Toolbars[(int)posicionToolBar].Tools.Count - 1)
            {
                this.Toolbars[(int)posicionToolBar].Tools.AddTool(nuevoContainerTool.Key);
            }
            else
            {
                if (posicion < 0)
                {
                    this.Toolbars[(int)posicionToolBar].Tools.InsertTool(0, nuevoContainerTool.Key);
                }
                else
                {
                    this.Toolbars[(int)posicionToolBar].Tools.InsertTool(posicion, nuevoContainerTool.Key);
                }
            }
        }
        /// <summary>
        /// Agregar un botón a la ToolBar del tipo BotonesToolbar.TipoBoton.
        /// </summary>
        /// <param name="texto">Texto a añadir.</param>
        /// <param name="posicion">Posicion del texto.</param>
        /// <param name="alFinal">Hace spring hasta el final.</param>
        /// <returns>La clave del texto que se acaba de añadir para identificar el control dentro de la ToolBar.</returns>
        public string AgregarTexto(string texto, int posicion, bool alFinal)
        {
            // Crear un LabelTool que contenga el texto.
            Infragistics.Win.UltraWinToolbars.LabelTool nuevoLabelTool = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTexto" + (this.Toolbars[0].Tools.Count - 1));
            nuevoLabelTool.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            nuevoLabelTool.SharedProps.Caption = texto;
            this.Tools.Add(nuevoLabelTool);
            if (alFinal || posicion > this.Toolbars[0].Tools.Count - 1)
            {
                nuevoLabelTool.SharedProps.Spring = true;
                this.Toolbars[0].Tools.AddTool(nuevoLabelTool.Key);
            }
            else
            {
                if (posicion < 0)
                {
                    this.Toolbars[0].Tools.InsertTool(0, nuevoLabelTool.Key);
                }
                else
                {
                    this.Toolbars[0].Tools.InsertTool(posicion, nuevoLabelTool.Key);
                }
            }
            return nuevoLabelTool.Key;
        }
        /// <summary>
        /// Agregar un botón a la ToolBar del tipo BotonesToolbar.TipoBoton.
        /// </summary>
        /// <param name="clave">Key del botón.</param>
        /// <param name="texto">texto del botón (ToolTipText).</param>
        /// <param name="imagen">Imagen del botón.</param>
        public void AgregarBoton(string clave, string texto, System.Drawing.Bitmap imagen)
        {
            Infragistics.Win.UltraWinToolbars.ToolBase boton = new Infragistics.Win.UltraWinToolbars.ButtonTool(clave);
            boton.SharedProps.AppearancesLarge.Appearance.Image = boton.SharedProps.AppearancesSmall.Appearance.Image = imagen;
            boton.SharedProps.Caption = clave;
            boton.SharedProps.ToolTipText = texto;
            this.Tools.Add(boton);
            this.Toolbars[0].Tools.AddTool(clave);
        }
        /// <summary>
        /// Agregar un botón a la ToolBar del tipo BotonesToolbar.TipoBoton.
        /// </summary>
        /// <param name="texto">Texto del botón.</param>
        /// <param name="imagen">Imagen del botón.</param>
        /// <param name="clave">Key del botón.</param>
        /// <param name="posicion">Posición en la botón.</param>
        /// <param name="alFinal">Lo ponemos al final.</param>
        public void AgregarBoton(string texto, System.Drawing.Bitmap imagen, string clave, int posicion, bool alFinal)
        {
            this.AgregarBoton(0, texto, imagen, clave, posicion, alFinal, Orbita.Controles.Shared.TipoTool.Boton);
        }
        /// <summary>
        /// Agregar un botón a la ToolBar del tipo BotonesToolbar.TipoBoton.
        /// </summary>
        /// <param name="posicionToolBar">La toolbar en la que vamos a agregar el control.</param>
        /// <param name="texto">Texto del botón.</param>
        /// <param name="imagen">Imagen del botón.</param>
        /// <param name="clave">Key del botón.</param>
        /// <param name="posicion">Posición en la botón.</param>
        /// <param name="alFinal">Lo ponemos al final.</param>
        public void AgregarBoton(Orbita.Controles.Shared.PosicionToolBar posicionToolBar, string texto, System.Drawing.Bitmap imagen, string clave, int posicion, bool alFinal)
        {
            this.AgregarBoton(posicionToolBar, texto, imagen, clave, posicion, alFinal, Orbita.Controles.Shared.TipoTool.Boton);
        }
        /// <summary>
        /// Agregar un botón a la ToolBar del tipo BotonesToolbar.TipoBoton.
        /// </summary>
        /// <param name="texto">Texto de la tool.</param>
        /// <param name="imagen">Imagen de la tool.</param>
        /// <param name="clave">Key de la tool.</param>
        /// <param name="tipoTool">Tipo de tool.</param>
        public void AgregarBoton(string texto, System.Drawing.Bitmap imagen, string clave, Orbita.Controles.Shared.TipoTool tipoTool)
        {
            this.AgregarBoton(0, texto, imagen, clave, 0, true, tipoTool);
        }
        /// <summary>
        /// Agregar un botón a la ToolBar del tipo BotonesToolbar.Tipo.Boton.
        /// </summary>
        /// <param name="posicionToolBar">La ToolBar en la que vamos a agregar el control.</param>
        /// <param name="texto">Texto de la tool.</param>
        /// <param name="imagen">Imagen de la tool.</param>
        /// <param name="clave">Clave de la tool.</param>
        /// <param name="posicion">Posición en la ToolBar.</param>
        /// <param name="alFinal">Lo ponemos al final.</param>
        /// <param name="tipoTool">Tipo de tool.</param>
        public void AgregarBoton(Orbita.Controles.Shared.PosicionToolBar posicionToolBar, string texto, System.Drawing.Bitmap imagen, string clave, int posicion, bool alFinal, Orbita.Controles.Shared.TipoTool tipoTool)
        {
            Infragistics.Win.UltraWinToolbars.ToolBase boton;
            switch (tipoTool)
            {
                case Orbita.Controles.Shared.TipoTool.Boton:
                default:
                    boton = new Infragistics.Win.UltraWinToolbars.ButtonTool(clave);
                    break;
                case Orbita.Controles.Shared.TipoTool.Check:
                    boton = new Infragistics.Win.UltraWinToolbars.StateButtonTool(clave);
                    break;
            }
            boton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            boton.SharedProps.Caption = texto;
            boton.SharedProps.Visible = true;
            boton.SharedProps.AppearancesSmall.Appearance.Image = imagen;
            this.Tools.Add(boton);
            if (alFinal || posicion > this.Toolbars[0].Tools.Count - 1)
            {
                this.Toolbars[(int)posicionToolBar].Tools.AddTool(clave);
            }
            else
            {
                if (posicion < 0)
                {
                    this.Toolbars[(int)posicionToolBar].Tools.InsertTool(0, clave);
                }
                else
                {
                    this.Toolbars[(int)posicionToolBar].Tools.InsertTool(posicion, clave);
                }
            }
        }
        /// <summary>
        /// Hace visible o no un control de la ToolBar.
        /// </summary>
        /// <param name="posicionToolBar">ToolBar correspondiente a la Orbita.Controles.ToolBarManager.</param>
        /// <param name="control">Control a añadir.</param>
        /// <param name="mostrar">Indica si se muestra o no el botón.</param>
        public void ControlVisible(Orbita.Controles.Shared.PosicionToolBar posicionToolBar, System.Windows.Forms.Control control, bool mostrar)
        {
            if (control != null)
            {
                this.Toolbars[(int)posicionToolBar].Tools[control.Name].SharedProps.Visible = mostrar;
            }
        }
        #endregion

        #region Métodos privados estáticos
        /// <summary>
        /// InitializeResourceStrings.
        /// </summary>
        static void InitializeResourceStrings()
        {
            Infragistics.Shared.ResourceCustomizer resCustomizer = Infragistics.Win.UltraWinToolbars.Resources.Customizer;
            resCustomizer.SetCustomizedString("MdiCommandArrangeIcons", "Organizar iconos");
            resCustomizer.SetCustomizedString("MdiCommandCascade", "Mostrar ventanas en cascada");
            resCustomizer.SetCustomizedString("MdiCommandCloseWindows", "Cerrar todas las ventanas");
            resCustomizer.SetCustomizedString("MdiCommandTileHorizontal", "Pestañas horizontal");
            resCustomizer.SetCustomizedString("MdiCommandTileVertical", "Pestañas vertical");
            resCustomizer.SetCustomizedString("MdiCommandMinimizeWindows", "Minimizar todas las ventanas");
        }
        #endregion
    }
}
