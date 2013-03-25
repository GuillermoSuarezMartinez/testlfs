//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : aibañez
// Created          : 25-03-2013
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
using Emgu.CV;
using Orbita.VA.Comun;
using System.Drawing;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase estática con herramientas de OpenCV
    /// </summary>
    public static class OHerramientasOpenCV
    {
        #region Corrección de distorsión
        /// <summary>
        /// Corección de distorsión para imagenes de tipo OpenCV
        /// </summary>
        /// <typeparam name="TColor">Tipo de color de la imagen</typeparam>
        /// <typeparam name="TDepth">Tipo de profundidad de la imagen</typeparam>
        /// <param name="imagenOriginal">Imagen original</param>
        /// <param name="puntoOriginal1">Punto origen 1</param>
        /// <param name="puntoOriginal2">Punto origen 2</param>
        /// <param name="puntoOriginal3">Punto origen 3</param>
        /// <param name="puntoOriginal4">Punto origen 4</param>
        /// <param name="puntoDestino1">Punto destino 1</param>
        /// <param name="puntoDestino2">Punto destino 2</param>
        /// <param name="puntoDestino3">Punto destino 3</param>
        /// <param name="puntoDestino4">Punto destino 4</param>
        /// <returns></returns>
        public static OImagenOpenCV<TColor, TDepth> CorregirDistorsion<TColor, TDepth>(this OImagenOpenCV<TColor, TDepth> imagenOriginal, PointF puntoOriginal1, PointF puntoOriginal2, PointF puntoOriginal3, PointF puntoOriginal4, PointF puntoDestino1, PointF puntoDestino2, PointF puntoDestino3, PointF puntoDestino4)
            where TColor : struct, global::Emgu.CV.IColor
            where TDepth : new()
        {
            PointF[] srcs = new PointF[4];
            srcs[0] = puntoOriginal1;
            srcs[1] = puntoOriginal2;
            srcs[2] = puntoOriginal3;
            srcs[3] = puntoOriginal4;

            PointF[] dsts = new PointF[4];
            dsts[0] = puntoDestino1;
            dsts[1] = puntoDestino2;
            dsts[2] = puntoDestino3;
            dsts[3] = puntoDestino4;

            HomographyMatrix mywarpmat = CameraCalibration.GetPerspectiveTransform(srcs, dsts);
            Emgu.CV.Image<TColor, TDepth> img = imagenOriginal.Image.WarpPerspective(mywarpmat, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC, Emgu.CV.CvEnum.WARP.CV_WARP_DEFAULT, default(TColor));
            return new OImagenOpenCV<TColor, TDepth>(imagenOriginal.Codigo, img);
        }

        /// <summary>
        /// Corección de distorsión para imagenes de tipo OpenCV
        /// </summary>
        /// <typeparam name="TColor">Tipo de color de la imagen</typeparam>
        /// <typeparam name="TDepth">Tipo de profundidad de la imagen</typeparam>
        /// <param name="imagenOriginal">Imagen original</param>
        /// <param name="puntoOriginal1">Punto origen 1</param>
        /// <param name="puntoOriginal2">Punto origen 2</param>
        /// <param name="puntoOriginal3">Punto origen 3</param>
        /// <param name="puntoOriginal4">Punto origen 4</param>
        /// <param name="xDestino">Coordenada X destino</param>
        /// <param name="yDestino">Coordenada Y destino</param>
        /// <param name="anchoDestino">Ancho destino</param>
        /// <param name="altoDestino">Alto destino</param>
        /// <returns></returns>
        public static OImagenOpenCV<TColor, TDepth> CorregirDistorsion<TColor, TDepth>(this OImagenOpenCV<TColor, TDepth> imagenOriginal, PointF puntoOriginal1, PointF puntoOriginal2, PointF puntoOriginal3, PointF puntoOriginal4, float xDestino, float yDestino, float anchoDestino, float altoDestino)
            where TColor : struct, global::Emgu.CV.IColor
            where TDepth : new()
        {
            PointF puntoDestino1 = new PointF(xDestino, yDestino);
            PointF puntoDestino2 = new PointF(xDestino + anchoDestino, yDestino + 0);
            PointF puntoDestino3 = new PointF(xDestino + anchoDestino, yDestino + altoDestino);
            PointF puntoDestino4 = new PointF(xDestino + 0, yDestino + altoDestino);

            return CorregirDistorsion<TColor, TDepth>(imagenOriginal, puntoOriginal1, puntoOriginal2, puntoOriginal3, puntoOriginal4, puntoDestino1, puntoDestino2, puntoDestino3, puntoDestino4);
        }

        /// <summary>
        /// Corección de distorsión para imagenes de tipo OpenCV
        /// </summary>
        /// <typeparam name="TColor">Tipo de color de la imagen</typeparam>
        /// <typeparam name="TDepth">Tipo de profundidad de la imagen</typeparam>
        /// <param name="imagenOriginal">Imagen original</param>
        /// <param name="puntoOriginal1">Punto origen 1</param>
        /// <param name="puntoOriginal2">Punto origen 2</param>
        /// <param name="puntoOriginal3">Punto origen 3</param>
        /// <param name="puntoOriginal4">Punto origen 4</param>
        /// <param name="areaDestino">Area destino</param>
        /// <returns></returns>
        public static OImagenOpenCV<TColor, TDepth> CorregirDistorsion<TColor, TDepth>(this OImagenOpenCV<TColor, TDepth> imagenOriginal, PointF puntoOriginal1, PointF puntoOriginal2, PointF puntoOriginal3, PointF puntoOriginal4, RectangleF areaDestino)
            where TColor : struct, global::Emgu.CV.IColor
            where TDepth : new()
        {
            float xDestino = areaDestino.X;
            float yDestino = areaDestino.Y; 
            float anchoDestino = areaDestino.Width;
            float altoDestino = areaDestino.Height;

            return CorregirDistorsion<TColor, TDepth>(imagenOriginal, puntoOriginal1, puntoOriginal2, puntoOriginal3, puntoOriginal4, xDestino, yDestino, anchoDestino, altoDestino);
        } 

        #endregion

        #region Cambio del tamaño del lienzo
        public static OImagenOpenCV<TColor, TDepth> CambioTamañoLienzo<TColor, TDepth>(this OImagenOpenCV<TColor, TDepth> imagenOriginal, int offsetX, int OffsetY, int anchoDestino, int altoDestino)
            where TColor : struct, global::Emgu.CV.IColor
            where TDepth : new()
        {
            Emgu.CV.Image<TColor, TDepth> imgResut = new Image<TColor,TDepth>(anchoDestino, altoDestino, default(TColor));
            imgResut.ROI = new Rectangle( offsetX, OffsetY, anchoDestino, altoDestino);
            imagenOriginal.Image.CopyTo(imgResut);

            return new OImagenOpenCV<TColor, TDepth>(imagenOriginal.Codigo, imgResut);
        }
        
        #endregion
    }
}
