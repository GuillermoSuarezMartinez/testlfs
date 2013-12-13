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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.VA.Comun;
using System.Drawing;
using Emgu.CV;

namespace Orbita.VA.Funciones
{
    public static class OSegmentacionOpenCV
    {
        /// <summary>
        /// Encuentra una línea en una imagen
        /// </summary>
        /// <param name="input">Imagen de entrada</param>
        /// <param name="origen">Punto de origen</param>
        /// <param name="extremoX">Extremo hasta el cual buscar la línea</param>
        /// <param name="extremoY">Eje a lo largo del cual se desplaza la línea</param>
        /// <param name="numCalipers">Número de objetos OrbitaCaliper a utilizar (puntos para el dibujado de la línea)</param>
        /// <param name="kernel">Filtro para los OrbitaCaliper</param>
        /// <returns></returns>
        public static OLinea FindLine(this OImagenOpenCVMonocromo<byte> input, PointF origen, PointF extremoX, PointF extremoY, int numCalipers, FilterSize kernel)
        {
            if (origen.X >= input.Width || extremoX.X >= input.Width || extremoY.X >= input.Width || origen.Y >= input.Height || extremoX.Y >= input.Height || extremoY.Y >= input.Height)
            {
                throw new ArgumentException("Alguno de los puntos pasados a la función FindLine, se encuentran fuera de la imagen");
            }

            //Declaración de herramientas necesarias
            OrbitaCaliper item;

            //Proyección del área de búsqueda
            Matrix<float> mat = new Matrix<float>(2, 3);
            OImagenOpenCVMonocromo<byte> proyeccion = new OImagenOpenCVMonocromo<byte>();
            proyeccion.Image = input.Proyeccion(origen, extremoX, extremoY, out mat).Image;
            mat = OHerramientasOpenCV.Invertir(mat);

            float caliperHeight = proyeccion.Height / numCalipers;

            PointF origenC;
            PointF extremoXC;
            PointF extremoYC;

            List<PointF> ptos = new List<PointF>();

            for (int i = 0; i < numCalipers; i++)
            {
                item = new OrbitaCaliper(PolaridadEdges.NegroBlanco, PolaridadEdges.BlancoNegro, 10, 12, kernel, 1);
                item.EliminarMetodosPuntuacion();
                item.AgregarContraste();

                float despY = i * caliperHeight;

                origenC = new PointF(0, despY);
                extremoXC = new PointF(proyeccion.Width, despY);
                extremoYC = new PointF(0, despY + caliperHeight);

                List<OEdgeResult> edges = item.BuscarEdges(proyeccion, origenC, extremoXC, extremoYC);
                OImagenOpenCVColor<byte> res = item.PintarEdges(Color.LightGreen, 1);

                if (edges.Count > 0)
                {
                    float x = (edges[0].Edge1.X + edges[0].Edge2.X) / 2;
                    float y = (edges[0].Edge1.Y + edges[0].Edge2.Y) / 2;

                    ptos.Add(OHerramientasOpenCV.Proyeccion(new PointF(x, y), mat));
                }
            }
            if (ptos.Count == 0)
            {
                throw new AnalisisException("No se encontraron puntos para construir la línea");
            }
            float Sum_X = 0;
            float Sum_Y = 0;
            float Sum_XxY = 0;
            float Sum_X2 = 0;
            foreach (PointF punto in ptos)
            {
                Sum_X = Sum_X + punto.X;
                Sum_Y = Sum_Y + punto.Y;
                Sum_XxY = Sum_XxY + (punto.X * punto.Y);
                Sum_X2 = Sum_X2 + (punto.X * punto.X);
            }

            float den = (ptos.Count * Sum_X2) - (Sum_X * Sum_X);
            float num_m = (ptos.Count * Sum_XxY) - (Sum_X * Sum_Y);
            float num_b = (Sum_Y * Sum_X2) - (Sum_X * Sum_XxY);

            double M, B;
            if (den != 0)
            {
                M = Math.Round(1000 * (num_m / den)) / 1000;
                B = Math.Round(1000 * (num_b / den)) / 1000;
            }
            else
            {
                B = ptos[0].X;
                M = 0;
            }
            PointF start = new PointF(extremoY.X, (float)(extremoY.X * M + B));
            PointF end = new PointF(origen.X, (float)(origen.X * M + B));

            return new OLinea(start, end);
        }
    }
}
