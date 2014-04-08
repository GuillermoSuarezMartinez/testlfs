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
    /// <summary>
    /// Componente para la gestión del acoplamiento y la flotación de los controles de un formulario.
    /// </summary>
    public partial class OrbitaUltraDockManager : Infragistics.Win.UltraWinDock.UltraDockManager
    {
        #region Nueva definición
        public class ControlNuevaDefinicion : OUltraDockManager
        {
            #region Constructor
            /// <summary>
            /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraDockManager.ControlNuevaDefinicion.
            /// </summary>
            /// <param name="sender">Representa un control para mostrar una lista de elementos.</param>
            public ControlNuevaDefinicion(OrbitaUltraDockManager sender)
                : base(sender) { }
            #endregion
        }
        #endregion

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraDockManager.
        /// </summary>
        public OrbitaUltraDockManager()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraDockManager.
        /// </summary>
        /// <param name="contenedor">Proporciona funcionalidad para contenedores. Los contenedores son objetos
        /// que contienen cero o más componentes de forma lógica.</param>
        public OrbitaUltraDockManager(System.ComponentModel.IContainer contenedor)
            : base(contenedor)
        {
            if (contenedor == null)
            {
                return;
            }
            contenedor.Add(this);
            InitializeComponent();
            InitializeAttributes();
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraDockManager.
        /// </summary>
        /// <param name="info">Almacena todos los datos necesarios para serializar o deserializar un objeto.</param>
        /// <param name="context">Describe el origen y destino de una secuencia de serialización determinada y proporciona un contexto definido por el llamador adicional.</param>
        protected OrbitaUltraDockManager(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            InitializeComponent();
            InitializeAttributes();
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Category("Gestión de controles")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
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
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Se invoca durante la serialización del objeto.
        /// </summary>
        /// <param name="info">Almacena todos los datos necesarios para serializar o deserializar un objeto.</param>
        /// <param name="context">Describe el origen y destino de una secuencia de serialización determinada y proporciona un contexto definido por el llamador adicional.</param>
        [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Flags=System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter)]
        protected override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
        #endregion
    }
}