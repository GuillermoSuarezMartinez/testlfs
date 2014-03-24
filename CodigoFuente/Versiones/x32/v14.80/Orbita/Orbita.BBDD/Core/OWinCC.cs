//***********************************************************************
// Assembly         : Orbita.BBDD
// Author           : crodriguez
// Created          : 02-22-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-22-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Orbita.BBDD
{
    /// <summary>
    /// Clase tipo para instanciar objetos de base de datos SQLServer,
    /// asignadas a WinCC. Acceso a través de Connectivity Pack.
    /// </summary>
    public class OWinCC : OCoreBBDD
    {
        #region Enumerados
        /// <summary>
        /// Tipo de alarmas.
        /// El parámetro FlagsAttribute considera
        /// que el  enumerado  puede considerarse
        /// como un conjunto de enumerados.
        /// </summary>
        [FlagsAttribute]
        public enum Alarmas
        {
            /// <summary>
            /// Indefinido.
            /// </summary>
            None = 0,
            /// <summary>
            /// Alarma activa.
            /// </summary>
            Activa = 1,
            /// <summary>
            /// Alarma inactiva.
            /// </summary>
            Inactiva = 2,
            /// <summary>
            /// Alarma acusada.
            /// </summary>
            Acusada = 3,
            /// <summary>
            /// Alarma reactivada.
            /// </summary>
            Reactivada = 16
        }
        /// <summary>
        /// Tipo agregado útil para interpolación.
        /// </summary>
        public enum AgregationType
        {
            /// <summary>
            /// Indefinido.
            /// </summary>
            None = 0,
            /// <summary>
            /// Sin interpolación primero.
            /// </summary>
            WithoutInterpolationFirst = 1,
            /// <summary>
            /// Sin interpolación último.
            /// </summary>
            WithoutInterpolationLast = 2,
            /// <summary>
            /// Sin interpolación mínimo.
            /// </summary>
            WithoutInterpolationMin = 3,
            /// <summary>
            /// Sin interpolación máximo.
            /// </summary>
            WithoutInterpolationMax = 4,
            /// <summary>
            /// Sin interpolación media.
            /// </summary>
            WithoutInterpolationAvg = 5,
            /// <summary>
            /// Sin interpolación suma.
            /// </summary>
            WithoutInterpolationSum = 6,
            /// <summary>
            /// Sin interpolación contador.
            /// </summary>
            WithoutInterpolationCount = 7,
            /// <summary>
            /// Con interpolación primero.
            /// </summary>
            WithInterpolationFirstInterpolated = 257,
            /// <summary>
            /// Con interpolación último.
            /// </summary>
            WithInterpolationLastInterpolated = 258,
            /// <summary>
            /// Con interpolación mínimo.
            /// </summary>
            WithInterpolationMinInterpolated = 259,
            /// <summary>
            /// Con interpolación máximo.
            /// </summary>
            WithInterpolationMaxInterpolated = 260,
            /// <summary>
            /// Con interpolación media.
            /// </summary>
            WithInterpolationAvgInterpolated = 261,
            /// <summary>
            /// Con interpolación suma.
            /// </summary>
            WithInterpolationSumInterpolated = 262,
            /// <summary>
            /// Con interpolación contador.
            /// </summary>
            WithInterpolationCountInterpolated = 263
        }
        #endregion

        #region Constantes privadas
        private const string Fecha = "yyyy-MM-dd HH:mm:ss";
        private const string LowerBound = "1970-01-01T00:00:00";
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase WinCC.
        /// </summary>
        /// <param name="infoConexion">Información de la conexión actual.</param>
        public OWinCC(OInfoConexion infoConexion)
            : base(infoConexion)
        {
            if (infoConexion == null) return;

            //  Obtener el nombre de la base de datos consultando la tabla master. Necesitamos usuario y password.
            var sql = new OSqlServer(new OInfoConexion(infoConexion.Instancia, "master", infoConexion.Usuario, infoConexion.Password, 180));
            DataTable tablaAux = sql.SeleccionSql("SELECT NAME AS BDD FROM SYSDATABASES WHERE (NAME LIKE 'CC_%') AND (NAME LIKE '%R')");
            if (tablaAux != null)
            {
                if (tablaAux.Rows.Count > 0)
                {
                    //  Extraer el nombre de la base de datos que le pasaremos a la cadena de conexión.
                    InfoConexion.BaseDatos = tablaAux.Rows[0]["BDD"].ToString();
                }
            }
            else
            {
                throw new Exception("No se encuentra la base de datos de WinCC.");
            }
            CadenaConexion = string.Format(CultureInfo.CurrentCulture, @"Provider=WinCCOLEDBProvider.1; Catalog={0}; Data Source={1}", infoConexion.BaseDatos, infoConexion.Instancia);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Tabla con los Tags de WinCC.
        /// </summary>
        /// <returns></returns>
        public DataTable TablaTagLogging
        {
            get
            {
                //  Crear la conexión Sql para la consulta.
                var sqlServer = new OSqlServer(new OInfoConexion(Instancia, BaseDatos, Usuario, InfoConexion.Password));
                string sql =
                    "SELECT	ARCHIVE.ValueID Id,  " +
                    "	LTRIM(RTRIM(ARCHIVE.ValueName)) Nombre,  " +
                    "	CONVERT(NVARCHAR(30),lastmodification,120) FechaModificacion, " +
                    "	TIMES.[TIMEBASE]*TAGS.[ARCFACTOR] TiempoAdquisicion, " +
                    "	LTRIM(RTRIM(TAGS.[PROCVARNAME])) VariableProceso, " +
                    "	LTRIM(RTRIM(TAGS.[ARCNAME])) Grupo, " +
                    "	VARIABLES.[ADDRESSPARAMETER] Direccion, " +
                    "	TIPO.[VARIABLETYPELENGTH] Tamanyo, " +
                    "	LTRIM(RTRIM(TIPO.[VARIABLETYPENAME])) Tipo " +
                    "FROM	[" + BaseDatos + "].[dbo].[Archive] ARCHIVE,  " +
                    "		[" + BaseDatos.Remove(BaseDatos.Length - 1) + "].[dbo].[PDE#TAGs] TAGS, " +
                    "		[" + BaseDatos.Remove(BaseDatos.Length - 1) + "].[dbo].[PDE#TIMES] TIMES, " +
                    "		[" + BaseDatos.Remove(BaseDatos.Length - 1) + "].[dbo].[MCPTVARIABLEDESC] VARIABLES, " +
                    "		[" + BaseDatos.Remove(BaseDatos.Length - 1) + "].[dbo].[MCPTVARIABLETYPE] TIPO " +
                    "WHERE 	ARCHIVE.[ValueID] = TAGS.[TLGTAGID] AND " +
                    "		TAGS.[SCANTIME] = TIMES.[TIMENAME] AND " +
                    "		TAGS.[PROCVARNAME] = VARIABLES.[VARIABLENAME] AND " +
                    "		VARIABLES.[VARIABLETYPEID] = TIPO.[VARIABLETYPEID]";

                //  Devolver los datos.
                DataTable resultado = sqlServer.SeleccionSql(sql);
                resultado.PrimaryKey = new[] { resultado.Columns["Id"] };
                return resultado;
            }
        }
        #endregion

        #region Métodos públicos

        #region TagLogging
        /// <summary>
        /// Leer los registros contenidos en TagLogging como resultado de los parámetros solicitados.
        /// </summary>
        /// <param name="variables">Colección de identificadores de variables de TagLogging.</param>
        /// <param name="fechaInicial">Fecha inicial en formato GMT.</param>.
        /// <param name="fechaFinal">Fecha final en formato GMT.</param>
        /// <param name="tiempo">Tiempo de paso.</param>
        /// <param name="agregado">Tipo de agregado para interpolación.</param>
        /// <returns>Una tabla de datos (DataTable) con el resultado de la consulta solicitada.</returns>
        public DataTable LeerTagLogging(IEnumerable<string> variables, DateTime fechaInicial, DateTime? fechaFinal = null, int tiempo = -1, AgregationType agregado = AgregationType.None)
        {
            string sql = ConstruirSql(variables, fechaInicial, fechaFinal, tiempo, agregado);
            return LeerLogging(sql, 1);
        }
        /// <summary>
        /// Leer los registros contenidos en TagLogging como resultado de los parámetros solicitados.
        /// </summary>
        /// <param name="nombreTabla">Nombre de System.Data.DataTable.</param>
        /// <param name="variables">Colección de identificadores de variables de TagLogging.</param>
        /// <param name="fechaInicial">Fecha inicial en formato GMT.</param>
        /// <param name="fechaFinal">Fecha final en formato GMT.</param>
        /// <param name="tiempo">Tiempo de paso.</param>
        /// <param name="agregado">Tipo de agregado para interpolación.</param>
        /// <returns>Cada tabla es una variable. El nombre de la tabla es el ID de la variable.</returns>
        public DataSet LeerTagLogging(string nombreTabla, string[] variables, DateTime fechaInicial, DateTime? fechaFinal = null, int tiempo = -1, AgregationType agregado = AgregationType.None)
        {
            string sql = ConstruirSql(variables, fechaInicial, fechaFinal, tiempo, agregado);
            return LeerLogging(nombreTabla, sql, 1);
        }
        #endregion TagLogging

        #region AlarmLogging
        /// <summary>
        /// Leer los registros contenidos en AlarmLogging como resultado de los parámetros de fecha solicitados.
        /// </summary>
        /// <param name="variables">Identificador de variables.</param>
        /// <param name="fechaInicial">Fecha inicial en formato GMT.</param>
        /// <param name="fechaFinal">Fecha final en formato GMT.</param>
        /// <returns></returns>
        public DataTable LeerAlarmLogging(IEnumerable<string> variables, DateTime fechaInicial, DateTime? fechaFinal = null)
        {
            string sql = ConstruirSql(variables, fechaInicial, fechaFinal);
            return LeerLogging(sql, 2);
        }
        /// <summary>
        /// Leer los registros contenidos en AlarmLogging como resultado de los parámetros de fecha solicitados.
        /// </summary>
        /// <param name="nombreTabla"></param>
        /// <param name="variables">Identificador de variables.</param>
        /// <param name="fechaInicial">Fecha inicial en formato GMT.</param>
        /// <param name="fechaFinal">Fecha final en formato GMT.</param>
        /// <returns></returns>
        public DataSet LeerAlarmLogging(string nombreTabla, string[] variables, DateTime fechaInicial, DateTime? fechaFinal = null)
        {
            string sql = ConstruirSql(variables, fechaInicial, fechaFinal);
            return LeerLogging(nombreTabla, sql, 2);
        }
        /// <summary>
        /// Leer los registros contenidos en AlarmLogging como resultado de los parámetros de fecha solicitados.
        /// </summary>
        /// <param name="fechaInicial">Fecha inicial en formato GMT.</param>
        /// <param name="fechaFinal">Fecha final en formato GMT.</param>
        /// <returns></returns>
        public DataTable LeerAlarmLogging(DateTime fechaInicial, DateTime? fechaFinal = null)
        {
            string sql = ConstruirSql(fechaInicial, fechaFinal);
            return LeerLogging(sql, 2);
        }
        public DataSet LeerAlarmLogging(string nombreTabla, DateTime fechaInicial, DateTime? fechaFinal = null)
        {
            string sql = ConstruirSql(fechaInicial, fechaFinal);
            return LeerLogging(nombreTabla, sql, 2);
        }
        #endregion AlarmLogging

        #endregion

        #region Métodos privados

        private static string ConstruirSql(DateTime fechaInicial, DateTime? fechaFinal)
        {
            //  Fecha inicial a UTC.
            string inicio = fechaInicial.ToUniversalTime().ToString(Fecha, CultureInfo.CurrentCulture);
            if (fechaInicial <= DateTime.Parse(LowerBound))
            {
                inicio = LowerBound;
            }
            //  Variable auxiliar donde almacenamos el string de la consulta Sql.
            string sql = @"ALARMVIEW:SELECT * FROM ALGVIEWENU WHERE DateTime>'" + inicio + "'";
            if (fechaFinal != null && fechaFinal >= fechaInicial)
            {
                string fin = fechaFinal.Value.ToUniversalTime().ToString(Fecha, CultureInfo.CurrentCulture);
                sql += "AND DateTime<'" + fin + "'";
            }
            return sql;
        }
        private static string ConstruirSql(IEnumerable<string> variables, DateTime fechaInicial, DateTime? fechaFinal, int tiempo, AgregationType agregado)
        {
            //  Variable auxiliar para almacenar la colección de variables con el formato que entiende la consulta Connectivity Pack.
            string auxVariables = string.Empty;

            //  Extraer las variables de la colección.
            auxVariables = variables.Aggregate(auxVariables, (current, varID) => current + "'" + varID + "';");
            auxVariables = auxVariables.Substring(0, auxVariables.Length - 1);

            // Fechas.
            string inicio = fechaInicial.ToUniversalTime().ToString(Fecha, CultureInfo.CurrentCulture);
            if (fechaInicial <= DateTime.Parse(LowerBound))
            {
                inicio = LowerBound;
            }

            string fin = "0000-00-00 00:00:00.000";
            if (fechaFinal != null && fechaFinal >= fechaInicial)
            {
                fin = fechaFinal.Value.ToUniversalTime().ToString(Fecha, CultureInfo.CurrentCulture);
            }

            //  Variable auxiliar donde almacenamos el string de la consulta Sql.
            string sql = @"TAG:R,(" + auxVariables + "),'" + inicio + "','" + fin + "'";
            if (tiempo != -1)
            {
                sql = sql + ", 'TIMESTEP=" + tiempo + "," + (int)agregado + "'";
            }
            return sql;
        }
        private static string ConstruirSql(IEnumerable<string> variables, DateTime fechaInicial, DateTime? fechaFinal)
        {
            //  Variable auxiliar para almacenar la colección de variables con el formato que entiende la consulta Connectivity Pack.
            string auxVariables = string.Empty;

            //  Extraer las variables de la colección.
            auxVariables = variables.Aggregate(auxVariables, (current, varID) => current + "" + varID + ",");
            auxVariables = auxVariables.Substring(0, auxVariables.Length - 1);

            // Fechas.
            string inicio = fechaInicial.ToUniversalTime().ToString(Fecha, CultureInfo.CurrentCulture);
            if (fechaInicial <= DateTime.Parse(LowerBound))
            {
                inicio = LowerBound;
            }

            //  Variable auxiliar donde almacenamos el string de la consulta Sql.
            string sql = @"ALARMVIEW:SELECT * FROM ALGVIEWENU WHERE MsgNr IN (" + auxVariables + ") AND DateTime>'" + inicio + "'";
            if (fechaFinal != null && fechaFinal >= fechaInicial)
            {
                string fin = fechaFinal.Value.ToUniversalTime().ToString(Fecha, CultureInfo.CurrentCulture);
                sql += "AND DateTime<'" + fin + "'";
            }
            return sql;
        }

        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "SQL proviene de un archivo de recursos y parámetros.")]
        private DataTable LeerLogging(string sql, int columnaFecha)
        {
            // Inicializar resultado.
            DataTable resultado = null;
            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                using (var command = new OleDbCommand(sql, conexion))
                {
                    // Abrir conexión.
                    conexion.Open();
                    // Establecer timeout de ejecución en segundos.
                    command.CommandTimeout = Timeout;
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    resultado = new DataTable();
                                    for (var columna = 0; columna < reader.FieldCount; columna++)
                                    {
                                        resultado.Columns.Add(reader.GetName(columna), reader.GetValue(columna).GetType());
                                    }
                                    var fila = new object[reader.FieldCount];
                                    bool read;
                                    do
                                    {
                                        reader.GetValues(fila);
                                        DateTime fechaGmt;
                                        if (DateTime.TryParse(fila[columnaFecha].ToString(), out fechaGmt))
                                        {
                                            fila[columnaFecha] = fechaGmt.ToLocalTime();
                                        }
                                        resultado.Rows.Add(fila);
                                        read = reader.Read();
                                    }
                                    while (read);
                                }
                            }
                        }
                    }
                }
                return resultado;
            }
            finally
            {
                if (resultado != null)
                {
                    resultado.Dispose();
                }
            }
        }
        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "SQL proviene de un archivo de recursos y parámetros.")]
        private DataSet LeerLogging(string nombreTabla, string sql, int columnaFecha)
        {
            // Inicializar resultado.
            DataSet resultado = null;
            try
            {
                // Obtener el resultado en DataTable del método sobrecargado.
                DataTable dt = LeerLogging(sql, columnaFecha);
                if (dt == null) return null;

                // Establecer el nombre de la tabla del DataSet.
                dt.TableName = nombreTabla;
                // Crear el DataSet adecuado en el retorno.
                resultado = new DataSet { Locale = CultureInfo.CurrentCulture };
                // Establecer una configuración regional actual.
                // Agregar el objeto DataTable a la colección.
                resultado.Tables.Add(dt);
                return resultado;
            }
            finally
            {
                if (resultado != null)
                {
                    resultado.Dispose();
                }
            }
        }

        #endregion Métodos privados
    }
}