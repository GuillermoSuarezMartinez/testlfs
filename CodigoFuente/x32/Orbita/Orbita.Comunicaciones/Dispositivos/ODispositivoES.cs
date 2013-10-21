using System;
using System.Collections;
using Orbita.Utiles;
using Orbita.Winsock;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Clase base para los dispositivos de ES
    /// </summary>
    public class ODispositivoES : ODispositivo
    {
        #region Atributos
        /// <summary>
        /// Atributo que indica las  colecciones de tags de datos, lecturas y alarmas.
        /// </summary>
        public OTags Tags;
        /// <summary>
        /// Colección de hilos.
        /// </summary>
        public static OHilos Hilos;
        /// <summary>
        /// Datos de configuración del canal.
        /// </summary>
        public OConfigDispositivo ConfigDispositivo;
        /// <summary>
        /// Argumentos para generar los eventos.
        /// </summary>
        public OEventArgs Eventargs;
        /// <summary>
        /// Objeto para establecer el canal Tcp.
        /// </summary>
        public OWinsockBase Winsock;
        /// <summary>
        /// Segundos para la reconexión con el dispositivo.
        /// </summary>
        public decimal ReConexionSg = 1;
        /// <summary>
        /// Valor devuelto para las entradas.
        /// </summary>
        public byte[] Entradas;
        /// <summary>
        /// Byte de escrituras.
        /// </summary>
        protected new byte[] Salidas;
        /// <summary>
        /// Tiempo que tarda en trazar un error de comunicación.
        /// </summary>
        public int LogErrorComunicacionSg = 60;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ODispositivoES.
        /// </summary>
        public ODispositivoES(OTags tags, OHilos hilos, ODispositivo dispositivo)
        {
            Wrapper.Info("Creando dispositivo ODispositivoES");
            try
            {
                // Asignación de las colecciones de datos, lecturas y alarmas.
                Tags = tags;
                ConfigDispositivo = tags.Config;
                Eventargs = new OEventArgs();

                // Actualizando las variables de dispositivo.
                Identificador = dispositivo.Identificador;
                Nombre = dispositivo.Nombre;
                Tipo = dispositivo.Tipo;
                Direccion = dispositivo.Direccion;
                Local = dispositivo.Local;
                Puerto = dispositivo.Puerto;
                Protocolo = dispositivo.Protocolo;

                // Asignar colección de hilos.
                Hilos = hilos;
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoES Constructor ", ex);
                throw;
            }
        }
        #endregion Constructor

        #region Propiedades
        /// <summary>
        /// Colección de datos.
        /// </summary>
        public OHashtable Datos
        {
            get { return Tags.GetDatos(); }
        }
        /// <summary>
        /// Colección de lecturas.
        /// </summary>
        public OHashtable Lecturas
        {
            get { return Tags.GetLecturas(); }
        }
        /// <summary>
        /// Colección de alarmas.
        /// </summary>
        public OHashtable Alarmas
        {
            get { return Tags.GetAlarmas(); }
        }
        /// <summary>
        /// Colección de alarmas activas.
        /// </summary>
        public ArrayList AlarmasActivas
        {
            get { return Tags.GetAlarmasActivas(); }
        }
        #endregion Propiedades

        #region Métodos públicos
        /// <summary>
        /// Inicializar grupos, punteros e items.
        /// </summary>
        public override void Iniciar()
        {
            IniciarHiloVida();
        }
        /// <summary>
        /// Devuelva las alarmas activas del sistema.
        /// </summary>
        /// <returns></returns>
        public override ArrayList GetAlarmasActivas()
        {
            return Tags.GetAlarmasActivas();
        }
        /// <summary>
        /// Devuelve los datos del dipositivo y su valor.
        /// </summary>
        /// <returns></returns>
        public override OHashtable GetDatos()
        {
            return Tags.GetDatos();
        }
        /// <summary>
        /// Devuelve las lectuas del dipositivo y su valor.
        /// </summary>
        /// <returns></returns>
        public override OHashtable GetLecturas()
        {
            return Tags.GetLecturas();
        }
        /// <summary>
        /// Devuelve las alarmas del dipositivo y su valor.
        /// </summary>
        /// <returns></returns>
        public override OHashtable GetAlarmas()
        {
            return Tags.GetAlarmas();
        }
        /// <summary>
        /// Proceso del hilo de vida.
        /// </summary>
        public virtual void ProcesarHiloVida() { }
        /// <summary>
        /// Limpia los objetos en memoria.
        /// </summary>
        /// <param name="disposing"></param>
        public override void Dispose(bool disposing)
        {
            Tags.Dispose();
            Hilos.Destruir();
        }
        /// <summary>
        /// Escribir el valor de los identificadores de variables de la colección.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <param name="canal"></param>
        /// <returns></returns>
        public override bool Escribir(string[] variables, object[] valores, string canal)
        {
            return Escribir(variables, valores);
        }
        #endregion Métodos públicos

        #region Métodos privados
        /// <summary>
        /// Inicia hilo de vida.
        /// </summary>
        private void IniciarHiloVida()
        {
            // Crear el objeto Hilo e iniciarlo. El parámetro iniciar indica
            // a la colección que una vez añadido el hilo se iniciado.
            Hilos.Add(ProcesarHiloVida, true);
        }
        #endregion Métodos privados
    }
}