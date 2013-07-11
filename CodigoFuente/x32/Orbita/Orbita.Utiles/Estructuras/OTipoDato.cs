//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 06-09-2012
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

namespace Orbita.Utiles
{
    /// <summary>
    /// Clase estática encargada de devolver el valor por defecto de un determinado tipo de dato
    /// </summary>
    public static class OTipoDato
    {
        /// <summary>
        /// Valor por defecto de un determinado tipo de datos
        /// </summary>
        /// <param name="tipoDato"></param>
        /// <returns></returns>
        public static object DevaultValue(OEnumTipoDato tipoDato)
        {
            object resultado = null;

            switch (tipoDato)
            {
                case OEnumTipoDato.SinDefinir:
                case OEnumTipoDato.Imagen:
                case OEnumTipoDato.Grafico:
                case OEnumTipoDato.Flag:
                    resultado = null;
                    break;
                case OEnumTipoDato.Bit:
                    resultado = false;
                    break;
                case OEnumTipoDato.Entero:
                    resultado = (int)0;
                    break;
                case OEnumTipoDato.Texto:
                    resultado = string.Empty;
                    break;
                case OEnumTipoDato.Decimal:
                    resultado = (double)0.0;
                    break;
                case OEnumTipoDato.Fecha:
                    resultado = DateTime.Now;
                    break;
            }

            return resultado;
        }
    }
    
    /// <summary>
	/// Enumerado que implementa el enumerado de los módulos del sistema
	/// </summary>
    public enum OEnumTipoDato
	{
		/// <summary>
		/// Tipo no definido
		/// </summary>
		SinDefinir = 0,
		/// <summary>
		/// Tipo booleano o bit
		/// </summary>
		Bit = 1,
		/// <summary>
		/// Tipo entero
		/// </summary>
		Entero = 2,
		/// <summary>
		/// Tipo texto
		/// </summary>
		Texto = 3,
		/// <summary>
		/// Tipo decimal
		/// </summary>
		Decimal = 4,
		/// <summary>
		/// Tipo fecha
		/// </summary>
		Fecha = 5,
		/// <summary>
		/// Tipo imagen
		/// </summary>
		Imagen = 6,
		/// <summary>
		/// Tipo gráfico
		/// </summary>
		Grafico = 7,
		/// <summary>
		/// Tipo Evento
		/// </summary>
		Flag = 8,
	}
}
