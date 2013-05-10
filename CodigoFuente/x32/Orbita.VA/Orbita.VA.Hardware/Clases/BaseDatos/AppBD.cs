//***********************************************************************
// Assembly         : Orbita.VA.Hardware
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

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Clase estática que contiene llamadas a los procedimiento almacenados en la base de datos
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
            string nombreProcedimientoAlmacenado = OHardwareManager.Servidor ? "CAMS_HWR_GET_HARDWARE" : "VA_HWR_GET_HARDWARE";
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado(nombreProcedimientoAlmacenado);
        }
        /// <summary>
        /// Consulta las cámaras del sistema
        /// </summary>
        /// <returns>DataTable con los códigos de las cámaras existentes en el sistema</returns>
        public static DataTable GetCamaras()
        {
            string nombreProcedimientoAlmacenado = OHardwareManager.Servidor ? "CAMS_CAM_GET_CAMARAS" : "VA_CAM_GET_CAMARAS";
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado(nombreProcedimientoAlmacenado);
        }
        /// <summary>
        /// Consulta la información de una determinada cámara
        /// </summary>
        /// <returns>DataTable con toda la información de una determinada cámara</returns>
        public static DataTable GetCamara(string codCamara)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodCamara", codCamara));

            string nombreProcedimientoAlmacenado = OHardwareManager.Servidor ? "CAMS_CAM_GET_CAMARA" : "VA_CAM_GET_CAMARA";
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado(nombreProcedimientoAlmacenado, list);
        }
        /// <summary>
        /// Consulta las tarjetas IO del sistema
        /// </summary>
        /// <returns>DataTable con los códigos de las tarjetas IO existentes en el sistema</returns>
        public static DataTable GetTarjetasIO()
        {
            string nombreProcedimientoAlmacenado = OHardwareManager.Servidor ? "CAMS_IO_GET_TARJETAS" : "VA_IO_GET_TARJETAS";
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado(nombreProcedimientoAlmacenado);
        }
        /// <summary>
        /// Consulta los terminales IO de una determinada tarjeta IO
        /// </summary>
        /// <returns>DataTable con los terminales IO  de una determinada tarjeta IO</returns>
        public static DataTable GetTerminalesIO(string codTarjetaIO)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodTarjetaIO", codTarjetaIO));

            string nombreProcedimientoAlmacenado = OHardwareManager.Servidor ? "CAMS_IO_GET_TERMINALES" : "VA_IO_GET_TERMINALES";
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado(nombreProcedimientoAlmacenado, list);
        }
        /// <summary>
        /// Consulta la información de una determinada tarjeta IO
        /// </summary>
        /// <returns>DataTable con toda la información de una determinada tarjeta IO</returns>
        public static DataTable GetTarjetaIO(string codTarjetaIO)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodTarjetaIO", codTarjetaIO));

            string nombreProcedimientoAlmacenado = OHardwareManager.Servidor ? "CAMS_IO_GET_TARJETA" : "VA_IO_GET_TARJETA";
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado(nombreProcedimientoAlmacenado, list);
        }
        /// <summary>
        /// Consulta la información de un determinado terminal de una tarjeta IO
        /// </summary>
        /// <returns>DataTable con toda la información de un determinado terminal de una tarjeta IO</returns>
        public static DataTable GetTerminalIO(string codTarjetaIO, string codTerminalIO)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodTarjetaIO", codTarjetaIO));
            list.Add(new SqlParameter("@CodTerminalIO", codTerminalIO));

            string nombreProcedimientoAlmacenado = OHardwareManager.Servidor ? "CAMS_IO_GET_TERMINAL" : "VA_IO_GET_TERMINAL";
            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado(nombreProcedimientoAlmacenado, list);
        }
        /// <summary>
        /// Consulta la información de todos los terminales que están vinculados a cierto terminal de escritura
        /// </summary>
        /// <returns>DataTable con los terminales IO  de una determinada tarjeta IO</returns>
        public static DataTable GetTerminalesIO_EscrituraCOM(string codTarjetaIO, string codTerminalIOEscritura)
        {
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@CodTarjetaIO", codTarjetaIO));
            list.Add(new SqlParameter("@CodTerminalIO", codTerminalIOEscritura));

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("VA_IO_GET_COM_TERMINALES_ESCRITURA", list);
        }
        /// <summary>
        /// Consulta los canales a abrir para servir las cámaras
        /// </summary>
        /// <returns>DataTable con canales a abrir para servir las cámaras</returns>
        public static DataTable GetConfiguracionCanales()
        {
            ArrayList list = new ArrayList();

            return OBaseDatosParam.SQLServer.SeleccionProcedimientoAlmacenado("CAMS_CAM_GET_CANALES", list);
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

