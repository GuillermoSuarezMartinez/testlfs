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
namespace Orbita.Controles.Grid
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OCeldasAgrupadas : OControlBase
    {
        #region Atributos
        EstiloCeldasAgrupadas estilo;
        #endregion

        #region Eventos
        public event System.EventHandler<OPropiedadEventArgs> PropertyChanging;
        public event System.EventHandler<OPropiedadEventArgs> PropertyChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OCeldasAgrupadas.
        /// </summary>
        public OCeldasAgrupadas()
            : base() { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina la apariencia de las celdas agrupadas.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        [System.ComponentModel.Description("Especifica el estilo de las celdas agrupadas.")]
        public EstiloCeldasAgrupadas Estilo
        {
            get { return this.estilo; }
            set
            {
                if (this.estilo != value)
                {
                    if (this.PropertyChanging != null)
                    {
                        this.PropertyChanging(this, new OPropiedadEventArgs("EstiloCeldasAgrupadas"));
                    }
                    this.estilo = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new OPropiedadEventArgs("EstiloCeldasAgrupadas"));
                    }
                }
            }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetEstilo()
        {
            this.Estilo = Configuracion.DefectoEstiloCeldasAgrupadas;
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeEstilo()
        {
            return (this.Estilo != Configuracion.DefectoEstiloCeldasAgrupadas);
        }
        #endregion
    }
}