//***********************************************************************
// Assembly         : Orbita.Trazabilidad
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
    ///<summary>
    /// Define los niveles disponibles de registro.
    /// Los niveles de registro pueden ser  utilizados para organizar y filtrar la salida de registro.
    ///</summary>
    public enum NivelLog
    {
        /// <summary>
        /// Registra informaci�n de depuraci�n. No suele utilizarse para los casos de producci�n.
        /// </summary>
        Debug = 0,
        /// <summary>
        /// Registra informaci�n b�sica a nivel de producci�n.
        /// </summary>
        Info = 1,
        /// <summary>
        /// Registra Warns. Ocurre algo que parece extra�o
        /// y la aplicaci�n no puede hacer frente correctamente.
        /// </summary>
        Warn = 2,
        /// <summary>
        /// Registra errores recuperables.
        /// </summary>
        Error = 3,
        /// <summary>
        /// Registra errores fatales. La aplicaci�n se ha estropeado y no puede continuar.
        /// </summary>
        Fatal = 4
    }
}