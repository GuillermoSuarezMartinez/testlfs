namespace Orbita.Controles.VA
{
    partial class OrbitaSplash
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaSplash));
            this.TableLayoutPanel = new Orbita.Controles.Contenedores.OrbitaTableLayoutPanel();
            this.PanelSplash = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.lblProducto = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblCompañia = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblMensaje = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblIdioma = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblMaquina = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblUsuario = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblVersion = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.pbLogo = new Orbita.Controles.Comunes.OrbitaPictureBox();
            this.TableLayoutPanel.SuspendLayout();
            this.PanelSplash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.TableLayoutPanel.ColumnCount = 3;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 246F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel.Controls.Add(this.PanelSplash, 1, 1);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 3;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(703, 465);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // PanelSplash
            // 
            this.PanelSplash.BackColor = System.Drawing.Color.White;
            this.PanelSplash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelSplash.Controls.Add(this.lblProducto);
            this.PanelSplash.Controls.Add(this.lblCompañia);
            this.PanelSplash.Controls.Add(this.lblMensaje);
            this.PanelSplash.Controls.Add(this.lblIdioma);
            this.PanelSplash.Controls.Add(this.lblMaquina);
            this.PanelSplash.Controls.Add(this.lblUsuario);
            this.PanelSplash.Controls.Add(this.lblVersion);
            this.PanelSplash.Controls.Add(this.pbLogo);
            this.PanelSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSplash.Location = new System.Drawing.Point(228, 102);
            this.PanelSplash.Margin = new System.Windows.Forms.Padding(0);
            this.PanelSplash.Name = "PanelSplash";
            this.PanelSplash.Size = new System.Drawing.Size(246, 260);
            this.PanelSplash.TabIndex = 0;
            // 
            // lblProducto
            // 
            this.lblProducto.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblProducto.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.ForeColor = System.Drawing.Color.Black;
            this.lblProducto.Location = new System.Drawing.Point(22, 119);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(204, 16);
            this.lblProducto.TabIndex = 15;
            this.lblProducto.Text = "Producto";
            this.lblProducto.UseMnemonic = false;
            // 
            // lblCompañia
            // 
            this.lblCompañia.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblCompañia.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompañia.ForeColor = System.Drawing.Color.Black;
            this.lblCompañia.Location = new System.Drawing.Point(22, 136);
            this.lblCompañia.Name = "lblCompañia";
            this.lblCompañia.Size = new System.Drawing.Size(204, 16);
            this.lblCompañia.TabIndex = 14;
            this.lblCompañia.Text = "Comañía";
            this.lblCompañia.UseMnemonic = false;
            // 
            // lblMensaje
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Center";
            this.lblMensaje.Appearance = appearance1;
            this.lblMensaje.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMensaje.Location = new System.Drawing.Point(0, 235);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblMensaje.OI.Apariencia.ColorFondo = System.Drawing.Color.Transparent;
            this.lblMensaje.OI.Apariencia.ColorTexto = System.Drawing.Color.Black;
            this.lblMensaje.Size = new System.Drawing.Size(244, 23);
            this.lblMensaje.TabIndex = 12;
            this.lblMensaje.UseMnemonic = false;
            // 
            // lblIdioma
            // 
            this.lblIdioma.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblIdioma.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdioma.ForeColor = System.Drawing.Color.Black;
            this.lblIdioma.Location = new System.Drawing.Point(22, 187);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(204, 16);
            this.lblIdioma.TabIndex = 11;
            this.lblIdioma.Text = "Idioma";
            this.lblIdioma.UseMnemonic = false;
            // 
            // lblMaquina
            // 
            this.lblMaquina.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblMaquina.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaquina.ForeColor = System.Drawing.Color.Black;
            this.lblMaquina.Location = new System.Drawing.Point(22, 153);
            this.lblMaquina.Name = "lblMaquina";
            this.lblMaquina.Size = new System.Drawing.Size(204, 16);
            this.lblMaquina.TabIndex = 10;
            this.lblMaquina.Text = "Equipo";
            this.lblMaquina.UseMnemonic = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblUsuario.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(22, 170);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(204, 16);
            this.lblUsuario.TabIndex = 9;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.UseMnemonic = false;
            // 
            // lblVersion
            // 
            this.lblVersion.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Black;
            this.lblVersion.Location = new System.Drawing.Point(22, 204);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(204, 16);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "Versión";
            this.lblVersion.UseMnemonic = false;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(12, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(220, 93);
            this.pbLogo.TabIndex = 2;
            this.pbLogo.TabStop = false;
            // 
            // OrbitaSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPanel);
            this.Name = "OrbitaSplash";
            this.Size = new System.Drawing.Size(703, 465);
            this.Load += new System.EventHandler(this.FrmSplash_Load);
            this.TableLayoutPanel.ResumeLayout(false);
            this.PanelSplash.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Contenedores.OrbitaTableLayoutPanel TableLayoutPanel;
        private Contenedores.OrbitaPanel PanelSplash;
        private Comunes.OrbitaPictureBox pbLogo;
        private Comunes.OrbitaUltraLabel lblProducto;
        private Comunes.OrbitaUltraLabel lblCompañia;
        private Comunes.OrbitaUltraLabel lblMensaje;
        private Comunes.OrbitaUltraLabel lblIdioma;
        private Comunes.OrbitaUltraLabel lblMaquina;
        private Comunes.OrbitaUltraLabel lblUsuario;
        private Comunes.OrbitaUltraLabel lblVersion;
    }
}
