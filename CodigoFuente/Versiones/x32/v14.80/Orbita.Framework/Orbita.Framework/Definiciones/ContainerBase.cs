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
    /// Contenedor base abstracto de métodos y tipos.
    /// </summary>
    [System.CLSCompliantAttribute(false)]
    public abstract class ContainerBase
    {
        #region Atributos
        /// <summary>
        /// Acceso al contenedor principal de plugins.
        /// </summary>
        Main parent;
        /// <summary>
        /// Objeto de tipo Controles.Shared.OrbitaUserControl.
        /// </summary>
        Controles.Shared.OrbitaUserControl userControl;
        /// <summary>
        /// Objeto de tipo Controles.Contenedores.OrbitaForm.
        /// </summary>
        Controles.Contenedores.OrbitaForm form;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.ContainerBase.
        /// </summary>
        /// <param name="parent">Contenedor principal del control.</param>
        private ContainerBase(object parent)
        {
            this.parent = (Main)parent;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.ContainerBase.
        /// </summary>
        /// <param name="parent">Contenedor principal del control.</param>
        /// <param name="form">Plugin de tipo Orbita.Controles.Contenedores.OrbitaForm.</param>
        protected ContainerBase(object parent, Controles.Contenedores.OrbitaForm form)
            : this(parent)
        {
            this.form = form;
            if (this.parent.Controles == null || form == null) return;
            InitializePluginControls(form.GetType().FullName, form);
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.ContainerBase.
        /// </summary>
        /// <param name="parent">Contenedor principal del control.</param>
        /// <param name="userControl">Plugin de tipo Orbita.Controles.Shared.OrbitaUserControl.</param>
        protected ContainerBase(object parent, Controles.Shared.OrbitaUserControl userControl)
            : this(parent)
        {
            this.userControl = userControl;
            if (this.parent.Controles == null || userControl == null) return;
            InitializePluginControls(userControl.GetType().FullName, userControl);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Contenedor principal del control.
        /// </summary>
        protected Main Parent
        {
            get { return this.parent; }
        }
        /// <summary>
        /// Plugin de tipo Orbita.Controles.Shared.OrbitaUserControl.
        /// </summary>
        protected Controles.Shared.OrbitaUserControl UserControl
        {
            get { return this.userControl; }
        }
        /// <summary>
        /// Plugin de tipo Orbita.Controles.Contenedores.OrbitaForm.
        /// </summary>
        protected Controles.Contenedores.OrbitaForm Form
        {
            get { return this.form; }
        }
        #endregion

        #region Métodos privados
        private void InitializePluginControls(string nombre, System.Windows.Forms.Control contenedor)
        {
            foreach (System.Windows.Forms.Control control in contenedor.Controls)
            {
                InitializePluginControls(nombre + "." + control.Name, control);
            }
            if (Parent.Controles.ContainsKey(nombre))
            {
                Core.ControlInfo info = this.Parent.Controles[nombre];
                if (info.Tipo == "text")
                {
                    contenedor.Text = info.Valor;
                }
            }
        }
        #endregion

        #region Métodos abstractos
        /// <summary>
        /// Mostrar un objeto de tipo System.Windows.Forms.Control en pantalla.
        /// </summary>
        public abstract void Mostrar();
        #endregion
    }
}