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

namespace Orbita.VA.Funciones.Clases.OpenCV.Herramientas.OrbitaCaliper
{
    /// <summary>
    /// Interfaz de puntuación de una variable
    /// </summary>
    interface OScoringFunction
    {
        /// <summary>
        /// Mapeo de una puntuación en crudo
        /// </summary>
        /// <param name="rawScore">Puntuación en crudo</param>
        /// <returns>Puntuación mapeada</returns>
        double MapScore(double rawScore);
    }
    /// <summary>
    /// Clase que implementa una función de puntuación simple
    /// </summary>
    public class SingleSideScoringFunction : OScoringFunction
    {
        #region Atributos
        private float x0;
        private float x1;
        private float xc;
        private float y0;
        private float y1;
        #endregion

        #region Propiedades
        public float X0
        {
            set { x0 = value; }
            get { return x0; }
        }
        public float X1
        {
            set { x1 = value; }
            get { return x1; }
        }
        public float Xc
        {
            set { xc = value; }
            get { return xc; }
        }
        public float Y0
        {
            set { y0 = value; }
            get { return y0; }
        }
        public float Y1
        {
            set { y1 = value; }
            get { return y1; }
        }
        public bool x0MayorXC
        {
            get { return (x0 > xc); }
        }
        #endregion

        /// <summary>
        /// Constructor de la clase, y0 e y1 deben encontrarse entre 0 y 1. X1 se debe encontrar entre Xc y X0
        /// </summary>
        /// <param name="xc">Valor límite entre devolver 0 o y1</param>
        /// <param name="x0">Valor límite entre devolver y1 o la función de puntuación</param>
        /// <param name="x1">Valor límite entre devolver la función de puntuación o devolver y0</param>
        /// <param name="y0">Puntuación máxima</param>
        /// <param name="y1">Puntuación mínima</param>
        public SingleSideScoringFunction(float xc, float x0, float x1, float y0, float y1)
        {
            if (y0 > 1 || y0 < 0)
            {
                throw new ArgumentException("El argumento debe encontrarse en el rango {0 - 1}", "Y0");
            }
            if (y1 > 1 || y1 < 0)
            {
                throw new ArgumentException("El argumento debe encontrarse en el rango {0 - 1}", "Y1");
            }
            if (x0 > xc && (x1 > x0 || x1 < xc))
            {
                throw new ArgumentException("Si X0 es mayor que Xc, entonces debe cumplirse Xc <= X1 < X0");
            }
            else if (x0 < xc && (x1 < x0 || x1 > xc))
            {
                throw new ArgumentException("Si X0 es menor que Xc, entonces debe cumplirse X0 < X1 <= Xc");
            }
            else if (x0 == xc && x0 != x1)
            {
                throw new ArgumentException("El argumento X1 debe encontrarse entre X0 y Xc", "X1");
            }

            this.xc = xc;
            this.x0 = x0;
            this.x1 = x1;
            this.y0 = y0;
            this.y1 = y1;
        }
        #region Métodos implementados
        /// <summary>
        /// Mapea un valor crudo según la función de puntuación definida
        /// </summary>
        /// <param name="rawScore">Valor crudo</param>
        /// <returns>Puntuación mapeada</returns>
        public double MapScore(double rawScore)
        {
            double scoreMapped;
            if (x0 > xc)
            {
                if (rawScore < xc)
                    scoreMapped = 0;
                else if (rawScore < x1)
                    scoreMapped = y1;
                else if (rawScore < x0)
                {
                    if ((x1 - x0) == 0)
                    {
                        scoreMapped = (y0 + y1) / 2;
                    }
                    else
                    {
                        scoreMapped = y0 + (rawScore - x0) * (y1 - y0) / (x1 - x0);
                    }
                }
                else
                    scoreMapped = y0;
            }
            else
            {
                if (rawScore > xc)
                    scoreMapped = 0;
                else if (rawScore > x1)
                    scoreMapped = y1;
                else if (rawScore > x0)
                {
                    if ((x1 - x0) == 0)
                    {
                        scoreMapped = (y0 + y1) / 2;
                    }
                    else
                    {
                        scoreMapped = y0 + (rawScore - x0) * (y1 - y0) / (x1 - x0);
                    }
                }
                else
                    scoreMapped = y0;
            }
            return scoreMapped;
        }
        #endregion
    }
    /// <summary>
    /// Clase que implementa una función de puntuación de dos lados
    /// </summary>
    public class TwoSidedScoringFunction : OScoringFunction
    {
        #region Atributos
        private SingleSideScoringFunction functionSmaller;
        private SingleSideScoringFunction functionBigger;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="xcs">Parámetro Xc de la parte izquierda</param>
        /// <param name="x0s">Parámetro X0 de la parte izquierda</param>
        /// <param name="x1s">Parámetro X1 de la parte izquierda</param>
        /// <param name="y0"> Parámetro Y0 de la parte izquierda</param>
        /// <param name="y1"> Parámetro Y1 de la parte izquierda</param>
        /// <param name="xcb">Parámetro Xc de la parte derecha</param>
        /// <param name="x0b">Parámetro X0 de la parte derecha</param>
        /// <param name="x1b">Parámetro X1 de la parte derecha</param>
        /// <param name="y0h">Parámetro Y0 de la parte derecha</param>
        /// <param name="y1h">Parámetro Y1 de la parte derecha</param>
        public TwoSidedScoringFunction(float xcs, float x0s, float x1s, float y0, float y1, float xcb, float x0b, float x1b, float y0h, float y1h)
        {
            if (xcb < xcs || x0b < x0s)
            {
                throw new ArgumentException("Los argumentos no son válidos. Xcb, X1b y X0b deben ser mayores que sus respectivos Xcs, X1s y X0s");
            }
            functionSmaller = new SingleSideScoringFunction(xcs, x0s, x1s, y0, y1);
            functionBigger = new SingleSideScoringFunction(xcb, x0b, x1b, y0h, y1h);
        }

        #region Métodos implementados
        /// <summary>
        /// Mapea un valor crudo según una función de puntuación
        /// 
        /// If the edge pattern candidate is exactly the same size as the edge model, the raw score must be 0.0; 
        /// if the edge pattern candidate is smaller than the edge model, the raw score must be less than 0; 
        /// if the edge pattern candidate is larger than the edge model, the raw score must be greater than 0.
        /// </summary>
        /// <param name="rawScore">Puntuación a mapear</param>
        /// <returns>Puntuación mapeada</returns>
        public double MapScore(double rawScore)
        {
            if (rawScore < 0)
            {
                return functionSmaller.MapScore(rawScore);
            }
            else
            {
                return functionBigger.MapScore(rawScore);
            }
        }
        #endregion
    }
}
