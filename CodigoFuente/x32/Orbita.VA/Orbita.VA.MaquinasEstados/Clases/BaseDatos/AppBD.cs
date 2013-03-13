//***********************************************************************
// Assembly         : Orbita.VA.MaquinasEstados
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 12-03-2013
// Description      : Cambiados el acceso a los procedimientos almacenados para incluir el prefijo VA
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
	/// Clase estática que contiene llamadas a los procedimiento almacenados en la base de datos
	/// </summary>
	public static class AppBD
	{
		#region TAB Select: funciones Get -> GetX(...)

		/// <summary>
		/// Consulta todas las máquinas de estados existentes en el sistema
		/// </summary>
		/// <returns>DataTable con los códigos de las máquinas de estado existentes en el sistema</returns>
		public static DataTable GetMaquinasEstados()
		{
			ArrayList list = new ArrayList();

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_EST_GET_MAQUINAS_ESTADO", list);
		}

		/// <summary>
		/// Consulta una máquina de estados
		/// </summary>
		/// <returns>DataTable con la información de las máquinas de estados</returns>
		public static DataTable GetMaquinaEstados(string codMaquinaEstados)
		{
			ArrayList list = new ArrayList();
			list.Add(new SqlParameter("@CodMaquinaEstados", codMaquinaEstados));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_EST_GET_MAQUINA_ESTADO", list);
		}

        /// <summary>
        /// Consulta todas las máquinas de estados existentes en el sistema
        /// </summary>
        /// <returns>DataTable con los códigos de las máquinas de estado existentes en el sistema</returns>
        public static DataTable GetInstanciasMaquinasEstados()
        {
            ArrayList list = new ArrayList();

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_EST_GET_INSTANCIAS_MAQUINAS_ESTADO", list);
        }

        /// <summary>
        /// Consulta una máquina de estados
        /// </summary>
        /// <returns>DataTable con la información de las máquinas de estados</returns>
        public static DataTable GetInstanciaMaquinaEstados(string codInstanciaMaquinaEstados)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodInstanciaMaquinaEstados", codInstanciaMaquinaEstados));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_EST_GET_INSTANCIA_MAQUINA_ESTADO", list);
        }

		/// <summary>
		/// Consulta todos los estados pertenecientes a determinada máquina de estados
		/// </summary>
		/// <returns>DataTable con los códigos de los estados pertenecientes a determinada máquina de estados</returns>
        public static DataTable GetInstanciasEstados(string codInstanciaMaquinaEstados)
		{
			ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodInstanciaMaquinaEstados", codInstanciaMaquinaEstados));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_EST_GET_INSTANCIAS_ESTADOS", list);
		}

		/// <summary>
		/// Consulta todos las transiciones pertenecientes a determinada máquina de estados
		/// </summary>
		/// <returns>DataTable con los códigos de las transiciones pertenecientes a determinada máquina de estados</returns>
        public static DataTable GetInstanciasTransiciones(string codInstanciaMaquinaEstados)
		{
			ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodInstanciaMaquinaEstados", codInstanciaMaquinaEstados));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_EST_GET_INSTANCIAS_TRANSICIONES", list);
		}

        /// <summary>
        /// Consulta todos los estados pertenecientes a determinada máquina de estados
        /// </summary>
        /// <returns>DataTable con los códigos de los estados pertenecientes a determinada máquina de estados</returns>
        public static DataTable GetEstados(string codMaquinaEstados)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodMaquinaEstados", codMaquinaEstados));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_EST_GET_ESTADOS", list);
        }

        /// <summary>
        /// Consulta todos las transiciones pertenecientes a determinada máquina de estados
        /// </summary>
        /// <returns>DataTable con los códigos de las transiciones pertenecientes a determinada máquina de estados</returns>
        public static DataTable GetTransiciones(string codMaquinaEstados)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodMaquinaEstados", codMaquinaEstados));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_EST_GET_TRANSICIONES", list);
        }

        /// <summary>
		/// Consulta un determinado estado
		/// </summary>
		/// <returns>DataTable con la información de un determinado estado</returns>
        public static DataTable GetInstanciaEstado(string codInstanciaMaquinaEstados, string codEstado)
		{
			ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodInstanciaMaquinaEstados", codInstanciaMaquinaEstados));
			list.Add(new SqlParameter("@CodEstado", codEstado));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_EST_GET_INSTANCIA_ESTADO", list);
		}

		/// <summary>
		/// Consulta un determinada transicion
		/// </summary>
		/// <returns>DataTable con la información de una determinada transicion</returns>
        public static DataTable GetInstanciaTransicion(string codInstanciaMaquinaEstados, string codTransicion)
		{
			ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodInstanciaMaquinaEstados", codInstanciaMaquinaEstados));
			list.Add(new SqlParameter("@CodTransicion", codTransicion));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_EST_GET_INSTANCIA_TRANSICION", list);
		}

        /// <summary>
        /// Consulta todos los estados pertenecientes a determinada máquina de estados
        /// </summary>
        /// <returns>DataTable con los códigos de los estados pertenecientes a determinada máquina de estados</returns>
        public static DataTable GetEstado(string codMaquinaEstados, string codEstado)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@codMaquinaEstados", codMaquinaEstados));
            list.Add(new SqlParameter("@CodEstado", codEstado));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_EST_GET_ESTADO", list);
        }

        /// <summary>
        /// Consulta un determinada transicion
        /// </summary>
        /// <returns>DataTable con la información de una determinada transicion</returns>
        public static DataTable GetTransicion(string codMaquinaEstados, string codTransicion)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@codMaquinaEstados", codMaquinaEstados));
            list.Add(new SqlParameter("@CodTransicion", codTransicion));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_EST_GET_TRANSICION", list);
        }

		/// <summary>
		/// Consulta las variables de un determinada transicion
		/// </summary>
		/// <returns>DataTable con la información de una determinada transicion</returns>
        public static DataTable GetVariablesTransicion(string codInstanciaMaquinaEstados, string codTransicion)
		{
			ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodInstanciaMaquinaEstados", codInstanciaMaquinaEstados));
			list.Add(new SqlParameter("@CodTransicion", codTransicion));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_EST_GET_VARIABLES_TRANSICION", list);
		}

		/// <summary>
		/// Consulta las claves de una determinada escenario
		/// </summary>
		/// <param name="codEscenario"></param>
		/// <returns></returns>
		public static DataTable GetClavesDeEscenario(string codEscenario)
		{
			ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodEscenario", codEscenario));

			return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_ESC_GET_ESCENARIO_CLAVES", list);
		}
		#endregion

		#region TAB Insert: funciones Add -> AddX(...)
		#endregion

		#region TAB Update: funciones Modify -> MdfX(...) 
		#endregion 

		#region TAB Delete: funciones Delete -> DelX(...)
		#endregion
	}
}
