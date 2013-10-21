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
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;
namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Remoting Logger.
    /// </summary>
    [Target("Remoting")]
    public class RemotingLogger : BaseLogger
    {
        #region Atributos privados
        /// <summary>
        /// Crea y controla un subproceso, establece su prioridad y obtiene su estado.
        /// </summary>
        private System.Threading.Thread _hilo;
        /// <summary>
        /// Cliente remoting.
        /// </summary>
        private IRemotingLogger _cliente;
        /// <summary>
        /// Colección de items.
        /// </summary>
        private List<ItemLog> _lista;
        #endregion

        #region Delegados públicos
        /// <summary>
        /// Evento que se ejecuta tras escribir logger vía remoting.
        /// </summary>
        event System.EventHandler OnDespuesEscribirRemotingLogger;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// </summary>
        public RemotingLogger() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>Alias=logger</c>, <c>Puerto=1440</c>, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public RemotingLogger(string identificador)
            : this(identificador, NivelLog.Debug) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>Alias=logger</c>, <c>Puerto=1440</c>, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public RemotingLogger(string identificador, NivelLog nivelLog)
            : this(identificador, nivelLog, Logger.Alias) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>Alias=logger</c>, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="puerto">Puerto del URI de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public RemotingLogger(string identificador, int puerto)
            : this(identificador, NivelLog.Debug, puerto) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>Alias=logger</c>, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        /// <param name="puerto">Puerto del URI de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public RemotingLogger(string identificador, NivelLog nivelLog, int puerto)
            : this(identificador, nivelLog, Logger.Alias, puerto) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>Alias=logger</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="puerto">Puerto del URI de conexión .NET remoting.</param>
        /// <param name="maquina">Host de la máquina cliente de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public RemotingLogger(string identificador, int puerto, string maquina)
            : this(identificador, NivelLog.Debug, puerto, maquina) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>Alias=logger</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        /// <param name="puerto">Puerto del URI de conexión .NET remoting.</param>
        /// <param name="maquina">Host de la máquina cliente de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public RemotingLogger(string identificador, NivelLog nivelLog, int puerto, string maquina)
            : this(identificador, nivelLog, Logger.Alias, puerto, maquina) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>Puerto=1440</c>, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="alias">Alias del URI de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public RemotingLogger(string identificador, string alias)
            : this(identificador, NivelLog.Debug, alias) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>Puerto=1440</c>, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        /// <param name="alias">Alias del URI de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public RemotingLogger(string identificador, NivelLog nivelLog, string alias)
            : this(identificador, nivelLog, alias, Logger.Puerto) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="alias">Alias del URI de conexión .NET remoting.</param>
        /// <param name="puerto">Puerto del URI de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public RemotingLogger(string identificador, string alias, int puerto)
            : this(identificador, NivelLog.Debug, alias, puerto) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        /// <param name="alias">Alias del URI de conexión .NET remoting.</param>
        /// <param name="puerto">Puerto del URI de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public RemotingLogger(string identificador, NivelLog nivelLog, string alias, int puerto)
            : this(identificador, nivelLog, alias, puerto, Dns.GetHostName()) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>NivelLog=Debug</c>. 
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="alias">Alias del URI de conexión .NET remoting.</param>
        /// <param name="puerto">Puerto del URI de conexión .NET remoting.</param>
        /// <param name="maquina">Host de la máquina cliente de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public RemotingLogger(string identificador, string alias, int puerto, string maquina)
            : this(identificador, NivelLog.Debug, alias, puerto, maquina) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        /// <param name="alias">Alias del URI de conexión .NET remoting.</param>
        /// <param name="puerto">Puerto del URI de conexión .NET remoting.</param>
        /// <param name="maquina">Host de la máquina cliente de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public RemotingLogger(string identificador, NivelLog nivelLog, string alias, int puerto, string maquina)
            : base(identificador, nivelLog)
        {
            SetTcpClientChannel(alias, puerto, maquina);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Alias del canal de conexión.
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// Máquina del canal de conexión.
        /// </summary>
        public string Maquina { get; set; }
        /// <summary>
        /// Puerto del canal de conexión.
        /// </summary>
        public int Puerto { get; set; }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Asignar el canal de conexión con los servicios de canal.
        /// </summary>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public void SetTcpClientChannel()
        {
            if (string.IsNullOrEmpty(Alias))
            {
                Alias = Logger.Alias;
            }
            if (string.IsNullOrEmpty(Maquina))
            {
                Maquina = Dns.GetHostName();
            }
            if (Puerto == 0)
            {
                Puerto = Logger.Puerto;
            }
            SetTcpClientChannel(Alias, Puerto, Maquina);
        }
        /// <summary>
        /// Registra un elemento determinado.
        /// </summary>
        /// <param name="item">El elemento que va a ser registrado.</param>
        public override void Log(ItemLog item)
        {
            lock (this)
            {
                // Añadir el item a la colección.
                _lista.Add(item);
                // Activar la sincronización mediante un monitor.
                System.Threading.Monitor.Pulse(this);
                // En C# debemos comprobar que el evento no sea null.
                if (OnDespuesEscribirRemotingLogger == null) return;
                var e = new RemotingEventArgs(item);
                // El evento se lanza como cualquier delegado.
                OnDespuesEscribirRemotingLogger(this, e);
            }
        }
        /// <summary>
        /// Registra un elemento determinado con parámetros adicionales.
        /// </summary>
        /// <param name="item">El elemento que va a ser registrado.</param>
        /// <param name="args">Parámetros adicionales.</param>
        public override void Log(ItemLog item, object[] args)
        {
            Log(item);
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Asignar el canal de conexión con los servicios de canal.
        /// </summary>
        /// <param name="alias">Alias.</param>
        /// <param name="puerto">Puerto.</param>
        /// <param name="maquina">Máquina.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        void SetTcpClientChannel(string alias, int puerto, string maquina)
        {
            // Crear la cadena URL de conexión.
            string url = string.Format(CultureInfo.CurrentCulture, @"tcp://{0}:{1}/{2}", maquina, puerto, alias);
            IChannel canal = ChannelServices.GetChannel(alias);
            if (canal != null) return;
            // Registrar el canal de conexión con los servicios de canal.
            ChannelServices.RegisterChannel(new TcpClientChannel(alias, null), false);
            // Crea un proxy para el objeto conocido indicado por el tipo y dirección URL especificados.
            _cliente = (IRemotingLogger)System.Activator.GetObject(typeof(IRemotingLogger), url);
            // Crear la colección de items.
            _lista = new List<ItemLog>();
            // Inicializar e iniciar el hilo de proceso de copias backup.
            _hilo = new System.Threading.Thread(Procesar)
                {
                    IsBackground = true
                };
            _hilo.Start();
        }
        /// <summary>
        /// Añade a la colección de remoting el item (mensaje).
        /// </summary>
        void Procesar()
        {
            while (true)
            {
                ItemLog[] mensajes;
                lock (this)
                {
                    while (_lista.Count == 0)
                    {
                        System.Threading.Monitor.Wait(this);
                    }
                    mensajes = _lista.ToArray();
                    _lista.Clear();
                }
                _cliente.Log(mensajes);
            }
        }
        #endregion
    }
}