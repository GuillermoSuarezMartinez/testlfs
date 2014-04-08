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
using Emgu.CV.Util;
using Emgu.CV.CvEnum;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase estática con herramientas de OpenCV
    /// </summary>
    public static class OHerramientasOpenCV
    {
        #region Cambio de coordenadas
        /// <summary>
        /// Devuelve la inversa de una matriz (si la matriz no tiene inversa o no es cuadrada devuelve una matriz 0)
        /// </summary>
        /// <param name="sourceMat">Matriz a invertir</param>
        /// <returns>Matriz inversa</returns>
        public static Matrix<float> Invertir(Matrix<float> sourceMat)
        {
            Matrix<float> third = new Matrix<float>(1, 3);
            third[0, 2] = 1;
            sourceMat = sourceMat.ConcateVertical(third);
            Matrix<float> destMat = new Matrix<float>(sourceMat.Size);

            try
            {
                CvInvoke.cvInvert(sourceMat, destMat, SOLVE_METHOD.CV_LU);
            }
            catch (CvException)
            {
                destMat.SetZero();
            }
            return destMat;
        }
        /// <summary>
        /// Devuelve las coordenadas de un punto al aplicar una transformación
        /// </summary>
        /// <param name="input">Coordenadas de origen</param>
        /// <param name="sourceMat">Matriz de transformación</param>
        /// <returns>Coordenadas en destino</returns>
        public static PointF Proyeccion(PointF input, Matrix<float> sourceMat)
        {
            Matrix<float> point = new Matrix<float>(3, 1);
            point[0, 0] = input.X;
            point[1, 0] = input.Y;
            point[2, 0] = 1;

            point = sourceMat.Mul(point);

            return new PointF(point[0, 0], point[1, 0]);
        }
        #endregion
    }
}
