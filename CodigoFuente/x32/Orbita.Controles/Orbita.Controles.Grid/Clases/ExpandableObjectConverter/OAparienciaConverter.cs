﻿//***********************************************************************
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
using System.ComponentModel;
using System.Globalization;
namespace Orbita.Controles.Grid
{
    public class OAparienciaConverter : ExpandableObjectConverter
    {
        #region Métodos públicos
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            // Convertir a string.
            if ((destinationType == typeof(string)))
            {
                OApariencia apariencia = (OApariencia)value;
                int cont = 0;
                if (!apariencia.ColorBorde.IsEmpty)
                {
                    cont++;
                }
                if (!apariencia.ColorFondo.IsEmpty)
                {
                    cont++;
                }
                if (!apariencia.ColorTexto.IsEmpty)
                {
                    cont++;
                }
                if (apariencia.EstiloBorde != EstiloBorde.Solido)
                {
                    cont++;
                }
                if (apariencia.AlineacionTextoHorizontal != Configuracion.DefectoAlineacionTextoHorizontal)
                {
                    cont++;
                }
                if (apariencia.AlineacionTextoVertical != Configuracion.DefectoAlineacionTextoVertical)
                {
                    cont++;
                }
                if (apariencia.AdornoTexto != Configuracion.DefectoAdornoTexto)
                {
                    cont++;
                }
                if (cont == 1)
                {
                    return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0} propiedad modificada.", cont);
                }
                else if (cont > 1)
                {
                    return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0} propiedades modificadas.", cont);
                }
            }
            return "";
        }
        #endregion
    }
}