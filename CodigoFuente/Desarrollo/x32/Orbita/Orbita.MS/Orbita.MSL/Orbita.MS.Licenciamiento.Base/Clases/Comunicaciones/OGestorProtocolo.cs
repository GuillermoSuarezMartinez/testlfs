using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Orbita.MS.Sistema;
using System.Reflection;

namespace Orbita.MS
{
    /// <summary>
    /// Gestor de protocolo de comunicaciones
    /// </summary>
    public class OGestorProtocolo
    {
        #region Atributos
        #endregion Atributos

        #region Propiedades
        #endregion Propiedades

        #region Constructor
        #endregion Constructor

        #region Métodos privados
        #region Inicio comunicación
        /*
        Nombre	ClienteSolicitaCanal		
        Operación	CanalInicio		
        Parámetros:			
            string	NombreAplicacion	Nombre del binario de la aplicación	
            string	VersionAplicacion	Versión de la aplicación
            string  NombreEquipo        Nombre del equipo que ejecuta la aplicación
            string	CodeName	Identificador proporcionado por el cliente para identificar la conexión	
            string	VersionComunicacion (=1.0)	Versión del protocolo (por defecto 1.0)	
        Respuestas:			
            Error	MensajeError	Se ha producido un error	{int IDError, string Descripcion}
            ACK	MensajeACK	Comunicación correcta: datos de conexión de nuevo canal.	{string ip, string puerto, string idcomunicacion, string codename}
            NACK	MensajeNACK	El servidor ha rechazado la conexión.	

         */
        /// <summary>
        /// Estructura solicitud de nuevo canal cliente.
        /// </summary>
        public struct C_Datos_ClienteSolicitaCanal
        {
            public string NombreAplicacion;
            public string NombreEquipo;
            public string VersionAplicacion;
            public string CodeName;
            public string VersionComunicacion;
        }

        /// <summary>
        /// Estructura mensaje ACK
        /// </summary>
        public struct S_ACK_ClienteSolicitaCanal
        {
            public string NombreServidor;
            public string IP;
            public int Puerto;
            public string CodeName;
            public string IdComunicacion;
            public string VersionComunicacion;
        }

        /// <summary>
        /// Estructura mensaje NACK
        /// </summary>
        public struct S_NACK_ClienteSolicitaCanal
        {
            public string Datos;
            public string CodeName;
            public string VersionComunicacion;
        }

        /// <summary>
        /// Estructura mensaje error de cliente
        /// </summary>
        public struct C_Error
        {
            public int IdError;
            public string CodError;
            public string Descripcion;
            public string Datos;
        }

        /// <summary>
        /// Estructura mensaje error de servidor
        /// </summary>
        public struct S_Error
        {
            public int IdError;
            public string CodError;
            public string Descripcion;
            public string Datos;
            public string CodeName;
        }
        /// <summary>
        /// Petición del cliente al servidor de un nuevo canal seguro de comunicación.
        /// </summary>
        /// <param name="codeName"></param>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string C_S_SolicitaCanal(string codeName = "ORBITADEV-001", Assembly binario = null)
        {
            string res = "";
            if(binario == null)
            {
                binario = Assembly.GetCallingAssembly();
            }
            //Generamos estructura de datos
            C_Datos_ClienteSolicitaCanal datos = new C_Datos_ClienteSolicitaCanal();
            datos.NombreAplicacion = binario.GetName().Name;
            datos.VersionAplicacion = binario.GetName().Version.ToString();
            datos.NombreEquipo = Environment.MachineName;
            datos.CodeName = codeName;
            datos.VersionComunicacion = "1.1";
            //Componemos el mensaje
            OObjetoXMLMensaje objeto = new OObjetoXMLMensaje(datos);
            Orbita.MS.Comunicaciones.OMensajeXMLOperacion operacion = Orbita.MS.Comunicaciones.OMensajeXMLOperacion.CanalInicio;
            List<OObjetoXMLMensaje> parametros = new List<OObjetoXMLMensaje>() {new OObjetoXMLMensaje(datos)};
            //Encapsulamos, serializamos y ciframos.
            OMensajeXML mensaje = new OMensajeXML(operacion, parametros);
            res = mensaje.ObtenerMensajeCifrado();
            return res;

        }
        
