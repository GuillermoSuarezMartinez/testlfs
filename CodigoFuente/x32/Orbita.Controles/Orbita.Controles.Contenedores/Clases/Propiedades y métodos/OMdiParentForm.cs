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
    public class OMdiParentForm
    {
        #region Atributos
        OrbitaMdiParentForm control;
        int numeroMaximoFormulariosAbiertos;
        #endregion

        #region Constructor
        public OMdiParentForm(object control)
            : base()
        {
            this.control = (OrbitaMdiParentForm)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaMdiParentForm Control
        {
            get { return this.control; }
        }
        [System.ComponentModel.Description("")]
        public int NumeroMaximoFormulariosAbiertos
        {
            get { return this.numeroMaximoFormulariosAbiertos; }
            set { this.numeroMaximoFormulariosAbiertos = value; }
        }
        #endregion

        #region Métodos públicos
        public override string ToString()
        {
            return null;
        }
        public void MostrarFormulario(OrbitaForm form)
        {
            if (this.control.MdiChildren.Length < this.numeroMaximoFormulariosAbiertos)
            {
                if (form == null)
                {
                    return;
                }
                form.MdiParent = this.control;
                form.Show();
            }
            else
            {
                throw new System.Exception("Se ha alcanzado el número máximo de formularios abiertos.");
            }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetNumeroMaximoFormulariosAbiertos()
        {
            this.NumeroMaximoFormulariosAbiertos = Configuracion.DefectoNumeroMaximoFormulariosAbiertos;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeNumeroMaximoFormulariosAbiertos()
        {
            return (this.NumeroMaximoFormulariosAbiertos != Configuracion.DefectoNumeroMaximoFormulariosAbiertos);
        }
        #endregion
    }
}