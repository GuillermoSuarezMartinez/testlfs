//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : sizquierdo/aibañez
// Created          : 26-03-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//                    
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Gestiona las operaciones en regiones de memoria mapeadas con buffer múltiple.
    /// </summary>
    public class OMemoriaMapeadaMultiBuffer
    {
        #region Atributos
        /// <summary>
        /// Objetos de control para los buffer de regiones
        /// </summary>
        private Dictionary<string, OInfoBufferMemoriaMapeada> InfoBuffers;
        /// <summary>
        /// Memoria mapeada
        /// </summary>
        private OMemoriaMapeada MemoriaMapeada;
        #endregion Atributos

        #region Constructores
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OMemoriaMapeadaMultiBuffer(bool liberarAlFinalizar = false)
        {
            this.InfoBuffers = new Dictionary<string, OInfoBufferMemoriaMapeada>();
            this.MemoriaMapeada = new OMemoriaMapeada(liberarAlFinalizar);
        }
        #endregion Constructores

        #region Métodos públicos
        /// <summary>
        /// Declaración de la región del buffer
        /// </summary>
        /// <param name="infoBuffer"></param>
        /// <returns></returns>
        public bool InicializarEscritura(OInfoBufferMemoriaMapeada infoBuffer)
        {
            try
            {
                this.InfoBuffers.Add(infoBuffer.CodigoRegion, infoBuffer);
                for (int contBuffer = 0; contBuffer < infoBuffer.NumeroBuffers; contBuffer++)
                {
                    string nombreBuffer = infoBuffer.GetCodigoBuffer(contBuffer);
                    this.MemoriaMapeada.CrearEscritura(nombreBuffer, infoBuffer.TamañoRegion);
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.RegionMemoriaMapeada.Error(exception, "InicializarEscritura");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Declaración de la región del buffer
        /// </summary>
        /// <param name="infoBuffer"></param>
        /// <returns></returns>
        public bool InicializarLectura(OInfoBufferMemoriaMapeada infoBuffer)
        {
            try
            {
                this.InfoBuffers.Add(infoBuffer.CodigoRegion, infoBuffer);
                for (int contBuffer = 0; contBuffer < infoBuffer.NumeroBuffers; contBuffer++)
                {
                    string nombreBuffer = infoBuffer.GetCodigoBuffer(contBuffer);
                    this.MemoriaMapeada.CrearLectura(nombreBuffer);
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.RegionMemoriaMapeada.Error(exception, "InicializarLectura");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Lectura de determinada región del buffer
        /// </summary>
        /// <param name="codigoBuffer"></param>
        /// <returns></returns>
        public bool Leer(string codigoBuffer, out byte[] datos)
        {
            bool resultado = false;
            datos = new byte[1];

            try
            {
                resultado = this.MemoriaMapeada.Leer(codigoBuffer, out datos);
            }
            catch (Exception exception)
            {
                OLogsVAComun.RegionMemoriaMapeada.Error(exception, "Leer");
                datos = null;
            }

            return resultado;
        }
        /// <summary>
        /// Lectura de determinada región del buffer
        /// </summary>
        /// <param name="codigoBuffer"></param>
        /// <returns></returns>
        public bool Leer(string codigoRegion, int numBuffer, out byte[] datos)
        {
            string codigoBuffer = OInfoBufferMemoriaMapeada.GetCodigoBuffer(codigoRegion, numBuffer);
            return this.Leer(codigoBuffer, out datos);
        }
        /// <summary>
        /// Escritura de determinada región del buffer
        /// </summary>
        /// <param name="codigoRegion"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public string Escribir(string codigoRegion, byte[] datos)
        {
            if (!InfoBuffers.ContainsKey(codigoRegion))
            {
                throw new KeyNotFoundException("No existe el identificador de región indicado: " + codigoRegion);
            }

            string codigoBuffer = this.InfoBuffers[codigoRegion].SiguienteIdentificador;
            try
            {
                this.MemoriaMapeada.Escribir(codigoBuffer, datos);
            }
            catch (Exception exception)
            {
                OLogsVAComun.RegionMemoriaMapeada.Error(exception, "Escribir");
                return null;
            }

            return codigoBuffer;
        }
        /// <summary>
        /// Escritura de determinada región del buffer
        /// </summary>
        /// <param name="codigoRegion"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public string Escribir(string codigoRegion, int numBuffer, byte[] datos)
        {
            if (!InfoBuffers.ContainsKey(codigoRegion))
            {
                throw new KeyNotFoundException("No existe el identificador de región indicado: " + codigoRegion);
            }

            string codigoBuffer = this.InfoBuffers[codigoRegion].GetCodigoBuffer(numBuffer);

            try
            {
                this.MemoriaMapeada.Escribir(codigoBuffer, datos);
            }
            catch (Exception exception)
            {
                OLogsVAComun.RegionMemoriaMapeada.Error(exception, "Escribir");
                return null;
            }

            return codigoBuffer;
        }
        #endregion Métodos públicos
    }

    /// <summary>
    /// Objeto de control que contiene la información de una región de buffer
    /// </summary>
    public class OInfoBufferMemoriaMapeada
    {
        #region Atributo(s)
        /// <summary>
        /// Región usada
        /// </summary>
        private int _subRegionActual = -1;
        /// <summary>
        /// Objeto de bloqueo
        /// </summary>
        private object LockSiguiente = new object();
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Identificador de la región
        /// </summary>
        protected string _CodigoRegion = "ID";
        /// <summary>
        /// Identificador de la región
        /// </summary>
        public string CodigoRegion
        {
            get { return _CodigoRegion; }
            set { _CodigoRegion = value; }
        }

        /// <summary>
        /// Capacidad del buffer de la región 0 ... n con n=10
        /// </summary>
        protected int _NumeroBuffers = 10;
        /// <summary>
        /// Capacidad del buffer de la región 0 ... n con n=10
        /// </summary>
        public int NumeroBuffers
        {
            get { return _NumeroBuffers; }
            set { _NumeroBuffers = value; }
        }

        /// <summary>
        /// Capacidad de la región, -1 para valores predefinidos
        /// </summary>
        protected long _TamañoRegion = -1;
        /// <summary>
        /// Capacidad de la región, -1 para valores predefinidos
        /// </summary>
        public long TamañoRegion
        {
            get { return _TamañoRegion; }
            set { _TamañoRegion = value; }
        }

        /// <summary>
        /// Obtiene el identificador de la subRegión del buffer en curso
        /// </summary>
        public string IdentificadorActual
        {
            get
            {
                lock (LockSiguiente)
                {
                    return _CodigoRegion + _subRegionActual;
                }
            }
        }

        /// <summary>
        /// Itera en el buffer y devuelve el nuevo identificador en curso
        /// </summary>
        public string SiguienteIdentificador
        {
            get
            {
                lock (LockSiguiente)
                {
                    if (this._subRegionActual < NumeroBuffers - 1)
                    {
                        _subRegionActual++;

                    }
                    else
                    {
                        _subRegionActual = 0;
                    }
                    //OLogsVAComun.RegionMemoriaMapeada.Debug("Identificador del buffer de región de memoria actual actual: " + IdentificadorActual);
                    return IdentificadorActual;
                }
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codigoRegion"></param>
        /// <param name="numeroBuffers"></param>
        /// <param name="preInicializado"></param>
        public OInfoBufferMemoriaMapeada(string codigoRegion, int numeroBuffers = 10, long tamañoRegion = 10000)
        {
            this._CodigoRegion = codigoRegion;
            this._NumeroBuffers = numeroBuffers;
            this._TamañoRegion = tamañoRegion;
        }
        #endregion Constructor

        #region Método(s) estático(s)
        /// <summary>
        /// Obtiene el código del buffer
        /// </summary>
        /// <param name="numBuffer"></param>
        /// <returns></returns>
        public static string GetCodigoBuffer(string codigoRegion, int numBuffer)
        {
            return codigoRegion + numBuffer;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Obtiene el código del buffer
        /// </summary>
        /// <param name="numBuffer"></param>
        /// <returns></returns>
        public string GetCodigoBuffer(int numBuffer)
        {
            return GetCodigoBuffer(this.CodigoRegion, numBuffer);
        }
        #endregion
    }
}
