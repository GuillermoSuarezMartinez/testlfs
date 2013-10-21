//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Threading
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;
using System.Threading;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Threading
{
    /// <summary>
    /// Esta clase es un temporizador (timer) que realiza periódicamente algunas tareas.
    /// </summary>
    public class Timer
    {
        #region Eventos públicos
        /// <summary>
        /// Este evento se produce periódicamente en función del período del temporizador (timer).
        /// </summary>
        public event EventHandler Elapsed;
        #endregion Eventos públicos

        #region Atributos públicos
        /// <summary>
        /// Período de la tarea del temporizador (en milisegundos).
        /// </summary>
        public int Periodo { get; set; }
        /// <summary>
        /// Indica si el temporizador provoca el evento Elapsed en el método de inicio del temporizador.
        /// Valor predeterminado: False.
        /// </summary>
        public bool ArrancarAlIniciar { get; set; }
        #endregion Atributos públicos

        #region Atributos privados
        /// <summary>
        /// Este temporizador se utiliza para realizar tareas en intervalos especificados.
        /// </summary>
        private readonly System.Threading.Timer _timerTareas;
        /// <summary>
        /// Indica si el temporizador está en marcha o parado.
        /// </summary>
        private volatile bool _iniciado;
        /// <summary>
        /// Indica que si la realización de la tarea o _taskTimer está en modo de suspensión.
        /// Este campo se utiliza para esperar la ejecución de tareas cuando se detiene Timer.
        /// </summary>
        private volatile bool _tareasRealizadas;
        #endregion Atributos privados

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Timer.
        /// </summary>
        /// <param name="periodo">Período de la tarea del temporizador (en milisegundos).</param>
        public Timer(int periodo)
            : this(periodo, false) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Timer.
        /// </summary>
        /// <param name="periodo">Período de la tarea del temporizador (en milisegundos).</param>
        /// <param name="arrancarAlIniciar">Indica si el temporizador provoca el evento Elapsed en el método de inicio del temporizador.</param>
        public Timer(int periodo, bool arrancarAlIniciar)
        {
            Periodo = periodo;
            ArrancarAlIniciar = arrancarAlIniciar;
            _timerTareas = new System.Threading.Timer(TimerCallBack, null, Timeout.Infinite, Timeout.Infinite);
        }
        #endregion Constructores

        #region Métodos públicos
        /// <summary>
        /// Iniciar el temporizador.
        /// </summary>
        public void Iniciar()
        {
            _iniciado = true;
            _timerTareas.Change(ArrancarAlIniciar ? 0 : Periodo, Timeout.Infinite);
        }
        /// <summary>
        /// Parar el temporizador.
        /// </summary>
        public void Parar()
        {
            lock (_timerTareas)
            {
                _iniciado = false;
                _timerTareas.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }
        /// <summary>
        /// Espera a que el servicio se detenga.
        /// </summary>
        public void EsperarParaTerminar()
        {
            lock (_timerTareas)
            {
                while (_tareasRealizadas)
                {
                    Monitor.Wait(_timerTareas);
                }
            }
        }
        #endregion Métodos públicos

        #region Métodos privados
        /// <summary>
        /// Este método es llamado por _timerTareas.
        /// </summary>
        /// <param name="state">Argumento sin uso.</param>
        private void TimerCallBack(object state)
        {
            lock (_timerTareas)
            {
                if (!_iniciado || _tareasRealizadas)
                {
                    return;
                }
                _timerTareas.Change(Timeout.Infinite, Timeout.Infinite);
                _tareasRealizadas = true;
            }
            try
            {
                if (Elapsed != null)
                {
                    Elapsed(this, new EventArgs());
                }
            }
            catch
            {
                //  Empty.
            }
            finally
            {
                lock (_timerTareas)
                {
                    _tareasRealizadas = false;
                    _timerTareas.Change(Periodo, Timeout.Infinite);
                    Monitor.Pulse(_timerTareas);
                }
            }
        }
        #endregion Métodos privados
    }
}