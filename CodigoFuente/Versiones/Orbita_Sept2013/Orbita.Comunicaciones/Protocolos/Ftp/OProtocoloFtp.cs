//***********************************************************************
// Assembly         : OrbitaComunicaciones
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-18-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Globalization;
using System.IO;
using System.Net;
using Orbita.Utiles;
namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Clase que representa la funcionalidad necesaria
    /// comunicarse con el protocolo de transferencia FTP.
    /// </summary>
    public class OProtocoloFtp : Protocolo
    {
        #region Atributos privados
        /// <summary>
        /// Nombre del servidor Ftp.
        /// </summary>
        string _nombre;
        /// <summary>
        /// Usuario de acceso al servidor.
        /// </summary>
        string _usuario;
        /// <summary>
        /// Contrase�a de usuario de acceso.
        /// </summary>
        string _password;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Ftp.
        /// </summary>
        public OProtocoloFtp() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Ftp.
        /// </summary>
        /// <param name="nombre">Nombre del servidor de Ftp.</param>
        public OProtocoloFtp(string nombre)
        {
            this._nombre = nombre;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Ftp.
        /// </summary>
        /// <param name="nombre">Nombre del servidor de Ftp.</param>
        /// <param name="usuario">Usuario de acceso al servidor.</param>
        /// <param name="password">Contrase�a de usuario de acceso.</param>
        public OProtocoloFtp(string nombre, string usuario, string password)
        {
            this._nombre = nombre;
            this._usuario = usuario;
            this._password = password;
        }
        #endregion

        #region Destructores
        /// <summary>
        /// M�todo  sobrecargado de  Dispose que ser�  el que
        /// libera los recursos. Controla que solo se ejecute
        /// dicha l�gica una  vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name="disposing">Indica si llama al m�todo Dispose.</param>
        public override void Dispose(bool disposing)
        {
            // Preguntar si Dispose ya fue llamado.
            if (!this.disposed)
            {
                // Finalizar correctamente los recursos no manejados.
                this._nombre = null;
                this._usuario = null;
                this._password = null;

                // Marcar como desechada � desechandose,
                // de forma que no se puede ejecutar el
                // c�digo dos veces.
                disposed = true;
            }
        }
        #endregion

        #region M�todos p�blicos
        /// <summary>
        /// Descargar fichero de Ftp.
        /// </summary>
        /// <param name="identificador">Identificador del dispositivo</param>
        /// <param name="directorio">Directorio de primer nivel origen</param>
        /// <param name="fichero">Nombre del fichero ftp</param>
        /// <param name="extension">Extensi�n del fichero ftp</param>
        /// <param name="copiarENbaseDEdatos">Indica si se quiere 
        /// escribir la informaci�n del fichero en Base de datos</param>
        /// <returns></returns>
        public OFichero Descargar(string identificador, string directorio, string fichero, Extension extension, bool copiarENbaseDEdatos)
        {
            OFichero ficheroEndisco = null;
            try
            {
                FtpWebRequest solicitud = (FtpWebRequest)FtpWebRequest.Create(new Uri(string.Format(CultureInfo.CurrentCulture, "{0}/{1}.{2}", this._nombre, fichero, Enum.GetName(typeof(Extension), extension))));
                solicitud.Method = WebRequestMethods.Ftp.DownloadFile;
                solicitud.UseBinary = true;
                solicitud.Credentials = new NetworkCredential(this._usuario, this._password);
                using (FtpWebResponse respuesta = (FtpWebResponse)solicitud.GetResponse())
                using (Stream ftpStream = respuesta.GetResponseStream())
                {
                    // Escribir en disco el Stream leido. Asignar un tama�o
                    // fijo de buffer de 2048 bytes.
                    int contador = 0;
                    byte[] buffer = new byte[2048];

                    // Leer el contenido del Stream.
                    contador = ftpStream.Read(buffer, 0, buffer.Length);

                    // Crear el objeto ficheroEnDisco que va a ser tratado
                    // posteriormente por el proceso escritor en Base de datos.
                    // Por defecto se considera la escritura en disco.
                    ficheroEndisco = new OFichero(fichero, extension, true, copiarENbaseDEdatos);

                    // Obtener la ruta destino que se va a retornar.
                    string rutaDestino = ficheroEndisco[identificador, directorio];

                    using (FileStream destino = new FileStream(rutaDestino, FileMode.Create))
                    {
                        while (contador > 0)
                        {
                            destino.Write(buffer, 0, contador);
                            contador = ftpStream.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
                return ficheroEndisco;
            }
            finally
            {
                if (ficheroEndisco != null)
                {
                    ficheroEndisco.Dispose();
                }
            }
        }
        #endregion
    }
}