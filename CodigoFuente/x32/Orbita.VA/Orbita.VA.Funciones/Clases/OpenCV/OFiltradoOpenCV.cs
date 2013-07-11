//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : jbelenguer
// Created          : 02-05-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************

using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Orbita.VA.Comun;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase estática con herramientas de OpenCV
    /// </summary>
    public static class OFiltradoOpenCV
    {
        #region Corrección de perspectiva
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
        public static OImagenOpenCV<TColor, TDepth> CorregirPerspectiva<TColor, TDepth>(this OImagenOpenCV<TColor, TDepth> imagenOriginal, PointF puntoOriginal1, PointF puntoOriginal2, PointF puntoOriginal3, PointF puntoOriginal4, PointF puntoDestino1, PointF puntoDestino2, PointF puntoDestino3, PointF puntoDestino4)
            where TColor : struct, global::Emgu.CV.IColor
            where TDepth : new()
        {
            OImagenOpenCV<TColor, TDepth> resultado = null;

            try
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
                resultado = new OImagenOpenCV<TColor, TDepth>(imagenOriginal.Codigo, img);
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.OpenCV.Error(exception, "Corección Distorsión");
            }

            return resultado;
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
        public static OImagenOpenCV<TColor, TDepth> CorregirPerspectiva<TColor, TDepth>(this OImagenOpenCV<TColor, TDepth> imagenOriginal, PointF puntoOriginal1, PointF puntoOriginal2, PointF puntoOriginal3, PointF puntoOriginal4, float xDestino, float yDestino, float anchoDestino, float altoDestino)
            where TColor : struct, global::Emgu.CV.IColor
            where TDepth : new()
        {
            PointF puntoDestino1 = new PointF(xDestino, yDestino);
            PointF puntoDestino2 = new PointF(xDestino + anchoDestino, yDestino + 0);
            PointF puntoDestino3 = new PointF(xDestino + anchoDestino, yDestino + altoDestino);
            PointF puntoDestino4 = new PointF(xDestino + 0, yDestino + altoDestino);

            return CorregirPerspectiva<TColor, TDepth>(imagenOriginal, puntoOriginal1, puntoOriginal2, puntoOriginal3, puntoOriginal4, puntoDestino1, puntoDestino2, puntoDestino3, puntoDestino4);
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
        public static OImagenOpenCV<TColor, TDepth> CorregirPerspectiva<TColor, TDepth>(this OImagenOpenCV<TColor, TDepth> imagenOriginal, PointF puntoOriginal1, PointF puntoOriginal2, PointF puntoOriginal3, PointF puntoOriginal4, RectangleF areaDestino)
            where TColor : struct, global::Emgu.CV.IColor
            where TDepth : new()
        {
            float xDestino = areaDestino.X;
            float yDestino = areaDestino.Y;
            float anchoDestino = areaDestino.Width;
            float altoDestino = areaDestino.Height;

            return CorregirPerspectiva<TColor, TDepth>(imagenOriginal, puntoOriginal1, puntoOriginal2, puntoOriginal3, puntoOriginal4, xDestino, yDestino, anchoDestino, altoDestino);
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
        public static OImagenOpenCV<TColor, TDepth> CorregirPerspectiva<TColor, TDepth>(this OImagenOpenCV<TColor, TDepth> imagenOriginal, PointF puntoOriginal1, PointF puntoOriginal2, PointF puntoOriginal3, PointF puntoOriginal4, Point offsetMarco, RectangleF areaDestino)
            where TColor : struct, global::Emgu.CV.IColor
            where TDepth : new()
        {
            OImagenOpenCV<TColor, TDepth> imgResultado = null;

            // Ampliación del lienzo
            OImagenOpenCV<TColor, TDepth> imgAmpliada = imagenOriginal.CrearBorde(offsetMarco.X, offsetMarco.Y);

            // Actualización puntos de referencia en la imagen original
            PointF puntoOriginal1Offset = new PointF(puntoOriginal1.X + offsetMarco.X, puntoOriginal1.Y + offsetMarco.Y);
            PointF puntoOriginal2Offset = new PointF(puntoOriginal2.X + offsetMarco.X, puntoOriginal2.Y + offsetMarco.Y);
            PointF puntoOriginal3Offset = new PointF(puntoOriginal3.X + offsetMarco.X, puntoOriginal3.Y + offsetMarco.Y);
            PointF puntoOriginal4Offset = new PointF(puntoOriginal4.X + offsetMarco.X, puntoOriginal4.Y + offsetMarco.Y);

            // Corrección de perspectiva
            imgResultado = imgAmpliada.CorregirPerspectiva(puntoOriginal1Offset, puntoOriginal2Offset, puntoOriginal3Offset, puntoOriginal4Offset, areaDestino);
            //imgResultado = imgAmpliada;
            
            imgAmpliada.Dispose();

            return imgResultado;
        }
        #endregion

        #region Crear Borde
        public static OImagenOpenCV<TColor, TDepth> CrearBorde<TColor, TDepth>(this OImagenOpenCV<TColor, TDepth> imagenOriginal, int offsetX, int OffsetY)
            where TColor : struct, global::Emgu.CV.IColor
            where TDepth : new()
        {
            OImagenOpenCV<TColor, TDepth> resultado = null;

            try
            {
                int ancho = imagenOriginal.Width;
                int alto = imagenOriginal.Height;

                Emgu.CV.Image<TColor, TDepth> imgOriginal = imagenOriginal.Image;
                Emgu.CV.Image<TColor, TDepth> imgResult = new Emgu.CV.Image<TColor, TDepth>(ancho + offsetX, alto + OffsetY, default(TColor));
                Emgu.CV.CvInvoke.cvCopyMakeBorder(imgOriginal.Ptr, imgResult.Ptr, new Point(offsetX, OffsetY), Emgu.CV.CvEnum.BORDER_TYPE.CONSTANT, new Emgu.CV.Structure.MCvScalar(0));
                resultado = new OImagenOpenCV<TColor, TDepth>(imagenOriginal.Codigo, imgResult);
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.OpenCV.Error(exception, "Cambio tamaño lienzo");
            }

            return resultado;
        }
        #endregion

        #region Obtención de datos
        /// <summary>
        /// Obtiene el plano (del espacio BGR) pasado como parámetro
        /// </summary>
        /// <param name="input">Imagen de entrada</param>
        /// <param name="plano">Plano a extraer</param>
        /// <returns>Plano de la imagen indicado</returns>
        public static OImagenOpenCVMonocromo<TDepth> ObtenerPlano<TDepth>(this OImagenOpenCVColor<TDepth> input, OPlanoBGR plano)
            where TDepth : new()
        {
            OImagenOpenCVMonocromo<TDepth> resultado = new OImagenOpenCVMonocromo<TDepth>();

            //Descomponemos la imagen de entrada
            resultado.Image = input.Image.Split()[(int)plano];

            return resultado;
        }

        /// <summary>
        /// Calcula la media de los contrastes de la imagen obteniendo una única fila
        /// </summary>
        /// <param name="input">Imagen de origen</param>
        /// <returns>Estructura imagen con una única fila que almacena los valores de contraste medios</returns>
        public static OImagenOpenCVMonocromo<float> Reducir<TDepth>(this OImagenOpenCVMonocromo<TDepth> input)
            where TDepth : new()
        {
            OImagenOpenCVMonocromo<float> resultado = new OImagenOpenCVMonocromo<float>();
            Image<Gray, float> imgRes = new Image<Gray, float>(input.Width, 1);

            ((Image<Gray, TDepth>)input.Image).Reduce(imgRes, REDUCE_DIMENSION.SINGLE_ROW, REDUCE_TYPE.CV_REDUCE_AVG);
            resultado.Image = imgRes;

            return resultado;
        }
        #endregion

        #region Filtros
        /// <summary>
        /// Binariza una imagen utilizando un umbral
        /// </summary>
        /// <param name="input">Imagen de entrada</param>
        /// <param name="umbral">Umbral de binarización</param>
        /// <returns></returns>
        public static OImagenOpenCVMonocromo<byte> Binarizar<TDepth>(this OImagenOpenCVColor<TDepth> input, int umbral)
            where TDepth : new()
        {
            //Copiamos la imagen
            //Image<Gray, byte> resultOpenCV = new Image<Gray, byte>(input.ConvertToBitmap());
            Image<Gray, byte> resultOpenCV = input.Image.Convert<Gray, byte>();

            //Filtramos
            OImagenOpenCVMonocromo<byte> result = new OImagenOpenCVMonocromo<byte>();
            result.Image = resultOpenCV.ThresholdBinary(new Gray(umbral), new Gray(255));

            return result;
        }

        public static OImagenOpenCVMonocromo<byte> Dilatar(this OImagenOpenCVMonocromo<byte> input, int iteraciones)
        {
            //Filtrado
            OImagenOpenCVMonocromo<byte> result = new OImagenOpenCVMonocromo<byte>();
            result.Image = ((Image<Gray, byte>)input.Image).Dilate(iteraciones);

            return result;
        }
        #endregion

        #region Proyecciones
        /// <summary>
        /// Realiza una proyección de un area de la imagen en un rectangulo
        /// </summary>
        /// <typeparam name="TColor">Espacio de color</typeparam>
        /// <typeparam name="TDepth">Profundidad de color</typeparam>
        /// <param name="input">Imagen sobre la que se hace la proyección</param>
        /// <param name="puntoO">Punto de origen de la proyección</param>
        /// <param name="puntoX">Punto extremo en ancho de la proyección</param>
        /// <param name="puntoY">Punto extremo en alto de la proyección</param>
        /// <returns>Proyección rectangular del area especificada</returns>
        public static OImagenOpenCV<TColor, TDepth> Proyeccion<TColor, TDepth>(this OImagenOpenCV<TColor, TDepth> input, PointF puntoO, PointF puntoX, PointF puntoY)
            where TColor : struct, global::Emgu.CV.IColor
            where TDepth : new()
        {
            Matrix<float> sourceMat = new Matrix<float>(2, 3);
            OImagenOpenCV<TColor, TDepth> resultado = new OImagenOpenCV<TColor, TDepth>();
            resultado.Image = input.Proyeccion(puntoO, puntoX, puntoY, out sourceMat).Image;
            return resultado;
        }
        /// <summary>
        /// Realiza una proyección de un area de la imagen en un rectangulo
        /// </summary>
        /// <typeparam name="TColor">Espacio de color</typeparam>
        /// <typeparam name="TDepth">Profundidad de color</typeparam>
        /// <param name="input">Imagen sobre la que se hace la proyección</param>
        /// <param name="sourceMat">Matriz de transformación a utilizar en la transformación</param>
        /// <returns>Proyección rectangular del area especificada</returns>
        public static OImagenOpenCV<TColor, TDepth> Proyeccion<TColor, TDepth>(this OImagenOpenCV<TColor, TDepth> input, Matrix<float> sourceMat, bool inversa = false)
            where TColor : struct, global::Emgu.CV.IColor
            where TDepth : new()
        {
            OImagenOpenCV<TColor, TDepth> result = new OImagenOpenCV<TColor, TDepth>();

            //Aplicación de la transformación
            result.Image = input.Image.WarpAffine<float>(sourceMat, INTER.CV_INTER_NN, (inversa ? WARP.CV_WARP_INVERSE_MAP : WARP.CV_WARP_DEFAULT), default(TColor));

            return result;
        }
        /// <summary>
        /// Realiza una proyección de un area de la imagen en un rectangulo, devolviendo la matriz de transformación utilizada
        /// </summary>
        /// <typeparam name="TColor">Espacio de color</typeparam>
        /// <typeparam name="TDepth">Profundidad de color</typeparam>
        /// <param name="input">Imagen sobre la que se hace la proyección</param>
        /// <param name="puntoO">Punto de origen de la proyección</param>
        /// <param name="puntoX">Punto extremo en ancho de la proyección</param>
        /// <param name="puntoY">Punto extremo en alto de la proyección</param>
        /// <param name="sourceMat">Matriz de transformación utilizada para realiar la proyección. Sirve para deshacer la proyección</param>
        /// <returns>Proyección rectangular del area especificada</returns>
        internal static OImagenOpenCV<TColor, TDepth> Proyeccion<TColor, TDepth>(this OImagenOpenCV<TColor, TDepth> input, PointF puntoO, PointF puntoX, PointF puntoY, out Matrix<float> sourceMat)
            where TColor : struct, global::Emgu.CV.IColor
            where TDepth : new()
        {
            if (puntoO.X > input.Width || puntoX.X > input.Width || puntoY.X > input.Width || puntoO.Y > input.Height || puntoX.Y > input.Height || puntoY.Y > input.Height)
            {
                throw new ArgumentException("Alguno de los puntos pasados a la función Proyeccion, se encuentran fuera del rango de la imagen de entrada");
            }

            OImagenOpenCV<TColor, TDepth> resultado = null;

            PointF[] srcTri = { puntoO, puntoX, puntoY };
            double width, height;

            //Cálculo de ancho del área de proyección
            if (puntoO.X == puntoX.X)
            {
                width = Math.Abs(puntoX.Y - puntoO.Y);
            }
            else if (puntoO.Y == puntoX.Y)
            {
                width = Math.Abs(puntoX.X - puntoO.X);
            }
            else
            {
                width = Math.Sqrt(Math.Pow(puntoX.X - puntoO.X, 2) + Math.Pow(puntoX.Y - puntoO.Y, 2));
            }

            //Cálculo del alto del área de proyección
            if (puntoO.Y == puntoY.Y)
            {
                height = Math.Abs(puntoY.X - puntoO.X);
            }
            else if (puntoO.X == puntoY.X)
            {
                height = Math.Abs(puntoY.Y - puntoO.Y);
            }
            else
            {
                //Cálculo de la pendiente
                double m = (puntoO.Y - puntoX.Y) / (puntoO.X - puntoX.X);

                //Cálculo de parámetros de las rectas paralelas
                double C = puntoY.Y - m * puntoY.X;
                double Cp = puntoO.Y - m * puntoO.X;


                height = Math.Abs(Cp - C) / Math.Sqrt(Math.Pow(m, 2) + 1);
            }

            //Puntos de destino
            PointF[] dstTri = {
                                new PointF(0, 0),
                                new PointF((float)width, 0),
                                new PointF(0, (float)height),
                            };

            //Creacion de la matriz de transformación (en el futuro se puede usar para deshacer la proyección)
            sourceMat = new Matrix<float>(2, 3);
            CvInvoke.cvGetAffineTransform(srcTri, dstTri, sourceMat.Ptr);

            //Aplicación de la transformación
            resultado = new OImagenOpenCV<TColor, TDepth>();
            resultado.Image = input.Image.WarpAffine<float>(sourceMat, (int)Math.Round(width), (int)Math.Round(height), INTER.CV_INTER_NN, WARP.CV_WARP_DEFAULT, default(TColor));
            return resultado;
        }
        #endregion
    }
}
