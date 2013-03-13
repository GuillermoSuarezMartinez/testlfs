﻿//***********************************************************************
// Assembly         : Orbita.VA.MaquinasEstados
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.Data;
using Orbita.VA.Comun;
using System.Collections.Generic;

namespace Orbita.VA.MaquinasEstados
{
    /// <summary>
    /// Escenario Base.
    /// Permite la utilización de escenarios.
    /// </summary>
    public class OEscenario
    {
        #region Atributo(s)
        /// <summary>
        /// Código del escenario
        /// </summary>
        public string Codigo;

        /// <summary>
        /// Claves del escenario
        /// </summary>
        public OClaves Claves;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codigo"></param>
        public OEscenario(string codigo)
        {
            this.Codigo = codigo;
            this.Claves = new OClaves();

            // Consulta las claves de una determinada escenario
            DataTable dt = AppBD.GetClavesDeEscenario(this.Codigo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.Claves.Add(new OClave(dr));
                }
            }
        }
        #endregion

        #region Método(s) virtual(es)
        /// <summary>
        /// Inicializa la clase
        /// </summary>
        public virtual void Inicializar()
        {
            // Implementado en heredados
        }

        /// <summary>
        /// Finaliza la clase
        /// </summary>
        public virtual void Finalizar()
        {
            // Implementado en heredados
        }
        #endregion
    }
}
