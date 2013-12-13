//***********************************************************************
// Assembly         : Orbita.Framework
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Framework
{
    public static class DatosHelper
    {
        /// <summary>
        /// Obtener la configuración principal del Framework.
        /// </summary>
        /// <returns>Una tabla de datos con la configuración que tenga registros activos.</returns>
        public static System.Data.DataTable GetConfiguracion()
        {
            System.Data.DataTable resultado = null;
            try
            {
                resultado = BDatos.FW.SeleccionProcedimientoAlmacenado("FW_GET_CONFIGURACION");
            }
            catch
            {
                throw;
            }
            return resultado;
        }
    }
}