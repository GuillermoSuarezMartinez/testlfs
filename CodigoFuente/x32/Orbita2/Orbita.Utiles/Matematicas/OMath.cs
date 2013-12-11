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
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

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
        /// <summary>
        /// Calcula los parámetros m y b tal que y=m*x+b de la línea que más se aproxima a la nube de puntos pasada por parámetro
        /// No válido para líneas verticales!!!
        /// </summary>
        public static void CalculoLineaMinimosCuadrados(PointF[] nubePuntos, out double m, out double b)
        {
            List<PointF> listaNubePuntos = new List<PointF>(nubePuntos);
            CalculoLineaMinimosCuadrados(listaNubePuntos, out m, out b);
        }
        /// <summary>
        /// Calcula los parámetros m y b tal que y=m*x+b de la línea que más se aproxima a la nube de puntos pasada por parámetro.
        /// No válido para líneas verticales!!!
        /// </summary>
        public static void CalculoLineaMinimosCuadrados(PointF[] nubePuntos, int numPuntosDescartar, double distanciaDescarte, out double m, out double b, out double desviacionEstandar)
        {
            List<PointF> listaNubePuntos = new List<PointF>(nubePuntos);
            CalculoLineaMinimosCuadrados(listaNubePuntos, numPuntosDescartar, distanciaDescarte, out m, out b, out desviacionEstandar);
        }
        /// <summary>
        /// Calcula los parámetros m y b tal que y=m*x+b de la línea que más se aproxima a la nube de puntos pasada por parámetro.
        /// No válido para líneas verticales!!!
        /// </summary>
        public static void CalculoLineaMinimosCuadrados(List<PointF> nubePuntos, out double m, out double b)
        {
            m = 0;
            b = 0;

            if (nubePuntos.Count > 0)
            {
                float Sum_X = 0;
                float Sum_Y = 0;
                float Sum_XxY = 0;
                float Sum_X2 = 0;
                foreach (PointF punto in nubePuntos)
                {
                    Sum_X = Sum_X + punto.X;
                    Sum_Y = Sum_Y + punto.Y;
                    Sum_XxY = Sum_XxY + (punto.X * punto.Y);
                    Sum_X2 = Sum_X2 + (punto.X * punto.X);
                }

                float den = (nubePuntos.Count * Sum_X2) - (Sum_X * Sum_X);
                float num_m = (nubePuntos.Count * Sum_XxY) - (Sum_X * Sum_Y);
                float num_b = (Sum_Y * Sum_X2) - (Sum_X * Sum_XxY);

                if (den != 0)
                {
                    m = num_m / den;
                    b = num_b / den;
                }
                else
                {
                    m = 0;
                    b = nubePuntos[0].X;
                }
            }
        }
        /// <summary>
        /// Calcula los parámetros m y b tal que y=m*x+b de la línea que más se aproxima a la nube de puntos pasada por parámetro.
        /// No válido para líneas verticales!!!
        /// </summary>
        public static void CalculoLineaMinimosCuadrados(List<PointF> nubePuntos, out double m, out double b, out double desviacionEstandar)
        {
            m = 0;
            b = 0;
            desviacionEstandar = 0;

            if (nubePuntos.Count > 0)
            {
                CalculoLineaMinimosCuadrados(nubePuntos, out m, out b);

                double sumaDistancia = 0;
                foreach (PointF punto in nubePuntos)
                {
                    PointF puntoDeLinea = new PointF(punto.X, (float)(m * punto.X + b));
                    sumaDistancia += Distancia(puntoDeLinea, punto);
                }
                desviacionEstandar = sumaDistancia / nubePuntos.Count;
            }
        }
        /// <summary>
        /// Calcula los parámetros m y b tal que y=m*x+b de la línea que más se aproxima a la nube de puntos pasada por parámetro.
        /// No válido para líneas verticales!!!
        /// </summary>
        public static void CalculoLineaMinimosCuadrados(List<PointF> nubePuntos, int numPuntosDescartar, double distanciaDescarte, out double m, out double b, out double desviacionEstandar)
        {
            m = 0;
            b = 0;
            desviacionEstandar = 0;

            if (nubePuntos.Count > 0)
            {
                double mProvisional;
                double bProvisional;
                CalculoLineaMinimosCuadrados(nubePuntos, out mProvisional, out bProvisional);

                if (numPuntosDescartar > 0)
                {
                    // Cálculo de distancias
                    Dictionary<PointF, double> distancias = new Dictionary<PointF, double>();
                    foreach (PointF punto in nubePuntos)
                    {
                        PointF puntoDeLinea = new PointF(punto.X, (float)(mProvisional * punto.X + bProvisional));
                        double distancia = Distancia(puntoDeLinea, punto);

                        distancias.Add(punto, distancia);
                    }

                    // Ordenación de las distancias
                    var puntosAEliminar = (from dist in distancias
                                           where dist.Value > distanciaDescarte
                                           orderby dist.Value descending
                                           select dist.Key).Take(numPuntosDescartar);

                    if (puntosAEliminar.Count() > 0)
                    {
                        foreach (PointF punto in puntosAEliminar)
                        {
                            distancias.Remove(punto);
                        }

                        List<PointF> nubePuntosFiltrada = distancias.Keys.ToList();
                        CalculoLineaMinimosCuadrados(nubePuntosFiltrada, out mProvisional, out bProvisional);
                    }
                }

                m = mProvisional;
                b = bProvisional;

                double sumaDistancia = 0;
                foreach (PointF punto in nubePuntos)
                {
                    PointF puntoDeLinea = new PointF(punto.X, (float)(m * punto.X + b));
                    sumaDistancia += Distancia(puntoDeLinea, punto);
                }
                desviacionEstandar = sumaDistancia / nubePuntos.Count;
            }
        }
        #endregion
    }
}