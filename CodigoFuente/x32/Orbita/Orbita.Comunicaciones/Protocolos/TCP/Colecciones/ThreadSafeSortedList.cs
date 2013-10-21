//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Colecciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System.Collections.Generic;
using System.Threading;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Colecciones
{
    /// <summary>
    /// Esta clase se utiliza para guardar objetos de tipo clave-valor de forma segura.
    /// Se utiliza internamente System.Collections.Generic.SortedList.
    /// </summary>
    /// <typeparam name="TK">Tipo clave.</typeparam>
    /// <typeparam name="TV">Tipo valor.</typeparam>
    public class ThreadSafeSortedList<TK, TV>
    {
        #region Atributos protegidos
        /// <summary>
        /// Colección interna para almacenar elementos.
        /// </summary>
        protected readonly SortedList<TK, TV> Elementos;
        /// <summary>
        /// Utilizado para sincronizar el acceso a la lista de elementos.
        /// </summary>
        protected readonly ReaderWriterLockSlim Lock;
        #endregion Atributos protegidos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ThreadSafeSortedList.
        /// </summary>
        public ThreadSafeSortedList()
        {
            Elementos = new SortedList<TK, TV>();
            Lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        }
        #endregion Constructor

        #region Propiedades públicas
        /// <summary>
        /// Obtener el número de elementos de la colección.
        /// </summary>
        public int Contar
        {
            get
            {
                Lock.EnterReadLock();
                try
                {
                    return Elementos.Count;
                }
                finally
                {
                    Lock.ExitReadLock();
                }
            }
            set { throw new System.NotImplementedException(); }
        }
        /// <summary>
        /// Obtener/añadir/reemplazar un elemento por clave.
        /// </summary>
        /// <param name="key">Valor de la clave.</param>
        /// <returns>Elemento asociado con this clave.</returns>
        public TV this[TK key]
        {
            get
            {
                Lock.EnterReadLock();
                try
                {
                    return Elementos.ContainsKey(key) ? Elementos[key] : default(TV);
                }
                finally
                {
                    Lock.ExitReadLock();
                }
            }
            set
            {
                Lock.EnterWriteLock();
                try
                {
                    Elementos[key] = value;
                }
                finally
                {
                    Lock.ExitWriteLock();
                }
            }
        }
        #endregion Propiedades públicas

        #region Métodos públicos
        /// <summary>
        /// Evaluar si la colección contiene la clave especificada.
        /// </summary>
        /// <param name="key">Clave a evaluar.</param>
        /// <returns>True; si la colección contiene la clave proporcionada.</returns>
        public bool ContieneClave(TK key)
        {
            Lock.EnterReadLock();
            try
            {
                return Elementos.ContainsKey(key);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }
        /// <summary>
        /// Evaluar si la colección contiene el elemento especificado.
        /// </summary>
        /// <param name="elemento">Elemento a evaluar.</param>
        /// <returns>True; si la colección contiene el elemento proporcionado.</returns>
        public bool ContieneValor(TV elemento)
        {
            Lock.EnterReadLock();
            try
            {
                return Elementos.ContainsValue(elemento);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }
        /// <summary>
        /// Eliminar un elemento de la colección.
        /// </summary>
        /// <param name="key">Clave del elemento a eliminar.</param>
        public bool Eliminar(TK key)
        {
            Lock.EnterWriteLock();
            try
            {
                if (!Elementos.ContainsKey(key))
                {
                    return false;
                }

                Elementos.Remove(key);
                return true;
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }
        /// <summary>
        /// Obtener todos los elementos de la colección.
        /// </summary>
        /// <returns>Colección de elementos.</returns>
        public List<TV> ObtenerTodosLosElementos()
        {
            Lock.EnterReadLock();
            try
            {
                return new List<TV>(Elementos.Values);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }
        /// <summary>
        /// Obtener el primer elemento de la colección.
        /// </summary>
        /// <returns>Primer elemento.</returns>
        public TV ObtenerPrimerElemento()
        {
            Lock.EnterReadLock();
            try
            {
                if (Elementos.Count == 0) return default(TV);
                var key = Elementos.Keys[0];
                return Elementos.ContainsKey(key) ? Elementos[key] : default(TV);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }
        /// <summary>
        /// Eliminar todos los elementos de la colección.
        /// </summary>
        public void EliminarTodo()
        {
            Lock.EnterWriteLock();
            try
            {
                Elementos.Clear();
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }
        /// <summary>
        /// Obtener todos los elementos de la colección, previamente los elimina.
        /// </summary>
        /// <returns>Colección de elementos.</returns>
        public List<TV> ObtenerYEliminarTodosLosElementos()
        {
            Lock.EnterWriteLock();
            try
            {
                var list = new List<TV>(Elementos.Values);
                Elementos.Clear();
                return list;
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }
        #endregion Métodos públicos
    }
}