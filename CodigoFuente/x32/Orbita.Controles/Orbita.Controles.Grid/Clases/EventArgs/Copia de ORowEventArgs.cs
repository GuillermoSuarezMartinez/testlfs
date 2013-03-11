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
using System;
namespace Orbita.Controles.Grid
{
    public class OTimerEventArgs : EventArgs
    {
        #region Atributos privados
        int intervalo;
        #endregion

        #region Constructores
        public OTimerEventArgs(int intervalo)
        {
            this.intervalo = intervalo;
        }
        #endregion

        #region Propiedades
        public int Intervalo
        {
            get { return this.intervalo; }
            set { this.intervalo = value; }
        }
        #endregion
    }
}