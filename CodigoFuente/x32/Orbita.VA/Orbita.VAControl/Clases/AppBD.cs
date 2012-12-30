//***********************************************************************
// Assembly         : Orbita.VA.MaquinasEstados
// Author           : aiba�ez
// Created          : 06-09-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Orbita.VA.Comun;
using Orbita.Utiles;

namespace Orbita.VA.MaquinasEstados
{
	/// <summary>
	/// Clase est�tica que contiene llamadas a los procedimiento almacenados en la base de datos
	/// </summary>
	public static class AppBD
	{
		#region TAB Select: funciones Get -> GetX(...)

		/// <summary>
		/// Consulta todas las m�quinas de estados existentes en el sistema
		/// </summary>
		/// <returns>DataTable con los c�digos de las m�quinas de estado existentes en el sistema</returns>
		public static DataTable GetMaquinasEstados()
		{
			ArrayList list = new ArrayList();

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("EST_GET_MAQUINAS_ESTADO", list);
		}

		/// <summary>
		/// Consulta una m�quina de estados
		/// </summary>
		/// <returns>DataTable con la informaci�n de las m�quinas de estados</returns>
		public static DataTable GetMaquinaEstados(string codMaquinaEstados)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodMaquinaEstados", codMaquinaEstados));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("EST_GET_MAQUINA_ESTADO", list);
		}

		/// <summary>
		/// Consulta todos los estados pertenecientes a determinada m�quina de estados
		/// </summary>
		/// <returns>DataTable con los c�digos de los estados pertenecientes a determinada m�quina de estados</returns>
		public static DataTable GetEstados(string codMaquinaEstados)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodMaquinaEstados", codMaquinaEstados));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("EST_GET_ESTADOS", list);
		}

		/// <summary>
		/// Consulta todos las transiciones pertenecientes a determinada m�quina de estados
		/// </summary>
		/// <returns>DataTable con los c�digos de las transiciones pertenecientes a determinada m�quina de estados</returns>
		public static DataTable GetTransiciones(string codMaquinaEstados)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodMaquinaEstados", codMaquinaEstados));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("EST_GET_TRANSICIONES", list);
		}

		/// <summary>
		/// Consulta un determinado estado
		/// </summary>
		/// <returns>DataTable con la informaci�n de un determinado estado</returns>
		public static DataTable GetEstado(string codMaquinaEstados, string codEstado)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodMaquinaEstados", codMaquinaEstados));
			list.Add(new SqlParameter("@CodEstado", codEstado));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("EST_GET_ESTADO", list);
		}

		/// <summary>
		/// Consulta un determinado estado de tipo thread
		/// </summary>
		/// <returns>DataTable con la informaci�n de un determinado estado</returns>
		public static DataTable GetEstadoAsincrono(string codMaquinaEstados, string codEstado)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodMaquinaEstados", codMaquinaEstados));
			list.Add(new SqlParameter("@CodEstado", codEstado));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("EST_GET_ESTADO_THREAD", list);
		}

		/// <summary>
		/// Consulta un determinada transicion
		/// </summary>
		/// <returns>DataTable con la informaci�n de una determinada transicion</returns>
		public static DataTable GetTransicion(string codMaquinaEstados, string codTransicion)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodMaquinaEstados", codMaquinaEstados));
			list.Add(new SqlParameter("@CodTransicion", codTransicion));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("EST_GET_TRANSICION", list);
		}

		/// <summary>
		/// Consulta las variables de un determinada transicion
		/// </summary>
		/// <returns>DataTable con la informaci�n de una determinada transicion</returns>
		public static DataTable GetVariablesTransicion(string codMaquinaEstados, string codTransicion)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodMaquinaEstados", codMaquinaEstados));
			list.Add(new SqlParameter("@CodTransicion", codTransicion));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("EST_GET_VARIABLES_TRANSICION", list);
		}

		/// <summary>
		/// Consulta todas variables existentes en el sistema
		/// </summary>
		/// <returns>DataTable con los c�digos de las variables existentes en el sistema</returns>
		public static DataTable GetVariables()
		{
			ArrayList list = new ArrayList();

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VAR_GET_VARIABLES", list);
		}

		/// <summary>
		/// Consulta una variables existente en el sistema
		/// </summary>
		/// <returns>DataTable con los c�digos de las variables existentes en el sistema</returns>
		public static DataTable GetVariable(string codVariable)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodVariable", codVariable));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VAR_GET_VARIABLE", list);
		}

		/// <summary>
		/// Consulta toda la informaci�n de las variables existentes en el sistema
		/// </summary>
		/// <returns>DataTable con los c�digos de las variables existentes en el sistema</returns>
		public static DataTable GetListaVariables()
		{
			ArrayList list = new ArrayList();

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VAR_GET_LISTA_VARIABLES", list);
		}

		/// <summary>
		/// Consulta toda la informaci�n de los tipos de variables existentes en el sistema
		/// </summary>
		/// <returns>DataTable con la informaci�n de los tipos de variables existentes en el sistema</returns>
		public static DataTable GetTiposVariables()
		{
			ArrayList list = new ArrayList();

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VAR_GET_TIPOS_VARIABLES", list);
		}

		/// <summary>
		/// Consulta el alias de una vista de variables
		/// </summary>
		/// <param name="codVista"></param>
		/// <returns></returns>
		public static DataTable GetAliasVistaVariables(string codVista)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodVista", codVista));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VAR_GET_ALIAS_VISTA", list);
		}

		/// <summary>
		/// Consulta las claves de una determinada vista
		/// </summary>
		/// <param name="codVista"></param>
		/// <returns></returns>
		public static DataTable GetClavesDeVista(string codVista)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodVista", codVista));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VST_GET_VISTA_CLAVES", list);
		}
		

		#endregion

		#region TAB Insert: funciones Add -> AddX(...)

		/// <summary>
		/// A�ade informaci�n de las trazas a la base de datos
		/// </summary>
		/// <param name="datosTrazas">Objeto CXML con los datos de las trazas</param>
		/// <returns>Menor que 0 si ha habido alg�n error (devuleve un c�digo de errores ente -1 y -7 en funci�n de donde se ha producido)</returns>
		public static int AddTrazas(OXml datosTrazas)
		{
			ArrayList list = new ArrayList();

			list.Add(new SqlParameter("@DATOS_TRAZAS_ADD", (datosTrazas == null) ? null : datosTrazas.SWXml.ToString()));

			return OBaseDatosAlmacen.SQLServer.EjecutarProcedimientoAlmacenado("VAR_ADD_TRAZAS_XML", list);
		}

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

			return OBaseDatosParam.SQLServer.EjecutarProcedimientoAlmacenado("VAR_ADD_LISTA_VARIABLES", list);
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

			return OBaseDatosParam.SQLServer.EjecutarProcedimientoAlmacenado("VAR_MDF_LISTA_VARIABLES", list);
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

			return OBaseDatosParam.SQLServer.EjecutarProcedimientoAlmacenado("VAR_DEL_LISTA_VARIABLES", list);
		}
		#endregion
	}
}
