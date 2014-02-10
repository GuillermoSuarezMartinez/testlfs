//***********************************************************************
// Assembly         : Orbita.Utiles
// Author           : aiba�ez
// Created          : 06-09-2012
//
// Last Modified By : aiba�ez
// Last Modified On : 03-02-2014
// Description      : A�adido evento de actualizaci�n del cron�metro
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
namespace Orbita.Utiles
{
    /// <summary>
    /// Clase est�tica para el acceso a los cron�metros que se est�n ejecutandose en el sistema
    /// </summary>
    public static class OCronometrosManager
    {
        #region Atributos
        /// <summary>
        /// Listado de todos los cron�metros necesarios para el c�mputo de tiempos de proceso
        /// </summary>
        public static List<OCronometro> ListaCronometros;

        #endregion

        #region M�todos p�blicos
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
        public static OCronometro NuevoCronometro(string codigo, string nombre, string descripcion)
        {
            OCronometro resultado = null;

            // Si el cron�metro no existe se crea
            if (!ExisteCronometro(codigo))
            {
                // Creaci�n del nuevo cron�metro
                resultado = new OCronometro(codigo, nombre, descripcion);

                // A�adimos a la lista de m�quinas de estado
                if (ListaCronometros != null)
                {
                    ListaCronometros.Add(resultado);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Elimina el cronometro de la lista
        /// </summary>
        /// <param name="codigo"></param>
        public static void EliminaCronometro(string codigo)
        {
            OCronometro cronometro = BuscaCronometro(codigo);
            if (cronometro != null)
            {
                ListaCronometros.Remove(cronometro);
            }
        }

        /// <summary>
        /// Informa de la existencia eel cronometro en la lista
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static bool ExisteCronometro(string codigo)
        {
            return (ListaCronometros != null) && ListaCronometros.Exists(delegate(OCronometro c) { return c.Codigo == codigo; });
        }

        /// <summary>
        /// B�sca el cronometro en la lista
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static OCronometro BuscaCronometro(string codigo)
        {
            if (ListaCronometros != null)
            {
                return ListaCronometros.Find(delegate(OCronometro c) { return c.Codigo == codigo; });
            }
            return null;
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
        /// Contador del n�mero de veces que se ha realizado una medici�n de tiempos
        /// </summary>
        public static long ContadorEjecuciones(string codigo)
        {
            long resultado = 0;
            OCronometro cronometro = BuscaCronometro(codigo);
            if (cronometro != null)
            {
                resultado = cronometro.ContadorEjecuciones;
            }
            return resultado;
        }

        /// <summary>
        /// Duraci�n promedio del tiempo que ha contabilizado el cron�metro
        /// </summary>
        public static TimeSpan DuracionPromedioEjecucion(string codigo)
        {
            TimeSpan resultado = new TimeSpan();
            OCronometro cronometro = BuscaCronometro(codigo);
            if (cronometro != null)
            {
                resultado = cronometro.DuracionPromedioEjecucion;
            }
            return resultado;
        }

        /// <summary>
        /// Duraci�n del tiempo acumulado que ha contabilizado el cron�metro
        /// </summary>
        public static TimeSpan DuracionTotalEjecucion(string codigo)
        {
            TimeSpan resultado = new TimeSpan();
            OCronometro cronometro = BuscaCronometro(codigo);
            if (cronometro != null)
            {
                resultado = cronometro.DuracionTotalEjecucion;
            }
            return resultado;
        }

        /// <summary>
        /// Duraci�n del tiempo acumulado que ha contabilizado el cron�metro
        /// </summary>
        public static DateTime MomentoUltimaEjecucion(string codigo)
        {
            DateTime resultado = new DateTime();
            OCronometro cronometro = BuscaCronometro(codigo);
            if (cronometro != null)
            {
                resultado = cronometro.MomentoUltimaEjecucion;
            }
            return resultado;
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

        /// <summary>
        /// Indica si el contador est� ejecutandose
        /// </summary>
        public static bool Ejecutando(string codigo)
        {
            bool resultado = false;
            OCronometro cronometro = BuscaCronometro(codigo);
            if (cronometro != null)
            {
                resultado = cronometro.Ejecutando;
            }
            return resultado;
        }

        /// <summary>
        /// Suscribe a un determinado cron�metro
        /// </summary>
        /// <param name="codigo">C�digo del cron�metro</param>
        /// <param name="delegadoSuscriptor">Delegado al cual recibir los eventos</param>
        public static void CrearSuscripcion(string codigo, OEjecucionCronometroDelegate delegadoSuscriptor)
        {
            OCronometro cronometro;
            if (TryGetCronometro(codigo, out cronometro))
            {
                cronometro.CrearSuscripcion(delegadoSuscriptor);
            }
        }

        /// <summary>
        /// Elimina la suscripci�n a un determinado cron�metro
        /// </summary>
        /// <param name="codigo">C�digo del cron�metro</param>
        /// <param name="delegadoSuscriptor">Delegado al cual recibir los eventos</param>
        public static void EliminarSuscripcion(string codigo, OEjecucionCronometroDelegate delegadoSuscriptor)
        {
            OCronometro cronometro;
            if (TryGetCronometro(codigo, out cronometro))
            {
                cronometro.EliminarSuscripcion(delegadoSuscriptor);
            }
        }

        /// <summary>
        /// Suscribe a todos los cron�metros
        /// </summary>
        /// <param name="delegadoSuscriptor">Delegado al cual recibir los eventos</param>
        public static void CrearSuscripcionTodos(OEjecucionCronometroDelegate delegadoSuscriptor)
        {
            foreach (OCronometro cronometro in ListaCronometros)
            {
                cronometro.CrearSuscripcion(delegadoSuscriptor);
            }
        }

        /// <summary>
        /// Elimina la suscripci�n a todos los cron�metros
        /// </summary>
        /// <param name="codigo">C�digo del cron�metro</param>
        /// <param name="delegadoSuscriptor">Delegado al cual recibir los eventos</param>
        public static void EliminarSuscripcionTodos(OEjecucionCronometroDelegate delegadoSuscriptor)
        {
            foreach (OCronometro cronometro in ListaCronometros)
            {
                cronometro.EliminarSuscripcion(delegadoSuscriptor);
            }
        }
        #endregion

        #region M�todo(s) privado(s)
        /// <summary>
        /// M�todo para acceder a un cron�metro
        /// </summary>
        /// <param name="codigo">C�digo del cron�metro</param>
        /// <param name="cronometro">Cron�metro resultante de la b�squeda</param>
        /// <returns>Devuelve verdadero si el cron�metro ha sido encontrado</returns>
        private static bool TryGetCronometro(string codigo, out OCronometro cronometro)
        {
            cronometro = BuscaCronometro(codigo);
            return cronometro != null;
        }
        #endregion
    }

    /// <summary>
    /// Clase que implementa un cron�metro para la medici�n de tiempos
    /// </summary>
    public class OCronometro
    {
        #region Atributos
        /// <summary>
        /// Cron�metro de la ejecuci�n del estado
        /// </summary>
        private Stopwatch CronometroEjecucion;
        /// <summary>
        /// Estado del cron�metro
        /// </summary>
        public EstadoCronometro EstadoCronometro;
        #endregion

        #region Propiedades
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
        /// Indica si el contador est� ejecutandose
        /// </summary>
        public bool Ejecutando
        {
            get { return this.CronometroEjecucion.IsRunning; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OCronometro(string codigo, string nombre, string descripcion)
        {
            this._Codigo = codigo;
            this._Nombre = nombre;
            this._Descripcion = descripcion;
            this._ContadorEjecuciones = 0;
            this.EstadoCronometro = EstadoCronometro.Detenido;
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
            this.EstadoCronometro = EstadoCronometro.Detenido;
            this.MomentoUltimaEjecucion = DateTime.Now;
            this.CronometroEjecucion = new Stopwatch();
            this._DuracionTotalEjecucion = new TimeSpan();
        }
        #endregion

        #region M�todos p�blicos
        /// <summary>
        /// Inicia el cronometro
        /// </summary>
        public void Start()
        {
            if (this.EstadoCronometro == EstadoCronometro.Detenido)
            {
                this.ContadorEjecuciones++;
                this._MomentoUltimaEjecucion = DateTime.Now;
                this.CronometroEjecucion.Reset();
                this.CronometroEjecucion.Start();
                this.EstadoCronometro = EstadoCronometro.Iniciado;
            }
        }
        /// <summary>
        /// Inicia el cronometro de forma pausada
        /// </summary>
        public void StartPaused()
        {
            if (this.EstadoCronometro == EstadoCronometro.Detenido)
            {
                this.ContadorEjecuciones++;
                this._MomentoUltimaEjecucion = DateTime.Now;
                this.CronometroEjecucion.Reset();
                this.EstadoCronometro = EstadoCronometro.Pausado;
            }
        }
        /// <summary>
        /// Detiene el cronometro
        /// </summary>
        public void Stop()
        {
            if ((this.EstadoCronometro == EstadoCronometro.Iniciado) || (this.EstadoCronometro == EstadoCronometro.Pausado))
            {
                this.CronometroEjecucion.Stop();
                this._DuracionTotalEjecucion += this.DuracionUltimaEjecucion;
                this.EstadoCronometro = EstadoCronometro.Detenido;

                if (this.EjecucionCronometroDelegate != null)
                {
                    // Ejecuci�n del delegado
                    this.EjecucionCronometroDelegate(this.Codigo);
                }
            }
        }
        /// <summary>
        /// Pausa el cronometro
        /// </summary>
        public void Pause()
        {
            if (this.EstadoCronometro == EstadoCronometro.Iniciado)
            {
                this.CronometroEjecucion.Stop();
                this.EstadoCronometro = EstadoCronometro.Pausado;
            }
        }
        /// <summary>
        /// Reanuda el cronometro
        /// </summary>
        public void Resume()
        {
            if (this.EstadoCronometro == EstadoCronometro.Pausado)
            {
                this.CronometroEjecucion.Start();
                this.EstadoCronometro = EstadoCronometro.Iniciado;
            }
        }
        /// <summary>
        /// Suscribe al cron�metro
        /// </summary>
        /// <param name="delegadoSuscriptor">Delegado al cual recibir los eventos</param>
        public void CrearSuscripcion(OEjecucionCronometroDelegate delegadoSuscriptor)
        {
            this.EjecucionCronometroDelegate += delegadoSuscriptor;
        }
        /// <summary>
        /// Elimina la suscripci�n al cron�metro
        /// </summary>
        /// <param name="delegadoSuscriptor">Delegado al cual recibir los eventos</param>
        public void EliminarSuscripcion(OEjecucionCronometroDelegate delegadoSuscriptor)
        {
            this.EjecucionCronometroDelegate -= delegadoSuscriptor;
        }
        #endregion

        #region Definici�n de delegado(s)
        /// <summary>
        /// Implementaci�n del delegado que se activa cuando se termina la ejecuci�n del cron�metro.
        /// No se garantiza la ejecuci�n en el thread principal
        /// </summary>
        private event OEjecucionCronometroDelegate EjecucionCronometroDelegate = null;
        #endregion
    }

    #region Definici�n de delegado(s)
    /// <summary>
    /// Declaraci�n del delegado que se activa cuando cambia el valor de una variable
    /// </summary>
    public delegate void OEjecucionCronometroDelegate(string codigo);
    #endregion

    /// <summary>
    /// Enumerado que describe el esatado de un cron�metro
    /// </summary>
    public enum EstadoCronometro
    {
        /// <summary>
        /// Detenido
        /// </summary>
        [OAtributoEnumerado("Detenido")]
        Detenido,
        /// <summary>
        /// Pausado
        /// </summary>
        [OAtributoEnumerado("Pausado")]
        Pausado,
        /// <summary>
        /// Iniciado
        /// </summary>
        [OAtributoEnumerado("Iniciado")]
        Iniciado
    }
}