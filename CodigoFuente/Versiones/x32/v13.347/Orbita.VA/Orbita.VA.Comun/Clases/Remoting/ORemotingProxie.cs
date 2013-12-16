//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 18-04-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Collections;
using System.Runtime.Remoting;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase cliente de remoting
    /// </summary>
    public class ORemotingProxie<T>
        where T : new()
    {
        #region Atributo(s)
        /// <summary>
        /// Canal de Servidor de remoting
        /// </summary>
        protected TcpChannel CanalCliente; //channel to communicate
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Indica si el servicio está iniciado
        /// </summary>
        protected bool _Iniciado = false;
        /// <summary>
        /// Indica si el servicio está iniciado
        /// </summary>
        public bool Iniciado
        {
            get { return _Iniciado; }
        }

        /// <summary>
        /// Dirección IP de la cámara
        /// </summary>
        protected IPAddress _IP;
        /// <summary>
        /// Dirección IP de la cámara
        /// </summary>
        public IPAddress IP
        {
            get { return _IP; }
        }

        /// <summary>
        /// Puerto de comunicación remota
        /// </summary>
        protected int _Puerto;
        /// <summary>
        /// Puerto de comunicación remota
        /// </summary>
        public int Puerto
        {
            get { return _Puerto; }
        }

        /// <summary>
        /// Código de la clase
        /// </summary>
        protected string _NombreCanal;
        /// <summary>
        /// Código de la clase
        /// </summary>
        public string NombreCanal
        {
            get { return _NombreCanal; }
        }

        /// <summary>
        /// Instancia de la clase remota
        /// </summary>
        protected T _Instancia;
        /// <summary>
        /// Instancia de la clase remota
        /// </summary>
        public T Instancia
        {
            get { return _Instancia; }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ORemotingProxie()
        {
            this._Iniciado = false;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ORemotingProxie(string nombreCanal, IPAddress ip, int puerto)
        {
            this._NombreCanal = nombreCanal;
            this._IP = ip;
            this._Puerto = puerto;
            this._Iniciado = false;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Inicio del servicio
        /// </summary>
        /// <returns></returns>
        public bool Conectar()
        {
            bool resultado = false;

            try
            {
                if (!this._Iniciado)
                {
                    if (!ORemotingUtils.CanalRegistrado(this.NombreCanal))
                    {
                        // Registro del canal de cliente
                        BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
                        BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
                        serverProvider.TypeFilterLevel = TypeFilterLevel.Full;
                        IDictionary props = new Hashtable();
                        props["port"] = 0;
                        props["typeFilterLevel"] = TypeFilterLevel.Full;
                        props["name"] = this._NombreCanal;
                        this.CanalCliente  = new TcpChannel(props, clientProvider, serverProvider); //channel to communicate
                        ChannelServices.RegisterChannel(this.CanalCliente, false);  //register channel
                    }

                    string nombreClase = typeof(T).Name;
                    string direccion = string.Format(@"tcp://{0}:{1}/{2}", this.IP, this.Puerto, nombreClase); // Dirección remota
                    this._Instancia = (T)Activator.GetObject(typeof(T), direccion);

                    this._Iniciado = true;
                    resultado = true;
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.Remoting.Error(exception, "Conexión servidor remoto: " + this.NombreCanal);
            }

            return resultado;
        }

        /// <summary>
        /// Fin del servicio
        /// </summary>
        /// <returns></returns>
        public void Desconectar()
        {
            if (this._Iniciado && ORemotingUtils.CanalRegistrado(this.NombreCanal))
            {
                // Destrucción de los objetos
                ChannelServices.UnregisterChannel(this.CanalCliente);
            }
        }
        #endregion
    }
}
