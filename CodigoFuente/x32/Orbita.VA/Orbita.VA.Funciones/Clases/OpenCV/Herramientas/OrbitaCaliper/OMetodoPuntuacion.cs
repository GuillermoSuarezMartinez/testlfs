using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.VA.Funciones.Clases.OpenCV.Herramientas.OrbitaCaliper
{
    /// <summary>
    /// Clase abstracta que define la interfaz de un método de puntuación
    /// </summary>
    abstract class OMetodoPuntuacion
    {
        #region Atributos protegidos
        /// <summary>
        /// Indica si el método de puntuación se aplica sólamente a pares de edges
        /// </summary>
        protected bool onlyPairMethod;
        /// <summary>
        /// Función de puntuación del método
        /// </summary>
        protected OScoringFunction funcionPuntuacion;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene si se trata de un método para puntuar únicamente pares de edges
        /// </summary>
        public bool OnlyPairMethod
        {
            get { return onlyPairMethod; }
        }
        #endregion

        #region Métodos abstractos
        /// <summary>
        /// Método que devuelve la puntuación de un candidato
        /// </summary>
        /// <param name="candidato">Resultado a puntuar</param>
        /// <returns>Puntuación numérica del resultado</returns>
        public abstract double Puntuar(OEdgeResult candidato);
        #endregion
    }
    /// <summary>
    /// Método de puntuación por tamaño. Se basa en el ancho entre un par de edge 
    /// </summary>
    class SizeDiffNormMethod : OMetodoPuntuacion
    {
        #region Atributo
        /// <summary>
        /// Ancho del par de edges
        /// </summary>
        private double edgePairWidth;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor del método de puntuación
        /// </summary>
        /// <param name="edgePairWidth">Ancho de máxima puntuación</param>
        public SizeDiffNormMethod(double edgePairWidth)
        {
            this.onlyPairMethod = true;

            this.funcionPuntuacion = new SingleSideScoringFunction(1, 0, 1, 1, 0);

            this.edgePairWidth = edgePairWidth;
        }
        #endregion

        #region Métodos sobreescritos
        /// <summary>
        /// Sobreescritura del método de puntuación
        /// </summary>
        /// <param name="candidato">Resultado candidato</param>
        /// <returns>Puntuación numérica</returns>
        public override double Puntuar(OEdgeResult candidato)
        {
            //Comprobamos que efectivamente tenemos dos edges
            if (!candidato.IsPair)
            {
                throw new ArgumentException("El argumento debe ser un par de edges válido. Parece que uno o más edges son null", "candidato");
            }

            //Calculamos la distancia entre ellos
            double rawScore = Math.Abs(candidato.Edge1.Position - candidato.Edge2.Position);

            //Normalizamos
            rawScore = Math.Abs(rawScore - edgePairWidth) / edgePairWidth;
            return this.funcionPuntuacion.MapScore(rawScore);
        }
        #endregion
    }
    /// <summary>
    /// Método de puntuación por contraste. Se basa en el contraste normalizado de un edge
    /// </summary>
    class ContrastMethod : OMetodoPuntuacion
    {
        #region Constructor
        /// <summary>
        /// Constructor del método de puntuación
        /// </summary>
        public ContrastMethod()
        {
            //Este método es para ambos modos, pares y single
            this.onlyPairMethod = false;

            this.funcionPuntuacion = new SingleSideScoringFunction(0, 255, 0, 1, 0);
        }
        #endregion

        #region Métodos sobreescritos
        /// <summary>
        /// Método sobreescrito de puntuación
        /// </summary>
        /// <param name="candidato">Resultado a puntuar</param>
        /// <returns>Puntuación numérica del resultado</returns>
        public override double Puntuar(OEdgeResult candidato)
        {
            //Obtenemos el primer contraste
            double rawScore = Math.Abs(candidato.Edge1.Contraste);
            candidato.Edge1.Score = this.funcionPuntuacion.MapScore(rawScore);

            //Si hay un segundo edge, calculamos la media
            if (candidato.IsPair)
            {
                //Normalizamos el contrase del primer edge
                rawScore = Math.Abs(candidato.Edge2.Contraste);
                candidato.Edge2.Score = this.funcionPuntuacion.MapScore(rawScore);
            }
            return this.funcionPuntuacion.MapScore(candidato.ContrasteAbsoluto);
        }
        #endregion
    }
}
