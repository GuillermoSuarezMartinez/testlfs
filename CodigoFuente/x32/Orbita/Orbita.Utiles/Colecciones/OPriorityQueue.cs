//***********************************************************************
// Assembly         : Orbita.Utiles
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
using System.Collections.Generic;
namespace Orbita.Utiles
{
    /// <summary>
    /// Implementación de una cola con prioridad de encolamiento.
    /// La prioridad está definida mediante un número entero.
    /// Cuanto más bajo sea el valor más prioridad tendrá.
    /// </summary>
    /// <typeparam name="TValue">Tipos de valores a almacenar en la cola</typeparam>
    public class OPriorityQueue<TValue> : OPriorityQueue<TValue, int> { }

    /// <summary>
    /// Implementación de una cola con prioridad de encolamiento.
    /// Cuanto más bajo sea el valor de prioridad más prioridad tendrá.
    /// </summary>
    /// <typeparam name="TValue">Tipos de valores a almacenar en la cola</typeparam>
    /// <typeparam name="TPriority">Tipo de dato de la prioridad</typeparam>
    public class OPriorityQueue<TValue, TPriority> where TPriority : IComparable
    {
        #region Atributos
        /// <summary>
        /// Diccionario ordenado de colas interno
        /// </summary>
        private SortedDictionary<TPriority, Queue<TValue>> storage;
        #endregion

        #region Propiedades
        /// <summary>
        /// Número de elementos de la cola
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Indica que la cola está vacía
        /// </summary>
        public bool Empty { get { return Count == 0; } }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OPriorityQueue()
        {
            this.storage = new SortedDictionary<TPriority, Queue<TValue>>();
            this.Count = 0;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Desencolar
        /// </summary>
        /// <returns>Valor desencolado</returns>
        public TValue Dequeue()
        {
            if (this.Empty)
            {
                throw new Exception("PriorityQueue is empty");
            }
            else
            {
                foreach (Queue<TValue> q in storage.Values)
                {
                    // we use a sorted dictionary
                    if (q.Count > 0)
                    {
                        this.Count--;
                        return q.Dequeue();
                    }
                }
            }
            return default(TValue); // not supposed to reach here.
        }

        /// <summary>
        /// Obtener el primer valor de la cola sin desencolar
        /// </summary>
        /// <returns></returns>
        public TValue Peek()
        {
            if (this.Empty)
            {
                throw new Exception("PriorityQueue is empty");
            }
            else
            {
                foreach (Queue<TValue> q in storage.Values)
                {
                    if (q.Count > 0)
                    {
                        return q.Peek();
                    }
                }
            }
            return default(TValue); // not supposed to reach here.
        }

        /// <summary>
        /// Encolar con prioridad
        /// </summary>
        /// <param name="item">Valor a encolar</param>
        public void Enqueue(TValue item)
        {
            this.Enqueue(item, default(TPriority));
        }

        /// <summary>
        /// Encolar con prioridad
        /// </summary>
        /// <param name="item">Valor a encolar</param>
        /// <param name="priority">prioridad de encolamiento</param>
        public void Enqueue(TValue item, TPriority priority)
        {
            if (!storage.ContainsKey(priority))
            {
                storage.Add(priority, new Queue<TValue>());
                Enqueue(item, priority);
            }
            else
            {
                storage[priority].Enqueue(item);
                this.Count++;
            }
        }

        /// <summary>
        /// Quita todos los objetos de la colección.
        /// </summary>
        public void Clear()
        {
            foreach (Queue<TValue> q in storage.Values)
            {
                q.Clear();
            }
            storage.Clear();
        }
        #endregion
    }
}