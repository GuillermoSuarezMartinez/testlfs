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
        /// <summary>
        /// Número máximo de formularios abiertos.
        /// </summary>
        int numeroMaximoFormulariosAbiertos;
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
        [System.ComponentModel.Description("Número máximo de formularios abiertos del tipo actual.")]
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
        #endregion
    }
}