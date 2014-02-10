//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : afranco
// Created          : 05-11-2013
//
// Last Modified By : afranco
// Last Modified On : 05-11-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Orbita.Utiles;
using Orbita.VA.Comun;
using System.Runtime.InteropServices;

namespace Orbita.VA.Hardware
{
    public class OIONuvo1300 : OModuloIOBase
    {
        #region Importar de DLL nativa
        [DllImport("WDT_DIO32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool InitDIO();
        #endregion

        #region Atributo(s)

        /// <summary>
        /// PuertoA
        /// </summary>
        private OTerminalIONuvo1300Int PuertoI;

        /// <summary>
        /// PuertoB
        /// </summary>
        private OTerminalIONuvo1300Int PuertoO;

        /// <summary>
        /// Timer de escaneo de las entradas
        /// </summary>
        protected Timer TimerScan;
        #endregion

        #region Constructores

        public OIONuvo1300(string codHardware)
            : base(codHardware)
        {
            // Creamos los campos
            this.TimerScan = new Timer();
            this.TimerScan.Interval = 1;
            this.TimerScan.Enabled = false;
            this.TimerScan.Tick += new EventHandler(EventoScan);

            // Cargamos valores de la base de datos
            DataTable dtTarjetaIO = AppBD.GetTarjetaIO(this.Codigo);
            
            if (dtTarjetaIO.Rows.Count == 1)
            {
                this.CrearTerminales();
            }
        }

        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Rellenamos la lista genérica de terminales del puerto correspondiente
        /// </summary>
        /// <param name="terminalPuerto"></param>
        internal void RellenarListaTerminales(OTerminalIONuvo1300Int terminalPuerto)
        {
            this.ListaTerminales.Add(terminalPuerto.Codigo, terminalPuerto);
            foreach (OTerminalIOBase terminal in terminalPuerto.ListaTerminalesBit)
            {
                this.ListaTerminales.Add(terminal.Codigo, terminal);
            }
        }
        #endregion

        #region Método(s) virtual(es)
        /// <summary>
        /// Crea los terminales de la tarjeta
        /// </summary>
        protected virtual void CrearTerminales()
        {
            // Cargamos los terminales del puerto de entrada
            this.PuertoI = new OTerminalIONuvo1300Int(this.Codigo, "PortI", 8);
            this.RellenarListaTerminales(this.PuertoI);

            // Cargamos los terminales del puerto de salida
            this.PuertoO = new OTerminalIONuvo1300Int(this.Codigo, "PortO", 8);
            this.RellenarListaTerminales(this.PuertoO);
        }

        #endregion

        #region Método(s) heredado(s)

        /// <summary>
        /// Método a heredar donde se conecta y se configura la tarjeta de IO
        /// </summary>
        public override void Inicializar()
        {
            try
            {
                base.Inicializar();

                if (this.Habilitado)
                {
                    // Comprobamos que el módulo de E/S está disponible
                    if (InitDIO())
                    {
                        foreach (OTerminalIOBase terminal in this.ListaTerminales.Values)
                        {
                            if (terminal is OTerminalIONuvo1300Int)
                            {
                                ((OTerminalIONuvo1300Int)terminal).Inicializar();
                            }
                        }
                        this.Existe = true;

                        // Ponemos en marcha el timer de escaneo
                        this.TimerScan.Enabled = true;
                    }
                }
            }
            catch (AccessViolationException exception)
            {
                OMensajes.MostrarError("El módulo de entradas/salidas con identificador " + this.Codigo + "\n no se encuetra o está actualmente en uso.");
                OLogsVAHardware.EntradasSalidas.Info(exception, this.Codigo);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Finaliza la cámara
        /// </summary>
        public override void Finalizar()
        {
            base.Finalizar();

            this.TimerScan.Stop();
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento del timer de ejecución
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void EventoScan(object sender, EventArgs e)
        {
            this.TimerScan.Stop();
            
            try
            {
                //foreach (OTerminalIOBase terminal in this.ListaTerminales)
                foreach (OTerminalIOBase terminal in this.ListaTerminales.Values)
                {
                    if (terminal is OTerminalIONuvo1300Int)
                    {
                        ((OTerminalIONuvo1300Int)terminal).LeerEntrada();
                    }
                }
            }
            
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
            
            this.TimerScan.Start();
        }

        #endregion
    }

    /// <summary>
    /// Terminal de tipo ushort que simboliza un puerto entero
    /// </summary>
    internal class OTerminalIONuvo1300Int : OTerminalIOBase
    {
        #region Importar de DLL nativa
        [DllImport("WDT_DIO32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort DIReadPort();

        [DllImport("WDT_DIO32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DOWritePort(ushort value);
        #endregion

        #region Atributo(s)

        /// <summary>
        /// Número de bits que contiene el puerto
        /// </summary>
        public short NumBits;

        public List<OTerminalIONuvo1300Bit> ListaTerminalesBit;

        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Valor del terminal
        /// </summary>
        public new ushort Valor
        {
            get
            {
                ushort ushortValor;
                if (this.ComprobarValor(base.Valor, out ushortValor))
                {
                    return ushortValor;
                }
                return 0;
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
        public OTerminalIONuvo1300Int(string codTarjetaIO, string codTerminalIO, short numBits)
            : base(codTarjetaIO, codTerminalIO)
        {
            // Inicialiamos los valores
            this.NumBits = numBits;

            this.ListaTerminalesBit = new List<OTerminalIONuvo1300Bit>();

            // Creación de los bits asociados
            for (int i = 0; i < numBits; i++)
            {
                OTerminalIONuvo1300Bit terminalBit = new OTerminalIONuvo1300Bit(this.CodTarjeta, this.Codigo + i.ToString(), this);
                this.ListaTerminalesBit.Add(terminalBit);
            }
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Método a heredar donde se inicializan los terminales
        /// </summary>
        public new void Inicializar()
        {
            base.Inicializar();

            foreach (OTerminalIONuvo1300Bit terminalBit in this.ListaTerminalesBit)
            {
                terminalBit.Inicializar();
            }

            this.Existe = true;
        }

        /// <summary>
        /// Lectura de la entrada física
        /// </summary>
        public override void LeerEntrada()
        {
            if (this.Habilitado && this.Existe)
            {
                if (this.TipoTerminalIO == OTipoTerminalIO.EntradaDigital)
                {
                    ushort ushortValor = DIReadPort();

                    if (this.Valor != ushortValor)
                    {
                        this.Valor = ushortValor;
                        this.LanzarCambioValor();

                        // Actualizo las entradas de tipo bit asociadas
                        foreach (OTerminalIONuvo1300Bit terminalBit in this.ListaTerminalesBit)
                        {
                            terminalBit.LeerEntrada(this.Valor);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Escritura de la salida física
        /// </summary>
        public override void EscribirSalida(string codigoVariable, object valor, string remitente)
        {
            if (this.TipoTerminalIO == OTipoTerminalIO.SalidaDigital)
            {
                base.EscribirSalida(codigoVariable, valor, remitente);

                // Se comprueba que el valor a escribir sea correcto
                ushort ushortValor;
                if (this.ComprobarValor(valor, out ushortValor))
                {
                    // Si el valor es correcto se escribe la salida física
                    if (this.Habilitado && this.Existe)
                    {
                        // Se escribe la entrada propia
                        DOWritePort(ushortValor);
                    }
                    
                    this.Valor = ushortValor;

                    // Se actualizan los valores de las salidas de tipo bit asociadas
                    foreach (OTerminalIONuvo1300Bit terminalBit in this.ListaTerminalesBit)
                    {
                        terminalBit.EscribirSalida(ushortValor);
                    }
                }
            }
        }

        /// <summary>
        /// Se comprueba que el valor a escribir sea del tipo correcto
        /// </summary>
        /// <param name="valor">Valor a escribir</param>
        /// <param name="ushortValor">Valor a escribir del tipo correcto</param>
        /// <returns>Devuelve verdadero si el valor a escribir es válido</returns>
        private bool ComprobarValor(object valor, out ushort ushortValor)
        {
            ushortValor = 0;

            // Se comprueba que el valor sea correcto
            bool valorOK = false;
            if (OEntero.EsEntero(valor))
            {
                int intValor = Convert.ToInt32(valor);
                int maxvalor = (int)Math.Pow(2, this.NumBits) - 1;

                if (OEntero.EnRango(intValor, 0x00, maxvalor))
                {
                    ushortValor = (ushort)intValor;
                    valorOK = true;
                }
            }
            return valorOK;
        }

        #endregion
    }

    /// <summary>
    /// Terminal de tipo bit que simboliza un bit de un puerto
    /// </summary>
    internal class OTerminalIONuvo1300Bit : OTerminalIOBase
    {
        #region Importar de DLL nativa
        [DllImport("WDT_DIO32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool DIReadLine(byte ch);

        [DllImport("WDT_DIO32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DOWriteLine(byte ch, bool value);
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Terminal de tipo ushort al que pertenece
        /// </summary>
        private OTerminalIONuvo1300Int TerminalPerteneciente;

        #endregion

        #region Propiedad(es)
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
        public OTerminalIONuvo1300Bit(string codTarjetaIO, string codTerminalIO, OTerminalIONuvo1300Int terminalPerteneciente)
            : base(codTarjetaIO, codTerminalIO)
        {
            // Inicialiamos los valores
            this.TerminalPerteneciente = terminalPerteneciente;
        }
        #endregion

        #region Método(s) heredado(s)

        /// <summary>
        /// Método a heredar donde se inicializan los terminales
        /// </summary>
        public new void Inicializar()
        {
            base.Inicializar();
            this.Existe = true;
        }

        /// <summary>
        /// Lectura de la entrada física
        /// </summary>
        public override void LeerEntrada()
        {
            if (this.Habilitado)
            {
                bool lectura = DIReadLine((byte)this.Numero);
                this.LeerEntrada(lectura);
            }
        }

        /// <summary>
        /// Posteriormente a la lectura del entero del puerto se acutaliza el valor de la entrada del bit
        /// </summary>
        public void LeerEntrada(ushort ushortValor)
        {
            if (this.Habilitado && this.Existe)
            {
                bool boolValor = OBinario.GetBit(ushortValor, this.Numero);
                if (this.Valor != boolValor)
                {
                    this.Valor = boolValor;
                    this.LanzarCambioValor();
                }
            }
        }
        /// <summary>
        /// Posteriormente a la lectura del bit del puerto se acutaliza el valor a la variable
        /// </summary>
        public void LeerEntrada(bool boolValor)
        {
            if (this.Habilitado && this.Existe)
            {
                if (this.Valor != boolValor)
                {
                    this.Valor = boolValor;
                    this.LanzarCambioValor(); 
                }
            }
        }

        /// <summary>
        /// Escritura de la salida física
        /// </summary>
        public override void EscribirSalida(string codigoVariable, object valor, string remitente)
        {
            base.EscribirSalida(codigoVariable, valor, remitente);

            // Se comprueba que el valor a escribir sea correcto
            bool boolValor;

            if (this.ComprobarValor(valor, out boolValor))
            {
                // Si el valor es correcto se escribe la salida física
                if (this.Habilitado && this.Existe)
                {
                    ushort ushortValor = this.TerminalPerteneciente.Valor;
                    OBinario.SetBit(ref ushortValor, this.Numero, boolValor);

                    DOWriteLine((byte)this.Numero, boolValor);

                    this.TerminalPerteneciente.Valor = ushortValor;
                }

                this.Valor = boolValor;
            }
        }

        /// <summary>
        /// Escritura de la salida física
        /// </summary>
        public void EscribirSalida(ushort valor)
        {
            // Si el valor es correcto se escribe la salida física
            this.Valor = OBinario.GetBit(valor, this.Numero);
        }

        /// <summary>
        /// Se comprueba que el valor a escribir sea del tipo correcto
        /// </summary>
        /// <param name="valor">Valor a escribir</param>
        /// <param name="boolValor">Valor a escribir del tipo correcto</param>
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
        
        #endregion
    }
}
