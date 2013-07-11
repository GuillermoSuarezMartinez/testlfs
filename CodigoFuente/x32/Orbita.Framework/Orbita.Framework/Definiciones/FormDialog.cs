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
    /// Mostrar un formulario de tipo FormDialog.
    /// </summary>
    [System.CLSCompliantAttribute(false)]
    public class FormDialog : ContainerBase
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.FormDialog.
        /// </summary>
        /// <param name="parent">Contenedor principal del control.</param>
        /// <param name="form"></param>
        public FormDialog(object parent, Controles.Contenedores.OrbitaForm form)
            : base(parent, form) { }
        #endregion

        #region Métodos públicos override
        /// <summary>
        /// Mostrar el formulario como un cuadro de diálogo modal como ventana activa.
        /// </summary>
        public override void Mostrar()
        {
            Form.ShowDialog();
        }
        #endregion
    }
}