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
namespace Orbita.Controles.Shared
{
    [System.Serializable]
    public class OExcepcion : System.Exception
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Shared.OrbitaExcepcion.
        /// </summary>
        public OExcepcion()
            : base() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Shared.OrbitaExcepcion.
        /// </summary>
        /// <param name="mensaje">Mensaje.</param>
        public OExcepcion(string mensaje)
            : base(mensaje) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Shared.OrbitaExcepcion.
        /// </summary>
        /// <param name="mensaje">Mensaje.</param>
        /// <param name="inner">Inner exception.</param>
        public OExcepcion(string mensaje, System.Exception inner)
            : base(mensaje, inner) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Shared.OrbitaExcepcion.
        /// </summary>
        /// <param name="info">Informacion de serialización.</param>
        /// <param name="contexto">Contexto de serialización.</param>
        protected OExcepcion(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext contexto)
            : base(info, contexto) { }
        #endregion
    }
}