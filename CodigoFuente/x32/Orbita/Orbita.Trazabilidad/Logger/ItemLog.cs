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

using System;

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
        /// Identificador de secuencia. Por defecto <c>null</c>.
        /// </summary>
        private int? _identificador;
        /// <summary>
        /// Argumentos adicionales que puede contener el item, adem�s del mensaje propiamente dicho.
        /// </summary>
        private object[] _args;
        #endregion

        #region Atributos privados est�ticos
        /// <summary>
        /// Identificador de secuencia global.
        /// </summary>
        private static int _identificadorGlobal;
        #endregion

        #region Atributos p�blicos est�ticos
        /// <summary>
        /// Fecha del primer evento creado de logger.
        /// </summary>
        public static readonly DateTime FechaCero = DateTime.Now;
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
            NivelLog = nivelLog;
            Fecha = System.DateTime.Now;
            _identificador = System.Threading.Interlocked.Increment(ref _identificadorGlobal);
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.ItemLog.
        /// </summary>
        /// <param name="nivelLog">El nivel de registro.</param>
        /// <param name="mensaje">Cuerpo del mensaje.</param>
        public ItemLog(NivelLog nivelLog, string mensaje)
            : this(nivelLog)
        {
            Mensaje = mensaje;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.ItemLog.
        /// </summary>
        /// <param name="nivelLog">El nivel de registro.</param>
        /// <param name="excepcion">Excepci�n.</param>
        public ItemLog(NivelLog nivelLog, Exception excepcion)
            : this(nivelLog)
        {
            // Convertir la excepci�n a .ToString(), ya que, pasar por remoting la excepci�n produce errores.
            Mensaje = string.Format(System.Globalization.CultureInfo.CurrentCulture, "[{0}] {1}", Orbita.Trazabilidad.Estado.Excepcion, excepcion.ToString());
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
            Mensaje = mensaje;
            // Convertir la excepci�n a string, ya que, pasar por remoting la excepci�n produce errores.
            Mensaje += string.Format(System.Globalization.CultureInfo.CurrentCulture, " [{0}] {1}", Orbita.Trazabilidad.Estado.Excepcion, excepcion.ToString());
        }
        #endregion

        #region Destructores
        /// <summary>
        /// Indica si ya se llamo al m�todo Dispose. (default = false)
        /// </summary>
        bool _disposed;
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
            if (!_disposed)
            {
                // Finalizar correctamente los recursos no manejados.
                NivelLog = NivelLog.Debug;
                Mensaje = null;
                _identificador = null;
                _args = null;
                // Marcar como desechada � desechandose,
                // de forma que no se puede ejecutar el
                // c�digo dos veces.
                _disposed = true;
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
        public NivelLog NivelLog { get; set; }
        /// <summary>
        /// Nivel de registro formateado.
        /// </summary>
        public string SNivelLog
        {
            get { return NivelLog.ToString().PadRight(5).ToUpper(System.Globalization.CultureInfo.CurrentCulture); }
        }
        /// <summary>
        /// Dia y hora de entrada en el registro. Si no  explicitamente
        /// esta propiedad ofrece la marca de tiempo de la creaci�n del
        /// objeto.
        /// </summary>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// Fecha formateada en formato 'yyyy-MM-dd HH:mm:ss.fff'.
        /// </summary>
        public string SFecha
        {
            get { return Fecha.ToString(Formato.FechaLarga, System.Globalization.CultureInfo.CurrentCulture); }
        }
        /// <summary>
        /// El cuerpo del mensaje. Por defecto <c>string.Empty</c>.
        /// </summary>
        public string Mensaje { get; set; }
        /// <summary>
        /// Identificador de evento. Por defecto <c>null</c>.
        /// </summary>
        public int? Identificador
        {
            get { return _identificador; }
            set { _identificador = value; }
        }
        #endregion

        #region M�todos p�blicos
        /// <summary>
        /// Obtener argumentos adicionales que puede contener el item, adem�s del mensaje propiamente dicho.
        /// </summary>
        /// <returns>Colecci�n de object.</returns>
        public object[] GetArgumentos()
        {
            return _args;
        }
        /// <summary>
        /// Asignar argumentos adicionales que puede contener el item, adem�s del mensaje propiamente dicho.
        /// </summary>
        public void SetArgumentos(object[] argumentos)
        {
            _args = argumentos;
        }
        #endregion
    }
}