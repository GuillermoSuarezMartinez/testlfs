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
namespace Orbita.Controles.Contenedores
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OMdiContainerForm
    {
        #region Atributos
        OrbitaMdiContainerForm control;
        int numeroMaximoFormulariosAbiertos;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.OMdiContainerForm.
        /// </summary>
        /// <param name="control"></param>
        public OMdiContainerForm(object control)
            : base()
        {
            this.control = (OrbitaMdiContainerForm)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaMdiContainerForm Control
        {
            get { return this.control; }
        }
        [System.ComponentModel.Description("Número máximo de formularios abiertos en el formulario contenedor.")]
        public int NumeroMaximoFormulariosAbiertos
        {
            get { return this.numeroMaximoFormulariosAbiertos; }
            set { this.numeroMaximoFormulariosAbiertos = value; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Invalida el método ToString() para devolver una cadena que representa la instancia de objeto.
        /// </summary>
        /// <returns>El nombre de tipo completo del objeto.</returns>
        public override string ToString()
        {
            return null;
        }
        public bool MostrarFormulario(OrbitaForm form)
        {
            if (form == null)
            {
                return false;
            }
            if (this.control.MdiChildren.Length < this.numeroMaximoFormulariosAbiertos)
            {
                //foreach (OrbitaForm hijo in this.control.MdiChildren)
                //{
                    //if (hijo.GetType() == form.GetType())
                    //{
                    //    hijo.Activate();
                    //    hijo.BringToFront();
                    //    return true;
                    //}
                //}
                form.MdiParent = this.control;
                form.Show();
            }
            else
            {
                throw new System.Exception("Se ha alcanzado el número máximo de formularios abiertos.");
            }
            return false;
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetNumeroMaximoFormulariosAbiertos()
        {
            this.NumeroMaximoFormulariosAbiertos = Configuración.DefectoNumeroMaximoFormulariosAbiertosEnMdi;
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeNumeroMaximoFormulariosAbiertos()
        {
            return (this.NumeroMaximoFormulariosAbiertos != Configuración.DefectoNumeroMaximoFormulariosAbiertosEnMdi);
        }
        #endregion
    }
}