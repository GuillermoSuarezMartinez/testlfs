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
namespace Orbita.Controles.Comunes
{
    /// <summary>
    /// Orbita.Controles.Comunes.OrbitaBarraProgreso.
    /// </summary>
    public partial class OrbitaBarraProgreso : Orbita.Controles.Shared.OrbitaUserControl
    {
        #region Atributos
        /// <summary>
        /// Color borde.
        /// </summary>
        System.Drawing.Color colorBorde = System.Drawing.Color.Black;
        /// <summary>
        /// Color relleno 1.
        /// </summary>
        System.Drawing.Color colorRelleno1 = System.Drawing.Color.White;
        /// <summary>
        /// Color relleno 2.
        /// </summary>
        System.Drawing.Color colorRelleno2 = System.Drawing.Color.Blue;
        /// <summary>
        /// Valor mínimo.
        /// </summary>
        int minimo = 0;
        /// <summary>
        /// Valor máximo.
        /// </summary>
        int maximo = 100;
        /// <summary>
        /// Valor.
        /// </summary>
        int valor = 100;
        /// <summary>
        /// Borde.
        /// </summary>
        bool borde = true;
        /// <summary>
        /// Vertical.
        /// </summary>
        bool vertical = false;
        /// <summary>
        /// Monocolor.
        /// </summary>
        bool monocolor = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.OrbitaBarraProgreso.
        /// </summary>
        public OrbitaBarraProgreso()
            : base()
        {
            InitializeComponent();
            this.SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
        }
        #endregion

        #region Eventos
        /// <summary>
        /// ValorModificado.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor modificado.")]
        public event System.EventHandler ValorModificado;
        #endregion

        #region Propiedades
        /// <summary>
        /// Color borde.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Color del borde.")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color ColorBorde
        {
            get { return this.colorBorde; }
            set
            {
                this.colorBorde = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Color relleno 1.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Color de relleno 1.")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color ColorRelleno1
        {
            get { return this.colorRelleno1; }
            set
            {
                this.colorRelleno1 = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Color relleno 2.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Color de relleno 2.")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color ColorRelleno2
        {
            get { return this.colorRelleno2; }
            set
            {
                this.colorRelleno2 = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Valor mínimo.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor mínimo.")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.None)]
        public int Min
        {
            get { return this.minimo; }
            set
            {
                this.minimo = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Valor máximo.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor máximo.")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.None)]
        public int Max
        {
            get { return this.maximo; }
            set
            {
                this.maximo = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Valor.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Valor.")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public int Valor
        {
            get { return this.valor; }
            set
            {
                this.valor = value;
                this.Invalidate();
                if (this.ValorModificado != null)
                {
                    this.ValorModificado(this, null);
                }
            }
        }
        /// <summary>
        /// Borde.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Borde.")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool Borde
        {
            get { return this.borde; }
            set
            {
                this.borde = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Vertical.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Vertical.")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool Vertical
        {
            get { return this.vertical; }
            set
            {
                this.vertical = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Monocolor.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Monocolor.")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool Monocolor
        {
            get { return this.monocolor; }
            set
            {
                this.monocolor = value;
                this.Invalidate();
            }
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// OnPaint.
        /// </summary>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            base.OnPaint(e);
            int w;
            int value = this.valor;
            if (value < this.minimo)
            {
                value = this.minimo;
            }
            else if (value > this.maximo)
            {
                value = this.maximo;
            }
            double p = System.Convert.ToDouble(value - this.minimo) / System.Convert.ToDouble(this.maximo - this.minimo);
            System.Drawing.Color c1 = this.colorRelleno1;
            System.Drawing.Color c2 = this.colorRelleno2;
            System.Drawing.Drawing2D.LinearGradientMode modo;
            if (this.vertical)
            {
                modo = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            }
            else
            {
                modo = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            }
            if (this.vertical && !this.monocolor)
            {
                c1 = this.colorRelleno2;
                c2 = this.colorRelleno1;
            }
            // Crear la brocha.
            System.Drawing.Rectangle r = new System.Drawing.Rectangle(0, 0, this.Width, this.Height);
            System.Drawing.Brush br;
            if (this.monocolor)
            {
                int R = System.Convert.ToInt32(c1.R + (c2.R - c1.R) * p);
                int G = System.Convert.ToInt32(c1.G + (c2.G - c1.G) * p);
                int B = System.Convert.ToInt32(c1.B + (c2.B - c1.B) * p);
                System.Drawing.Color c = System.Drawing.Color.FromArgb(R, G, B);
                br = new System.Drawing.SolidBrush(c);
            }
            else
            {
                br = new System.Drawing.Drawing2D.LinearGradientBrush(r, c1, c2, modo);
            }
            // Calcular la longitud de la barra.
            System.Drawing.Rectangle r2;
            if (this.vertical)
            {
                w = (int)(p * this.Height);
                r2 = new System.Drawing.Rectangle(0, this.Height - w, this.Width, this.Height);
            }
            else
            {
                w = (int)(p * this.Width);
                r2 = new System.Drawing.Rectangle(0, 0, w, this.Height);
            }
            // Dibujar la barra.
            e.Graphics.Clear(this.BackColor);
            e.Graphics.FillRectangle(br, r2);
            if (this.borde)
            {
                e.Graphics.DrawRectangle(new System.Drawing.Pen(this.colorBorde), 0, 0, this.Width - 1, this.Height - 1);
            }
        }
        /// <summary>
        /// OnResize.
        /// </summary>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
        #endregion
    }
}