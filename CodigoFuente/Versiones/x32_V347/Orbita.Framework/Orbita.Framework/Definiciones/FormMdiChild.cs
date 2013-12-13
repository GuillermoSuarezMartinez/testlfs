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
namespace Orbita.Framework
{
    /// <summary>
    /// Mostrar un formulario de tipo MdiChild.
    /// </summary>
    [System.CLSCompliantAttribute(false)]
    public class FormMdiChild : ContainerBase
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.FormMdiChild.
        /// </summary>
        /// <param name="parent">Contenedor principal del control.</param>
        /// <param name="form">Formulario de tipo Orbita.Controles.Contenedores.OrbitaForm.</param>
        public FormMdiChild(object parent, Controles.Contenedores.OrbitaForm form)
            : base(parent, form) { }
        #endregion

        #region Métodos públicos override
        /// <summary>
        /// Mostrar el formulario como 
        /// </summary>
        public override void Mostrar()
        {
            System.Windows.Forms.FormWindowState estado = this.Form.WindowState;
            this.Form.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Form.MdiParent = this.Parent;
            this.Form.Show();
            this.Form.WindowState = estado;
        }
        #endregion
    }
}