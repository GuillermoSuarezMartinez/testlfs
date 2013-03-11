//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 12-12-2012
// Description      : Grabación de video
//                    PTZ
//                    Adaptada la forma de conexión desconexión
//
// Last Modified By : aibañez
// Last Modified On : 16-11-2012
// Description      : Eliminadas referencias al formulario de monitorización de cámaras
//                    Eliminadas referencias a los displays
//                    Añadidos eventos de NuevaFotografia, CambioEstado y Mensajes
//
// Last Modified By : aibañez
// Last Modified On : 05-11-2012
// Description      : Adaptada a la utilización de los nuevos controles display
//                    Añadido nuevo campo a la BBDD (FrameIntervalMs)
//                    Modificado nombre de campo de la BBDD (MaxFrameIntervalMsVisualizacion)
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Orbita.VA.Comun;
using Orbita.VA.MaquinasEstados;
using Orbita.Utiles;

namespace Orbita.VA.Hardware
{
	/// <summary>
	/// Clase estática para el acceso a las cámaras
	/// </summary>
	public static class OCamaraManager
	{
		#region Atributo(s)
		/// <summary>
		/// Lista de las cámaras del sistema
		/// </summary>
		public static Dictionary<string, OCamaraBase> ListaCamaras;
		#endregion

		#region Método(s) público(s)
		/// <summary>
		/// Construye los campos de la clase
		/// </summary>
		public static void Constructor()
		{
            ListaCamaras = new Dictionary<string, OCamaraBase>();

			// Añadimos las cámaras al formulario
            DataTable dtCamaras = AppBD.GetCamaras();
            if (dtCamaras.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCamaras.Rows)
                {
                    string codCamara = dr["CodHardware"].ToString();
                    string ensambladoClaseImplementadora = dr["EnsambladoClaseImplementadora"].ToString();
                    string claseImplementadora = string.Format("{0}.{1}", ensambladoClaseImplementadora, dr["ClaseImplementadora"].ToString());

                    object objetoImplementado;
                    if (App.ConstruirClase(ensambladoClaseImplementadora, claseImplementadora, out objetoImplementado, codCamara))
                    {
                        OCamaraBase camara = (OCamaraBase)objetoImplementado;
                        ListaCamaras.Add(codCamara, camara);
                    }
                }
            }
		}

		/// <summary>
		/// Destruye los campos de la clase
		/// </summary>
		public static void Destructor()
		{
			ListaCamaras = null;
		}

		/// <summary>
		/// Inicializa las propieades de la clase
		/// </summary>
		public static void Inicializar()
		{
			foreach (OCamaraBase camara in ListaCamaras.Values)
			{
				camara.Inicializar();
			}
		}

		/// <summary>
		/// Finaliza las propiedades de la clase
		/// </summary>
		public static void Finalizar()
		{
			foreach (OCamaraBase camara in ListaCamaras.Values)
			{
				camara.Finalizar();
			}
		}

		/// <summary>
		/// Busca la cámara con el código indicado
		/// </summary>
		/// <param name="codigo">Código de la cámara</param>
		public static OCamaraBase GetCamara(string codigo)
		{
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara;
            }

