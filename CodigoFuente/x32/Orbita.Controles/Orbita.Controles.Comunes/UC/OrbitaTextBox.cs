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
    public partial class OrbitaTextBox : System.Windows.Forms.TextBox, System.ComponentModel.ISupportInitialize
    {
        #region Atributos
        /// <summary>
        /// Indica que se debe inicializar con la fuente por defecto de Órbita.
        /// </summary>
        bool fuenteOrbita;
        /// <summary>
        /// Fuente por defecto del control.
        /// </summary>
        System.Drawing.Font fuente;
        /// <summary>
        /// Bloquear el control para que sea de solo lectura.
        /// </summary>
        bool iniciado;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaTextBox.
        /// </summary>
        public OrbitaTextBox()
            : base()
        {
            InitializeComponent();
            InicializeProperties();
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Se ejecuta cuando se produce un cambio en el valor del texto.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Se ejecuta cuando se produce un cambio en el texto.")]
        public event System.EventHandler ValueChanged;
        #endregion

        #region Propiedades
        /// <summary>
        /// Seleccionar la fuente por defecto de Órbita.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Selecciona la fuente por defecto de Orbita; si está a true, aunque se aplique otra fuente mantendrá siempre la fuente por defecto.")]
        [System.ComponentModel.DefaultValue(typeof(bool), "true")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbFuenteOrbita
        {
            get { return this.fuenteOrbita; }
            set
            {
                this.fuenteOrbita = value;
                if (value)
                {
                    this.Font = this.fuente;
                }
            }
        }
        /// <summary>
        /// Bloquear el control para que sea de solo lectura.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Bloquea el control para que sea de solo lectura.")]
        [System.ComponentModel.DefaultValue(typeof(bool), "false")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public new bool ReadOnly
        {
            get { return base.ReadOnly; }
            set { base.ReadOnly = value; }
        }
        /// <summary>
        /// Permitir escribir texto en varias lineas.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Permite escribir texto en varias lineas.")]
        [System.ComponentModel.DefaultValue(typeof(bool), "false")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public override bool Multiline
        {
            get { return base.Multiline; }
            set
            {
                base.Multiline = value;
                switch (base.Multiline)
                {
                    case true:
                        base.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                        break;
                    case false:
                        base.ScrollBars = System.Windows.Forms.ScrollBars.None;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Esta propiedad se sobreescribe para habilitar el multiline en el caso de que se asigne un texto multilinea en tiempo de ejecución.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Obtiene o establece el texto del control.")]
        [System.ComponentModel.DefaultValue(typeof(string), "")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (value == null)
                {
                    return;
                }
                base.Text = value;
                if (value.Contains("\n"))
                {
                    this.Multiline = true;
                    this.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                }
            }
        }
        /// <summary>
        /// Cambia la fuente del control, cuando la propiedad OrbFuentePorDefecto es false.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Cambia la fuente del control,si se establece la propiedad orbFuentePorDefecto a false.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Font), "Franklin Gothic Book, 9pt")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public new System.Drawing.Font Font
        {
            get { return base.Font; }
            set
            {
                if (!this.fuenteOrbita && value != null)
                {
                    base.Font = value;
                }
                else
                {
                    base.Font = this.fuente;
                }
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializar propiedades.
        /// </summary>
        void InicializeProperties()
        {
            base.Size = new System.Drawing.Size(100, 21);
            //base.Multiline = false;
            //base.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this.fuenteOrbita = true;
            this.fuente = new System.Drawing.Font("Franklin Gothic Book", 9F);
            this.iniciado = false;
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// TextChanged.
        /// </summary>
        /// <param name="sender">Objeto que envía el evento</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void OrbitaTextChanged(object sender, System.EventArgs e)
        {
            if (this.iniciado && this.ValueChanged != null)
            {
                this.ValueChanged(sender, e);
            }
        }
        /// <summary>
        /// KeyPress.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void OrbitaKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            if (this.Multiline == false && e.KeyChar == (char)13)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Miembros de ISupportInitialize
        /// <summary>
        /// Indica al objeto que está comenzando la inicialización.
        /// </summary>
        void System.ComponentModel.ISupportInitialize.BeginInit()
        {
            BeginInit();
        }
        /// <summary>
        /// Indica al objeto que está comenzando la inicialización.
        /// </summary>
        protected void BeginInit()
        {
            this.iniciado = false;
        }
        /// <summary>
        /// Indica al objeto que se ha completado la inicialización.
        /// </summary>
        void System.ComponentModel.ISupportInitialize.EndInit()
        {
            EndInit();
        }
        /// <summary>
        /// Indica al objeto que se ha completado la inicialización.
        /// </summary>
        protected void EndInit()
        {
            this.iniciado = true;
        }
        #endregion
    }
}