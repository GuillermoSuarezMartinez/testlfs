//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;
using System.Diagnostics.CodeAnalysis;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Constantes.
    /// </summary>
    public static class OComunicacionesConstantes
    {
        /// <summary>
        /// Creación de la estructura
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "El origen del nombre abreviado.")]
        public struct OInfoOPC
        {
            #region Constantes
            /// <summary>
            /// Colección de datos.
            /// </summary>
            public const string Dato = "Dato";
            /// <summary>
            /// Colección de lecturas.
            /// </summary>
            public const string Lectura = "Lectura";
            /// <summary>
            /// Colección de alarmas.
            /// </summary>
            public const string Alarma = "Alarma";
            #endregion Constantes

            #region Métodos públicos
            /// <summary>
            /// Sobreescritura del método Equals.
            /// </summary>
            /// <param name="obj">Objeto de comparación.</param>
            /// <returns>Si la instancia y el objeto son iguales.</returns>
            public override bool Equals(Object obj)
            {
                return false;
            }
            /// <summary>
            /// Sobreescritura del método GetHashCode.
            /// </summary>
            /// <returns>El código Hash de esta instancia.</returns>
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            /// <summary>
            /// Operador de igualdad.
            /// </summary>
            /// <param name="infoOPC">InfoOPC de tipo contenedor.</param>
            /// <param name="cadena">Cadena de comparación.</param>
            /// <returns>La igualdad de la cadena de comparación con el tipo.</returns>
            [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "El origen del nombre abreviado.")]
            public static bool operator ==(OInfoOPC infoOPC, string cadena)
            {
                return infoOPC.Equals(cadena);
            }
            /// <summary>
            /// Operador de desigualdad.
            /// </summary>
            /// <param name="infoOPC">InfoOPC de tipo contenedor.</param>
            /// <param name="cadena">Cadena de comparación.</param>
            /// <returns>La desigualdad de la cadena de comparación con el tipo.</returns>
            [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "El origen del nombre abreviado.")]
            public static bool operator !=(OInfoOPC infoOPC, string cadena)
            {
                return !infoOPC.Equals(cadena);
            }
            #endregion Métodos públicos
        }
    }
}