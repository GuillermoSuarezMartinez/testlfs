//***********************************************************************
// Assembly         : Orbita.Trazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-18-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************

using System.IO;
using System.Linq;

namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Trace Logger.
    /// </summary>
    public abstract class TraceLogger : BaseLogger
    {
        #region Atributos protegidos
        /// <summary>
        /// Ruta de almacenamiento de ficheros de logger.
        /// </summary>
        protected PathLogger Path;
        /// <summary>
        /// Separador de columnas de ficheros de logger.
        /// </summary>
        protected string separador;
        /// <summary>
        /// Permitir incluir retornos de carro en los mensajes de logger. Por defecto, false.
        /// </summary>
        protected bool RetornoDeCarro;
        /// <summary>
        /// Dirige los resultados del seguimiento o la depuración a un objeto System.IO.TextWriter
        /// o a un objeto de la clase System.IO.Stream como un archivo System.IO.FileStream.
        /// </summary>
        protected System.Diagnostics.TextWriterTraceListener Listener;
        /// <summary>
        /// Guarda relativa al evento cíclico que sucede si se traza sobre el evento elevado de logger.
        /// </summary>
        private bool _eventoCiclico = true;
        #endregion

        #region Atributos protegidos estáticos
        /// <summary>
        /// Atributo estático volátil de bloqueo.
        /// </summary>
        internal static volatile object Bloqueo = new object();
        #endregion

        #region Constructores protegidos
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.TraceLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensión=log</c>.
        /// </summary>
        protected TraceLogger()
            : this(string.Empty, NivelLog.Debug) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.TraceLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensión=log</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        protected TraceLogger(string identificador)
            : this(identificador, NivelLog.Debug) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.TraceLogger.
        /// Por defecto, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensión=log</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        protected TraceLogger(string identificador, NivelLog nivelLog)
            : this(identificador, nivelLog, new PathLogger()) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.TraceLogger.
        /// Por defecto, <c>NivelLog=Debug</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="path">Ruta de almacenamiento de ficheros de logger.</param>
        protected TraceLogger(string identificador, PathLogger path)
            : this(identificador, NivelLog.Debug, path) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.TraceLogger.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        /// <param name="path">Ruta de almacenamiento de ficheros de logger.</param>
        protected TraceLogger(string identificador, NivelLog nivelLog, PathLogger path)
            : base(identificador, nivelLog)
        {
            // Path de logger.
            Path = path;
            // Por defecto, no vamos a almacenar retornos de carro.
            RetornoDeCarro = false;
            // Separador de mensajes.
            separador = Logger.Separador;
            // Asignación del método delegado dinámico de traza de nivel.
            TrazarNivel = Nivel;
        }
        #endregion

        #region Propiedades abstractas
        /// <summary>
        /// Ruta de almacenamiento de ficheros de logger.
        /// </summary>
        public abstract PathLogger PathLogger
        {
            get;
            set;
        }
        /// <summary>
        /// Nombre del fichero de logger.
        /// </summary>
        public abstract string Fichero
        {
            get;
        }
        /// <summary>
        /// Separador de columnas de ficheros de logger.
        /// </summary>
        public abstract string Separador
        {
            get;
            set;
        }
        /// <summary>
        /// Permitir incluir retornos de carro en los mensajes de logger. Por defecto, false.
        /// </summary>
        public abstract bool RetornoCarro
        {
            get;
            set;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Registra un elemento determinado en disco.
        /// </summary>
        /// <param name="item">El elemento que va a ser registrado.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public override void Log(ItemLog item)
        {
            try
            {
                // Crear la cadena que se va a escribir en el log.
                var cadena = Formatear(item);
                // Escribir en disco la cadena de texto.
                Escribir(cadena, item);
            }
            catch (System.Exception ex)
            {
                // Escribir error en disco.
                Escribir(ex);
            }
        }
        /// <summary>
        /// Registra un elemento determinado en disco.
        /// </summary>
        /// <param name="item">El elemento que va a ser registrado.</param>
        /// <param name="args">Argumentos adicionales.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public override void Log(ItemLog item, object[] args)
        {
            try
            {
                // Crear la cadena que se va a escribir en el log.
                string cadena = Formatear(item);
                // Control de argumento no nulo.
                if (args != null)
                {
                    // Concatenar los argumentos adicionales al registro.
                    cadena = args.Aggregate(cadena, (current, t) => current + string.Concat(Separador, Formatear(t)));
                }
                // Escribir en disco la cadena de texto.
                Escribir(cadena, item);
            }
            catch (System.Exception ex)
            {
                // Escribir error en disco.
                Escribir(ex);
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Método privado asociado al evento NivelSID.
        /// </summary>
        /// <param name="item">Item de entrada.</param>
        /// <returns>Nivel de log.</returns>
        private static string Nivel(ItemLog item)
        {
            return item.SNivelLog;
        }
        /// <summary>
        /// Método que formatea la cadena de entrada. Eliminando los  saltos de
        /// línea por emptys y reemplazando los caracteres que coincidan con el
        /// separador por el carácter desconocido (?).
        /// </summary>
        /// <param name="cadena">Cadena de entrada.</param>
        /// <returns>Cadena de entrada formateada.</returns>
        private string Formatear(object cadena)
        {
            object res = cadena ?? string.Empty;
            return RetornoDeCarro ? res.ToString().Replace(Separador, "?") : res.ToString().Replace(System.Environment.NewLine, string.Empty).Replace(Separador, "?");
        }
        /// <summary>
        /// Método que formatea la cadena de entrada. Eliminando los  saltos de
        /// línea por emptys y reemplazando los caracteres que coincidan con el
        /// separador por el carácter desconocido (?).
        /// </summary>
        /// <param name="cadena">Cadena de entrada.</param>
        /// <returns>Cadena de entrada formateada.</returns>
        private string Formatear(string cadena)
        {
            return RetornoDeCarro ? cadena.Replace(Separador, "?") : cadena.Replace(System.Environment.NewLine, string.Empty).Replace(Separador, "?");
        }
        /// <summary>
        /// Método que crea la cadena de entrada al logger.
        /// </summary>
        /// <param name="item">Item de entrada.</param>
        /// <returns>Cadena de entrada formateada.</returns>
        private string Formatear(ItemLog item)
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}  {1} {2} {3}", item.SFecha, TrazarNivel(item), Separador, Formatear(item.Mensaje));
        }
        /// <summary>
        /// Escribir en disco la cadena de texto.
        /// </summary>
        /// <param name="cadena">Cadena de texto.</param>
        /// <param name="item">Item de entrada.</param>
        private void Escribir(string cadena, ItemLog item)
        {
            // Utilizar bloqueo...static volatile object Bloqueo = new object();
            lock (Bloqueo)
            {
                // Escribir el texto en el fichero de datos de disco.
                FileStream fs = null;
                try
                {
                    // Abrir el Fichero=Nombre del fichero, en modo escritura con lectura y escritura compartida y modo de creacion.
                    fs = new FileStream(Fichero, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    using (var sw = new StreamWriter(fs))
                    {
                        // Obtiene un valor que indica si la secuencia actual admite escritura.
                        while (!fs.CanWrite) { }
                        
                        // Referencia: necesario para evitar CA2202: No aplicar Dispose a los objetos varias veces.
                        fs = null;
                        
                        // Use the writer object...
                        // Escribir la cadena en el fichero de texto.
                        sw.WriteLine(cadena);
                    }
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                    try
                    {
                        if (_eventoCiclico)
                        {
                            _eventoCiclico = false;
                            // Argumentos relativos al evento de escritura.
                            var e = new LoggerEventArgs(item);
                            // El evento se lanza como cualquier delegado.
                            OnDespuesEscribirLogger(this, e);
                        }
                    }
                    finally
                    {
                        if (!_eventoCiclico)
                        {
                            _eventoCiclico = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region Métodos protegidos
        /// <summary>
        /// Escribir error en disco.
        /// </summary>
        /// <param name="ex">Excepción.</param>
        protected void Escribir(System.Exception ex)
        {
            // Comprobar la existencia del directorio.
            if (!PathLogger.Existe())
            {
                // ..sino existe crearlo.
                Path.Crear();
            }
            if (ex == null) return;
            using (var item = new ItemLog(NivelLog.Fatal, ex))
            {
                // Formatear la salida.
                var cadena = Formatear(item);
                // Escribir la salida en un fichero.
                Listener.WriteLine(cadena);
                // Cierra System.Diagnostics.TextWriterTraceListener.Writer para que ya no se
                // reciba ningún resultado del seguimiento o la depuración.
                Listener.Close();
                // Vacía el búfer de resultados de la propiedad System.Diagnostics.TextWriterTraceListener.Writer.
                Listener.Flush();
                // Argumentos relativos al evento de escritura.
                var e = new LoggerEventArgs(item, ex);
                // El evento se lanza como cualquier delegado.
                OnErrorLogger(this, e);
            }
        }
        #endregion
    }
}