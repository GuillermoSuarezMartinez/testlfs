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
using System.Drawing;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Implementa el resultado de una detección de edges por parte de OrbitaCaliper
    /// </summary>
    public class OEdgeResult
    {
        #region Atributos
        /// <summary>
        /// Edge detectado (o primer edge del par)
        /// </summary>
        private OEdge edge1;
        /// <summary>
        /// Segundo edge del par
        /// </summary>
        private OEdge edge2;
        /// <summary>
        /// Determina si se trata de un par de edges o de un sigle edge
        /// </summary>
        private bool pair;
        /// <summary>
        /// Puntuación del resultado
        /// </summary>
        private double resultScore;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el edge resultado (primer edge en caso de ser un par)
        /// </summary>
        public OEdge Edge1
        {
            get { return edge1; }
        }
        /// <summary>
        /// Obtiene o establece el segundo edge del par
        /// </summary>
        public OEdge Edge2
        {
            get { return edge2; }
            set
            {
                edge2 = value;
                pair = true;
            }
        }
        /// <summary>
        /// Obtiene si el resultado es un par de edges
        /// </summary>
        public bool IsPair
        {
            get { return pair; }
        }
        /// <summary>
        /// Obtiene la puntuación del resultado
        /// </summary>
        public double ResultScore
        {
            get { return this.resultScore; }
            set { this.resultScore = value; }
        }
        /// <summary>
        /// Obtiene el ancho del par
        /// </summary>
        public double MeasuredWidth
        {
            get { return IsPair ? Math.Abs(Edge1.Position - Edge2.Position) : 0; }
        }
        /// <summary>
        /// Obtiene la posición del resultado
        /// </summary>
        public double Position
        {
            get { return IsPair ? (edge1.Position + edge2.Position) / 2 : edge1.Position; }
        }
        /// <summary>
        /// Obtiene el contraste del resultado (en valor absoluto)
        /// </summary>
        public double ContrasteAbsoluto
        {
            get { return IsPair ? (Math.Abs(edge1.Contraste) + Math.Abs(edge2.Contraste)) / 2 : Math.Abs(edge1.Contraste); }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor para un resultado single edge
        /// </summary>
        /// <param name="edge">Edge a incluir en el resultado</param>
        public OEdgeResult(OEdge edge)
        {
            this.edge1 = edge;
            this.pair = false;
            this.resultScore = edge.Score;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Sobreescritura del método ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Puntuación del par: " + ResultScore;
        }
        #endregion
    }
    /// <summary>
    /// Estructura que almacena datos de un Edge
    /// </summary>
    public class OEdge
    {
        #region Atributos
        /// <summary>
        /// Índice del edge
        /// </summary>
        private int indice;
        /// <summary>
        /// Puntuación del edge
        /// </summary>
        private double score;
        /// <summary>
        /// Posición del edge respecto al centro del caliper
        /// </summary>
        private float position;
        /// <summary>
        /// Posición del edge sobre el eje x
        /// </summary>
        private float x;
        /// <summary>
        /// Posición del edge sobre el eje y
        /// </summary>
        private float y;
        /// <summary>
        /// Contraste medido del edge
        /// </summary>
        private double contraste;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece la puntuación del edge
        /// </summary>
        public double Score
        {
            get { return score; }
            set { score = value; }
        }
        /// <summary>
        /// Obtiene la posición del edge respecto al centro del OrbitaCaliper
        /// </summary>
        public float Position
        {
            get { return position; }
        }
        /// <summary>
        /// Obtiene la posición sobre el eje X del edge
        /// </summary>
        public float X
        {
            get { return x; }
        }
        /// <summary>
        /// Obtiene la posición sobre el eje Y del edge
        /// </summary>
        public float Y
        {
            get { return y; }
        }
        /// <summary>
        /// Obtiene si el edge está en una transición negro a blanco
        /// </summary>
        public bool NegroBlanco
        {
            get { return contraste > 0; }
        }
        /// <summary>
        /// Obtiene el contraste medido del edge
        /// </summary>
        public double Contraste
        {
            get { return contraste; }
        }
        /// <summary>
        /// Obtiene el índice del edge
        /// </summary>
        public int Indice
        {
            get { return indice; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Crea un nuevo edge con la puntuación vacia
        /// </summary>
        /// <param name="indice">Indice del caliper, para identificarlo dentro de la colección</param>
        /// <param name="posicion">Posición respecto al centro del caliper</param>
        /// <param name="coordenadas">Coordenadas donde se encuentra el edge</param>
        /// <param name="contraste">Contraste encontrado</param>
        public OEdge(int indice, float posicion, PointF coordenadas, double contraste)
        {
            this.indice = indice;
            this.position = posicion;
            this.x = coordenadas.X;
            this.y = coordenadas.Y;
            this.contraste = contraste;
            this.score = 0;
        }
        /// <summary>
        /// Crea un nuevo edge con la puntuación
        /// </summary>
        /// <param name="indice">Indice del caliper, para identificarlo dentro de la colección</param>
        /// <param name="posicion">Posición respecto al centro del caliper</param>
        /// <param name="coordenadas">Coordenadas donde se encuentra el edge</param>
        /// <param name="contraste">Contraste encontrado</param>
        /// <param name="score">Puntuación del edge</param>
        public OEdge(int indice, float posicion, PointF coordenadas, float contraste, float score)
        {
            this.indice = indice;
            this.position = posicion;
            this.x = coordenadas.X;
            this.y = coordenadas.Y;
            this.contraste = contraste;
            this.score = score;
        }
        /// <summary>
        /// Crea un nuevo edge en base a otro
        /// </summary>
        /// <param name="origen">Edge a copiar</param>
        public OEdge(OEdge origen)
        {
            this.indice = origen.Indice;
            this.position = origen.Position;
            this.x = origen.X;
            this.y = origen.Y;
            this.contraste = origen.Contraste;
            this.score = origen.Score;
        }
        #endregion

        #region Métodos sobreescritos
        /// <summary>
        /// Método ToString sobreescrito
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Posición del edge: " + this.position;
        }
        #endregion
    }
    /// <summary>
    /// Enumera los tipos de edges disponibles
    /// </summary>
    public enum PolaridadEdges
    {
        /// <summary>
        /// Contraste positivo, pasa de negro a blanco
        /// </summary>
        NegroBlanco,
        /// <summary>
        /// Contraste negativo, pasa de blanco a negro
        /// </summary>
        BlancoNegro,
        /// <summary>
        /// Cualquier signo de contraste, sirve para cualquier edge sea cual sea su signo
        /// </summary>
        Cualquiera,
        /// <summary>
        /// Edge no definido, se utiliza para indicar la no existencia de un edge
        /// </summary>
        Ninguno
    }
}
