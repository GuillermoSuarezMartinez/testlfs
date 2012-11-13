//***********************************************************************
// Assembly         : OrbitaTrazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-21-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Globalization;
namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Item Log.
    /// </summary>
    [Serializable]
    public class ItemLog : IDisposable
    {
        #region Atributos privados
        /// <summary>
        /// El nivel de registro. Por defecto <c>NivelLog.Debug</c>.
        /// </summary>
        NivelLog nivelLog;
        /// <summary>
        /// Dia y hora de entrada en el registro. Si no  explicitamente esta propiedad ofrece la marca de tiempo de la creaci�n del objeto.
        /// </summary>
        DateTime fecha;
        /// <summary>
        /// Cuerpo del mensaje. Por defecto <c>string.Empty</c>.
        /// </summary>
        string mensaje;
        /// <summary>
        /// Identificador de evento. Por defecto <c>null</c>.
        /// </summary>
        int? identificador;
        /// <summary>
        /// Argumentos adicionales que puede contener el item, adem�s del mensaje propiamente dicho.
        /// </summary>
        object[] args;
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
            this.fecha = DateTime.Now;
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
        /// <param name="excepcion">Excepci�n.</param>
        public ItemLog(NivelLog nivelLog, Exception excepcion)
            : this(nivelLog)
        {
            if (excepcion != null)
            {
                // Convertir la excepci�n a string, ya que, pasar por remoting la excepci�n produce errores.
                this.mensaje = string.Format(CultureInfo.CurrentCulture, "[{0}] {1}", Orbita.Trazabilidad.Estado.Excepcion, excepcion.ToString());
            }
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.ItemLog.
        /// </summary>
        /// <param name="nivelLog">El nivel de registro.</param>
        /// <param name="excepcion">Excepci�n.</param>
        /// <param name="mensaje">Cuerpo del mensaje.</param>
        public ItemLog(NivelLog nivelLog, Exception excepcion, string mensaje)
            : this(nivelLog)
        {
            if (excepcion != null)
            {
                // Convertir la excepci�n a string, ya que, pasar por remoting la excepci�n produce errores.
                this.mensaje = string.Format(CultureInfo.CurrentCulture, "{0} [{1}] {2}", mensaje, Orbita.Trazabilidad.Estado.Excepcion, excepcion.ToString());
            }
        }
        #endregion

        #region Destructores
        /// <summary>
        /// Indica si ya se llamo al m�todo Dispose. (default = false)
        /// </summary>
        bool disposed = false;
        /// <summary>
        /// Implementa IDisposable.
        /// No  hacer  este  m�todo  virtual.
        /// Una clase derivada no deber�a ser capaz de  reemplazar este m�todo.
        /// </summary>
        public void Dispose()
        {
            // Llamo al m�todo que  contiene la l�gica para liberar los recursos de esta clase.
            Dispose(true);
            // Este objeto ser� limpiado por el m�todo Dispose.
            // Llama al m�todo del recolector de basura, GC.SuppressFinalize.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// M�todo  sobrecargado de  Dispose que ser�  el que
        /// libera los recursos. Controla que solo se ejecute
        /// dicha l�gica una  vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name="disposing">Indica si llama al m�todo Dispose.</param>
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
                // Marcar como desechada � desechandose,
                // de forma que no se puede ejecutar el
                // c�digo dos veces.
                disposed = true;
            }
        }
        /// <summary>
        /// Destructor(es) de clase.
        /// En caso de que se nos olvide �desechar� la clase, el GC llamar� al destructor, que tamb�n ejecuta la l�gica anterior para liberar los recursos.
        /// </summary>
        ~ItemLog()
        {
            // Llamar a Dispose(false) es �ptimo en terminos de legibilidad y mantenimiento.
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
            get { return string.Format(CultureInfo.CurrentCulture, " {0}", this.nivelLog).ToUpper(CultureInfo.CurrentCulture); }
        }
        /// <summary>
        /// Dia y hora de entrada en el registro. Si no  explicitamente
        /// esta propiedad ofrece la marca de tiempo de la creaci�n del
        /// objeto.
        /// </summary>
        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }
        /// <summary>
        /// Fecha formateada en formato 'yyyy-MM-dd HH:mm:ss.fff'.
        /// </summary>
        public string SFecha
        {
            get { return this.fecha.ToString(Orbita.Trazabilidad.Formato.FechaLarga, CultureInfo.CurrentCulture); }
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

        #region M�todos p�blicos
        /// <summary>
        /// Obtener argumentos adicionales que puede contener el item, adem�s del mensaje propiamente dicho.
        /// </summary>
        /// <returns>Colecci�n de object.</returns>
        public object[] GetArgumentos()
        {
            return this.args;
        }
        /// <summary>
        /// Asignar argumentos adicionales que puede contener el item, adem�s del mensaje propiamente dicho.
        /// </summary>
        public void SetArgumentos(object[] args)
        {
            this.args = args;
        }
        #endregion
    }
}
