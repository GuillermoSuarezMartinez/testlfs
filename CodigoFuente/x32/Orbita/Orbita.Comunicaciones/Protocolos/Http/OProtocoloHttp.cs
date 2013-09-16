//***********************************************************************
// Assembly         : OrbitaComunicaciones
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-22-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Clase para la comunicación HTTP
    /// </summary>
    public class OProtocoloHttp : Protocolo
    {
        #region Eventos
        /// <summary>
        /// Evento que se ejecuta tras realizar la solicitud al servicio Web.
        /// </summary>
        public event ManejadorEvento EnviarOHttpCompletado;
        #endregion Eventos

        #region Atributos
        /// <summary>
        /// Respuesta obtenida del servicio Web.
        /// </summary>
        private HttpWebResponse _respuesta;
        /// <summary>
        /// Cuerpo de la respuesta.
        /// </summary>
        private string _cuerpoRespuesta;
        /// <summary>
        /// Tiempo de respuesta.
        /// </summary>
        private double _tiempoRespuesta;
        /// <summary>
        /// Definición de los carácteres de escape.
        /// </summary>
        private string _caracteresEscapeBody;
        /// <summary>
        /// Código de respuesta necesario en la trama.
        /// </summary>
        private int _codigoEstado;
        /// <summary>
        /// Timeout de espera de 
        /// respuesta en segundos.
        /// </summary>
        private int _timeout;
        #endregion Atributos

        #region Destructor
        /// <summary>
        /// Método  sobrecargado de  Dispose que será  el que
        /// libera los recursos. Controla que solo se ejecute
        /// dicha lógica una  vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name="disposing">Indica si llama al método Dispose.</param>
        public override void Dispose(bool disposing)
        {
            // Preguntar si Dispose ya fue llamado.
            if (this.Disposed) return;

            // Finalizar correctamente los recursos no manejados.
            this._respuesta = null;
            this._cuerpoRespuesta = null;
            this._caracteresEscapeBody = null;

            // Marcar como desechada ó desechandose,
            // de forma que no se puede ejecutar el
            // código dos veces.
            Disposed = true;
        }
        #endregion Destructor

        #region Propiedades
        /// <summary>
        /// Cuerpo de la respuesta.
        /// </summary>
        public string CuerpoRespuesta
        {
            get { return this._cuerpoRespuesta; }
        }
        /// <summary>
        /// Tiempo de respuesta.
        /// </summary>
        public double TiempoRespuesta
        {
            get { return this._tiempoRespuesta; }
        }
        /// <summary>
        /// Carácteres de escape HTML.
        /// </summary>
        public string CaracteresEscapeBody
        {
            get
            {
                this._caracteresEscapeBody = this._cuerpoRespuesta.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;").Replace("\"", "&quot;");
                return this._caracteresEscapeBody;
            }
        }
        /// <summary>
        /// Código de estado.
        /// </summary>
        public int CodigoEstado
        {
            get { return this._codigoEstado; }
        }
        /// <summary>
        /// Cabeceras.
        /// </summary>
        public string Cabeceras
        {
            get
            {
                string resultado = string.Empty;
                if (this._respuesta != null)
                {
                    string cabeceras = string.Empty;
                    for (int i = 0; i < this._respuesta.Headers.Count; ++i)
                    {
                        cabeceras += (string.Format(CultureInfo.CurrentCulture, "{0}: {1} ", this._respuesta.Headers.Keys[i], this._respuesta.Headers[i].Replace(";", "/")));
                    }
                    resultado = cabeceras;
                }
                return resultado;
            }
        }
        /// <summary>
        /// Línea de estado.
        /// </summary>
        public string LineaDEestado
        {
            get
            {
                string resultado = string.Empty;
                if (this._respuesta != null)
                {
                    resultado = string.Format(CultureInfo.CurrentCulture, "HTTP/{0} {1} {2}", this._respuesta.ProtocolVersion, (int)this._respuesta.StatusCode, this._respuesta.StatusDescription);
                }
                return resultado;
            }
        }
        /// <summary>
        /// Timeout.
        /// </summary>
        public int Timeout
        {
            get { return this._timeout; }
            set { this._timeout = value; }
        }
        #endregion Propiedades

        #region Métodos públicos
        /// <summary>
        /// Método de solicitud de datos al servicio Web.
        /// </summary>
        /// <param name="uri"></param>
        public void Solicitud(Uri uri)
        {
            // Contador de tiempo de respuesta.
            Stopwatch tiempoDeRespuesta = new Stopwatch();

            // Declarar la respuesta.
            StringBuilder cuerpoRespuesta = new StringBuilder();

            // Crear la solicitud de respuesta al servicio Web.
            HttpWebRequest solicitud = (HttpWebRequest)WebRequest.Create(uri);

            // Establecer el tiempo máximo de espera de respuesta en milisegundos.
            solicitud.Timeout = this._timeout * 1000;

            // Activar el evento que permite tracear, informando
            // del envio de la solicitud al servicio Web.
            if (EnviarOHttpCompletado != null)
            {
                EnviarOHttpCompletado(this, null);
            }

            try
            {
                // Resetear el contador de respuesta.
                tiempoDeRespuesta.Reset();
                // Inicio del contador de respuesta.
                tiempoDeRespuesta.Start();

                // Retorna la respuesta obtenida del servicio Web.
                this._respuesta = (HttpWebResponse)solicitud.GetResponse();

                // Fin del contador de respuesta.
                tiempoDeRespuesta.Stop();

                // Componer la respuesta Stream en un StringBuilder.
                Byte[] buf = new Byte[8192];
                using (Stream recibeStream = this._respuesta.GetResponseStream())
                {
                    int contador = 0;
                    do
                    {
                        contador = recibeStream.Read(buf, 0, buf.Length);
                        if (contador != 0)
                        {
                            cuerpoRespuesta.Append(Encoding.ASCII.GetString(buf, 0, contador));
                        }
                    }
                    while (contador > 0);
                }

                this._codigoEstado = (int)(HttpStatusCode)this._respuesta.StatusCode;
                this._cuerpoRespuesta = cuerpoRespuesta.ToString();
                this._tiempoRespuesta = (tiempoDeRespuesta.ElapsedMilliseconds / 1000.0);
            }
            catch (WebException ex)
            {
                this._codigoEstado = 404;
                this._respuesta = (HttpWebResponse)ex.Response;
                this._cuerpoRespuesta = "EXCEPCION";
                this._tiempoRespuesta = Math.Abs(solicitud.Timeout / 1000.0);
            }
        }
        #endregion Métodos públicos
    }
}