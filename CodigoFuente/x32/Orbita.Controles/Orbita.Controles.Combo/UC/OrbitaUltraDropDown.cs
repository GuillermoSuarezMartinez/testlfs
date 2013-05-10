using System;
using Orbita.Controles.Grid;
namespace Orbita.Controles.Combo
{
    public partial class OrbitaUltraDropDown : Infragistics.Win.UltraWinGrid.UltraDropDown
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OrbitaUltraDropDown.
        /// </summary>
        public OrbitaUltraDropDown()
            : base()
        {
            InitializeComponent();
            InitializeProperties();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedades del Dropdown de Infragistics.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Propiedades del Dropdown de Infragistics.")]
        [System.ComponentModel.Browsable(false)]
        public Infragistics.Win.UltraWinGrid.UltraDropDown UltraDropDown
        {
            get { return this; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Formatear el Dropdown.
        /// </summary>
        /// <param name="dt">Tabla de datos.</param>
        /// <param name="columnas">Lista de columnas.</param>
        /// <param name="displayMember">Campo texto a visualizar.</param>
        /// <param name="valueMember">Campo valor.</param>
        public void OrbFormatear(System.Data.DataTable dt, System.Collections.ArrayList columnas, string displayMember, string valueMember)
        {
            try
            {
                if (dt != null)
                {
                    this.DataSource = dt;
                    this.DisplayMember = displayMember;
                    this.ValueMember = valueMember;
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ugc in this.DisplayLayout.Bands[0].Columns)
                    {
                        ugc.Hidden = true;
                    }
                    if (columnas == null)
                    {
                        return;
                    }
                    foreach (OEstiloColumna columna in columnas)
                    {
                        if (this.DisplayLayout.Bands[0].Columns.Exists(columna.Campo))
                        {
                            this.DisplayLayout.Bands[0].Columns[columna.Campo].Hidden = false;
                            this.DisplayLayout.Bands[0].Columns[columna.Campo].Header.Caption = columna.Nombre;
                            this.DisplayLayout.Bands[0].Columns[columna.Campo].Style = (Infragistics.Win.UltraWinGrid.ColumnStyle)columna.Estilo;
                            this.DisplayLayout.Bands[0].Columns[columna.Campo].CellAppearance.TextHAlign = (Infragistics.Win.HAlign)columna.Alinear;
                            if (columna.Ancho > -1)
                            {
                                this.DisplayLayout.Bands[0].Columns[columna.Campo].Width = columna.Ancho;
                            }
                            this.DisplayLayout.Bands[0].Columns[columna.Campo].Header.VisiblePosition = columnas.IndexOf(columna);
                        }
                        else
                        {
                            // Si el campo que le hemos pasado como parametro no existe en el combo.
                            throw new Exception("Error en FormatearDropDown. El campo " + columna.Campo + " no existe en el Grid.");
                        }
                    }
                    if (dt.Rows.Count > 0)
                    {
                        this.SelectedRow = this.Rows[0];
                    }
                    if (columnas.Count == 1)
                    {
                        this.DisplayLayout.Bands[0].ColHeadersVisible = false;
                        this.DisplayLayout.Bands[0].Columns[((OEstiloColumna)columnas[0]).Campo].Width = this.Width - 2;
                    }
                }
                else
                {
                    // Si la tabla es nula lanzamos excepcion.
                    throw new Exception("Error en FormatearDropDown. La tabla es nula.");
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializar propiedades.
        /// </summary>
        void InitializeProperties()
        {
            // Importante: sin no inicializamos esta propiedad a false, a consecuencia de
            // utilizar TextRenderingMode = GDI, produce que los tooltip de scroll (si hubiera)
            // y los de la fila de filtros, aparezcan en negrita (ilegibles).
            Infragistics.Win.DrawUtility.UseGDIPlusTextRendering = false;
            this.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
        }
        #endregion
    }
}
