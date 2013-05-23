namespace Orbita.Controles.Comunicaciones.Custom.Remoting
{
    partial class OrbitaClienteEventoComs
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtServidorRemoting = new System.Windows.Forms.TextBox();
            this.lblServidorRemoting = new System.Windows.Forms.Label();
            this.txtPuertoRemoting = new System.Windows.Forms.TextBox();
            this.lblPuertoRemoting = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.gbCDato = new System.Windows.Forms.GroupBox();
            this.listViewCDato = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewComunicaciones = new System.Windows.Forms.ListView();
            this.btnBorrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbCDato.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnBorrar);
            this.splitContainer1.Panel1.Controls.Add(this.txtServidorRemoting);
            this.splitContainer1.Panel1.Controls.Add(this.lblServidorRemoting);
            this.splitContainer1.Panel1.Controls.Add(this.txtPuertoRemoting);
            this.splitContainer1.Panel1.Controls.Add(this.lblPuertoRemoting);
            this.splitContainer1.Panel1.Controls.Add(this.btnConectar);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbCDato);
            this.splitContainer1.Size = new System.Drawing.Size(658, 345);
            this.splitContainer1.SplitterDistance = 135;
            this.splitContainer1.TabIndex = 32;
            // 
            // txtServidorRemoting
            // 
            this.txtServidorRemoting.Location = new System.Drawing.Point(418, 22);
            this.txtServidorRemoting.Name = "txtServidorRemoting";
            this.txtServidorRemoting.Size = new System.Drawing.Size(100, 20);
            this.txtServidorRemoting.TabIndex = 36;
            this.txtServidorRemoting.Text = "localhost";
            // 
            // lblServidorRemoting
            // 
            this.lblServidorRemoting.AutoSize = true;
            this.lblServidorRemoting.Location = new System.Drawing.Point(322, 26);
            this.lblServidorRemoting.Name = "lblServidorRemoting";
            this.lblServidorRemoting.Size = new System.Drawing.Size(97, 13);
            this.lblServidorRemoting.TabIndex = 35;
            this.lblServidorRemoting.Text = "Servidor Remoting:";
            // 
            // txtPuertoRemoting
            // 
            this.txtPuertoRemoting.Location = new System.Drawing.Point(205, 23);
            this.txtPuertoRemoting.Name = "txtPuertoRemoting";
            this.txtPuertoRemoting.Size = new System.Drawing.Size(100, 20);
            this.txtPuertoRemoting.TabIndex = 34;
            this.txtPuertoRemoting.Text = "1852";
            // 
            // lblPuertoRemoting
            // 
            this.lblPuertoRemoting.AutoSize = true;
            this.lblPuertoRemoting.Location = new System.Drawing.Point(111, 26);
            this.lblPuertoRemoting.Name = "lblPuertoRemoting";
            this.lblPuertoRemoting.Size = new System.Drawing.Size(89, 13);
            this.lblPuertoRemoting.TabIndex = 33;
            this.lblPuertoRemoting.Text = "Puerto Remoting:";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(19, 21);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 32;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // gbCDato
            // 
            this.gbCDato.Controls.Add(this.listViewCDato);
            this.gbCDato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCDato.Location = new System.Drawing.Point(0, 0);
            this.gbCDato.Name = "gbCDato";
            this.gbCDato.Padding = new System.Windows.Forms.Padding(10);
            this.gbCDato.Size = new System.Drawing.Size(658, 206);
            this.gbCDato.TabIndex = 31;
            this.gbCDato.TabStop = false;
            this.gbCDato.Text = "Cambio Dato";
            // 
            // listViewCDato
            // 
            this.listViewCDato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCDato.GridLines = true;
            this.listViewCDato.Location = new System.Drawing.Point(10, 23);
            this.listViewCDato.MultiSelect = false;
            this.listViewCDato.Name = "listViewCDato";
            this.listViewCDato.Size = new System.Drawing.Size(638, 173);
            this.listViewCDato.TabIndex = 13;
            this.listViewCDato.UseCompatibleStateImageBehavior = false;
            this.listViewCDato.View = System.Windows.Forms.View.List;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listViewComunicaciones);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 71);
            this.panel1.TabIndex = 37;
            // 
            // listViewComunicaciones
            // 
            this.listViewComunicaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewComunicaciones.GridLines = true;
            this.listViewComunicaciones.Location = new System.Drawing.Point(0, 0);
            this.listViewComunicaciones.MultiSelect = false;
            this.listViewComunicaciones.Name = "listViewComunicaciones";
            this.listViewComunicaciones.Size = new System.Drawing.Size(658, 71);
            this.listViewComunicaciones.TabIndex = 14;
            this.listViewComunicaciones.UseCompatibleStateImageBehavior = false;
            this.listViewComunicaciones.View = System.Windows.Forms.View.List;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(559, 21);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 38;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // OrbitaClienteEventoComs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "OrbitaClienteEventoComs";
            this.Size = new System.Drawing.Size(658, 345);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbCDato.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.TextBox txtServidorRemoting;
        private System.Windows.Forms.Label lblServidorRemoting;
        public System.Windows.Forms.TextBox txtPuertoRemoting;
        private System.Windows.Forms.Label lblPuertoRemoting;
        private System.Windows.Forms.Button btnConectar;
        public System.Windows.Forms.GroupBox gbCDato;
        private System.Windows.Forms.ListView listViewCDato;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewComunicaciones;
    }
}
