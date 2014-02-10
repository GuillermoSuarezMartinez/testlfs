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
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Repositorio de utilidades de remoting
    /// </summary>
    public static class ORemotingUtils
    {
        #region Método(s) público(s)
        /// <summary>
        /// Indica que el canal ya está registrado
        /// </summary>
        /// <param name="nombreCanal"></param>
        /// <returns></returns>
        public static bool CanalRegistrado(string nombreCanal)
        {
            bool resultado = false;
            foreach (IChannel canal in ChannelServices.RegisteredChannels)
            {
                if (canal.ChannelName == nombreCanal)
                {
                    resultado = true;
                    break;
                }
            }
            return resultado;
        }
        /// <summary>
        /// Indica que la publicaciónd el servicio del tipo ya existe
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public static bool ServicioTipoRegistardo(Type tipo)
        {
            WellKnownServiceTypeEntry[] serviciosRegistrados = RemotingConfiguration.GetRegisteredWellKnownServiceTypes();
            return serviciosRegistrados.Any(srv => srv.ObjectType == tipo);
        }
        #endregion
    }
}
