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
namespace Orbita.BBDD
{
    /// <summary>
    /// Informaci�n de la conexi�n.
    /// </summary>
    public class OInfoConexion
    {
        #region Constantes
        /// <summary>
        /// Timeout por defecto en segundos.
        /// </summary>
        protected const int DefaultTimeout = 120;
        #endregion

        #region Atributos privados
        /// <summary>
        /// Nombre de la instancia de base de datos.
        /// </summary>
        string instancia;
        /// <summary>
        /// Nombre de la base de datos.
        /// </summary>
        string baseDatos;
        /// <summary>
        /// Usuario de autenticaci�n de base de datos.
        /// </summary>
        string usuario;
        /// <summary>
        /// Password de autenticaci�n de base de datos.
        /// </summary>
        string password;
        /// <summary>
        /// Timeout de conexi�n a base de datos.
        /// </summary>
        int timeout;
        /// <summary>
        /// Puerto de conexi�n.
        /// </summary>
        int port;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase InfoConexion.
        /// </summary>
        public OInfoConexion()
            : this(DefaultTimeout) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase InfoConexion.
        /// </summary>
        /// <param name="timeout">Timeout de conexi�n.</param>
        public OInfoConexion(int timeout)
        {
            this.timeout = timeout;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase InfoConexion.
        /// </summary>
        /// <param name="instancia">Nombre de la instancia de base de datos.</param>
        /// <param name="baseDatos">Nombre de la base de datos.</param>
        /// <param name="usuario">Usuario de las credenciales de base de datos.</param>
        /// <param name="password">Password de las credenciales de base de datos.</param>
        public OInfoConexion(string instancia, string baseDatos, string usuario, string password)
            : this(instancia, baseDatos, usuario, password, DefaultTimeout) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase InfoConexion.
        /// </summary>
        /// <param name="instancia">Nombre de la instancia de base de datos.</param>
        /// <param name="baseDatos">Nombre de la base de datos.</param>
        /// <param name="usuario">Usuario de las credenciales de base de datos.</param>
        /// <param name="password">Password de las credenciales de base de datos.</param>
        /// <param name="timeout">Timeout de conexi�n.</param>
        public OInfoConexion(string instancia, string baseDatos, string usuario, string password, int timeout)
            : this(timeout)
        {
            this.instancia = instancia;
            this.baseDatos = baseDatos;
            this.usuario = usuario;
            this.password = password;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase InfoConexion a trav�s de una cadena de conexion para SQL Server
        /// </summary>
        /// <param name="cadenaConexion">Cadena de conexion a la base de datos SQL Server. La ideal seria esta: @"Data Source={0}; Initial Catalog={1}; User Id={2}; Password={3}; Connect Timeout={4}". Se puede omitir el �ltimo par�metro, 'Connect Timeout', que por defecto ser� de InfoConexion.DefaultTimeout segundos.</param>
        public OInfoConexion(string cadenaConexion)
        {
            // Hay que procesar la cadena de conexi�n, extrayendo los datos y almacen�ndolos.
            this.instancia = "Nombre de m�quina no especificado";
            this.baseDatos = "Nombre de base de datos no especificado";
            this.usuario = "Nombre de usuario no especificado";
            this.password = "Contrase�a de usuario no especificada";
            this.timeout = OInfoConexion.DefaultTimeout;

            if (!string.IsNullOrEmpty(cadenaConexion))
            {
                char[] separador = { ';' };
                string[] partes = cadenaConexion.Split(separador);
                foreach (string parte in partes)
                {
                    if (parte.Trim().StartsWith("Data Source", System.StringComparison.CurrentCulture))
                    {
                        // Nombre de la m�quina.
                        this.instancia = parte.Replace("Data Source", "").Replace("=", "").Trim();
                    }
                    if (parte.Trim().StartsWith("Initial Catalog", System.StringComparison.CurrentCulture))
                    {
                        // Nombre de la base de datos.
                        this.baseDatos = parte.Replace("Initial Catalog", "").Replace("=", "").Trim();
                    }
                    if (parte.Trim().StartsWith("User Id", System.StringComparison.CurrentCulture))
                    {
                        // Nombre de usuario.
                        this.usuario = parte.Replace("User Id", "").Replace("=", "").Trim();
                    }
                    if (parte.Trim().StartsWith("Password", System.StringComparison.CurrentCulture))
                    {
                        // Contrase�a del usuario.
                        this.password = parte.Replace("Password", "").Replace("=", "").Trim();
                    }
                    if (parte.Trim().StartsWith("Connect Timeout", System.StringComparison.CurrentCulture))
                    {
                        // Nombre de la m�quina.
                        int to;
                        if (int.TryParse(parte.Replace("Connect Timeout", "").Replace("=", "").Trim(), out to))
                        {
                            this.timeout = to;
                        }
                    }
                }
            }
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Nombre de la instancia de base de datos.
        /// </summary>
        public string Instancia
        {
            get { return this.instancia; }
            set { this.instancia = value; }
        }
        /// <summary>
        /// Nombre de la base de datos.
        /// </summary>
        public string BaseDatos
        {
            get { return this.baseDatos; }
            set { this.baseDatos = value; }
        }
        /// <summary>
        /// Usuario de autenticaci�n de base de datos.
        /// </summary>
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }
        /// <summary>
        /// Password de autenticaci�n de base de datos.
        /// </summary>
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        /// <summary>
        /// Timeout de conexi�n en segundos a la base de datos.
        /// </summary>
        public int Timeout
        {
            get { return this.timeout; }
            set { this.timeout = value; }
        }
        /// <summary>
        /// Puerto de conexi�n.
        /// </summary>
        public int Port
        {
            get { return this.port; }
            set { this.port = value; }
        }
        #endregion
    }
}
