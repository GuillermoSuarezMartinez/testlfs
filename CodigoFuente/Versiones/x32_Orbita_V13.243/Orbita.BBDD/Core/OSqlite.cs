//***********************************************************************
// Assembly         : Orbita.BBDD
// Author           : sizquierdo
// Created          : 05-13-2013
//
// Last Modified By : sizquierdo
// Last Modified On : 05-13-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Data.SQLite;
using System;
namespace Orbita.BBDD
{
    /// <summary>
    /// Clase tipo para instanciar objetos de base de datos OSQLite.
    /// </summary>
    public class OSQLite : OCoreBBDD
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase SQLite.
        /// </summary>
        /// <param name="infoConexion">Información de la conexión actual.</param>
        public OSQLite(OInfoConexion infoConexion)
            : base(infoConexion)
        {
            if (infoConexion != null)
            {
                this.CadenaConexion = string.Format(CultureInfo.CurrentCulture, @"Data Source={0};Version=3;Password={1};",
                      infoConexion.Instancia, infoConexion.Password);
            }
        }
        #endregion

        #region Métodos públicos

        #region Test
        /// <summary>
        /// Comprueba el estado una conexión existente.
        /// </summary>
        /// <returns>El resultado del test de conexión.</returns>
        public bool TestConexion()
        {
            // Inicializar resultado.
            bool resultado = false;
            using (SQLiteConnection conexion = new SQLiteConnection(CadenaConexion))
            {
                // Abrir conexión.
                conexion.Open(); resultado = (conexion.State == ConnectionState.Open);
            }

            return resultado;
        }
        #endregion Test

        #region SeleccionSql
        /// <summary>
        /// Ejecutar una consulta Select con timeout por defecto.
        /// </summary>
        /// <param name="sql">Consulta SQL.</param>
        /// <returns>Datatable con el resultado.</returns>
        public DataTable SeleccionSql(string sql)
        {
            return this.SeleccionSql(sql, this.Timeout);
        }
        /// <summary>
        /// Ejecutar una consulta Select.
        /// </summary>
        /// <param name="sql">Consulta SQL.</param>
        /// <param name="timeout">Timeout de SqlCommand.</param>
        /// <returns>Datatable con el resultado.</returns>
        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "SQL proviene de un archivo de recursos y parámetros.")]
        public DataTable SeleccionSql(string sql, int timeout)
        {
            DataTable dt = new DataTable();
            SQLiteConnection conexion = null;
            try
            {
                conexion = new SQLiteConnection(CadenaConexion);
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(conexion);
                comando.CommandText = sql;
                SQLiteDataReader reader = comando.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conexion.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally 
            {
                if (conexion != null)
                {
                    try 
                    { 
                        conexion.Dispose(); 
                    }
                    catch (Exception) { }
                }
            }
            return dt;

           
        }
        #endregion SeleccionSql

        #region EjecutarSql
        /// <summary>
        /// Ejecutar una sentencia SQL con timeout por defecto.
        /// </summary>
        /// <param name="sql">Consulta SQL.</param>
        /// <returns>Para las instrucciones Update, Insert y Delete, el 
        /// valor devuelto corresponde al número de filas afectadas por
        /// el comando. Para los demás tipos de instrucciones, el valor
        /// devuelto es -1.</returns>
        public int EjecutarSql(string sql)
        {
            return this.EjecutarSql(sql, this.Timeout);
        }
        /// <summary>
        /// Ejecutar una sentencia SQL.
        /// Para las instrucciones Update, Insert y Delete, 
        /// el valor devuelto corresponde al número de filas afectadas por
        /// el comando. Para los demás tipos de instrucciones, el valor 
        /// devuelto es -1.
        /// </summary>
        /// <param name="sql">Consulta SQL.</param>
        /// <param name="timeout">Timeout de SqlCommand.</param>
        /// <returns>Para las instrucciones Update, Insert y Delete, el 
        /// valor devuelto corresponde al número de filas afectadas por
        /// el comando. Para los demás tipos de instrucciones, el valor
        /// devuelto es -1.</returns>
        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "SQL proviene de un archivo de recursos y parámetros.")]
        public int EjecutarSql(string sql, int timeout)
        {
            SQLiteConnection conexion = new SQLiteConnection(CadenaConexion);
            conexion.Open();
            SQLiteCommand comando = new SQLiteCommand(conexion);
            comando.CommandText = sql;
            int resultado = comando.ExecuteNonQuery();
            conexion.Close();
            return resultado;
        }
        #endregion EjecutarSql

        #endregion Métodos públicos
    }
}