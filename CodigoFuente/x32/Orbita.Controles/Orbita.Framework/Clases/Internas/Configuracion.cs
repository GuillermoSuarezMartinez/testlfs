//***********************************************************************
// Assembly         : Orbita.Framework
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Framework
{
    internal static class Configuracion
    {
        #region Atributos internos constantes
        internal const Core.EstadoVentana DefectoEstadoVentanta = Core.EstadoVentana.Maximizado;
        internal const System.Windows.Forms.FormBorderStyle DefectoEstiloBorde = System.Windows.Forms.FormBorderStyle.Sizable;
        internal const bool DefectoMostrarMenu = true;
        internal const int DefectoNumeroMaximoFormulariosAbiertos = 50;
        internal const bool DefectoAutenticación = false;
        internal const Core.SelectorIdioma DefectoIdioma = Core.SelectorIdioma.Español;
        #endregion
    }
}