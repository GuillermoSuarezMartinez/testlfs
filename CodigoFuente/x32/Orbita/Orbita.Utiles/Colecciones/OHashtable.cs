//***********************************************************************
// Assembly         : OrbitaUtiles
// Author           : crodriguez
// Created          : 03-03-2011
//
// Last Modified By : crodriguez
// Last Modified On : 03-03-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections;
using System.Runtime.Serialization;
namespace Orbita.Utiles
{
    /// <summary>
    /// Colecci�n de que representa una tabla de dispersi�n (Hash).
    /// </summary>
    [Serializable]
    public class OHashtable : Hashtable, IDisposable
    {
        #region Atributo(s)
        #region Evento(s)
        /// <summary>
        /// Evento que se ejecuta tras a�adir un objeto a la colecci�n.
        /// </summary>
        public event ManejadorEvento OnDespuesAdicionar;
        /// <summary>
        /// Evento que se ejecuta tras eliminar un objeto de la colecci�n.
        /// </summary>
        public event ManejadorEvento OnDespuesEliminar;
        #endregion
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Inicializar una nueva instancia de la clase OHashtable.
        /// </summary>
        public OHashtable()
            : base() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OHashtable.
        /// </summary>
        /// <param name="info">Objeto System.Runtime.Serialization.SerializationInfo 
        /// que contiene la informaci�n que se requiere para serializar el objeto
        /// System.Collections.Hashtable.</param>
        /// <param name="context">Objeto System.Runtime.Serialization.StreamingContext
        /// que contiene el origen y el destino de la secuencia serializada asociada a 
        /// System.Collections.Hashtable.</param>
        protected OHashtable(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OHashtable.
        /// </summary>
        /// <param name="table">Colecci�n hashtable.</param>
        OHashtable(Hashtable table)
            : base(table) { }
        #endregion

        #region Destructor(es)
        /// <summary>
        /// Indica si ya se llamo al m�todo Dispose. (default = false)
        /// </summary>
        bool disposed = false;
        /// <summary>
        /// Implementa IDisposable.
        /// No  hacer  este  m�todo  virtual.
        /// Una clase derivada no deber�a ser
        /// capaz de  reemplazar este m�todo.
        /// </summary>
        public void Dispose()
        {
            // Llamo al m�todo que  contiene la l�gica
            // para liberar los recursos de esta clase.
            Dispose(true);
            // Este objeto ser� limpiado por el m�todo Dispose.
            // Llama al m�todo del recolector de basura, GC.SuppressFinalize.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// M�todo  sobrecargado de  Dispose que ser�  el que
        /// libera los recursos. Controla que solo se ejecute
        /// dicha l�gica una  vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name="disposing">Indica si llama al m�todo Dispose.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Preguntar si Dispose ya fue llamado.
            if (!this.disposed)
            {
                // Marcar como desechada � desechandose,
                // de forma que no se puede ejecutar el
                // c�digo dos veces.
                disposed = true;
            }
        }
        /// <summary>
        /// Destructor(es) de clase.
        /// En caso de que se nos olvide �desechar� la clase,
        /// el GC llamar� al destructor, que tamb�n ejecuta 
        /// la l�gica anterior para liberar los recursos.
        /// </summary>
        ~OHashtable()
        {
            // Llamar a Dispose(false) es �ptimo en terminos
            // de legibilidad y mantenimiento.
            Dispose(false);
        }
        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Agrega un elemento con  la clave y el  valor 
        /// especificados a System.Collections.Hashtable.
        /// </summary>
        /// <param name="key">Clave del elemento que se va a agregar.</param>
        /// <param name="value">Valor del elemento que se va a agregar. 
        /// El valor puede ser null.</param>
        public override void Add(object key, object value)
        {
            // A�adir un nuevo elemento a la colecci�n.
            //
            // Bloquear este m�todo por si se usan Threads.
            lock (this)
            {
                if (!Existe(key))
                {
                    base.Add(key, value);

                    // En C# debemos comprobar que el evento no sea null.
                    if (OnDespuesAdicionar != null)
                    {
                        // El evento se lanza como cualquier delegado.
                        OnDespuesAdicionar(this, new OEventArgs(key));
                    }
                }
            }
        }
        /// <summary>
        /// M�todo de borrado del elemento en la colecci�n.
        /// </summary>
        /// <param name="clave">Clave.</param>
        public virtual void Eliminar(object clave)
        {
            // A�adir un nuevo elemento a la colecci�n.
            //
            // Bloquear este m�todo por si se usan Threads.
            lock (this)
            {
                if (Existe(clave))
                {
                    base.Remove(clave);

                    // En C# debemos comprobar que el evento no sea null.
                    if (OnDespuesEliminar != null)
                    {
                        // El evento se lanza como cualquier delegado.
                        OnDespuesEliminar(this, new OEventArgs(clave));
                    }
                }
            }
        }
        /// <summary>
        /// M�todo contador de elementos de la colecci�n.
        /// </summary>
        /// <returns>N�mero de elementos de la colecci�n.</returns>
        public int Contar()
        {
            // M�todo 'Count' de la colecci�n.
            return base.Count;
        }
        /// <summary>
        /// M�todo de comprobaci�n de aparici�n del objeto en la colecci�n.
        /// </summary>
        /// <param name="clave">Identificar de key en object.</param>
        /// <returns>La existencia o no del objeto.</returns>
        public bool Existe(object clave)
        {
            // Comprobar si el ID indicado existe en la colecci�n.
            // Devolver verdadero o falso, seg�n sea el caso.
            return base.ContainsKey(clave);
        }
        /// <summary>
        /// M�todo de borrado total de la colecci�n.
        /// </summary>
        public void Limpiar()
        {
            // Borrar el contenido de la colecci�n.
            base.Clear();
        }
        /// <summary>
        /// Clonar una copia superficial del objeto.
        /// </summary>
        /// <returns>Una nueva colecci�n clonada.</returns>
        public virtual object Clonar()
        {
            return new OHashtable(this);
        }
        /// <summary>
        /// Copia los elementos de la interfaz System.Collections.ICollection en un objeto
        ///  System.Array, a partir de un �ndice determinado de la clase System.Array.
        /// </summary>
        /// <param name="array">Objeto System.Array unidimensional que constituye el destino 
        /// de los elementos copiados de la interfaz System.Collections.ICollection. 
        /// System.Array debe tener una indizaci�n de base cero.</param>
        /// <param name="indice">�ndice de base cero de array donde comienza la copia.</param>
        public void CopiarA(Exception[] array, int indice)
        {
            this.CopyTo(array, indice);
        }
        /// <summary>
        /// Implementa la interfaz de System.Runtime.Serialization.ISerializable y devuelve
        //  los datos necesarios para serializar System.Collections.Hashtable.
        /// </summary>
        /// <param name="info">Objeto System.Runtime.Serialization.SerializationInfo que contiene 
        /// la informaci�n que se requiere para serializar System.Collections.Hashtable.</param>
        /// <param name="context">Objeto System.Runtime.Serialization.StreamingContext que contiene 
        /// el origeny el destino de la secuencia serializada asociada a System.Collections.Hashtable.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
        #endregion

        #region M�todo(s) privado(es)
        /// <summary>
        /// Copia los elementos de la interfaz System.Collections.ICollection en un objeto
        ///  System.Array, a partir de un �ndice determinado de la clase System.Array.
        /// </summary>
        /// <param name="array">Objeto System.Array unidimensional que constituye el destino 
        /// de los elementos copiados de la interfaz System.Collections.ICollection. 
        /// System.Array debe tener una indizaci�n de base cero.</param>
        /// <param name="indice">�ndice de base cero de array donde comienza la copia.</param>
        void CopyTo(Exception[] array, int indice)
        {
            base.CopyTo(array, indice);
        }
        #endregion
    }
}