namespace Orbita.Controles.Comunes
{
    partial class OrbitaTecladoNumerico
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaTecladoNumerico));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PnlFondo = new System.Windows.Forms.Panel();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.PnlTexto = new System.Windows.Forms.Panel();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.PnlDesplegable = new System.Windows.Forms.Panel();
            this.BtnDropDown = new System.Windows.Forms.Button();
            this.PnlRet = new System.Windows.Forms.Panel();
            this.btnRetrocede = new System.Windows.Forms.Button();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.TableLayoutPanelFondo = new Orbita.Controles.Contenedores.OrbitaTableLayoutPanel();
            this.Panel1Vacio = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.PnlTeclas = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.BtnEsc = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btnIntro = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.PnlFondo.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.PnlTexto.SuspendLayout();
            this.PnlDesplegable.SuspendLayout();
            this.PnlRet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.TableLayoutPanelFondo.SuspendLayout();
            this.PnlTeclas.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlFondo
            // 
            this.PnlFondo.BackColor = System.Drawing.Color.LightGray;
            this.PnlFondo.Controls.Add(this.GridView);
            this.PnlFondo.Controls.Add(this.TableLayoutPanelFondo);
            this.PnlFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlFondo.Location = new System.Drawing.Point(0, 96);
            this.PnlFondo.Name = "PnlFondo";
            this.PnlFondo.Size = new System.Drawing.Size(439, 392);
            this.PnlFondo.TabIndex = 6;
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.PnlTexto);
            this.PnlTop.Controls.Add(this.PnlDesplegable);
            this.PnlTop.Controls.Add(this.PnlRet);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(439, 96);
            this.PnlTop.TabIndex = 5;
            // 
            // PnlTexto
            // 
            this.PnlTexto.Controls.Add(this.txtResultado);
            this.PnlTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTexto.Location = new System.Drawing.Point(93, 0);
            this.PnlTexto.Name = "PnlTexto";
            this.PnlTexto.Padding = new System.Windows.Forms.Padding(3);
            this.PnlTexto.Size = new System.Drawing.Size(253, 96);
            this.PnlTexto.TabIndex = 8;
            // 
            // txtResultado
            // 
            this.txtResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultado.Font = new System.Drawing.Font("Arial Black", 44F, System.Drawing.FontStyle.Bold);
            this.txtResultado.Location = new System.Drawing.Point(3, 3);
            this.txtResultado.Margin = new System.Windows.Forms.Padding(0);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(247, 90);
            this.txtResultado.TabIndex = 3;
            this.txtResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PnlDesplegable
            // 
            this.PnlDesplegable.Controls.Add(this.BtnDropDown);
            this.PnlDesplegable.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlDesplegable.Location = new System.Drawing.Point(0, 0);
            this.PnlDesplegable.Name = "PnlDesplegable";
            this.PnlDesplegable.Size = new System.Drawing.Size(93, 96);
            this.PnlDesplegable.TabIndex = 7;
            // 
            // BtnDropDown
            // 
            this.BtnDropDown.BackColor = System.Drawing.Color.White;
            this.BtnDropDown.Font = new System.Drawing.Font("Wingdings 3", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.BtnDropDown.Image = global::Orbita.Controles.Comunes.Properties.Resources.ImgComputerKey90;
            this.BtnDropDown.Location = new System.Drawing.Point(0, 3);
            this.BtnDropDown.Name = "BtnDropDown";
            this.BtnDropDown.Size = new System.Drawing.Size(90, 90);
            this.BtnDropDown.TabIndex = 4;
            this.BtnDropDown.Tag = "Desplegar";
            this.BtnDropDown.Text = "";
            this.BtnDropDown.UseVisualStyleBackColor = false;
            this.BtnDropDown.Click += new System.EventHandler(this.BtnDropDown_Click);
            this.BtnDropDown.Leave += new System.EventHandler(this.BtnDropDown_Leave);
            // 
            // PnlRet
            // 
            this.PnlRet.Controls.Add(this.btnRetrocede);
            this.PnlRet.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlRet.Location = new System.Drawing.Point(346, 0);
            this.PnlRet.Name = "PnlRet";
            this.PnlRet.Size = new System.Drawing.Size(93, 96);
            this.PnlRet.TabIndex = 6;
            // 
            // btnRetrocede
            // 
            this.btnRetrocede.BackColor = System.Drawing.Color.White;
            this.btnRetrocede.Font = new System.Drawing.Font("Wingdings 3", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRetrocede.Image = global::Orbita.Controles.Comunes.Properties.Resources.ImgComputerKey90;
            this.btnRetrocede.Location = new System.Drawing.Point(0, 3);
            this.btnRetrocede.Name = "btnRetrocede";
            this.btnRetrocede.Size = new System.Drawing.Size(90, 90);
            this.btnRetrocede.TabIndex = 4;
            this.btnRetrocede.Tag = "Ret";
            this.btnRetrocede.Text = "";
            this.btnRetrocede.UseVisualStyleBackColor = false;
            this.btnRetrocede.Click += new System.EventHandler(this.btnRetrocede_Click);
            // 
            // GridView
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridView.Location = new System.Drawing.Point(96, 3);
            this.GridView.MultiSelect = false;
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridView.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold);
            this.GridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.GridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold);
            this.GridView.RowTemplate.Height = 40;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(247, 389);
            this.GridView.TabIndex = 39;
            this.GridView.Visible = false;
            this.GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellClick);
            // 
            // TableLayoutPanelFondo
            // 
            this.TableLayoutPanelFondo.ColumnCount = 3;
            this.TableLayoutPanelFondo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelFondo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.TableLayoutPanelFondo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelFondo.Controls.Add(this.Panel1Vacio, 0, 0);
            this.TableLayoutPanelFondo.Controls.Add(this.PnlTeclas, 1, 0);
            this.TableLayoutPanelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelFondo.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelFondo.Name = "TableLayoutPanelFondo";
            this.TableLayoutPanelFondo.RowCount = 1;
            this.TableLayoutPanelFondo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelFondo.Size = new System.Drawing.Size(439, 392);
            this.TableLayoutPanelFondo.TabIndex = 38;
            // 
            // Panel1Vacio
            // 
            this.Panel1Vacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1Vacio.Location = new System.Drawing.Point(3, 3);
            this.Panel1Vacio.Name = "Panel1Vacio";
            this.Panel1Vacio.Size = new System.Drawing.Size(68, 386);
            this.Panel1Vacio.TabIndex = 41;
            // 
            // PnlTeclas
            // 
            this.PnlTeclas.Controls.Add(this.BtnEsc);
            this.PnlTeclas.Controls.Add(this.btn1);
            this.PnlTeclas.Controls.Add(this.btnIntro);
            this.PnlTeclas.Controls.Add(this.btn2);
            this.PnlTeclas.Controls.Add(this.btn3);
            this.PnlTeclas.Controls.Add(this.btn4);
            this.PnlTeclas.Controls.Add(this.btn5);
            this.PnlTeclas.Controls.Add(this.btn6);
            this.PnlTeclas.Controls.Add(this.btn7);
            this.PnlTeclas.Controls.Add(this.btn8);
            this.PnlTeclas.Controls.Add(this.btn9);
            this.PnlTeclas.Controls.Add(this.btn0);
            this.PnlTeclas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTeclas.Location = new System.Drawing.Point(77, 3);
            this.PnlTeclas.Name = "PnlTeclas";
            this.PnlTeclas.Size = new System.Drawing.Size(284, 386);
            this.PnlTeclas.TabIndex = 40;
            // 
            // BtnEsc
            // 
            this.BtnEsc.BackColor = System.Drawing.Color.White;
            this.BtnEsc.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEsc.Image = global::Orbita.Controles.Comunes.Properties.Resources.ImgComputerKey90;
            this.BtnEsc.Location = new System.Drawing.Point(97, 291);
            this.BtnEsc.Name = "BtnEsc";
            this.BtnEsc.Size = new System.Drawing.Size(90, 90);
            this.BtnEsc.TabIndex = 17;
            this.BtnEsc.Tag = "Esc";
            this.BtnEsc.Text = "Esc";
            this.BtnEsc.UseVisualStyleBackColor = false;
            this.BtnEsc.Click += new System.EventHandler(this.BtnEsc_Click);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.White;
            this.btn1.Font = new System.Drawing.Font("Arial Narrow", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Image = ((System.Drawing.Image)(resources.GetObject("btn1.Image")));
            this.btn1.Location = new System.Drawing.Point(3, 195);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(90, 90);
            this.btn1.TabIndex = 13;
            this.btn1.Tag = "1";
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnIntro
            // 
            this.btnIntro.BackColor = System.Drawing.Color.White;
            this.btnIntro.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIntro.Image = global::Orbita.Controles.Comunes.Properties.Resources.ImgComputerKey90;
            this.btnIntro.Location = new System.Drawing.Point(191, 291);
            this.btnIntro.Name = "btnIntro";
            this.btnIntro.Size = new System.Drawing.Size(90, 90);
            this.btnIntro.TabIndex = 16;
            this.btnIntro.Tag = "Intro";
            this.btnIntro.Text = "Intro";
            this.btnIntro.UseVisualStyleBackColor = false;
            this.btnIntro.Click += new System.EventHandler(this.btnIntro_Click);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.White;
            this.btn2.Font = new System.Drawing.Font("Arial Narrow", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Image = ((System.Drawing.Image)(resources.GetObject("btn2.Image")));
            this.btn2.Location = new System.Drawing.Point(97, 195);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(90, 90);
            this.btn2.TabIndex = 15;
            this.btn2.Tag = "2";
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.White;
            this.btn3.Font = new System.Drawing.Font("Arial Narrow", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Image = ((System.Drawing.Image)(resources.GetObject("btn3.Image")));
            this.btn3.Location = new System.Drawing.Point(191, 195);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(90, 90);
            this.btn3.TabIndex = 14;
            this.btn3.Tag = "3";
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.White;
            this.btn4.Font = new System.Drawing.Font("Arial Narrow", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Image = ((System.Drawing.Image)(resources.GetObject("btn4.Image")));
            this.btn4.Location = new System.Drawing.Point(3, 99);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(90, 90);
            this.btn4.TabIndex = 12;
            this.btn4.Tag = "4";
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.Transparent;
            this.btn5.FlatAppearance.BorderSize = 0;
            this.btn5.Font = new System.Drawing.Font("Arial Narrow", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Image = global::Orbita.Controles.Comunes.Properties.Resources.ImgComputerKey90;
            this.btn5.Location = new System.Drawing.Point(97, 99);
            this.btn5.Margin = new System.Windows.Forms.Padding(0);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(90, 90);
            this.btn5.TabIndex = 7;
            this.btn5.Tag = "5";
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.White;
            this.btn6.Font = new System.Drawing.Font("Arial Narrow", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.Image = ((System.Drawing.Image)(resources.GetObject("btn6.Image")));
            this.btn6.Location = new System.Drawing.Point(191, 99);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(90, 90);
            this.btn6.TabIndex = 6;
            this.btn6.Tag = "6";
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.White;
            this.btn7.Font = new System.Drawing.Font("Arial Narrow", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.Image = ((System.Drawing.Image)(resources.GetObject("btn7.Image")));
            this.btn7.Location = new System.Drawing.Point(3, 3);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(90, 90);
            this.btn7.TabIndex = 8;
            this.btn7.Tag = "7";
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.White;
            this.btn8.Font = new System.Drawing.Font("Arial Narrow", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.Image = ((System.Drawing.Image)(resources.GetObject("btn8.Image")));
            this.btn8.Location = new System.Drawing.Point(97, 3);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(90, 90);
            this.btn8.TabIndex = 10;
            this.btn8.Tag = "8";
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.White;
            this.btn9.Font = new System.Drawing.Font("Arial Narrow", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.Image = ((System.Drawing.Image)(resources.GetObject("btn9.Image")));
            this.btn9.Location = new System.Drawing.Point(191, 3);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(90, 90);
            this.btn9.TabIndex = 9;
            this.btn9.Tag = "9";
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.White;
            this.btn0.Font = new System.Drawing.Font("Arial Narrow", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.Image = ((System.Drawing.Image)(resources.GetObject("btn0.Image")));
            this.btn0.Location = new System.Drawing.Point(3, 291);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(90, 90);
            this.btn0.TabIndex = 11;
            this.btn0.Tag = "0";
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            this.btn0.Click += new System.EventHandler(this.btn_Click);
            // 
            // OrbitaTecladoNumerico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.PnlFondo);
            this.Controls.Add(this.PnlTop);
            this.Name = "OrbitaTecladoNumerico";
            this.Size = new System.Drawing.Size(439, 488);
            this.Load += new System.EventHandler(this.OrbitaControlTeclado_Load);
            this.PnlFondo.ResumeLayout(false);
            this.PnlTop.ResumeLayout(false);
            this.PnlTexto.ResumeLayout(false);
            this.PnlTexto.PerformLayout();
            this.PnlDesplegable.ResumeLayout(false);
            this.PnlRet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.TableLayoutPanelFondo.ResumeLayout(false);
            this.PnlTeclas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Button btnRetrocede;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Panel PnlFondo;
        private System.Windows.Forms.Panel PnlDesplegable;
        private System.Windows.Forms.Button BtnDropDown;
        private System.Windows.Forms.Panel PnlRet;
        private System.Windows.Forms.Panel PnlTexto;
        private Contenedores.OrbitaTableLayoutPanel TableLayoutPanelFondo;
        private Contenedores.OrbitaPanel PnlTeclas;
        private System.Windows.Forms.Button BtnEsc;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btnIntro;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.DataGridView GridView;
        private Contenedores.OrbitaPanel Panel1Vacio;
    }
}
