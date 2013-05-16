//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Orbita.BBDD;
using Orbita.Utiles;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase estática que configura el acceso a la bases de datos de SQL Server de parametrización.
    /// </summary>
    public static class OBaseDatosParam
    {
        #region Constante(s)
        /// <summary>
        /// Identificador de la base de datos
        /// </summary>
        public const string NombreBBDD = "Vision";
        #endregion

        #region Propiedad(es)
        /// <summary>
        ///  Acceso a la base de datos SQL Server
        /// </summary>
        private static OSqlServer _SQLServer;
        /// <summary>
        ///  Acceso a la base de datos SQL Server
        /// </summary>
        public static OSqlServer SQLServer
        {
            get { return _SQLServer; }
        }

        /// <summary>
        /// Indica que la creación de los logs ha sido válida
        /// </summary>
        private static bool Valido = Constructor();
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Constructror de los logs
        /// </summary>
        /// <returns></returns>
        private static bool Constructor()
        {
            _SQLServer = (OSqlServer)OBBDDManager.GetBBDD(NombreBBDD);

            return true;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Comprueba el acceso a la base de datos
        /// </summary>
        public static Boolean CompruebaAccesoBasesDatos(TimeSpan timeOut)
        {
            bool servidorEncontrado = false;
            DateTime momentoTimeOut = DateTime.Now.Add(timeOut);
            Exception excepcionConexion = new Exception();

            do
            {
                try
                {
                    servidorEncontrado = SQLServer.TestConexion();
                }
                catch (Exception exception)
                {
                    excepcionConexion = exception;
                }
            }
            while ((!servidorEncontrado) && (DateTime.Now <= momentoTimeOut));

            // Se lanza la excepción
            if (!servidorEncontrado)
            {
                throw new Exception("Ha sido imposible realizar la conexión con la base de datos.\n\rIdentificador =  " + SQLServer.Instancia + "\n\r\n\r", excepcionConexion);
            }

            return servidorEncontrado;
        }
        #endregion
    }
}
