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
    public partial class OrbitaUltraNumericEditorWithFilter : Orbita.Controles.Shared.OrbitaUserControl
    {
        #region Atributos
        /// <summary>
        /// Valor m�nimo del a�o A.
        /// </summary>
        int _minAnyoA;
        /// <summary>
        /// Valor m�ximo del a�o A.
        /// </summary>
        int _maxAnyoA;
        /// <summary>
        /// Valor del a�o A.
        /// </summary>
        int _valorAnyoA;
        /// <summary>
        /// Valor m�nimo del a�o B.
        /// </summary>
        int _minAnyoB;
        /// <summary>
        /// Valor m�ximo del a�o B.
        /// </summary>
        int _maxAnyoB;
        /// <summary>
        /// Valor del a�o B.
        /// </summary>
        int _valorAnyoB;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaYearFilter.
        /// </summary>
        public OrbitaUltraNumericEditorWithFilter()
            : base()
        {
            InitializeComponent();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Valor m�nimo del a�o A.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor m�nimo del a�o A")]
        [System.ComponentModel.DefaultValue(0)]
        public int OrbMinAnyoA
        {
            get { return this._minAnyoA; }
            set { this._minAnyoA = value; }
        }
        /// <summary>
        /// Valor m�ximo del a�o A.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor m�ximo del a�o A")]
        [System.ComponentModel.DefaultValue(0)]
        public int OrbMaxAnyoA
        {
            get { return this._maxAnyoA; }
            set { this._maxAnyoA = value; }
        }
        /// <summary>
        /// Valor del a�o A.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor del a�o A")]
        [System.ComponentModel.DefaultValue(0)]
        public int OrbValueAnyoA
        {
            get
            {
                this._valorAnyoA = System.Convert.ToInt32(this.neAnyoA.Value, System.Globalization.CultureInfo.CurrentCulture);
                return this._valorAnyoA;
            }
            set
            {
                this._valorAnyoA = value;
                this.neAnyoA.Value = this._valorAnyoA;
            }
        }
        /// <summary>
        /// Valor m�nimo del a�o B.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor m�nimo del a�o B")]
        [System.ComponentModel.DefaultValue(0)]
        public int OrbMinAnyoB
        {
            get { return this._minAnyoB; }
            set { this._minAnyoB = value; }
        }
        /// <summary>
        /// Valor m�ximo del a�o B.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor m�ximo del a�o B")]
        [System.ComponentModel.DefaultValue(0)]
        public int OrbMaxAnyoB
        {
            get { return this._maxAnyoB; }
            set { this._maxAnyoB = value; }
        }
        /// <summary>
        /// Valor del a�o B.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor del a�o B")]
        [System.ComponentModel.DefaultValue(0)]
        public int OrbValueAnyoB
        {
            get
            {
                this._valorAnyoB = System.Convert.ToInt32(this.neAnyoB.Value, System.Globalization.CultureInfo.CurrentCulture);
                return this._valorAnyoB;
            }
            set
            {
                this._valorAnyoB = value;
                this.neAnyoB.Value = this._valorAnyoB;
            }
        }
        #endregion

        #region M�todos p�blicos
        /// <summary>
        /// Funci�n que comprueba los a�os (m�nimos, m�ximos, etc.).
        /// </summary>
        public void CompruebaAnyos()
        {
            int auxiliar;
            // Comprobamos que el a�o A no sea mayor al a�o B.
            if (this.OrbValueAnyoA > this.OrbValueAnyoB)
            {
                auxiliar = this.OrbValueAnyoA;
                this.OrbValueAnyoA = this.OrbValueAnyoB;
                this.OrbValueAnyoB = auxiliar;
            }
            // Comprobamos que el a�o A no sea menor a su m�nimo ni mayor a su m�ximo.
            if (this.OrbValueAnyoA < this.OrbMinAnyoA)
            {
                this.OrbValueAnyoA = this.OrbMinAnyoA;
            }
            else if (this.OrbValueAnyoA > this.OrbMaxAnyoA)
            {
                this.OrbValueAnyoA = this.OrbMaxAnyoA;
            }
            // Comprobamos que el a�o B no sea menor a su m�nimo ni mayor a su m�ximo.
            if (this.OrbValueAnyoB < this.OrbMinAnyoB)
            {
                this.OrbValueAnyoB = this.OrbMinAnyoB;
            }
            else if (this.OrbValueAnyoB > this.OrbMaxAnyoB)
            {
                this.OrbValueAnyoB = this.OrbMaxAnyoB;
            }
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Leave.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void orbitaYearFilter_Leave(object sender, System.EventArgs e)
        {
            try
            {
                this.CompruebaAnyos();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
    }
}