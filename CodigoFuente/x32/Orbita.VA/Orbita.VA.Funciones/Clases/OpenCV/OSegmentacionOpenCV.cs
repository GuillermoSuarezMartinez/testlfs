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
using Orbita.Utiles;

namespace Orbita.VA.Funciones
{
    public static class OSegmentacionOpenCV
    {
        #region Método(s) privado(s)
        /// <summary>
        /// Búsqueda de edges
        /// </summary>
        /// <param name="input"></param>
        /// <param name="origen"></param>
        /// <param name="extremoX"></param>
        /// <param name="extremoY"></param>
        /// <param name="numCalipers"></param>
        /// <param name="kernel"></param>
        /// <param name="anchuraEsperada"></param>
        /// <param name="threshold"></param>
        /// <param name="matrizConversionCoordenadas"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        private static bool BuscarEdges(OImagenOpenCVMonocromo<byte> input, PointF origen, PointF extremoX, PointF extremoY, int numCalipers, FilterSize kernel, double anchuraEsperada, double threshold, out Matrix<float> matrizConversionCoordenadas, out List<OEdgeResult> edges)
        {
            edges = new List<OEdgeResult>();

            if (origen.X >= input.Width || extremoX.X >= input.Width || extremoY.X >= input.Width || origen.Y >= input.Height || extremoX.Y >= input.Height || extremoY.Y >= input.Height)
            {
                throw new ArgumentException("Alguno de los puntos pasados a la función FindLine, se encuentran fuera de la imagen");
            }

            //Declaración de herramientas necesarias
            OrbitaCaliper item;

            //Proyección del área de búsqueda
            matrizConversionCoordenadas = new Matrix<float>(2, 3);
            OImagenOpenCVMonocromo<byte> proyeccion = new OImagenOpenCVMonocromo<byte>();
            proyeccion.Image = input.Proyeccion(origen, extremoX, extremoY, out matrizConversionCoordenadas).Image;
            matrizConversionCoordenadas = OHerramientasOpenCV.Invertir(matrizConversionCoordenadas);

            float caliperHeight = proyeccion.Height / numCalipers;

            PointF origenC;
            PointF extremoXC;
            PointF extremoYC;

            List<PointF> ptos = new List<PointF>();

            for (int i = 0; i < numCalipers; i++)
            {
                item = new OrbitaCaliper(PolaridadEdges.NegroBlanco, PolaridadEdges.BlancoNegro, kernel, 1);
                item.EliminarMetodosPuntuacion();
                item.AgregarContraste(0, (int)kernel * 255, 0, 1, 0);
                item.AgregarDistancia(anchuraEsperada, 0, 1, 0, 1, 0);

                float despY = i * caliperHeight;

                origenC = new PointF(0, despY);
                extremoXC = new PointF(proyeccion.Width, despY);
                extremoYC = new PointF(0, despY + caliperHeight);

                List<OEdgeResult> edgesIteracion = item.BuscarEdges(proyeccion, origenC, extremoXC, extremoYC, threshold);

                if (edgesIteracion.Count > 0)
                {
                    edges.Add(edgesIteracion[0]);
                }
            }

            proyeccion.Dispose();

            return edges.Count > 0;
        }

        /// <summary>
        /// Cálculo de la línea de tendencia
        /// </summary>
        /// <param name="ptos"></param>
        /// <param name="origen"></param>
        /// <param name="extremoY"></param>
        /// <param name="numPuntosDescartar"></param>
        /// <param name="distanciaDescarte"></param>
        /// <returns></returns>
        private static OLinea CalculoLineaTendencia(List<PointF> ptos, PointF origen, PointF extremoY, int numPuntosDescartar, double distanciaDescarte, out double desviacionEstandar)
        {
            double M, B;

            // Cálculo de la línea de tendencia
            OMath.CalculoLineaMinimosCuadrados(ptos, numPuntosDescartar, distanciaDescarte, out M, out B, out desviacionEstandar);
            PointF start = new PointF(extremoY.X, (float)(extremoY.X * M + B));
            PointF end = new PointF(origen.X, (float)(origen.X * M + B));
            return new OLinea(start, end);
        }
        #endregion

