//***********************************************************************
// Assembly         : Orbita.Trazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-21-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Representa un evento de logger.
    /// </summary>
    [System.Serializable]
    public class ItemLog : System.IDisposable
    {
        #region Atributos privados
        /// <summary>
        /// El nivel de registro. Por defecto <c>NivelLog.Debug</c>.
        /// </summary>
        NivelLog nivelLog;
        /// <summary>
        /// Dia y hora de entrada en el registro. Si no  explicitamente esta propiedad ofrece la marca de tiempo de la creación del objeto.
        /// </summary>
        System.DateTime fecha;
        /// <summary>
        /// Cuerpo del mensaje. Por defecto <c>string.Empty</c>.
        /// </summary>
        string mensaje;
        /// <summary>
        /// Identificador de secuencia. Por defecto <c>null</c>.
        /// </summary>
        int? identificador;
        /// <summary>
        /// Argumentos adicionales que puede contener el item, además del mensaje propiamente dicho.
        /// </summary>
        object[] args;
        #endregion

        #region Atributos privados estáticos
        /// <summary>
        /// Identificador de secuencia global.
        /// </summary>
        static int identificadorGlobal = 0;
        #endregion

        #region Atributos públicos estáticos
        /// <summary>
        /// Fecha del primer evento creado de logger.
        /// </summary>
        public static readonly System.DateTime FechaCero = System.DateTime.Now;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.ItemLog.
        /// Por defecto <c>NivelLog.Debug</c>.
        /// </summary>
        public ItemLog()
            : this(NivelLog.Debug) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.ItemLog.
        /// </summary>
        /// <param name="nivelLog">El nivel de registro.</param>
        public ItemLog(NivelLog nivelLog)
        {
            this.nivelLog = nivelLog;
            this.fecha = System.DateTime.Now;
            this.identificador = System.Threading.Interlocked.Increment(ref identificadorGlobal);
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.ItemLog.
        /// </summary>
        /// <param name="nivelLog">El nivel de registro.</param>
        /// <param name="mensaje">Cuerpo del mensaje.</param>
        public ItemLog(NivelLog nivelLog, string mensaje)
            : this(nivelLog)
        {
            this.mensaje = mensaje;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.ItemLog.
        /// </summary>
        /// <param name="nivelLog">El nivel de registro.</param>
        /// <param name="excepcion">Excepción.</param>
        public ItemLog(NivelLog nivelLog, System.Exception excepcion)
            : this(nivelLog)
        {
            // Convertir la excepción a .ToString(), ya que, pasar por remoting la excepción produce errores.
            this.mensaje = string.Format(System.Globalization.CultureInfo.CurrentCulture, "[{0}] {1}", Orbita.Trazabilidad.Estado.Excepcion, excepcion.ToString());
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.ItemLog.
        /// </summary>
        /// <param name="nivelLog">El nivel de registro.</param>
        /// <param name="excepcion">Excepción.</param>
        /// <param name="mensaje">Cuerpo del mensaje.</param>
        public ItemLog(NivelLog nivelLog, System.Exception excepcion, string mensaje)
            : this(nivelLog)
        {
            this.mensaje = mensaje;
            // Convertir la excepción a string, ya que, pasar por remoting la excepción produce errores.
            this.mensaje += string.Format(System.Globalization.CultureInfo.CurrentCulture, " [{0}] {1}", Orbita.Trazabilidad.Estado.Excepcion, excepcion.ToString());
        }
        #endregion

        #region Destructores
        /// <summary>
        /// Indica si ya se llamo al método Dispose. (default = false)
        /// </summary>
        bool disposed = false;
        /// <summary>
        /// Implementa IDisposable.
        /// No  hacer  este  método  virtual.
        /// Una clase derivada no debería ser capaz de  reemplazar este método.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que  contiene la lógica para liberar los recursos de esta clase.
            Dispose(true);
            // Este objeto será limpiado por el método Dispose.
            // Llama al método del recolector de basura, GC.SuppressFinalize.
            System.GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Método  sobrecargado de  Dispose que será  el que
        /// libera los recursos. Controla que solo se ejecute
        /// dicha lógica una  vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name="disposing">Indica si llama al método Dispose.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Preguntar si Dispose ya fue llamado.
            if (!this.disposed)
            {
                // Finalizar correctamente los recursos no manejados.
                this.nivelLog = NivelLog.Debug;
                this.mensaje = null;
                this.identificador = null;
                this.args = null;
                // Marcar como desechada ó desechandose,
                // de forma que no se puede ejecutar el
                // código dos veces.
                disposed = true;
            }
        }
        /// <summary>
        /// Destructor(es) de clase.
        /// En caso de que se nos olvide “desechar” la clase, el GC llamará al destructor, que tambén ejecuta la lógica anterior para liberar los recursos.
        /// </summary>
        ~ItemLog()
        {
            // Llamar a Dispose(false) es óptimo en terminos de legibilidad y mantenimiento.
            Dispose(false);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// El nivel de registro. Por defecto <c>NivelLog.Debug</c>.
        /// </summary>
        public NivelLog NivelLog
        {
            get { return this.nivelLog; }
            set { this.nivelLog = value; }
        }
        /// <summary>
        /// Nivel de registro formateado.
        /// </summary>
        public string SNivelLog
        {
            get { return this.nivelLog.ToString().PadRight(5).ToUpper(System.Globalization.CultureInfo.CurrentCulture); }
        }
        /// <summary>
        /// Dia y hora de entrada en el registro. Si no  explicitamente
        /// esta propiedad ofrece la marca de tiempo de la creación del
        /// objeto.
        /// </summary>
        public System.DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }
        /// <summary>
        /// Fecha formateada en formato 'yyyy-MM-dd HH:mm:ss.fff'.
        /// </summary>
        public string SFecha
        {
            get { return this.fecha.ToString(Orbita.Trazabilidad.Formato.FechaLarga, System.Globalization.CultureInfo.CurrentCulture); }
        }
        /// <summary>
        /// El cuerpo del mensaje. Por defecto <c>string.Empty</c>.
        /// </summary>
        public string Mensaje
        {
            get { return this.mensaje; }
            set { this.mensaje = value; }
        }
        /// <summary>
        /// Identificador de evento. Por defecto <c>null</c>.
        /// </summary>
        public int? Identificador
        {
            get { return this.identificador; }
            set { this.identificador = value; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Obtener argumentos adicionales que puede contener el item, además del mensaje propiamente dicho.
        /// </summary>
        /// <returns>Colección de object.</returns>
        public object[] GetArgumentos()
        {
            return this.args;
        }
        /// <summary>
        /// Asignar argumentos adicionales que puede contener el item, además del mensaje propiamente dicho.
        /// </summary>
        public void SetArgumentos(object[] argumentos)
        {
            this.args = argumentos;
        }
        #endregion
    }
}