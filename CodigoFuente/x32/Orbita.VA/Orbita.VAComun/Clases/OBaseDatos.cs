//***********************************************************************
// Assembly         : Orbita.VAComun
// Author           : aiba�ez
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

namespace Orbita.VAComun
{
    /// <summary>
    /// Clase est�tica que configura el acceso a la bases de datos de SQL Server de parametrizaci�n.
    /// Utiliza BaseDatosRuntime especificando como origen la base datos de parametrizaci�n
    /// </summary>
    public static class OBaseDatosParam
    {
        #region Propiedad(es)
        /// <summary>
        ///  Acceso a la base de datos SQL Server
        /// </summary>
        public static OSqlServer SQLServer
        {
            get
            {
                return OBaseDatosManager.SQLServer(OrigenBaseDatos.Parametrizacion);
            }
        }
        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Extrae la informaci�n de conexi�n con la base de datos y comprueba que existe comunicaci�n
        /// </summary>
        public static void Conectar()
        {
            OBaseDatosManager.NuevaBaseDatos(OrigenBaseDatos.Parametrizacion);
        }

        /// <summary>
        /// Obtiene la cadena de conexi�n a la base de datos
        /// </summary>
        public static string ObtenerConnectionString()
        {
            return OBaseDatosManager.ObtenerConnectionString(OrigenBaseDatos.Parametrizacion);
        }
        #endregion
    }

    /// <summary>
    /// Clase est�tica que configura el acceso a la bases de datos de SQL Server de almacenamiento.
    /// Utiliza BaseDatosRuntime especificando como origen la base datos de parametrizaci�n
    /// </summary>
    public static class OBaseDatosAlmacen
    {
        #region Propiedad(es)
        /// <summary>
        ///  Acceso a la base de datos SQL Server
        /// </summary>
        public static OSqlServer SQLServer
        {
            get
            {
                return OBaseDatosManager.SQLServer(OrigenBaseDatos.Almacen);
            }
        }
        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Extrae la informaci�n de conexi�n con la base de datos y comprueba que existe comunicaci�n
        /// </summary>
        public static void Conectar()
        {
            OBaseDatosManager.NuevaBaseDatos(OrigenBaseDatos.Almacen);
        }

        /// <summary>
        /// Obtiene la cadena de conexi�n a la base de datos
        /// </summary>
        public static string ObtenerConnectionString()
        {
            return OBaseDatosManager.ObtenerConnectionString(OrigenBaseDatos.Almacen);
        }
        #endregion
    }

    /// <summary>
    /// Clase est�tica que configura el acceso a todas las bases de datos de SQL Server.
    /// Contiene una lista con todas las bases de datos del sitema
    /// </summary>
    public static class OBaseDatosManager
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de las bases de datos existentes en el sistema
        /// </summary>
        public static List<OBaseDatos> ListaBaseDatos;
        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Constructor de los campos de la clase
        /// </summary>
        public static void Constructor()
        {
            ListaBaseDatos = new List<OBaseDatos>();
        }

        /// <summary>
        /// Destruye los campos de la clase
        /// </summary>
        public static void Destructor()
        {
            ListaBaseDatos = null;
        }

        /// <summary>
        /// Inicializa las variables necesarias para el funcionamiento de los cron�metros
        /// </summary>
        public static void Inicializar()
        {
        }

        /// <summary>
        /// Finaliza la ejecuci�n
        /// </summary>
        public static void Finalizar()
        {
        }

        /// <summary>
        /// Extrae la informaci�n de conexi�n con la base de datos y comprueba que existe comunicaci�n
        /// </summary>
        public static void NuevaBaseDatos(OEnumOrigenBaseDatos enumOrigenBaseDatos)
        {
            OBaseDatos baseDatos = new OBaseDatos(enumOrigenBaseDatos);
            baseDatos.CompruebaAccesoBasesDatos();

            ListaBaseDatos.Add(baseDatos);
        }

        /// <summary>
        ///  Acceso a la base de datos SQL Server
        /// </summary>
        public static OSqlServer SQLServer(OEnumOrigenBaseDatos origenBaseDatos)
        {
            OBaseDatos baseDatos = ListaBaseDatos.Find(delegate(OBaseDatos bd) { return bd.Origen == origenBaseDatos; });
            if (baseDatos != null)
            {
                return baseDatos.SQLServer;
            }

            return null;
        }

