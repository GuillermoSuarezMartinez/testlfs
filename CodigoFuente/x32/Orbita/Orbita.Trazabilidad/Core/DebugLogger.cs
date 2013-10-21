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

namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Debug Logger.
    /// </summary>
    [Target("Debug")]
    public sealed class DebugLogger : TraceLogger, System.IDisposable
    {
        #region Atributos privados
        /// <summary>
        /// Ruta de almacenamiento de ficheros de error de logger.
        /// </summary>
        private PathLogger _pathError;
        /// <summary>
        /// Escucha las notificaciones de cambio del sistema de archivos y provoca eventos
        /// cuando cambia un directorio o un archivo de un directorio. �til para backups
        /// de logger por tama�o.
        /// </summary>
        private System.IO.FileSystemWatcher _watcher;
        #endregion

        #region Delegados p�blicos
        /// <summary>
        /// Evento que se ejecuta tras ejecutar la Callback.
        /// </summary>
        public event System.EventHandler OnDespuesCrearBackup;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensi�n=log</c>, <c>Hora de ejecuci�n=23:00:00</c>, <c>Periodo de ejecuci�n=24h</c>, <c>PathBackup=Application.StartupPath\BLog</c>, <c>M�scara=aaaaMM</c>.
        /// </summary>
        public DebugLogger()
            : this(string.Empty) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensi�n=log</c>, <c>Hora de ejecuci�n=23:00:00</c>, <c>Periodo de ejecuci�n=24h</c>, <c>PathBackup=Application.StartupPath\BLog</c>, <c>M�scara=aaaaMM</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        public DebugLogger(string identificador)
            : base(identificador) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensi�n=log</c>, <c>Hora de ejecuci�n=23:00:00</c>, <c>Periodo de ejecuci�n=24h</c>, <c>PathBackup=Application.StartupPath\BLog</c>, <c>M�scara=aaaaMM</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger. Por defecto, <c>NivelLog.Debug</c>.</param>
        public DebugLogger(string identificador, NivelLog nivelLog)
            : base(identificador, nivelLog) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>Hora de ejecuci�n=23:00:00</c>, <c>Periodo de ejecuci�n=24h</c>, <c>PathBackup=Application.StartupPath\BLog</c>, <c>M�scara=aaaaMM</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="pathLogger">Ruta de almacenamiento del fichero de logger.</param>
        public DebugLogger(string identificador, PathLogger pathLogger)
            : base(identificador, pathLogger) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>Hora de ejecuci�n=23:00:00</c>, <c>Periodo de ejecuci�n=24h</c>, <c>PathBackup=Application.StartupPath\BLog</c>, <c>M�scara=aaaaMM</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger. Por defecto, <c>NivelLog.Debug</c>.</param>
        /// <param name="pathLogger">Ruta de almacenamiento del fichero de logger.</param>
        public DebugLogger(string identificador, NivelLog nivelLog, PathLogger pathLogger)
            : base(identificador, nivelLog, pathLogger) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensi�n=log</c>, <c>PathBackup=Application.StartupPath\BLog</c>, <c>M�scara=aaaaMM</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="timerBackup">Objeto que representa el periodo de tiempo de inicio de backup logger y tiempo entre invocaciones.</param>
        public DebugLogger(string identificador, TimerBackup timerBackup)
            : this(identificador, NivelLog.Debug, timerBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensi�n=log</c>, <c>PathBackup=Application.StartupPath\BLog</c>, <c>M�scara=aaaaMM</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="sizeBackup">Tama�o m�ximo de logger hasta generar backup en bytes.</param>
        [System.Security.Permissions.EnvironmentPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Unrestricted = true)]
        public DebugLogger(string identificador, long sizeBackup)
            : this(identificador, NivelLog.Debug, sizeBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensi�n=log</c>, <c>PathBackup=Application.StartupPath\BLog</c>, <c>M�scara=aaaaMM</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger. Por defecto, <c>NivelLog.Debug</c>.</param>
        /// <param name="timerBackup">Objeto que representa el periodo de tiempo de inicio de backup logger y tiempo entre invocaciones.</param>
        public DebugLogger(string identificador, NivelLog nivelLog, TimerBackup timerBackup)
            : this(identificador, nivelLog, new PathLogger(), timerBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensi�n=log</c>, <c>PathBackup=Application.StartupPath\BLog</c>, <c>M�scara=aaaaMM</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger. Por defecto, <c>NivelLog.Debug</c>.</param>
        /// <param name="sizeBackup">Tama�o m�ximo de logger hasta generar backup en bytes.</param>
        [System.Security.Permissions.EnvironmentPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Unrestricted = true)]
        public DebugLogger(string identificador, NivelLog nivelLog, long sizeBackup)
            : this(identificador, nivelLog, new PathLogger(), sizeBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>PathBackup=Application.StartupPath\BLog</c>, <c>M�scara=aaaaMM</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="pathLogger">Ruta de almacenamiento del fichero de logger.</param>
        /// <param name="timerBackup">Objeto que representa el periodo de tiempo de inicio de backup logger y tiempo entre invocaciones.</param>
        public DebugLogger(string identificador, PathLogger pathLogger, TimerBackup timerBackup)
            : this(identificador, NivelLog.Debug, pathLogger, timerBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>PathBackup=Application.StartupPath\BLog</c>, <c>M�scara=aaaaMM</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="pathLogger">Ruta de almacenamiento del fichero de logger.</param>
        /// <param name="sizeBackup">Tama�o m�ximo de logger hasta generar backup en bytes.</param>
        [System.Security.Permissions.EnvironmentPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Unrestricted = true)]
        public DebugLogger(string identificador, PathLogger pathLogger, long sizeBackup)
            : this(identificador, NivelLog.Debug, pathLogger, sizeBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>PathBackup=Application.StartupPath\BLog</c>, <c>M�scara=aaaaMM</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger. Por defecto, <c>NivelLog.Debug</c>.</param>
        /// <param name="pathLogger">Ruta de almacenamiento del fichero de logger.</param>
        /// <param name="timerBackup">Objeto que representa el periodo de tiempo de inicio de backup logger y tiempo entre invocaciones.</param>
        public DebugLogger(string identificador, NivelLog nivelLog, PathLogger pathLogger, TimerBackup timerBackup)
            : this(identificador, nivelLog, pathLogger, timerBackup, new PathBackup()) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>PathBackup=Application.StartupPath\BLog</c>, <c>M�scara=aaaaMM</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger. Por defecto, <c>NivelLog.Debug</c>.</param>
        /// <param name="pathLogger">Ruta de almacenamiento del fichero de logger.</param>
        /// <param name="sizeBackup">Tama�o m�ximo de logger hasta generar backup en bytes.</param>
        [System.Security.Permissions.EnvironmentPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Unrestricted = true)]
        public DebugLogger(string identificador, NivelLog nivelLog, PathLogger pathLogger, long sizeBackup)
            : this(identificador, nivelLog, pathLogger, sizeBackup, new PathBackup()) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensi�n=log</c>, <c>Hora de ejecuci�n=23:00:00</c>, <c>Periodo de ejecuci�n=24h</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="pathBackup">Ruta de almacenamiento del fichero de backup de logger.</param>
        public DebugLogger(string identificador, PathBackup pathBackup)
            : this(identificador, NivelLog.Debug, new TimerBackup(), pathBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensi�n=log</c>, <c>Hora de ejecuci�n=23:00:00</c>, <c>Periodo de ejecuci�n=24h</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger. Por defecto, <c>NivelLog.Debug</c>.</param>
        /// <param name="pathBackup">Ruta de almacenamiento del fichero de backup de logger.</param>
        public DebugLogger(string identificador, NivelLog nivelLog, PathBackup pathBackup)
            : this(identificador, nivelLog, new PathLogger(), new TimerBackup(), pathBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>Hora de ejecuci�n=23:00:00</c>, <c>Periodo de ejecuci�n=24h</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="pathLogger">Ruta de almacenamiento del fichero de logger.</param>
        /// <param name="pathBackup">Ruta de almacenamiento del fichero de backup de logger.</param>
        public DebugLogger(string identificador, PathLogger pathLogger, PathBackup pathBackup)
            : this(identificador, NivelLog.Debug, pathLogger, new TimerBackup(), pathBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>Hora de ejecuci�n=23:00:00</c>, <c>Periodo de ejecuci�n=24h</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger. Por defecto, <c>NivelLog.Debug</c>.</param>
        /// <param name="pathLogger">Ruta de almacenamiento del fichero de logger.</param>
        /// <param name="pathBackup">Ruta de almacenamiento del fichero de backup de logger.</param>
        public DebugLogger(string identificador, NivelLog nivelLog, PathLogger pathLogger, PathBackup pathBackup)
            : this(identificador, nivelLog, pathLogger, new TimerBackup(), pathBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensi�n=log</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="timerBackup">Objeto que representa el periodo de tiempo de inicio de backup logger y tiempo entre invocaciones.</param>
        /// <param name="pathBackup">Ruta de almacenamiento del fichero de backup de logger.</param>
        public DebugLogger(string identificador, TimerBackup timerBackup, PathBackup pathBackup)
            : this(identificador, NivelLog.Debug, timerBackup, pathBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensi�n=log</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="sizeBackup">Tama�o m�ximo de logger hasta generar backup en bytes.</param>
        /// <param name="pathBackup">Ruta de almacenamiento del fichero de backup de logger.</param>
        [System.Security.Permissions.EnvironmentPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Unrestricted = true)]
        public DebugLogger(string identificador, long sizeBackup, PathBackup pathBackup)
            : this(identificador, NivelLog.Debug, sizeBackup, pathBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensi�n=log</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger. Por defecto, <c>NivelLog.Debug</c>.</param>
        /// <param name="timerBackup">Objeto que representa el periodo de tiempo de inicio de backup logger y tiempo entre invocaciones.</param>
        /// <param name="pathBackup">Ruta de almacenamiento del fichero de backup de logger.</param>
        public DebugLogger(string identificador, NivelLog nivelLog, TimerBackup timerBackup, PathBackup pathBackup)
            : this(identificador, nivelLog, new PathLogger(), timerBackup, pathBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>PathLogger=Application.StartupPath\Log</c>, <c>Fichero=debug</c>, <c>Extensi�n=log</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger. Por defecto, <c>NivelLog.Debug</c>.</param>
        /// <param name="sizeBackup">Tama�o m�ximo de logger hasta generar backup en bytes.</param>
        /// <param name="pathBackup">Ruta de almacenamiento del fichero de backup de logger.</param>
        [System.Security.Permissions.EnvironmentPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Unrestricted = true)]
        public DebugLogger(string identificador, NivelLog nivelLog, long sizeBackup, PathBackup pathBackup)
            : this(identificador, nivelLog, new PathLogger(), sizeBackup, pathBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>NivelLog=Debug</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="pathLogger">Ruta de almacenamiento del fichero de logger.</param>
        /// <param name="timerBackup">Objeto que representa el periodo de tiempo de inicio de backup logger y tiempo entre invocaciones.</param>
        /// <param name="pathBackup">Ruta de almacenamiento del fichero de backup de logger.</param>
        public DebugLogger(string identificador, PathLogger pathLogger, TimerBackup timerBackup, PathBackup pathBackup)
            : this(identificador, NivelLog.Debug, pathLogger, timerBackup, pathBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// Por defecto, <c>NivelLog=Debug</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="pathLogger">Ruta de almacenamiento del fichero de logger.</param>
        /// <param name="sizeBackup">Tama�o m�ximo de logger hasta generar backup en bytes.</param>
        /// <param name="pathBackup">Ruta de almacenamiento del fichero de backup de logger.</param>
        [System.Security.Permissions.EnvironmentPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Unrestricted = true)]
        public DebugLogger(string identificador, PathLogger pathLogger, long sizeBackup, PathBackup pathBackup)
            : this(identificador, NivelLog.Debug, pathLogger, sizeBackup, pathBackup) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger. Por defecto, <c>NivelLog.Debug</c>.</param>
        /// <param name="pathLogger">Ruta de almacenamiento del fichero de logger.</param>
        /// <param name="timerBackup">Objeto que representa el periodo de tiempo de inicio de backup logger y tiempo entre invocaciones.</param>
        /// <param name="pathBackup">Ruta de almacenamiento del fichero de backup de logger.</param>
        public DebugLogger(string identificador, NivelLog nivelLog, PathLogger pathLogger, TimerBackup timerBackup, PathBackup pathBackup)
            : base(identificador, nivelLog, pathLogger)
        {
            SetPathLogger(pathLogger);
            SetPathBackup(pathBackup);
            SetTimerBackup(timerBackup);
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.DebugLogger.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger. Por defecto, <c>NivelLog.Debug</c>.</param>
        /// <param name="pathLogger">Ruta de almacenamiento del fichero de logger.</param>
        /// <param name="sizeBackup">Tama�o m�ximo de logger hasta generar backup en bytes.</param>
        /// <param name="pathBackup">Ruta de almacenamiento del fichero de backup de logger.</param>
        [System.Security.Permissions.EnvironmentPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Unrestricted = true)]
        public DebugLogger(string identificador, NivelLog nivelLog, PathLogger pathLogger, long sizeBackup, PathBackup pathBackup)
            : this(identificador, nivelLog, pathLogger, null, pathBackup)
        {
            SetFileSystemWatcher(sizeBackup);
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Implementa IDisposable.
        /// No  hacer  este  m�todo  virtual.
        /// Una clase derivada no deber�a ser
        /// capaz de  reemplazar este m�todo.
        /// </summary>
        public void Dispose()
        {
            _watcher.Dispose();
        }
        #endregion

        #region Propiedades p�blicas
        /// <summary>
        /// Ruta de almacenamiento del fichero de logger.
        /// </summary>
        public override PathLogger PathLogger
        {
            get { return Path; }
            set { Path = value; }
        }
        /// <summary>
        /// Ruta de almacenamiento del fichero de backup de logger.
        /// </summary>
        public PathBackup PathBackup { get; set; }
        /// <summary>
        /// Ruta de almacenamiento del fichero de error de logger.
        /// </summary>
        public PathLogger PathError
        {
            get { return _pathError; }
            set
            {
                if (value == null) return;
                _pathError = new PathLogger(value.Path, string.Concat(value.Fichero, "-", Trazabilidad.Fichero.Error), value.Extension);
                Listener = new System.Diagnostics.TextWriterTraceListener(_pathError.ToString());
            }
        }
        /// <summary>
        /// Tiempo de inicio y periodo de ejecuci�n de backups de logger. Propiedad de solo lectura.
        /// </summary>
        public TimerLogger TimerLogger { get; private set; }
        /// <summary>
        /// Tama�o m�ximo de logger.
        /// </summary>
        public long SizeBackup { get; set; }
        /// <summary>
        /// Separador para fichero logger.
        /// </summary>
        public override string Separador
        {
            get { return separador; }
            set { separador = value; }
        }
        /// <summary>
        /// Permitir incluir retornos de carro en los mensajes de logger. Por defecto, false.
        /// </summary>
        public override bool RetornoCarro
        {
            get { return RetornoDeCarro; }
            set { RetornoDeCarro = value; }
        }
        /// <summary>
        /// Ruta completa de almacenamiento del fichero de logger.
        /// </summary>
        public override string Fichero
        {
            get { return Path.ToString(); }
        }
        #endregion

        #region Propiedades privadas
        /// <summary>
        /// Nombre del fichero del backup de logger.
        /// </summary>
        private string FicheroBackup
        {
            get
            {
                // Fecha actual, necesaria para la generaci�n de la m�scara de path de backup logger.
                System.DateTime fecha = System.DateTime.Now;
                // Crear el nuevo objeto de path de backup logger completo.
                // Asignar el path (pathlogger), nombre del fichero destino y extensi�n.
                var pathBackupFull = new PathLogger(PathBackup.Path, string.Format(System.Globalization.CultureInfo.CurrentCulture, @"{0}-{1}-{2}", PathLogger.Fichero, fecha.ToString(Formato.A�oMesDia, System.Globalization.CultureInfo.CurrentCulture), fecha.ToString(Formato.HoraMinutoSegundoCentesima, System.Globalization.CultureInfo.CurrentCulture)), PathLogger.Extension);
                // Formato del subpath de backup.
                string formato = PathBackup.Mascara;
                if (!string.IsNullOrEmpty(formato))
                {
                    pathBackupFull.Path = string.Format(System.Globalization.CultureInfo.CurrentCulture, @"{0}\{1}", PathBackup.Path, fecha.ToString(formato, System.Globalization.CultureInfo.CurrentCulture));
                }
                return pathBackupFull.ToString();
            }
        }
        #endregion

        #region M�todos privados
        /// <summary>
        /// M�todo de proceso de Callback.
        /// </summary>
        /// <param name="estado">Estado de la Callback.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void ProcesoBackup(object estado)
        {
            try
            {
                lock (Bloqueo)
                {
                    // Si existe el fichero origen (por defecto, debug.log).
                    if (!PathLogger.ExisteFichero()) return;
                    // Establecer tama�o del buffer.
                    const int bufferSize = 1024 * 1024;
                    using (var origen = new System.IO.FileStream(Fichero, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    using (var destino = new System.IO.FileStream(FicheroBackup, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
                    {
                        // Establecer la longitud de la secuencia.
                        destino.SetLength(origen.Length);
                        int bytesRead;
                        var bytes = new byte[bufferSize];
                        // Leer los bytes de la secuencia y escribir los datos en un b�fer dado.
                        while ((bytesRead = origen.Read(bytes, 0, bufferSize)) > 0)
                        {
                            // Escribir lo bloques de esta secuencia mediante el uso de datos de un b�fer.
                            destino.Write(bytes, 0, bytesRead);
                        }
                    }
                    // Eliminar el fichero origen (por defecto, debug.log).
                    if (!PathLogger.BorrarFichero())
                    {
                        throw new System.Exception(string.Format(System.Globalization.CultureInfo.CurrentCulture, "No se ha podido eliminar el archivo {0}", Fichero));
                    }
                    // En C# debemos comprobar que el evento no sea null.
                    if (OnDespuesCrearBackup != null)
                    {
                        // El evento se lanza como cualquier delegado.
                        OnDespuesCrearBackup(this, System.EventArgs.Empty);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Escribir(ex);
            }
        }
        #endregion

        #region M�todos p�blicos
        /// <summary>
        /// Asignar el objeto path.
        /// </summary>
        /// <param name="pathLogger">Objeto path logger.</param>
        public void SetPathLogger(PathLogger pathLogger)
        {
            if (pathLogger != null)
            {
                // Componer y asignar el listeners de trazas generadas en excepciones de logger.
                PathError = pathLogger;
            }
        }
        /// <summary>
        /// Asignar el objeto backup.
        /// </summary>
        /// <param name="path">Objeto path backup.</param>
        public void SetPathBackup(PathBackup path)
        {
            if (path != null)
            {
                // Asignar path de backup de logger.
                PathBackup = path;
            }
        }
        /// <summary>
        /// Asignar el objeto timer backup.
        /// </summary>
        /// <param name="timerBackup">Objeto timer backup.</param>
        public void SetTimerBackup(TimerBackup timerBackup)
        {
            if (timerBackup == null) return;
            // Asignar el timer adecuado de copias backup, en tiempo y periodo.
            // Crear el objeto p�blico, para permitir desde fuera destruir el timer.
            TimerLogger = new TimerLogger { CallBack = ProcesoBackup };
            TimerLogger.Timer = new System.Threading.Timer(TimerLogger.CallBack);
            TimerLogger.Change(timerBackup.Hora, timerBackup.Periodo);
        }
        /// <summary>
        /// Asignar el objeto System.IO.FileSystemWatcher.
        /// </summary>
        /// <param name="size">Tama�o m�ximo de logger.</param>
        [System.Security.Permissions.EnvironmentPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Unrestricted = true)]
        public void SetFileSystemWatcher(long size)
        {
            // Tama�o m�ximo de logger hasta hacer backup.
            SizeBackup = size;
            // Crear un vigilante de archivos del sistema.
            _watcher = new System.IO.FileSystemWatcher
                {
                    Path = System.IO.Path.GetFullPath(PathLogger.Path),
                    Filter = "*." + PathLogger.Extension,
                    NotifyFilter = System.IO.NotifyFilters.Size,
                    IncludeSubdirectories = false
                };
            // Asignar la ruta que se quiere monitorizar.
            // No incluir subdirectorios en la ruta de monitorizaci�n.
            // Asignar el evento de cambio.
            _watcher.Changed += Watcher_Changed;
            //
            // Comenzar la exploraci�n de tama�o de logger.
            _watcher.EnableRaisingEvents = true;
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Watcher_Changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                bool backup;
                lock (Bloqueo)
                {
                    backup = false;
                    // Si existe el fichero origen (por defecto, debug.log).
                    var logger = new System.IO.FileInfo(e.FullPath);
                    if (logger.Exists)
                    {
                        // Si el tama�o del fichero en bytes es igual o superior al establecido
                        // procesar el backup correspondiente.
                        backup = logger.Length.CompareTo(SizeBackup) >= 0;
                    }
                }
                // Control de backup fuera del bloqueo.
                if (backup)
                {
                    ProcesoBackup(null);
                }
            }
            catch (System.Exception ex)
            {
                Escribir(ex);
            }
        }
        #endregion
    }
}