//***********************************************************************
// Assembly         : Orbita.Controles.Comunes
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
namespace Orbita.Controles.Comunes
{
    public partial class OrbitaUltraDateTimeEditorWithFilter : Orbita.Controles.Shared.OrbitaUserControl
    {
        #region Atributos
        /// <summary>
        /// Valor de la fecha de inicio.
        /// </summary>
        System.DateTime desde;
        /// <summary>
        /// Valor de la fecha de fin.
        /// </summary>
        System.DateTime hasta;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraDateTimeEditorFilterCustom.
        /// </summary>
        public OrbitaUltraDateTimeEditorWithFilter()
            : base()
        {
            InitializeComponent();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Valor de la fecha Desde.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor de la fecha de inicio")]
        [System.ComponentModel.DefaultValue(0)]
        public System.DateTime OrbValueFechaDesde
        {
            get
            {
                this.desde = System.Convert.ToDateTime(this.dttDesde.Value, System.Globalization.CultureInfo.CurrentCulture);
                return this.desde;
            }
            set
            {
                this.desde = value;
                this.dttDesde.Value = this.desde;
            }
        }
        /// <summary>
        /// Valor de la fecha Hasta.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor de la fecha de fin")]
        [System.ComponentModel.DefaultValue(0)]
        public System.DateTime OrbValueFechaHasta
        {
            get
            {
                this.hasta = System.Convert.ToDateTime(this.dttHasta.Value, System.Globalization.CultureInfo.CurrentCulture);
                return this.hasta;
            }
            set
            {
                this.hasta = value;
                this.dttHasta.Value = this.hasta;
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Comprueba que la fecha "desde" sea menor a la "hasta".
        /// </summary>
        void CompruebaFechas()
        {
            System.DateTime desdeAux = System.Convert.ToDateTime(this.dttDesde.Value.ToString(), System.Globalization.CultureInfo.CurrentCulture);
            System.DateTime hastaAux = System.Convert.ToDateTime(this.dttHasta.Value.ToString(), System.Globalization.CultureInfo.CurrentCulture);
            if (desdeAux > hastaAux)
            {
                System.DateTime fechaAux = desdeAux;
                this.dttDesde.Value = hastaAux;
                this.dttHasta.Value = fechaAux;
            }
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// ValueChanged.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void dtDesde_ValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.CompruebaFechas();
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// ValueChanged.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void dtHasta_ValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.CompruebaFechas();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
    }
}