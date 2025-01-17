﻿//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 13-12-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Comunicación con aplicaciones CGI
    /// </summary>
    public class OComunicacionCGI
    {
        #region Atritubo(s)
        private HttpWebRequest Request;
        //private WebResponse Response;
        private HttpWebResponse Response;
        public Stream Stream;
        private long ContReconexion;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Código identificativo de la conexión
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código identificativo de la conexión
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Url de la conexión CGI
        /// </summary>
        private string _Url;
        /// <summary>
        /// Url de la conexión CGI
        /// </summary>
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        /// <summary>
        /// Usuario de la conexión
        /// </summary>
        private string _Usuario;
        /// <summary>
        /// Usuario de la conexión
        /// </summary>
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        /// <summary>
        /// Contraseña de la conexión
        /// </summary>
        private string _Contraseña;
        /// <summary>
        /// Contraseña de la conexión
        /// </summary>
        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }

        /// <summary>
        /// Indica si se usa un grupo de conexión separado
        /// </summary>
        private bool _UsaGrupoConexionSeparado;
        /// <summary>
        /// Indica si se usa un grupo de conexión separado
        /// </summary>
        public bool UsaGrupoConexionSeparado
        {
            get { return _UsaGrupoConexionSeparado; }
            set { _UsaGrupoConexionSeparado = value; }
        }

        /// <summary>
        /// Tiempo máximo de la duración de la lectura del CGI
        /// </summary>
        private int _TimeOut;
        /// <summary>
        /// Tiempo máximo de la duración de la lectura del CGI
        /// </summary>
        public int TimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; }
        }

        /// <summary>
        /// Indica que se realizado la conexión con el CGI
        /// </summary>
        private bool _Conectado;
        /// <summary>
        /// Indica que se realizado la conexión con el CGI
        /// </summary>
        public bool Conectado
        {
            get { return _Conectado; }
            set { _Conectado = value; }
        }

        /// <summary>
        /// Extrae tidpo del contenido de la respuesta
        /// </summary>
        public TipoContenidoRespuestaCGI TipoContenido
        {
            get
            {
                TipoContenidoRespuestaCGI resultado = TipoContenidoRespuestaCGI.Desconocido;

                try
                {
                    if ((this.Conectado) && (this.Response != null))
                    {
                        if (this.Response.ContentType.IndexOf("text/plain") != -1)
                        {
                            resultado = TipoContenidoRespuestaCGI.TextPlain;
                        }
                        else if (this.Response.ContentType.IndexOf("image/jpeg") != -1)
                        {
                            resultado = TipoContenidoRespuestaCGI.ImageJpeg;
                        }
                        else if (this.Response.ContentType.IndexOf("multipart/x-mixed-replace") != -1)
                        {
                            resultado = TipoContenidoRespuestaCGI.MultipartXMixedReplace;
                        }
                    }
                }
                catch (Exception exception)
                {
                    resultado = TipoContenidoRespuestaCGI.Desconocido;
                    OLogsVAComun.Comun.Error(exception, "ExtraeTipoContenidoRespuestaComandoCGI");
                }

                return resultado;
            }
        }

        public byte[] Delimitador
        {
            get
            {
                byte[] resultado = new byte[0];

                try
                {
                    if ((this.Conectado) && (this.Response != null))
                    {
                        // get boundary
                        int indiceBoundary = this.Response.ContentType.IndexOf("boundary=", 0);
                        if (indiceBoundary != -1)
                        {
                            ASCIIEncoding encoding = new ASCIIEncoding();
                            resultado = encoding.GetBytes(this.Response.ContentType.Substring(indiceBoundary + 9));
                        }
                    }
                }
                catch (Exception exception)
                {
                    OLogsVAComun.Comun.Error(exception, "ExtraeLimiteRespuestaComandoCGI");
                }

                return resultado;
            }
        }

        /// <summary>
        /// Código de la respuesta esperada 
        /// </summary>
        private HttpStatusCode _CodigoRespuesta;
        /// <summary>
        /// Código de la respuesta esperada 
        /// </summary>
	    public HttpStatusCode CodigoRespuesta
	    {
		    get { return _CodigoRespuesta;}
            set { _CodigoRespuesta = value; }
	    }
        
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OComunicacionCGI()
        {
            this.Url = string.Empty;
            this.Usuario = string.Empty;
            this.Contraseña = string.Empty;
            this.Codigo = string.Empty;
            this.UsaGrupoConexionSeparado = false;
            this.TimeOut = 15000;
            this.ContReconexion = 0;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OComunicacionCGI(string url, string usuario, string contraseña, string codigo, bool usaGrupoConexionSeparado, int timeOut, HttpStatusCode codigoRespuesta)
        {
            this.Url = url;
            this.Usuario = usuario;
            this.Contraseña = contraseña;
            this.Codigo = codigo;
            this.UsaGrupoConexionSeparado = usaGrupoConexionSeparado;
            this.TimeOut = timeOut;
            this.ContReconexion = 0;
            this.CodigoRespuesta = codigoRespuesta;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Inicia la conexión con el CGI
        /// </summary>
        /// <returns>Verdadero si la conexión se ha establecido con éxito</returns>
        public bool Start(bool nuevoGrupoConexion = false)
        {
            bool resultado = false;

            this.Request = null;
            this.Response = null;
            this.Stream = null;

            try
            {
                // Creamos la consulta CGI
                this.Request = (HttpWebRequest)HttpWebRequest.Create(this.Url);
                this.Request.KeepAlive = false;

                // set login and password
                if ((this.Usuario != null) && (this.Contraseña != null) && (this.Usuario != ""))
                {
                    this.Request.Credentials = new NetworkCredential(this.Usuario, this.Contraseña);
                }

                // set connection group name
                if (this.UsaGrupoConexionSeparado)
                {
                    string codigoGrupoConexion = this.Codigo;
                    if (nuevoGrupoConexion)
                    {
                        codigoGrupoConexion += this.ContReconexion.ToString();
                        this.ContReconexion++;
                    }
                    this.Request.ConnectionGroupName = codigoGrupoConexion;
                }

                this.Request.Method = "GET";
                this.Request.AllowWriteStreamBuffering = false;
                this.Request.AllowAutoRedirect = false;
                this.Request.Timeout = this.TimeOut;

                this.Response = (HttpWebResponse)this.Request.GetResponse();
                this.Stream = this.Response.GetResponseStream();
                this.Stream.ReadTimeout = this.TimeOut;

                resultado = this.Response.StatusCode == this.CodigoRespuesta;
            }
                catch (Exception exception)
            {
                this.Stop();
                //this.Request = null;
                //this.Response = null;
                //this.Stream = null;
                OLogsVAComun.Comun.Info(exception, "StartComandoCGI");
            }

            this.Conectado = resultado;
            return resultado;
        }

        /// <summary>
        /// Finaliza la conexión con el CGI
        /// </summary>
        /// <returns>Verdadero si la conexión se ha finalizado con éxito</returns>
        public bool Stop()
        {
            bool resultado = false;

            try
            {
                if (this.Conectado)
                {
                    if (this.Stream != null)
                    {
                        this.Stream.Close();
                        this.Stream.Dispose();
                        this.Stream = null;
                    }

                    if (this.Response != null)
                    {
                        this.Response.Close();
                        this.Response = null;
                    }

                    if (this.Request != null)
                    {
                        this.Request.Abort();
                        this.Request = null;
                    }

                    resultado = true;
                    this.Conectado = false;
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.Comun.Error(exception, "StopComandoCGI");
            }

            return resultado;
        }
        #endregion

        #region Enumerado(s)
        /// <summary>
        /// Indica el tipo de contenido de una consulta CGI
        /// </summary>
        public enum TipoContenidoRespuestaCGI
        {
            /// <summary>
            /// Desconocido
            /// </summary>
            Desconocido = 0,
            /// <summary>
            /// Texto
            /// </summary>
            TextPlain = 1,
            /// <summary>
            /// Imagen  JPG
            /// </summary>
            ImageJpeg = 2,
            /// <summary>
            /// Envio continuo de bytes
            /// </summary>
            MultipartXMixedReplace = 3
        }
        #endregion
    }

    /// <summary>
    /// Comunicación con aplicaciones CGI con respuesta de texto
    /// </summary>
    public class OComunicacionCGITexto : OComunicacionCGI
    {
        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OComunicacionCGITexto() :
            base()
        {
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OComunicacionCGITexto(string url, string usuario, string contraseña, string codigo, bool usaGrupoConexionSeparado, int timeOut, HttpStatusCode codigoRespuesta) :
            base(url, usuario, contraseña, codigo, usaGrupoConexionSeparado, timeOut, codigoRespuesta)
        {
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Envio de comando CGI para información de texto
        /// </summary>
        /// <returns>Verdadero si la ejecución se ha realizado con éxito</returns>
        public bool Ejecuta(out string respuesta)
        {
            bool resultado = false;
            respuesta = string.Empty;

            try
            {
                resultado = this.Start();

                if (resultado)
                {
                    resultado = this.TipoContenido == TipoContenidoRespuestaCGI.TextPlain;
                }

                if (resultado)
                {
                    StreamReader streamReaderInfo;
                    streamReaderInfo = new StreamReader(this.Stream);
                    respuesta = streamReaderInfo.ReadToEnd();
                    streamReaderInfo.Close();
                }

                this.Stop();
            }
            catch (Exception exception)
            {
                resultado = false;
                respuesta = string.Empty;
                OLogsVAComun.Comun.Info(exception, "EjecucionComandoCGITexto");
            }

            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Comunicación con aplicaciones CGI con respuesta de texto
    /// </summary>
    public class OComunicacionCGIDummy : OComunicacionCGI
    {
        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OComunicacionCGIDummy() :
            base()
        {
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OComunicacionCGIDummy(string url, string usuario, string contraseña, string codigo, bool usaGrupoConexionSeparado, int timeOut, HttpStatusCode codigoRespuesta):
            base(url, usuario, contraseña, codigo, usaGrupoConexionSeparado, timeOut, codigoRespuesta)
        {
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Envio de comando CGI para información de texto
        /// </summary>
        /// <returns>Verdadero si la ejecución se ha realizado con éxito</returns>
        public bool Ejecuta()
        {
            bool resultado = false;

            try
            {
                resultado = this.Start();
                this.Stop();
            }
            catch (Exception exception)
            {
                OLogsVAComun.Comun.Info(exception, "OComunicacionCGIDummy");
            }

            return resultado;
        }
        #endregion
    }
}
