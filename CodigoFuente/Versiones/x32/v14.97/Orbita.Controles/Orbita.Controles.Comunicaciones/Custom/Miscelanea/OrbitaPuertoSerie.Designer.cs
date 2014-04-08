namespace Orbita.Controles.Comunicaciones
{
    partial class OrbitaPuertoSerie
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
            this.gbPuertoSerie = new System.Windows.Forms.GroupBox();
            this.txtEnviar = new System.Windows.Forms.RichTextBox();
            this.txtConsola = new System.Windows.Forms.RichTextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnRecibir = new System.Windows.Forms.Button();
            this.brnCerrar = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.lblBitsParada = new System.Windows.Forms.Label();
            this.cmbBitsParada = new System.Windows.Forms.ComboBox();
            this.lblControlFlujo = new System.Windows.Forms.Label();
            this.cmbControlFlujo = new System.Windows.Forms.ComboBox();
            this.lblBitsDatos = new System.Windows.Forms.Label();
            this.cmbBitsDatos = new System.Windows.Forms.ComboBox();
            this.lblParidad = new System.Windows.Forms.Label();
            this.cmbParidad = new System.Windows.Forms.ComboBox();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.cmbPuerto = new System.Windows.Forms.ComboBox();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.cmbVelocidad = new System.Windows.Forms.ComboBox();
            this.gbPuertoSerie.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPuertoSerie
            // 
            this.gbPuertoSerie.Controls.Add(this.txtEnviar);
            this.gbPuertoSerie.Controls.Add(this.txtConsola);
            this.gbPuertoSerie.Controls.Add(this.btnEnviar);
            this.gbPuertoSerie.Controls.Add(this.btnRecibir);
            this.gbPuertoSerie.Controls.Add(this.brnCerrar);
            this.gbPuertoSerie.Controls.Add(this.btnAbrir);
            this.gbPuertoSerie.Controls.Add(this.lblBitsParada);
            this.gbPuertoSerie.Controls.Add(this.cmbBitsParada);
            this.gbPuertoSerie.Controls.Add(this.lblControlFlujo);
            this.gbPuertoSerie.Controls.Add(this.cmbControlFlujo);
            this.gbPuertoSerie.Controls.Add(this.lblBitsDatos);
            this.gbPuertoSerie.Controls.Add(this.cmbBitsDatos);
            this.gbPuertoSerie.Controls.Add(this.lblParidad);
            this.gbPuertoSerie.Controls.Add(this.cmbParidad);
            this.gbPuertoSerie.Controls.Add(this.lblPuerto);
            this.gbPuertoSerie.Controls.Add(this.cmbPuerto);
            this.gbPuertoSerie.Controls.Add(this.lblVelocidad);
            this.gbPuertoSerie.Controls.Add(this.cmbVelocidad);
            this.gbPuertoSerie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPuertoSerie.Location = new System.Drawing.Point(5, 5);
            this.gbPuertoSerie.Name = "gbPuertoSerie";
            this.gbPuertoSerie.Size = new System.Drawing.Size(549, 501);
            this.gbPuertoSerie.TabIndex = 0;
            this.gbPuertoSerie.TabStop = false;
            this.gbPuertoSerie.Text = "Control Puerto Serie";
            // 
            // txtEnviar
            // 
            this.txtEnviar.Location = new System.Drawing.Point(20, 385);
            this.txtEnviar.Name = "txtEnviar";
            this.txtEnviar.Size = new System.Drawing.Size(501, 71);
            this.txtEnviar.TabIndex = 34;
            this.txtEnviar.Text = "";
            // 
            // txtConsola
            // 
            this.txtConsola.Location = new System.Drawing.Point(20, 239);
            this.txtConsola.Name = "txtConsola";
            this.txtConsola.Size = new System.Drawing.Size(501, 71);
            this.txtConsola.TabIndex = 33;
            this.txtConsola.Text = "";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(20, 465);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 32;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnRecibir
            // 
            this.btnRecibir.Location = new System.Drawing.Point(20, 316);
            this.btnRecibir.Name = "btnRecibir";
            this.btnRecibir.Size = new System.Drawing.Size(75, 23);
            this.btnRecibir.TabIndex = 31;
            this.btnRecibir.Text = "Recibir";
            this.btnRecibir.UseVisualStyleBackColor = true;
            this.btnRecibir.Click += new System.EventHandler(this.btnRecibir_Click);
            // 
            // brnCerrar
            // 
            this.brnCerrar.Location = new System.Drawing.Point(404, 59);
            this.brnCerrar.Name = "brnCerrar";
            this.brnCerrar.Size = new System.Drawing.Size(117, 23);
            this.brnCerrar.TabIndex = 30;
            this.brnCerrar.Text = "Cerrar Puerto";
            this.brnCerrar.UseVisualStyleBackColor = true;
            this.brnCerrar.Click += new System.EventHandler(this.brnCerrar_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(404, 30);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(117, 23);
            this.btnAbrir.TabIndex = 29;
            this.btnAbrir.Text = "Abrir Puerto";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // lblBitsParada
            // 
            this.lblBitsParada.Location = new System.Drawing.Point(17, 157);
            this.lblBitsParada.Name = "lblBitsParada";
            this.lblBitsParada.Size = new System.Drawing.Size(87, 23);
            this.lblBitsParada.TabIndex = 28;
            this.lblBitsParada.Text = "Bits de parada";
            this.lblBitsParada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBitsParada
            // 
            this.cmbBitsParada.FormattingEnabled = true;
            this.cmbBitsParada.Location = new System.Drawing.Point(123, 158);
            this.cmbBitsParada.Name = "cmbBitsParada";
            this.cmbBitsParada.Size = new System.Drawing.Size(121, 21);
            this.cmbBitsParada.TabIndex = 27;
            // 
            // lblControlFlujo
            // 
            this.lblControlFlujo.Location = new System.Drawing.Point(17, 189);
            this.lblControlFlujo.Name = "lblControlFlujo";
            this.lblControlFlujo.Size = new System.Drawing.Size(87, 23);
            this.lblControlFlujo.TabIndex = 26;
            this.lblControlFlujo.Text = "Control de fujo";
            this.lblControlFlujo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbControlFlujo
            // 
            this.cmbControlFlujo.FormattingEnabled = true;
            this.cmbControlFlujo.Location = new System.Drawing.Point(123, 190);
            this.cmbControlFlujo.Name = "cmbControlFlujo";
            this.cmbControlFlujo.Size = new System.Drawing.Size(121, 21);
            this.cmbControlFlujo.TabIndex = 25;
            // 
            // lblBitsDatos
            // 
            this.lblBitsDatos.Location = new System.Drawing.Point(17, 93);
            this.lblBitsDatos.Name = "lblBitsDatos";
            this.lblBitsDatos.Size = new System.Drawing.Size(87, 23);
            this.lblBitsDatos.TabIndex = 24;
            this.lblBitsDatos.Text = "Bits de datos";
            this.lblBitsDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBitsDatos
            // 
            this.cmbBitsDatos.FormattingEnabled = true;
            this.cmbBitsDatos.Location = new System.Drawing.Point(123, 94);
            this.cmbBitsDatos.Name = "cmbBitsDatos";
            this.cmbBitsDatos.Size = new System.Drawing.Size(121, 21);
            this.cmbBitsDatos.TabIndex = 23;
            // 
            // lblParidad
            // 
            this.lblParidad.Location = new System.Drawing.Point(17, 125);
            this.lblParidad.Name = "lblParidad";
            this.lblParidad.Size = new System.Drawing.Size(87, 23);
            this.lblParidad.TabIndex = 22;
            this.lblParidad.Text = "Paridad";
            this.lblParidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbParidad
            // 
            this.cmbParidad.FormattingEnabled = true;
            this.cmbParidad.Location = new System.Drawing.Point(123, 126);
            this.cmbParidad.Name = "cmbParidad";
            this.cmbParidad.Size = new System.Drawing.Size(121, 21);
            this.cmbParidad.TabIndex = 21;
            // 
            // lblPuerto
            // 
            this.lblPuerto.Location = new System.Drawing.Point(17, 29);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(87, 23);
            this.lblPuerto.TabIndex = 20;
            this.lblPuerto.Text = "Puerto";
            this.lblPuerto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPuerto
            // 
            this.cmbPuerto.FormattingEnabled = true;
            this.cmbPuerto.Location = new System.Drawing.Point(123, 30);
            this.cmbPuerto.Name = "cmbPuerto";
            this.cmbPuerto.Size = new System.Drawing.Size(121, 21);
            this.cmbPuerto.TabIndex = 19;
            // 
            // lblVelocidad
            // 
            this.lblVelocidad.Location = new System.Drawing.Point(17, 61);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(87, 23);
            this.lblVelocidad.TabIndex = 18;
            this.lblVelocidad.Text = "Velocidad";
            this.lblVelocidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbVelocidad
            // 
            this.cmbVelocidad.FormattingEnabled = true;
            this.cmbVelocidad.Location = new System.Drawing.Point(123, 62);
            this.cmbVelocidad.Name = "cmbVelocidad";
            this.cmbVelocidad.Size = new System.Drawing.Size(121, 21);
            this.cmbVelocidad.TabIndex = 17;
            // 
            // OrbitaPuertoSerie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPuertoSerie);
            this.Name = "OrbitaPuertoSerie";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(559, 511);
            this.gbPuertoSerie.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPuertoSerie;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnRecibir;
        private System.Windows.Forms.Button brnCerrar;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Label lblBitsParada;
        private System.Windows.Forms.ComboBox cmbBitsParada;
        private System.Windows.Forms.Label lblControlFlujo;
        private System.Windows.Forms.ComboBox cmbControlFlujo;
        private System.Windows.Forms.Label lblBitsDatos;
        private System.Windows.Forms.ComboBox cmbBitsDatos;
        private System.Windows.Forms.Label lblParidad;
        private System.Windows.Forms.ComboBox cmbParidad;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.ComboBox cmbPuerto;
        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.ComboBox cmbVelocidad;
        private System.Windows.Forms.RichTextBox txtEnviar;
        private System.Windows.Forms.RichTextBox txtConsola;
    }
}
