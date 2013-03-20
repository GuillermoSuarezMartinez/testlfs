//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aiba�ez
// Created          : 06-09-2012
//
// Last Modified By : aiba�ez
// Last Modified On : 12-03-2013
// Description      : Cambiados el acceso a los procedimientos almacenados para incluir el prefijo VA
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Orbita.VA.Comun;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Clase est�tica que contiene llamadas a los procedimiento almacenados en la base de datos
    /// </summary>
    public static class AppBD
    {
        #region TAB Select: funciones Get -> GetX(...)
        /// <summary>
        /// Consulta el alias de una escenario de hardware
        /// </summary>
        /// <param name="codEscenario"></param>
        /// <returns></returns>
        public static DataTable GetAliasEscenarioHardware(string codEscenario)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodEscenario", codEscenario));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_HWR_GET_ALIAS_ESCENARIO", list);
        }

        /// <summary>
        /// Consulta todo el hardware del sistema
        /// </summary>
        /// <param name="codEscenario"></param>
        /// <returns></returns>
        public static DataTable GetHardware()
        {
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_HWR_GET_HARDWARE");
        }


        /// <summary>
        /// Consulta las c�maras del sistema
        /// </summary>
        /// <returns>DataTable con los c�digos de las c�maras existentes en el sistema</returns>
        public static DataTable GetCamaras()
        {
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_CAM_GET_CAMARAS");
        }

        /// <summary>
        /// Consulta la informaci�n de una determinada c�mara
        /// </summary>
        /// <returns>DataTable con toda la informaci�n de una determinada c�mara</returns>
        public static DataTable GetCamara(string codCamara)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodCamara", codCamara));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_CAM_GET_CAMARA", list);
        }

        /// <summary>
        /// Consulta las tarjetas IO del sistema
        /// </summary>
        /// <returns>DataTable con los c�digos de las tarjetas IO existentes en el sistema</returns>
        public static DataTable GetTarjetasIO()
        {
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_IO_GET_TARJETAS");
        }
        /// <summary>
        /// Consulta los terminales IO de una determinada tarjeta IO
        /// </summary>
        /// <returns>DataTable con los terminales IO  de una determinada tarjeta IO</returns>
        public static DataTable GetTerminalesIO(string codTarjetaIO)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodTarjetaIO", codTarjetaIO));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_IO_GET_TERMINALES", list);
        }
        /// <summary>
        /// Consulta la informaci�n de una determinada tarjeta IO
        /// </summary>
        /// <returns>DataTable con toda la informaci�n de una determinada tarjeta IO</returns>
        public static DataTable GetTarjetaIO(string codTarjetaIO)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodTarjetaIO", codTarjetaIO));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_IO_GET_TARJETA", list);
        }

        /// <summary>
        /// Consulta la informaci�n de un determinado terminal de una tarjeta IO
        /// </summary>
        /// <returns>DataTable con toda la informaci�n de un determinado terminal de una tarjeta IO</returns>
        public static DataTable GetTerminalIO(string codTarjetaIO, string codTerminalIO)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodTarjetaIO", codTarjetaIO));
            list.Add(new SqlParameter("@CodTerminalIO", codTerminalIO));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_IO_GET_TERMINAL", list);
        }

        /// <summary>
        /// Consulta la informaci�n de todos los terminales que est�n vinculados a cierto terminal de escritura
        /// </summary>
        /// <returns>DataTable con los terminales IO  de una determinada tarjeta IO</returns>
        public static DataTable GetTerminalesIO_EscrituraSCED(string codTarjetaIO, string codTerminalIOEscritura)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodTarjetaIO", codTarjetaIO));
            list.Add(new SqlParameter("@CodTerminalIO", codTerminalIOEscritura));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_IO_GET_SCED_TERMINALES_ESCRITURA", list);
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

