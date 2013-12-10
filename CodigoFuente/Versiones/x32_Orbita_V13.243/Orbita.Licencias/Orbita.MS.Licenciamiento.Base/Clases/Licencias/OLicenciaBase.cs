using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.Trazabilidad;
using Orbita.Utiles;
using Orbita.MS.Clases.Trazabilidad;
using System.Xml.Serialization;
using System.Reflection;
using Orbita.MS.Licencias;
namespace Orbita.MS
{
    /// <summary>
    /// Clase base para la gestión de licencias
    /// </summary>
    public class OLicenciaBase
    {
        #region Atributos
        /// <summary>
        /// Tipo de licencia de producto
        /// </summary>
        private OTipoLicencia _tipoLicencia = OTipoLicencia.Indefinido;
        /// <summary>
        /// ID Dispositivo licencia
        /// </summary>
        private string _idDispositivoLicencia = "";

        /// <summary>
        /// Versión de la licencia
        /// </summary>
        protected string _versionLicenciaBase = "1.1";

        /// <summary>
        /// Tipo 
        /// </summary>
        [XmlIgnore()]
        protected Type _tipo = typeof(OLicenciaBase);
        /// <summary>
        /// Logger
        /// </summary>
        [XmlIgnore()]
        private ILogger _log = null;
        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// Tipo de licencia de producto
        /// </summary>
        public OTipoLicencia TipoLicencia
        {
            get { return _tipoLicencia; }
            set { _tipoLicencia = value; }
        }
        /// <summary>
        /// ID Dispositivo licencia
        /// </summary>
        public string IdDispositivoLicencia
        {
            get { return _idDispositivoLicencia; }
            set { _idDispositivoLicencia = value; }
        }
        /// <summary>
        /// Logger
        /// </summary>
        [XmlIgnore()]
        public ILogger Log
        {
            get
            {
                if (_log == null)
                {
                    _log = OGestionTrazabilidad.LoggerPredeterminado;
                }
                return _log;
            }
        }
        /// <summary>
        /// Tipo
        /// </summary>
        [XmlIgnore()]
        protected Type Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

      
        /// <summary>
        /// Referencia a ID de características
        /// </summary>
        [XmlIgnore()]
        protected List<int> _refIDCaracteristicas = new List<int>() { };
        /// <summary>
        /// Referencia a ID de características
        /// </summary>
        [XmlIgnore()]
        public List<int> RefIDCaracteristicas
        {
            get { return _refIDCaracteristicas; }
            set { _refIDCaracteristicas = value; }
        }
        /// <summary>
        /// Referencia a ID de productos
        /// </summary>
        [XmlIgnore()]
        protected List<int> _refIDProductos = new List<int>() { };
        /// <summary>
        /// Referencia a ID de productos
        /// </summary>
        [XmlIgnore()]
        public List<int> RefIDProductos
        {
            get { return _refIDProductos; }
            set { _refIDProductos = value; }
        }
        #endregion Propiedades

        #region Delegados

        /// <summary>
        /// Delegado cierre aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void OrbitaCerrarAplicaciontHandler(object sender, OEventArgs e);
        /// <summary>
        /// Delegado mensaje de aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void OrbitaMensajeAplicaciontHandler(object sender, OEventArgs e);

        #endregion Delegados

        #region Eventos
        /// <summary>
        /// Evento cierre aplicación
        /// </summary>
        public event OrbitaCerrarAplicaciontHandler OrbitaCerrarAplicacion;
        /// <summary>
        /// Evento mensaje de aplicación
        /// </summary>
        public event OrbitaMensajeAplicaciontHandler OrbitaMensajeAplicacion;
        #endregion Eventos

        #region Constructores

        public OLicenciaBase()
        {
        }

        #endregion Constructores

        #region Métodos públicos
        /// <summary>
        /// Inicializar
        /// </summary>
        /// <returns></returns>
        public virtual bool Inicializar()
        {
            return true;
        }

        public override string ToString()
        {
            return this.GetType().Name + " " + this.IdDispositivoLicencia + " - " + this.TipoLicencia.ToString();
        }
        /// <summary>
        /// Comprueba la existencia y validez del producto
        /// </summary>
        /// <returns></returns>
        public virtual bool CompruebaProducto()
        {
            return VerificaExistenciaLicencia() && VerificaValidezLicencia();
        }

        /// <summary>
        /// Comprobaciones iniciales de existencia y validez del producto
        /// </summary>
        /// <returns></returns>
        public virtual bool ComprobacionInicial()
        {
            return VerificaExistenciaLicencia() && VerificaValidezLicencia();
        }
        #endregion Métodos públicos

        #region Métodos privados

        /// <summary>
        /// Tareas a realizar para verificar la validez de la licencia
        /// </summary>
        /// <returns></returns>
        protected virtual bool VerificaValidezLicencia()
        {
            Log.Error("No hay definido un proceso para verificar la validez de la licencia.");
            return false;
        }
        /// <summary>
        /// Tareas a realizar para verificar la existencia de la licencia
        /// </summary>
        /// <returns></returns>
        protected virtual bool VerificaExistenciaLicencia()
        {
            Log.Error("No hay definido un proceso para verificar la existencia de la licencia.");
            return false;
        }

        /// <summary>
        /// Método a ejecutar si la validación de la licencia es correcta
        /// </summary>
        protected virtual void AccionValidacionCorrecta()
        {

        }

        /// <summary>
        /// Método a ejecutar si la validación de la licencia es incorrecta
        /// </summary>
        protected virtual void AccionValidacionIncorrecta()
        {

        }

        /// <summary>
        /// Método a ejecutar si la licencia es detectada
        /// </summary>
        protected virtual void AccionLicenciaDetectada()
        {

        }

        /// <summary>
        /// Método a ejecutar si la licencia es detectada
        /// </summary>
        protected virtual void AccionLicenciaNoDisponible()
        {

        }
        protected virtual bool CerrarAplicacion()
        {
            Log.Debug("Se ha iniciado el cierre de la aplicación");
            try
            {
                Log.Debug("Fin del proceso controlado de cierre de la aplicación");
                return true;
            }
            catch (Exception e1)
            {
                Console.Error.WriteLine(e1);
                Log.Error(e1);
                return false;
            }
        }
        #endregion Métodos privados

    }
}
