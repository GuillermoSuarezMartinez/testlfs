//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : aibañez
// Created          : 07-01-2014
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
using System.Data;
using Orbita.Utiles;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Manejador de resultados de inspecciones
    /// </summary>
    public static class OResultadoVAManager<T>
        where T : ConfiguracionResultadosVA, new()
    {
        #region Atributo(s)
        /// <summary>
        /// Listado de configuraciones
        /// </summary>
        private static Dictionary<string, T> ConfiguracionResultadosVA;
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Constructor de los campos de la clase
        /// </summary>
        public static void Constructor()
        {
            ConfiguracionResultadosVA = new Dictionary<string, T>();
        }

        /// <summary>
        /// Destruye los campos de la clase
        /// </summary>
        public static void Destructor()
        {
            ConfiguracionResultadosVA = null;
        }

        /// <summary>
        /// Inicializa las variables necesarias para el funcionamiento de la clase
        /// </summary>
        public static void Inicializar()
        {
            DataTable dt = AppBD.GetResultadosInspeccionesFuncionesVision();
            foreach (DataRow dr in dt.Rows)
	        {
                string codigo = dr["CodResultadoInspeccionFuncionVision"].ValidarTexto();
                T valor = new T();
                valor.Inicializar(dr);
                ConfiguracionResultadosVA[codigo] = valor;
	        }
        }

        /// <summary>
        /// Finaliza la ejecución
        /// </summary>
        public static void Finalizar()
        {
            ConfiguracionResultadosVA.Clear();
        }

        /// <summary>
        /// Devuelve la configuración de resultado
        /// </summary>
        /// <param name="cogido"></param>
        /// <returns></returns>
        public static T GetConfiguracionResultadoVA(string codigo)
        {
            T resultado;
            if (ConfiguracionResultadosVA.TryGetValue(codigo, out resultado))
            {
                return resultado;
            }

            return null;
        }
        #endregion
    }

    /// <summary>
    /// Guarda la información de la BBDD relativa a los resultados de inspección
    /// </summary>
    public class ConfiguracionResultadosVA
    {
        #region Constructor(es)
        /// <summary>
        /// Consctructor de la clase
        /// </summary>
        public ConfiguracionResultadosVA()
        {
        }
        #endregion

        #region Método(s) público(s) virtual(es)
        /// <summary>
        /// Inicialización
        /// </summary>
        /// <param name="dr"></param>
        public virtual void Inicializar(DataRow dr)
        {
        }
        #endregion
    }
}
