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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
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
        Thread hilo;
        /// <summary>
        /// Cliente remoting.
        /// </summary>
        IRemotingLogger cliente;
        /// <summary>
        /// Colección de items.
        /// </summary>
        List<ItemLog> lista;
        /// <summary>
        /// Alias del canal de conexión.
        /// </summary>
        string alias;
        /// <summary>
        /// Máquina del canal de conexión.
        /// </summary>
        string maquina;
        /// <summary>
        /// Puerto del canal de conexión.
        /// </summary>
        int puerto;
        #endregion

        #region Delegados públicos
        /// <summary>
        /// Evento que se ejecuta tras escribir logger vía remoting.
        /// </summary>
        event EventHandler OnDespuesEscribirRemotingLogger;
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
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
        public RemotingLogger(string identificador)
            : this(identificador, NivelLog.Debug) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>Alias=logger</c>, <c>Puerto=1440</c>, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
        public RemotingLogger(string identificador, NivelLog nivelLog)
            : this(identificador, nivelLog, Orbita.Trazabilidad.Logger.Alias) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>Alias=logger</c>, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="puerto">Puerto del URI de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
        public RemotingLogger(string identificador, int puerto)
            : this(identificador, NivelLog.Debug, puerto) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>Alias=logger</c>, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        /// <param name="puerto">Puerto del URI de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
        public RemotingLogger(string identificador, NivelLog nivelLog, int puerto)
            : this(identificador, nivelLog, Orbita.Trazabilidad.Logger.Alias, puerto) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>Alias=logger</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="puerto">Puerto del URI de conexión .NET remoting.</param>
        /// <param name="maquina">Host de la máquina cliente de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
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
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
        public RemotingLogger(string identificador, NivelLog nivelLog, int puerto, string maquina)
            : this(identificador, nivelLog, Orbita.Trazabilidad.Logger.Alias, puerto, maquina) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>Puerto=1440</c>, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="alias">Alias del URI de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
        public RemotingLogger(string identificador, string alias)
            : this(identificador, NivelLog.Debug, alias) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>Puerto=1440</c>, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        /// <param name="alias">Alias del URI de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
        public RemotingLogger(string identificador, NivelLog nivelLog, string alias)
            : this(identificador, nivelLog, alias, Orbita.Trazabilidad.Logger.Puerto) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>Máquina=localhost</c>.
        /// </summary>
        /// <param name="identificador">Identificador del logger.</param>
        /// <param name="alias">Alias del URI de conexión .NET remoting.</param>
        /// <param name="puerto">Puerto del URI de conexión .NET remoting.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
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
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
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
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
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
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
        public RemotingLogger(string identificador, NivelLog nivelLog, string alias, int puerto, string maquina)
            : base(identificador, nivelLog)
        {
            this.SetTcpClientChannel(alias, puerto, maquina);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Alias del canal de conexión.
        /// </summary>
        public string Alias
        {
            get { return this.alias; }
            set { this.alias = value; }
        }
        /// <summary>
        /// Máquina del canal de conexión.
        /// </summary>
        public string Maquina
        {
            get { return this.maquina; }
            set { this.maquina = value; }
        }
        /// <summary>
        /// Puerto del canal de conexión.
        /// </summary>
        public int Puerto
        {
            get { return this.puerto; }
            set { this.puerto = value; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Asignar el canal de conexión con los servicios de canal.
        /// </summary>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
        public void SetTcpClientChannel()
        {
            if (string.IsNullOrEmpty(this.alias))
            {
                this.alias = Orbita.Trazabilidad.Logger.Alias;
            }
            if (string.IsNullOrEmpty(this.maquina))
            {
                this.maquina = Dns.GetHostName();
            }
            if (this.puerto == 0)
            {
                this.puerto = Orbita.Trazabilidad.Logger.Puerto;
            }
            this.SetTcpClientChannel(this.alias, this.puerto, this.maquina);
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
                this.lista.Add(item);
                // Activar la sincronización mediante un monitor.
                Monitor.Pulse(this);
                // En C# debemos comprobar que el evento no sea null.
                if (this.OnDespuesEscribirRemotingLogger != null)
                {
                    RemotingEventArgs e = new RemotingEventArgs(item);
                    // El evento se lanza como cualquier delegado.
                    this.OnDespuesEscribirRemotingLogger(this, e);
                }
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
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
        void SetTcpClientChannel(string alias, int puerto, string maquina)
        {
            // Crear la cadena URL de conexión.
            string url = string.Format(CultureInfo.CurrentCulture, @"tcp://{0}:{1}/{2}", maquina, puerto, alias);
            IChannel canal = ChannelServices.GetChannel(alias);
            if (canal == null)
            {
                // Registrar el canal de conexión con los servicios de canal.
                ChannelServices.RegisterChannel(new TcpClientChannel(alias, null), false);
                // Crea un proxy para el objeto conocido indicado por el tipo y dirección URL especificados.
                this.cliente = (IRemotingLogger)Activator.GetObject(typeof(IRemotingLogger), url);
                // Crear la colección de items.
                this.lista = new List<ItemLog>();
                // Inicializar e iniciar el hilo de proceso de copias backup.
                this.hilo = new Thread(new ThreadStart(Procesar));
                this.hilo.IsBackground = true;
                this.hilo.Start();
            }
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
                    while (this.lista.Count == 0)
                    {
                        Monitor.Wait(this);
                    }
                    mensajes = this.lista.ToArray();
                    this.lista.Clear();
                }
                this.cliente.Log(mensajes);
            }
        }
        #endregion
    }
}