        #region Método(s) público(s)
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
        public static OLinea FindLaserLine(this OImagenOpenCVMonocromo<byte> input, PointF origen, PointF extremoX, PointF extremoY, int numCalipers, FilterSize kernel, double anchuraEsperada, double threshold, int numPuntosDescartar, double distanciaDescarte)
        {
            // Cálculo de los edges
            Matrix<float> mat;
            List<OEdgeResult> edges;
            bool ok = BuscarEdges(input, origen, extremoX, extremoY, numCalipers, kernel, anchuraEsperada, threshold, out mat, out edges);

            // Cálculo de los centros
            List<PointF> ptos = new List<PointF>();
            if (edges.Count > 0)
            {
                foreach (OEdgeResult edge in edges)
                {
                    float x = (edge.Edge1.X + edge.Edge2.X) / 2;
                    float y = (edge.Edge1.Y + edge.Edge2.Y) / 2;

                    ptos.Add(OHerramientasOpenCV.Proyeccion(new PointF(x, y), mat));
                }
            }

            // Cálculo de la línea de tendencia
            double desviacionEstandar;
            return CalculoLineaTendencia(ptos, origen, extremoY, numPuntosDescartar, distanciaDescarte, out desviacionEstandar);
        }

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
        public static OLinea FindLaserLine(this OImagenOpenCVMonocromo<byte> input, PointF origen, PointF extremoX, PointF extremoY, int numCalipers, FilterSize kernel, double anchuraEsperada, double threshold, int numPuntosDescartar, double distanciaDescarte, ref OGraficoOpenCV grafico, Color color)
        {
            OLinea lineaCentro = null;
            OLinea lineaSup = null;
            OLinea lineaInf = null;
            double desviacionEstCentro;
            double desviacionEstSup;
            double desviacionEstInf;

            FindLaserLine(input, origen, extremoX, extremoY, numCalipers, kernel, anchuraEsperada, threshold, numPuntosDescartar, distanciaDescarte, out lineaCentro, out desviacionEstCentro, out lineaSup, out desviacionEstSup, out lineaInf, out desviacionEstInf, ref grafico, color);

            OLinea linea = null;

            // Me quedo con la línea de menor desviación estandar
            if ((desviacionEstCentro <= desviacionEstSup) && (desviacionEstCentro <= desviacionEstInf))
            {
                linea = lineaCentro;                
            }
            else if (desviacionEstSup <= desviacionEstInf)
            {
                linea = lineaSup;
            }
            else
            {
                linea = lineaInf;
            }

            return linea;
        }

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
        public static void FindLaserLine(this OImagenOpenCVMonocromo<byte> input, PointF origen, PointF extremoX, PointF extremoY, int numCalipers, FilterSize kernel, double anchuraEsperada, double threshold, int numPuntosDescartar, double distanciaDescarte, out OLinea lineaCentro, out double desviacionEstCentro, out OLinea lineaSup, out double desviacionEstSup, out OLinea lineaInf, out double desviacionEstInf, ref OGraficoOpenCV grafico, Color color)
        {
            lineaCentro = null;
            lineaSup = null;
            lineaInf = null;
            desviacionEstCentro = 0;
            desviacionEstSup = 0;
            desviacionEstInf = 0;

            float anchoEdgePintar = ((extremoX.X - origen.X) / numCalipers) / 4;

            // Cálculo de los edges
            Matrix<float> mat;
            List<OEdgeResult> edges;
            bool ok = BuscarEdges(input, origen, extremoX, extremoY, numCalipers, kernel, anchuraEsperada, threshold, out mat, out edges);

            if (edges.Count > 0)
            {
                List<PointF> ptosCentro = new List<PointF>();
                List<PointF> ptosSup = new List<PointF>();
                List<PointF> ptosInf = new List<PointF>();
                float x, y;
                PointF pto;

                foreach (OEdgeResult edge in edges)
                {
                    // Cálculo de los centros
                    x = (edge.Edge1.X + edge.Edge2.X) / 2;
                    y = (edge.Edge1.Y + edge.Edge2.Y) / 2;

                    pto = OHerramientasOpenCV.Proyeccion(new PointF(x, y), mat);
                    ptosCentro.Add(pto);
                    if (grafico is OGraficoOpenCV)
                    {
                        grafico.Linea(pto.X - anchoEdgePintar, pto.Y, pto.X + anchoEdgePintar, pto.Y, color, 1);
                    }

                    // Cálculo de los superiores
                    x = edge.Edge1.X;
                    y = edge.Edge1.Y;

                    pto = OHerramientasOpenCV.Proyeccion(new PointF(x, y), mat);
                    ptosSup.Add(pto);
                    if (grafico is OGraficoOpenCV)
                    {
                        grafico.Linea(pto.X - anchoEdgePintar, pto.Y, pto.X + anchoEdgePintar, pto.Y, color, 1);
                    }

                    // Cálculo de los inferiores
                    x = edge.Edge2.X;
                    y = edge.Edge2.Y;

                    pto = OHerramientasOpenCV.Proyeccion(new PointF(x, y), mat);
                    ptosInf.Add(pto);
                    if (grafico is OGraficoOpenCV)
                    {
                        grafico.Linea(pto.X - anchoEdgePintar, pto.Y, pto.X + anchoEdgePintar, pto.Y, color, 1);
                    }
                }

                // Calculo línea de tendencia del centro
                lineaCentro = CalculoLineaTendencia(ptosCentro, origen, extremoY, numPuntosDescartar, distanciaDescarte, out desviacionEstCentro);
                if (grafico is OGraficoOpenCV)
                {
                    grafico.Linea(lineaCentro.Punto1, lineaCentro.Punto2, color, 1);
                }

                // Calculo línea de tendencia superior
                lineaSup = CalculoLineaTendencia(ptosSup, origen, extremoY, numPuntosDescartar, distanciaDescarte, out desviacionEstSup);
                if (grafico is OGraficoOpenCV)
                {
                    grafico.Linea(lineaSup.Punto1, lineaSup.Punto2, color, 1);
                }

                // Calculo línea de tendencia inferior
                lineaInf = CalculoLineaTendencia(ptosInf, origen, extremoY, numPuntosDescartar, distanciaDescarte, out desviacionEstInf);
                if (grafico is OGraficoOpenCV)
                {
                    grafico.Linea(lineaInf.Punto1, lineaInf.Punto2, color, 1);
                }
            }

        }
        #endregion

