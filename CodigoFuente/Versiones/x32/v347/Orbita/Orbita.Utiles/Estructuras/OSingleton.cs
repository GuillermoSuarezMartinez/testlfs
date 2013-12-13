//***********************************************************************
// Assembly         : Orbita.Utiles
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//                    
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.Utiles
{
    /// <summary>
    /// Clase que implementa la estructura tipo patrón singelton
    /// </summary>
    public abstract class OSingleton<T>
        where T: new()
    {
        #region Propiedad(es)
        /// <summary>
        /// Instancia única del objeto
        /// </summary>
        private static T _Instancia = Constructor();
        /// <summary>
        /// Instancia única del objeto
        /// </summary>
        public static T Instancia
        {
            get { return _Instancia; }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        protected OSingleton()
        {
        }
        #endregion

        #region Método(s) privado(s) estático(s)
        /// <summary>
        /// Constructror de los logs
        /// </summary>
        /// <returns></returns>
        private static T Constructor()
        {
            return new T();
        }
        #endregion
    }
}
