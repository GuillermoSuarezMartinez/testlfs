//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

using System;
using System.IO;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Listener
{
    /// <summary>
    /// Esta clase proporciona la funcionalidad básica para todas las clases de escucha (listener) de comunicaciones.
    /// </summary>
    internal abstract class ListenerBase : IListener
    {
        #region Eventos públicos
        /// <summary>
        /// Este evento se produce cuando se establece la escucha de conexiones entrantes con éxito.
        /// </summary>
        public event EventHandler<EventArgs> Escuchando;
        /// <summary>
        /// Este evento se produce cuando se cierra el agente de escucha de conexiones entrantes con éxito.
        /// </summary>
        public event EventHandler<EventArgs> NoEscuchando;
        public event EventHandler<ErrorEventArgs> ErrorConexion;
        /// <summary>
        /// Este evento se produce cuando se conecta un nuevo canal de comunicación. Es decir,
        /// cuando un nuevo cliente acepta una comunicación de escucha.
        /// </summary>
        public event EventHandler<CanalComunicacionEventArgs> CanalComunicacionConectado;
        #endregion

        #region Propiedades
        /// <summary>
        /// Flag que permite establecer la reconexión de escuchas si se produce una excepción en el proceso de escucha.
        /// </summary>
        public bool ReConexion { get; set; }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Iniciar la escucha de peticiones de conexiones entrantes de clientes.
        /// </summary>
        public abstract void Iniciar();
        /// <summary>
        /// Terminar la escucha de peticiones de conexiones entrantes de clientes.
        /// </summary>
        public abstract void Terminar();
        #endregion

        #region Métodos protegidos de eventos elevados
        /// <summary>
        /// Elevar el evento Escuchando.
        /// </summary>
        protected virtual void OnEscuchando()
        {
            var handler = Escuchando;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Elevar el evento NoEscuchando.
        /// </summary>
        protected virtual void OnNoEscuchando()
        {
            var handler = NoEscuchando;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        protected virtual void OnErrorConexion(Exception ex)
        {
            var handler = ErrorConexion;
            if (handler != null)
            {
                handler(this, new ErrorEventArgs(ex));
            }
        }
        /// <summary>
        /// Elevar el evento CanalComunicacionConectado.
        /// </summary>
        /// <param name="cliente">Cliente.</param>
        protected virtual void OnCanalComunicacionConectado(ICanalComunicacion cliente)
        {
            var handler = CanalComunicacionConectado;
            if (handler != null)
            {
                handler(this, new CanalComunicacionEventArgs(cliente));
            }
        }
        #endregion
    }
}