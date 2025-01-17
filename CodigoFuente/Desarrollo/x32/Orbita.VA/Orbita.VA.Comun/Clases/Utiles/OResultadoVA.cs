﻿//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : aibañez
// Created          : 01-01-2013
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
using Orbita.Xml;
using Orbita.Utiles;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase utilizada como contenedor de los resultados de una inspección de visión artificial.
    /// Esta clase tiene la peculiaridad de que es exportable directamente a XML, por lo que es ideal para
    /// su almacenamiento en BBDD mediante su envio a un procedimiento almacenado.
    /// 
    /// Los datos que se desean convertir en XML deben programarse siguiendo el ejemplo:
    ///         private bool _OK;
    ///         public bool OK
    ///         {
    ///             get { return _OK; }
    ///             set
    ///             {
    ///                 this._OK = value;
    ///                 this.Propiedades["OK"] = value;
    ///             }
    ///         }
    /// </summary>
    [Obsolete]
    public class OResultadoVA : OConvertibleXML
    {
        #region Propiedades
        /// <summary>
        /// Resultado global
        /// </summary>
        private bool _OK;
        /// <summary>
        /// Resultado global
        /// </summary>
        public bool OK
        {
            get { return _OK; }
            set
            {
                this._OK = value;
                this.Propiedades["OK"] = value;
            }
        }

        /// <summary>
        /// Fecha de análisis
        /// </summary>
        private DateTime _Fecha;
        /// <summary>
        /// Fecha de análisis
        /// </summary>
        public DateTime Fecha
        {
            get { return _Fecha; }
            set
            {
                this._Fecha = value;
                this.Propiedades["Fecha"] = value;
            }
        }

        /// <summary>
        /// Indica si se ha podido realizar la inspección o ha habido algun error en el intento
        /// </summary>
        private bool _Inspeccionado;
        /// <summary>
        /// Indica si se ha podido realizar la inspección o ha habido algun error en el intento
        /// </summary>
        public bool Inspeccionado
        {
            get { return _Inspeccionado; }
            set
            {
                this._Inspeccionado = value;
                this.Propiedades["Inspeccionado"] = value;
            }
        }

        /// <summary>
        /// Tiempo  de procesado
        /// </summary>
        private TimeSpan _TiempoProceso;
        /// <summary>
        /// Tiempo  de procesado
        /// </summary>
        public TimeSpan TiempoProceso
        {
            get { return _TiempoProceso; }
            set
            {
                this._TiempoProceso = value;
                this.Propiedades["TiempoProceso"] = value;
            }
        }

        /// <summary>
        /// En el caso de no haberse podido realizar la inspección, se informaría en este cammpo del motivo
        /// </summary>
        private string _Excepcion;
        /// <summary>
        /// En el caso de no haberse podido realizar la inspección, se informaría en este cammpo del motivo
        /// </summary>
        public string Excepcion
        {
            get { return _Excepcion; }
            set
            {
                this._Excepcion = value;
                this.Propiedades["Excepcion"] = value;
            }
        }
        #endregion

        #region Propiedad(es) heredada(s)
        /// <summary>
        /// Desglose de detalle
        /// </summary>
        public new List<OResultadoVA> Detalles
        {
            get { return this._Detalles.Select(result => (OResultadoVA)result).ToList(); }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OResultadoVA()
            : this(false, DateTime.Now, false, string.Empty, new TimeSpan())
        {
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="ok">Resultado global</param>
        /// <param name="Fecha">Fecha de análisis</param>
        /// <param name="inspeccionado">Indica si se ha podido realizar la inspección o ha habido algun error en el intento</param>
        /// <param name="excepcion">En el caso de no haberse podido realizar la inspección, se informaría en este cammpo del motivo</param>
        /// <param name="rechazado">Debido al resultado negativo se ha prodecido a rechazar el producto/pieza</param>
        public OResultadoVA(bool ok, DateTime fecha, bool inspeccionado, string excepcion, TimeSpan tiempoProceso)
            : base()
        {
            // Se rellenan los campos
            this.OK = ok;
            this.Fecha = fecha;
            this.Inspeccionado = inspeccionado;
            this.Excepcion = excepcion;
            this.TiempoProceso = tiempoProceso;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="listaPropiedades">Lista de propiedades a añadir</param>
        public OResultadoVA(Dictionary<string, object> listaPropiedades)
            : this(false, DateTime.Now, false, string.Empty, new TimeSpan())
        {
            this.Propiedades.AddRange(listaPropiedades);

            // Se rellenan los campos
            object valor;
            if (this.Propiedades.TryGetValue("OK", out valor))
            {
                this.OK = valor.ValidarBooleano();
            }

            if (this.Propiedades.TryGetValue("Fecha", out valor))
            {
                this.Fecha = valor.ValidarFechaHora();
            }

            if (this.Propiedades.TryGetValue("Inspeccionado", out valor))
            {
                this.Inspeccionado = valor.ValidarBooleano();
            }

            if (this.Propiedades.TryGetValue("Excepcion", out valor))
            {
                this.Excepcion = valor.ValidarTexto();
            }

            if (this.Propiedades.TryGetValue("TiempoProceso", out valor))
            {
                this.TiempoProceso = valor.ValidarIntervaloTiempo();
            }
        }
        #endregion

        #region Método(s) virtual(es)
        /// <summary>
        /// Añade un subresultado
        /// </summary>
        /// <param name="resultado">Resultado global</param>
        /// <param name="Fecha">Fecha de análisis</param>
        /// <param name="inspeccionado">Indica si se ha podido realizar la inspección o ha habido algun error en el intento</param>
        /// <param name="excepcion">En el caso de no haberse podido realizar la inspección, se informaría en este cammpo del motivo</param>
        /// <param name="rechazado">Debido al resultado negativo se ha prodecido a rechazar el producto/pieza</param>
        public virtual OResultadoVA AñadirNuevoDetalle(bool resultado, DateTime fecha, bool inspeccionado, string excepcion, TimeSpan tiempoProceso)
        {
            OResultadoVA subResultado = new OResultadoVA(resultado, fecha, inspeccionado, excepcion, tiempoProceso);
            this._Detalles.Add(subResultado);

            return subResultado;
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada como contenedor de los resultados de una inspección de visión artificial.
    /// Esta clase tiene la peculiaridad de que es exportable directamente a XML, por lo que es ideal para
    /// su almacenamiento en BBDD mediante su envio a un procedimiento almacenado.
    /// 
    /// Los datos que se desean convertir en XML deben programarse siguiendo el ejemplo:
    ///            /// <summary>
    ///            /// Resultado global
    ///            /// </summary>
    ///            private bool _OK;
    ///            /// <summary>
    ///            /// Resultado global
    ///            /// </summary>
    ///            [OAtributoConversionXML(ModoGeneracionXML.XMLNormal, "OK")]
    ///            public bool OK
    ///            {
    ///                get { return _OK; }
    ///                set { _OK = value; }
    ///            }
    /// </summary>
    public class OResultadoVAEx : OConvertibleXMLEx
    {
        #region Propiedades
        /// <summary>
        /// Código de la inspección
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código de la inspección
        /// </summary>
        [OAtributoConversionXML(ModoGeneracionXML.XMLNormal, "Codigo")]
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Resultado global
        /// </summary>
        private bool _OK;
        /// <summary>
        /// Resultado global
        /// </summary>
        [OAtributoConversionXML(ModoGeneracionXML.XMLNormal, "OK")]
        public bool OK
        {
            get { return _OK; }
            set { _OK = value; }
        }

        /// <summary>
        /// Fecha de análisis
        /// </summary>
        private DateTime _Fecha;
        /// <summary>
        /// Fecha de análisis
        /// </summary>
        [OAtributoConversionXML(ModoGeneracionXML.XMLNormal, "Fecha")]
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        /// <summary>
        /// Indica si se ha podido realizar la inspección o ha habido algun error en el intento
        /// </summary>
        private bool _Inspeccionado;
        /// <summary>
        /// Indica si se ha podido realizar la inspección o ha habido algun error en el intento
        /// </summary>
        [OAtributoConversionXML(ModoGeneracionXML.XMLNormal, "Inspeccionado")]
        public bool Inspeccionado
        {
            get { return _Inspeccionado; }
            set { _Inspeccionado = value; }
        }

        /// <summary>
        /// Tiempo  de procesado
        /// </summary>
        private TimeSpan _TiempoProceso;
        /// <summary>
        /// Tiempo  de procesado
        /// </summary>
        [OAtributoConversionXML(ModoGeneracionXML.XMLNormal, "TiempoProceso")]
        public TimeSpan TiempoProceso
        {
            get { return _TiempoProceso; }
            set { _TiempoProceso = value; }
        }

        /// <summary>
        /// En el caso de no haberse podido realizar la inspección, se informaría en este cammpo del motivo
        /// </summary>
        private string _Excepcion;
        /// <summary>
        /// En el caso de no haberse podido realizar la inspección, se informaría en este cammpo del motivo
        /// </summary>
        [OAtributoConversionXML(ModoGeneracionXML.XMLNormal, "Excepcion")]
        public string Excepcion
        {
            get { return _Excepcion; }
            set { _Excepcion = value; }
        }
        #endregion

        #region Propiedad(es) heredada(s)
        /// <summary>
        /// Desglose de detalle
        /// </summary>
        [OAtributoConversionXML(Xml.ModoGeneracionXML.XMLIgnore, "Detalles")]
        public new List<OResultadoVAEx> Detalles
        {
            get { return this._Detalles.Select(result => (OResultadoVAEx)result).ToList(); }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OResultadoVAEx(string codigo, Func<string, string> formateador = null)
            : this(codigo, false, DateTime.Now, false, string.Empty, new TimeSpan(), formateador)
        {
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="ok">Resultado global</param>
        /// <param name="Fecha">Fecha de análisis</param>
        /// <param name="inspeccionado">Indica si se ha podido realizar la inspección o ha habido algun error en el intento</param>
        /// <param name="excepcion">En el caso de no haberse podido realizar la inspección, se informaría en este cammpo del motivo</param>
        /// <param name="rechazado">Debido al resultado negativo se ha prodecido a rechazar el producto/pieza</param>
        public OResultadoVAEx(string codigo, bool ok, DateTime fecha, bool inspeccionado, string excepcion, TimeSpan tiempoProceso, Func<string, string> formateador = null)
            : base(formateador)
        {
            // Se rellenan los campos
            this.Codigo = codigo;
            this.OK = ok;
            this.Fecha = fecha;
            this.Inspeccionado = inspeccionado;
            this.Excepcion = excepcion;
            this.TiempoProceso = tiempoProceso;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="listaPropiedades">Lista de propiedades a añadir</param>
        public OResultadoVAEx(string codigo, Dictionary<string, object> listaPropiedades, Func<string, string> formateador = null)
            : base(listaPropiedades, formateador)
        {
            this.Codigo = codigo;
        }
        #endregion

        #region Método(s) virtual(es)
        /// <summary>
        /// Añade un subresultado
        /// </summary>
        /// <param name="resultado">Resultado global</param>
        /// <param name="Fecha">Fecha de análisis</param>
        /// <param name="inspeccionado">Indica si se ha podido realizar la inspección o ha habido algun error en el intento</param>
        /// <param name="excepcion">En el caso de no haberse podido realizar la inspección, se informaría en este cammpo del motivo</param>
        /// <param name="rechazado">Debido al resultado negativo se ha prodecido a rechazar el producto/pieza</param>
        public virtual OResultadoVAEx AñadirNuevoDetalle(string codigo, bool resultado, DateTime fecha, bool inspeccionado, string excepcion, TimeSpan tiempoProceso, Func<string, string> formateador = null)
        {
            OResultadoVAEx subResultado = new OResultadoVAEx(codigo, resultado, fecha, inspeccionado, excepcion, tiempoProceso, formateador);
            this._Detalles.Add(subResultado);

            return subResultado;
        }
        #endregion
    }
}
