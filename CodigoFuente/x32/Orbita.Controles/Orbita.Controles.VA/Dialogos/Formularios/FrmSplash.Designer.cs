namespace Orbita.Controles.VA
{
    partial class FrmSplash
    {
        #region Windows Form Designer generated code

        private System.ComponentModel.IContainer components;
        
        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Método necesario para admitir el Diseñador, no se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSplash));
            this.TimerRefresco = new System.Windows.Forms.Timer(this.components);
            this.lblUsuario = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblMaquina = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblIdioma = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblMensaje = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblVersion = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblCompañia = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblProducto = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.pbLogo = new Orbita.Controles.Comunes.OrbitaPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerRefresco
            // 
            this.TimerRefresco.Tick += new System.EventHandler(this.TimerRefresco_Tick);
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(22, 170);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(204, 16);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblMaquina
            // 
            this.lblMaquina.BackColor = System.Drawing.Color.Transparent;
            this.lblMaquina.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaquina.ForeColor = System.Drawing.Color.Black;
            this.lblMaquina.Location = new System.Drawing.Point(22, 153);
            this.lblMaquina.Name = "lblMaquina";
            this.lblMaquina.Size = new System.Drawing.Size(204, 16);
            this.lblMaquina.TabIndex = 3;
            this.lblMaquina.Text = "Equipo";
            // 
            // lblIdioma
            // 
            this.lblIdioma.BackColor = System.Drawing.Color.Transparent;
            this.lblIdioma.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdioma.ForeColor = System.Drawing.Color.Black;
            this.lblIdioma.Location = new System.Drawing.Point(22, 187);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(204, 16);
            this.lblIdioma.TabIndex = 4;
            this.lblIdioma.Text = "Idioma";
            // 
            // lblMensaje
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblMensaje.Appearance = appearance2;
            this.lblMensaje.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMensaje.Location = new System.Drawing.Point(0, 235);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.OI.Apariencia.ColorFondo = System.Drawing.Color.Transparent;
            this.lblMensaje.OI.Apariencia.ColorTexto = System.Drawing.Color.Black;
            this.lblMensaje.Size = new System.Drawing.Size(244, 23);
            this.lblMensaje.TabIndex = 5;
            this.lblMensaje.UseMnemonic = false;
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Black;
            this.lblVersion.Location = new System.Drawing.Point(22, 204);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(204, 16);
            this.lblVersion.TabIndex = 6;
            this.lblVersion.Text = "Versión";
            // 
            // lblCompañia
            // 
            this.lblCompañia.BackColor = System.Drawing.Color.Transparent;
            this.lblCompañia.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompañia.ForeColor = System.Drawing.Color.Black;
            this.lblCompañia.Location = new System.Drawing.Point(22, 136);
            this.lblCompañia.Name = "lblCompañia";
            this.lblCompañia.Size = new System.Drawing.Size(204, 16);
            this.lblCompañia.TabIndex = 7;
            this.lblCompañia.Text = "Comañía";
            // 
            // lblProducto
            // 
            this.lblProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblProducto.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.ForeColor = System.Drawing.Color.Black;
            this.lblProducto.Location = new System.Drawing.Point(22, 119);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(204, 16);
            this.lblProducto.TabIndex = 8;
            this.lblProducto.Text = "Producto";
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(12, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(220, 93);
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // FrmSplash
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(244, 258);
            this.ControlBox = false;
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.lblCompañia);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lblIdioma);
            this.Controls.Add(this.lblMaquina);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSplash";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSplash_FormClosing);
            this.Load += new System.EventHandler(this.FrmSplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Timer TimerRefresco;
        private Orbita.Controles.Comunes.OrbitaPictureBox pbLogo;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblUsuario;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblMaquina;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblMensaje;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblVersion;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblIdioma;

        #endregion
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblCompañia;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblProducto;
    }
}