        /// <summary>
        /// Obtiene la cadena de conexi�n a la base de datos
        /// </summary>
        public static string ObtenerConnectionString(OEnumOrigenBaseDatos origenBaseDatos)
        {
            OBaseDatos basedatos = ListaBaseDatos.Find(delegate(OBaseDatos bd) { return bd.Origen == origenBaseDatos; });
            return basedatos.ObtenerConnectionString();
        }
        #endregion
    }

    /// <summary>
    /// Clase que configura el acceso a las bases de datos de SQL Server y Access
    /// </summary>
    public class OBaseDatos
    {
        #region Atributo(s)
        /// <summary>
        /// Origen de la base de datos
        /// </summary>
        public OEnumOrigenBaseDatos Origen;

        /// <summary>
        /// Informaci�n de la configuraci�n de la base de datos
        /// </summary>
        internal InformacionBasesDatos InformacionBasesDatos;
        #endregion

        #region Propiedad(es)
        /// <summary>
        ///  Acceso a la base de datos SQL Server
        /// </summary>
        public OSqlServer SQLServer
        {
            get
            {
                OInfoConexion info = this.CrearInformacionSQL();
                return new OSqlServer(info);
            }
        }
        #endregion Propiedades

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="origen"></param>
        public OBaseDatos(OEnumOrigenBaseDatos origen)
        {
            this.Origen = origen;

            this.InformacionBasesDatos = OSistemaManager.Configuracion.ListaInformacionBasesDatos.Find(delegate(InformacionBasesDatos info) { return info.Origen.Equals(origen.Nombre); });
        }
        #endregion

        #region M�todo(s) privado(s)
        /// <summary>
        /// Crea la informaci�n de conexi�n a una base de datos SQL Server
        /// </summary>
        /// <param name="baseDatos">Base de datos SQL Server a la que se desa conectar</param>
        /// <returns>Un objeto InfoConexionSQLServer con la informaci�n necesaria para conectarse a la base de datos SQL Server</returns>
        private OInfoConexion CrearInformacionSQL()
        {
            OInfoConexion infoConexion = new OInfoConexion();
            infoConexion.Instancia = this.InformacionBasesDatos.Instancia;
            infoConexion.BaseDatos = this.InformacionBasesDatos.BaseDatos;
            infoConexion.Usuario = this.InformacionBasesDatos.Usuario;
            infoConexion.Password = this.InformacionBasesDatos.Password;
            return infoConexion;
        }
        #endregion M�todos privados est�ticos

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Comprueba el acceso a la base de datos
        /// </summary>
        public Boolean CompruebaAccesoBasesDatos()
        {
            bool servidorEncontrado = false;
            DateTime momentoTimeOut = DateTime.Now.AddMinutes(1);
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

            // Se lanza la excepci�n
            if (!servidorEncontrado)
            {
                throw new Exception("Ha sido imposible realizar la conexi�n con la base de datos.\n\rCadena de conexi�n =  " + ObtenerConnectionString() + "\n\r\n\r", excepcionConexion);
            }

            return servidorEncontrado;
        }

        /// <summary>
        /// Obtiene la cadena de conexi�n a la base de datos
        /// </summary>
        public string ObtenerConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.Add("Data Source", this.InformacionBasesDatos.Instancia);
            builder.Add("Initial Catalog", this.InformacionBasesDatos.BaseDatos);
            builder.Add("Persist Security Info", "True");
            builder.Add("User ID", this.InformacionBasesDatos.Usuario);
            builder.Add("Password", this.InformacionBasesDatos.Password);
            return builder.ConnectionString;
        }
        #endregion M�todos p�blicos
    }

    /// <summary>
    /// Clase que contiene toda la informaci�n necesaria para establecer las conexiones a las bases de datos.
    /// Esta clase es recuperada del archivo XML de configuraci�n de la aplicaci�n
    /// </summary>
    [Serializable]
    public class InformacionBasesDatos
    {
        #region Propiedad(es)

        /// <summary>
        /// Nombre identificador de la base de datos
        /// </summary>
        public string Origen = string.Empty;
        /// <summary>
        /// Nombre de la m�quina donde se encuentra la base de datos SQL Server
        /// </summary>
        public string Instancia = string.Empty;
        /// <summary>
        /// Nombre de la base de datos SQL Server
        /// </summary>
        public string BaseDatos = string.Empty;
        /// <summary>
        /// Nombre de usuario de la base de datos SQL Server
        /// </summary>
        public string Usuario = string.Empty;
        /// <summary>
        /// Contrase�a de usuario de la base de datos SQL Server
        /// </summary>
        public string Password = string.Empty;

        #endregion Campos
    }

    /// <summary>
    /// Define el origen de la base de datos
    /// </summary>
    internal class OrigenBaseDatos
    {
        #region Atributo(s)
        /// <summary>
        /// Base de datos de parametrizaci�n del sistema. 
        /// En esta BBDD est� definida toda la informaci�n necesaria para la ejecuci�n del sistema.
        /// Se trata de una base de datos de acceso normal a lectura.
        /// El tama�o de esta base de datos es bajo y su velocidad de acceso alta.
        /// El mantenimiento de esta BBDD se basa en realizar copias de seguridad.
        /// </summary>
        public static OEnumOrigenBaseDatos Parametrizacion = new OEnumOrigenBaseDatos("Parametrizaci�n", "Base de datos de parametrizaci�n", 1);
        /// <summary>
        /// Base de datos de almacenamiento del hist�rico de inspecciones. 
        /// En esta BBDD est� definida toda la informaci�n que genera la ejecuci�n del sistema.
        /// Se trata de una base de datos de acceso normal a escritura.
        /// El tama�o de esta base de datos es alto y su velocidad de acceso baja.
        /// El mantenimiento de esta BBDD se basa en elimnar registros antiguos.
        /// </summary>
        public static OEnumOrigenBaseDatos Almacen = new OEnumOrigenBaseDatos("Almacen", "Base de datos de almacenamietno", 2);
        #endregion    
    }

    /// <summary>
    /// Clase que implementa el enumerado del origen de la base de datos
    /// </summary>
    public class OEnumOrigenBaseDatos : OEnumeradoHeredable
    {        
        #region Constructor
        /// <summary>
        /// Constuctor de la clase
        /// </summary>
        public OEnumOrigenBaseDatos(string nombre, string descripcion, int valor): 
            base(nombre, descripcion, valor)
        {}
        #endregion
    }
}
