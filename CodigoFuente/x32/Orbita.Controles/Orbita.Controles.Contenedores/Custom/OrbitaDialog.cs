//***********************************************************************
// Assembly         : Orbita.Controles.Contenedores
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.ComponentModel;
namespace Orbita.Controles.Contenedores
{
    public partial class OrbitaDialog : System.Windows.Forms.Form
    {
        public class ControlNuevaDefinicion : ODialog
        {
            public ControlNuevaDefinicion(OrbitaDialog sender)
                : base(sender) { }
        };

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.OrbitaPanel.
        /// </summary>
        public OrbitaDialog()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
            InitializeProperties();
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
        #endregion

        #region Métodos privados
        void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new ControlNuevaDefinicion(this);
            }
        }
        void InitializeProperties()
		{
			this.toolTip.Active = Configuracion.DefectoVerToolTips;
		}
        #endregion

        #region Manejadores de eventos
		protected virtual void OnKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{
				if (e == null)
				{
					return;
				}
				if (e.KeyChar == (char)System.ConsoleKey.Escape)
				{
					this.Close();
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion
    }
}