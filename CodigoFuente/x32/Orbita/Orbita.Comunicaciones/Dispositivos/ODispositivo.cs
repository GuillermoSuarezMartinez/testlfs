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
        /// Identificador de dispositivo.
        /// </summary>
        int _identificador;
        /// <summary>
        /// Nombre de dispositivo.
        /// </summary>
        string _nombre;
        /// <summary>
        /// Tipo de dispositivo.
        /// </summary>
        string _tipo;
        /// <summary>
        /// Dirección de conexión.
        /// </summary>
        object _direccion;
        /// <summary>
        /// Puerto de conexión.
        /// </summary>
        int _puerto;
        /// <summary>
        /// Nombre del protocolo.
        /// </summary>
        string _protocolo;
        /// <summary>
        /// Indica si se conecta al dispositivo de forma local o remota.
        /// </summary>
        bool _local;
        /// <summary>
        /// Variable para el cierre de todos los objetos
        /// </summary>
        public bool disposed = false;
        /// <summary>
        /// Salidas del dispositivo
        /// </summary>
        public byte[] Salidas;
        /// <summary>
        /// Logger de la clase
        /// </summary>
        public static ILogger wrapper;
        /// <summary>
        /// Objeto para bloquear las escrituras
        /// </summary>
        public Object bloqueo = new Object();
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

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Dispositivo.
        /// </summary>
        public ODispositivo()
        {
            try
            {
                wrapper = LogManager.GetLogger("wrapper");
            }
            catch (Exception e)
            {
                OExcepcion ex = new OExcepcion("No se ha definido el objeto logger (nombre wrapper) desde la aplicación.", e);
            }

        }
        /// <summary>
        /// Destruye el objeto
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
        public int Identificador
        {
            get { return this._identificador; }
            set { this._identificador = value; }
        }
        /// <summary>
        /// Nombre de dispositivo.
        /// </summary>
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        /// <summary>
        /// Tipo de dispositivo.
        /// </summary>
        public string Tipo
        {
            get { return this._tipo; }
            set { this._tipo = value; }
        }
        /// <summary>
        /// Dirección de conexión.
        /// </summary>
        public object Direccion
        {
            get { return this._direccion; }
            set { this._direccion = value; }
        }
        /// <summary>
        /// Puerto de conexión.
        /// </summary>
        public int Puerto
        {
            get { return this._puerto; }
            set { this._puerto = value; }
        }
        /// <summary>
        /// Nombre del protocolo.
        /// </summary>
        public string Protocolo
        {
            get { return this._protocolo; }
            set { this._protocolo = value; }
        }
        /// <summary>
        /// Indica si se conecta al dispositivo de forma local o remota.
        /// </summary>
        public bool Local
        {
            get { return _local; }
            set { _local = value; }
        }
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
            handler = null;
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
            handler = null;
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
            handler = null;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Arranca todas las comunicaciones del dispositivo
        /// </summary>
        public virtual void Iniciar()
        {

        }
        /// <summary>
        /// Método de escritura de un dispositivo
        /// </summary>
        /// <param name="variables">nombre de las variables</param>
        /// <param name="valores">valor de las variables</param>
        /// <returns></returns>
        public virtual bool Escribir(string[] variables, object[] valores)
        {
            return false;
        }
        /// <summary>
        /// Método de escritura de un dispositivo
        /// </summary>
        /// <param name="variables">nombre de las variables</param>
        /// <param name="valores">valor de las variables</param>
        /// <returns></returns>
        public virtual bool Escribir(string[] variables, object[] valores,string canal)
        {
            return false;
        }
        /// <summary>
        /// Método de lectura de un dispositivo
        /// </summary>
        /// <param name="variables">nombre de las variables</param>
        /// <param name="demanda">establece si la lectura se realiza al instante</param>
        /// <returns></returns>
        public virtual object[] Leer(string[] variables, bool demanda)
        {
            return null;
        }
        /// <summary>
        /// Devuelve las alarmas activas del dispositivo
        /// </summary>
        /// <returns></returns>
        public virtual ArrayList GetAlarmasActivas()
        {
            return null;
        }
        /// <summary>
        /// Devuelve los datos del sistema y su valor
        /// </summary>
        /// <returns></returns>
        public virtual OHashtable GetDatos()
        {
            return null;
        }
        /// <summary>
        /// Devuelve las lecturas del sistema y su valor
        /// </summary>
        /// <returns></returns>
        public virtual OHashtable GetLecturas()
        {
            return null;
        }
        /// <summary>
        /// Devuelve las alarmas del sistema y su valor
        /// </summary>
        /// <returns></returns>
        public virtual OHashtable GetAlarmas()
        {
            return null;
        }
        /// <summary>
        /// Limpia la memoria
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called. 
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources. 
                if (disposing)
                {
                    //// Dispose managed resources.
                    //component.Dispose();
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here. 
                // If disposing is false, 
                // only the following code is executed.
                //CloseHandle(handle);
                //handle = IntPtr.Zero;

                // Note disposing has been done.
                disposed = true;
            }
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
}