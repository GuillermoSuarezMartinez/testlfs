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
    /// Base Logger.
    /// </summary>
    public abstract class BaseLogger : ILogger
    {
        #region Atributos privados
        /// <summary>
        /// Identificador de logger.
        /// </summary>
        string identificador;
        /// <summary>
        /// Nivel de logger.
        /// </summary>
        NivelLog nivelLog;
        /// <summary>
        /// Identificador alfanum�rico de logger.
        /// Trazable en la trama. �til si varios logger escriben en el mismo fichero.
        /// </summary>
        string sid;
        /// <summary>
        /// Atributo asociada al delegado de traza de nivel y SID.
        /// </summary>
        NivelSID trazarNivel;
        #endregion

        #region Delegado
        /// <summary>
        /// Delegado din�mico de traza de nivel y SID.
        /// </summary>
        /// <param name="item">Item de entrada.</param>
        /// <returns>Cadena de nivel formateada.</returns>
        protected delegate string NivelSID(ItemLog item);
        #endregion

        #region Eventos
        /// <summary>
        /// Evento que se ejecuta antes de escribir en el fichero de logger.
        /// </summary>
        public event System.EventHandler<LoggerEventArgs> AntesEscribirLogger;
        /// <summary>
        /// Evento que se ejecuta tras escribir en el fichero de logger.
        /// </summary>
        public event System.EventHandler<LoggerEventArgs> DespuesEscribirLogger;
        /// <summary>
        /// Evento que se ejecuta tras producirse un error en la escritura en el fichero de logger.
        /// </summary>
        public event System.EventHandler<LoggerEventArgs> ErrorLogger;
        #endregion

        #region Constructores protegidos
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.BaseLogger.
        /// </summary>
        protected BaseLogger() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.BaseLogger.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        protected BaseLogger(string identificador, NivelLog nivelLog)
        {
            this.identificador = identificador;
            this.nivelLog = nivelLog;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Identificador de logger.
        /// </summary>
        public string Identificador
        {
            get { return this.identificador; }
            set { this.identificador = value; }
        }
        /// <summary>
        /// Nivel de logger.
        /// </summary>
        public NivelLog NivelLog
        {
            get { return this.nivelLog; }
            set { this.nivelLog = value; }
        }
        /// <summary>
        /// Identificador alfanum�rico de logger.
        /// </summary>
        public string SID
        {
            get { return this.sid; }
            set 
            { 
                this.sid = value;
                // Asignaci�n del m�todo delegado din�mico de traza de nivel.
                this.trazarNivel = new NivelSID(Nivel);
            }
        }
        #endregion

        #region Propiedades protegidas
        /// <summary>
        /// Propiedad asociada al delegado de traza de nivel y SID.
        /// </summary>
        protected NivelSID TrazarNivel
        {
            get { return this.trazarNivel; }
            set { this.trazarNivel = value; }
        }
        #endregion

        #region M�todos p�blicos

        #region Debug
        /// <summary>
        /// Logger de tipo debug.
        /// </summary>
        /// <param name="objeto">Objeto que encapsula un mensaje.</param>
        public void Debug(object objeto)
        {
            if (ESNivelLogEnabled(NivelLog.Debug))
            {
                Log(NivelLog.Debug, objeto != null ? objeto.ToString() : Orbita.Trazabilidad.E.Nulo);
            }
        }
        /// <summary>
        /// Logger de tipo debug.
        /// </summary>
        /// <param name="mensaje">Mensaje de logger.</param>
        public void Debug(string mensaje)
        {
            if (ESNivelLogEnabled(NivelLog.Debug))
            {
                Log(NivelLog.Debug, mensaje);
            }
        }
        /// <summary>
        /// Logger de tipo debug.
        /// </summary>
        /// <param name="mensaje">Mensaje de logger.</param>
        /// <param name="args">Argumentos de inclusi�n.</param>
        public void Debug(string mensaje, params object[] args)
        {
            if (ESNivelLogEnabled(NivelLog.Debug))
            {
                Log(NivelLog.Debug, mensaje, args);
            }
        }
        /// <summary>
        /// Logger de tipo debug.
        /// </summary>
        /// <param name="excepcion">Excepci�n.</param>
        public void Debug(System.Exception excepcion)
        {
            if (ESNivelLogEnabled(NivelLog.Debug))
            {
                Log(NivelLog.Debug, excepcion);
            }
        }
        /// <summary>
        /// Logger de tipo debug.
        /// </summary>
        /// <param name="excepcion">Excepci�n.</param>
        /// <param name="mensaje">Mensaje de logger.</param>
        public void Debug(System.Exception excepcion, string mensaje)
        {
            if (ESNivelLogEnabled(NivelLog.Debug))
            {
                Log(NivelLog.Debug, excepcion, mensaje);
            }
        }
        /// <summary>
        /// Logger de tipo debug.
        /// </summary>
        /// <param name="excepcion">Excepci�n.</param>
        /// <param name="mensaje">Mensaje de logger.</param>
        /// <param name="args">Argumentos de inclusi�n.</param>
        public void Debug(System.Exception excepcion, string mensaje, params object[] args)
        {
            if (ESNivelLogEnabled(NivelLog.Debug))
            {
                Log(NivelLog.Debug, excepcion, mensaje, args);
            }
        }
        #endregion Debug

        #region Info
        /// <summary>
        /// Logger de tipo info.
        /// </summary>
        /// <param name="objeto">Objeto que encapsula un mensaje.</param>
        public void Info(object objeto)
        {
            if (ESNivelLogEnabled(NivelLog.Info))
            {
                Log(NivelLog.Info, objeto != null ? objeto.ToString() : Orbita.Trazabilidad.E.Nulo);
            }
        }
        /// <summary>
        /// Logger de tipo info.
        /// </summary>
        /// <param name="mensaje">Mensaje de logger.</param>
        public void Info(string mensaje)
        {
            if (ESNivelLogEnabled(NivelLog.Info))
            {
                Log(NivelLog.Info, mensaje);
            }
        }
        /// <summary>
        /// Logger de tipo info.
        /// </summary>
        /// <param name="mensaje">Mensaje de logger.</param>
        /// <param name="args">Argumentos de inclusi�n.</param>
        public void Info(string mensaje, params object[] args)
        {
            if (ESNivelLogEnabled(NivelLog.Info))
            {
                Log(NivelLog.Info, mensaje, args);
            }
        }
        /// <summary>
        /// Logger de tipo info.
        /// </summary>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        public void Info(System.Exception excepcion)
        {
            if (ESNivelLogEnabled(NivelLog.Info))
            {
                Log(NivelLog.Info, excepcion);
            }
        }
        /// <summary>
        /// Logger de tipo info.
        /// </summary>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        /// <param name="mensaje">Mensaje de logger.</param>
        public void Info(System.Exception excepcion, string mensaje)
        {
            if (ESNivelLogEnabled(NivelLog.Info))
            {
                Log(NivelLog.Info, excepcion, mensaje);
            }
        }
        /// <summary>
        /// Logger de tipo info.
        /// </summary>
        /// <param name="excepcion"></param>
        /// <param name="mensaje">Mensaje de logger.</param>
        /// <param name="args">Argumentos de inclusi�n.</param>
        public void Info(System.Exception excepcion, string mensaje, params object[] args)
        {
            if (ESNivelLogEnabled(NivelLog.Info))
            {
                Log(NivelLog.Info, excepcion, mensaje, args);
            }
        }
        #endregion Info

        #region Warn
        /// <summary>
        /// Logger de tipo Warn.
        /// </summary>
        /// <param name="objeto">Objeto que encapsula un mensaje.</param>
        public void Warn(object objeto)
        {
            if (ESNivelLogEnabled(NivelLog.Warn))
            {
                Log(NivelLog.Warn, objeto != null ? objeto.ToString() : Orbita.Trazabilidad.E.Nulo);
            }
        }
        /// <summary>
        /// Logger de tipo Warn.
        /// </summary>
        /// <param name="mensaje">Mensaje de logger.</param>
        public void Warn(string mensaje)
        {
            if (ESNivelLogEnabled(NivelLog.Warn))
            {
                Log(NivelLog.Warn, mensaje);
            }
        }
        /// <summary>
        /// Logger de tipo Warn.
        /// </summary>
        /// <param name="mensaje">Mensaje de logger.</param>
        /// <param name="args">Argumentos de inclusi�n.</param>
        public void Warn(string mensaje, params object[] args)
        {
            if (ESNivelLogEnabled(NivelLog.Warn))
            {
                Log(NivelLog.Warn, mensaje, args);
            }
        }
        /// <summary>
        /// Logger de tipo Warn.
        /// </summary>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        public void Warn(System.Exception excepcion)
        {
            if (ESNivelLogEnabled(NivelLog.Warn))
            {
                Log(NivelLog.Warn, excepcion);
            }
        }
        /// <summary>
        /// Logger de tipo Warn.
        /// </summary>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        /// <param name="mensaje">Mensaje de logger.</param>
        public void Warn(System.Exception excepcion, string mensaje)
        {
            if (ESNivelLogEnabled(NivelLog.Warn))
            {
                Log(NivelLog.Warn, excepcion, mensaje);
            }
        }
        /// <summary>
        /// Logger de tipo Warn.
        /// </summary>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        /// <param name="mensaje">Mensaje de logger.</param>
        /// <param name="args">Argumentos de inclusi�n.</param>
        public void Warn(System.Exception excepcion, string mensaje, params object[] args)
        {
            if (ESNivelLogEnabled(NivelLog.Warn))
            {
                Log(NivelLog.Warn, excepcion, mensaje, args);
            }
        }
        #endregion Warn

        #region Error
        /// <summary>
        /// Logger de tipo error.
        /// </summary>
        /// <param name="objeto">Objeto que encapsula un mensaje.</param>
        public void Error(object objeto)
        {
            if (ESNivelLogEnabled(NivelLog.Error))
            {
                Log(NivelLog.Error, objeto != null ? objeto.ToString() : Orbita.Trazabilidad.E.Nulo);
            }
        }
        /// <summary>
        /// Logger de tipo error.
        /// </summary>
        /// <param name="mensaje">Mensaje de logger.</param>
        public void Error(string mensaje)
        {
            if (ESNivelLogEnabled(NivelLog.Error))
            {
                Log(NivelLog.Error, mensaje);
            }
        }
        /// <summary>
        /// Logger de tipo error.
        /// </summary>
        /// <param name="mensaje">Mensaje de logger.</param>
        /// <param name="args">Argumentos de inclusi�n.</param>
        public void Error(string mensaje, params object[] args)
        {
            if (ESNivelLogEnabled(NivelLog.Error))
            {
                Log(NivelLog.Error, mensaje, args);
            }
        }
        /// <summary>
        /// Logger de tipo error.
        /// </summary>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        public void Error(System.Exception excepcion)
        {
            if (ESNivelLogEnabled(NivelLog.Error))
            {
                Log(NivelLog.Error, excepcion);
            }
        }
        /// <summary>
        /// Logger de tipo error.
        /// </summary>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        /// <param name="mensaje">Mensaje de logger.</param>
        public void Error(System.Exception excepcion, string mensaje)
        {
            if (ESNivelLogEnabled(NivelLog.Error))
            {
                Log(NivelLog.Error, excepcion, mensaje);
            }
        }
        /// <summary>
        /// Logger de tipo error.
        /// </summary>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        /// <param name="mensaje">Mensaje de logger.</param>
        /// <param name="args">Argumentos de inclusi�n.</param>
        public void Error(System.Exception excepcion, string mensaje, params object[] args)
        {
            if (ESNivelLogEnabled(NivelLog.Error))
            {
                Log(NivelLog.Error, excepcion, mensaje, args);
            }
        }
        #endregion Error

        #region Fatal
        /// <summary>
        /// Logger de tipo error fatal.
        /// </summary>
        /// <param name="objeto">Objeto que encapsula un mensaje.</param>
        public void Fatal(object objeto)
        {
            if (ESNivelLogEnabled(NivelLog.Fatal))
            {
                Log(NivelLog.Fatal, objeto != null ? objeto.ToString() : Orbita.Trazabilidad.E.Nulo);
            }
        }
        /// <summary>
        /// Logger de tipo error fatal.
        /// </summary>
        /// <param name="mensaje">Mensaje de logger.</param>
        public void Fatal(string mensaje)
        {
            if (ESNivelLogEnabled(NivelLog.Fatal))
            {
                Log(NivelLog.Fatal, mensaje);
            }
        }
        /// <summary>
        /// Logger de tipo error fatal.
        /// </summary>
        /// <param name="mensaje">Mensaje de logger.</param>
        /// <param name="args">Argumentos de inclusi�n.</param>
        public void Fatal(string mensaje, params object[] args)
        {
            if (ESNivelLogEnabled(NivelLog.Fatal))
            {
                Log(NivelLog.Fatal, mensaje, args);
            }
        }
        /// <summary>
        /// Logger de tipo error fatal.
        /// </summary>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        public void Fatal(System.Exception excepcion)
        {
            if (ESNivelLogEnabled(NivelLog.Fatal))
            {
                Log(NivelLog.Fatal, excepcion);
            }
        }
        /// <summary>
        /// Logger de tipo error fatal.
        /// </summary>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        /// <param name="mensaje">Mensaje de logger.</param>
        public void Fatal(System.Exception excepcion, string mensaje)
        {
            if (ESNivelLogEnabled(NivelLog.Fatal))
            {
                Log(NivelLog.Fatal, excepcion, mensaje);
            }
        }
        /// <summary>
        /// Logger de tipo error fatal.
        /// </summary>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        /// <param name="mensaje">Mensaje de logger.</param>
        /// <param name="args">Argumentos de inclusi�n.</param>
        public void Fatal(System.Exception excepcion, string mensaje, params object[] args)
        {
            if (ESNivelLogEnabled(NivelLog.Fatal))
            {
                Log(NivelLog.Fatal, excepcion, mensaje, args);
            }
        }
        #endregion Fatal

        #region Log
        /// <summary>
        /// Crea una entrada de registro nuevo basado en un elemento de inicio de sesi�n dado.
        /// </summary>
        /// <param name="item">Encapsula la informaci�n de registro.</param>
        public abstract void Log(ItemLog item);
        /// <summary>
        /// Crea una entrada de registro nuevo basado en un elemento de inicio de sesi�n dado.
        /// </summary>
        /// <param name="item">Encapsula la informaci�n de registro.</param>
        /// <param name="args">Argumentos adicionales.</param>
        public abstract void Log(ItemLog item, object[] args);
        /// <summary>
        /// Crea una entrada de registro nuevo basado en un elemento de inicio de sesi�n dado.
        /// </summary>
        /// <param name="nivel">Nivel de logger.</param>
        /// <param name="mensaje">Mensaje de logger.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope")]
        public virtual void Log(NivelLog nivel, string mensaje)
        {
            ItemLog item = new ItemLog(nivel, mensaje);
            // Argumentos relativos al evento de escritura.
            LoggerEventArgs e = new LoggerEventArgs(item);
            // El evento se lanza como cualquier delegado.
            this.OnAntesEscribirLogger(this, e);
            Log(item);
        }
        /// <summary>
        /// Crea una entrada de registro nuevo basado en un elemento de inicio de sesi�n dado.
        /// </summary>
        /// <param name="nivel">Nivel de logger.</param>
        /// <param name="mensaje">Mensaje de logger.</param>
        /// <param name="args">Argumentos de inclusi�n.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope")]
        public virtual void Log(NivelLog nivel, string mensaje, params object[] args)
        {
            ItemLog item = new ItemLog(nivel, mensaje);
            item.SetArgumentos(args);
            // Argumentos relativos al evento de escritura.
            LoggerArgsEventArgs e = new LoggerArgsEventArgs(item);
            e.SetArgumentos(args);
            // El evento se lanza como cualquier delegado.
            this.OnAntesEscribirLogger(this, e);
            Log(item, args);
        }
        /// <summary>
        /// Crea una entrada de registro nuevo basado en un elemento de inicio de sesi�n dado.
        /// </summary>
        /// <param name="nivel">Nivel de logger.</param>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope")]
        public virtual void Log(NivelLog nivel, System.Exception excepcion)
        {
            ItemLog item = new ItemLog(nivel, excepcion);
            // Argumentos relativos al evento de escritura.
            LoggerEventArgs e = new LoggerEventArgs(item, excepcion);
            // El evento se lanza como cualquier delegado.
            this.OnAntesEscribirLogger(this, e);
            Log(item);
        }
        /// <summary>
        /// Crea una entrada de registro nuevo basado en un elemento de inicio de sesi�n dado.
        /// </summary>
        /// <param name="nivel">Nivel de logger.</param>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        /// <param name="mensaje">Mensaje de logger.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope")]
        public virtual void Log(NivelLog nivel, System.Exception excepcion, string mensaje)
        {
            ItemLog item = new ItemLog(nivel, excepcion, mensaje);
            // Argumentos relativos al evento de escritura.
            LoggerEventArgs e = new LoggerEventArgs(item, excepcion);
            // El evento se lanza como cualquier delegado.
            this.OnAntesEscribirLogger(this, e);
            Log(item);
        }
        /// <summary>
        /// Crea una entrada de registro nuevo basado en un elemento de inicio de sesi�n dado.
        /// </summary>
        /// <param name="nivel">Nivel de logger.</param>
        /// <param name="excepcion">Excepci�n de inclusi�n.</param>
        /// <param name="mensaje">Mensaje de logger.</param>
        /// <param name="args">Argumentos de inclusi�n.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope")]
        public virtual void Log(NivelLog nivel, System.Exception excepcion, string mensaje, params object[] args)
        {
            ItemLog item = new ItemLog(nivel, excepcion, mensaje);
            item.SetArgumentos(args);
            // Argumentos relativos al evento de escritura.
            LoggerArgsEventArgs e = new LoggerArgsEventArgs(item, excepcion);
            e.SetArgumentos(args);
            // El evento se lanza como cualquier delegado.
            this.OnAntesEscribirLogger(this, e);
            Log(item, args);
        }
        #endregion Log

        #endregion M�todos p�blicos

        #region M�todos protegidos
        /// <summary>
        /// M�todo escalable de inclusi�n de logger.
        /// </summary>
        /// <param name="nivel">Nivel de logger.</param>
        /// <returns>Indica si el nivel de logger se incluye en el tipo de definido.</returns>
        protected virtual bool ESNivelLogEnabled(NivelLog nivel)
        {
            return nivel >= this.NivelLog;
        }
        /// <summary>
        /// Evento que se ejecuta antes de escribir en el fichero de logger.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">Orbita.Trazabilidad.LoggerEventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected virtual void OnAntesEscribirLogger(object sender, LoggerEventArgs e)
        {
            if (this.AntesEscribirLogger != null)
            {
                this.AntesEscribirLogger(this, e);
            }
        }
        /// <summary>
        /// Evento que se ejecuta tras escribir en el fichero de logger.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">Orbita.Trazabilidad.LoggerEventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected virtual void OnDespuesEscribirLogger(object sender, LoggerEventArgs e)
        {
            if (this.DespuesEscribirLogger != null)
            {
                this.DespuesEscribirLogger(this, e);
            }
        }
        /// <summary>
        /// Evento que se ejecuta tras producirse un error en la escritura en el fichero de logger.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">Orbita.Trazabilidad.LoggerEventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected virtual void OnErrorLogger(object sender, LoggerEventArgs e)
        {
            if (ErrorLogger != null)
            {
                ErrorLogger(this, e);
            }
        }
        #endregion

        #region M�todos privados
        /// <summary>
        /// M�todo privado asociado al evento NivelSID.
        /// </summary>
        /// <param name="item">Item de entrada.</param>
        /// <returns>Nivel de log + SID formateado.</returns>
        string Nivel(ItemLog item)
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0} {1}", item.SNivelLog, this.sid);
        }
        #endregion
    }
}