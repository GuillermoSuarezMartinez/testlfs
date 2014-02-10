//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.Collections.Generic;
using System.Data;
using Orbita.VA.Comun;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Clase estática para el acceso al hardware
    /// </summary>
    public static class OHardwareManager
    {
        #region Atributo(s)
        /// <summary>
        /// Indica que se ha iniciado el manejador en modo servidor / cliente
        /// </summary>
        public static bool CargarIO = true;

        /// <summary>
        /// Indica que se ha iniciado el manejador en modo servidor / cliente
        /// </summary>
        public static bool CargarCams = true;
        
        /// <summary>
        /// Indica que se ha iniciado el manejador en modo servidor / cliente
        /// </summary>
        public static bool Servidor = false;

        /// <summary>
        /// Lista de las cámaras del sistema
        /// </summary>
        public static Dictionary<string, IHardware> ListaHardware;

        /// <summary>
        /// Lista de todas las escenarios de hardware del sistema
        /// </summary>
        public static Dictionary<string, OEscenarioHardware> Escenarios;
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Construye los campos de la clase
        /// </summary>
        public static void Constructor(bool cargarIO = true, bool cargarCams = true, bool servidor = false)
        {
            // Inicialización de variables
            CargarIO = cargarIO;
            CargarCams = cargarCams;
            Servidor = servidor;
            ListaHardware = new Dictionary<string, IHardware>();

            // Constructor del hardware
            if (CargarIO)
            {
                OIOManager.Constructor();
            }

            if (CargarCams)
            {
                OCamaraManager.Constructor();
            }

            // Consulta de todas las escenarios existentes en el sistema
            if (OSistemaManager.IntegraMaquinaEstados)
            {
                Escenarios = new Dictionary<string, OEscenarioHardware>();

                DataTable dtEscenario = Orbita.VA.Comun.AppBD.GetEscenarios();
                if (dtEscenario.Rows.Count > 0)
                {
                    // Cargamos todas las escenarios existentes en el sistema
                    OEscenarioHardware escenario;
                    foreach (DataRow drEscenario in dtEscenario.Rows)
                    {
                        // Creamos cada una de las escenarios del sistema
                        string codEscenario = drEscenario["CodEscenario"].ToString();
                        escenario = new OEscenarioHardware(codEscenario);
                        Escenarios.Add(codEscenario, escenario);
                    }
                }
            }
        }

        /// <summary>
        /// Destruye los campos de la clase
        /// </summary>
        public static void Destructor()
        {
            if (CargarCams)
            {
                OCamaraManager.Destructor();
            } 
            
            if (CargarIO)
            {
                OIOManager.Destructor();
            }

            ListaHardware = null;
        }

        /// <summary>
        /// Inicializa las propieades de la clase
        /// </summary>
        public static void Inicializar()
        {
            if (CargarIO)
            {
                OIOManager.Inicializar();
                foreach (IHardware hardware in OIOManager.ListaTarjetasIO)
                {
                    ListaHardware.Add(hardware.Codigo, hardware);
                }
            }

            if (CargarCams)
            {
                OCamaraManager.Inicializar();
                foreach (IHardware hardware in OCamaraManager.ListaCamaras.Values)
                {
                    ListaHardware.Add(hardware.Codigo, hardware);
                }
            }
        }

        /// <summary>
        /// Finaliza las propiedades de la clase
        /// </summary>
        public static void Finalizar()
        {
            if (CargarCams)
            {
                OCamaraManager.Finalizar();
            }

            if (CargarIO)
            {
                OIOManager.Finalizar();
            }
        }

        /// <summary>
        /// Busca la cámara con el código indicado
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <returns>Hardware encontrado</returns>
        public static IHardware GetHardware(string codigo)
        {
            return GetHardware(string.Empty, codigo);
        }

        /// <summary>
        /// Busca la cámara con el código indicado
        /// </summary>
        /// <param name="escenario">Escenario utilizada</param>
        /// <param name="codigo">Código de la cámara</param>
        /// <returns>Hardware encontrado</returns>
        public static IHardware GetHardware(string escenario, string codigo)
        {
            IHardware hardware;
            if (TryGetHardware(escenario, codigo, out hardware))
            {
                return hardware;
            }
            return null;
        }

        /// <summary>
        /// Suscribe el cambio de valor de un terminal de una determinada cámara
        /// </summary>
        /// <param name="codHw">Código del hardware</param>
        /// <param name="codTerminal">Código del terminal</param>
        /// <param name="delegadoCambioValorTerminal">Delegado donde recibir llamadas a cada cambio de valor</param>
        public static void CrearSuscripcionCambioValorTerminal(string codHw, string codTerminal, CambioValorTerminalEvent delegadoCambioValorTerminal)
        {
            IHardware hw;
            if (ListaHardware.TryGetValue(codHw, out hw))
            {
                hw.CrearSuscripcionCambioValorTerminal(codTerminal, delegadoCambioValorTerminal);
            }
        }
        /// <summary>
        /// Elimina el cambio de valor de un terminal de una determinada codHw
        /// </summary>
        /// <param name="codHw">Código del hardware</param>
        /// <param name="codTerminal">Código del terminal</param>
        /// <param name="delegadoCambioValorTerminal">Delegado donde recibir llamadas a cada cambio de valor</param>
        public static void EliminarSuscripcionCambioValorTerminal(string codHw, string codTerminal, CambioValorTerminalEvent delegadoCambioValorTerminal)
        {
            IHardware hw;
            if (ListaHardware.TryGetValue(codHw, out hw))
            {
                hw.EliminarSuscripcionCambioValorTerminal(codTerminal, delegadoCambioValorTerminal);
            }
        }

        /// <summary>
        /// Suscribe la recepción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public static void CrearSuscripcionMensajes(string codigo, OMessageEvent messageDelegate)
        {
            IHardware hw;
            if (ListaHardware.TryGetValue(codigo, out hw))
            {
                hw.OnMensaje += messageDelegate;
            }
        }
        /// <summary>
        /// Elimina la suscripción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public static void EliminarSuscripcionMensajes(string codigo, OMessageEvent messageDelegate)
        {
            IHardware hw;
            if (ListaHardware.TryGetValue(codigo, out hw))
            {
                hw.OnMensaje -= messageDelegate;
            }
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Método para acceder a un hardware
        /// </summary>
        /// <param name="codEscenario">Escenario</param>
        /// <param name="codAlias">Código o alias del hardware</param>
        /// <param name="hardware">Hardware devuelto</param>
        /// <returns>Devuelve la variable correspondientes</returns>
        private static bool TryGetHardware(string codEscenario, string codAlias, out IHardware hardware)
        {
            // Inicialización de resultados
            bool resultado = false;
            hardware = null;

            if (OSistemaManager.IntegraMaquinaEstados)
            {
                string alias = codAlias;

                // Cambio el alias al del escenario
                if ((codEscenario != string.Empty) && (OSistemaManager.IntegraMaquinaEstados) && (Escenarios is Dictionary<string, OEscenarioHardware>))
                {
                    // Cambio el alias
                    OEscenarioHardware escenarioHardware;
                    if (Escenarios.TryGetValue(codEscenario, out escenarioHardware))
                    {
                        string codHardware;
                        if (escenarioHardware.ListaAlias.TryGetValue(codAlias, out codHardware))
                        {
                            alias = codHardware;
                        }
                    }
                }

                if (ListaHardware is Dictionary<string, IHardware>)
                {
                    resultado = ListaHardware.TryGetValue(alias, out hardware);
                }
            }

            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Interfaz para el acceso a las caracerísticas comunes de todos los dispositivos hardware
    /// </summary>
    public interface IHardware
    {
        #region Propiedad(es)
        /// <summary>
        /// Código identificador de la cámara
        /// </summary>
        string Codigo { get; }

        /// <summary>
        /// Nombre identificativo de la cámara
        /// </summary>
        string Nombre { get; }

        /// <summary>
        /// Descripción de la cámara
        /// </summary>
        string Descripcion { get; }

        /// <summary>
        /// Habilita o deshabilita el funcionamiento
        /// </summary>
        bool Habilitado { get; }

        /// <summary>
        /// Fabricante del tipo de cámara
        /// </summary>
        string Fabricante { get; }

        /// <summary>
        /// Modelo del tipo de cámara
        /// </summary>
        string Modelo { get; }

        /// <summary>
        /// Tipo de hardware
        /// </summary>
        TipoHardware TipoHardware { get; }

        /// <summary>
        /// Lista de todos los terminales de la tarjeta de IO
        /// </summary>
        Dictionary<string, OTerminalIOBase> ListaTerminales { get; }

        /// <summary>
        /// Delegado de mensaje de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        event OMessageEvent OnMensaje;
        #endregion

        #region Método(s) público(s)

        /// <summary>
        /// Carga los valores del hardware
        /// </summary>
        void Inicializar();

        /// <summary>
        /// Finaliza el hardware
        /// </summary>
        void Finalizar();

        /// <summary>
        /// Comienza el hardware
        /// </summary>
        /// <returns></returns>
        bool Start();

        /// <summary>
        /// Para el hardware
        /// </summary>
        /// <returns></returns>
        bool Stop();

        /// <summary>
        /// Suscribe el cambio de valor de un terminal de un determinado hardware
        /// </summary>
        /// <param name="codTerminal">Código del terminal</param>
        /// <param name="delegadoCambioValorTerminal">Delegado donde recibir llamadas a cada cambio de valor</param>
        void CrearSuscripcionCambioValorTerminal(string codTerminal, CambioValorTerminalEvent delegadoCambioValorTerminal);

        /// <summary>
        /// Elimina el cambio de valor de un terminal de un determinado hardware
        /// </summary>
        /// <param name="codTerminal">Código del terminal</param>
        /// <param name="delegadoCambioValorTerminal">Delegado donde recibir llamadas a cada cambio de valor</param>
        void EliminarSuscripcionCambioValorTerminal(string codTerminal, CambioValorTerminalEvent delegadoCambioValorTerminal);
        #endregion
    }

    /// <summary>
    /// Clase que implementa las escenarios del hardware
    /// </summary>
    public class OEscenarioHardware
    {
        #region Atributo(s)
        /// <summary>
        /// Código del escenario
        /// </summary>
        public string Codigo;

        /// <summary>
        /// Lista de todos los alias del escenario
        /// </summary>
        public Dictionary<string, string> ListaAlias;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codEscenario">Código del escenario</param>
        public OEscenarioHardware(string codEscenario)
        {
            this.Codigo = codEscenario;

            this.ListaAlias = new Dictionary<string, string>();
            this.RellenarAlias(codEscenario);
        }

        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Rellena la lista de alias del escenario
        /// </summary>
        private void RellenarAlias(string codEscenario)
        {
            // Consulta de todos los alias existentes en el sistema
            DataTable dtVar = AppBD.GetAliasEscenarioHardware(codEscenario);
            if (dtVar.Rows.Count > 0)
            {
                // Cargamos todos los alias existentes en el sistema
                foreach (DataRow drVar in dtVar.Rows)
                {
                    // Creamos cada una de las variables del sistema
                    string codAlias = drVar["CodAlias"].ToString();
                    string codHardware = drVar["CodHardware"].ToString();
                    ListaAlias.Add(codAlias, codHardware);
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Tipo de hardware dispoinble
    /// </summary>
    public enum TipoHardware
    {
        /// <summary>
        /// Cámara: Dispositivo de adquisición de imágenes
        /// </summary>
        HwCamara = 1,
        /// <summary>
        /// Dispoisitivo de entradas / salidas
        /// </summary>
        HwModuloIO = 2
    }
}
