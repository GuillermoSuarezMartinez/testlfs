//***********************************************************************
// Assembly         : Orbita.Controles.Grid
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Grid
{
    public class OTimerEventArgs : System.EventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Intervalo de tiempo.
        /// </summary>
        int intervalo;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OTimerEventArgs.
        /// </summary>
        /// <param name="intervalo"></param>
        public OTimerEventArgs(int intervalo)
        {
            this.intervalo = intervalo;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Intervalo de tiempo.
        /// </summary>
        public int Intervalo
        {
            get { return this.intervalo; }
            set { this.intervalo = value; }
        }
        #endregion
    }
}