using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS.Clases
{
    /// <summary>
    /// Clase base para la gestión de licencias de tipo HASP
    /// </summary>
    public class OLicenciaHaspBase : OLicenciaBase
    {
        #region Atributos
        /// <summary>
        /// Soporte base de la serie
        /// </summary>
        protected OLicenciaHaspSoporteSerie _soporteSerie = null;

        protected Type _tipo = typeof(OLicenciaHaspBase);
        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// Soporte base de la serie
        /// </summary>
        public OLicenciaHaspSoporteSerie SoporteSerie
        {
            get { return _soporteSerie; }
            set { _soporteSerie = value; }
        }
        #endregion Propiedades

        #region Delegados

        #endregion Delegados

        #region Eventos

        #endregion Eventos

        #region Constructores
        public OLicenciaHaspBase()
            : base()
        {
            this.TipoLicencia = OTipoLicencia.HASP;
        }
        #endregion Constructores

        #region Métodos públicos

        public override bool CompruebaProducto()
        {
            return base.CompruebaProducto();
        }
        #endregion Métodos públicos

        #region Métodos privados

        #endregion Métodos privados

    }

    /// <summary>
    /// Información sobre el soporte Serie
    /// </summary>
    public class OLicenciaHaspSoporteSerie
    {
        #region Atributos
        private string _batchCode = "INVALIDO";
        private string _vendorCode = "INVALIDO";
        private int _idVersion = 1;
        #endregion Atributos
        #region Propiedades
        public string BatchCode
        {
            get { return _batchCode; }
            set { _batchCode = value; }
        }
        public string VendorCode
        {
            get { return _vendorCode; }
            set { _vendorCode = value; }
        }
        #endregion Propiedades
        #region Constructor
        public OLicenciaHaspSoporteSerie(string batch, string vendor, int idVersion)
        {
            this._batchCode = batch;
            this._vendorCode = vendor;
            this._idVersion = idVersion;
        }
        #endregion Constructor
    }
}
