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
    /// El modificador abstract en una declaración de clase, se
    /// usa para  indicar que la  clase sólo se  puede utilizar
    /// como clase base de otras clases.
    /// </summary>
    public abstract class OCoreBBDD
    {
        #region Atributos privados
        /// <summary>
        /// Información de la conexión.
        /// La inclusión  del  atributo es  necesaria
        /// para poder obtener las  propiedades de la
        /// clase  InfoConexion  a  través del objeto
        /// de base de datos que se cree en cada caso.
        /// </summary>
        private readonly OInfoConexion _infoConexion;

        #endregion

        #region Constructores privados
        /// <summary>
        /// Inicializar una nueva instancia de la clase Core.
        /// </summary>
        OCoreBBDD()
        {
            // Establecer el timeout por defecto en 120s.
            this.Timeout = 120;
        }
        #endregion

        #region Constructores protegidos
        /// <summary>
        /// Inicializar una nueva instancia de la clase Core.
        /// </summary>
        /// <param name="infoConexion">Información de la conexión actual.</param>
        protected OCoreBBDD(OInfoConexion infoConexion)
            : this()
        {
            this._infoConexion = infoConexion;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Información de la conexión.
        /// La inclusión  del  atributo es  necesaria
        /// para poder obtener las  propiedades de la
        /// clase  InfoConexion  a  través del objeto
        /// de base de datos que se cree en cada caso.
        /// </summary>
        protected OInfoConexion InfoConexion
        {
            get { return this._infoConexion; }
        }
        /// <summary>
        /// Información correspondiente a la cadena de conexión de la base de datos.
        /// </summary>
        protected string CadenaConexion { get; set; }
        /// <summary>
        /// Timeout de ejecución de sentencias T-SQL. (En segundos).
        /// </summary>
        protected int Timeout { get; set; }
        /// <summary>
        /// Nombre de la instancia de base de datos.
        /// </summary>
        public string Instancia
        {
            get { return this._infoConexion.Instancia; }
        }
        /// <summary>
        /// Nombre de la base de datos.
        /// </summary>
        public string BaseDatos
        {
            get { return this._infoConexion.BaseDatos; }
        }
        /// <summary>
        /// Usuario de autenticación de base de datos.
        /// </summary>
        public string Usuario
        {
            get { return this._infoConexion.Usuario; }
        }
        #endregion
    }
}