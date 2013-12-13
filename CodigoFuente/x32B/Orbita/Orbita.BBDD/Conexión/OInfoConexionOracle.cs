//***********************************************************************
// Assembly         : Orbita.BBDD
// Author           : vnicolau
// Created          : 08-18-2011
//
// Last Modified By : vnicolau
// Last Modified On : 08-18-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************

namespace Orbita.BBDD
{
    /// <summary>
    /// Informaci�n de la conexi�n de Oracle.
    /// </summary>
    public class OInfoConexionOracle : OInfoConexion
    {
        #region Atributos protegidos
        /// <summary>
        /// Puerto de conexi�n por defecto
        /// </summary>
        protected const int DefaultPort = 1521;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase InfoConexion.
        /// </summary>
        public OInfoConexionOracle()
        {
            this.Puerto = DefaultPort;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase InfoConexion.
        /// </summary>
        /// <param name="timeout">Timeout de conexi�n.</param>
        public OInfoConexionOracle(int timeout)
            : base(timeout)
        {
            this.Puerto = DefaultPort;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase InfoConexion.
        /// </summary>
        /// <param name="instancia">Nombre de la instancia de base de datos.</param>
        /// <param name="baseDatos">Nombre de la base de datos.</param>
        /// <param name="usuario">Usuario de las credenciales de base de datos.</param>
        /// <param name="password">Password de las credenciales de base de datos.</param>
        public OInfoConexionOracle(string instancia, string baseDatos, string usuario, string password)
            : base(instancia, baseDatos, usuario, password)
        {
            this.Puerto = DefaultPort;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase InfoConexion.
        /// </summary>
        /// <param name="instancia">Nombre de la instancia de base de datos.</param>
        /// <param name="puerto">N�mero de puerto al que se conectar�.</param>
        /// <param name="baseDatos">Nombre de la base de datos.</param>
        /// <param name="usuario">Usuario de las credenciales de base de datos.</param>
        /// <param name="password">Password de las credenciales de base de datos.</param>
        public OInfoConexionOracle(string instancia, int puerto, string baseDatos, string usuario, string password)
            : base(instancia, baseDatos, usuario, password)
        {
            this.Puerto = puerto;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase InfoConexion.
        /// </summary>
        /// <param name="instancia">Nombre de la instancia de base de datos.</param>
        /// <param name="baseDatos">Nombre de la base de datos.</param>
        /// <param name="usuario">Usuario de las credenciales de base de datos.</param>
        /// <param name="password">Password de las credenciales de base de datos.</param>
        /// <param name="timeout">Timeout de conexi�n.</param>
        public OInfoConexionOracle(string instancia, string baseDatos, string usuario, string password, int timeout)
            : base(instancia, baseDatos, usuario, password, timeout)
        {
            this.Puerto = DefaultPort;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase InfoConexion.
        /// </summary>
        /// <param name="instancia">Nombre de la instancia de base de datos.</param>
        /// <param name="puerto">N�mero de puerto al que se conectar�.</param>
        /// <param name="baseDatos">Nombre de la base de datos.</param>
        /// <param name="usuario">Usuario de las credenciales de base de datos.</param>
        /// <param name="password">Password de las credenciales de base de datos.</param>
        /// <param name="timeout">Timeout de conexi�n.</param>
        public OInfoConexionOracle(string instancia, int puerto, string baseDatos, string usuario, string password, int timeout)
            : base(instancia, baseDatos, usuario, password, timeout)
        {
            this.Puerto = puerto;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// N�mero de puerto al que se conectar�.
        /// </summary>
        public int Puerto { get; set; }
        #endregion
    }
}