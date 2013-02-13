//***********************************************************************
// Assembly         : Orbita.VA.Funciones
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

namespace Orbita.VA.Funciones
{
	public static class AppBD
	{
		#region TAB Select: funciones Get -> GetX(...)

		/// <summary>
		/// Consulta las par�metros de un determinada funci�n de visi�n
		/// </summary>
		/// <returns>DataTable con la informaci�n de una determinada funci�n de visi�n</returns>
		public static DataTable GetParametrosFuncionesVision(string codFuncionVision, bool esEntrada)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodFuncionVision", codFuncionVision));
			list.Add(new SqlParameter("@EsEntrada", esEntrada));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VIS_GET_PARAMETROS_FUNCIONES_VISION", list);
		}

		/// <summary>
		/// Consulta toda la informaci�n de un determinado par�metro de una funci�n de visi�n
		/// </summary>
		/// <returns>DataTable con la informaci�n de una determinada funci�n de visi�n</returns>
		public static DataTable GetParametroFuncionVision(string codFuncionVision, string codParametroFuncionVision)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodFuncionVision", codFuncionVision));
			list.Add(new SqlParameter("@codParametroFuncionVision", codParametroFuncionVision));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VIS_GET_PARAMETRO_FUNCION_VISION", list);
		}

		/// <summary>
		/// Consulta todas las funciones de vision existentes en el sistema
		/// </summary>
		/// <returns>DataTable con los c�digos de las funciones de vision existentes en el sistema</returns>
		public static DataTable GetFuncionesVision()
		{
			ArrayList list = new ArrayList();

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VIS_GET_FUNCIONES_VISION", list);
		}

		/// <summary>
		/// Consulta una funci�n de visi�n
		/// </summary>
		/// <returns>DataTable con la informaci�n de la funci�n de visi�n</returns>
		public static DataTable GetFuncionVision(string codFuncionVision)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodFuncionVision", codFuncionVision));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VIS_GET_FUNCION_VISION", list);
		}

		/// <summary>
		/// Consulta las claves de una determinada vista
		/// </summary>
		/// <param name="codVista"></param>
		/// <returns></returns>
		public static DataTable GetClavesDeFuncionVision(string codFuncionVision)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodFuncionVision", codFuncionVision));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VIS_GET_FUNCIONES_VISION_CLAVES", list);
		}

		#endregion

		#region TAB Add: funciones Add -> AddX(...)

		#endregion

		#region TAB Update: funciones Modify -> MdfX(...)

		#endregion

		#region TAB Delete: funciones Delete -> DelX(...)

		#endregion
	}
}
