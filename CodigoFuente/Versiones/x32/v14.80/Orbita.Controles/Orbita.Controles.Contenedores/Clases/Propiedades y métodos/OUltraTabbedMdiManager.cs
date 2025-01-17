﻿//***********************************************************************
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
namespace Orbita.Controles.Contenedores
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OUltraTabbedMdiManager
    {
        #region Atributos
        OrbitaUltraTabbedMdiManager control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.OUltraTabbedMdiManager.
        /// </summary>
        /// <param name="control"></param>
        public OUltraTabbedMdiManager(object control)
            : base()
        {
            this.control = (OrbitaUltraTabbedMdiManager)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaUltraTabbedMdiManager Control
        {
            get { return this.control; }
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