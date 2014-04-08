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
    /// Item Traza.
    /// </summary>
    [System.Serializable]
    public class ItemTraza : System.IDisposable
    {
        #region Atributos privados
        /// <summary>
        /// El nivel de registro de traza.
        /// </summary>
        NivelTraza _nivelTraza;
        /// <summary>
        /// Dia y hora de entrada en el registro. Si no  explicitamente esta propiedad ofrece la marca de tiempo de la creaci�n del objeto.
        /// </summary>
        System.DateTime _fecha;
        /// <summary>
        /// El procedimiento almacenado. Por defecto, <c>string.Empty</c>.
        /// </summary>
        string _procedimiento;
        /// <summary>
        /// Identificador de evento. Por defecto, <c>null</c>.
        /// </summary>
        int? _identificador;
        /// <summary>
        /// Argumentos adicionales que puede contener el item, adem�s del mensaje propiamente dicho.
        /// </summary>
        System.Collections.ArrayList _args;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.ItemTraza.
        /// </summary>
        public ItemTraza()
        {
            this._fecha = System.DateTime.Now;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.ItemTraza.
        /// </summary>
        /// <param name="nivelTraza">El nivel de registro de traza.</param>
        public ItemTraza(NivelTraza nivelTraza)
            : this()
        {
            this._nivelTraza = nivelTraza;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.ItemTraza.
        /// </summary>
        /// <param name="nivelTraza">El nivel de registro de traza.</param>
        /// <param name="procedimiento">El procedimiento almacenado.</param>
        public ItemTraza(NivelTraza nivelTraza, string procedimiento)
            : this(nivelTraza)
        {
            this._procedimiento = procedimiento;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.ItemTraza.
        /// </summary>
        /// <param name="nivelTraza">El nivel de registro de traza.</param>
        /// <param name="procedimiento">El procedimiento almacenado.</param>
        /// <param name="args">Argumentos del procedimiento almacenado.</param>
        public ItemTraza(NivelTraza nivelTraza, string procedimiento, System.Collections.ArrayList args)
            : this(nivelTraza, procedimiento)
        {
            this._args = args;
        }
        #endregion

        #region Destructores
        /// <summary>
        /// Indica si ya se llamo al m�todo Dispose. (default = false)
        /// </summary>
        bool disposed = false;
        /// <summary>
        /// Implementa IDisposable.
        /// No  hacer  este  m�todo  virtual.
        /// Una clase derivada no deber�a ser capaz de  reemplazar este m�todo.
        /// </summary>
        public void Dispose()
        {
            // Llamo al m�todo que  contiene la l�gica para liberar los recursos de esta clase.
            Dispose(true);
            // Este objeto ser� limpiado por el m�todo Dispose.
            // Llama al m�todo del recolector de basura, GC.SuppressFinalize.
            System.GC.SuppressFinalize(this);
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
                // Finalizar correctamente los recursos no manejados.
                this._procedimiento = null;
                this._identificador = null;
                this._args = null;
                // Marcar como desechada � desechandose, de forma que no se puede ejecutar el c�digo dos veces.
                disposed = true;
            }
        }
        /// <summary>
        /// Destructor(es) de clase.
        /// En caso de que se nos olvide �desechar� la clase, el GC llamar� al destructor, que tamb�n ejecuta la l�gica anterior para liberar los recursos.
        /// </summary>
        ~ItemTraza()
        {
            // Llamar a Dispose(false) es �ptimo en terminos de legibilidad y mantenimiento.
            Dispose(false);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// El nivel de registro de traza.
        /// </summary>
        public NivelTraza NivelTraza
        {
            get { return this._nivelTraza; }
            set { this._nivelTraza = value; }
        }
        /// <summary>
        /// D�a y hora de entrada en el registro. Si no  explicitamente
        /// esta propiedad ofrece la marca de tiempo de la creaci�n del
        /// objeto.
        /// </summary>
        public System.DateTime Fecha
        {
            get { return this._fecha; }
            set { this._fecha = value; }
        }
        /// <summary>
        /// El procedimiento almacenado. Por defecto <c>string.Empty</c>.
        /// </summary>
        public string Procedimiento
        {
            get { return this._procedimiento; }
            set { this._procedimiento = value; }
        }
        /// <summary>
        /// Identificador de evento. Por defecto <c>null</c>.
        /// </summary>
        public int? Identificador
        {
            get { return this._identificador; }
            set { this._identificador = value; }
        }
        /// <summary>
        /// Argumentos adicionales que puede contener el item, adem�s del mensaje propiamente dicho.
        /// </summary>
        public System.Collections.ArrayList Argumentos
        {
            get { return this._args; }
        }
        #endregion

        #region M�todos p�blicos
        /// <summary>
        /// Argumentos adicionales que puede contener el item, adem�s del mensaje propiamente dicho.
        /// </summary>
        public void SetArgumentos(System.Collections.ArrayList argumentos)
        {
            this._args = argumentos;
        }
        #endregion
    }
}