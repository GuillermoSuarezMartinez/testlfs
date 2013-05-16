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
namespace Orbita.Controles.Comunes
{
    public partial class OrbitaUltraNumericEditorWithFilter : Orbita.Controles.Shared.OrbitaUserControl
    {
        #region Atributos
        /// <summary>
        /// Valor mínimo del año A.
        /// </summary>
        int minAnyoA;
        /// <summary>
        /// Valor máximo del año A.
        /// </summary>
        int maxAnyoA;
        /// <summary>
        /// Valor del año A.
        /// </summary>
        int valorAnyoA;
        /// <summary>
        /// Valor mínimo del año B.
        /// </summary>
        int minAnyoB;
        /// <summary>
        /// Valor máximo del año B.
        /// </summary>
        int maxAnyoB;
        /// <summary>
        /// Valor del año B.
        /// </summary>
        int valorAnyoB;
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
        /// Valor mínimo del año A.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor mínimo del año A")]
        [System.ComponentModel.DefaultValue(0)]
        public int OrbMinAnyoA
        {
            get { return this.minAnyoA; }
            set { this.minAnyoA = value; }
        }
        /// <summary>
        /// Valor máximo del año A.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor máximo del año A")]
        [System.ComponentModel.DefaultValue(0)]
        public int OrbMaxAnyoA
        {
            get { return this.maxAnyoA; }
            set { this.maxAnyoA = value; }
        }
        /// <summary>
        /// Valor del año A.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor del año A")]
        [System.ComponentModel.DefaultValue(0)]
        public int OrbValueAnyoA
        {
            get
            {
                this.valorAnyoA = System.Convert.ToInt32(this.neAnyoA.Value, System.Globalization.CultureInfo.CurrentCulture);
                return this.valorAnyoA;
            }
            set
            {
                this.valorAnyoA = value;
                this.neAnyoA.Value = this.valorAnyoA;
            }
        }
        /// <summary>
        /// Valor mínimo del año B.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor mínimo del año B")]
        [System.ComponentModel.DefaultValue(0)]
        public int OrbMinAnyoB
        {
            get { return this.minAnyoB; }
            set { this.minAnyoB = value; }
        }
        /// <summary>
        /// Valor máximo del año B.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor máximo del año B")]
        [System.ComponentModel.DefaultValue(0)]
        public int OrbMaxAnyoB
        {
            get { return this.maxAnyoB; }
            set { this.maxAnyoB = value; }
        }
        /// <summary>
        /// Valor del año B.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor del año B")]
        [System.ComponentModel.DefaultValue(0)]
        public int OrbValueAnyoB
        {
            get
            {
                this.valorAnyoB = System.Convert.ToInt32(this.neAnyoB.Value, System.Globalization.CultureInfo.CurrentCulture);
                return this.valorAnyoB;
            }
            set
            {
                this.valorAnyoB = value;
                this.neAnyoB.Value = this.valorAnyoB;
            }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Función que comprueba los años (mínimos, máximos, etc.).
        /// </summary>
        public void CompruebaAnyos()
        {
            int auxiliar;
            // Comprobamos que el año A no sea mayor al año B.
            if (this.OrbValueAnyoA > this.OrbValueAnyoB)
            {
                auxiliar = this.OrbValueAnyoA;
                this.OrbValueAnyoA = this.OrbValueAnyoB;
                this.OrbValueAnyoB = auxiliar;
            }
            // Comprobamos que el año A no sea menor a su mínimo ni mayor a su máximo.
            if (this.OrbValueAnyoA < this.OrbMinAnyoA)
            {
                this.OrbValueAnyoA = this.OrbMinAnyoA;
            }
            else if (this.OrbValueAnyoA > this.OrbMaxAnyoA)
            {
                this.OrbValueAnyoA = this.OrbMaxAnyoA;
            }
            // Comprobamos que el año B no sea menor a su mínimo ni mayor a su máximo.
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
            catch (System.Exception)
            {
                throw;
            }
        }
        #endregion
    }
}