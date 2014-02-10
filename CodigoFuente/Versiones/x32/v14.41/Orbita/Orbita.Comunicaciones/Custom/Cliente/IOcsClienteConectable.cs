//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;
using System.IO;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Esta clase proporciona la funcionalidad básica para el cliente conectado al listener.
    /// </summary>
    public interface IOcsClienteConectable
    {
        /// <summary>
        /// Este evento se produce cuando se produce en algunos de los eventos de solicitud.
        /// </summary>
        event EventHandler<ErrorEventArgs> Error;
        /// <summary>
        /// Iniciar los mensajeros.
        /// </summary>
        void Iniciar();
        /// <summary>
        /// Terminar los mensajeros.
        /// </summary>
        void Terminar();
    }
}