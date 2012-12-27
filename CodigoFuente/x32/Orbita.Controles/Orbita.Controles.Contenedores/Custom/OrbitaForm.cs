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
namespace Orbita.Controles.Contenedores
{
    /// <summary>
    /// Orbita.Controles.OrbitaForm.
    /// </summary>
    public partial class OrbitaForm : System.Windows.Forms.Form
    {
        #region Atributos
        /// <summary>
        /// Número máximo de formularios.
        /// </summary>
        static int MdiMaxNumForms = 25;
        /// <summary>
        /// Cola con los formularios que se han abierto.
        /// </summary>
        System.Collections.Generic.Queue<OrbitaForm> MdiColaFormularios = new System.Collections.Generic.Queue<OrbitaForm>(MdiMaxNumForms);
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.OrbitaForm.
        /// </summary>
        public OrbitaForm()
        {
            InitializeComponent();
            InitializeProperties();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Número máximo de formularios.
        /// </summary>
        public int OrbMdiMaxNumForms
        {
            get { return MdiMaxNumForms; }
            set
            {
                if (this.OrbMdiColaFormularios.Count == 0)
                {
                    this.SetOrbMdiColaFormularios(new System.Collections.Generic.Queue<OrbitaForm>(value));
                    MdiMaxNumForms = value;
                }
                else
                {
                    throw new Orbita.Controles.Shared.OExcepcion("No se puede cambiar el número máximo de formularios en la cola del MDI cuando ya se han encolado formularios.");
                }
            }
        }
        /// <summary>
        /// Cola con los formularios que se han abierto.
        /// </summary>
        public System.Collections.Generic.Queue<OrbitaForm> OrbMdiColaFormularios
        {
            get { return this.MdiColaFormularios; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Cuando trabajamos con un MDI, encola un formulario le asigna el mdiParent y se queda con su evento closing para borrarlo cuando se cierre.
        /// </summary>
        /// <param name="form"></param>
        public void OrbMdiEncolarForm(OrbitaForm form)
        {
            if (this.IsMdiContainer && this.OrbMdiColaFormularios.Count < MdiMaxNumForms)
            {
                if (form == null)
                {
                    return;
                }
                this.OrbMdiColaFormularios.Enqueue(form);
                form.MdiParent = this;
                form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrbitaForm_Closed);
                form.Show();
            }
            else
            {
                throw new Orbita.Controles.Shared.OExcepcion("Ha alcanzado el número máximo de formularios abiertos.");
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializar propiedades.
        /// </summary>
        void InitializeProperties()
        {
            this.OrbToolTip.Active = OConfiguracion.OrbFormVerToolTips;
        }
        /// <summary>
        /// Asignar formularios a la cola.
        /// </summary>
        /// <param name="cola">Representa una colección de objetos de tipo primero en entrar, primero en salir.</param>
        void SetOrbMdiColaFormularios(System.Collections.Generic.Queue<OrbitaForm> cola)
        {
            this.MdiColaFormularios = cola;
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Closed.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void OrbitaForm_Closed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            try
            {
                OrbitaForm form = (OrbitaForm)sender;
                form.FormClosed -= new System.Windows.Forms.FormClosedEventHandler(this.OrbitaForm_Closed);
                for (int i = 0; i < this.OrbMdiColaFormularios.Count; i++)
                {
                    form = (OrbitaForm)OrbMdiColaFormularios.Dequeue();
                    if (form != sender)
                    {
                        OrbMdiColaFormularios.Enqueue(form);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}