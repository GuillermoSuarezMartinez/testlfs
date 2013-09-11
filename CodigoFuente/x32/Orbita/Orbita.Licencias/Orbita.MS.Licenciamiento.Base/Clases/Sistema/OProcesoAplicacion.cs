using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Orbita.MS.Sistema;

namespace Orbita.MS
{
    /// <summary>
    /// Información realativa al proceso de la aplicación licenciada
    /// </summary>
    [XmlRootAttribute("ProcesoAplicLic", Namespace = "http://orbitaingenieria.es/orbita/ms", IsNullable = false)]
    public class OProcesoAplicacion
    {
        #region Atributos

        /// <summary>
        /// ID del proceso
        /// </summary>
        private int _pID = -1;
        /// <summary>
        /// Nombre del proceso
        /// </summary>
        private string _pNombre = "";
        /// <summary>
        /// Estado del proceso
        /// </summary>
        private OEstadoProceso _pEstado = OEstadoProceso.Indefinido;
        /// <summary>
        /// Fecha/hora de inicio del proceso.
        /// </summary>
        private DateTime _pInicio = DateTime.MinValue;
        /// <summary>
        /// Fecha/hora de inicio del proceso.
        /// </summary>
        private DateTime _pFin = DateTime.MinValue;
        /// <summary>
        /// Datos de licenciamiento
        /// </summary>
        private OAplicacion _pDatosLicenciamiento = null;
        /// <summary>
        /// Procesos dependientes de la instancia definida.
        /// </summary>
        private List<OProcesoAplicacion> _pDependientes = new List<OProcesoAplicacion>() { };
        /// <summary>
        /// Detalles del proceso
        /// </summary>
        private string _pdetalles = "";
        /// <summary>
        /// Códido de salida del proceso
        /// </summary>
        private int _pEC = -9999;
        /// <summary>
        /// Descripción de la finalización del proceso.
        /// </summary>
        private OSalidaProceso _pSalida = OSalidaProceso.Indefinido;
        /// <summary>
        /// Nombre de usuario efectivo que inicia el proceso
        /// </summary>
        private string _pUsuarioEfectivo = "SYSTEM";
        /// <summary>
        /// Nombre del equipo sobre el que se inicia el proceso (equipo Final).
        /// </summary>
        private string _pEquipoFinal = Environment.MachineName;

        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// ID del proceso
        /// </summary>
        public int PID
        {
            get { return _pID; }
            set { _pID = value; }
        }
        /// <summary>
        /// Nombre del proceso
        /// </summary>
        public string PNombre
        {
            get { return _pNombre; }
            set { _pNombre = value; }
        }
        /// <summary>
        /// Estado del proceso
        /// </summary>
        public OEstadoProceso PEstado
        {
            get { return _pEstado; }
            set { _pEstado = value; }
        }
        /// <summary>
        /// Fecha/hora de inicio del proceso.
        /// </summary>
        public DateTime PInicio
        {
            get { return _pInicio; }
            set { _pInicio = value; }
        }
        /// <summary>
        /// Fecha/hora de inicio del proceso.
        /// </summary>
        public DateTime PFin
        {
            get { return _pFin; }
            set { _pFin = value; }
        }
        /// <summary>
        /// Detalles de la operación
        /// </summary>
        public string PDetalles
        {
            get { return _pdetalles; }
            set { _pdetalles = value; }
        }
        /// <summary>
        /// Datos de licenciamiento
        /// </summary>
        public OAplicacion PDatosLicenciamiento
        {
            get { return _pDatosLicenciamiento; }
            set { _pDatosLicenciamiento = value; }
        }
        /// <summary>
        /// Procesos dependientes del definido
        /// </summary>
        public List<OProcesoAplicacion> PDependientes
        {
            get { return _pDependientes; }
            set { _pDependientes = value; }
        }
        /// <summary>
        /// Descripción de la finalización del proceso.
        /// </summary>
        public OSalidaProceso PSalida
        {
            get { return _pSalida; }
            set { _pSalida = value; }
        }
        /// <summary>
        /// Nombre de usuario efectivo que inicia el proceso
        /// </summary>
        public string PUsuarioEfectivo
        {
            get { return _pUsuarioEfectivo; }
            set { _pUsuarioEfectivo = value; }
        }
        /// <summary>
        /// Nombre del equipo sobre el que se inicia el proceso (equipo Final).
        /// </summary>
        public string PEquipoFinal
        {
            get { return _pEquipoFinal; }
            set { _pEquipoFinal = value; }
        }

        private string _versionOProcesoAplicacion = "1.1";
        #endregion Propiedades
        #region Constructor
        public OProcesoAplicacion()
        {

        }
        public OProcesoAplicacion(string nombre)
        {
            this._pNombre = nombre;
        }
        public OProcesoAplicacion(System.Diagnostics.Process proceso)
        {
            this._pID = proceso.Id;
            this._pNombre = proceso.ProcessName;
            this._pEquipoFinal = proceso.MachineName;
            this._pInicio = proceso.StartTime;
            if (proceso.HasExited)
            { 
                this._pFin = proceso.ExitTime;
                this._pEC = proceso.ExitCode;
            }
            this._pUsuarioEfectivo = "Desconocido";
        }
        #endregion Constructor
    }
}
