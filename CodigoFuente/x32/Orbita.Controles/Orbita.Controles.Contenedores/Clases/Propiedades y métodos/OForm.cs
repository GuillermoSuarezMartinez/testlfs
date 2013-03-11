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
using System.ComponentModel;
using System;
namespace Orbita.Controles.Contenedores
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OForm
    {
        #region Atributos
        OrbitaForm control;
        int numeroMaximoFormulariosAbiertosEnMdi;
        #endregion

        #region Constructor
        public OForm(object control)
            : base()
        {
            this.control = (OrbitaForm)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaForm Control
        {
            get { return this.control; }
        }
        [System.ComponentModel.Description("")]
        public int NumeroMaximoFormulariosAbiertosEnMdi
        {
            get { return this.numeroMaximoFormulariosAbiertosEnMdi; }
            set { this.numeroMaximoFormulariosAbiertosEnMdi = value; }
        }
        #endregion

        #region Métodos públicos
        public override string ToString()
        {
            return null;
        }
        public void MostrarFormularioEnMdi(OrbitaForm form)
        {
            if (this.control.IsMdiContainer && this.control.MdiChildren.Length < this.numeroMaximoFormulariosAbiertosEnMdi)
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
                throw new Exception("Se ha alcanzado el número máximo de formularios abiertos.");
            }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetNumeroMaximoFormulariosAbiertosEnMdi()
        {
            this.NumeroMaximoFormulariosAbiertosEnMdi = Configuracion.DefectoNumeroMaximoFormulariosAbiertosEnMdi;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeNumeroMaximoFormulariosAbiertosEnMdi()
        {
            return (this.NumeroMaximoFormulariosAbiertosEnMdi != Configuracion.DefectoNumeroMaximoFormulariosAbiertosEnMdi);
        }
        #endregion
    }
}