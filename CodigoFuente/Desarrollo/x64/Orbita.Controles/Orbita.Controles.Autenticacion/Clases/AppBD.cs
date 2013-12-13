//***********************************************************************
// Assembly         : Orbita.Controles.Autenticacion
// Author           : jljuan
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Autenticacion
{
    public class AppBD
    {
        public static System.Data.DataTable Get_Tipo_Autenticacion()
        {
            System.Data.DataTable resultado = null;
            try
            {
                resultado = App.COMS.SeleccionProcedimientoAlmacenado("FW_GET_TIPO_AUTENTICACION");
            }
            catch
            {
                throw;
            }
            return resultado;
        }
        public static System.Data.DataTable Get_Autenticacion_BBDD(string usuario)
        {
            System.Data.DataTable resultado = null;
            try
            {
                System.Collections.ArrayList list = new System.Collections.ArrayList();
                list.Add(new System.Data.SqlClient.SqlParameter("@NOMBRE_USUARIO", usuario));
                resultado = App.COMS.SeleccionProcedimientoAlmacenado("GET_USUARIO_PASS", list);
            }
            catch
            {
                throw;
            }
            return resultado;
        }
    }
}