        /// <summary>
        /// Envía confirmación con los datos de conexión
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="puerto"></param>
        /// <param name="codeName"></param>
        /// <param name="idComunicacion"></param>
        /// <returns></returns>
        public static string S_ACK_SolicitaCanal(string ip, int puerto, string codeName, string idComunicacion)
        {
            string res = "";
            S_ACK_ClienteSolicitaCanal datos = new S_ACK_ClienteSolicitaCanal();
            datos.CodeName = codeName;
            datos.IdComunicacion = idComunicacion;
            datos.IP = ip;
            datos.NombreServidor = Environment.MachineName;
            datos.Puerto = puerto;
            datos.VersionComunicacion = "1.1";

            Orbita.MS.Comunicaciones.OMensajeXMLOperacion operacion = Orbita.MS.Comunicaciones.OMensajeXMLOperacion.CanalInicio;
            List<OObjetoXMLMensaje> parametros = new List<OObjetoXMLMensaje>() { new OObjetoXMLMensaje(datos) };

            OMensajeXML mensaje = new OMensajeXML(operacion, parametros, Comunicaciones.OMensajeXMLTipoMensaje.ACK);
            res = mensaje.ObtenerMensajeCifrado();
            return res;
        }

        public static string S_NACK_SolicitaCanal(string sdatos, string codeName)
        {
            string res = "";
            S_NACK_ClienteSolicitaCanal datos = new S_NACK_ClienteSolicitaCanal();
            datos.CodeName = codeName;
            datos.Datos = sdatos;
            datos.VersionComunicacion = "1.1";

            Orbita.MS.Comunicaciones.OMensajeXMLOperacion operacion = Orbita.MS.Comunicaciones.OMensajeXMLOperacion.CanalInicio;
            List<OObjetoXMLMensaje> parametros = new List<OObjetoXMLMensaje>() { new OObjetoXMLMensaje(datos) };

            OMensajeXML mensaje = new OMensajeXML(operacion, parametros,Comunicaciones.OMensajeXMLTipoMensaje.NACK);
            res = mensaje.ObtenerMensajeCifrado();
            return res;
        }

        public static string S_NotificarError(string idError, string codError, string descripcion, string sdatos, string codeName = "")
        {
            string res = "";
            S_Error datos = new S_Error();
            datos.CodError = codError;
            datos.Datos = sdatos;
            datos.Descripcion = descripcion;
            datos.CodeName = codeName;

            Orbita.MS.Comunicaciones.OMensajeXMLOperacion operacion = Orbita.MS.Comunicaciones.OMensajeXMLOperacion.Error;
            List<OObjetoXMLMensaje> parametros = new List<OObjetoXMLMensaje>() { new OObjetoXMLMensaje(datos) };

            OMensajeXML mensaje = new OMensajeXML(operacion, parametros,Comunicaciones.OMensajeXMLTipoMensaje.Notificacion);
            res = mensaje.ObtenerMensajeCifrado();
            return res;
        }
        public static string C_NotificarError(string idError, string codError, string descripcion, string sdatos, string codeName = "")
        {
            string res = "";
            C_Error datos = new C_Error();
            datos.CodError = codError;
            datos.Datos = sdatos;
            datos.Descripcion = descripcion;

            Orbita.MS.Comunicaciones.OMensajeXMLOperacion operacion = Orbita.MS.Comunicaciones.OMensajeXMLOperacion.Error;
            List<OObjetoXMLMensaje> parametros = new List<OObjetoXMLMensaje>() { new OObjetoXMLMensaje(datos) };

            OMensajeXML mensaje = new OMensajeXML(operacion, parametros,Comunicaciones.OMensajeXMLTipoMensaje.Notificacion);
            res = mensaje.ObtenerMensajeCifrado();
            return res;
        }
        
        #endregion Inicio comunicación

        