        // Comentado
        ///// <summary>
        ///// Encuentra una línea en una imagen
        ///// </summary>
        ///// <param name="input">Imagen de entrada</param>
        ///// <param name="origen">Punto de origen</param>
        ///// <param name="extremoX">Extremo hasta el cual buscar la línea</param>
        ///// <param name="extremoY">Eje a lo largo del cual se desplaza la línea</param>
        ///// <param name="numCalipers">Número de objetos OrbitaCaliper a utilizar (puntos para el dibujado de la línea)</param>
        ///// <param name="kernel">Filtro para los OrbitaCaliper</param>
        ///// <returns></returns>
        //public static OLinea FindLaserLine(this OImagenOpenCVMonocromo<byte> input, PointF origen, PointF extremoX, PointF extremoY, int numCalipers, FilterSize kernel, double anchuraEsperada, double threshold, int numPuntosDescartar, double distanciaDescarte, out OLinea lineaSup, out OLinea lineaInf, out OImagenOpenCVMonocromo<byte> grafico)
        //{
        //    lineaSup = null;
        //    lineaInf = null;
        //    grafico = null;

        //    if (origen.X >= input.Width || extremoX.X >= input.Width || extremoY.X >= input.Width || origen.Y >= input.Height || extremoX.Y >= input.Height || extremoY.Y >= input.Height)
        //    {
        //        throw new ArgumentException("Alguno de los puntos pasados a la función FindLine, se encuentran fuera de la imagen");
        //    }

        //    //Declaración de herramientas necesarias
        //    OrbitaCaliper item;

        //    //Proyección del área de búsqueda
        //    Matrix<float> mat = new Matrix<float>(2, 3);
        //    OImagenOpenCVMonocromo<byte> proyeccion = new OImagenOpenCVMonocromo<byte>();
        //    proyeccion.Image = input.Proyeccion(origen, extremoX, extremoY, out mat).Image;
        //    mat = OHerramientasOpenCV.Invertir(mat);

        //    float caliperHeight = proyeccion.Height / numCalipers;

        //    PointF origenC;
        //    PointF extremoXC;
        //    PointF extremoYC;

        //    List<PointF> ptos = new List<PointF>();

        //    for (int i = 0; i < numCalipers; i++)
        //    {
        //        item = new OrbitaCaliper(PolaridadEdges.NegroBlanco, PolaridadEdges.BlancoNegro, anchuraEsperada, kernel, 1);
        //        item.EliminarMetodosPuntuacion();
        //        item.AgregarContraste();

        //        float despY = i * caliperHeight;

        //        origenC = new PointF(0, despY);
        //        extremoXC = new PointF(proyeccion.Width, despY);
        //        extremoYC = new PointF(0, despY + caliperHeight);

        //        List<OEdgeResult> edges = item.BuscarEdges(proyeccion, origenC, extremoXC, extremoYC, threshold);
        //        //OImagenOpenCVColor<byte> res = item.PintarEdges(Color.LightGreen, 1);

        //        if (edges.Count > 0)
        //        {
        //            float x = (edges[0].Edge1.X + edges[0].Edge2.X) / 2;
        //            float y = (edges[0].Edge1.Y + edges[0].Edge2.Y) / 2;

        //            ptos.Add(OHerramientasOpenCV.Proyeccion(new PointF(x, y), mat));
        //        }
        //    }
        //    if (ptos.Count == 0)
        //    {
        //        throw new AnalisisException("No se encontraron puntos para construir la línea");
        //    }

        //    double M, B;
        //    OMath.CalculoLineaMinimosCuadrados(ptos, numPuntosDescartar, distanciaDescarte, out M, out B);
        //    PointF start = new PointF(extremoY.X, (float)(extremoY.X * M + B));
        //    PointF end = new PointF(origen.X, (float)(origen.X * M + B));

        //    proyeccion.Dispose();

        //    return new OLinea(start, end);
        //}
    }
}
