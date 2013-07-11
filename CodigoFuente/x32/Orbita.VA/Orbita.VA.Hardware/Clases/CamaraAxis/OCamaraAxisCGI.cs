//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : sfenollosa
// Created          : 31-10-2012
//
// Last Modified By : aibañez
// Last Modified On : 26-11-2012
// Description      : Herencia de Camara IP
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Threading;
using Orbita.VA.Comun;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Clase que implementa las funciones de manejo de la cámara IP
    /// </summary>
    public class OCamaraAxisCGI : OCamaraIP
    {
        #region Atributo(s)
        /// <summary>
        /// Timer de escaneo de las entradas
        /// </summary>
        private OThreadLoop ThreadScan;
        #endregion

        #region Propiedad(es) heredadas
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>       
        public OCamaraAxisCGI(string codigo)
            : base(codigo)
        {
            try
            {
                // Rellenamos los terminales dinámicamente
                this._ListaTerminales = new Dictionary<string, OTerminalIOBase>();
                DataTable dtTerminales = AppBD.GetTerminalesIO(codigo);
                if (dtTerminales.Rows.Count > 0)
                {
                    foreach (DataRow drTerminales in dtTerminales.Rows)
                    {
                        string codigoTerminalIO = drTerminales["CodTerminalIO"].ToString();
                        this._ListaTerminales.Add(codigoTerminalIO, new TerminalIOAxisBit(codigo, codigoTerminalIO, this.IP, this.TimeOutCGIMS));
                    }
                }

                // Creamos el thread de consulta de las E/S
                this.ThreadScan = new OThreadLoop(this.Codigo, this.IOTiempoScanMS, ThreadPriority.BelowNormal);
                this.ThreadScan.CrearSuscripcionRun(EventoScan, true);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Fatal(exception, this.Codigo);
                throw new Exception("Imposible iniciar la cámara " + this.Codigo);
            }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>       
        public OCamaraAxisCGI(string codigo, string url, string usuario, string contraseña)
            : base(codigo, url, usuario, contraseña)
        {
            try
            {
                // Rellenamos los terminales dinámicamente
                this._ListaTerminales = new Dictionary<string, OTerminalIOBase>();
                DataTable dtTerminales = AppBD.GetTerminalesIO(codigo);
                if (dtTerminales.Rows.Count > 0)
                {
                    foreach (DataRow drTerminales in dtTerminales.Rows)
                    {
                        string codigoTerminalIO = drTerminales["CodTerminalIO"].ToString();
                        this._ListaTerminales.Add(codigoTerminalIO, new TerminalIOAxisBit(codigo, codigoTerminalIO, this.IP, this.TimeOutCGIMS));
                    }
                }

                // Creamos el thread de consulta de las E/S
                this.ThreadScan = new OThreadLoop(this.Codigo, this.IOTiempoScanMS, ThreadPriority.BelowNormal);
                this.ThreadScan.CrearSuscripcionRun(EventoScan, true);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Fatal(exception, this.Codigo);
                throw new Exception("Imposible iniciar la cámara " + this.Codigo);
            }
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Se toma el control de la cámara
        /// </summary>
        /// <returns>Verdadero si la operación ha funcionado correctamente</returns>
        protected override bool ConectarInterno(bool reconexion)
        {
            bool resultado = base.ConectarInterno(reconexion);
            try
            {
                // Se configuran los terminales dinamicamente
                foreach (TerminalIOAxisBit terminalIO in this._ListaTerminales.Values)
                {
                    terminalIO.Inicializar(this.Conectividad);
                }

                // Ponemos en marcha el thread de escaneo
                this.ThreadScan.Start();

                resultado = true;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo, "Error al conectarse a la cámara " + this.Codigo + ": ".ToString());
            }

            return resultado;
        }

        /// <summary>
        /// Se deja el control de la cámara
        /// </summary>
        /// <returns>Verdadero si la operación ha funcionado correctamente</returns>
        protected override bool DesconectarInterno(bool errorConexion)
        {
            bool resultado = base.DesconectarInterno(errorConexion);

            try
            {
                // Paramos el thread de escaneo
                this.ThreadScan.Stop(250);

                resultado = true;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }

            return resultado;
        }

        /// <summary>
        /// Comienza una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        protected override bool StartInterno()
        {
            bool resultado = false;

            try
            {
                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    base.StartInterno();
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }

            return resultado;
        }

        /// <summary>
        /// Termina una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        protected override bool StopInterno()
        {
            bool resultado = false;

            try
            {
                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    base.StopInterno();
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza una fotografía de forma sincrona
        /// </summary>
        /// <returns></returns>
        protected override bool SnapInterno()
        {
            bool resultado = false;
            try
            {
                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    resultado = base.SnapInterno();
                }

                return resultado;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }
            return resultado;
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Evento del timer de ejecución
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void EventoScan(ref bool finalize)
        {
            finalize = false;

            try
            {
                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    // Lectura dinámica
                    foreach (TerminalIOAxisBit terminalIO in this._ListaTerminales.Values)
                    {
                        switch (terminalIO.TipoTerminalIO)
                        {
                            case OTipoTerminalIO.EntradaDigital:
                                terminalIO.LeerEntrada();
                                break;
                            case OTipoTerminalIO.SalidaDigital:
                                terminalIO.LeerSalida();
                                break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }
        }
        #endregion
    }

    #region Terminales de Entrada/Salida
    /// <summary>
    /// Terminal de tipo bit que simboliza un bit de un puerto
    /// </summary>
    internal class TerminalIOAxisBit : OTerminalIOBase
    {
        #region Constante(s)
        /// <summary>
        /// Subfijo utilizado para la lectura
        /// </summary>
        private const string SUBFIJO_LECTURA = "check=";
        /// <summary>
        /// Subfijo utilizado para la escritura
        /// </summary>
        private const string SUBFIJO_ESCRITURA = "action=";
        /// <summary>
        /// Subfijo utilizado para el acceso al CGI de entrada
        /// </summary>
        private const string CGI_ENTRADA = "input";
        /// <summary>
        /// Subfijo utilizado para el acceso al CGI de entrada
        /// </summary>
        private const string CGI_SALIDA = "output";
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Cámara perteneciente
        /// </summary>
        OConectividad Conectividad;
        /// <summary>
        /// IP de la camara
        /// </summary>
        private IPAddress IP;
        /// <summary>
        /// TimeOut de consulta con el CGI
        /// </summary>
        private int TimeOutMS;
        /// <summary>
        /// Dirección URL de la lectura de la entrada
        /// </summary>
        private string URLLecturaEntrada;
        /// <summary>
        /// Dirección URL de la escritura de la salida
        /// </summary>
        private string URLEscrituraSalida;
        /// <summary>
        /// Dirección URL de la lectura de la salida
        /// </summary>
        private string URLLecturaSalida;
        #endregion

        #region Propiedades
        /// <summary>
        /// Valor del terminal
        /// </summary>
        public new bool Valor
        {
            get
            {
                bool boolValor;
                if (this.ComprobarValor(base.Valor, out boolValor))
                {
                    return boolValor;
                }
                return false;
            }
            set
            {
                base.Valor = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public TerminalIOAxisBit(string codTarjetaIO, string codTerminalIO, IPAddress iP, int timeOutMS)
            : base(codTarjetaIO, codTerminalIO)
        {
            this.IP = iP;
            this.TimeOutMS = timeOutMS;
            this.URLLecturaEntrada = "http://" + this.IP.ToString() + "/axis-cgi/io/" + CGI_ENTRADA + ".cgi?" + SUBFIJO_LECTURA + this.Numero.ToString();
            this.URLEscrituraSalida = "http://" + this.IP.ToString() + "/axis-cgi/io/" + CGI_SALIDA + ".cgi?" + SUBFIJO_ESCRITURA + this.Numero.ToString();
            this.URLLecturaSalida = "http://" + this.IP.ToString() + "/axis-cgi/io/" + CGI_SALIDA + ".cgi?" + SUBFIJO_LECTURA + this.Numero.ToString();
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Convierte la cadena resultante de la consulta al CGI de Axis en un valor booleano
        /// </summary>
        /// <param name="strValor"></param>
        /// <returns></returns>
        private bool StringToBit(string strValor, string variable)
        {
            bool boolValor;

            if (strValor.Trim() == variable + this.Numero.ToString() + "=1")
            {
                boolValor = true;
            }
            else
            {
                boolValor = false;
            }

            return boolValor;
        }

        /// <summary>
        /// Se comprueba que el valor a escribir sea del tipo correcto
        /// </summary>
        /// <param name="valor">Valor a escribir</param>
        /// <param name="byteValor">Valor a escribir del tipo correcto</param>
        /// <returns>Devuelve verdadero si el valor a escribir es válido</returns>
        private bool ComprobarValor(object valor, out bool boolValor)
        {
            boolValor = false;

            // Se comprueba que el valor sea correcto
            bool valorOK = false;
            if (valor is bool)
            {
                boolValor = (bool)valor;
                valorOK = true;
            }
            return valorOK;
        }

        /// <summary>
        /// Realiza una lectura de una URL (entrada o salida)
        /// </summary>
        /// <param name="URL">URL a la que tiene que consultar</param>
        /// <param name="valor">Resultado de la consulta</param>
        /// <returns>Verdadero si la consulta se ha realizado con éxito</returns>
        private bool LecturaInterna(string uRL, ref bool valor, string variable, int timeOutMs)
        {
            bool ok = false;
            if (this.Habilitado)
            {
                OComunicacionCGITexto com = new OComunicacionCGITexto(uRL, string.Empty, string.Empty, this.Codigo, false, timeOutMs, HttpStatusCode.OK);
                string respuesta;
                ok = com.Ejecuta(out respuesta);
                if (ok)
                {
                    valor = this.StringToBit(respuesta, variable);
                }
                else
                {
                    OLogsVAHardware.Camaras.Info("LecturaInterna", String.Format("Error comuniacando con la URL: {0} .Trama resultado: {1}", uRL, respuesta));
                }
            }

            return ok;
        }

        /// <summary>
        /// Realiza una escritura de una URL (salida)
        /// </summary>
        /// <param name="URL">URL base a la que tiene que llamar</param>
        /// <param name="valor">Valor a establecer</param>
        /// <returns>Verdadero si la escritura se ha realizado con éxito</returns>
        private bool EscrituraInterna(string uRL, bool valor, int timeOutMs)
        {
            string url = valor ? uRL + @":/" : uRL + @":\";
            return this.EscrituraInterna(url, timeOutMs);
        }

        /// <summary>
        /// Realiza una escritura de una URL (salida)
        /// </summary>
        /// <param name="URL">URL a la que tiene que llamar</param>
        /// <returns>Verdadero si la escritura se ha realizado con éxito</returns>
        private bool EscrituraInterna(string uRL, int timeOutMs)
        {
            bool ok = false;
            if (this.Habilitado)
            {
                OComunicacionCGITexto com = new OComunicacionCGITexto(uRL, string.Empty, string.Empty, this.Codigo, false, timeOutMs, HttpStatusCode.OK);
                string respuesta;
                ok = com.Ejecuta(out respuesta);
                if (!ok)
                {
                    OLogsVAHardware.Camaras.Info("EscrituraInterna", String.Format("Error comuniacando con la URL: {0} .Trama resultado: {1}", uRL, respuesta));
                }
            }
            return ok;
        }
        #endregion

        #region Métodos heredados
        /// <summary>
        /// Método a heredar donde se inicializan los terminales
        /// </summary>
        public new void Inicializar(OConectividad conectividad)
        {
            try
            {
                base.Inicializar();

                this.Conectividad = conectividad;

                if (this.TipoTerminalIO == OTipoTerminalIO.SalidaDigital)
                {
                    // Inicializamos la salida
                    this.EscrituraInterna(this.URLEscrituraSalida, false, this.TimeOutMS * 2); // El primer acceso suele ser más lento y vencer el timeout
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodTarjeta);
            }
        }

        /// <summary>
        /// Lectura de la entrada física
        /// </summary>
        public override void LeerEntrada()
        {
            try
            {
                if ((this.Conectividad.EstadoConexion == EstadoConexion.Conectado) && this.Habilitado)
                {
                    base.LeerEntrada();
                    bool boolValor = this.Valor;

                    if (this.Habilitado && (this.TipoTerminalIO == OTipoTerminalIO.EntradaDigital))
                    {
                        bool ok = this.LecturaInterna(this.URLLecturaEntrada, ref boolValor, CGI_ENTRADA, this.TimeOutMS);
                        if (ok && (this.Valor != boolValor))
                        {
                            this.Valor = boolValor;
                            this.LanzarCambioValor();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodTarjeta);
            }
        }

        /// <summary>
        /// Lectura de la salida física
        /// </summary>
        public override void LeerSalida()
        {
            try
            {
                if ((this.Conectividad.EstadoConexion == EstadoConexion.Conectado) && this.Habilitado)
                {
                    base.LeerSalida();
                    bool boolValor = this.Valor;

                    if (this.Habilitado && (this.TipoTerminalIO == OTipoTerminalIO.SalidaDigital))
                    {
                        bool ok = this.LecturaInterna(this.URLLecturaSalida, ref boolValor, CGI_SALIDA, this.TimeOutMS);
                        if (ok && (this.Valor != boolValor))
                        {
                            this.Valor = boolValor;
                            this.LanzarCambioValor();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodTarjeta);
            }
        }

        /// <summary>
        /// Escritura de la salida física
        /// </summary>
        public override void EscribirSalida(string codigoVariable, object valor, string remitente)
        {
            try
            {
                if ((this.Conectividad.EstadoConexion == EstadoConexion.Conectado) && this.Habilitado)
                {
                    base.EscribirSalida(codigoVariable, valor, remitente);

                    // Se comprueba que el valor a escribir sea correcto
                    bool boolValor;
                    if (this.ComprobarValor(valor, out boolValor))
                    {
                        // Si el valor es correcto se escribe la salida física
                        if (this.Habilitado && (this.TipoTerminalIO == OTipoTerminalIO.SalidaDigital))
                        {
                            bool ok = this.EscrituraInterna(this.URLEscrituraSalida, boolValor, this.TimeOutMS);
                            if (ok)
                            {
                                this.Valor = boolValor;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodTarjeta);
            }
        }
        #endregion
    }
    #endregion
}