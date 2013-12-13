using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.MS.Clases;
using Orbita.MS.Clases.Trazabilidad;
using System.Xml.Serialization;
using System.Reflection;

namespace Orbita.MS
{
    /// <summary>
    /// Definición de los datos de licencimiento de una aplicación.
    /// </summary>
    [XmlRootAttribute("AplicacionLic", Namespace = "http://orbitaingenieria.es/orbita/ms", IsNullable = false)]
    public class OAplicacion
    {
        #region Atributos
        /// <summary>
        /// Nombre de la aplicación
        /// </summary>
        private string _nombreAplicacion = "AplicacionOrbita";
        /// <summary>
        /// Indica si se permite la depuración de la aplicación
        /// </summary>
        private bool _permiteDepuracion = true;
        /// <summary>
        /// Versión de estructura OAplicacion
        /// </summary>
        private string _versionEstructura = "1.1";
        /// <summary>
        /// Licencias soportadas por la aplicación, no gestionable por cliente.
        /// </summary>
        [XmlArrayAttribute("Licencias")]
        private List<OLicenciaBase> _licencias = new List<OLicenciaBase>();
        /// <summary>
        /// Tipo de soporte válido
        /// </summary>
        [XmlArrayAttribute("Soporte")]
        private List<OTipoLicencia> _soportesValidos = new List<OTipoLicencia>();
        /// <summary>
        /// Código de soportes específicos
        /// </summary>
        private List<string> _idCodSoportes = new List<string>() { };
        /// <summary>
        /// Código de productos específicos
        /// </summary>
        private List<string> _idCodProductos = new List<string>() { };
        /// <summary>
        /// Identificador de productos específicos
        /// </summary>
        private List<int> _idProductos = new List<int>() { };
        /// <summary>
        /// Identificar de características específicas.
        /// </summary>
        private List<int> _idCaracteristicas = new List<int>() { };
        /// <summary>
        /// Productos utilizados
        /// </summary>
        [XmlArrayAttribute("Productos")]
        private List<OProductos> _productos = new List<OProductos>();
        /// <summary>
        /// Características utilizadas
        /// </summary>
        [XmlArrayAttribute("Caracteristicas")]
        private List<OProductos> _caracteristicas = new List<OProductos>();

        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// Nombre de la aplicación
        /// </summary>
        public string NombreAplicacion
        {
            get { return _nombreAplicacion; }
            set { _nombreAplicacion = value; }
        }
        /// <summary>
        /// Permite Depuración
        /// </summary>
        public bool PermiteDepuracion
        {
            get { return _permiteDepuracion; }
            set { _permiteDepuracion = value; }
        }
        /// <summary>
        /// Licencias soportadas por la aplicacion
        /// </summary>
        public List<OLicenciaBase> Licencias
        {
            get { return _licencias; }
            set { _licencias = value; }
        }

        /// <summary>
        /// Código de soportes específicos
        /// </summary>
        public List<string> IdCodSoportes
        {
            get { return _idCodSoportes; }
            set { _idCodSoportes = value; }
        }
        /// <summary>
        /// Código de productos específicos
        /// </summary>
        public List<string> IdCodProductos
        {
            get { return _idCodProductos; }
            set { _idCodProductos = value; }
        }
        /// <summary>
        /// Identificador de productos específicos
        /// </summary>
        public List<int> IdProductos
        {
            get { return _idProductos; }
            set { _idProductos = value; }
        }
        /// <summary>
        /// Identificar de características específicas.
        /// </summary>
        public List<int> IdCaracteristicas
        {
            get { return _idCaracteristicas; }
            set { _idCaracteristicas = value; }
        }
        /// <summary>
        /// Productos utilizados
        /// </summary>
        protected List<OProductos> Productos
        {
            get { return _productos; }
            set { _productos = value; }
        }
        #endregion Propiedades

        #region Delegados

        #endregion Delegados

        #region Eventos

        #endregion Eventos

        #region Constructores
        /// <summary>
        /// Datos de licencimiento
        /// </summary>
        /// <param name="_permiteDepuracion"></param>
        public OAplicacion(bool _permiteDepuracion = true)
        {
           if(!_permiteDepuracion) InicializarProteccionDepuracion();
        }
        #endregion Constructores

        #region Métodos públicos
        public void AplicarLicencias()
        {
            InicializarProteccionDepuracion();
        }
        #endregion Métodos públicos

        #region Métodos privados
        /// <summary>
        /// Inicialización de las protecciones de acceso
        /// </summary>
        private void InicializarProteccionDepuracion()
        {
            if (!_permiteDepuracion)
            {
                OGestionSistema.InhibirDepuracionAplicacion();
            }
            else
            {
                OGestionTrazabilidad.LoggerPredeterminado.Warn("La aplicación se está ejecutando sin protección contra depuración.");
            }
        }
        #endregion Métodos privados

    }
}
