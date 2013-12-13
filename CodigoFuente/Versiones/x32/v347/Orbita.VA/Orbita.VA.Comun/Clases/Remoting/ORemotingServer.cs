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
using System.Runtime.Remoting.Channels;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Remoting;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase servidora de remoting
    /// </summary>
    public class ORemotingServer<T>
        where T: ORemotingObject, new()
    {
        #region Atributo(s)
        /// <summary>
        /// Canal de Servidor de remoting
        /// </summary>
        protected TcpChannel CanalServidor; //channel to communicate
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
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ORemotingServer()
        {
            this._Iniciado = false;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ORemotingServer(string nombreCanal, int puerto)
        {
            this._NombreCanal = nombreCanal;
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
                        // Registro del canal de servidor
                        BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
                        BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
                        serverProvider.TypeFilterLevel = TypeFilterLevel.Full;
                        IDictionary props = new Hashtable();
                        props["port"] = this._Puerto;
                        props["typeFilterLevel"] = TypeFilterLevel.Full;
                        props["name"] = this._NombreCanal;
                        CanalServidor = new TcpChannel(props, clientProvider, serverProvider); //channel to communicate
                        ChannelServices.RegisterChannel(CanalServidor, false);  //register channel
                    }

                    if (!ORemotingUtils.ServicioTipoRegistardo(typeof(T)))
                    {
                        string nombreClase = typeof(T).Name;
                        RemotingConfiguration.RegisterWellKnownServiceType(typeof(T), nombreClase, WellKnownObjectMode.Singleton); //register remote object
                        this._Iniciado = true;
                        resultado = true;
                    }
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
                ChannelServices.UnregisterChannel(CanalServidor);
            }
        }
        #endregion
    }
}
