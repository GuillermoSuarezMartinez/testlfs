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
    /// <summary>
    /// Métodos de base de datos.
    /// </summary>
    public static class AppBD
    {
        #region Métodos públicos estáticos
        /// <summary>
        /// Obtener tipo de autenticación.
        /// </summary>
        /// <returns></returns>
        public static System.Data.DataTable GetTipoAutenticacion()
        {
            return App.COMS.SeleccionProcedimientoAlmacenado("FW_GET_TIPO_AUTENTICACION");
        }
        /// <summary>
        /// Obtener resultado de autenticación de un usuario.
        /// </summary>
        /// <param name="usuario">Usuario de autenticación.</param>
        /// <returns></returns>
        public static System.Data.DataTable GetAutenticacionBBDD(string usuario)
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            list.Add(new System.Data.SqlClient.SqlParameter("@NOMBRE_USUARIO", usuario));
            return App.COMS.SeleccionProcedimientoAlmacenado("GET_USUARIO_PASS", list);
        }
        #endregion
    }
}