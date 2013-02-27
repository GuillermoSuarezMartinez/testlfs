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
    public partial class OrbitaUltraDateTimeEditorAboveFilter : Orbita.Controles.Shared.OrbitaUserControl
    {
        #region Atributos
        bool validando = false;
        System.DateTime fechaDesde = new System.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, 0, 0, 0);
        System.DateTime fechaHasta = new System.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, 23, 59, 59);
        string etiquetaDesde;
        string etiquetaHasta;
        string mascaraEntrada;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.OrbitaUltraDateTimeEditorFilter.
        /// </summary>
        public OrbitaUltraDateTimeEditorAboveFilter()
            : base()
        {
            InitializeComponent();
        }
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado OrbDelegadoCambioValor.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void OrbDelegadoCambioValor(object sender, System.EventArgs e);
        #endregion

        #region Eventos
        /// <summary>
        /// Cambio de valor del filtro.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Cambio de valor del filtro")]
        public event OrbDelegadoCambioValor OrbCambioValorFiltro;
        #endregion

        #region Propiedades
        /// <summary>
        /// Devuelve o establece la fecha Desde.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Devuelve o establece la fecha Desde.")]
        public System.DateTime Fechadesde
        {
            get { return new System.DateTime(this.fechaDesde.Year, this.fechaDesde.Month, this.fechaDesde.Day, 0, 0, 0); }
            set { this.dttDesde.DateTime = value; }
        }
        /// <summary>
        /// Devuelve o establece la fecha Hasta.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Devuelve o establece la fecha Hasta.")]
        public System.DateTime FechaHasta
        {
            get { return new System.DateTime(this.fechaHasta.Year, this.fechaHasta.Month, this.fechaHasta.Day, 23, 59, 59); }
            set { this.dttHasta.DateTime = value; }
        }
        /// <summary>
        /// Devuelve o establece el texto que aparece en el label Desde:
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Devuelve o establece el texto que aparece en el label Desde.")]
        public string LabelDesde
        {
            get { return this.etiquetaDesde; }
            set
            {
                this.etiquetaDesde = value;
                this.lblDesde.Text = value;
            }
        }
        /// <summary>
        /// Devuelve o establece el texto que aparece en el label Hasta:
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Devuelve o establece el texto que aparece en el label Hasta.")]
        public string LabelHasta
        {
            get { return this.etiquetaHasta; }
            set
            {
                this.etiquetaHasta = value;
                this.lblHasta.Text = value;
            }
        }
        /// <summary>
        /// Devuelve o establece el valor de la propiedad MaskInput de los dateTimes del control.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Devuelve o establece el valor de la propiedad MaskInput de los DateTimes del control. Puede tener los siguientes valores{date}; {time};{longdate};{date} {time};{date} {longtime};{y unos cuantos mas}")]
        public string OrbMascaraEntrada
        {
            get { return this.mascaraEntrada; }
            set
            {
                this.mascaraEntrada = value;
                dttDesde.MaskInput = value;
                dttHasta.MaskInput = value;
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Validar rango.
        /// </summary>
        /// <returns></returns>
        bool ValidarRango()
        {
            if (System.DateTime.Compare(this.dttDesde.DateTime, this.dttHasta.DateTime) > 0 || System.DateTime.Compare(this.dttHasta.DateTime, this.dttDesde.DateTime) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Load.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void OrbitaUltraDateTimeEditorAboveFilter_Load(object sender, System.EventArgs e)
        {
            if (this.etiquetaHasta == null)
            {
                this.lblHasta.Text = "Hasta:";
            }
            else
            {
                this.lblHasta.Text = this.etiquetaHasta;
            }
            if (this.etiquetaDesde == null)
            {
                this.lblDesde.Text = "Desde:";
            }
            else
            {
                this.lblDesde.Text = this.etiquetaDesde;
            }
            if (this.mascaraEntrada == null)
            {
                this.dttHasta.MaskInput = "";
                this.dttDesde.MaskInput = "";
            }
            else
            {
                this.dttHasta.MaskInput = this.mascaraEntrada;
                this.dttDesde.MaskInput = this.mascaraEntrada;
            }
        }
        /// <summary>
        /// ValueChanged.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void dttDesde_ValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (!this.validando)
                {
                    this.validando = true;
                    if (!ValidarRango())
                    {
                        this.dttDesde.DateTime = this.dttHasta.DateTime;
                        if (OrbCambioValorFiltro!=null)
                        {
                            OrbCambioValorFiltro(this, new System.EventArgs());
                        }
                    }
                    else
                    {
                        this.fechaDesde = this.dttDesde.DateTime;
                        if (OrbCambioValorFiltro != null)
                        {
                            OrbCambioValorFiltro(this, new System.EventArgs());
                        }
                    }
                    this.validando = false;
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// ValueChanged.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void dttHasta_ValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (!this.validando)
                {
                    this.validando = true;
                    if (!ValidarRango())
                    {
                        this.dttHasta.DateTime = this.dttDesde.DateTime;
                        if (OrbCambioValorFiltro != null)
                        {
                            OrbCambioValorFiltro(this, new System.EventArgs());
                        }
                    }
                    else
                    {
                        this.fechaHasta = this.dttHasta.DateTime;
                        if (OrbCambioValorFiltro != null)
                        {
                            OrbCambioValorFiltro(this, new System.EventArgs());
                        }
                    }
                    this.validando = false;
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}