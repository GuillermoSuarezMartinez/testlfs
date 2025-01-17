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
    public class OSumario
    {
        #region Atributos
        bool mostrarRecuentoFilas;
        AreaSumario posicion;
        #endregion

        #region Eventos
        public event System.EventHandler<OPropiedadEventArgs> PropertyChanging;
        public event System.EventHandler<OPropiedadEventArgs> PropertyChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OSumario.
        /// </summary>
        public OSumario()
            : base() { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Especifica el estilo de columnas.")]
        public AreaSumario Posicion
        {
            get { return this.posicion; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("Posicion"));
                }
                this.posicion = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("Posicion"));
                }
            }
        }
        [System.ComponentModel.Description("Mostrar recuento de filas.")]
        public bool MostrarRecuentoFilas
        {
            get { return this.mostrarRecuentoFilas; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("MostrarRecuentoFilas"));
                }
                this.mostrarRecuentoFilas = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("MostrarRecuentoFilas"));
                }
            }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetPosicion()
        {
            this.Posicion = Configuracion.DefectoPosicionSumario;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarRecuentoFilas()
        {
            this.MostrarRecuentoFilas = Configuracion.DefectoMostrarRecuentoFilas;
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializePosicion()
        {
            return (this.Posicion != Configuracion.DefectoPosicionSumario);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarRecuentoFilas()
        {
            return (this.MostrarRecuentoFilas != Configuracion.DefectoMostrarRecuentoFilas);
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
