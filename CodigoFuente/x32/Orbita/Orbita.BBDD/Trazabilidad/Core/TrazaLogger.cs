//***********************************************************************
// Assembly         : Orbita.Trazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-22-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************

using System.Collections;
using System.Data.SqlClient;
using Orbita.Trazabilidad;
namespace Orbita.BBDD.Trazabilidad
{
    /// <summary>
    /// Traza Logger.
    /// </summary>
    public class TrazaLogger : BaseTraza
    {
        #region Atributos privados
        /// <summary>
        /// Informaci�n de la conexi�n.
        /// La inclusi�n del atributo es necesaria para poder obtener las propiedades de  la
        /// clase OInfoConexion a trav�s del objeto de base de datos que se cree en cada caso.
        /// </summary>
        private OInfoConexion _infoConexion;
        /// <summary>
        /// Logger de trazas correctas.
        /// </summary>
        private readonly ILogger _logger;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.TrazaLogger.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        public TrazaLogger(string identificador)
            : base(identificador) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.TrazaLogger.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="instancia">Nombre de la instancia de base de datos.</param>
        /// <param name="baseDatos">Nombre de la base de datos.</param>
        /// <param name="usuario">Usuario de las credenciales de base de datos.</param>
        /// <param name="password">Password de las credenciales de base de datos.</param>
        /// <param name="logger">DebugLogger de registro que chequea errores de inserci�n en base de datos.</param>
        public TrazaLogger(string identificador, string instancia, string baseDatos, string usuario, string password, ILogger logger)
            : this(identificador, new OInfoConexion(instancia, baseDatos, usuario, password), logger) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.TrazaLogger.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="instancia">Nombre de la instancia de base de datos.</param>
        /// <param name="baseDatos">Nombre de la base de datos.</param>
        /// <param name="usuario">Usuario de las credenciales de base de datos.</param>
        /// <param name="password">Password de las credenciales de base de datos.</param>
        public TrazaLogger(string identificador, string instancia, string baseDatos, string usuario, string password)
            : this(identificador, instancia, baseDatos, usuario, password, null) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.TrazaLogger.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="instancia">Nombre de la instancia de base de datos.</param>
        /// <param name="baseDatos">Nombre de la base de datos.</param>
        /// <param name="usuario">Usuario de las credenciales de base de datos.</param>
        /// <param name="password">Password de las credenciales de base de datos.</param>
        /// <param name="timeout">Timeout de conexi�n.</param>
        public TrazaLogger(string identificador, string instancia, string baseDatos, string usuario, string password, int timeout)
            : this(identificador, instancia, baseDatos, usuario, password, timeout, null) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.TrazaLogger.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="instancia">Nombre de la instancia de base de datos.</param>
        /// <param name="baseDatos">Nombre de la base de datos.</param>
        /// <param name="usuario">Usuario de las credenciales de base de datos.</param>
        /// <param name="password">Password de las credenciales de base de datos.</param>
        /// <param name="timeout">Timeout de conexi�n.</param>
        /// <param name="logger">DebugLogger de registro que chequea errores de inserci�n en base de datos.</param>
        public TrazaLogger(string identificador, string instancia, string baseDatos, string usuario, string password, int timeout, ILogger logger)
            : this(identificador, new OInfoConexion(instancia, baseDatos, usuario, password, timeout), logger) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.TrazaLogger.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="oInfoConexion">Informaci�n de la conexi�n actual.</param>
        public TrazaLogger(string identificador, OInfoConexion oInfoConexion)
            : this(identificador, oInfoConexion, null) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.TrazaLogger.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="oInfoConexion">Informaci�n de la conexi�n actual.</param>
        /// <param name="logger">DebugLogger de registro que chequea errores de inserci�n en base de datos.</param>
        public TrazaLogger(string identificador, OInfoConexion oInfoConexion, ILogger logger)
            : this(identificador)
        {
            this._infoConexion = oInfoConexion;
            this._logger = logger;
        }
        #endregion

        #region Propiedades p�blicas
        /// <summary>
        /// OInfoConexion de base de datos.
        /// </summary>
        public OInfoConexion OInfoConexion
        {
            get { return this._infoConexion; }
            set { this._infoConexion = value; }
        }
        #endregion

        #region Propiedades privadas
        /// <summary>
        /// Base de datos.
        /// </summary>
        OSqlServer BD
        {
            get { return new OSqlServer(this._infoConexion); }
        }
        /// <summary>
        /// Logger de control de excepciones.
        /// </summary>
        ILogger Logger
        {
            get { return this._logger; }
        }
        #endregion

        #region M�todos p�blicos
        /// <summary>
        /// Crea una entrada de registro nuevo basado en un elemento de inicio de sesi�n dado.
        /// </summary>
        /// <param name="item">Entrada de registro de traza.</param>
        /// <returns>Resultado de ejecuci�n del procedimiento almacenado.</returns>
        public override int Log(ItemTraza item)
        {
            return (item == null) ? -1 : TrazarDato(item);
        }
        #endregion

        #region M�todos privados
        /// <summary>
        /// Escribir en base de datos.
        /// </summary>
        /// <param name="item">Entrada de registro de traza.</param>
        /// <returns>El estado del procedimiento almacenado.</returns>
        int TrazarDato(ItemTraza item)
        {
            int resultado = -1;
            try
            {
                resultado = this.BD.EjecutarProcedimientoAlmacenado(item.Procedimiento, item.Argumentos);
            }
            catch (SqlException ex)
            {
                if (this._logger != null)
                {
                    if (item.Argumentos != null)
                    {
                        // Convertir el array de par�metros en un array de valores.
                        ArrayList argsValores = new ArrayList();
                        for (int i = 0; i < item.Argumentos.Count; i++)
                        {
                            argsValores.Add(((SqlParameter)item.Argumentos[i]).SqlValue.ToString());
                        }
                        // Logger del registro que no se ha podido insertar, con argumentos.
                        this.Logger.Error(ex, item.Procedimiento, (string[])argsValores.ToArray(typeof(string)));
                    }
                    else
                    {
                        // Logger del registro que no se ha podido insertar, sin argumentos.
                        this.Logger.Error(ex, item.Procedimiento);
                    }
                }
            }
            return resultado;
        }
        #endregion
    }
}