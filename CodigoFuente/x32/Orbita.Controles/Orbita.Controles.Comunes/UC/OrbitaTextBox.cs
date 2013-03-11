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
using System.ComponentModel;
namespace Orbita.Controles.Comunes
{
    public partial class OrbitaTextBox : System.Windows.Forms.TextBox
    {
        public class ControlNuevaDefinicion : OTextBox
        {
            public ControlNuevaDefinicion(OrbitaTextBox sender)
                : base(sender) { }
        };

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaTextBox.
        /// </summary>
        public OrbitaTextBox()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
            InicializeProperties();
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicion OI
        {
            get { return this.definicion; }
            set { this.definicion = value; }
        }
        public override bool Multiline
        {
            get { return base.Multiline; }
            set
            {
                base.Multiline = value;
                if (this.OI.AutoScrollBar)
                {
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
        }
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
                }
            }
        }
        #endregion

        #region Métodos privados
        void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new ControlNuevaDefinicion(this);
            }
        }
        void InicializeProperties()
        {
            base.Size = new System.Drawing.Size(100, 21);
            this.OI.AutoScrollBar = Configuracion.DefectoAutoScrollBar;
        }
        #endregion
    }
}