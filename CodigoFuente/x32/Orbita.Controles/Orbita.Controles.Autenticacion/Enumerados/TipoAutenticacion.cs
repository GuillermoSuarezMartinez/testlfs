//***********************************************************************
// Assembly         : Orbita.Framework.Core
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Autenticacion
{
    /// <summary>
    /// Determina el tipo de autenticación.
    /// </summary>
    public enum TipoAutenticacion
    {
        /// <summary>
        /// Sin autenticación.
        /// </summary>
        Ninguna,
        /// <summary>
        /// Autenticación por base de datos.
        /// </summary>
        BBDD,
        /// <summary>
        /// Autenticación Active Directory.
        /// </summary>
        ActiveDirectory,
        /// <summary>
        /// Autenticación OpenLDAP.
        /// </summary>
        OpenLDAP
    }
}