//***********************************************************************
// Assembly         : Orbita.VAComun
// Author           : aiba�ez
// Created          : 06-09-2012
//
// Last Modified By : aiba�ez
// Last Modified On : 16-11-2012
// Description      : A�adido nuevo m�todo ExisteCronometro
//                    Utilizaci�n interna de este nuevo m�todo
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Orbita.VAComun
{
    /// <summary>
    /// Clase est�tica para el acceso a los cron�metros que se est�n ejecutandose en el sistema
    /// </summary>
    public static class OCronometrosManager
    {
        #region Atributo(s)
        /// <summary>
        /// Listado de todos los cron�metros necesarios para el c�mputo de tiempos de proceso
        /// </summary>
        public static List<OCronometro> ListaCronometros;

        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Constructor de los campos de la clase
        /// </summary>
        public static void Constructor()
        {
            ListaCronometros = new List<OCronometro>();
        }

        /// <summary>
        /// Destruye los campos de la clase
        /// </summary>
        public static void Destructor()
        {
            ListaCronometros = null;
        }

        /// <summary>
        /// Inicializa las variables necesarias para el funcionamiento de los cron�metros
        /// </summary>
        public static void Inicializar()
        {
        }

        /// <summary>
        /// Finaliza la ejecuci�n
        /// </summary>
        public static void Finalizar()
        {
        }

        /// <summary>
        /// A�ade un nuevo cron�metro al sistema
        /// </summary>
        /// <param name="codigo">C�digo identificador del cron�metro</param>
        /// <param name="nombre">Nombre del cron�metro</param>
        /// <param name="descripcion">Texto descriptivo del cron�metro</param>
        public static void NuevoCronometro(string codigo, string nombre, string descripcion)
        {
            // Si el cron�metro no existe se crea
            if (!ExisteCronometro(codigo))
            {
                // Creaci�n del nuevo cron�metro
                OCronometro cronometro = new OCronometro(codigo, nombre, descripcion);

                // A�adimos a la lista de m�quinas de estado
                if (ListaCronometros != null)
                {
                    ListaCronometros.Add(cronometro);
                }
            }
        }

        public static bool ExisteCronometro(string codigo)
        {
            return ListaCronometros.Exists(delegate(OCronometro c) { return c.Codigo == codigo;});
        }

        public static OCronometro BuscaCronometro(string codigo)
        {
            return ListaCronometros.Find(delegate(OCronometro c) { return c.Codigo == codigo; });
        }

        /// <summary>
        /// Inicia la cuenta de determinado cronometro
        /// </summary>
        public static void Start(string codigo)
        {
            OCronometro cronometro = BuscaCronometro(codigo);
            if (cronometro != null)
            {
                cronometro.Start();
            }
        }

        /// <summary>
        /// Inicia la cuenta de forma pausada de determinado cronometro
        /// </summary>
        public static void StartPaused(string codigo)
        {
            OCronometro cronometro = BuscaCronometro(codigo);
            if (cronometro != null)
            {
                cronometro.StartPaused();
            }
        }

        /// <summary>
        /// Detiene la cuenta de determinado cronometro
        /// </summary>
        public static void Stop(string codigo)
        {
            OCronometro cronometro = BuscaCronometro(codigo);
            if (cronometro != null)
            {
                cronometro.Stop();
            }
        }

        /// <summary>
        /// Pausa el cronometro
        /// </summary>
        public static void Pause(string codigo)
        {
            OCronometro cronometro = BuscaCronometro(codigo);
            if (cronometro != null)
            {
                cronometro.Pause();
            }
        }

        /// <summary>
        /// Reanuda el cronometro
        /// </summary>
        public static void Resume(string codigo)
        {
            OCronometro cronometro = BuscaCronometro(codigo);
            if (cronometro != null)
            {
                cronometro.Resume();
            }
        }

        /// <summary>
        /// Duraci�n de la �ltima ejecuci�n
        /// </summary>
        public static TimeSpan DuracionUltimaEjecucion(string codigo)
        {
            TimeSpan resultado = new TimeSpan();
            OCronometro cronometro = BuscaCronometro(codigo);
            if (cronometro != null)
            {
                resultado = cronometro.DuracionUltimaEjecucion;
            }
            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Clase que implementa un cron�metro para la medici�n de tiempos
    /// </summary>
    public class OCronometro
    {
        #region Atributo(s)
        /// <summary>
        /// Cron�metro de la ejecuci�n del estado
        /// </summary>
        private Stopwatch CronometroEjecucion;
        /// <summary>
        /// Estado del cron�metro
        /// </summary>
        public OEstadoCronometro EstadoCronometro;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// C�digo identificativo del cron�metro.
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// C�digo identificativo del cron�metro.
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Nombre del cron�metro.
        /// </summary>
        private string _Nombre;
        /// <summary>
        /// Nombre del cron�metro.
        /// </summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        /// <summary>
        /// Texto descriptivo.
        /// </summary>
        private string _Descripcion;
        /// <summary>
        /// Texto descriptivo.
        /// </summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        /// <summary>
        /// Contador del n�mero de veces que se ha realizado una medici�n de tiempos
        /// </summary>
        private long _ContadorEjecuciones;
        /// <summary>
        /// Contador del n�mero de veces que se ha realizado una medici�n de tiempos
        /// </summary>
        public long ContadorEjecuciones
        {
            get { return _ContadorEjecuciones; }
            set { _ContadorEjecuciones = value; }
        }

        /// <summary>
        /// Duraci�n promedio del tiempo que ha contabilizado el cron�metro
        /// </summary>
        public TimeSpan DuracionPromedioEjecucion
        {
            get
            {
                if (this.ContadorEjecuciones > 0)
                {
                    return TimeSpan.FromMilliseconds(this.DuracionTotalEjecucion.TotalMilliseconds / (double)this.ContadorEjecuciones);
                }
                return new TimeSpan();
            }
        }
        /// <summary>
        /// Duraci�n promedio del tiempo que ha contabilizado el cron�metro
        /// </summary>
        public string StrDuracionPromedioEjecucion
        {
            get
            {
                return this.DuracionPromedioEjecucion.TotalMilliseconds.ToString("#0.000");
            }
        }

        /// <summary>
        /// Duraci�n del tiempo acumulado que ha contabilizado el cron�metro
        /// </summary>
        private TimeSpan _DuracionTotalEjecucion;
        /// <summary>
        /// Duraci�n del tiempo acumulado que ha contabilizado el cron�metro
        /// </summary>
        public TimeSpan DuracionTotalEjecucion
        {
            get
            {
                if (this.CronometroEjecucion.IsRunning)
                {
                    return this._DuracionTotalEjecucion + this.DuracionUltimaEjecucion;
                }
                else
                {
                    return this._DuracionTotalEjecucion;
                }
            }
        }
        /// <summary>
        /// Duraci�n del tiempo acumulado que ha contabilizado el cron�metro
        /// </summary>
        public string StrDuracionTotalEjecucion
        {
            get
            {
                return this.DuracionTotalEjecucion.TotalMilliseconds.ToString("#0.000");
            }
        }

        /// <summary>
        /// Momento en el que se ejecut� por �ltima vez
        /// </summary>
        private DateTime _MomentoUltimaEjecucion;
        /// <summary>
        /// Momento en el que se ejecut� por �ltima vez
        /// </summary>
        public DateTime MomentoUltimaEjecucion
        {
            get { return _MomentoUltimaEjecucion; }
            set { _MomentoUltimaEjecucion = value; }
        }

        /// <summary>
        /// Duraci�n de la �ltima ejecuci�n
        /// </summary>
        public TimeSpan DuracionUltimaEjecucion
        {
            get
            {
                return this.CronometroEjecucion.Elapsed;
            }
        }
        /// <summary>
        /// Duraci�n del tiempo acumulado que ha contabilizado el cron�metro
        /// </summary>
        public string StrDuracionUltimaEjecucion
        {
            get
            {
                return this.DuracionUltimaEjecucion.TotalMilliseconds.ToString("#0.000");
            }
        }

        /// <summary>
        /// Indica si el contador est� ejecutandose
        /// </summary>
        public bool Ejecutando
        {
            get { return this.CronometroEjecucion.IsRunning; }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OCronometro(string codigo, string nombre, string descripcion)
        {
            this._Codigo = codigo;
            this._Nombre = nombre;
            this._Descripcion = descripcion;
            this._ContadorEjecuciones = 0;
            this.EstadoCronometro = OEstadoCronometro.Detenido;
            this.MomentoUltimaEjecucion = DateTime.Now;
            this.CronometroEjecucion = new Stopwatch();
            this._DuracionTotalEjecucion = new TimeSpan();
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OCronometro()
        {
            this._Codigo = string.Empty;
            this._Nombre = string.Empty;
            this._Descripcion = string.Empty;
            this._ContadorEjecuciones = 0;
            this.EstadoCronometro = OEstadoCronometro.Detenido;
            this.MomentoUltimaEjecucion = DateTime.Now;
            this.CronometroEjecucion = new Stopwatch();
            this._DuracionTotalEjecucion = new TimeSpan();
        }
        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Inicia el cronometro
        /// </summary>
        public void Start()
        {
            if (this.EstadoCronometro == OEstadoCronometro.Detenido)
            {
                this.ContadorEjecuciones++;
                this._MomentoUltimaEjecucion = DateTime.Now;
                this.CronometroEjecucion.Reset();
                this.CronometroEjecucion.Start();
                this.EstadoCronometro = OEstadoCronometro.Iniciado;
            }
        }
        /// <summary>
        /// Inicia el cronometro de forma pausada
        /// </summary>
        public void StartPaused()
        {
            if (this.EstadoCronometro == OEstadoCronometro.Detenido)
            {
                this.ContadorEjecuciones++;
                this._MomentoUltimaEjecucion = DateTime.Now;
                this.CronometroEjecucion.Reset();
                this.EstadoCronometro = OEstadoCronometro.Pausado;
            }
        }
        /// <summary>
        /// Detiene el cronometro
        /// </summary>
        public void Stop()
        {
            if ((this.EstadoCronometro == OEstadoCronometro.Iniciado) || (this.EstadoCronometro == OEstadoCronometro.Pausado))
            {
                this.CronometroEjecucion.Stop();
                this._DuracionTotalEjecucion += this.DuracionUltimaEjecucion;
                this.EstadoCronometro = OEstadoCronometro.Detenido;
            }
        }
        /// <summary>
        /// Pausa el cronometro
        /// </summary>
        public void Pause()
        {
            if (this.EstadoCronometro == OEstadoCronometro.Iniciado)
            {
                this.CronometroEjecucion.Stop();
                this.EstadoCronometro = OEstadoCronometro.Pausado;
            }
        }
        /// <summary>
        /// Reanuda el cronometro
        /// </summary>
        public void Resume()
        {
            if (this.EstadoCronometro == OEstadoCronometro.Pausado)
            {
                this.CronometroEjecucion.Start();
                this.EstadoCronometro = OEstadoCronometro.Iniciado;
            }
        }

        #endregion
    }

    /// <summary>
    /// Enumerado que describe el esatado de un cron�metro
    /// </summary>
    public enum OEstadoCronometro
    {
        /// <summary>
        /// Detenido
        /// </summary>
        [OStringValue("Detenido")]
        Detenido,
        /// <summary>
        /// Pausado
        /// </summary>
        [OStringValue("Pausado")]
        Pausado,
        /// <summary>
        /// Iniciado
        /// </summary>
        [OStringValue("Iniciado")]
        Iniciado
    }
}
