using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.Comunicaciones;
using Orbita.Trazabilidad;
using System.Collections;
using Orbita.Winsock;

namespace Orbita.MS
{

    /// <summary>
    /// Listener de servidor
    /// </summary>
    public class OListenerServidor : OTCPListener
    {
        #region Atributos
        /// <summary>
        /// Aplicación: licencimiento y opciones
        /// </summary>
        public OAplicacion _aplicacion =  null;
        /// <summary>
        /// Datos del proceso residente.
        /// </summary>
        public OProcesoAplicacion _proceso = null;
        /// <summary>
        /// Estado de comunicación.
        /// </summary>
        public OEstadoComunicacionCliente _estadoComunicacion = OEstadoComunicacionCliente.Desconectado;


        public DateTime _ultimaVerificacionLicencia = DateTime.MinValue;

        #endregion Atributos
        #region Constructor

        public OListenerServidor(ILogger logger, int puerto, string nombreInstancia):base(logger, puerto, nombreInstancia)    
        {
        
            
        }
        #endregion Constructor
        #region Métodos privados
        
        /// <summary>
        /// Obtiene el canal cliente de la conexión
        /// </summary>
        /// <param name="pool">Colección de canales</param>
        /// <returns></returns>
        private OWinSockCliente GetCliente(Hashtable pool, string ip = "127.0.0.1", string puerto = "")
        {
            OWinSockCliente winsock = null;
            if (!String.IsNullOrEmpty(ip))
            {
                //TODO: Modificar Pool para poder generar ip + puerto como Key
                if (pool.ContainsKey(ip + puerto))
                {
                    foreach (DictionaryEntry item in pool)
                    {
                        if (item.Key.ToString() == ip)
                        {
                            winsock = (OWinSockCliente)item.Value;
                        }
                    }
                }
            }
            else
            {
                //Seleccionamos la primera conexión activa disponible.
                foreach (DictionaryEntry item in pool)
                {
                    return (OWinSockCliente)item.Value;
                }
            }
            return winsock;
        }
        #endregion Métodos privados
        #region Métodos públicos
        

        /// <summary>
        /// Permite enviar una cadena de texto
        /// </summary>
        /// <param name="mensaje"></param>
        public void EnviarMensaje(string mensaje = "Mensaje de prueba")
        {
            byte[] mbase = OMensajeXML.StringAByteArray(mensaje);
            OWinSockCliente cliente = GetCliente(this.PoolCliente);
            cliente.Enviar(mbase);
        }
        #endregion Métodos públicos
    }
}
