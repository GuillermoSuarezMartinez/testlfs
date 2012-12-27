//***********************************************************************
// Assembly         : OrbitaTrazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-21-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Trazabilidad
{
    internal class FactoryHelper
    {
        #region Atributos privados estáticos
        /// <summary>
        /// Sin parámetros.
        /// </summary>
        static object[] EmptyParams = new object[0];
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.FactoryHelper.
        /// </summary>
        FactoryHelper() { }
        #endregion

        #region Métodos públicos estáticos
        public static object CreateInstance(System.Type tipo)
        {
            System.Reflection.ConstructorInfo constructor = tipo.GetConstructor(System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance, null, System.Type.EmptyTypes, null);
            if (constructor != null)
            {
                return constructor.Invoke(EmptyParams);
            }
            return constructor;
        }
        #endregion
    }
}
