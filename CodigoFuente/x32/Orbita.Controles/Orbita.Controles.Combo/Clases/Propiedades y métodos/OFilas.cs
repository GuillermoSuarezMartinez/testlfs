//***********************************************************************
// Assembly         : Orbita.Controles
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
namespace Orbita.Controles.Combo
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OFilas : OControlBase
    {
        #region Atributos
        /// <summary>
        /// Fila activa.
        /// </summary>
        OFilaActiva activa;
        /// <summary>
        /// Fila alterna.
        /// </summary>
        OFilaAlterna alterna;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OFilas.
        /// </summary>
        public OFilas()
            : base() { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina la apariencia de fila.")]
        //[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de la fila activa.")]
        //[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content), System.ComponentModel.Category("Fila")]
        public OFilaActiva Activa
        {
            get 
            {
                if (this.activa == null)
                {
                    this.activa = new OFilaActiva();
                }
                return this.activa; 
            }
            set { this.activa = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de la fila alterna.")]
        //[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content), System.ComponentModel.Category("Fila")]
        public OFilaAlterna Alterna
        {
            get 
            {
                if (this.alterna == null)
                {
                    this.alterna = new OFilaAlterna();
                }
                return this.alterna; 
            }
            set { this.alterna = value; }
        }
        #endregion
    }
}
