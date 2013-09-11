using System;
using System.Collections;
using Orbita.Trazabilidad;
using Orbita.Utiles;
namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Dispositivo.
    /// </summary>
    public class ODispositivo : IDisposable
    {
        #region Atributos
        /// <summary>
        /// Variable para el cierre de todos los objetos.
        /// </summary>
        public bool Disposed = false;
        /// <summary>
        /// Salidas del dispositivo.
        /// </summary>
        public byte[] Salidas;
        /// <summary>
        /// Logger de la clase.
        /// </summary>
        public static ILogger Wrapper;
        /// <summary>
        /// Objeto para bloquear las escrituras.
        /// </summary>
        public object Bloqueo = new object();
        /// <summary>
        /// Segundos del evento Comunicaciones.
        /// </summary>
        protected decimal EventoCommSg;
        /// <summary>
        /// Fecha del último evento de comunicaciones.
        /// </summary>
        protected DateTime FechaUltimoEventoComm;
        #endregion

        #region Eventos
        /// <summary>
        /// Evento de cambio de dato.
        /// </summary>
        public event OManejadorEventoComm OrbitaCambioDato;
        /// <summary>
        /// Evento de alarma.
        /// </summary>
        public event OManejadorEventoComm OrbitaAlarma;
        /// <summary>
        /// Evento de comunicaciones correctas.
        /// </summary>
        public event OManejadorEventoComm OrbitaComm;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ODispositivo.
        /// </summary>
        public ODispositivo()
        {
            try
            {
                Wrapper = LogManager.GetLogger("wrapper");
                this.FechaUltimoEventoComm = DateTime.Now;
            }
            catch (Exception e)
            {
                throw new OExcepcion("No se ha definido el objeto logger (nombre wrapper) desde la aplicación.", e);
            }
        }
        /// <summary>
        /// Destructor del objeto.
        /// </summary>
        ~ODispositivo()
        {
            // Do not re-create Dispose clean-up code here. 
            // Calling Dispose(false) is optimal in terms of 
            // readability and maintainability.
            Dispose(false);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Identificador de dispositivo.
        /// </summary>
        public int Identificador { get; set; }
        /// <summary>
        /// Nombre de dispositivo.
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Tipo de dispositivo.
        /// </summary>
        public string Tipo { get; set; }
        /// <summary>
        /// Dirección de conexión.
        /// </summary>
        public object Direccion { get; set; }
        /// <summary>
        /// Puerto de conexión.
        /// </summary>
        public int Puerto { get; set; }
        /// <summary>
        /// Nombre del protocolo.
        /// </summary>
        public string Protocolo { get; set; }
        /// <summary>
        /// Indica si se conecta al dispositivo de forma local o remota.
        /// </summary>
        public bool Local { get; set; }
        #endregion

        #region Métodos protegidos
        /// <summary>
        /// El evento invoca el método que puede ser sobreescrito en la clase derivada.
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        protected virtual void OnCambioDato(OEventArgs e)
        {
            // Hacer una copia temporal del evento para evitar una condición
            // de carrera, si el último suscriptor desuscribe inmediatamente
            // después de la comprobación nula y antes de que el  evento  se
            // produce.
            OManejadorEventoComm handler = OrbitaCambioDato;
            if (handler != null)
            {
                handler(e);
            }
        }
        /// <summary>
        /// El evento invoca el método que puede ser sobreescrito en la clase derivada.
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        protected virtual void OnAlarma(OEventArgs e)
        {
            // Hacer una copia temporal del evento para evitar una condición
            // de carrera, si el último suscriptor desuscribe inmediatamente
            // después de la comprobación nula y antes de que el  evento  se
            // produce.
            OManejadorEventoComm handler = OrbitaAlarma;
            if (handler != null)
            {
                handler(e);
            }
        }
        /// <summary>
        /// El evento invoca el método que puede ser sobreescrito en la clase derivada.
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        protected virtual void OnComm(OEventArgs e)
        {
            // Hacer una copia temporal del evento para evitar una condición
            // de carrera, si el último suscriptor desuscribe inmediatamente
            // después de la comprobación nula y antes de que el  evento  se
            // produce.
            OManejadorEventoComm handler = OrbitaComm;
            if (handler != null)
            {
                handler(e);
            }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Iniciar todas las comunicaciones del dispositivo.
        /// </summary>
        public virtual void Iniciar() { }
        /// <summary>
        /// Método de escritura de un dispositivo.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <returns>Resultado de la escritura.</returns>
        public virtual bool Escribir(string[] variables, object[] valores)
        {
            return false;
        }
        /// <summary>
        /// Método de escritura de un dispositivo.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <param name="canal"></param>
        /// <returns></returns>
        public virtual bool Escribir(string[] variables, object[] valores, string canal)
        {
            return false;
        }
        /// <summary>
        /// Método de lectura de un dispositivo.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="demanda">establece si la lectura se realiza al instante</param>
        /// <returns></returns>
        public virtual object[] Leer(string[] variables, bool demanda)
        {
            return null;
        }
        /// <summary>
        /// Obtener las alarmas activas del dispositivo.
        /// </summary>
        /// <returns></returns>
        public virtual ArrayList GetAlarmasActivas()
        {
            return null;
        }
        /// <summary>
        /// Obtener los datos del sistema y su valor.
        /// </summary>
        /// <returns></returns>
        public virtual OHashtable GetDatos()
        {
            return null;
        }
        /// <summary>
        /// Obtenerr las lecturas del sistema y su valor.
        /// </summary>
        /// <returns></returns>
        public virtual OHashtable GetLecturas()
        {
            return null;
        }
        /// <summary>
        /// Obtener las alarmas del sistema y su valor.
        /// </summary>
        /// <returns></returns>
        public virtual OHashtable GetAlarmas()
        {
            return null;
        }
        /// <summary>
        /// Limpia la memoria.
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called. 
            if (this.Disposed) return;
            // If disposing equals true, dispose all managed 
            // and unmanaged resources. 
            if (disposing)
            {
            }
            // Call the appropriate methods to clean up 
            // unmanaged resources here. 
            // If disposing is false, 
            // only the following code is executed.

            // Note disposing has been done.
            Disposed = true;
        }
        /// <summary>
        /// Llama al método para limpiar todos los objetos de memoria
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method. 
            // Therefore, you should call GC.SupressFinalize to 
            // take this object off the finalization queue 
            // and prevent finalization code for this object 
            // from executing a second time.
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class DispositivoEscrituras
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase DispositivoEscrituras.
        /// </summary>
        public DispositivoEscrituras() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase DispositivoEscrituras.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        public DispositivoEscrituras(string[] variables, object[] valores)
        {
            Variables = variables;
            Valores = valores;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Colección de variables.
        /// </summary>
        public string[] Variables { get; set; }
        /// <summary>
        /// Colección de valores.
        /// </summary>
        public object[] Valores { get; set; }
        #endregion
    }
}