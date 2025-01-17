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
    public class OCeldas : OControlBase
    {
        #region Atributos
        /// <summary>
        /// Celdas activas.
        /// </summary>
        OCeldasActivas activas;
        /// <summary>
        /// Celdas agrupadas.
        /// </summary>
        OCeldasAgrupadas agrupadas;
        /// <summary>
        /// Tipo de selección.
        /// </summary>
        TipoSeleccion tipoSeleccion;
        #endregion

        #region Eventos
        /// <summary>
        /// Propiedad cambiando.
        /// </summary>
        public event System.EventHandler<OPropiedadEventArgs> PropertyChanging;
        /// <summary>
        /// Propiedad cambio.
        /// </summary>
        public event System.EventHandler<OPropiedadEventArgs> PropertyChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OCeldas.
        /// </summary>
        public OCeldas()
            : base() { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina la apariencia de las celdas.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de las celdas activas.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content), System.ComponentModel.Category("Fila")]
        public OCeldasActivas Activas
        {
            get
            {
                if (this.activas == null)
                {
                    this.activas = new OCeldasActivas();
                }
                return this.activas;
            }
            set { this.activas = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de las celdas agrupadas.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content), System.ComponentModel.Category("Fila")]
        public OCeldasAgrupadas Agrupadas
        {
            get
            {
                if (this.agrupadas == null)
                {
                    this.agrupadas = new OCeldasAgrupadas();
                }
                return this.agrupadas;
            }
            set { this.agrupadas = value; }
        }
        [System.ComponentModel.Description("")]
        public TipoSeleccion TipoSeleccion
        {
            get { return this.tipoSeleccion; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("TipoSeleccion"));
                }
                this.tipoSeleccion = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("TipoSeleccion"));
                }
            }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetTipoSeleccion()
        {
            this.TipoSeleccion = Configuracion.DefectoTipoSeleccionCelda;
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeTipoSeleccion()
        {
            return (this.TipoSeleccion != Configuracion.DefectoTipoSeleccionCelda);
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Invalida el método ToString() para devolver una cadena que representa la instancia de objeto.
        /// </summary>
        /// <returns>El nombre de tipo completo del objeto.</returns>
        public override string ToString()
        {
            return null;
        }
        #endregion
    }
}