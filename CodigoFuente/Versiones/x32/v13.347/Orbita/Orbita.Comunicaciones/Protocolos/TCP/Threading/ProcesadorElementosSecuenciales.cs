//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Threading
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Threading
{
    /// <summary>
    /// Esta clase se utiliza para procesar elementos de forma secuencial en procesos multihilo (Multithread).
    /// </summary>
    /// <typeparam name="TElemento">Tipo de elemento.</typeparam>
    public class ProcesadorElementosSecuenciales<TElemento>
    {
        #region Atributos
        /// <summary>
        /// El método delegado que se llama para procesar elementos.
        /// </summary>
        private readonly Action<TElemento> _metodo;
        /// <summary>
        /// Cola de elementos. Se utiliza para procesar elementos secuencialmente.
        /// </summary>
        private readonly Queue<TElemento> _cola;
        /// <summary>
        /// Una referencia a la tarea actual que se está procesando un elemento en el método ProcesarElemento.
        /// </summary>
        private Task _tareaActual;
        /// <summary>
        /// Indica el estado del procesamiento de elementos.
        /// </summary>
        private bool _estaProcesando;
        /// <summary>
        /// Un valor booleano para controlar el funcionamiento de la clase.
        /// </summary>
        private bool _estaIniciado;
        /// <summary>
        /// Este objeto sólo se utiliza para la sincronización de threads (bloqueo).
        /// </summary>
        private readonly object _objSincronizacion = new object();
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ProcesadorElementosSecuenciales.
        /// </summary>
        /// <param name="metodo">El método delegado que se llama para procesar elementos.</param>
        public ProcesadorElementosSecuenciales(Action<TElemento> metodo)
        {
            _metodo = metodo;
            _cola = new Queue<TElemento>();
        }
        #endregion Constructor

        #region Métodos públicos
        /// <summary>
        /// Añadir un elemento a la cola y procesarlo.
        /// </summary>
        /// <param name="elemento">Elemento que se añade a la cola.</param>
        public void EncolarMensaje(TElemento elemento)
        {
            //  Añadir el elemento a la cola y comenzar una nueva tarea si es necesario.
            lock (_objSincronizacion)
            {
                if (!_estaIniciado)
                {
                    return;
                }

                _cola.Enqueue(elemento);
                if (!_estaProcesando)
                {
                    //  Task representa una operación asíncrona.
                    _tareaActual = Task.Factory.StartNew(ProcesarElemento);
                }
            }
        }
        /// <summary>
        /// Iniciar el procesamiento de elementos.
        /// </summary>
        public void Iniciar()
        {
            _estaIniciado = true;
        }
        /// <summary>
        /// Terminar el procesamiento de elementos y esperar la detención del elemento actual.
        /// </summary>
        public void Terminar()
        {
            _estaIniciado = false;

            //  Borrar todos los mensajes entrantes.
            lock (_objSincronizacion)
            {
                _cola.Clear();
            }

            //  Comprobar si existen mensajes que deban ser procesados.
            if (!_estaProcesando)
            {
                return;
            }

            //  Esperar a terminar el procesamiento actual.
            try
            {
                _tareaActual.Wait();
            }
            catch
            {
                //  Empty.
            }
        }
        #endregion Métodos públicos

        #region Métodos privados
        /// <summary>
        /// Este método se ejecuta en un nuevo hilo (thread) para procesar elementos de la cola.
        /// </summary>
        private void ProcesarElemento()
        {
            //  Intentar obtener un elemento de la cola y procesarlo.
            TElemento elemento;
            lock (_objSincronizacion)
            {
                if (!_estaIniciado || _estaProcesando)
                {
                    return;
                }
                if (_cola.Count <= 0)
                {
                    return;
                }
                _estaProcesando = true;
                elemento = _cola.Dequeue();
            }

            //  Procesar el elemento (llamar al metodo delegado).
            _metodo(elemento);

            //  Procesar el siguiente elemento disponible.
            lock (_objSincronizacion)
            {
                _estaProcesando = false;
                if (_cola.Count <= 0)
                {
                    return;
                }

                //  Iniciar una nueva tarea.
                _tareaActual = Task.Factory.StartNew(ProcesarElemento);
            }
        }
        #endregion Métodos privados
    }
}