//***********************************************************************
// Assembly         : Orbita.Utiles
// Author           : aibañez
// Created          : 03-05-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Drawing;

namespace Orbita.Utiles
{
    /// <summary>
    /// Clase estática con métodos matemáticos
    /// </summary>
    public static class OMath
    {
        #region Ángulos
        /// <summary>
        /// Convierte un ángulo de grados a radianes
        /// </summary>
        /// <param name="angle">Ángulo en grados</param>
        /// <returns>Ángulo en radianes</returns>
        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
        /// <summary>
        /// Convierte un ángulo de radianes a grados
        /// </summary>
        /// <param name="angle">Ángulo en radianes</param>
        /// <returns>Ángulo en grados</returns>
        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }
        #endregion

        #region Métodos geometría
        /// <summary>
        /// Calcula el ángulo (en grados) entre 3 puntos (que definen dos rectas)
        /// </summary>
        /// <param name="punto a">end point</param>
        /// <param name="interseccion">Punto central</param>
        /// <param name="punto b">end point</param>
        /// <returns>angulo (0 a 180)</returns>
        public static double Angulo(PointF a, PointF interseccion, PointF b)
        {
            double result;

            // calculating the 3 distances
            double ai = Distancia(a, interseccion);
            double ib = Distancia(interseccion, b);
            double ab = Distancia(a, b);

            double cosB = Math.Pow(ab, 2) - Math.Pow(ai, 2) - Math.Pow(ib, 2);
            cosB = cosB / (2 * ai * ib);
            result = 180 - (Math.Acos(cosB) * 180 / Math.PI);

            return result;
        }
        /// <summary>
        /// Calcula la distancia euclídea entre dos puntos
        /// </summary>
        /// <param name="a">Punto de origen</param>
        /// <param name="b">Punto de destino</param>
        /// <returns>Distancia entre los puntos</returns>
        public static double Distancia(PointF a, PointF b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }
        #endregion
    }
}