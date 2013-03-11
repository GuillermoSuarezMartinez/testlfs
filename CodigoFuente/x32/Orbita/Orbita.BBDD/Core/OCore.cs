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
    /// El modificador abstract en una declaraci�n de clase, se
    /// usa para  indicar que la  clase s�lo se  puede utilizar
    /// como clase base de otras clases.
    /// </summary>
    public abstract class OCore
    {
        #region Atributos privados
        /// <summary>
        /// Informaci�n de la conexi�n.
        /// La inclusi�n  del  atributo es  necesaria
        /// para poder obtener las  propiedades de la
        /// clase  InfoConexion  a  trav�s del objeto
        /// de base de datos que se cree en cada caso.
        /// </summary>
        OInfoConexion infoConexion;
        /// <summary>
        /// Informaci�n correspondiente a la cadena
        /// de conexi�n de la base de datos.
        /// </summary>
        string cadenaConexion;
        /// <summary>
        /// Timeout de ejecuci�n de sentencias T-SQL.
        /// </summary>
        int timeout;
        #endregion

        #region Constructores privados
        /// <summary>
        /// Inicializar una nueva instancia de la clase Core.
        /// </summary>
        OCore()
        {
            // Establecer el timeout por defecto en 120s.
            this.timeout = 120;
        }
        #endregion

        #region Constructores protegidos
        /// <summary>
        /// Inicializar una nueva instancia de la clase Core.
        /// </summary>
        /// <param name="infoConexion">Informaci�n de la conexi�n actual.</param>
        protected OCore(OInfoConexion infoConexion)
            : this()
        {
            this.infoConexion = infoConexion;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Informaci�n de la conexi�n.
        /// La inclusi�n  del  atributo es  necesaria
        /// para poder obtener las  propiedades de la
        /// clase  InfoConexion  a  trav�s del objeto
        /// de base de datos que se cree en cada caso.
        /// </summary>
        protected OInfoConexion InfoConexion
        {
            get { return this.infoConexion; }
        }
        /// <summary>
        /// Informaci�n correspondiente a la cadena de conexi�n de la base de datos.
        /// </summary>
        protected string CadenaConexion
        {
            get { return this.cadenaConexion; }
            set { this.cadenaConexion = value; }
        }
        /// <summary>
        /// Timeout de ejecuci�n de sentencias T-SQL. (En segundos).
        /// </summary>
        protected int Timeout
        {
            get { return this.timeout; }
            set { this.timeout = value; }
        }
        /// <summary>
        /// Nombre de la instancia de base de datos.
        /// </summary>
        public string Instancia
        {
            get { return this.infoConexion.Instancia; }
        }
        /// <summary>
        /// Nombre de la base de datos.
        /// </summary>
        public string BaseDatos
        {
            get { return this.infoConexion.BaseDatos; }
        }
        /// <summary>
        /// Usuario de autenticaci�n de base de datos.
        /// </summary>
        public string Usuario
        {
            get { return this.infoConexion.Usuario; }
        }
        #endregion
    }
}