        public static string C_S_RegistrarInicio(OProcesoAplicacion instancia)
        {
            OObjetoXMLMensaje objeto = new OObjetoXMLMensaje(instancia);
            string ser = objeto.ObjetoXML;
            OMensajeXML mensaje = new OMensajeXML(Orbita.MS.Comunicaciones.OMensajeXMLOperacion.RegistrarInicio, new List<OObjetoXMLMensaje>() { objeto });
            string mensajeTrans = mensaje.ObtenerMensajeCifrado();
            return mensajeTrans;
        }
        public static string C_S_RegistrarSalida(OProcesoAplicacion instancia, OSalidaProceso salida)
        {
            OObjetoXMLMensaje objeto = new OObjetoXMLMensaje(instancia);
            OMensajeXML mensaje = new OMensajeXML(Orbita.MS.Comunicaciones.OMensajeXMLOperacion.RegistrarSalida, new List<OObjetoXMLMensaje>() { objeto, new OObjetoXMLMensaje(salida) });
            string mensajeTrans = mensaje.ObtenerMensajeCifrado();
            return mensajeTrans;
        }
        public static string S_C_DesconexionForzada(OSalidaProceso salida, string msgArgs)
        {
            OObjetoXMLMensaje objeto = new OObjetoXMLMensaje(salida);
            OMensajeXML mensaje = new OMensajeXML(Orbita.MS.Comunicaciones.OMensajeXMLOperacion.RegistrarSalida, new List<OObjetoXMLMensaje>() { objeto, new OObjetoXMLMensaje(msgArgs) });
            string mensajeTrans = mensaje.ObtenerMensajeCifrado();
            return mensajeTrans;
        }
        public static string SetCanalInicio(string IdCanal, string men, string ip, int puerto, string msgArgs)
        {
            OObjetoXMLMensaje objeto = new OObjetoXMLMensaje(IdCanal);
            OMensajeXML mensaje = new OMensajeXML(Orbita.MS.Comunicaciones.OMensajeXMLOperacion.CanalInicio, new List<OObjetoXMLMensaje>() { objeto, new OObjetoXMLMensaje(men), new OObjetoXMLMensaje(ip), new OObjetoXMLMensaje(puerto),new OObjetoXMLMensaje(msgArgs) });
            string mensajeTrans = mensaje.ObtenerMensajeCifrado();
            return mensajeTrans;
        }
        public static string SetMensajeClienteServidor(OProcesoAplicacion instancia, string men)
        {
            OObjetoXMLMensaje objeto = new OObjetoXMLMensaje(instancia);
            OMensajeXML mensaje = new OMensajeXML(Orbita.MS.Comunicaciones.OMensajeXMLOperacion.RegistrarSalida, new List<OObjetoXMLMensaje>() { objeto, new OObjetoXMLMensaje(men) });
            string mensajeTrans = mensaje.ObtenerMensajeCifrado();
            return mensajeTrans;
        }
        public static string SetConsultaLicencias(OProcesoAplicacion instancia, List<string> valores)
        {
            OObjetoXMLMensaje objeto = new OObjetoXMLMensaje(instancia);
            OMensajeXML mensaje = new OMensajeXML(Orbita.MS.Comunicaciones.OMensajeXMLOperacion.RegistrarSalida, new List<OObjetoXMLMensaje>() { objeto, new OObjetoXMLMensaje(valores) });
            string mensajeTrans = mensaje.ObtenerMensajeCifrado();
            return mensajeTrans;
        }
        public static OProcesoAplicacion GetRegistrarInicioAplicacion(OMensajeXML mensaje)
        {
            try
            {
                if (mensaje.Atributos.Count > 0)
                {
                    string xmlAplicacion = mensaje.Atributos[0];
                    ArrayList atributoFinal = OMensajeXML.DescifrarAtributoMensajeXML(xmlAplicacion, new List<Type>() { typeof(OProcesoAplicacion), typeof(OAplicacion) });
                    return atributoFinal[0] as OProcesoAplicacion;
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1);
                throw new Exception("Mensaje no procesable.", e1);
                
            }
            throw new Exception("Formato inesperado en el mensaje.");
        }
        #endregion Métodos privados

        #region Métodos públicos
        #endregion Métodos públicos



    }
}
