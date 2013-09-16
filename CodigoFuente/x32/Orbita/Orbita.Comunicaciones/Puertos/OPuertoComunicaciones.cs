using System;
using System.Collections;
using System.Data;
using System.Text;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Implementa una clase abstacta de un puerto de comunicaciones
    /// </summary>
    public abstract class OPuertoComunicaciones : IDisposable
    {
        #region Atributos públicos
        /// <summary>
        /// Contiene los dispositivos asociados a este puerto
        /// </summary>
        public Hashtable Dispositivos = new Hashtable();
        #endregion Atributos públicos

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OPuertoComunicaciones.
        /// </summary>
        /// <param name="configuracionPuerto">Configuración del puerto de comunicaciones.</param>
        protected OPuertoComunicaciones(OConfiguracionPuerto configuracionPuerto)
        {
            this.ConfiguracionPuerto = configuracionPuerto;
            this.InformacionPuerto = new OInformacionPuerto(-1, "No especificado");
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OPuertoComunicaciones.
        /// </summary>
        /// <param name="configuracionPuerto">Configuración del puerto de comunicaciones.</param>
        /// <param name="info">Información básica del puerto de comunicaciones.</param>
        protected OPuertoComunicaciones(OConfiguracionPuerto configuracionPuerto, OInformacionPuerto info)
        {
            this.ConfiguracionPuerto = configuracionPuerto;
            this.InformacionPuerto = info;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OPuertoComunicaciones.
        /// </summary>
        /// <param name="configuracionPuerto">Configuración del puerto de comunicaciones.</param>
        /// <param name="idNumerico">Identificador númerico del puerto de comunicaciones.</param>
        /// <param name="tipoPuerto">Tipo del puerto de comunicaciones.</param>
        protected OPuertoComunicaciones(OConfiguracionPuerto configuracionPuerto, int idNumerico, string tipoPuerto)
        {
            this.ConfiguracionPuerto = configuracionPuerto;
            this.InformacionPuerto = new OInformacionPuerto(idNumerico, tipoPuerto);
        }
        #endregion Constructores

        #region Propiedades
        /// <summary>
        /// Obtiene la información básica del puerto de comunicaciones.
        /// </summary>
        public OInformacionPuerto InformacionPuerto { get; protected set; }
        /// <summary>
        /// Obtiene la configuración del puerto de comunicaciones.
        /// </summary>
        public OConfiguracionPuerto ConfiguracionPuerto { get; protected set; }
        #endregion Propiedades

        #region Métodos públicos abstractos - Funciones a implementar en función del tipo de puerto.
        /// <summary>
        /// Configurar el puerto de comunicaciones.
        /// </summary>
        /// <param name="configuracion"></param>
        public abstract void ConfigurarPuerto(OConfiguracionPuerto configuracion);
        /// <summary>
        /// Abrir el puerto de comunicaciones.
        /// </summary>
        public abstract void Abrir();
        /// <summary>
        /// Cerrar el puerto de comunicaciones.
        /// </summary>
        public abstract void Cerrar();
        /// <summary>
        /// Envía por el puerto de comunicaciones el vector de bytes tramaTx.
        /// </summary>
        /// <param name="tramaTx">Vector de bytes a enviar por el puerto de comunicaciones.</param>
        public abstract void Enviar(byte[] tramaTx);
        /// <summary>
        /// Copiar en el vector de bytes tramaRx la información recibida por el puerto de comunicaciones.
        /// </summary>
        /// <returns>Vector de bytes donde que contendrá la información recibida hasta el momento.</returns>
        public abstract byte[] RecibirBytes();
        /// <summary>
        ///  Devuleve el número de bytes recibidos hasta el momento por el puerto de comunicaciones.
        /// </summary>
        /// <returns>El número de bytes recibidos hasta el momento.</returns>
        public abstract int BytesRecibidos();
        /// <summary>
        /// Resetea el buffer de recepcion de datos del puerto de comunicaciones.
        /// </summary>
        public abstract void ResetBuffer();
        /// <summary>
        /// Busca un carácter en el buffer de recepcion de datos del puerto de comunicaciones.
        /// </summary>
        /// <param name="caracter">Carácter a buscar.</param>
        /// <returns>True encuentra el valor buscado; false en caso contrario.</returns>
        public abstract bool BuscarCaracter(byte caracter);
        /// <summary>
        /// Lista los puertos COM RS-232 disponbles en el sistema en un DataTable.
        /// </summary>
        /// <returns>Un DataTable con los puertos COM RS-232 disponbles en el sistema.</returns>
        public abstract DataTable ObtenerPuertosDisponibles();
        #endregion Métodos públicos abstractos - Funciones a implementar en función del tipo de puerto.

        #region Métodos públicos
        /// <summary>
        /// Envia una cadena de texto por el puerto utilizando una codificación ASCII.
        /// </summary>
        /// <param name="tramaTx">Cadena de texto a enviar</param>
        public void Enviar(string tramaTx)
        {
            byte[] b = Encoding.ASCII.GetBytes(tramaTx);
            this.Enviar(b);
        }
        /// <summary>
        /// Envia una cadena de texto por el puerto utilizando la codificación Encoding.
        /// </summary>
        /// <param name="tramaTx"></param>
        /// <param name="codificacion">Cadena de texto a enviar</param>
        public void Enviar(string tramaTx, Encoding codificacion)
        {
            byte[] b = codificacion.GetBytes(tramaTx);
            this.Enviar(b);
        }
        /// <summary>
        /// Recibe una cadena de texto por el puerto utilizando la codificación ASCII.
        /// </summary>
        public string RecibirCadena()
        {
            string tramaRx;
            byte[] b = this.RecibirBytes();
            if (b != null && b.Length > 0)
            {
                tramaRx = Encoding.ASCII.GetString(b);
            }
            else
            {
                tramaRx = string.Empty;
            }
            return tramaRx;
        }
        /// <summary>
        /// Recibe una cadena de texto por el puerto utilizando la codificación Encoding.
        /// </summary>
        /// <param name="codificacion">Cadena que contendrá el texto recibido</param>
        public string RecibirCadena(Encoding codificacion)
        {
            byte[] b = this.RecibirBytes();
            return codificacion.GetString(b);
        }
        #endregion Métodos públicos

        #region Miembros de IDisposable
        /// <summary>
        /// Libera los recursos utilizados
        /// </summary>
        public virtual void Dispose()
        {
            this.InformacionPuerto = null;
            this.ConfiguracionPuerto = null;
            this.Dispositivos.Clear();
            this.Dispositivos = null;
        }
        #endregion Miembros de IDisposable
    }
}