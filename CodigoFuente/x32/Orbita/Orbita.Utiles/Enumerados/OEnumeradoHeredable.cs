//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 13-12-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Utiles
{
    /// <summary>
    /// Clase utilizada para permitir la herencia de enumerados
    /// </summary>
    public class OEnumeradoHeredable
    {
        #region Atributos
        /// <summary>
        /// Nombre del enumerado
        /// </summary>
        public string Nombre;
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion;
        /// <summary>
        /// Valor del enumerado
        /// </summary>
        public int Valor;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OEnumeradoHeredable(string nombre, string descripcion, int valor)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Valor = valor;
        }
        #endregion
    }
}