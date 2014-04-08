//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 12-12-2012
// Description      : Nueva clase ProductorConsumidor
//                    Posibilidad de lanzar eventos en el propio thread o 
//                    en el thread principal
//                    Se evita tener más de un delegado suscrito al evento run
//
// Last Modified By : aibañez
// Last Modified On : 16-11-2012
// Description      : Cabiados métodos de finalización
//
// Last Modified By : aibañez
// Last Modified On : 29-11-2013
// Description      : Utilización antes de sincronizar con el thread principal de IsHandleCreated
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Orbita.Utiles;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase estática para el control de la ejecución de threads
    /// </summary>
    public static class OThreadManager
    {
        #region Atributo(s)
        /// <summary>
        /// Listado de los threads de tipo loop del sistema
        /// </summary>
        public static List<OThreadLoop> ListaThreadsLoop;

        /// <summary>
        /// Identificador del thread principal
        /// </summary>
        private static int MainThreadId;

        /// <summary>
        /// Objeto de bloqueo. Utilizado para el bloqueo multihilo
        /// </summary>
        private static object BlockObject = new object();
        #endregion

        #region Propiedad(es)
        /// </summary>
        /// <returns></returns>
        public static int Count
        {
            get
            {
                int resultado = 0;
                if (ListaThreadsLoop != null)
                {
                    lock (BlockObject)
                    {
                        resultado = ListaThreadsLoop.Count;
                    }
                }
                return resultado;
            }
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Constructor de los campos de la clase
        /// </summary>
        public static void Constructor()
        {
            ListaThreadsLoop = new List<OThreadLoop>();
        }

        /// <summary>
        /// Destruye los campos de la clase
        /// </summary>
        public static void Destructor()
        {
            ListaThreadsLoop = null;
        }

        /// <summary>
        /// Inicializa las variables necesarias para el funcionamiento de la clase
        /// </summary>
        public static void Inicializar()
        {
            MainThreadId = Thread.CurrentThread.ManagedThreadId;
        }

        /// <summary>
        /// Finaliza la ejecución
        /// </summary>
        public static void Finalizar()
        {
            if (ListaThreadsLoop != null)
            {
                lock (BlockObject)
                {
                    foreach (OThreadLoop thread in ListaThreadsLoop)
                    {
                        thread.Stop();
                    }
                }
            }
        }

        /// <summary>
        /// Detiene la ejecución hasta que el semaforo se pone en verde
        /// Debe de ser llamada desde el propio thread!!
        /// </summary>
        /// <returns>Falso si el semaforo no existe</returns>
        public static bool EsperarSemaforo()
        {
            bool resultado = false;
            OThreadLoop thread = null;
            if (ListaThreadsLoop != null)
            {
                lock (BlockObject)
                {
                    thread = ListaThreadsLoop.Find(delegate(OThreadLoop t)
                        {
                            bool result = false;
                            if (t.ThreadEjecucion != null)
                            {
                                result = t.ThreadEjecucion.Thread.Equals(Thread.CurrentThread);
                            }
                            return result;
                        });
                }
            }
            if (thread != null)
            {
                resultado = thread.Wait();
            }

            return resultado;
        }

        /// <summary>
        /// Pone el semaforo en rojo
        /// Debe de ser llamaeda desde fuera del thread!!!
        /// </summary>
        /// <param name="codigo">Identificador del objeto</param>
        /// <returns>Falso si el semaforo no existe</returns>
        public static bool SemaforoRojo(string codigo)
        {
            bool resultado = false;

            if (ListaThreadsLoop != null)
            {
                lock (BlockObject)
                {
                    OThreadLoop thread = ListaThreadsLoop.Find(delegate(OThreadLoop t) { return string.Equals(t.Codigo, codigo, StringComparison.CurrentCultureIgnoreCase); });
                    if (thread != null)
                    {
                        resultado = thread.Pause();
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Pone el semaforo en verde
        /// Debe de ser llamaeda desde fuera del thread!!!
        /// </summary>
        /// <param name="codigo">Identificador del objeto</param>
        /// <returns>Falso si el semaforo no existe</returns>
        public static bool SemaforoVerde(string codigo)
        {
            bool resultado = false;

            if (ListaThreadsLoop != null)
            {
                lock (BlockObject)
                {
                    OThreadLoop thread = ListaThreadsLoop.Find(delegate(OThreadLoop t) { return string.Equals(t.Codigo, codigo, StringComparison.CurrentCultureIgnoreCase); });
                    if (thread != null)
                    {
                        resultado = thread.Resume();
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Informa si se está ejecutando desde el mismo hilo de ejecución que la aplicación principal o desde otro distinto
        /// </summary>
        /// <returns>Verdadero si se está ejecutando desde el mismo hilo de ejecución que la aplicación principal</returns>
        public static bool EjecucionEnTrheadPrincipal()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            return !App.FormularioPrincipal.InvokeRequired && (threadId == MainThreadId);
        }

        /// <summary>
        /// Ejecuta el método pasado como parámetro en el hilo principal de la aplicación
        /// </summary>
        /// <param name="metodo">Método que se desea ejecutar en el hilo principal</param>
        /// <param name="parametros">Parámetros del métodos que se desea ejecutar en el hilo principal</param>
        public static object SincronizarConThreadPrincipal(Delegate metodo, object[] parametros)
        {
            try
            {
                if (App.FormularioPrincipal.IsHandleCreated)
                {
                    return App.FormularioPrincipal.Invoke(metodo, parametros);
                }
                else
                {
                    OLogsVAComun.Threads.Warn("Imposible sincronizar con el thrad principal");
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.Threads.Warn(exception, "SincronizarConThreadPrincipal");
            }
            return null;
        }

        /// <summary>
        /// Método que realiza una espera (sin parar la ejecución del sistema) de cierto tiempo en milisegundos
        /// </summary>
        /// <param name="timeOut">Tiempo de espera en milisegundos</param>
        public static void Espera(int timeOut)
        {
            // Momento en el que finalizará la espera
            DateTime momentoTimeOut = DateTime.Now.AddMilliseconds(timeOut);

            while (DateTime.Now < momentoTimeOut)
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Método que realiza una espera hasta que cierto valor sea verdadero durante un máximo de tiempo
        /// </summary>
        /// <param name="valor">Valor al cual se espera que su estado sea verdadero o falso</param>
        /// <param name="valorEsperado">Valor de comparación</param>
        /// <param name="timeOut">Tiempo máximo de la espera en milisegundos</param>
        /// <returns>Verdadero si el valor a cambiado a verdadero antes de que finalizase el TimeOut</returns>
        public static bool Espera(DelegadoEspera delegadoEspera, int timeOut)
        {
            // Momento en el que finalizará la espera
            DateTime momentoTimeOut = DateTime.Now.AddMilliseconds(timeOut);

            bool valor = delegadoEspera();
            while (!valor && (DateTime.Now < momentoTimeOut))
            {
                Application.DoEvents();
                valor = delegadoEspera();
            }

            return valor;
        }

        /// <summary>
        /// Delegado de la espera
        /// </summary>
        /// <returns></returns>
        public delegate bool DelegadoEspera();

        /// <summary>
        /// Método que realiza una espera hasta que cierto valor sea verdadero durante un máximo de tiempo
        /// </summary>
        /// <param name="valor">Valor al cual se espera que su estado sea verdadero o falso</param>
        /// <param name="valorEsperado">Valor de comparación</param>
        /// <param name="timeOut">Tiempo máximo de la espera en milisegundos</param>
        /// <returns>Verdadero si el valor a cambiado a verdadero antes de que finalizase el TimeOut</returns>
        public static bool Espera(ref bool valor, bool valorEsperado, int timeOut)
        {
            // Momento en el que finalizará la espera
            DateTime momentoTimeOut = DateTime.Now.AddMilliseconds(timeOut);

            while ((valor != valorEsperado) && (DateTime.Now < momentoTimeOut))
            {
                Application.DoEvents();
            }

            return valor == valorEsperado;
        }

        /// <summary>
        /// Método que realiza una espera hasta que cierto valor sea verdadero durante un máximo de tiempo
        /// </summary>
        /// <param name="valor">Valor al cual se espera que su estado sea verdadero o falso</param>
        /// <param name="valorEsperado">Valor de comparación</param>
        /// <param name="timeOut">Tiempo máximo de la espera en milisegundos</param>
        /// <returns>Verdadero si el valor a cambiado a verdadero antes de que finalizase el TimeOut</returns>
        public static bool Espera(ref object valor, object valorEsperado, int timeOut)
        {
            // Momento en el que finalizará la espera
            DateTime momentoTimeOut = DateTime.Now.AddMilliseconds(timeOut);

            while ((valor != valorEsperado) && (DateTime.Now < momentoTimeOut))
            {
                Application.DoEvents();
            }

            return valor == valorEsperado;
        }

        /// <summary>
        /// Devuelve el estado de la lista de threads
        /// </summary>
        /// <param name="textoFormateado">Texto válido para utilizar en la función string.Format.
        /// Debe contener {0}, {1}, {2} para ser válido</param>
        public static List<string> Resumen(string textoFormateado)
        {
            List<string> resultado = new List<string>();
            if (ListaThreadsLoop != null)
            {
                lock (BlockObject)
                {
                    foreach (OThreadLoop thread in ListaThreadsLoop)
                    {
                        string registro = string.Format(textoFormateado, thread.GetHashCode(), thread.GetType(), thread.Codigo, thread.Estado);
                        resultado.Add(registro);
                    }
                }
            }
            return resultado;
        }

        /// <summary>
        /// Registra en el log el estado de la lista de objetos
        /// </summary>
        /// <param name="textoFormateado">Texto válido para utilizar en la función string.Format.
        /// Debe contener {0}, {1}, {2} para ser válido</param>
        public static void RegistraEnLog(string textoFormateado)
        {
            if (ListaThreadsLoop != null)
            {
                List<string> listaResumen = Resumen(textoFormateado);
                foreach (string textoResumen in listaResumen)
                {
                    OLogsVAComun.GestionMemoria.Info("OThreadManager", textoResumen);
                }
            }
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Añade un nuevo Thread al sistema
        /// </summary>
        /// <param name="threadOrbita">Thread a añadir</param>
        internal static void NuevoThread(OThreadLoop threadOrbita)
        {
            // Añadimos a la lista
            if (ListaThreadsLoop != null)
            {
                lock (BlockObject)
                {
                    ListaThreadsLoop.Add(threadOrbita);
                }
            }
        }

        /// <summary>
        /// Añade un nuevo Thread al sistema
        /// </summary>
        /// <param name="threadOrbita">Thread a eliminar</param>
        internal static void EliminarThread(OThreadLoop threadOrbita)
        {
            // Añadimos a la lista
            if (ListaThreadsLoop != null)
            {
                lock (BlockObject)
                {
                    ListaThreadsLoop.Remove(threadOrbita);
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Thread donde se ha implementado el evento OnFinalize
    /// </summary>
    public class OThreadLoop : IDisposable
    {
        #region Atributo(s)
        /// <summary>
        /// Thread de ejecución de la tarea
        /// </summary>
        internal OHilo ThreadEjecucion;
        /// <summary>
        /// Prioridad del thread
        /// </summary>
        protected ThreadPriority Priority;
        /// <summary>
        /// Estado de funcionamiento del thread
        /// </summary>
        public EstadoThread Estado;
        /// <summary>
        /// Evento de reanudación de la suspensión
        /// </summary>
        private ManualResetEvent FinSuspensionEvent;
        /// <summary>
        /// Indica que se ha de salir del bucle de ejecución
        /// </summary>
        private bool FlagFinalizacion;
        /// <summary>
        /// Indica si la ejecución del evento Run se ha de realizar en el thread o fuera de él
        /// </summary>
        private bool EjecutarRunEnThread;
        /// <summary>
        /// Indica si la ejecución del evento Fin se ha de realizar en el thread o fuera de él
        /// </summary>
        private bool EjecutarFinEnThread;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Estado del thread
        /// </summary>
        protected ThreadState ThreadState
        {
            get
            {
                ThreadState resultado = ThreadState.Unstarted;

                if (this.ThreadEjecucion != null)
                {
                    resultado = this.ThreadEjecucion.Thread.ThreadState;
                }

                return resultado;
            }
        }

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
        /// Tiempo de descanso entre bucles del thread
        /// </summary>
        private int _TiempoSleep;
        /// <summary>
        /// Tiempo de descanso entre bucles del thread
        /// </summary>
        public int TiempoSleep
        {
            get { return _TiempoSleep; }
            set { _TiempoSleep = value; }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OThreadLoop(string codigo) :
            this(codigo, 1, ThreadPriority.Normal)
        {
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OThreadLoop(string codigo, int tiempoSleep, ThreadPriority threadPriority)
        {
            this.Codigo = codigo;
            this.TiempoSleep = tiempoSleep;
            this.Priority = threadPriority;
            this.FinSuspensionEvent = new ManualResetEvent(false);

            this.CrearThread();
            this.CrearSuscripcionRun(this.Ejecucion, true); // Delegado único
            this.CrearSuscripcionFin(this.FinEjecucion, true); // Delegado múltiple
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Lanza la ejecución del thread
        /// </summary>
        /// <param name="finalize">Indica la finalización del thread</param>
        private void LanzarEventoEjecucion(ref bool finalize)
        {
            try
            {
                if (this.OnEjecucion != null)
                {
                    if (this.EjecutarRunEnThread)
                    {
                        this.OnEjecucion(ref finalize);
                    }
                    else
                    {
                        object[] obj = new object[] { finalize };
                        App.FormularioPrincipal.Invoke(this.OnEjecucion, obj);
                        finalize = (bool)obj[0];
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.Threads.Info(exception, "LanzarEventoEjecucion");
            }
        }

        /// <summary>
        /// Lanza la el final de ejecución del thread
        /// </summary>
        private void LanzarEventoFinEjecucion()
        {
            try
            {
                if (this.OnFinEjecucion != null)
                {
                    if (this.EjecutarFinEnThread)
                    {
                        this.OnFinEjecucion();
                    }
                    else
                    {
                        App.FormularioPrincipal.Invoke(this.OnFinEjecucion);
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.Threads.Info(exception, "LanzarEventoFinEjecucion");
            }
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Inicio del thread
        /// </summary>
        public void Start()
        {
            if ((this.Estado == EstadoThread.ThreadInitial) || (this.Estado == EstadoThread.ThreadEnded))
            {
                this.FlagFinalizacion = false;
                this.Estado = EstadoThread.ThreadRunning;

                this.ThreadEjecucion = new OHilo(this.EjecucionInterna, this.Codigo, this.Priority, true, false);
                this.ThreadEjecucion.Iniciar();
            }
        }
        /// <summary>
        /// Inicio del thread
        /// </summary>
        public void StartPaused()
        {
            if ((this.Estado == EstadoThread.ThreadInitial) || (this.Estado == EstadoThread.ThreadEnded))
            {
                this.FlagFinalizacion = false;
                //this.CrearThread();
                this.Estado = EstadoThread.ThreadRunning;
                this.Pause();
                this.ThreadEjecucion = new OHilo(this.EjecucionInterna, this.Codigo, this.Priority, true, false);
                this.ThreadEjecucion.Iniciar();
            }
        }
        /// <summary>
        /// Fin del trehad
        /// </summary>
        public void Stop()
        {
            if (((this.ThreadEjecucion != null)) && ((this.Estado == EstadoThread.ThreadRunning) || (this.Estado == EstadoThread.ThreadSuspended) || (this.Estado == EstadoThread.ThreadSuspending)))
            {
                try
                {
                    this.ThreadEjecucion.Terminar();
                    bool cerrado = false;
                    while (!cerrado && this.ThreadEjecucion.EstaVivo())
                    {
                        cerrado = this.ThreadEjecucion.Join(10);
                        Application.DoEvents();
                    }

                    this.Estado = EstadoThread.ThreadEnded;
                    this.ThreadEjecucion = null;
                }
                catch (Exception exception)
                {
                    OLogsVAComun.Threads.Error(exception, "Stop");
                }
            }
        }
        /// <summary>
        /// Fin del trehad
        /// </summary>
        public void Stop(int milisecondsTimeout)
        {
            if (this.Estado == EstadoThread.ThreadRunning)
            {
                this.FlagFinalizacion = true;

                DateTime momentoTimeOut = DateTime.Now.AddMilliseconds(milisecondsTimeout);
                while ((this.Estado != EstadoThread.ThreadEnded) && (DateTime.Now < momentoTimeOut))
                {
                    OThreadManager.Espera(10);
                }
            }

            this.Stop();
        }
        /// <summary>
        /// Pasua de la ejecución del thread. Este método no debe ser llamado desde el propio thread
        /// </summary>
        /// <returns>Verdadero si la acción ha resultado exitosa</returns>
        public bool Pause()
        {
            bool resultado = false;

            if (this.Estado == EstadoThread.ThreadRunning)
            {
                this.Estado = EstadoThread.ThreadSuspending;
                this.FinSuspensionEvent.Reset();
                resultado = true;
            }

            return resultado;
        }
        /// <summary>
        /// Continua la ejecución del thread. Este método no debe ser llamado desde el propio thread
        /// </summary>
        /// <returns>Verdadero si la acción ha resultado exitosa</returns>
        public bool Resume()
        {
            bool resultado = false;

            if ((this.Estado == EstadoThread.ThreadSuspended) || (this.Estado == EstadoThread.ThreadSuspending))
            {
                this.Estado = EstadoThread.ThreadRunning;
                this.FinSuspensionEvent.Set();
                resultado = true;
            }

            return resultado;
        }
        /// <summary>
        /// Detiene la ejecución hasta que el semaforo se pone en verde
        /// </summary>
        /// <returns>Verdadero si la acción ha resultado exitosa</returns>
        public bool Wait()
        {
            bool resultado = false;

            if (this.Estado == EstadoThread.ThreadSuspending)
            {
                try
                {
                    this.Estado = EstadoThread.ThreadSuspended;
                    this.FinSuspensionEvent.WaitOne();
                    resultado = true;
                }
                catch (ThreadAbortException threadAbortException)
                {
                }
                catch (Exception exception)
                {
                    OLogsVAComun.Threads.Info(exception, "Wait");
                }
            }

            return resultado;
        }
        /// <summary>
        /// Elimina la memoria asignada por el objeto.
        /// </summary>
        public void Dispose()
        {
            //this.Stop();
            //this.DestruirThread();
        }
        /// <summary>
        /// Elimina la memoria asignada por el objeto.
        /// </summary>
        public void Dispose(int milisecondsTimeout)
        {
            //this.Stop(milisecondsTimeout);
            //this.DestruirThread();
        }
        /// <summary>
        /// Cambia la prioridad al thread
        /// </summary>
        /// <param name="threadPriority">Prioridad a establecer</param>
        public void ChangePriority(ThreadPriority threadPriority)
        {
            if (this.ThreadEjecucion != null)
            {
                if (this.Priority != threadPriority)
                {
                    this.Priority = threadPriority;
                    this.ThreadEjecucion.Thread.Priority = threadPriority;
                }
            }
        }
        /// <summary>
        /// Creación de la suscripción al evento de ejecución
        /// </summary>
        public void CrearSuscripcionRun(ThreadRun threadRun, bool ejecutarEnThread)
        {
            this.OnEjecucion = threadRun; // Este método no puede ser nunca múltiple
            this.EjecutarRunEnThread = ejecutarEnThread;
        }
        /// <summary>
        /// Creación de la suscripción al evento de finalización de la ejecución
        /// </summary>
        public void CrearSuscripcionFin(OSimpleMethod threadEnd, bool ejecutarEnThread)
        {
            this.OnFinEjecucion += threadEnd; // Este método puede ser múltiple
            this.EjecutarFinEnThread = ejecutarEnThread;
        }
        #endregion

        #region Método(s) virtual(es)
        /// <summary>
        /// Inicio del thread
        /// </summary>
        protected virtual void CrearThread()
        {
            this.Estado = EstadoThread.ThreadInitial;

            //this.ThreadEjecucion = new OHilo(this.EjecucionInterna, this.Codigo, this.Priority, true, false);
            OThreadManager.NuevoThread(this);
        }

        /// <summary>
        /// Fin del thread
        /// </summary>
        protected virtual void DestruirThread()
        {
            //this.OnEjecucion = null; // Delegado único
            //this.OnFinEjecucion -= FinEjecucion;

            //this.ThreadEjecucion = null;
            OThreadManager.EliminarThread(this);
        }

        /// <summary>
        /// Método a heredar para implementar la ejecución del thread.
        /// Este método se está ejecutando en un bucle. Para salir del bucle hay que devolver finalize a true.
        /// </summary>
        protected virtual void Ejecucion(ref bool finalize)
        {
            // Implementado en hijos
        }

        /// <summary>
        /// Método a heredar para implementar la ejecución del thread.
        /// Este método se está ejecutando en un bucle. Para salir del bucle hay que devolver finalize a true.
        /// </summary>
        protected virtual void FinEjecucion()
        {
            // Implementado en hijos
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Método donde realmente se ejecuta el thread.
        /// </summary>
        protected void EjecucionInterna()
        {
            if (this.OnEjecucion != null)
            {
                this.FlagFinalizacion = false;
                while ((!this.FlagFinalizacion) && (this.ThreadState != System.Threading.ThreadState.AbortRequested))
                {
                    try
                    {
                        //OThreadManager.EsperarSemaforo();
                        this.Wait();
                        bool flagFinalizacionInterno = false;

                        // Evento de ejecución del thread
                        this.LanzarEventoEjecucion(ref flagFinalizacionInterno);

                        // Se activará el flag de finalización bien cuando se diga de forma interna (desde el método OnEjecucion)
                        // o cuando se active desde el exterior (atributo FlagFinalización)
                        this.FlagFinalizacion |= flagFinalizacionInterno;
                    }
                    catch (ThreadAbortException)
                    {
                        this.Estado = EstadoThread.ThreadEnded;
                        return;
                    }
                    catch (Exception exception)
                    {
                        OLogsVAComun.Threads.Info(exception, "EjecucionInterna: " + this._Codigo);
                    }
                    Thread.Sleep(this._TiempoSleep);
                }
            }

            // Evento de finalización del thread
            if (this.ThreadState != System.Threading.ThreadState.AbortRequested)
            {
                this.LanzarEventoFinEjecucion();
            }

            this.Estado = EstadoThread.ThreadEnded;
        }
        #endregion

        #region Definición de delegado(s)
        /// <summary>
        /// Delegado que de la ejecución del thread
        /// </summary>
        protected ThreadRun OnEjecucion;

        /// <summary>
        /// Delegado que de la ejecución del fin del thread
        /// </summary>
        protected OSimpleMethod OnFinEjecucion;
        #endregion

        #region Enumerados
        /// <summary>
        /// Estado del thread
        /// </summary>
        public enum EstadoThread
        {
            /// <summary>
            /// El thread ha sido creado pero no está en funcionamiento
            /// </summary>
            ThreadInitial = 0,
            /// <summary>
            /// El thread está ejecutandose
            /// </summary>
            ThreadRunning = 1,
            /// <summary>
            /// El thread se está suspendiendo
            /// </summary>
            ThreadSuspending = 2,
            /// <summary>
            /// El thread está suspendido
            /// </summary>
            ThreadSuspended = 3,
            /// <summary>
            /// El thread se ha detenido
            /// </summary>
            ThreadEnded = 4
        }
        #endregion
    }

    public class OThreadsLoop: IDisposable
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de thrads de tipo loop
        /// </summary>
        private List<OThreadLoop> ListaThreads;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OThreadsLoop(string codigo, uint numeroThreads):
            this(codigo, numeroThreads, 1, ThreadPriority.Normal)
        {
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OThreadsLoop(string codigo, uint numeroThreads, int tiempoSleep, ThreadPriority threadPriority)
        {
            this.ListaThreads = new List<OThreadLoop>();

            for (int i = 0; i < numeroThreads; i++)
            {
                string codigoThead = codigo + i.ToString();
                OThreadLoop thread = new OThreadLoop(codigoThead, tiempoSleep, threadPriority);
                this.ListaThreads.Add(thread);
            }
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Inicio del thread
        /// </summary>
        public void Start()
        {
            this.ListaThreads.ForEach(delegate(OThreadLoop thread) { thread.Start(); });
        }
        /// <summary>
        /// Inicio del thread
        /// </summary>
        public void StartPaused()
        {
            this.ListaThreads.ForEach(delegate(OThreadLoop thread) { thread.StartPaused(); });
        }
        /// <summary>
        /// Fin del trehad
        /// </summary>
        public void Stop()
        {
            this.ListaThreads.ForEach(delegate(OThreadLoop thread) { thread.Stop(); });
        }
        /// <summary>
        /// Fin del trehad
        /// </summary>
        public void Stop(int milisecondsTimeout)
        {
            this.ListaThreads.ForEach(delegate(OThreadLoop thread) { thread.Stop(milisecondsTimeout); });
        }
        /// <summary>
        /// Pasua de la ejecución del thread. Este método no debe ser llamado desde el propio thread
        /// </summary>
        public void Pause()
        {
            this.ListaThreads.ForEach(delegate(OThreadLoop thread) { thread.Pause(); });
        }
        /// <summary>
        /// Continua la ejecución del thread. Este método no debe ser llamado desde el propio thread
        /// </summary>
        /// <returns>Verdadero si la acción ha resultado exitosa</returns>
        public void Resume()
        {
            this.ListaThreads.ForEach(delegate(OThreadLoop thread) { thread.Resume(); });
        }
        /// <summary>
        /// Detiene la ejecución hasta que el semaforo se pone en verde
        /// </summary>
        /// <returns>Verdadero si la acción ha resultado exitosa</returns>
        public void Wait()
        {
            this.ListaThreads.ForEach(delegate(OThreadLoop thread) { thread.Wait(); });
        }
        /// <summary>
        /// Elimina la memoria asignada por el objeto.
        /// </summary>
        public void Dispose()
        {
            this.ListaThreads.ForEach(delegate(OThreadLoop thread) { thread.Dispose(); });
        }
        /// <summary>
        /// Elimina la memoria asignada por el objeto.
        /// </summary>
        public void Dispose(int milisecondsTimeout)
        {
            this.ListaThreads.ForEach(delegate(OThreadLoop thread) { thread.Dispose(milisecondsTimeout); });
        }
        /// <summary>
        /// Cambia la prioridad al thread
        /// </summary>
        /// <param name="threadPriority">Prioridad a establecer</param>
        public void ChangePriority(ThreadPriority threadPriority)
        {
            this.ListaThreads.ForEach(delegate(OThreadLoop thread) { thread.ChangePriority(threadPriority); });
        }
        /// <summary>
        /// Creación de la suscripción al evento de ejecución
        /// </summary>
        public void CrearSuscripcionRun(ThreadRun threadRun, bool ejecutarEnThread)
        {
            this.ListaThreads.ForEach(delegate(OThreadLoop thread) { thread.CrearSuscripcionRun(threadRun, ejecutarEnThread); });
        }
        /// <summary>
        /// Creación de la suscripción al evento de finalización de la ejecución
        /// </summary>
        public void CrearSuscripcionFin(OSimpleMethod threadEnd, bool ejecutarEnThread)
        {
            this.ListaThreads.ForEach(delegate(OThreadLoop thread) { thread.CrearSuscripcionFin(threadEnd, ejecutarEnThread); });
        }
        #endregion
    }

    /// <summary>
    /// Delegado que de la ejecución del thread
    /// </summary>
    public delegate void ThreadRun(ref bool finalize);
}
