﻿//***********************************************************************
// Assembly         : Orbita.Utiles
// Author           : aibañez
// Created          : 13-12-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Reflection;
namespace Orbita.Utiles
{
    /// <summary>
    /// Clase que agrupa a un conjunto de enumerados
    /// </summary>
    public class OEnumeradosHeredable
    {
        #region Atributos
        /// <summary>
        /// Lista de los enumerados que contiene
        /// </summary>
        public List<OEnumeradoHeredable> ListaEnumerados;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OEnumeradosHeredable()
        {
            this.ListaEnumerados = new List<OEnumeradoHeredable>();

            Type tipo = this.GetType();
            while (tipo != typeof(OEnumeradosHeredable))
            {
                FieldInfo[] fields = tipo.GetFields();
                foreach (FieldInfo fieldInfo in fields)
                {
                    if (fieldInfo.IsStatic)
                    {
                        object valor = fieldInfo.GetValue(null);
                        if (valor is OEnumeradoHeredable)
                        {
                            this.ListaEnumerados.Add((OEnumeradoHeredable)valor);
                        }
                    }
                }
                tipo = tipo.BaseType;
            }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public T Parse<T>(string nombre)
            where T : OEnumeradoHeredable
        {
            T resultado = null;

            foreach (OEnumeradoHeredable enumerado in this.ListaEnumerados)
            {
                if (enumerado.Nombre == nombre)
                {
                    return (T)enumerado;
                }
            }
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public T Parse<T>(int valor)
            where T : OEnumeradoHeredable
        {
            T resultado = null;
            foreach (OEnumeradoHeredable enumerado in this.ListaEnumerados)
            {
                if (enumerado.Valor == valor)
                {
                    return (T)enumerado;
                }
            }
            return resultado;
        }
        #endregion
    }
}