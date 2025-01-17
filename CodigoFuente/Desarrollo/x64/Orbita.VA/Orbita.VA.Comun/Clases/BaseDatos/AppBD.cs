//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aiba�ez
// Created          : 06-09-2012
//
// Last Modified By : aiba�ez
// Last Modified On : 27-09-2012
// Description      : A�adidas funciones de almacenamiento
//
// Last Modified By : aiba�ez
// Last Modified On : 12-03-2013
// Description      : Cambiados el acceso a los procedimientos almacenados para incluir el prefijo VA
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using Orbita.Xml;
using Orbita.BBDD;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase est�tica que contiene llamadas a los procedimiento almacenados en la base de datos
    /// </summary>
    public static class AppBD
    {
        #region Constante(s)
        /// <summary>
        /// Ruta por defecto del fichero xml de configuraci�n
        /// </summary>
        public static string XmlSchemaFile = Path.Combine(ORutaParametrizable.AppFolder, "Estructura_BaseDatos.xml");
        #endregion

        #region M�todos de sistema
        /// <summary>
        /// Exporta la base de datos SQL a ficheros XML
        /// </summary>
        public static void CreateXMLDataBase(Dictionary<string, string> tablas, string xmlFile)
        {
            DataSet ds = new DataSet();
            foreach (KeyValuePair<string, string> tabla in tablas)
            {
                ArrayList list = new ArrayList();
                list.Add(new SqlParameter("@TextoSQL", tabla.Value));
                DataTable dt = OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_APP_GET_SELECT_A_MEDIDA", list);
                dt.TableName = tabla.Key;
                ds.Tables.Add(dt);
            }

            ds.WriteXml(xmlFile, XmlWriteMode.WriteSchema);
        }

        /// <summary>
        /// Extrae un dataset con el esquema de la base de datos seleccionada. Tablas y procedimientos
        /// </summary>
        public static void ExtraerEsquemaBBDD(OSqlServer sqlServer, ref DataSet ds)
        {
            DataTable dtTablas = sqlServer.SeleccionProcedimientoAlmacenado("VA_APP_GET_ESQUEMA_TABLAS");
            dtTablas.TableName = "TABLAS_" + sqlServer.Instancia;
            ds.Tables.Add(dtTablas);

            DataTable dtProcedimientos = sqlServer.SeleccionProcedimientoAlmacenado("VA_APP_GET_PROCEDIMIENTOS");
            dtProcedimientos.TableName = "PROCEDIMIENTOS_" + sqlServer.Instancia;
            ds.Tables.Add(dtProcedimientos);

            //ds.WriteXml(xmlFile, XmlWriteMode.WriteSchema);
        }

        /// <summary>
        /// Compara los esquemas de las bases de datos seleccionadas. Tanto los campos de las tablas como los procedimientos almacenados
        /// </summary>
        public static bool CompararEsquemaBBDD(List<OSqlServer> basesDatos, out string explicacion)
        {
            bool resultado = false;
            explicacion = string.Empty;

            DataSet dsActual = new DataSet();
            DataSet dsReferencia = new DataSet();

            //ExtraerEsquemaBBDD(OrigenBaseDatos.Parametrizacion, ref dsActual);
            //ExtraerEsquemaBBDD(OrigenBaseDatos.Almacen, ref dsActual);
            //dsActual.WriteXml(xmlFile, XmlWriteMode.WriteSchema);

            dsReferencia.ReadXml(XmlSchemaFile);

            // Comparaci�n de BBDD
            resultado = true;
            foreach (OSqlServer origenBBDD in basesDatos)
            {
                // Compraci�n de tablas
                string nombreTabla = "TABLAS_" + origenBBDD.Instancia;
                DataTable dtReferencia = dsReferencia.Tables[nombreTabla];
                DataTable dtActual = dsActual.Tables[nombreTabla];
                foreach (DataRow drReferencia in dtReferencia.Rows)
                {
                    string nomTabla = (string)drReferencia["nom_tabla"];
                    string nomColumna = (string)drReferencia["nom_columna"];
                    DataRow[] drActuales = dtActual.Select(string.Format("nom_tabla = '{0}' and nom_columna = '{1}'", nomTabla, nomColumna));
                    if (drActuales.Length != 1)
	                {
                        resultado = false;
                        explicacion += string.Format("La columna {0} de la tabla {1} no existe en la BBDD {2}.", nomColumna, nomTabla, origenBBDD.BaseDatos) + Environment.NewLine;
	                }
                    else
                    {
                        DataRow drActual = drActuales[0];

                        string tipoReferencia = (string)drReferencia["nom_tipo"];
                        string tipoActual = (string)drActual["nom_tipo"];
                        if (tipoReferencia != tipoActual)
	                    {
                            resultado = false;
                            explicacion += string.Format("La columna {0} de la tabla {1} de la BBDD {2} no es del tipo {3}.", nomColumna, nomTabla, origenBBDD.BaseDatos, tipoReferencia) + Environment.NewLine;
	                    }

                        short longReferencia = (short)drReferencia["max_length"];
                        short longActual = (short)drActual["max_length"];
                        if (longReferencia != longActual)
	                    {
                            resultado = false;
                            explicacion += string.Format("La columna {0} de la tabla {1} de la BBDD {2} no es de la longitud {3}.", nomColumna, nomTabla, origenBBDD.BaseDatos, longReferencia) + Environment.NewLine;
	                    }

                        byte precisionReferencia = (byte)drReferencia["precision"];
                        byte precisionActual = (byte)drActual["precision"];
                        if (precisionReferencia != precisionActual)
	                    {
                            resultado = false;
                            explicacion += string.Format("La columna {0} de la tabla {1} de la BBDD {2} no es de la precisi�n {3}.", nomColumna, nomTabla, origenBBDD.BaseDatos, precisionReferencia) + Environment.NewLine;
	                    }

                        byte escalaReferencia = (byte)drReferencia["scale"];
                        byte escalaActual = (byte)drActual["scale"];
                        if (escalaReferencia != escalaActual)
	                    {
                            resultado = false;
                            explicacion += string.Format("La columna {0} de la tabla {1} de la BBDD {2} no es de la escala {3}.", nomColumna, nomTabla, origenBBDD.BaseDatos, escalaReferencia) + Environment.NewLine;
	                    }

                        bool nullableReferencia = (bool)drReferencia["is_nullable"];
                        bool nullableActual = (bool)drActual["is_nullable"];
                        if (nullableReferencia != nullableActual)
	                    {
                            resultado = false;
                            explicacion += string.Format("La columna {0} de la tabla {1} de la BBDD {2} debe tener la opci�n 'permitir valores NULL' a {3}.", nomColumna, nomTabla, origenBBDD.BaseDatos, nullableReferencia) + Environment.NewLine;
	                    }

                        bool identidadReferencia = (bool)drReferencia["is_identity"];
                        bool identidadActual = (bool)drActual["is_identity"];
                        if (identidadReferencia != identidadActual)
	                    {
                            resultado = false;
                            explicacion += string.Format("La columna {0} de la tabla {1} de la BBDD {2} debe tener la opci�n 'identidad' a {3}.", nomColumna, nomTabla, origenBBDD.BaseDatos, identidadReferencia) + Environment.NewLine;
	                    }
                    }
                }


                // Compraci�n de procedimientos
                nombreTabla = "PROCEDIMIENTOS_" + origenBBDD.Instancia;
                dtReferencia = dsReferencia.Tables[nombreTabla];
                dtActual = dsActual.Tables[nombreTabla];
                foreach (DataRow drReferencia in dtReferencia.Rows)
                {
                    string nomProcedimiento = (string)drReferencia["SPECIFIC_NAME"];
                    DataRow[] drActuales = dtActual.Select(string.Format("SPECIFIC_NAME = '{0}'", nomProcedimiento));
                    if (drActuales.Length != 1)
	                {
                        resultado = false;
                        explicacion += string.Format("El procedimiento {0} no existe en la BBDD {1}.", nomProcedimiento, origenBBDD.BaseDatos) + Environment.NewLine;
	                }
                    else
                    {
                        DataRow drActual = drActuales[0];

                        string defReferencia = (string)drReferencia["ROUTINE_DEFINITION"];
                        string defActual = (string)drActual["ROUTINE_DEFINITION"];

                        defReferencia = Regex.Replace(defReferencia, "[ \n\r\t]", string.Empty);
                        defActual = Regex.Replace(defActual, "[ \n\r\t]", string.Empty);

                        bool ok = string.Equals(defReferencia, defActual, StringComparison.InvariantCultureIgnoreCase);

                        if (!ok)
	                    {
                            resultado = false;
                            explicacion += string.Format("El procedimiento almacenado {0} de la BBDD {1} difiere del correcto.", nomProcedimiento, origenBBDD.BaseDatos) + Environment.NewLine;
	                    }
                    }
                }

            }

            return resultado;
        }

        #endregion

        #region TAB Select: funciones Get -> GetX(...)
        /// <summary>
        /// Consulta los par�metros b�sicos de la aplicaci�n
        /// </summary>
        /// <returns>DataTable con los par�metros b�sicos de la aplicaci�n</returns>
        public static DataTable GetParametrosAplicacion()
        {
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_APP_GET_PARAMETROS");
        }

        /// <summary>
        /// Consulta todas escenarios existentes en el sistema
        /// </summary>
        /// <returns>DataTable con los c�digos de las variables existentes en el sistema</returns>
        public static DataTable GetEscenarios()
        {
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_ESC_GET_ESCENARIOS");
        }
        /// <summary>
        /// Consulta una escenario existente en el sistema
        /// </summary>
        /// <returns>DataTable con los c�digos de las escenarios existentes en el sistema</returns>
        public static DataTable GetEscenario(string codEscenario)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodEscenario", codEscenario));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_ESC_GET_ESCENARIO", list);
        }

        /// <summary>
        /// Consulta un usuario existente en el sistema
        /// </summary>
        /// <returns>DataTable con los la informaci�n del usuario</returns>
        public static DataTable GetUsuarios()
        {
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_USU_GET_USUARIOS");
        }
        /// <summary>
        /// Consulta un usuario existente en el sistema
        /// </summary>
        /// <returns>DataTable con los la informaci�n del usuario</returns>
        public static DataTable GetUsuario(string codigo)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodUsuario", codigo));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_USU_GET_USUARIO", list);
        }

        /// <summary>
        /// Consulta todas variables existentes en el sistema
        /// </summary>
        /// <returns>DataTable con los c�digos de las variables existentes en el sistema</returns>
        public static DataTable GetVariables()
        {
            ArrayList list = new ArrayList();

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_VAR_GET_VARIABLES", list);
        }

        /// <summary>
        /// Consulta una variables existente en el sistema
        /// </summary>
        /// <returns>DataTable con los c�digos de las variables existentes en el sistema</returns>
        public static DataTable GetVariable(string codVariable)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodVariable", codVariable));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_VAR_GET_VARIABLE", list);
        }

        /// <summary>
        /// Consulta toda la informaci�n de las variables existentes en el sistema
        /// </summary>
        /// <returns>DataTable con los c�digos de las variables existentes en el sistema</returns>
        public static DataTable GetListaVariables()
        {
            ArrayList list = new ArrayList();

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_VAR_GET_LISTA_VARIABLES", list);
        }

        /// <summary>
        /// Consulta toda la informaci�n de los tipos de variables existentes en el sistema
        /// </summary>
        /// <returns>DataTable con la informaci�n de los tipos de variables existentes en el sistema</returns>
        public static DataTable GetTiposVariables()
        {
            ArrayList list = new ArrayList();

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_VAR_GET_TIPOS_VARIABLES", list);
        }

        /// <summary>
        /// Consulta el alias de una escenario de variables
        /// </summary>
        /// <param name="codEscenario"></param>
        /// <returns></returns>
        public static DataTable GetAliasEscenarioVariables(string codEscenario)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodEscenario", codEscenario));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_VAR_GET_ALIAS_ESCENARIO", list);
        }
        #endregion

        #region TAB Insert: funciones Add -> AddX(...)
        /// <summary>
        /// Guarda nueva variable
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="habilitado"></param>
        /// <param name="grupo"></param>
        /// <param name="trazabilidad"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public static int AddVariable(string codigo, string nombre, string descripcion, bool habilitado, string grupo, bool trazabilidad, int tipo)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodVariable", codigo));
            list.Add(new SqlParameter("@NombreVariable", nombre));
            list.Add(new SqlParameter("@DescVariable", descripcion));
            list.Add(new SqlParameter("@HabilitadoVariable", habilitado));
            list.Add(new SqlParameter("@Grupo", grupo));
            list.Add(new SqlParameter("@GuardarTrazabilidad", trazabilidad));
            list.Add(new SqlParameter("@IdTipoVariable", tipo));

            return OBaseDatosParam.SQLServer.EjecutarProcedimientoAlmacenado("VA_VAR_ADD_LISTA_VARIABLES", list);
        }
        #endregion

        #region TAB Update: funciones Modify -> MdfX(...)
        /// <summary>
        /// Guarda la variable modificada
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="habilitado"></param>
        /// <param name="grupo"></param>
        /// <param name="trazabilidad"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public static int ModificaVariable(int id, string codigo, string nombre, string descripcion, bool habilitado, string grupo, bool trazabilidad, int tipo)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@IdVariable", id));
            list.Add(new SqlParameter("@CodVariable", codigo));
            list.Add(new SqlParameter("@NombreVariable", nombre));
            list.Add(new SqlParameter("@DescVariable", descripcion));
            list.Add(new SqlParameter("@HabilitadoVariable", habilitado));
            list.Add(new SqlParameter("@Grupo", grupo));
            list.Add(new SqlParameter("@GuardarTrazabilidad", trazabilidad));
            list.Add(new SqlParameter("@IdTipoVariable", tipo));

            return OBaseDatosParam.SQLServer.EjecutarProcedimientoAlmacenado("VA_VAR_MDF_LISTA_VARIABLES", list);
        }
        #endregion

        #region TAB Delete: funciones Delete -> DelX(...)
        /// <summary>
        /// Borramos una variable
        /// </summary>
        /// <param name="idVariable"></param>
        /// <returns></returns>
        public static int EliminaVariable(int idVariable)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@IdVariable", idVariable));

            return OBaseDatosParam.SQLServer.EjecutarProcedimientoAlmacenado("VA_VAR_DEL_LISTA_VARIABLES", list);
        }
        #endregion
    }
}
