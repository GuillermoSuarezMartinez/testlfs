//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 13-02-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Threading;
using Orbita.Utiles;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase que implementa un consumidor en thread
    /// </summary>
    public class OProductorConsumidorThread<T> : IDisposable
    {
        #region Atributo(s)
        /// <summary>
        /// Cola del consumidor
        /// </summary>
        private OPriorityQueue<T> Cola;

        /// <summary>
        /// Capacidad máxima de la cola
        /// </summary>
        private int CapacidadMaxima;

        /// <summary>
        /// Objeto bloqueante
        /// </summary>
        private object LockObject;

        /// <summary>
        /// Thread de ejecución
        /// </summary>
        OThreadsLoop Thread;

        /// <summary>
        /// Indica si la ejecución del consumidor se ha de realizar en el thread o fuera de él
        /// </summary>
        private bool EjecutarConsumidorEnThread;

        /// <summary>
        /// Indica si la ejecución del productor se ha de realizar en el thread o fuera de él
        /// </summary>
        private bool EjecutarProductorEnThread;

        /// <summary>
        /// Indica si la ejecución de la monitorización se ha de realizar en el thread o fuera de él
        /// </summary>
        private bool EjecutarMonitorizacionEnThread;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Código identificativo de la clase.
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código identificativo de la clase.
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Posibles estados del productor / consumidor
        /// </summary>
        private EstadoProductorConsumidor _Estado;
        /// <summary>
        /// Posibles estados del productor / consumidor
        /// </summary>
        public EstadoProductorConsumidor Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        /// <summary>
        /// Número de elementos en la cola
        /// </summary>
        public int Count
        {
            get
            {
                int resultado = 0;
                lock (this.LockObject)
                {
                    resultado = this.Cola.Count;
                }
                return resultado;
            }
        }

        /// <summary>
        /// Número de instancias totales añadidas a la cola
        /// </summary>
        private long _Total;
        /// <summary>
        /// Número de instancias totales añadidas a la cola
        /// </summary>
        public long Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OProductorConsumidorThread(string codigo) :
            this(codigo, 1, 1, ThreadPriority.Normal, 100)
        {
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OProductorConsumidorThread(string codigo, uint numeroThreads, int tiempoSleep, ThreadPriority threadPriority, int capacidadMaxima)
        {
            this.Codigo = codigo;
            this.Cola = new OPriorityQueue<T>();
            this._Total = 0;
            this.CapacidadMaxima = capacidadMaxima;
            this.LockObject = new object();
            this.Estado = EstadoProductorConsumidor.Detenido;
            this.Thread = new OThreadsLoop(codigo, numeroThreads, tiempoSleep, threadPriority);

            this.CrearSuscripcionConsumidor(EjecucionConsumidor, true);
            this.CrearSuscripcionProductor(EjecucionProductor, true);
            this.CrearSuscripcionMonitorizacion(Monitorizacion, true);

            this.Thread.CrearSuscripcionRun(Ejecucion, true);
            this.Thread.CrearSuscripcionFin(FinEjecucion, true);
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Lanza la ejecución del thread de consumición
        /// </summary>
        /// <param name="valor">Valor a consumir</param>
        private void LanzarEventoConsumidor(T valor)
        {
            try
            {
                if (this.OnEjecucionConsumidor != null)
                {
                    if (this.EjecutarConsumidorEnThread)
                    {
                        this.OnEjecucionConsumidor(valor);
                    }
                    else
                    {
                        App.FormularioPrincipal.Invoke(this.OnEjecucionConsumidor, valor);
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.Threads.Info(exception, "LanzarEventoConsumidor");
            }
        }

        /// <summary>
        /// Lanza la ejecución del thread de producción
        /// </summary>
        /// <param name="encolar">Indica que se ha de encolar un elemento</param>
        /// <param name="valor">Valor producido</param>
        private void LanzarEventoProductor(ref bool encolar, ref T valor)
        {
            try
            {
                if (this.OnEjecucionProductor != null)
                {
                    if (this.EjecutarProductorEnThread)
                    {
                        this.OnEjecucionProductor(ref encolar, ref valor);
                    }
                    else
                    {
                        App.FormularioPrincipal.Invoke(this.OnEjecucionProductor, valor);

                        object[] obj = new object[] { encolar, valor };
                        App.FormularioPrincipal.Invoke(this.OnEjecucionProductor, obj);
                        encolar = (bool)obj[0];
                        valor = (T)obj[1];
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.Threads.Info(exception, "LanzarEventoProductor");
            }
        }

        /// <summary>
        /// Lanza la ejecución del thread de monitorizacion
        /// </summary>
        /// <param name="finalize">Indica la finalización del thread</param>
        /// <param name="valor">Valor producido</param>
        private void LanzarEventoMonitorizacion(ref bool finalize)
        {
            try
            {
                if (this.OnMonitorizacion != null)
                {
                    if (this.EjecutarMonitorizacionEnThread)
                    {
                        this.OnMonitorizacion(ref finalize);
                    }
                    else
                    {
                        object[] obj = new object[] { finalize };
                        App.FormularioPrincipal.Invoke(this.OnMonitorizacion, obj);
                        finalize = (bool)obj[0];
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.Threads.Info(exception, "LanzarEventoMonitorizacion");
            }
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Añade el valor a encolar
        /// </summary>
        /// <param name="valor"></param>
        public bool Encolar(T valor)
        {
            return this.Encolar(valor, 0);
        }

        /// <summary>
        /// Añade el valor a encolar
        /// </summary>
        /// <param name="valor"></param>
        public bool Encolar(T valor, int prioridad)
        {
            bool resultado = false;
            if ((this.Estado == EstadoProductorConsumidor.EnEjecucion) && (valor is T))
            {
                lock (this.LockObject)
                {
                    if (this.Cola.Count < this.CapacidadMaxima)
                    {
                        this.Cola.Enqueue(valor, prioridad);
                        this._Total++;
                        resultado = true;
                    }
                }
            }
            return resultado;
        }

        /// <summary>
        /// Devuelve el valor desencolado
        /// </summary>
        /// <param name="valor"></param>
        public bool Desencolar(out T valor)
        {
            bool resultado = false;
            valor = default(T);

            if (this.Estado == EstadoProductorConsumidor.EnEjecucion)
            {
                lock (this.LockObject)
                {
                    if (this.Cola.Count > 0)
                    {
                        valor = this.Cola.Dequeue();
                        resultado = true;
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Inicio del thread
        /// </summary>
        public void Start()
        {
            if (this.Estado == EstadoProductorConsumidor.Detenido)
            {
                this.Estado = EstadoProductorConsumidor.EnEjecucion;
                this._Total = 0;
                this.Thread.Start();
            }
        }

        /// <summary>
        /// Fin del thread
        /// </summary>
        public void Stop()
        {
            if (this.Estado == EstadoProductorConsumidor.EnEjecucion)
            {
                this.Estado = EstadoProductorConsumidor.Deteniendo;
            }
        }

        /// <summary>
        /// Elimina la memoria asignada por el objeto.
        /// </summary>
        public void Dispose()
        {
            this.Stop();
            this.Thread.Stop();
            this.Thread = null;
            this.OnEjecucionConsumidor = null;
            this.OnEjecucionProductor = null;
            this.OnMonitorizacion = null;
        }

        /// <summary>
        /// Borra la cola
        /// </summary>
        public void Clear()
        {
            lock (this.LockObject)
            {
                this.Cola.Clear();
            }
        }

        /// <summary>
        /// Elimina la memoria asignada por el objeto.
        /// </summary>
        public void Dispose(int milisecondsTimeout)
        {
            this.Stop();
            this.Thread.Stop(milisecondsTimeout);
            this.Thread = null;
            this.OnEjecucionConsumidor = null;
            this.OnEjecucionProductor = null;
            this.OnMonitorizacion = null;
        }

        /// <summary>
        /// Creación de la suscripción al evento de ejecución del consumidor
        /// </summary>
        public void CrearSuscripcionConsumidor(ConsumidorRun consumidorRun, bool ejecutarEnThread)
        {
            this.OnEjecucionConsumidor = consumidorRun; // Este método no puede ser nunca múltiple
            this.EjecutarConsumidorEnThread = ejecutarEnThread;
        }

        /// <summary>
        /// Creación de la suscripción al evento de ejecución del productor
        /// </summary>
        public void CrearSuscripcionProductor(ProductorRun productorRun, bool ejecutarEnThread)
        {
            this.OnEjecucionProductor = productorRun; // Este método no puede ser nunca múltiple
            this.EjecutarProductorEnThread = ejecutarEnThread;
        }

        /// <summary>
        /// Creación de la suscripción al evento de monitorización del productor / consumidor
        /// </summary>
        public void CrearSuscripcionMonitorizacion(ThreadRun monitorizacionRun, bool ejecutarEnThread)
        {
            this.OnMonitorizacion = monitorizacionRun; // Este método no puede ser nunca múltiple
            this.EjecutarMonitorizacionEnThread = ejecutarEnThread;
        }

        /// <summary>
        /// Creación de la suscripción al evento de finalización del productor / consumidor
        /// </summary>
        public void CrearSuscripcionFin(OSimpleMethod monitorizacionRun, bool ejecutarEnThread)
        {
            this.Thread.CrearSuscripcionFin(monitorizacionRun, ejecutarEnThread);
        }
        #endregion

        #region Método(s) virtual(es)
        /// <summary>
        /// Método que ejecuta la acción del consumidor.
        /// </summary>
        /// <param name="valor"></param>
        protected virtual void EjecucionConsumidor(T valor)
        {
            // A implementar en heredados
        }

        /// <summary>
        /// Método que ejecuta la acción del productor.
        /// </summary>
        /// <param name="valor"></param>
        protected virtual void EjecucionProductor(ref bool encolar, ref T valor)
        {
            // A implementar en heredados
        }

        /// <summary>
        /// Ejecución de la monitorización del productor / consumidor
        /// </summary>
        protected virtual void Monitorizacion(ref bool finalize)
        {
            // Implementado en heredados
        }

        /// <summary>
        /// Fin de la ejecución del thread
        /// </summary>
        protected virtual void FinEjecucion()
        {
            // A implementar en heredados
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Ejecución del thread
        /// </summary>
        /// <param name="finalize"></param>
        protected void Ejecucion(ref bool finalize)
        {
            finalize = false;

            // Comprobación del estado de la cola
            if ((this.Estado == EstadoProductorConsumidor.Deteniendo) && (this.Count == 0))
            {
                finalize = true;
            }

            // Monitorización de la ejecución del productor / consumidor
            if (!finalize)
            {
                // Evento de monitorización del thread
                this.LanzarEventoMonitorizacion(ref finalize);
            }

            if (!finalize)
            {
                // Llamada al productor
                try
                {
                    if (this.OnEjecucionProductor != null)
                    {
                        T valorEncolar = default(T);
                        bool encolar = false;

                        // Evento del productor
                        this.LanzarEventoProductor(ref encolar, ref valorEncolar);

                        if (encolar && (valorEncolar is T))
                        {
                            this.Encolar(valorEncolar);
                        }
                    }
                }
                catch (Exception exception)
                {
                    OLogsVAComun.Threads.Info(exception, "EjecucionProductor");
                }

                // Llamada al consumidor
                try
                {
                    if (this.OnEjecucionConsumidor != null)
                    {
                        T valorDesencolar;
                        bool hayDato = this.Desencolar(out valorDesencolar);

                        if (hayDato)
                        {
                            // Evento del consumidor
                            this.LanzarEventoConsumidor(valorDesencolar);
                        }
                    }
                }
                catch (Exception exception)
                {
                    OLogsVAComun.Threads.Info(exception, "EjecucionConsumidor");
                }
            }

            // Actualicamos el estado del productor / consumidor
            if (finalize)
            {
                this.Estado = EstadoProductorConsumidor.Detenido;
            }
        }
        #endregion

        #region Definición de delegado(s)
        /// <summary>
        /// Delegado que de la ejecución del consumidor
        /// </summary>
        public delegate void ConsumidorRun(T valor);
        /// <summary>
        /// Delegado que de la ejecución del consumidor
        /// </summary>
        protected ConsumidorRun OnEjecucionConsumidor;

        /// <summary>
        /// Delegado que de la ejecución del consumidor
        /// </summary>
        public delegate void ProductorRun(ref bool encolar, ref T valor);
        /// <summary>
        /// Delegado que de la ejecución del consumidor
        /// </summary>
        protected ProductorRun OnEjecucionProductor;

        /// <summary>
        /// Delegado que de la ejecución del monitor del productor / consumidor
        /// </summary>
        protected ThreadRun OnMonitorizacion;
        #endregion
    }

    /// <summary>
    /// Enumerado de los posibles estados del productor / consumidor
    /// </summary>
    public enum EstadoProductorConsumidor
    {
        /// <summary>
        /// Estado inicial del thread
        /// </summary>
        Detenido = 0,

        /// <summary>
        /// En ejecución
        /// </summary>
        EnEjecucion = 1,

        /// <summary>
        /// En proceso de parada. La parada definitiva se realizará cuando se vacie la cola
        /// </summary>
        Deteniendo = 2
    }
}
