//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 19-02-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Orbita.Utiles;
using Orbita.VA.Comun;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Cámara virtual utilizada para la simulación de hardware
    /// </summary>
    public class OCamaraVirtual : OCamaraBitmap
    {
        #region Atributo(s)
        /// <summary>
        /// Listado de las fotografías situadas en el directorio
        /// </summary>
        private List<string> ListaRutaFotografias;
        /// <summary>
        /// Indica la fotografía actual en la lista de fotografías
        /// </summary>
        private int IndiceFotografia;
        /// <summary>
        /// Timer que se utiliza para realizar la simulación de la grabación
        /// </summary>
        private Timer TimerSimulacionGrab;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Indica el tipo de simulación que se realizará en la cámara (con una única foto o con toda una carpeta de fotos)
        /// </summary>
        private TipoSimulacionCamara _TipoSimulacion;
        /// <summary>
        /// Indica el tipo de simulación que se realizará en la cámara (con una única foto o con toda una carpeta de fotos)
        /// </summary>
        public TipoSimulacionCamara TipoSimulacion
        {
            get { return _TipoSimulacion; }
            set { _TipoSimulacion = value; }
        }

        /// <summary>
        /// Indica la ruta de la fotografía o de la carpeta de fotografías donde están las imágenes a simular
        /// </summary>
        private string _RutaFotografias;
        /// <summary>
        /// Indica la ruta de la fotografía o de la carpeta de fotografías donde están las imágenes a simular
        /// </summary>
        public string RutaFotografias
        {
            get { return _RutaFotografias; }
            set { _RutaFotografias = value; }
        }

        /// <summary>
        /// Intervalo de tiempo entre snaps de grabación
        /// </summary>
        private int _IntervaloEntreSnaps;
        /// <summary>
        /// Intervalo de tiempo entre snaps de grabación
        /// </summary>
        public int IntervaloEntreSnaps
        {
            get { return _IntervaloEntreSnaps; }
            set { _IntervaloEntreSnaps = value; }
        }

        /// <summary>
        /// Filtro de las imagenes a simular
        /// </summary>
        private string _Filtro;
        /// <summary>
        /// Filtro de las imagenes a simular
        /// </summary>
        public string Filtro
        {
            get { return _Filtro; }
            set { _Filtro = value; }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OCamaraVirtual(string codigo)
            : base(codigo)
        {
            try
            {
                // Cargamos valores de la base de datos
                DataTable dt = AppBD.GetCamara(codigo);
                if (dt.Rows.Count == 1)
                {
                    this._TipoSimulacion = OEnumerado<TipoSimulacionCamara>.Validar(dt.Rows[0]["CamVirtual_TipoSimulacion"], TipoSimulacionCamara.FotografiaSimple);
                    this._RutaFotografias = dt.Rows[0]["CamVirtual_RutaFotografias"].ToString();
                    this._Filtro = dt.Rows[0]["CamVirtual_Filtro"].ToString();
                    this._IntervaloEntreSnaps = OEntero.Validar(dt.Rows[0]["CamVirtual_IntervaloEntreSnapsMs"], 1, int.MaxValue, 1000);

                    this.IndiceFotografia = -1;
                    this.ListaRutaFotografias = new List<string>();

                    this.TimerSimulacionGrab = new Timer();
                    this.TimerSimulacionGrab.Interval = this._IntervaloEntreSnaps;
                    this.TimerSimulacionGrab.Enabled = false;
                    this.TimerSimulacionGrab.Tick += EventoGrabSimulado;
                }
                else
                {
                    throw new Exception("No se ha podido cargar la información de la cámara " + codigo + " \r\nde la base de datos.");
                }

                this.Existe = true;
            }
            catch (Exception exception)
            {
                OVALogsManager.Fatal(ModulosHardware.CamaraVirtual, this.Codigo, exception);
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
                switch (this._TipoSimulacion)
                {
                    case TipoSimulacionCamara.FotografiaSimple:
                        if (File.Exists(this._RutaFotografias))
                        {
                            resultado = true;
                        }
                        break;
                    case TipoSimulacionCamara.DirectorioFotografias:
                        this.ListaRutaFotografias = new List<string>();
                        this.IndiceFotografia = -1;

                        if (Path.IsPathRooted(this._RutaFotografias) && Directory.Exists(this._RutaFotografias))
                        {
                            string[] arrayFotografias = Directory.GetFiles(this._RutaFotografias, this._Filtro, SearchOption.TopDirectoryOnly);
                            this.ListaRutaFotografias.AddRange(arrayFotografias);

                            this.TimerSimulacionGrab.Interval = this._IntervaloEntreSnaps;

                            resultado = this.ListaRutaFotografias.Count > 0;
                        }
                        break;
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraVirtual, this.Codigo, "Error al conectarse a la cámara " + this.Codigo + ": " + exception.ToString());
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

                    this.TimerSimulacionGrab.Enabled = true;

                    resultado = true;
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraVirtual, this.Codigo, exception);
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

                if (this.EstadoConexion != EstadoConexion.Desconectado)
                {
                    this.TimerSimulacionGrab.Enabled = false;

                    resultado = true;

                    base.StopInterno();
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraVirtual, this.Codigo, exception);
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
                    base.SnapInterno();

                    resultado = this.EjecutarSimulacion();
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraRemota, this.Codigo, exception);
            }
            return resultado;
        }

        /// <summary>
        /// Crea el objeto de conectividad adecuado para la cámara
        /// </summary>
        protected override void CrearConectividad()
        {
            // Creación de la comprobación de la conexión con la cámara
            this.Conectividad = new OConectividad(this.Codigo);
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Evento del timer de simulación de fotografía
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void EventoGrabSimulado(object sender, EventArgs e)
        {
            try
            {
                this.EjecutarSimulacion();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraVirtual, this.Codigo, exception);
            }
        }

        /// <summary>
        /// Ejecuta la simulación de un snap
        /// </summary>
        /// <returns>Verdadero si la simulación se ha ejecutado con éxito</returns>
        public bool EjecutarSimulacion()
        {
            bool resultado = false;

            try
            {
                string rutaFotografiaActual = "";

                switch (this.TipoSimulacion)
                {
                    case TipoSimulacionCamara.FotografiaSimple:
                        rutaFotografiaActual = this.RutaFotografias;
                        resultado = true;
                        break;
                    case TipoSimulacionCamara.DirectorioFotografias:
                        if (this.ListaRutaFotografias.Count > 0)
                        {
                            this.IndiceFotografia++;
                            resultado = OEntero.InRange(this.IndiceFotografia, 0, this.ListaRutaFotografias.Count - 1);
                            if (resultado)
                            {
                                rutaFotografiaActual = this.ListaRutaFotografias[this.IndiceFotografia];
                            }
                        }
                        break;
                }

                if (resultado)
                {
                    // Se carga la fotografía de disco
                    this.ImagenActual = (OImagenBitmap)this.NuevaImagen();
                    resultado = this.ImagenActual.Cargar(rutaFotografiaActual);

                    if (resultado)
                    {
                        // Lanamos el evento de adquisición
                        this.AdquisicionCompletada(this.ImagenActual);
                    }
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraVirtual, this.Codigo, exception);
            }

            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Enumerado que informa sobre el tipo de simulación que se está realizando en la cámara
    /// </summary>
    public enum TipoSimulacionCamara
    {
        /// <summary>
        /// Se simula siempre con la misma fotografía
        /// </summary>
        FotografiaSimple,

        /// <summary>
        /// Se simula con todo un directorio de fotografías
        /// </summary>
        DirectorioFotografias
    }
}
