using System;
using System.ComponentModel;
//***********************************************************************
// Assembly         : Orbita.Framework
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.Windows.Forms;
namespace Orbita.Framework.Core
{
    [System.CLSCompliantAttribute(false)]
    public partial class ContainerForm : Orbita.Controles.Contenedores.OrbitaMdiContainerForm
    {
        #region Atributos
        OIContainerForm definicion;
        #endregion

        event EventHandler<DialogResultArgs> DialogReturning;

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.ContainerForm.
        /// </summary>
        public ContainerForm()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
            InitializeProperties();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de definición de Órbita Ingeniería.
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public new OIContainerForm OI
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
                this.definicion = new OIContainerForm(this);
            }
        }
        void InitializeProperties()
        {
            this.OI.Autenticación = ConfiguracionEntorno.DefectoAutenticación;
            this.OI.NumeroMaximoFormulariosAbiertos = ConfiguracionEntorno.DefectoNumeroMaximoFormulariosAbiertos;
        }
        #endregion

        public void ShowChildDialog(Form sender, EventHandler<DialogResultArgs> DialogReturnedValue)
        {
            sender.MdiParent = this;
            sender.FormClosed += new FormClosedEventHandler(ChildClosed);
            DialogReturning += DialogReturnedValue;
            sender.Show();
        }
        //public void ShowAuthenticationDialog(Form sender, EventHandler<DialogResultArgs> DialogReturnedValue)
        //{
        //    sender.MdiParent = this;
        //    sender.FormClosed += new FormClosedEventHandler(ChildClosed);
        //    DialogReturning += DialogReturnedValue;
        //    sender.Show();
        //}

        protected void ChildClosed(object sender, FormClosedEventArgs e)
        {
            Form form = (Form)sender;
            form.FormClosed -= new FormClosedEventHandler(ChildClosed);
            DialogReturned(form, new DialogResultArgs(form.DialogResult));
        }

        public virtual void DialogReturned(object sender, DialogResultArgs DialogReturnedValue)
        {
            if (DialogReturning != null)
            {
                DialogReturning(sender, DialogReturnedValue);
            }
        }
    }
    public class DialogResultArgs : EventArgs
    {
        private DialogResult _Result;
        /// <summary>
        /// Returns DialogResult from the dialog form.
        /// </summary>
        [Description("Get DialogResult returned by the dialog form")]
        [Category("Property")]
        public DialogResult Result
        {
            get { return _Result; }
        }
        public DialogResultArgs(DialogResult dr)
        {
            _Result = dr;
        }
    }
}