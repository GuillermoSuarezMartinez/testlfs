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
    [System.CLSCompliantAttribute(false)]
    public class UserControl : ContainerBase
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.UserControl.
        /// </summary>
        /// <param name="parent">Contenedor principal del control.</param>
        /// <param name="control"></param>
        public UserControl(object parent, Controles.Shared.OrbitaUserControl control)
            : base(parent, control) { }
        #endregion

        #region Métodos públicos override
        /// <summary>
        /// Agregar el control especificado a la colección de controles y mostrarlo.
        /// </summary>
        public override void Mostrar()
        {
            UserControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Parent.Controls.Add(this.UserControl);
            this.Parent.Controls.SetChildIndex(UserControl, 0);
        }
        #endregion
    }
}