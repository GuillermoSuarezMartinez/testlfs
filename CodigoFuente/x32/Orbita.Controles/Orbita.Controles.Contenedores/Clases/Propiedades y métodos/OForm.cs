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
    public class OForm
    {
        #region Atributos
        OrbitaForm control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.OForm.
        /// </summary>
        /// <param name="control"></param>
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
        #endregion

        #region Métodos públicos
        public override string ToString()
        {
            return null;
        }
        public void MostrarFormulario(OrbitaForm form)
        {
            if (form == null)
            {
                return;
            }
            form.Show();
        }
        #endregion
    }
}