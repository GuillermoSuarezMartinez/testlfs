﻿//***********************************************************************
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
#region USING
using System.Linq;
#endregion
namespace Orbita.Framework
{
    /// <summary>
    /// Lista de plugins disponibles en el entorno.
    /// </summary>
    public partial class PluginsDisponibles : System.Windows.Forms.Form
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.PluginsDisponibles.
        /// </summary>
        public PluginsDisponibles()
        {
            InitializeComponent();
            System.Collections.Generic.IDictionary<string, string> ensamblados = PluginManager.PluginHelper.Ensamblados();
            lstPluginsDisponibles.Items.AddRange(ensamblados.Keys.ToArray());
        }
        #endregion
    }
}