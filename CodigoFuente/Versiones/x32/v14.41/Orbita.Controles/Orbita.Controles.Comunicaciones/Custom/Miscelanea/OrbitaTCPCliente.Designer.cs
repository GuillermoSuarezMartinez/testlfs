namespace Orbita.Controles.Comunicaciones.Custom
{
    partial class OrbitaTCPCliente
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.gbMensajesEnviados = new System.Windows.Forms.GroupBox();
            this.txtEnvioDatos = new System.Windows.Forms.RichTextBox();
            this.gbEnviar = new System.Windows.Forms.GroupBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.gbMensajesRecibidos = new System.Windows.Forms.GroupBox();
            this.txtRecepcionDatos = new System.Windows.Forms.RichTextBox();
            this.gbConfiguracion = new System.Windows.Forms.GroupBox();
            this.gbMensajesEnviados.SuspendLayout();
            this.gbEnviar.SuspendLayout();
            this.gbMensajesRecibidos.SuspendLayout();
            this.gbConfiguracion.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(194, 35);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(63, 20);
            this.txtIP.TabIndex = 4;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(168, 38);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(20, 13);
            this.lblIP.TabIndex = 3;
            this.lblIP.Text = "IP:";
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Location = new System.Drawing.Point(21, 40);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(41, 13);
            this.lblPuerto.TabIndex = 1;
            this.lblPuerto.Text = "Puerto:";
            // 
            // gbMensajesEnviados
            // 
            this.gbMensajesEnviados.Controls.Add(this.txtEnvioDatos);
            this.gbMensajesEnviados.Controls.Add(this.gbEnviar);
            this.gbMensajesEnviados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbMensajesEnviados.Location = new System.Drawing.Point(0, 331);
            this.gbMensajesEnviados.Name = "gbMensajesEnviados";
            this.gbMensajesEnviados.Padding = new System.Windows.Forms.Padding(10);
            this.gbMensajesEnviados.Size = new System.Drawing.Size(710, 168);
            this.gbMensajesEnviados.TabIndex = 35;
            this.gbMensajesEnviados.TabStop = false;
            this.gbMensajesEnviados.Text = "Mensajes Enviados";
            // 
            // txtEnvioDatos
            // 
            this.txtEnvioDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtEnvioDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEnvioDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnvioDatos.Location = new System.Drawing.Point(10, 23);
            this.txtEnvioDatos.Name = "txtEnvioDatos";
            this.txtEnvioDatos.Size = new System.Drawing.Size(690, 90);
            this.txtEnvioDatos.TabIndex = 23;
            this.txtEnvioDatos.Text = "";
            // 
            // gbEnviar
            // 
            this.gbEnviar.Controls.Add(this.btnEnviar);
            this.gbEnviar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbEnviar.Location = new System.Drawing.Point(10, 113);
            this.gbEnviar.Name = "gbEnviar";
            this.gbEnviar.Padding = new System.Windows.Forms.Padding(10);
            this.gbEnviar.Size = new System.Drawing.Size(690, 45);
            this.gbEnviar.TabIndex = 31;
            this.gbEnviar.TabStop = false;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Location = new System.Drawing.Point(602, 14);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(283, 33);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 0;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(68, 36);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(63, 20);
            this.txtPuerto.TabIndex = 2;
            // 
            // gbMensajesRecibidos
            // 
            this.gbMensajesRecibidos.Controls.Add(this.txtRecepcionDatos);
            this.gbMensajesRecibidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMensajesRecibidos.Location = new System.Drawing.Point(0, 73);
            this.gbMensajesRecibidos.Name = "gbMensajesRecibidos";
            this.gbMensajesRecibidos.Padding = new System.Windows.Forms.Padding(10);
            this.gbMensajesRecibidos.Size = new System.Drawing.Size(710, 426);
            this.gbMensajesRecibidos.TabIndex = 34;
            this.gbMensajesRecibidos.TabStop = false;
            this.gbMensajesRecibidos.Text = "Mensajes Recibidos";
            // 
            // txtRecepcionDatos
            // 
            this.txtRecepcionDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtRecepcionDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecepcionDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecepcionDatos.Location = new System.Drawing.Point(10, 23);
            this.txtRecepcionDatos.Name = "txtRecepcionDatos";
            this.txtRecepcionDatos.Size = new System.Drawing.Size(690, 393);
            this.txtRecepcionDatos.TabIndex = 23;
            this.txtRecepcionDatos.Text = "";
            // 
            // gbConfiguracion
            // 
            this.gbConfiguracion.Controls.Add(this.txtIP);
            this.gbConfiguracion.Controls.Add(this.lblIP);
            this.gbConfiguracion.Controls.Add(this.txtPuerto);
            this.gbConfiguracion.Controls.Add(this.lblPuerto);
            this.gbConfiguracion.Controls.Add(this.btnConectar);
            this.gbConfiguracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbConfiguracion.Location = new System.Drawing.Point(0, 0);
            this.gbConfiguracion.Name = "gbConfiguracion";
            this.gbConfiguracion.Padding = new System.Windows.Forms.Padding(10);
            this.gbConfiguracion.Size = new System.Drawing.Size(710, 73);
            this.gbConfiguracion.TabIndex = 36;
            this.gbConfiguracion.TabStop = false;
            this.gbConfiguracion.Text = "Configuración";
            // 
            // OrbitaClienteTCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMensajesEnviados);
            this.Controls.Add(this.gbMensajesRecibidos);
            this.Controls.Add(this.gbConfiguracion);
            this.Name = "OrbitaClienteTCP";
            this.Size = new System.Drawing.Size(710, 499);
            this.gbMensajesEnviados.ResumeLayout(false);
            this.gbEnviar.ResumeLayout(false);
            this.gbMensajesRecibidos.ResumeLayout(false);
            this.gbConfiguracion.ResumeLayout(false);
            this.gbConfiguracion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.GroupBox gbMensajesEnviados;
        private System.Windows.Forms.RichTextBox txtEnvioDatos;
        private System.Windows.Forms.GroupBox gbEnviar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.GroupBox gbMensajesRecibidos;
        private System.Windows.Forms.RichTextBox txtRecepcionDatos;
        private System.Windows.Forms.GroupBox gbConfiguracion;
    }
}
