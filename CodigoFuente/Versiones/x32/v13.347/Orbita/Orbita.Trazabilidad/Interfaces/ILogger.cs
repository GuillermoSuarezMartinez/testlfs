//***********************************************************************
// Assembly         : Orbita.Trazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-21-2011
// Description      : 
//
// Last Modified By : aiba�ez
// Last Modified On : 28-03-2013
// Description      : A�adido evento de AntesEscribirLogger
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Trazabilidad
{
    /// <summary>
    /// ILogger.
    /// </summary>
    public interface ILogger
    {
        #region Propiedades privadas
        /// <summary>
        /// Identificador de logger.
        /// </summary>
        string Identificador { get; set; }
        /// <summary>
        /// Nivel de log.
        /// </summary>
        NivelLog NivelLog { get; }
        #endregion

        #region Eventos
        /// <summary>
        /// Evento que se ejecuta antes de escribir en el fichero de logger.
        /// </summary>
        event System.EventHandler<LoggerEventArgs> AntesEscribirLogger;
        /// <summary>
        /// Evento que se ejecuta tras escribir en el fichero de logger.
        /// </summary>
        event System.EventHandler<LoggerEventArgs> DespuesEscribirLogger;
        /// <summary>
        /// Evento que se ejecuta tras producirse un error en la escritura en el fichero de logger.
        /// </summary>
        event System.EventHandler<LoggerEventArgs> ErrorLogger;
        #endregion Eventos

        #region M�todos privados

        #region Debug
        /// <summary>
        /// Registra un objeto arbitrario con el <see cref="NivelLog.Debug"/>. 
        /// </summary>
        /// <param name="objeto">El objeto mensaje a registrar, el cual ser� convertido en un string durante el registro.</param>
        void Debug(object objeto);
        /// <summary>
        /// Registra un mensaje de depuraci�n (<see cref="NivelLog.Debug"/>).
        /// </summary>
        /// <param name="mensaje">El mensaje a registrar.</param>
        void Debug(string mensaje);
        /// <summary>
        /// Registra un mensaje formateado en string con el nivel <see cref="NivelLog.Debug"/>. 
        /// </summary>
        /// <param name="mensaje">Una cadena con mensaje que contiene marcadores de posici�n.</param>
        /// <param name="args">Un <see cref="object"/> array que contiene cero o mas objetos.</param>
        void Debug(string mensaje, params object[] args);
        /// <summary>
        /// Registra una excepci�n con el <see cref="NivelLog.Debug"/>.
        /// </summary>
        /// <param name="excepcion">La excepci�n a registrar.</param>
        void Debug(System.Exception excepcion);
        /// <summary>
        /// Registra una excepci�n y un mensaje adicional con el <see cref="NivelLog.Debug"/>.
        /// </summary>
        /// <param name="excepcion"> La excepci�n a registrar.</param>
        /// <param name="mensaje">Informaci�n adicional con respecto a la excepci�n a registrar.</param>
        void Debug(System.Exception excepcion, string mensaje);
        /// <summary>
        /// Registra un mensaje formateado en string con el nivel <see cref="NivelLog.Debug"/>. 
        /// </summary>
        /// <param name="excepcion">La excepci�n a registrar. </param>
        /// <param name="mensaje">Una cadena con mensaje que contiene marcadores de posici�n.</param>
        /// <param name="args">Un <see cref="object"/> array que contiene cero o mas objetos.</param>
        void Debug(System.Exception excepcion, string mensaje, params object[] args);
        #endregion Debug

        #region Info
        /// <summary>
        /// Registra un objeto arbitrario con el <see cref="NivelLog.Info"/>. 
        /// </summary>
        /// <param name="objeto">El objeto mensaje a registrar, el cual ser� convertido en un string durante el registro.</param>
        void Info(object objeto);
        /// <summary>
        /// Registra un mensaje de informaci�n (<see cref="NivelLog.Info"/>).
        /// </summary>
        /// <param name="mensaje">El mensaje a registrar.</param>
        void Info(string mensaje);
        /// <summary>
        /// Registra un mensaje formateado en string con el nivel <see cref="NivelLog.Info"/>. 
        /// </summary>
        /// <param name="mensaje">Una cadena con mensaje que contiene marcadores de posici�n.</param>
        /// <param name="args">Un <see cref="object"/> array que contiene cero o mas objetos.</param>
        void Info(string mensaje, params object[] args);
        /// <summary>
        /// Registra una excepci�n con el <see cref="NivelLog.Info"/>.
        /// </summary>
        /// <param name="excepcion">La excepci�n a registrar.</param>
        void Info(System.Exception excepcion);
        /// <summary>
        /// Registra una excepci�n y un mensaje adicional con el <see cref="NivelLog.Info"/>.
        /// </summary>
        /// <param name="excepcion"> La excepci�n a registrar.</param>
        /// <param name="mensaje">Informaci�n adicional con respecto a la excepci�n a registrar.</param>
        void Info(System.Exception excepcion, string mensaje);
        /// <summary>
        /// Registra un mensaje formateado en string con el nivel <see cref="NivelLog.Info"/>. 
        /// </summary>
        /// <param name="excepcion">La excepci�n a registrar.</param>
        /// <param name="mensaje">Una cadena con mensaje que contiene marcadores de posici�n.</param>
        /// <param name="args">Un <see cref="object"/> array que contiene cero o mas objetos.</param>
        void Info(System.Exception excepcion, string mensaje, params object[] args);
        #endregion Info

        #region Warn
        /// <summary>
        /// Registra un objeto arbitrario con el <see cref="NivelLog.Warn"/>. 
        /// </summary>
        /// <param name="objeto">El objeto mensaje a registrar, el cual ser� convertido en un string durante el registro.</param>
        void Warn(object objeto);
        /// <summary>
        /// Registra un mensaje Warn (<see cref="NivelLog.Warn"/>).
        /// </summary>
        /// <param name="mensaje">El mensaje a registrar.</param>
        void Warn(string mensaje);
        /// <summary>
        /// Registra un mensaje formateado en string con el nivel <see cref="NivelLog.Warn"/>. 
        /// </summary>
        /// <param name="mensaje">Una cadena con mensaje que contiene marcadores de posici�n.</param>
        /// <param name="args">Un <see cref="object"/> array que contiene cero o mas objetos.</param>
        void Warn(string mensaje, params object[] args);
        /// <summary>
        /// Registra una excepci�n con el <see cref="NivelLog.Warn"/>.
        /// </summary>
        /// <param name="excepcion">La excepci�n a registrar.</param>
        void Warn(System.Exception excepcion);
        /// <summary>
        /// Registra una excepci�n y un mensaje adicional con el <see cref="NivelLog.Warn"/>.
        /// </summary>
        /// <param name="excepcion"> La excepci�n a registrar.</param>
        /// <param name="mensaje">Informaci�n adicional con respecto a la excepci�n a registrar.</param>
        void Warn(System.Exception excepcion, string mensaje);
        /// <summary>
        /// Registra un mensaje formateado en string con el nivel <see cref="NivelLog.Warn"/>. 
        /// </summary>
        /// <param name="excepcion">La excepci�n a registrar. </param>
        /// <param name="mensaje">Una cadena con mensaje que contiene marcadores de posici�n.</param>
        /// <param name="args">Un <see cref="object"/> array que contiene cero o mas objetos.</param>
        void Warn(System.Exception excepcion, string mensaje, params object[] args);
        #endregion Warn

        #region Error
        /// <summary>
        /// Registra un objeto arbitrario con el <see cref="NivelLog.Error"/>. 
        /// </summary>
        /// <param name="objeto">El objeto mensaje a registrar, el cual ser� convertido en un string durante el registro.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords",
         Justification = "Error necesario para identificar este nivel de log.")]
        void Error(object objeto);
        /// <summary>
        /// Registra un mensaje de error (<see cref="NivelLog.Error"/>).
        /// </summary>
        /// <param name="mensaje">El mensaje a registrar.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords",
         Justification = "Error necesario para identificar este nivel de log.")]
        void Error(string mensaje);
        /// <summary>
        /// Registra un mensaje formateado en string con el nivel <see cref="NivelLog.Error"/>. 
        /// </summary>
        /// <param name="mensaje">Una cadena con mensaje que contiene marcadores de posici�n.</param>
        /// <param name="args">Un <see cref="object"/> array que contiene cero o mas objetos.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords",
         Justification = "Error necesario para identificar este nivel de log.")]
        void Error(string mensaje, params object[] args);
        /// <summary>
        /// Registra una excepci�n con el <see cref="NivelLog.Error"/>.
        /// </summary>
        /// <param name="excepcion">La excepci�n a registrar.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords",
         Justification = "Error necesario para identificar este nivel de log.")]
        void Error(System.Exception excepcion);
        /// <summary>
        /// Registra una excepci�n y un mensaje adicional con el <see cref="NivelLog.Error"/>.
        /// </summary>
        /// <param name="excepcion"> La excepci�n a registrar.</param>
        /// <param name="mensaje">Informaci�n adicional con respecto a la excepci�n a registrar.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords",
         Justification = "Error necesario para identificar este nivel de log.")]
        void Error(System.Exception excepcion, string mensaje);
        /// <summary>
        /// Registra un mensaje formateado en string con el nivel <see cref="NivelLog.Error"/>. 
        /// </summary>
        /// <param name="excepcion">La excepci�n a registrar.</param>
        /// <param name="mensaje">Una cadena con mensaje que contiene marcadores de posici�n.</param>
        /// <param name="args">Un <see cref="object"/> array que contiene cero o mas objetos.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords",
         Justification = "Error necesario para identificar este nivel de log.")]
        void Error(System.Exception excepcion, string mensaje, params object[] args);
        #endregion Error

        #region Fatal
        /// <summary>
        /// Registra un objeto arbitrario con el <see cref="NivelLog.Fatal"/>. 
        /// </summary>
        /// <param name="objeto">El objeto mensaje a registrar, el cual ser� convertido en un string durante el registro.</param>
        void Fatal(object objeto);
        /// <summary>
        /// Registra un mensaje de error fatal (<see cref="NivelLog.Fatal"/>).
        /// </summary>
        /// <param name="mensaje">El mensaje a registrar.</param>
        void Fatal(string mensaje);
        /// <summary>
        /// Registra un mensaje formateado en string con el nivel <see cref="NivelLog.Fatal"/>. 
        /// </summary>
        /// <param name="mensaje">Una cadena con mensaje que contiene marcadores de posici�n.</param>
        /// <param name="args">Un <see cref="object"/> array que contiene cero o mas objetos.</param>
        void Fatal(string mensaje, params object[] args);
        /// <summary>
        /// Registra una excepci�n con el <see cref="NivelLog.Fatal"/>.
        /// </summary>
        /// <param name="excepcion">La excepci�n a registrar.</param>
        void Fatal(System.Exception excepcion);
        /// <summary>
        /// Registra una excepci�n y un mensaje adicional con el <see cref="NivelLog.Fatal"/>.
        /// </summary>
        /// <param name="excepcion"> La excepci�n a registrar.</param>
        /// <param name="mensaje">Informaci�n adicional con respecto a la excepci�n a registrar.</param>
        void Fatal(System.Exception excepcion, string mensaje);
        /// <summary>
        /// Registra un mensaje formateado en string con el nivel <see cref="NivelLog.Fatal"/>. 
        /// </summary>
        /// <param name="excepcion">La excepci�n a registrar.</param>
        /// <param name="mensaje">Una cadena con mensaje que contiene marcadores de posici�n.</param>
        /// <param name="args">Un <see cref="object"/> array que contiene cero o mas objetos.</param>
        void Fatal(System.Exception excepcion, string mensaje, params object[] args);
        #endregion Fatal

        #region Log
        /// <summary>
        /// Crea una nueva entrada de registro basada en un elemento item.
        /// </summary>
        /// <param name="item">Encapsula informaci�n de registro.</param>
        void Log(ItemLog item);
        /// <summary>
        /// Crea una nueva entrada de registro basada en un elemento item.
        /// </summary>
        /// <param name="item">Encapsula informaci�n de registro.</param>
        /// <param name="args">Argumentos adicionales.</param>
        void Log(ItemLog item, object[] args);
        #endregion Log

        #endregion M�todos privados
    }
}