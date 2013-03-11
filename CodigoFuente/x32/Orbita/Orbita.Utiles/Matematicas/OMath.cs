using System;
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
    }
}