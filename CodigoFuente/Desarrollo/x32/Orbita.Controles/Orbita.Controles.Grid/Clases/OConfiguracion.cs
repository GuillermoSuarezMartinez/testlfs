//***********************************************************************
// Assembly         : Orbita.Controles.Grid
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Grid
{
    public static class OConfiguracion
    {
        #region Atributos

        /// <summary>
        /// Establecer la persistencia entre el control y las aplicaciones externas.
        /// </summary>
        static OPersistencia Persistencia { get; set; }

        #endregion

        #region Propiedades

        /// <summary>
        /// Establecer la persistencia entre el control y las aplicaciones externas.
        /// </summary>
        public static OPersistencia OrbPersistencia
        {
            get { return OConfiguracion.Persistencia; }
            set { OConfiguracion.Persistencia = value; }
        }
        #endregion
    }
}