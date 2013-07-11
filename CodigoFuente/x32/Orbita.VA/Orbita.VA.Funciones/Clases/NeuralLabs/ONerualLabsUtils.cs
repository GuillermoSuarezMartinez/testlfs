//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : aibañez
// Created          : 06-09-2012
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
using Orbita.VA.Comun;
using System.Drawing;
using Orbita.Utiles;
using System.Data;
using System.IO;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase estática con utilidades para el procesado de neural labs
    /// </summary>
    internal static class ONerualLabsUtils
    {
        #region Método(s) público(s)
        /// <summary>
        /// Corrección de la perspectiva
        /// </summary>
        /// <param name="parametros"></param>
        public static void CorreccionPerspectivaDisco(string ruta, OCorreccionPerspectiva parametros)
        {
            try
            {
                if (parametros.Activada)
                {
                    if (!OFicheros.FicheroBloqueado(ruta, 5000))
                    {
                        // Carga de disco
                        OImagenOpenCV<Emgu.CV.Structure.Bgr, byte> imagen = new OImagenOpenCV<Emgu.CV.Structure.Bgr, byte>("NL_CorreccionPerspectiva");
                        imagen.Cargar(ruta);

                        // Corrección de perspectiva
                        OImagenOpenCV<Emgu.CV.Structure.Bgr, byte> imagenCorregida = imagen.CorregirPerspectiva(parametros.PuntoOrigen1,
                            parametros.PuntoOrigen2,
                            parametros.PuntoOrigen3,
                            parametros.PuntoOrigen4,
                            parametros.OffsetOrigen,
                            parametros.AreaDestino);

                        // Guardado en disco
                        imagenCorregida.Guardar(ruta);
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "CorreccionPerspectivaDisco");
            }
        }

        /// <summary>
        /// Corrección de la perspectiva
        /// </summary>
        /// <param name="parametros"></param>
        public static OImagenBitmap CorreccionPerspectivaMemoria(OImagenBitmap imagen, OCorreccionPerspectiva parametros)
        {
            OImagenBitmap resultado = imagen;

            try
            {
                if (parametros.Activada)
                {
                    // Conversión de tipo
                    OImagenOpenCV<Emgu.CV.Structure.Bgr, byte> imagenTrabajo;
                    imagen.Convert<OImagenOpenCV<Emgu.CV.Structure.Bgr, byte>>(out imagenTrabajo);

                    // Corrección de perspectiva
                    OImagenOpenCV<Emgu.CV.Structure.Bgr, byte> imagenCorregida = imagenTrabajo.CorregirPerspectiva(parametros.PuntoOrigen1,
                        parametros.PuntoOrigen2,
                        parametros.PuntoOrigen3,
                        parametros.PuntoOrigen4,
                        parametros.OffsetOrigen,
                        parametros.AreaDestino);

                    // Conversión de tipo
                    imagenCorregida.Convert<OImagenBitmap>(out resultado);

                    imagenCorregida.Dispose();
                    imagenTrabajo.Dispose();
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "CorreccionPerspectivaMemoria");
            }
            return resultado;
        }

        /// <summary>
        /// Eliminación del fichero temporal
        /// </summary>
        /// <param name="rutaFicheroTemporal"></param>
        internal static void EliminarFicheroTemporal(string rutaFicheroTemporal)
        {
            try
            {
                File.Delete(rutaFicheroTemporal);
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, "Eliminando imagen temporal de la ruta :" + rutaFicheroTemporal);
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase con la parametrización de corrección de perspectiva
    /// </summary>
    public class OCorreccionPerspectiva
    {
        #region Atributo(s)
        /// <summary>
        /// Activada la corrección de perspectiva de Orbita
        /// </summary>
        public bool Activada;
        /// <summary>
        /// Coordenadas del punto de origen número 1
        /// </summary>
        public PointF PuntoOrigen1;
        /// <summary>
        /// Coordenadas del punto de origen número 2
        /// </summary>
        public PointF PuntoOrigen2;
        /// <summary>
        /// Coordenadas del punto de origen número 3
        /// </summary>
        public PointF PuntoOrigen3;
        /// <summary>
        /// Coordenadas del punto de origen número 4
        /// </summary>
        public PointF PuntoOrigen4;
        /// <summary>
        /// Offset del marco rectangular
        /// </summary>
        public Point OffsetOrigen;
        /// <summary>
        /// Región destino
        /// </summary>
        public Rectangle AreaDestino;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase sin parámetros
        /// </summary>
        public OCorreccionPerspectiva()
        {
            this.Activada = false;
            this.PuntoOrigen1 = PointF.Empty;
            this.PuntoOrigen2 = PointF.Empty;
            this.PuntoOrigen3 = PointF.Empty;
            this.PuntoOrigen4 = PointF.Empty;
            this.OffsetOrigen = Point.Empty;
            this.AreaDestino = Rectangle.Empty;
        }

        /// <summary>
        /// Constructor de la clase configurandose a partir de un datarow
        /// </summary>
        public OCorreccionPerspectiva(DataRow dr)
        {
            this.Activada = OBooleano.Validar(dr["NL_OrbitaCorreccionPerspectivaActivada"], false);
            this.PuntoOrigen1 = new PointF(
                (float)ODecimal.Validar(dr["NL_OrbitaCorreccionPerspectivaPuntoOrigenX1"], 0, int.MaxValue, 100),
                (float)ODecimal.Validar(dr["NL_OrbitaCorreccionPerspectivaPuntoOrigenY1"], 0, int.MaxValue, 100));
            this.PuntoOrigen2 = new PointF(
                (float)ODecimal.Validar(dr["NL_OrbitaCorreccionPerspectivaPuntoOrigenX2"], 0, int.MaxValue, 100),
                (float)ODecimal.Validar(dr["NL_OrbitaCorreccionPerspectivaPuntoOrigenY2"], 0, int.MaxValue, 200));
            this.PuntoOrigen3 = new PointF(
                (float)ODecimal.Validar(dr["NL_OrbitaCorreccionPerspectivaPuntoOrigenX3"], 0, int.MaxValue, 200),
                (float)ODecimal.Validar(dr["NL_OrbitaCorreccionPerspectivaPuntoOrigenY3"], 0, int.MaxValue, 200));
            this.PuntoOrigen4 = new PointF(
                (float)ODecimal.Validar(dr["NL_OrbitaCorreccionPerspectivaPuntoOrigenX4"], 0, int.MaxValue, 200),
                (float)ODecimal.Validar(dr["NL_OrbitaCorreccionPerspectivaPuntoOrigenY4"], 0, int.MaxValue, 100));
            this.OffsetOrigen = new Point(
                OEntero.Validar(dr["NL_OrbitaCorreccionPerspectivaOffsetOrigenX"], 0, int.MaxValue, 0),
                OEntero.Validar(dr["NL_OrbitaCorreccionPerspectivaOffsetOrigenY"], 0, int.MaxValue, 0));
            this.AreaDestino = new Rectangle(
                OEntero.Validar(dr["NL_OrbitaCorreccionPerspectivaAreaDestinoX"], 0, int.MaxValue, 0),
                OEntero.Validar(dr["NL_OrbitaCorreccionPerspectivaAreaDestinoY"], 0, int.MaxValue, 0),
                OEntero.Validar(dr["NL_OrbitaCorreccionPerspectivaAreaDestinoAncho"], 1, int.MaxValue, 0),
                OEntero.Validar(dr["NL_OrbitaCorreccionPerspectivaAreaDestinoAlto"], 1, int.MaxValue, 0));
        }
        #endregion
    }
}
