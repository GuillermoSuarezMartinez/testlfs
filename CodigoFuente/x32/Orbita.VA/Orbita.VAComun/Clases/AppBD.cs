//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 27-09-2012
// Description      : Añadidas funciones de almacenamiento
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Orbita.Utiles;
using System.Text.RegularExpressions;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase estática que contiene llamadas a los procedimiento almacenados en la base de datos
    /// </summary>
    public static class AppBD
    {
        #region Constante(s)
        /// <summary>
        /// Ruta por defecto del fichero xml de configuración
        /// </summary>
        public static string DataFile = Path.Combine(ORutaParametrizable.AppFolder, "Configuracion_Datos.xml");

        /// <summary>
        /// Ruta por defecto del fichero xml de configuración
        /// </summary>
        public static string XmlSchemaFile = Path.Combine(ORutaParametrizable.AppFolder, "Estructura_BaseDatos.xml");
        #endregion

        #region Métodos de sistema
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
                DataTable dt = OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("APP_GET_SELECT_A_MEDIDA", list);
                dt.TableName = tabla.Key;
                ds.Tables.Add(dt);
            }

            ds.WriteXml(xmlFile, XmlWriteMode.WriteSchema);
        }

        /// <summary>
        /// Extrae un dataset con el esquema de la base de datos seleccionada. Tablas y procedimientos
        /// </summary>
        public static void ExtraerEsquemaBBDD(EnumOrigenBaseDatos origenBaseDatos, ref DataSet ds)
        {
            DataTable dtTablas = OBaseDatosManager.SQLServer(origenBaseDatos).SeleccionProcedimientoAlmacenado("APP_GET_ESQUEMA_TABLAS");
            dtTablas.TableName = "TABLAS_" + origenBaseDatos.Nombre;
            ds.Tables.Add(dtTablas);

            DataTable dtProcedimientos = OBaseDatosManager.SQLServer(origenBaseDatos).SeleccionProcedimientoAlmacenado("APP_GET_PROCEDIMIENTOS");
            dtProcedimientos.TableName = "PROCEDIMIENTOS_" + origenBaseDatos.Nombre;
            ds.Tables.Add(dtProcedimientos);

            //ds.WriteXml(xmlFile, XmlWriteMode.WriteSchema);
        }

        /// <summary>
        /// Compara los esquemas de las bases de datos seleccionadas. Tanto los campos de las tablas como los procedimientos almacenados
        /// </summary>
        public static bool CompararEsquemaBBDD(List<EnumOrigenBaseDatos> origenesBaseDatos, out string explicacion)
        {
            bool resultado = false;
            explicacion = string.Empty;

            DataSet dsActual = new DataSet();
            DataSet dsReferencia = new DataSet();

            ExtraerEsquemaBBDD(OrigenBaseDatos.Parametrizacion, ref dsActual);
            ExtraerEsquemaBBDD(OrigenBaseDatos.Almacen, ref dsActual);
            //dsActual.WriteXml(xmlFile, XmlWriteMode.WriteSchema);

            dsReferencia.ReadXml(XmlSchemaFile);

            // Comparación de BBDD
            resultado = true;
            foreach (EnumOrigenBaseDatos origenBBDD in origenesBaseDatos)
            {
                // Compración de tablas
                string nombreTabla = "TABLAS_" + origenBBDD.Nombre;
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
                        explicacion += string.Format("La columna {0} de la tabla {1} no existe en la BBDD {2}.", nomColumna, nomTabla, origenBBDD.Nombre) + Environment.NewLine;
	                }
                    else
                    {
                        DataRow drActual = drActuales[0];

                        string tipoReferencia = (string)drReferencia["nom_tipo"];
                        string tipoActual = (string)drActual["nom_tipo"];
                        if (tipoReferencia != tipoActual)
	                    {
                            resultado = false;
                            explicacion += string.Format("La columna {0} de la tabla {1} de la BBDD {2} no es del tipo {3}.", nomColumna, nomTabla, origenBBDD.Nombre, tipoReferencia) + Environment.NewLine;
	                    }

                        short longReferencia = (short)drReferencia["max_length"];
                        short longActual = (short)drActual["max_length"];
                        if (longReferencia != longActual)
	                    {
                            resultado = false;
                            explicacion += string.Format("La columna {0} de la tabla {1} de la BBDD {2} no es de la longitud {3}.", nomColumna, nomTabla, origenBBDD.Nombre, longReferencia) + Environment.NewLine;
	                    }

                        byte precisionReferencia = (byte)drReferencia["precision"];
                        byte precisionActual = (byte)drActual["precision"];
                        if (precisionReferencia != precisionActual)
	                    {
                            resultado = false;
                            explicacion += string.Format("La columna {0} de la tabla {1} de la BBDD {2} no es de la precisión {3}.", nomColumna, nomTabla, origenBBDD.Nombre, precisionReferencia) + Environment.NewLine;
	                    }

                        byte escalaReferencia = (byte)drReferencia["scale"];
                        byte escalaActual = (byte)drActual["scale"];
                        if (escalaReferencia != escalaActual)
	                    {
                            resultado = false;
                            explicacion += string.Format("La columna {0} de la tabla {1} de la BBDD {2} no es de la escala {3}.", nomColumna, nomTabla, origenBBDD.Nombre, escalaReferencia) + Environment.NewLine;
	                    }

                        bool nullableReferencia = (bool)drReferencia["is_nullable"];
                        bool nullableActual = (bool)drActual["is_nullable"];
                        if (nullableReferencia != nullableActual)
	                    {
                            resultado = false;
                            explicacion += string.Format("La columna {0} de la tabla {1} de la BBDD {2} debe tener la opción 'permitir valores NULL' a {3}.", nomColumna, nomTabla, origenBBDD.Nombre, nullableReferencia) + Environment.NewLine;
	                    }

                        bool identidadReferencia = (bool)drReferencia["is_identity"];
                        bool identidadActual = (bool)drActual["is_identity"];
                        if (identidadReferencia != identidadActual)
	                    {
                            resultado = false;
                            explicacion += string.Format("La columna {0} de la tabla {1} de la BBDD {2} debe tener la opción 'identidad' a {3}.", nomColumna, nomTabla, origenBBDD.Nombre, identidadReferencia) + Environment.NewLine;
	                    }
                    }
                }


                // Compración de procedimientos
                nombreTabla = "PROCEDIMIENTOS_" + origenBBDD.Nombre;
                dtReferencia = dsReferencia.Tables[nombreTabla];
                dtActual = dsActual.Tables[nombreTabla];
                foreach (DataRow drReferencia in dtReferencia.Rows)
                {
                    string nomProcedimiento = (string)drReferencia["SPECIFIC_NAME"];
                    DataRow[] drActuales = dtActual.Select(string.Format("SPECIFIC_NAME = '{0}'", nomProcedimiento));
                    if (drActuales.Length != 1)
	                {
                        resultado = false;
                        explicacion += string.Format("El procedimiento {0} no existe en la BBDD {1}.", nomProcedimiento, origenBBDD.Nombre) + Environment.NewLine;
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
                            explicacion += string.Format("El procedimiento almacenado {0} de la BBDD {1} difiere del correcto.", nomProcedimiento, origenBBDD.Nombre) + Environment.NewLine;
	                    }
                    }
                }

            }

            return resultado;
        }

        #endregion

        #region TAB Select: funciones Get -> GetX(...)

        /// <summary>
        /// Consulta los parámetros básicos de la aplicación
        /// </summary>
        /// <returns>DataTable con los parámetros básicos de la aplicación</returns>
        public static DataTable GetParametrosAplicacion()
        {
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("APP_GET_PARAMETROS");
        }

        /// <summary>
        /// Consulta todas vistas existentes en el sistema
        /// </summary>
        /// <returns>DataTable con los códigos de las variables existentes en el sistema</returns>
        public static DataTable GetVistas()
        {
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VST_GET_VISTAS");
        }
        /// <summary>
        /// Consulta una vista existente en el sistema
        /// </summary>
        /// <returns>DataTable con los códigos de las vistas existentes en el sistema</returns>
        public static DataTable GetVista(string codVista)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodVista", codVista));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VST_GET_VISTA", list);
        }

        /// <summary>
        /// Consulta un usuario existente en el sistema
        /// </summary>
        /// <returns>DataTable con los la información del usuario</returns>
        public static DataTable GetUsuarios()
        {
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("USU_GET_USUARIOS");
        }
        /// <summary>
        /// Consulta un usuario existente en el sistema
        /// </summary>
        /// <returns>DataTable con los la información del usuario</returns>
        public static DataTable GetUsuario(string codigo)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodUsuario", codigo));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("USU_GET_USUARIO", list);
        }
        #endregion

        #region TAB Insert: funciones Add -> AddX(...)
        /// <summary>
        /// Añade el historico de la inspección de la pieza
        /// </summary>
        /// <returns></returns>        
        public static int AddHistoricoSerie(bool resultado, DateTime fecha, bool inspeccionado, string excepcion, bool rechazado, TimeSpan tiempoProceso, int IdTipoHistorico, OXml xMLDetalle, OXml xMLClaves)
        {
            ArrayList list = new ArrayList();

            list.Add(new SqlParameter("@Resultado", resultado));
            list.Add(new SqlParameter("@Fecha", fecha));
            list.Add(new SqlParameter("@Inspeccionado", inspeccionado));
            list.Add(new SqlParameter("@Excepcion", excepcion));
            list.Add(new SqlParameter("@Rechazado", rechazado));
            list.Add(new SqlParameter("@TiempoProceso", (int)Math.Round(tiempoProceso.TotalMilliseconds)));
            list.Add(new SqlParameter("@IdTipoHistorico", IdTipoHistorico));

            list.Add(new SqlParameter("@DETALLE_HISTORICO_ADD", (xMLDetalle == null) ? null : xMLDetalle.SWXml.ToString()));
            list.Add(new SqlParameter("@CLAVES_HISTORICO_ADD", (xMLClaves == null) ? null : xMLClaves.SWXml.ToString()));

            return OBaseDatosAlmacen.SQLServer.EjecutarProcedimientoAlmacenado("HIS_ADD_HISTORICO_SERIE_XML", list);
        }

        /// <summary>
        /// Añade el historico de la inspección de la pieza
        /// </summary>
        /// <returns></returns>        
        public static int AddHistoricoSubInspeccionSerie(int idHistorico, bool resultado, bool inspeccionado, string excepcion, TimeSpan tiempoProceso, OXml xMLDetalle)
        {
            ArrayList list = new ArrayList();

            list.Add(new SqlParameter("@IdHistorico", idHistorico));
            list.Add(new SqlParameter("@Resultado", resultado));
            list.Add(new SqlParameter("@Inspeccionado", inspeccionado));
            list.Add(new SqlParameter("@Excepcion", excepcion));
            list.Add(new SqlParameter("@TiempoProceso", (int)Math.Round(tiempoProceso.TotalMilliseconds)));

            list.Add(new SqlParameter("@DETALLE_HISTORICO_ADD", (xMLDetalle == null) ? null : xMLDetalle.SWXml.ToString()));

            return OBaseDatosAlmacen.SQLServer.EjecutarProcedimientoAlmacenado("HIS_ADD_HISTORICO_SUBINSPECCION_SERIE_XML", list);
        }

        /// <summary>
        /// Añade el historico de la inspección de la pieza
        /// </summary>
        /// <returns></returns>        
        public static int AddHistoricoParalelo(int IdTipoHistorico, OXml xMLDetalle, OXml xMLClaves, OXml xMLSubDetalle)
        {
            ArrayList list = new ArrayList();

            list.Add(new SqlParameter("@IdTipoHistorico", IdTipoHistorico));
            list.Add(new SqlParameter("@DETALLE_HISTORICO_ADD", (xMLDetalle == null) ? null : xMLDetalle.SWXml.ToString()));
            list.Add(new SqlParameter("@CLAVES_HISTORICO_ADD", (xMLClaves == null) ? null : xMLClaves.SWXml.ToString()));
            list.Add(new SqlParameter("@SUB_DETALLE_HISTORICO_ADD", (xMLSubDetalle == null) ? null : xMLSubDetalle.SWXml.ToString()));

            return OBaseDatosAlmacen.SQLServer.EjecutarProcedimientoAlmacenado("HIS_ADD_HISTORICO_PARALELO_XML", list);
        }
        #endregion

        #region TAB Update: funciones Modify -> MdfX(...)
        #endregion

        #region TAB Delete: funciones Delete -> DelX(...)
        #endregion
    }
}
