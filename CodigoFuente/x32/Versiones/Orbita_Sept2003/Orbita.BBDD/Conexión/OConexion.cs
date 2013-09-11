//***********************************************************************
// Assembly         : Orbita.BBDD
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-18-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Data.SqlClient;
namespace Orbita.BBDD
{
    /// <summary>
    /// Clase que almacena los datos necesarios �tiles para el uso concatenado de transacciones.
    /// </summary>
    public class OConexion : IDisposable
    {
        #region Atributos privados
        /// <summary>
        /// Identificador de transacci�n.
        /// </summary>
        Guid identificador;
        /// <summary>
        /// Conexi�n de base de datos.
        /// </summary>
        SqlConnection conexion;
        /// <summary>
        /// Transacci�n de base de datos.
        /// </summary>
        SqlTransaction transaccion;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OConexion.
        /// </summary>
        /// <param name="infoConexion">Informaci�n de la conexi�n.</param>
        public OConexion(string infoConexion)
        {
            // Crear la conexi�n.
            this.conexion = new SqlConnection(infoConexion);
        }
        #endregion

        #region Destructores
        /// <summary>
        /// Indica si ya se llamo al m�todo Dispose. (Default = false)
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
                if (disposing)
                {
                    // Llamar a dispose de todos los recursos manejados.
                    this.conexion.Dispose();
                    this.transaccion.Dispose();
                }

                // Finalizar correctamente los recursos no manejados.
                this.identificador = Guid.Empty;

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
        ~OConexion()
        {
            // Llamar a Dispose(false) es �ptimo en terminos de legibilidad y mantenimiento.
            Dispose(false);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Identificador de transacci�n.
        /// </summary>
        public Guid Identificador
        {
            get { return this.identificador; }
            set { this.identificador = value; }
        }
        /// <summary>
        /// Conexi�n de base de datos.
        /// </summary>
        public SqlConnection Conexion
        {
            get { return this.conexion; }
            set { this.conexion = value; }
        }
        /// <summary>
        /// Transacci�n de base de datos.
        /// </summary>
        public SqlTransaction Transaccion
        {
            get { return this.transaccion; }
            set { this.transaccion = value; }
        }
        #endregion

        #region M�todos p�blicos
        /// <summary>
        /// Iniciar transacci�n.
        /// </summary>
        public string Iniciar()
        {
            if (this.conexion.State == System.Data.ConnectionState.Closed)
            {
                // Abrir la conexi�n.
                this.conexion.Open();
                // Iniciar y asignar la transacci�n.
                this.transaccion = this.conexion.BeginTransaction();
            }
            return this.identificador.ToString();
        }
        /// <summary>
        /// Iniciar transacci�n con un nivel de bloqueo espec�fico.
        /// </summary>
        public string Iniciar(System.Data.IsolationLevel iso)
        {
            if (this.conexion.State == System.Data.ConnectionState.Closed)
            {
                // Abrir la conexi�n.
                this.conexion.Open();
                // Iniciar y asignar la transacci�n con un nivel de bloque espec�fico.
                this.transaccion = this.conexion.BeginTransaction(iso);
            }
            return this.identificador.ToString();
        }
        #endregion
    }
}