            return null;
		}

		/// <summary>
		/// Comienza una reproducción continua de la cámara
		/// </summary>
		/// <returns></returns>
		public static bool Start(string codigo)
		{
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.Start();
            }

            return false;
		}

		/// <summary>
		/// Termina una reproducción continua de la cámara
		/// </summary>
		/// <returns></returns>
		public static bool Stop(string codigo)
		{
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.Stop();
            }

            return false;
		}

		/// <summary>
		/// Comienza una reproducción de todas las cámaras
		/// </summary>
		/// <returns></returns>
		public static bool StartAll()
		{
			bool resultado = true;
			foreach (OCamaraBase camara in ListaCamaras.Values)
			{
				resultado &= camara.Start();
			}
			return resultado;
		}

		/// <summary>
		/// Termina la reproducción de todas las cámaras
		/// </summary>
		/// <returns></returns>
		public static bool StopAll()
		{
			foreach (OCamaraBase camara in ListaCamaras.Values)
			{
				return camara.Stop();
			}
			return false;
		}

		/// <summary>
		/// Realiza una fotografía de forma sincrona
		/// </summary>
		/// <returns></returns>
		public static bool Snap(string codigo)
		{
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.Snap();
            }

            return false;
		}

        /// <summary>
        /// Comienza una grabación continua de la cámara
        /// </summary>
        /// <param name="fichero">Ruta y nombre del fichero que contendra el video</param>
        /// <returns></returns>
        public static bool StartREC(string codigo, string fichero)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.StartREC(fichero);
            }

            return false;
        }

        /// <summary>
        /// Termina una grabación continua de la cámara
        /// </summary>
        /// <returns></returns>
        public static bool StopREC(string codigo)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.StopREC();
            }

            return false;
        }

        /// <summary>
        /// Guarda una imagen en disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se ha de guardar la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public static bool GuardarImagenADisco(string codigo, string ruta)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.GuardarImagenADisco(ruta);
            }

            return false;
        }

        /// <summary>
        /// Método que realiza el empaquetado de un objeto para ser enviado por remoting
        /// </summary>
        /// <returns></returns>
        public static OByteArrayImage Serializar(string codigo)
        {
            OByteArrayImage resultado = null;

            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                resultado = camara.Serializar();
            }

            return resultado;
        }

        /// <summary>
        /// Método que realiza el empaquetado de un objeto para ser enviado por remoting
        /// </summary>
        /// <returns></returns>
        public static bool Desserializar(string codigo, OByteArrayImage byteArrayImage)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.Desserializar(byteArrayImage);
            }

            return false;
        }

        /// <summary>
        /// Ajusta un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public static bool SetAjuste(string codigo, string codAjuste, object valor)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.SetAjuste(codAjuste, valor);
            }

            return false;
        }

        /// <summary>
        /// Consulta el valor de un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public static bool GetAjuste(string codigo, string codAjuste, out object valor)
        {
            OCamaraBase camara;
            valor = null;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.GetAjuste(codAjuste, out valor);
            }

            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="tipo">Tipo de movimiento ptz a ejecutar</param>
        /// <param name="modo">Modo de movimiento: Absoluto o relativo</param>
        /// <param name="valor">valor a establecer</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public static bool EjecutaMovimientoPTZ(string codigo, OEnumTipoMovimientoPTZ tipo, OEnumModoMovimientoPTZ modo, double valor)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.EjecutaMovimientoPTZ(tipo, modo, valor);
            }

            return false; 
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="movimiento">Tipo de movimiento ptz a ejecutar</param>
        /// <param name="valor">valor a establecer</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public static bool EjecutaMovimientoPTZ(string codigo, OMovimientoPTZ movimiento, double valor)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.EjecutaMovimientoPTZ(movimiento, valor);
            }

            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="comando">Comando del movimiento ptz a ejecutar</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public static bool EjecutaMovimientoPTZ(string codigo, OComandoPTZ comando)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.EjecutaMovimientoPTZ(comando);
            }

            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento compuesto de ptz
        /// </summary>
        /// <param name="valores">Tipos de movimientos y valores</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public static bool EjecutaMovimientoPTZ(string codigo, OComandosPTZ valores)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.EjecutaMovimientoPTZ(valores);
            }

            return false;
        }

        /// <summary>
        /// Actualiza la posición actual del PTZ
        /// </summary>
        /// <returns></returns>
        public static OPosicionesPTZ ConsultaPosicionPTZ(string codigo)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.ConsultaPosicionPTZ();
            }

            return null;
        }

        /// <summary>
        /// Actualiza la posición actual de un determinado movimiento PTZ
        /// </summary>
        /// <returns>Listado de posiciones actuales</returns>
        public static OPosicionPTZ ConsultaPosicionPTZ(string codigo, OEnumTipoMovimientoPTZ movimiento)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.ConsultaPosicionPTZ(movimiento);
            }

            return new OPosicionPTZ();
        }

        /// <summary>
        /// Devuelve el tipo de imagen con el que trabaja la cámara
        /// </summary>
        /// <returns></returns>
        public static TipoImagen GetTipoImagen(string codigo)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.TipoImagen;
            }

            return TipoImagen.Bitmap;
        }

        /// <summary>
        /// Indica que se ha podido acceder a la cámara con éxito
        /// </summary>
        public static bool GetExiste(string codigo)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                return camara.Existe;
            }

            return false;
        }

        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public static void CrearSuscripcionNuevaFotografia(string codigo, EventoNuevaFotografiaCamara delegadoNuevaFotografiaCamara)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                camara.OnNuevaFotografiaCamara += delegadoNuevaFotografiaCamara;
            } 
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public static void EliminarSuscripcionNuevaFotografia(string codigo, EventoNuevaFotografiaCamara delegadoNuevaFotografiaCamara)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                camara.OnNuevaFotografiaCamara -= delegadoNuevaFotografiaCamara;
            }            
        }

        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public static void CrearSuscripcionNuevaFotografiaRemota(string codigo, EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                camara.OnNuevaFotografiaCamaraRemota += delegadoNuevaFotografiaCamaraRemota;
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public static void EliminarSuscripcionNuevaFotografiaRemotaRemota(string codigo, EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                camara.OnNuevaFotografiaCamaraRemota -= delegadoNuevaFotografiaCamaraRemota;
            }
        }

        /// <summary>
        /// Suscribe el cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public static void CrearSuscripcionCambioEstadoConexion(string codigo, EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                camara.OnCambioEstadoConexionCamara += delegadoCambioEstadoConexionCamara;
            } 
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public static void EliminarSuscripcionCambioEstadoConexion(string codigo, EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                camara.OnCambioEstadoConexionCamara -= delegadoCambioEstadoConexionCamara;
            } 
        }

        /// <summary>
        /// Suscribe el cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public static void CrearSuscripcionCambioEstadoReproduccion(string codigo, EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                camara.OnCambioEstadoReproduccionCamara += delegadoCambioEstadoReproduccionCamara;
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public static void EliminarSuscripcionCambioEstadoReproduccion(string codigo, EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            OCamaraBase camara;
            if (ListaCamaras.TryGetValue(codigo, out camara))
            {
                camara.OnCambioEstadoReproduccionCamara -= delegadoCambioEstadoReproduccionCamara;
            }
        }
        #endregion
	}

	/// <summary>
	/// Clase base para todas las cámaras
	/// </summary>
    public class OCamaraBase : IHardware
	{
		#region Atributo(s)
		/// <summary>
		/// Indica si esta grabando
		/// </summary>
        public bool Recording
        {
            get { return this.VideoFile.Estado == EstadoProductorConsumidor.EnEjecucion; }
        }
		/// <summary>
		/// Proporciona herramientas para medir la velocidad de adquisición de la cámara
		/// </summary>
		public OMedidorVelocidadAdquisicion MedidorVelocidadAdquisicion;
        /// <summary>
        /// Guardado de Fichero de video
        /// </summary>
        private OVideoFile VideoFile;
        /// <summary>
        /// Contador de fotos utilizado en el recolector de basura
        /// </summary>
        private long ContadorFotosRecolector;
		#endregion

		#region Propiedad(es)
		/// <summary>
		/// Código identificador de la cámara
		/// </summary>
		private string _Codigo;
		/// <summary>
		/// Código identificador de la cámara
		/// </summary>
		public string Codigo
		{
			get { return _Codigo; }
			set { _Codigo = value; }
		}

		/// <summary>
		/// Nombre identificativo de la cámara
		/// </summary>
		private string _Nombre;
		/// <summary>
		/// Nombre identificativo de la cámara
		/// </summary>
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		/// <summary>
		/// Descripción de la cámara
		/// </summary>
		private string _Descripcion;
		/// <summary>
		/// Descripción de la cámara
		/// </summary>
		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		/// <summary>
		/// Habilita o deshabilita el funcionamiento
		/// </summary>
		private bool _Habilitado;
		/// <summary>
		/// Habilita o deshabilita el funcionamiento
		/// </summary>
		public bool Habilitado
		{
			get { return _Habilitado; }
		}

		/// <summary>
		/// Tipo de hardware
		/// </summary>
		public TipoHardware TipoHardware
		{
			get { return TipoHardware.HwCamara; }
		}

		/// <summary>
		/// Tipo de cámara
		/// </summary>
		private TipoCamara _TipoCamara;
		/// <summary>
		/// Tipo de cámara
		/// </summary>
		public TipoCamara TipoCamara
		{
			get { return _TipoCamara; }
			set { _TipoCamara = value; }
		}

		/// <summary>
		/// Código del tipo de cámara
		/// </summary>
		private string _CodigoTipoCamara;
		/// <summary>
		/// Código del tipo de cámara
		/// </summary>
		public string CodigoTipoCamara
		{
			get { return _CodigoTipoCamara; }
			set { _CodigoTipoCamara = value; }
		}

		/// <summary>
		/// Fabricante del tipo de cámara
		/// </summary>
		private string _Fabricante;
		/// <summary>
		/// Fabricante del tipo de cámara
		/// </summary>
		public string Fabricante
		{
			get { return _Fabricante; }
			set { _Fabricante = value; }
		}

		/// <summary>
		/// Modelo del tipo de cámara
		/// </summary>
		private string _Modelo;
		/// <summary>
		/// Modelo del tipo de cámara
		/// </summary>
		public string Modelo
		{
			get { return _Modelo; }
			set { _Modelo = value; }
		}

		/// <summary>
		/// Descripcion del tipo de cámara
		/// </summary>
		private string _DescripcionTipoCamara;
		/// <summary>
		/// Descripcion del tipo de cámara
		/// </summary>
		public string DescripcionTipoCamara
		{
			get { return _DescripcionTipoCamara; }
			set { _DescripcionTipoCamara = value; }
		}

		/// <summary>
		/// Comienza o termina una reproducción de la cámara
		/// </summary>
		private bool _Play;
		/// <summary>
		/// Comienza o termina una reproducción de la cámara
		/// </summary>
		public bool Play
		{
			get
			{
				return _Play;
			}
			set
			{
				if (value)
				{
					this.Start();
				}
				else
				{
					this.Stop();
				}
			}
		}

        /// <summary>
        /// Indica que la reproducción continua se ha de ejecutar en el momento de conexión
        /// </summary>
        private bool _AutoStart;
        /// <summary>
        /// Indica que la reproducción continua se ha de ejecutar en el momento de conexión
        /// </summary>
        public bool AutoStart
        {
            get { return _AutoStart; }
            set { _AutoStart = value; }
        }

		/// <summary>
		/// Código de la variable que guarda la imagen
		/// </summary>
		private string _CodVariableImagen;
		/// <summary>
		/// Código de la variable que guarda la imagen
		/// </summary>
		public string CodVariableImagen
		{
			get { return _CodVariableImagen; }
			set { _CodVariableImagen = value; }
		}

        /// <summary>
        /// Código de la variable que fuerza el snap
        /// </summary>
        private string _CodVariableSnap;
        /// <summary>
        /// Código de la variable que fuerza el snap
        /// </summary>
        public string CodVariableSnap
        {
            get { return _CodVariableSnap; }
            set { _CodVariableSnap = value; }
        }

        /// <summary>
        /// Código de la variable que fuerza la reproducción
        /// </summary>
        private string _CodVariableReproduccion;
        /// <summary>
        /// Código de la variable que fuerza la reproducción
        /// </summary>
        public string CodVariableReproduccion
        {
            get { return _CodVariableReproduccion; }
            set { _CodVariableReproduccion = value; }
        }

        /// <summary>
        /// Código de la variable que indica el estado de la conexión de la cámara
        /// </summary>
        private string _CodVariableEstado;
        /// <summary>
        /// Código de la variable que indica el estado de la conexión de la cámara
        /// </summary>
        public string CodVariableEstado
        {
            get { return _CodVariableEstado; }
            set { _CodVariableEstado = value; }
        }

		/// <summary>
		/// Resolución de la cámara
		/// </summary>
		private Size _Resolucion;
		/// <summary>
		/// Resolución de la cámara
		/// </summary>
        public Size Resolucion
		{
			get { return _Resolucion; }
			set { _Resolucion = value; }
		}

		/// <summary>
		/// Tipo de cámara dependiendo de si sus imágenes son a color o monocromáticas
		/// </summary>
		private TipoColorPixel _Color;
		/// <summary>
		/// Tipo de cámara dependiendo de si sus imágenes son a color o monocromáticas
		/// </summary>
		public TipoColorPixel Color
		{
			get { return _Color; }
			set { _Color = value; }
		}

        /// <summary>
        /// Tipo de imagen que almacena
        /// </summary>
        protected TipoImagen _TipoImagen;
        /// <summary>
        /// Tipo de imagen que almacena
        /// </summary>
        public TipoImagen TipoImagen
        {
            get { return _TipoImagen; }
        }

		/// <summary>
		/// Indica que se ha podido acceder a la cámara con éxito
		/// </summary>
		private bool _Existe;
		/// <summary>
		/// Indica que se ha podido acceder a la cámara con éxito
		/// </summary>
		public bool Existe
		{
			get { return _Existe; }
			set { _Existe = value; }
		}

		/// <summary>
		/// Indica que el control ha de visualizar automáticamente la imagen que devuelve la cámara,
		/// de lo contrario se deberá de especificar el momento de la visualización por código.
		/// </summary>
		private bool _VisualizacionEnVivo;
		/// <summary>
		/// Indica que el control ha de visualizar automáticamente la imagen que devuelve la cámara,
		/// de lo contrario se deberá de especificar el momento de la visualización por código.
		/// </summary>
		public bool VisualizacionEnVivo
		{
			get { return _VisualizacionEnVivo; }
			set { _VisualizacionEnVivo = value; }
		}

		/// <summary>
		/// Lista de todos los terminales de la tarjeta de IO
		/// </summary>              
		protected Dictionary<string, OTerminalIOBase> _ListaTerminales;
		/// <summary>
		/// Lista de todos los terminales de la tarjeta de IO
		/// </summary>              
		public Dictionary<string, OTerminalIOBase> ListaTerminales
		{
			get { return _ListaTerminales; }
			set { _ListaTerminales = value; }
		}

        /// <summary>
        /// Intervalo de tiempo entre consultas de los terminales
        /// </summary>
        protected int _IOTiempoScanMS;
        /// <summary>
        /// Intervalo de tiempo entre consultas de los terminales
        /// </summary>
        public int IOTiempoScanMS
        {
            get { return _IOTiempoScanMS; }
            set { _IOTiempoScanMS = value; }
        }

		/// <summary>
		/// Indica que se ha de cambiar la variable asociada cada vez que se recibe una fotografía
		/// </summary>
		private bool _LanzarEventoAlSnap;
		/// <summary>
		/// Indica que se ha de cambiar la variable asociada cada vez que se recibe una fotografía
		/// </summary>
		public bool LanzarEventoAlSnap
		{
			get { return _LanzarEventoAlSnap; }
			set { _LanzarEventoAlSnap = value; }
		}

        /// <summary>
        /// Indica el intervalo de tiempo en ms. de adquisición de imagenes
        /// </summary>
        private double _ExpectedFrameInterval;
        /// <summary>
        /// Indica el intervalo de tiempo en ms. de adquisición de imagenes
        /// </summary>
        public double ExpectedFrameInterval
        {
            get { return _ExpectedFrameInterval; }
            set { _ExpectedFrameInterval = value; }
        }

        /// <summary>
        /// Indica la tasa de adquisición esperada
        /// </summary>
        private double _ExpectedFrameRate;
        /// <summary>
        /// Indica la tasa de adquisición esperada
        /// </summary>
        public double ExpectedFrameRate
        {
            get { return _ExpectedFrameRate; }
            set { _ExpectedFrameRate = value; }
        }

        /// <summary>
        /// Indica el límite máximo de visualización de imagenes y que por lo tanto se ha de visualizar de forma retrasada con un timer
        /// </summary>
        private double _MaxFrameIntervalVisualizacion;
        /// <summary>
        /// Indica el límite máximo de visualización de imagenes y que por lo tanto se ha de visualizar de forma retrasada con un timer
        /// </summary>
        public double MaxFrameIntervalVisualizacion
        {
            get { return _MaxFrameIntervalVisualizacion; }
            set { _MaxFrameIntervalVisualizacion = value; }
        }

        /// <summary>
        /// Gets or sets the flag indicating that garbage collection is to be run periodically.
        /// </summary>
        private bool _ForzarColectorBasura;
        /// <summary>
        /// Gets or sets the flag indicating that garbage collection is to be run periodically.
        /// </summary>
        public bool ForzarColectorBasura
        {
            get { return _ForzarColectorBasura; }
            set { _ForzarColectorBasura = value; }
        }

        /// <summary>
        /// Gets or sets the frequency at which garbage collection is to be run.
        /// </summary>
        public int _FrecuenciaColectorBasura;
        /// <summary>
        /// Gets or sets the frequency at which garbage collection is to be run.
        /// </summary>
        public int FrecuenciaColectorBasura
        {
            get { return _FrecuenciaColectorBasura; }
            set { _FrecuenciaColectorBasura = value; }
        }

        /// <summary>
        /// Nombre del ensamblado de la clase que implementa el display asociado a este tipo de cámara
        /// </summary>
        private string _EnsambladoClaseImplementadoraDisplay;
        /// <summary>
        /// Nombre del ensamblado de la clase que implementa el display asociado a este tipo de cámara
        /// </summary>
        public string EnsambladoClaseImplementadoraDisplay
        {
            get { return _EnsambladoClaseImplementadoraDisplay; }
            set { _EnsambladoClaseImplementadoraDisplay = value; }
        }

        /// <summary>
        /// Nombre de la clase que implementa el display asociado a este tipo de cámara
        /// </summary>                                        
        private string _ClaseImplementadoraDisplay;
        /// <summary>
        /// Nombre de la clase que implementa el display asociado a este tipo de cámara
        /// </summary>
        public string ClaseImplementadoraDisplay
        {
            get { return _ClaseImplementadoraDisplay; }
            set { _ClaseImplementadoraDisplay = value; }
        }

        /// <summary>
        /// Nombre del ensamblado de la clase que implementa el display asociado a este tipo de cámara
        /// </summary>
        private string _EnsambladoClaseImplementadoraPTZ;
        /// <summary>
        /// Nombre del ensamblado de la clase que implementa el display asociado a este tipo de cámara
        /// </summary>
        public string EnsambladoClaseImplementadoraPTZ
        {
            get { return _EnsambladoClaseImplementadoraPTZ; }
            set { _EnsambladoClaseImplementadoraPTZ = value; }
        }

        /// <summary>
        /// Nombre de la clase que implementa el display asociado a este tipo de cámara
        /// </summary>                                        
        private string _ClaseImplementadoraPTZ;
        /// <summary>
        /// Nombre de la clase que implementa el display asociado a este tipo de cámara
        /// </summary>
        public string ClaseImplementadoraPTZ
        {
            get { return _ClaseImplementadoraPTZ; }
            set { _ClaseImplementadoraPTZ = value; }
        }

        /// <summary>
        /// Clase encargada de comprobar la conectividad con un dispositivo
        /// </summary>
        private OConectividad _Conectividad;
        /// <summary>
        /// Clase encargada de comprobar la conectividad con un dispositivo
        /// </summary>
        public OConectividad Conectividad
        {
            get { return _Conectividad; }
            set { _Conectividad = value; }
        }

        /// <summary>
        /// Control PTZ
        /// </summary>
        private OPTZBase _PTZ;
        /// <summary>
        /// Control PTZ
        /// </summary>
        public OPTZBase PTZ
        {
            get { return _PTZ; }
            set { _PTZ = value; }
        }

        /// <summary>
        /// Porcentaje de la reducción de imagenes en el video grabado: 100 => Tamaño original, 50 => Reducción a la mitad...
        /// </summary>
        public Size ResolucionGrabacion
        {
            get { return this.VideoFile.Resolucion; }
            set { this.VideoFile.Resolucion = value; }
        }

        /// <summary>
        /// Tasa de captura
        /// </summary>
        public int FrameRateGrabacion
        {
            get { return this.VideoFile.FrameRate; }
        }

        /// <summary>
        /// Indica el intervalo de tiempo en ms. de grabación de imagenes
        /// </summary>
        public double FrameIntervalGrabacion
        {
            get { return this.VideoFile.FrameInterval.TotalMilliseconds; }
        }

        /// <summary>
        /// Tasa de transferencia
        /// </summary>
        public int BitRateGrabacion
        {
            get { return this.VideoFile.BitRate; }
            set { this.VideoFile.BitRate = value; }
        }

        /// <summary>
        /// Códec de grabación
        /// </summary>
        public OVideoCodec CodecGarbacion
        {
            get { return this.VideoFile.Codec; }
            set { this.VideoFile.Codec = value; }
        }

        /// <summary>
        /// Tiempo máximo de duración de la grabación
        /// </summary>
        public TimeSpan TiempoMaxGrabacion
        {
            get { return this.VideoFile.TiempoMaxGrabacion; }
            set { this.VideoFile.TiempoMaxGrabacion = value; }
        }

        /// <summary>
        /// Contador de fotografías desde que se inició la adquisición
        /// </summary>
        private long _ContadorFotografias;
        /// <summary>
        /// Contador de fotografías desde que se inició la adquisición
        /// </summary>
        public long ContadorFotografias
	    {
		    get { return _ContadorFotografias;}
	    }
        #endregion

        #region Propiedad(es) virtual(es)
        /// <summary>
        /// Última imagen capturada
        /// </summary>
        protected OImagen _ImagenActual;
        /// <summary>
        /// Propieadad a heredar donde se accede a la imagen
        /// </summary>
        public virtual OImagen ImagenActual
        {
            get { return this._ImagenActual; }
            set { this._ImagenActual = value; }
        }

        /// <summary>
        /// Estado de la conexión
        /// </summary>
        public virtual EstadoConexion EstadoConexion
        {
            get
            {
                return this.Conectividad != null ? this.Conectividad.EstadoConexion : EstadoConexion.Desconectado;
            }
            set
            {
                if (this.Conectividad != null)
                {
                    this.Conectividad.EstadoConexion = value;
                }
            }
        }
        #endregion

        #region Declaración(es) de evento(s)
        /// <summary>
        /// Delegado de nueva fotografía
        /// </summary>
        /// <param name="estadoConexion"></param>
        public event EventoNuevaFotografiaCamara OnNuevaFotografiaCamara;
        /// <summary>
        /// Delegado de nueva fotografía Remota
        /// </summary>
        /// <param name="estadoConexion"></param>
        public event EventoNuevaFotografiaCamaraRemota OnNuevaFotografiaCamaraRemota;
        /// <summary>
        /// Delegado de cambio de estaco de conexión de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        public event EventoCambioEstadoConexionCamara OnCambioEstadoConexionCamara;
        /// <summary>
        /// Delegado de mensaje de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        public event OMessageEvent OnMensaje;
        /// <summary>
        /// Delegado de mensaje de cambio de estado de reproducción
        /// </summary>
        public event EventoCambioEstadoReproduccionCamara OnCambioEstadoReproduccionCamara;
        #endregion

		#region Constructor(es)
		/// <summary>
		/// Constructor de la clase
		/// </summary>
        public OCamaraBase(string codigo)
		{
			try
			{
                //Inicializamos los valores por defecto
				this._Codigo = codigo;
                this._ListaTerminales = new Dictionary<string, OTerminalIOBase>();
				this._Existe = false;
				this._VisualizacionEnVivo = false;
				//this.Recording = false;
				this.MedidorVelocidadAdquisicion = new OMedidorVelocidadAdquisicion();

                DataTable dt = AppBD.GetCamara(codigo);
				if (dt.Rows.Count == 1)
				{
					this._Nombre = dt.Rows[0]["NombreHardware"].ToString();
					this._Descripcion = dt.Rows[0]["DescHardware"].ToString();
					this._Habilitado = (bool)dt.Rows[0]["HabilitadoHardware"];
                    this._TipoCamara = OEnumerado<TipoCamara>.Validar(dt.Rows[0]["CodTipoHardware"].ToString(), TipoCamara.VProBasler);
					this._CodigoTipoCamara = dt.Rows[0]["CodTipoHardware"].ToString();
					this._Fabricante = dt.Rows[0]["Fabricante"].ToString();
					this._Modelo = dt.Rows[0]["Modelo"].ToString();
					this._DescripcionTipoCamara = dt.Rows[0]["DescTipoHardware"].ToString();
					this._CodVariableImagen = dt.Rows[0]["CodVariableImagen"].ToString();
					this._LanzarEventoAlSnap = OBooleano.Validar(dt.Rows[0]["LanzarEventoAlSnap"], false);
					this._CodVariableSnap = dt.Rows[0]["CodVariableSnap"].ToString();
                    this._CodVariableReproduccion = dt.Rows[0]["CodVariableReproduccion"].ToString();
                    this._CodVariableEstado = dt.Rows[0]["CodVariableEstado"].ToString();
					this._Resolucion.Width = OEntero.Validar(dt.Rows[0]["ResolucionX"], 1, 100000, 1024);
					this._Resolucion.Height = OEntero.Validar(dt.Rows[0]["ResolucionY"], 1, 100000, 768);
					this._Color = (TipoColorPixel)OEntero.Validar(dt.Rows[0]["Color"], 0, 1, 0);
                    this._ExpectedFrameInterval = ODecimal.Validar(dt.Rows[0]["FrameIntervalMs"], 0.0, 1000.0, 1.0);
                    this._ExpectedFrameRate = this._ExpectedFrameInterval > 0 ? 1000 / this._ExpectedFrameInterval : 25;
                    this._MaxFrameIntervalVisualizacion = ODecimal.Validar(dt.Rows[0]["MaxFrameIntervalMsVisualizacion"], 0.0, 1000.0, 0.0);
                    this._EnsambladoClaseImplementadoraDisplay = dt.Rows[0]["EnsambladoClaseImplementadoraDisplay"].ToString();
                    this._IOTiempoScanMS = OEntero.Validar(dt.Rows[0]["IO_TiempoScanMS"], 0, int.MaxValue, 10);
                    this._ClaseImplementadoraDisplay = string.Format("{0}.{1}", this._EnsambladoClaseImplementadoraDisplay, dt.Rows[0]["ClaseImplementadoraDisplay"].ToString());
                    this._AutoStart = OBooleano.Validar(dt.Rows[0]["AutoStart"], false);
                    this._ForzarColectorBasura = OBooleano.Validar(dt.Rows[0]["ForzarColectorBasura"], false);
                    this._FrecuenciaColectorBasura = OEntero.Validar(dt.Rows[0]["FrecuenciaColectorBasura"], 1, int.MaxValue, 1);
                    this.ContadorFotosRecolector = 0;

                    // Construcción del PTZ
                    this._EnsambladoClaseImplementadoraPTZ = OTexto.Validar(dt.Rows[0]["EnsambladoClaseImplementadoraPTZ"], 100, false, false, Assembly.GetExecutingAssembly().GetName().Name);
                    this._ClaseImplementadoraPTZ = string.Format("{0}.{1}", this._EnsambladoClaseImplementadoraPTZ, OTexto.Validar(dt.Rows[0]["ClaseImplementadoraPTZ"], 100, false, false, typeof(OPTZBase).Name));
                    object objetoImplementado;
                    if (App.ConstruirClase(this._EnsambladoClaseImplementadoraPTZ, this._ClaseImplementadoraPTZ, out objetoImplementado, this._Codigo))
                    {
                        this.PTZ = (OPTZBase)objetoImplementado;
                    }
                    else
                    {
                        this.PTZ = new OPTZBase(this.Codigo);
                    }

                    // Construcción del Grabador de videos
                    TimeSpan tiempoMaxGrabacion = TimeSpan.FromMilliseconds(OEntero.Validar(dt.Rows[0]["GrabacionTiempoMaxMs"], 1, int.MaxValue, 60));
                    Size resolucionGrabacion = new Size();
                    resolucionGrabacion.Width = OEntero.Validar(dt.Rows[0]["GrabacionResolucionX"], 1, 100000, 1024);
                    resolucionGrabacion.Height = OEntero.Validar(dt.Rows[0]["GrabacionResolucionY"], 1, 100000, 768);
                    OVideoCodec codecGrabacion = OEnumerado<OVideoCodec>.Validar(dt.Rows[0]["GrabacionCodec"].ToString(), OVideoCodec.MPEG4);
                    int bitRateGrabacion = OEntero.Validar(dt.Rows[0]["GrabacionBitRate"], 1, int.MaxValue, 1000);
                    double grabacionFrameIntervalMs = ODecimal.Validar(dt.Rows[0]["GrabacionFrameIntervalMs"], 0.0, 1000.0, 1.0);
                    this.VideoFile = new OVideoFile(this.Codigo, resolucionGrabacion, tiempoMaxGrabacion, grabacionFrameIntervalMs, bitRateGrabacion, codecGrabacion);
				}
				else
				{
					throw new Exception("No se ha podido cargar la información de la cámara " + codigo + " de la base de datos.");
				}
			}
			catch (Exception exception)
			{
				OVALogsManager.Fatal(ModulosHardware.Camaras, this.Codigo, exception);
				throw new Exception("Imposible iniciar la cámara " + this.Codigo);
			}
		}
        #endregion

        #region Método(s) privados(s)
        /// <summary>
        /// Se conecta a la cámara
        /// </summary>
        protected bool Conectar(bool reconexion)
        {
            bool resultado = false;

            if ((this.Existe) && (
                (!reconexion && this.EstadoConexion == EstadoConexion.Desconectado) ||
                (reconexion && this.EstadoConexion == EstadoConexion.Reconectado)))
            {
                this.EstadoConexion = EstadoConexion.Conectando;

                resultado = this.ConectarInterno(reconexion);

                if (resultado)
                {
                    if (!reconexion)
                    {
                        // Verificamos que la cámara está conectada
                        this.Conectividad.OnCambioEstadoConexion += this.OnCambioEstadoConectividadCamara;
                        if (!this.Conectividad.ForzarVerificacionConectividad())
                        {
                            resultado = false;
                        }
                        // Iniciamos la comprobación de la conectividad con la cámara
                        this.Conectividad.Start();
                    }

                    // Iniciamos el PTZ
                    this.PTZ.Inicializar();
                }

                if (reconexion)
                {
                    this.EstadoConexion = resultado ? EstadoConexion.Conectado : EstadoConexion.Reconectando;
                }
                else
                {
                    this.EstadoConexion = resultado ? EstadoConexion.Conectado : EstadoConexion.Desconectado;
                }

                // Se tiene en cuenta el autostart definido en la base de datos para iniciar la reproducción continua
                if (resultado && this._AutoStart)
                {
                    this.Start();
                }
            }
            return resultado;
        }

        /// <summary>
        /// Se desconecta a la cámara
        /// </summary>
        protected bool Desconectar(bool errorConexion)
        {
            bool resultado = false;
            if ((this.Existe) && (
                    (!errorConexion && this.EstadoConexion == EstadoConexion.Conectado) ||
                    (errorConexion && this.EstadoConexion == EstadoConexion.ErrorConexion)))
            {
                this.EstadoConexion = EstadoConexion.Desconectando;

                resultado = this.DesconectarInterno(errorConexion);

                if (resultado)
                {
                    if (!errorConexion)
                    {
                        // Finalizamos la comprobación de la conectividad con la cámara
                        this.Conectividad.OnCambioEstadoConexion -= this.OnCambioEstadoConectividadCamara;
                        this.Conectividad.Stop();
                    }

                    // Finalizamos el PTZ
                    this.PTZ.Finalizar();
                }

                if (errorConexion)
                {
                    this.EstadoConexion = resultado ? EstadoConexion.Reconectando : EstadoConexion.ErrorConexion;
                }
                else
                {
                    this.EstadoConexion = resultado ? EstadoConexion.Desconectado : EstadoConexion.Conectado;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Establece el valor de la imagen a la variable asociada
        /// </summary>
        /// <param name="imagen">Imagen a establecer en la variable</param>
        private void EstablecerVariableImagenAsociada(OImagen imagen)
        {
            if (this.CodVariableImagen != null)
            {
                // Se asigna el valor de la variable asociada
                OVariablesManager.SetValue(this.CodVariableImagen, imagen, "Camaras", this.Codigo);
            }
        }

        /// <summary>
        /// Establece el valor del estado de la conexión a la variable asociada
        /// </summary>
        /// <param name="imagen">Estado a establecer en la variable</param>
        private void EstablecerVariableEstadoAsociada(EstadoConexion estado)
        {
            if (this.CodVariableEstado != null)
            {
                // Se asigna el valor de la variable asociada
                OVariablesManager.SetValue(this.CodVariableEstado, estado, "Camaras", this.Codigo);
            }
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Se conecta a la cámara
        /// </summary>
        public bool Conectar()
        {
            return this.Conectar(false);
        }

        /// <summary>
        /// Se desconecta a la cámara
        /// </summary>
        public bool Desconectar()
        {
            return this.Desconectar(false);
        }

		/// <summary>
		/// Comienza una reproducción continua de la cámara
		/// </summary>
		/// <returns></returns>
		public bool Start()
		{
            bool resultado = false;
            if (this.Habilitado && (this.EstadoConexion == EstadoConexion.Conectado))
            {
                // Información extra
                OVALogsManager.Debug(ModulosHardware.Camaras, this.Codigo, "Start de la cámara: " + this.Codigo);

                OVariablesManager.CrearSuscripcion(this._CodVariableSnap, "Camaras", this.Codigo, ComandoSnapPorVariable);
                OVariablesManager.CrearSuscripcion(this._CodVariableReproduccion, "Camaras", this.Codigo, ComandoReproduccionPorVariable);

                this._Play = true;
                resultado = this.StartInterno();

                this.LanzarEventoCambioReproduccionCamara(this.Codigo, this._Play);
            }
            return resultado;
		}

		/// <summary>
		/// Termina una reproducción continua de la cámara
		/// </summary>
		/// <returns></returns>
		public bool Stop()
		{
            bool resultado = false;
            if (this.Habilitado)
            {
                // Información extra
                OVALogsManager.Debug(ModulosHardware.Camaras, this.Codigo, "Stop de la cámara: " + this.Codigo);

                OVariablesManager.EliminarSuscripcion(this._CodVariableSnap, "Camaras", this.Codigo, ComandoSnapPorVariable);
                OVariablesManager.EliminarSuscripcion(this._CodVariableReproduccion, "Camaras", this.Codigo, ComandoReproduccionPorVariable);

                this._Play = false;
                resultado = this.StopInterno();

                this.LanzarEventoCambioReproduccionCamara(this.Codigo, this._Play);
            }
            return resultado;
        }

		/// <summary>
		/// Realiza una fotografía de forma sincrona
		/// </summary>
		/// <returns></returns>
		public virtual bool Snap()
		{
			bool resultado = false;

            if (this.Habilitado && (this.EstadoConexion == EstadoConexion.Conectado))
            {
                // Modo de funcionamiento normal
                resultado = this.SnapInterno();

                // Información extra
                OVALogsManager.Debug(ModulosHardware.Camaras, this.Codigo, "Snap de la cámara: " + this.Codigo + ". Resultado: " + resultado.ToString());
            }

			return resultado;
		}

		/// <summary>
		/// Visualiza una imagen en el display
		/// </summary>
		/// <param name="imagen">Imagen a visualizar</param>        
		public void VisualizarImagen(OImagen imagen)
		{
			this.VisualizarImagen(imagen, null);
		}

		/// <summary>
		/// Visualiza la última imagen capturada por la cámara
		/// </summary>
		public void VisualizarUltimaImagen()
		{
			this.VisualizarImagen(this.ImagenActual, null);
		}

		/// <summary>
		/// Visualiza la última imagen capturada por la cámara
		/// </summary>
		/// <param name="graficos">Objeto que contiene los gráficos a visualizar (letras, rectas, circulos, etc)</param>
		public void VisualizarUltimaImagen(OGrafico graficos)
		{
			this.VisualizarImagen(this.ImagenActual, graficos);
		}

		/// <summary>
		/// Comienza una grabación continua de la cámara
		/// </summary>
		/// <param name="fichero">Ruta y nombre del fichero que contendra el video</param>
		/// <returns></returns>
		public bool StartREC(string fichero)
		{
            bool resultado = false;
            if (this.Habilitado && (this.EstadoConexion == EstadoConexion.Conectado))
            {
                // Información extra
                OVALogsManager.Debug(ModulosHardware.Camaras, this.Codigo, "REC de la cámara: " + this.Codigo);

                resultado = this.StartRECInterno(fichero);
            }
            //this.Recording = resultado;
            return resultado;
        }

		/// <summary>
		/// Termina una grabación continua de la cámara
		/// </summary>
		/// <returns></returns>
        public bool StopREC()
        {
            bool resultado = false;
            if (this.Habilitado && (this.EstadoConexion == EstadoConexion.Conectado))
            {
                // Información extra
                OVALogsManager.Debug(ModulosHardware.Camaras, this.Codigo, "StopREC de la cámara: " + this.Codigo);

                resultado = this.StopRECInterno();
            }
            //this.Recording = false;
            return resultado;
        }

        /// <summary>
        /// Método que realiza el empaquetado de un objeto para ser enviado por remoting
        /// </summary>
        /// <returns></returns>
        public OByteArrayImage Serializar()
        {
            OByteArrayImage resultado = new OByteArrayImage();

            if (this.Habilitado && (this.EstadoConexion == EstadoConexion.Conectado) && ((this.ImagenActual is OImagen)))
            {
                resultado.Serializar(this.ImagenActual);
            }

            return resultado;
        }

        /// <summary>
        /// Método que realiza el empaquetado de un objeto para ser enviado por remoting
        /// </summary>
        /// <returns></returns>
        public bool Desserializar(OByteArrayImage byteArrayImage)
        {
            bool resultado = false;
            if ((this.Habilitado) && (byteArrayImage.Serializado))
            {
                this.ImagenActual = byteArrayImage.Desserializar();
                resultado = true;
            }
            return resultado;
        }

        /// <summary>
        /// Suscribe el cambio de valor de un terminal de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoCambioValorTerminal">Delegado donde recibir llamadas a cada cambio de valor</param>
        public void CrearSuscripcionCambioValorTerminal(string codTerminal, CambioValorTerminalEvent delegadoCambioValorTerminal)
        {
            OTerminalIOBase terminal;
            if (this._ListaTerminales.TryGetValue(codTerminal, out terminal))
            {
                terminal.OnCambioValorTerminalEvent += delegadoCambioValorTerminal;
            }
        }
        /// <summary>
        /// Elimina el cambio de valor de un terminal de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoCambioValorTerminal">Delegado donde recibir llamadas a cada cambio de valor</param>
        public void EliminarSuscripcionCambioValorTerminal(string codTerminal, CambioValorTerminalEvent delegadoCambioValorTerminal)
        {
            OTerminalIOBase terminal;
            if (this._ListaTerminales.TryGetValue(codTerminal, out terminal))
            {
                terminal.OnCambioValorTerminalEvent -= delegadoCambioValorTerminal;
            }
        }
		#endregion

		#region Método(s) virtual(es) público(s)
		/// <summary>
		/// Carga los valores de la cámara
		/// </summary>
		public virtual void Inicializar()
		{
			if (this.Habilitado)
			{
			    this.CrearConectividad();

                if (!this.Conectar())
				{
					OVALogsManager.Error(ModulosHardware.Camaras, "Inicialización", "Ha sido imposible realizar la conexión de la cámara " + this.Nombre);
				}
			}
		}

		/// <summary>
		/// Finaliza la cámara
		/// </summary>
		public virtual void Finalizar()
		{
			if (this.Habilitado)
			{
				if (this.Desconectar())
				{
                    this.Stop();

					if (this.ImagenActual != null)
					{
						this.ImagenActual = null;
					}
				}
				else
				{
					OVALogsManager.Error(ModulosHardware.Camaras, "Finalización", "Ha sido imposible realizar la desconexión de la cámara " + this.Nombre);
				}
			}
		}

		/// <summary>
		/// Carga una imagen de disco
		/// </summary>
		/// <param name="ruta">Indica la ruta donde se encuentra la fotografía</param>
		/// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
		public virtual bool CargarImagenDeDisco(out OImagen imagen, string ruta)
		{
			// Método implementado en las clases hijas
			imagen = null;
			return false;
		}

		/// <summary>
		/// Guarda una imagen en disco
		/// </summary>
		/// <param name="ruta">Indica la ruta donde se ha de guardar la fotografía</param>
		/// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
		public virtual bool GuardarImagenADisco(string ruta)
		{
			// Método implementado en las clases hijas
			return false;
		}

		/// <summary>
		/// Carga un grafico de disco
		/// </summary>
		/// <param name="ruta">Indica la ruta donde se encuentra el grafico</param>
		/// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
		public virtual bool CargarGraficoDeDisco(out OGrafico grafico, string ruta)
		{
			// Método implementado en las clases hijas
			grafico = null;
			return false;
		}

		/// <summary>
		/// Guarda un objeto gráfico en disco
		/// </summary>
		/// <param name="ruta">Indica la ruta donde se ha de guardar el objeto gráfico</param>
		/// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
		public virtual bool GuardarGraficoADisco(OGrafico graficos, string ruta)
		{
			// Método implementado en las clases hijas
			return false;
		}

		/// <summary>
		/// Devuelve una nueva imagen del tipo adecuado al trabajo con la cámara
		/// </summary>
		/// <returns>Imagen del tipo adecuado al trabajo con la cámara</returns>
		public virtual OImagen NuevaImagen()
		{
			return null;
		}

		/// <summary>
		/// Devuelve un nuevo gráfico del tipo adecuado al trabajo con el display
		/// </summary>
		/// <returns>Grafico del tipo adecuado al trabajo con el display</returns>
		public virtual OGrafico NuevoGrafico()
		{
			return null;
		}

		/// <summary>
		/// Visualiza una imagen en el display
		/// </summary>
		/// <param name="imagen">Imagen a visualizar</param>
		/// <param name="graficos">Objeto que contiene los gráficos a visualizar (letras, rectas, circulos, etc)</param>
		public virtual void VisualizarImagen(OImagen imagen, OGrafico graficos)
		{
		}

        /// <summary>
        /// Ajusta un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public virtual bool SetAjuste(string codAjuste, object valor)
        {
            return false;
        }

        /// <summary>
        /// Consulta el valor de un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public virtual bool GetAjuste(string codAjuste, out object valor)
        {
            valor = null;
            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="tipo">Tipo de movimiento ptz a ejecutar</param>
        /// <param name="modo">Modo de movimiento: Absoluto o relativo</param>
        /// <param name="valor">valor a establecer</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public virtual bool EjecutaMovimientoPTZ(OEnumTipoMovimientoPTZ tipo, OEnumModoMovimientoPTZ modo, double valor)
        {
            return this.PTZ.EjecutaMovimiento(tipo, modo, valor);
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="movimiento">Tipo de movimiento ptz a ejecutar</param>
        /// <param name="valor">valor a establecer</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public virtual bool EjecutaMovimientoPTZ(OMovimientoPTZ movimiento, double valor)
        {
            return this.PTZ.EjecutaMovimiento(movimiento, valor);
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="comando">Comando del movimiento ptz a ejecutar</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public virtual bool EjecutaMovimientoPTZ(OComandoPTZ comando)
        {
            return this.PTZ.EjecutaMovimiento(comando);
        }

        /// <summary>
        /// Ejecuta un movimiento compuesto de ptz
        /// </summary>
        /// <param name="valores">Tipos de movimientos y valores</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public virtual bool EjecutaMovimientoPTZ(OComandosPTZ valores)
        {
            return this.PTZ.EjecutaMovimiento(valores);
        }

        /// <summary>
        /// Actualiza la posición actual del PTZ
        /// </summary>
        /// <returns></returns>
        public virtual OPosicionesPTZ ConsultaPosicionPTZ()
        {
            return this.PTZ.ConsultaPosicion();
        }

        /// <summary>
        /// Actualiza la posición actual de un determinado movimiento PTZ
        /// </summary>
        /// <returns>Listado de posiciones actuales</returns>
        public virtual OPosicionPTZ ConsultaPosicionPTZ(OEnumTipoMovimientoPTZ movimiento)
        {
            return this.PTZ.ConsultaPosicion(movimiento);
        }
        #endregion

        #region Método(s) virtual(es) privado(s)
        /// <summary>
        /// Se toma el control de la cámara
        /// </summary>
        /// <returns>Verdadero si la operación ha funcionado correctamente</returns>
        protected virtual bool ConectarInterno(bool reconexion)
        {
            // Información extra
            OVALogsManager.Debug(ModulosHardware.Camaras, this.Codigo, "Conexión de la cámara: " + this.Codigo);

            return false;
        }

        /// <summary>
        /// Se deja el control de la cámara
        /// </summary>
        /// <returns>Verdadero si la operación ha funcionado correctamente</returns>
        protected virtual bool DesconectarInterno(bool errorConexion)
        {
            // Información extra
            OVALogsManager.Debug(ModulosHardware.Camaras, this.Codigo, "Desconexión de la cámara: " + this.Codigo);

            return false;
        }

        /// <summary>
        /// Comienza una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        protected virtual bool StartInterno()
        {
            this._Play = true;

            this.MedidorVelocidadAdquisicion.ResetearMediciones();

            this._ContadorFotografias = 0;

            // Método implementado en las clases hijas
            return true;
        }

        /// <summary>
        /// Termina una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        protected virtual bool StopInterno()
        {
            this._Play = false;

            // Método implementado en las clases hijas
            return true;
        }

        /// <summary>
        /// Realiza una fotografía de forma sincrona
        /// </summary>
        /// <returns></returns>
        protected virtual bool SnapInterno()
        {
            this.MedidorVelocidadAdquisicion.ResetearMediciones();

            // Método implementado en las clases hijas
            return false;
        }

		/// <summary>
		/// Comienza una grabacion continua de la cámara
		/// </summary>
		/// <param name="fichero">Ruta y nombre del fichero que contendra el video</param>
		/// <returns></returns>
		protected virtual bool StartRECInterno(string fichero)
		{
            bool resultado = false;

            this.VideoFile.Ruta = fichero;
            if (this.VideoFile.Valido)
            {
                resultado = this.VideoFile.Start();
            }

            return resultado;
		}
        
		/// <summary>
		/// Termina una grabación continua de la cámara
		/// </summary>
		/// <returns></returns>
		protected virtual bool StopRECInterno()
		{
            bool resultado = false;

            if (this.Recording)
            {
                this.VideoFile.Stop();
                resultado = true;
            }

            return resultado;
		}

        /// <summary>
        /// Crea el objeto de conectividad adecuado para la cámara
        /// </summary>
        protected virtual void CrearConectividad()
        {
            // Implementado en heredados
        }

        /// <summary>
        /// Se ejecuta cuando se ha completado la adquisición de una imagen
        /// </summary>
        protected virtual void AdquisicionCompletada(OImagen imagen)
        {
            // Actualizo la conectividad
            this.Conectividad.EstadoConexion = EstadoConexion.Conectado;

            // Actualizo el contador de fotografías
            this._ContadorFotografias++;

            // Actualizo el Frame Rate
            this.MedidorVelocidadAdquisicion.NuevaCaptura();

            // Se añade la foto al video
            if (this.Recording)
            {
                this.VideoFile.Add(this.ImagenActual);
            }

            // Se dispara el delegado de nueva fotografía
            this.LanzarEventoNuevaFotografiaCamara(this.Codigo, imagen, DateTime.Now, this.MedidorVelocidadAdquisicion.UltimaTasa);

            if (this._ForzarColectorBasura)
            {
                this.ContadorFotosRecolector++;
                if (this.ContadorFotosRecolector >= this._FrecuenciaColectorBasura)
                {
                    OGestionMemoriaManager.ColectorBasura(false);
                    this.ContadorFotosRecolector = 0;
                }
            }
        }
		#endregion

		#region Eventos
		/// <summary>
		/// Evento de snap realizado por una variable
		/// </summary>
		protected void ComandoSnapPorVariable()
		{
			this.Snap();
		}

        /// <summary>
        /// Evento de reproducción realizado por una variable
        /// </summary>
        protected void ComandoReproduccionPorVariable(string codigo, object valor)
        {
            bool play = OBooleano.Validar(valor, false);
            this.Play = play;
        }
        #endregion

        #region Evento(s) virtual(es)
        /// <summary>
        /// Evento de cambio en la conexión con la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected virtual void OnCambioEstadoConectividadCamara(string codigo, EstadoConexion estadoConexionActal, EstadoConexion estadoConexionAnterior)
        {
            // Lanzamos el evento de cambio de estado
            this.LanzarEventoCambioEstadoConexionCamara(this.Codigo, estadoConexionActal, estadoConexionAnterior);
        }
        #endregion

        #region Lanzamiento de evento(s)
        /// <summary>
        /// Lanza evento de nueva fotografía
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected void LanzarEventoNuevaFotografiaCamara(string codigo, OImagen imagen, DateTime momentoAdquisicion, double velocidadAdquisicion)
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                OThreadManager.SincronizarConThreadPrincipal(new DelegadoNuevaFotografiaCamara(this.LanzarEventoNuevaFotografiaCamara), new object[] { codigo, imagen, momentoAdquisicion, velocidadAdquisicion });
                return;
            }

            if (this.OnNuevaFotografiaCamara != null)
            {
                this.OnNuevaFotografiaCamara(new NuevaFotografiaCamaraEventArgs(codigo, imagen, momentoAdquisicion, velocidadAdquisicion));
            }
            if (this.OnNuevaFotografiaCamaraRemota != null)
            {
                OByteArrayImage imgArray = new OByteArrayImage();
                imgArray.Serializar(imagen);
                this.OnNuevaFotografiaCamaraRemota(new NuevaFotografiaCamaraRemotaEventArgs(codigo, imgArray, momentoAdquisicion, velocidadAdquisicion));
            }

            // Se asigna el valor de la variable asociada
            if (this.LanzarEventoAlSnap && (ImagenActual.EsValida()))
            {
                this.EstablecerVariableImagenAsociada(ImagenActual);
            }
        }
        /// <summary>
        /// Lanza evento de cambio de estado de conexión de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected void LanzarEventoCambioEstadoConexionCamara(string codigo, EstadoConexion estadoConexionActual, EstadoConexion estadoConexionAnterior)
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                OThreadManager.SincronizarConThreadPrincipal(new DelegadoCambioEstadoConexionCamara(this.LanzarEventoCambioEstadoConexionCamara), new object[] { codigo, estadoConexionActual, estadoConexionAnterior });
                return;
            }

            this.EstablecerVariableEstadoAsociada(estadoConexionActual);

            if (this.OnCambioEstadoConexionCamara != null)
            {
                this.OnCambioEstadoConexionCamara(new CambioEstadoConexionCamaraEventArgs(codigo, estadoConexionActual, estadoConexionAnterior));
            }
        }
        /// <summary>
        /// Lanza evento de mensaje de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected void LanzarEventoMensajeCamara(string codigo, string mensaje)
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                OThreadManager.SincronizarConThreadPrincipal(new OMessageDelegateAdv(this.LanzarEventoMensajeCamara), new object[] { codigo, mensaje });
                return;
            }

            if (this.OnMensaje != null)
            {
                this.OnMensaje(new OMessageEventArgs(codigo, mensaje));
            }
        }
        /// <summary>
        /// Lanza evento de mensaje de cambio de estado de reproducción
        /// </summary>
        protected void LanzarEventoCambioReproduccionCamara(string codigo, bool modoReproduccionContinua)
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                OThreadManager.SincronizarConThreadPrincipal(new DelegadoCambioEstadoReproduccionCamara(this.LanzarEventoCambioReproduccionCamara), new object[] { codigo, modoReproduccionContinua });
                return;
            }

            if (this.OnCambioEstadoReproduccionCamara != null)
            {
                this.OnCambioEstadoReproduccionCamara(new CambioEstadoReproduccionCamaraEventArgs(codigo, modoReproduccionContinua));
            }
        }
        #endregion
	}

	/// <summary>
	/// Enumerado que identifica a los tipos de cámaras
	/// </summary>
	public enum TipoCamara
	{
		/// <summary>
		/// Cámara tipo Axis  con firmware 4
		/// </summary>
		Axis = 1,
		/// <summary>
		/// Cámara del fabricante Basler. Mediante driver de Vision Pro
		/// </summary>
		VProBasler = 2,
        /// <summary>
        /// Cámara del fabricante Basler. Mediante driver de Pylon
        /// </summary>
        BaslerPylon = 3,
        /// <summary>
        /// Cámara genérica IP
        /// </summary>
        CamaraIP = 4,
        /// <summary>
        /// Cámara genérica DirectShow
        /// </summary>
        CamaraDirectShow = 5
	}

	/// <summary>
	/// Tipo de la cámara (mono o RGB)
	/// </summary>
	public enum TipoColorPixel
	{
		/// <summary>
		/// Cámara monocromática
		/// </summary>
		Monocromatica = 0,
		/// <summary>
		/// Cámara a color RGB
		/// </summary>
		RGB = 1
	}

    /// <summary>
    /// Enumerado de los modos de adquisición posibles
    /// </summary>
    public enum ModoAdquisicion
    {
        /// <summary>
        /// Modo de adquisición continua de multiples imágenes
        /// </summary>
        Continuo = 0,
        /// <summary>
        /// Modo de adquisición de una única imagen mediante un comando software
        /// </summary>
        DisparoSoftware = 1,
        /// <summary>
        /// Modo de adquisición de una única imagen mediante una entrada digital
        /// </summary>
        DisparoHardware = 2
    }

	#region Acceso a los parámeteros internos de las cámaras
    /// <summary>
    /// Acceso a una característica de la cámara
    /// </summary>
    public interface ICamFeature
    {
        #region Método(s)
        /// <summary>
        /// Envia el valor a la cámara
        /// </summary>
        bool Send(bool force, ModoAjuste modoAjuste);
        /// <summary>
        /// Consulta el valor de la cámara
        /// </summary>
        bool Receive();
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        void LoadBD(DataRow dataRow);
        #endregion
    }

    /// <summary>
    /// Modo de funcinamiento de las propiedades de las cámaras dependiendo de la finalidad de la llamada
    /// </summary>
    public enum ModoAjuste
    {
        /// <summary>
        /// Ajuste de parámetros en el momento de la incialización
        /// </summary>
        Inicializacion = 0,
        /// <summary>
        /// Ajuste de parámetros en el momento de la finalización
        /// </summary>
        Finalizacion = 1,
        /// <summary>
        /// Ajuste de parámetros en el momento de inicio de reproducción continua
        /// </summary>
        Start = 2,
        /// <summary>
        /// Ajuste de parámetros en el momento de la parada de la reproducción continua
        /// </summary>
        Stop = 3,
        /// <summary>
        /// Ajuste de parámetros en modo ejecución
        /// </summary>
        Ejecucion = 4
    }
    #endregion

	#region Reconexión con las cámaras
	/// <summary>
	/// Excepción que se lanza al detectar un problema de conexión con las cámaras
	/// </summary>
	[Serializable]
	public class OCameraConectionException : Exception
	{
		#region Constructor
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		public OCameraConectionException()
			: base("La cámara se encuentra desconectada")
		{
		}
		#endregion
	}

	/// <summary>
	/// Estado de la conexión de la cámara
	/// </summary>
	public enum EstadoConexion
	{
		/// <summary>
		/// Cámara desconectada
		/// </summary>
		Desconectado = 0,
        /// <summary>
        /// Cámara en proceso de desconexión
        /// </summary>
        Desconectando = 1,
        /// <summary>
		/// Cámara conectada correctamente
		/// </summary>
		Conectado = 2,
        /// <summary>
        /// Cámara en proceso de conexión
        /// </summary>
        Conectando = 3,
        /// <summary>
		/// La cámara estaba conectada pero ha aparecido un error de conexión
		/// </summary>
		ErrorConexion = 4,
        /// <summary>
		/// La cámara tiene un error de conexión y está intentando reconectarse
		/// </summary>
		Reconectando = 5,
        /// <summary>
		/// La cámara ha logrado reconectarse
		/// </summary>
		Reconectado = 6
	}
	#endregion

    #region Delegados de las cámaras
    /// <summary>
    /// Delegado de nueva fotografía
    /// </summary>
    /// <param name="codigo"></param>
    /// <param name="estadoConexion"></param>
    public delegate void DelegadoNuevaFotografiaCamara(string codigo, OImagen imagen, DateTime momentoAdquisicion, double velocidadAdquisicion);
    /// <summary>
    /// Delegado de nueva fotografía
    /// </summary>
    /// <param name="estadoConexion"></param>
    public delegate void EventoNuevaFotografiaCamara(NuevaFotografiaCamaraEventArgs e);
    /// <summary>
    /// Argumentos del evento de nueva fotografía
    /// </summary>
    [Serializable]
    public class NuevaFotografiaCamaraEventArgs
    {
        #region Propiedad(es)
        /// <summary>
        /// Código identificativo de la variable
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código identificativo de la variable
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Nueva imagen
        /// </summary>
        private OImagen _Imagen;
        /// <summary>
        /// Nueva imagen
        /// </summary>
        public OImagen Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        /// <summary>
        /// Momento de adquisición
        /// </summary>
        private DateTime _MomentoAdquisicion;
        /// <summary>
        /// Momento de adquisición
        /// </summary>
        public DateTime MomentoAdquisicion
        {
            get { return _MomentoAdquisicion; }
            set { _MomentoAdquisicion = value; }
        }

        /// <summary>
        /// Velocidad de adquisición
        /// </summary>
        private double _VelocidadAdquisicion;
        /// <summary>
        /// Velocidad de adquisición
        /// </summary>
        public double VelocidadAdquisicion
        {
            get { return _VelocidadAdquisicion; }
            set { _VelocidadAdquisicion = value; }
        }
        #endregion

        #region Constructor de la clase
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codigo">Código identificativo de la variable</param>
        /// <param name="valor">Valor de la variable</param>
        public NuevaFotografiaCamaraEventArgs(string codigo, OImagen imagen, DateTime momentoAdquisicion, double velocidadAdquisicion)
        {
            this._Codigo = codigo;
            this._Imagen = imagen;
            this._MomentoAdquisicion = momentoAdquisicion;
            this._VelocidadAdquisicion = velocidadAdquisicion;
        }
        #endregion
    }

    /// <summary>
    /// Delegado de nueva fotografía
    /// </summary>
    /// <param name="estadoConexion"></param>
    public delegate void EventoNuevaFotografiaCamaraRemota(NuevaFotografiaCamaraRemotaEventArgs e);
    /// <summary>
    /// Argumentos del evento de nueva fotografía
    /// </summary>
    [Serializable]
    public class NuevaFotografiaCamaraRemotaEventArgs
    {
        #region Propiedad(es)
        /// <summary>
        /// Código identificativo de la variable
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código identificativo de la variable
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Nueva imagen
        /// </summary>
        private OByteArrayImage _Imagen;
        /// <summary>
        /// Nueva imagen
        /// </summary>
        public OByteArrayImage Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        /// <summary>
        /// Momento de adquisición
        /// </summary>
        private DateTime _MomentoAdquisicion;
        /// <summary>
        /// Momento de adquisición
        /// </summary>
        public DateTime MomentoAdquisicion
        {
            get { return _MomentoAdquisicion; }
            set { _MomentoAdquisicion = value; }
        }

        /// <summary>
        /// Velocidad de adquisición
        /// </summary>
        private double _VelocidadAdquisicion;
        /// <summary>
        /// Velocidad de adquisición
        /// </summary>
        public double VelocidadAdquisicion
        {
            get { return _VelocidadAdquisicion; }
            set { _VelocidadAdquisicion = value; }
        }
        #endregion

        #region Constructor de la clase
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codigo">Código identificativo de la variable</param>
        /// <param name="valor">Valor de la variable</param>
        public NuevaFotografiaCamaraRemotaEventArgs(string codigo, OByteArrayImage imagen, DateTime momentoAdquisicion, double velocidadAdquisicion)
        {
            this._Codigo = codigo;
            this._Imagen = imagen;
            this._MomentoAdquisicion = momentoAdquisicion;
            this._VelocidadAdquisicion = velocidadAdquisicion;
        }
        #endregion
    }

    /// <summary>
    /// Delegado de cambio de estaco de conexión de la cámara
    /// </summary>
    /// <param name="estadoConexion"></param>
    public delegate void DelegadoCambioEstadoConexionCamara(string codigo, EstadoConexion estadoConexionActual, EstadoConexion estadoConexionAnterior);
    /// <summary>
    /// Delegado de cambio de estado de conexión
    /// </summary>
    /// <param name="estadoConexion"></param>
    public delegate void EventoCambioEstadoConexionCamara(CambioEstadoConexionCamaraEventArgs e);
    /// <summary>
    /// Argumentos del evento de cambio de estado de conexión
    /// </summary>
    [Serializable]
    public class CambioEstadoConexionCamaraEventArgs
    {
        #region Propiedad(es)
        /// <summary>
        /// Código identificativo de la variable
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código identificativo de la variable
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Estado de conexión actual
        /// </summary>
        private EstadoConexion _EstadoConexionActual;
        /// <summary>
        /// Estado de conexión actual
        /// </summary>
        public EstadoConexion EstadoConexionActual
        {
            get { return _EstadoConexionActual; }
            set { _EstadoConexionActual = value; }
        }

        /// <summary>
        /// Estado de conexión anterior
        /// </summary>
        private EstadoConexion _EstadoConexionAnterior;
        /// <summary>
        /// Estado de conexión anterior
        /// </summary>
        public EstadoConexion EstadoConexionAnterior
        {
            get { return _EstadoConexionAnterior; }
            set { _EstadoConexionAnterior = value; }
        }
        #endregion

        #region Constructor de la clase
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codigo">Código identificativo de la variable</param>
        /// <param name="valor">Valor de la variable</param>
        public CambioEstadoConexionCamaraEventArgs(string codigo, EstadoConexion estadoConexionActual, EstadoConexion estadoConexionAnterior)
        {
            this._Codigo = codigo;
            this._EstadoConexionActual = estadoConexionActual;
            this._EstadoConexionAnterior = estadoConexionAnterior;
        }
        #endregion
    }

    /// <summary>
    /// Delegado de cambio de estaco de reproducción de la cámara
    /// </summary>
    /// <param name="estadoConexion"></param>
    public delegate void DelegadoCambioEstadoReproduccionCamara(string codigo, bool modoReproduccionContinua);
    /// <summary>
    /// Delegado de cambio de estado de reproducción
    /// </summary>
    /// <param name="estadoConexion"></param>
    public delegate void EventoCambioEstadoReproduccionCamara(CambioEstadoReproduccionCamaraEventArgs e);
    /// <summary>
    /// Argumentos del evento de cambio de estado de reproducción
    /// </summary>
    [Serializable]
    public class CambioEstadoReproduccionCamaraEventArgs
    {
        #region Propiedad(es)
        /// <summary>
        /// Código identificativo de la variable
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código identificativo de la variable
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Estado de la reproducción
        /// </summary>
        private bool _ModoReproduccionContinua;
        /// <summary>
        /// Estado de la reproducción
        /// </summary>
        public bool ModoReproduccionContinua
        {
            get { return _ModoReproduccionContinua; }
            set { _ModoReproduccionContinua = value; }
        }
        #endregion

        #region Constructor de la clase
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codigo">Código identificativo de la variable</param>
        /// <param name="valor">Valor de la variable</param>
        public CambioEstadoReproduccionCamaraEventArgs(string codigo, bool modoReproduccionContinua)
        {
            this._Codigo = codigo;
            this._ModoReproduccionContinua = modoReproduccionContinua;
        }
        #endregion
    }
    #endregion

	#region Medición de la tasa de adquisición
	/// <summary>
	/// Se utiliza para medir la tasa de adquisición de la cámara
	/// </summary>
	public class OMedidorVelocidadAdquisicion
	{
		#region Constante(s)
		/// <summary>
		/// Constante que indica el número de valores utilizados en el promedio de las medidas
		/// </summary>
		private const int NumeroValoresPromediados = 10;
		#endregion

		#region Atributo(s)
		private Stopwatch Cronometro;
		/// <summary>
		/// Duración de la última adquisición. En el caso de ser la primera es 0.
		/// </summary>
		public TimeSpan UltimaDuracion;
		/// <summary>
		/// Capturas por sergundo tomada de la última adquisición. En el caso de ser la primera es 0.
		/// </summary>
		public double UltimaTasa;
		/// <summary>
		/// Promedio de duración de las últimas "NumeroValoresPromediados". En el caso de ser la primera es 0.
		/// </summary>
		public TimeSpan PromedioDuracion;
		/// <summary>
		/// Capturas por sergundo tomada de las últimas "NumeroValoresPromediados". En el caso de ser la primera es 0.
		/// </summary>
		public double PromedioTasa;
		#endregion

		#region Constructor de la clase
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		public OMedidorVelocidadAdquisicion()
		{
			this.ResetearMediciones();
		}
		#endregion

		#region Método(s) público(s)
		/// <summary>
		/// Se resetean las mediciones
		/// </summary>
		public void ResetearMediciones()
		{
			this.Cronometro = new Stopwatch();
			this.UltimaDuracion = new TimeSpan();
			this.UltimaTasa = 0;
			this.PromedioDuracion = new TimeSpan();
			this.PromedioTasa = 0;        
		}

		/// <summary>
		/// Se ha capturado una nueva foto, por lo que se recalcula la tasa de adquisición
		/// </summary>
		public void NuevaCaptura()
		{
			bool running = this.Cronometro.IsRunning;

			this.Cronometro.Stop();

			if (running)
			{
				this.UltimaDuracion = this.Cronometro.Elapsed;
				this.UltimaTasa = 1 / this.UltimaDuracion.TotalSeconds;
				if (this.PromedioDuracion.TotalSeconds == 0.0)
				{
					this.PromedioDuracion = this.UltimaDuracion;
					this.PromedioTasa = 1 / this.UltimaDuracion.TotalSeconds;
				}
				else
				{
					double factorValorAnterior = ((double)NumeroValoresPromediados - 1.0) / (double)NumeroValoresPromediados;
					double factorValorNuevo = 1.0 / (double)NumeroValoresPromediados;
					this.PromedioDuracion = TimeSpan.FromMilliseconds((this.PromedioDuracion.TotalMilliseconds * factorValorAnterior) + (this.UltimaDuracion.TotalMilliseconds * factorValorNuevo));
					this.PromedioTasa = 1 / this.PromedioDuracion.TotalSeconds;
				}
			}
			else
			{
				this.ResetearMediciones();
			}
			
			this.Cronometro.Reset();
			this.Cronometro.Start();
		}
		#endregion
	}
	#endregion
}
