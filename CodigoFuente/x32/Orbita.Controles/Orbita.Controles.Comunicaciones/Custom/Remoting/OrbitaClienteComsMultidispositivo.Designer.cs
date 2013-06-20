namespace Orbita.Controles.Comunicaciones
{
    partial class OrbitaClienteComsMultidispositivo
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
            this.gbSup = new System.Windows.Forms.GroupBox();
            this.btnReconectar = new System.Windows.Forms.Button();
            this.checkBoxDispositivo = new System.Windows.Forms.CheckBox();
            this.lblTpoLect = new System.Windows.Forms.Label();
            this.lblCom = new System.Windows.Forms.Label();
            this.txtVarLeer = new System.Windows.Forms.TextBox();
            this.txtValLeer = new System.Windows.Forms.TextBox();
            this.btnLectura = new System.Windows.Forms.Button();
            this.btnEscritura = new System.Windows.Forms.Button();
            this.txtCom = new System.Windows.Forms.TextBox();
            this.lblVarLectura = new System.Windows.Forms.Label();
            this.cmbDispositivo = new System.Windows.Forms.ComboBox();
            this.txtServidorRemoting = new System.Windows.Forms.TextBox();
            this.lblServidorRemoting = new System.Windows.Forms.Label();
            this.lblIdDispositivo = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtPuertoRemoting = new System.Windows.Forms.TextBox();
            this.lblPuertoRemoting = new System.Windows.Forms.Label();
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.dataGridViewOrbita = new System.Windows.Forms.DataGridView();
            this.pnlOrbitaLecturas = new System.Windows.Forms.Panel();
            this.btnEscribirTodo = new System.Windows.Forms.Button();
            this.btnLeerVariablesOrbita = new System.Windows.Forms.Button();
            this.btnLeerAlarmasOrbita = new System.Windows.Forms.Button();
            this.gbInf = new System.Windows.Forms.GroupBox();
            this.splitContainerInf = new System.Windows.Forms.SplitContainer();
            this.gbCDato = new System.Windows.Forms.GroupBox();
            this.listViewCDato = new System.Windows.Forms.ListView();
            this.gbEventoComs = new System.Windows.Forms.GroupBox();
            this.listViewComs = new System.Windows.Forms.ListView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.gbSup.SuspendLayout();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrbita)).BeginInit();
            this.pnlOrbitaLecturas.SuspendLayout();
            this.gbInf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInf)).BeginInit();
            this.splitContainerInf.Panel1.SuspendLayout();
            this.splitContainerInf.Panel2.SuspendLayout();
            this.splitContainerInf.SuspendLayout();
            this.gbCDato.SuspendLayout();
            this.gbEventoComs.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSup
            // 
            this.gbSup.Controls.Add(this.btnReconectar);
            this.gbSup.Controls.Add(this.checkBoxDispositivo);
            this.gbSup.Controls.Add(this.lblTpoLect);
            this.gbSup.Controls.Add(this.lblCom);
            this.gbSup.Controls.Add(this.txtVarLeer);
            this.gbSup.Controls.Add(this.txtValLeer);
            this.gbSup.Controls.Add(this.btnLectura);
            this.gbSup.Controls.Add(this.btnEscritura);
            this.gbSup.Controls.Add(this.txtCom);
            this.gbSup.Controls.Add(this.lblVarLectura);
            this.gbSup.Controls.Add(this.cmbDispositivo);
            this.gbSup.Controls.Add(this.txtServidorRemoting);
            this.gbSup.Controls.Add(this.lblServidorRemoting);
            this.gbSup.Controls.Add(this.lblIdDispositivo);
            this.gbSup.Controls.Add(this.btnConectar);
            this.gbSup.Controls.Add(this.txtPuertoRemoting);
            this.gbSup.Controls.Add(this.lblPuertoRemoting);
            this.gbSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSup.Location = new System.Drawing.Point(0, 0);
            this.gbSup.Name = "gbSup";
            this.gbSup.Size = new System.Drawing.Size(1018, 107);
            this.gbSup.TabIndex = 35;
            this.gbSup.TabStop = false;
            this.gbSup.Text = "Configuración";
            // 
            // btnReconectar
            // 
            this.btnReconectar.Location = new System.Drawing.Point(795, 23);
            this.btnReconectar.Name = "btnReconectar";
            this.btnReconectar.Size = new System.Drawing.Size(75, 23);
            this.btnReconectar.TabIndex = 38;
            this.btnReconectar.Text = "Reconectar";
            this.btnReconectar.UseVisualStyleBackColor = true;
            this.btnReconectar.Click += new System.EventHandler(this.btnReconectar_Click);
            // 
            // checkBoxDispositivo
            // 
            this.checkBoxDispositivo.AutoSize = true;
            this.checkBoxDispositivo.Location = new System.Drawing.Point(795, 61);
            this.checkBoxDispositivo.Name = "checkBoxDispositivo";
            this.checkBoxDispositivo.Size = new System.Drawing.Size(223, 17);
            this.checkBoxDispositivo.TabIndex = 37;
            this.checkBoxDispositivo.Text = "Sólo eventos del dispositivo seleccionado";
            this.checkBoxDispositivo.UseVisualStyleBackColor = true;
            // 
            // lblTpoLect
            // 
            this.lblTpoLect.AutoSize = true;
            this.lblTpoLect.Location = new System.Drawing.Point(642, 62);
            this.lblTpoLect.Name = "lblTpoLect";
            this.lblTpoLect.Size = new System.Drawing.Size(0, 13);
            this.lblTpoLect.TabIndex = 36;
            // 
            // lblCom
            // 
            this.lblCom.AutoSize = true;
            this.lblCom.Location = new System.Drawing.Point(23, 62);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(88, 13);
            this.lblCom.TabIndex = 35;
            this.lblCom.Text = "Comunicaciones:";
            // 
            // txtVarLeer
            // 
            this.txtVarLeer.Location = new System.Drawing.Point(320, 58);
            this.txtVarLeer.Name = "txtVarLeer";
            this.txtVarLeer.Size = new System.Drawing.Size(120, 20);
            this.txtVarLeer.TabIndex = 30;
            // 
            // txtValLeer
            // 
            this.txtValLeer.Location = new System.Drawing.Point(564, 58);
            this.txtValLeer.Name = "txtValLeer";
            this.txtValLeer.Size = new System.Drawing.Size(100, 20);
            this.txtValLeer.TabIndex = 31;
            // 
            // btnLectura
            // 
            this.btnLectura.Location = new System.Drawing.Point(476, 58);
            this.btnLectura.Name = "btnLectura";
            this.btnLectura.Size = new System.Drawing.Size(75, 23);
            this.btnLectura.TabIndex = 29;
            this.btnLectura.Text = "leer";
            this.btnLectura.UseVisualStyleBackColor = true;
            this.btnLectura.Click += new System.EventHandler(this.btnLectura_Click);
            // 
            // btnEscritura
            // 
            this.btnEscritura.Location = new System.Drawing.Point(690, 57);
            this.btnEscritura.Name = "btnEscritura";
            this.btnEscritura.Size = new System.Drawing.Size(75, 23);
            this.btnEscritura.TabIndex = 32;
            this.btnEscritura.Text = "escribir";
            this.btnEscritura.UseVisualStyleBackColor = true;
            this.btnEscritura.Click += new System.EventHandler(this.btnEscritura_Click_1);
            // 
            // txtCom
            // 
            this.txtCom.Location = new System.Drawing.Point(116, 58);
            this.txtCom.Name = "txtCom";
            this.txtCom.Size = new System.Drawing.Size(100, 20);
            this.txtCom.TabIndex = 34;
            // 
            // lblVarLectura
            // 
            this.lblVarLectura.AutoSize = true;
            this.lblVarLectura.Location = new System.Drawing.Point(227, 62);
            this.lblVarLectura.Name = "lblVarLectura";
            this.lblVarLectura.Size = new System.Drawing.Size(87, 13);
            this.lblVarLectura.TabIndex = 33;
            this.lblVarLectura.Text = "Variable Lectura:";
            // 
            // cmbDispositivo
            // 
            this.cmbDispositivo.FormattingEnabled = true;
            this.cmbDispositivo.Location = new System.Drawing.Point(319, 25);
            this.cmbDispositivo.Name = "cmbDispositivo";
            this.cmbDispositivo.Size = new System.Drawing.Size(121, 21);
            this.cmbDispositivo.TabIndex = 28;
            // 
            // txtServidorRemoting
            // 
            this.txtServidorRemoting.Location = new System.Drawing.Point(564, 25);
            this.txtServidorRemoting.Name = "txtServidorRemoting";
            this.txtServidorRemoting.Size = new System.Drawing.Size(100, 20);
            this.txtServidorRemoting.TabIndex = 27;
            this.txtServidorRemoting.Text = "localhost";
            // 
            // lblServidorRemoting
            // 
            this.lblServidorRemoting.AutoSize = true;
            this.lblServidorRemoting.Location = new System.Drawing.Point(461, 28);
            this.lblServidorRemoting.Name = "lblServidorRemoting";
            this.lblServidorRemoting.Size = new System.Drawing.Size(97, 13);
            this.lblServidorRemoting.TabIndex = 26;
            this.lblServidorRemoting.Text = "Servidor Remoting:";
            // 
            // lblIdDispositivo
            // 
            this.lblIdDispositivo.AutoSize = true;
            this.lblIdDispositivo.Location = new System.Drawing.Point(241, 29);
            this.lblIdDispositivo.Name = "lblIdDispositivo";
            this.lblIdDispositivo.Size = new System.Drawing.Size(75, 13);
            this.lblIdDispositivo.TabIndex = 20;
            this.lblIdDispositivo.Text = "ID Dispositivo:";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(690, 23);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 19;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txtPuertoRemoting
            // 
            this.txtPuertoRemoting.Location = new System.Drawing.Point(116, 25);
            this.txtPuertoRemoting.Name = "txtPuertoRemoting";
            this.txtPuertoRemoting.Size = new System.Drawing.Size(100, 20);
            this.txtPuertoRemoting.TabIndex = 1;
            this.txtPuertoRemoting.Text = "8003";
            // 
            // lblPuertoRemoting
            // 
            this.lblPuertoRemoting.AutoSize = true;
            this.lblPuertoRemoting.Location = new System.Drawing.Point(22, 28);
            this.lblPuertoRemoting.Name = "lblPuertoRemoting";
            this.lblPuertoRemoting.Size = new System.Drawing.Size(89, 13);
            this.lblPuertoRemoting.TabIndex = 0;
            this.lblPuertoRemoting.Text = "Puerto Remoting:";
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.dataGridViewOrbita);
            this.gbMain.Controls.Add(this.pnlOrbitaLecturas);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 107);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(1018, 444);
            this.gbMain.TabIndex = 39;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "Lecturas-Escrituras";
            // 
            // dataGridViewOrbita
            // 
            this.dataGridViewOrbita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrbita.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOrbita.Location = new System.Drawing.Point(3, 71);
            this.dataGridViewOrbita.Name = "dataGridViewOrbita";
            this.dataGridViewOrbita.Size = new System.Drawing.Size(1012, 370);
            this.dataGridViewOrbita.TabIndex = 29;
            // 
            // pnlOrbitaLecturas
            // 
            this.pnlOrbitaLecturas.Controls.Add(this.btnLimpiar);
            this.pnlOrbitaLecturas.Controls.Add(this.btnEscribirTodo);
            this.pnlOrbitaLecturas.Controls.Add(this.btnLeerVariablesOrbita);
            this.pnlOrbitaLecturas.Controls.Add(this.btnLeerAlarmasOrbita);
            this.pnlOrbitaLecturas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrbitaLecturas.Location = new System.Drawing.Point(3, 16);
            this.pnlOrbitaLecturas.Name = "pnlOrbitaLecturas";
            this.pnlOrbitaLecturas.Size = new System.Drawing.Size(1012, 55);
            this.pnlOrbitaLecturas.TabIndex = 30;
            // 
            // btnEscribirTodo
            // 
            this.btnEscribirTodo.Location = new System.Drawing.Point(211, 14);
            this.btnEscribirTodo.Name = "btnEscribirTodo";
            this.btnEscribirTodo.Size = new System.Drawing.Size(92, 23);
            this.btnEscribirTodo.TabIndex = 28;
            this.btnEscribirTodo.Text = "escribir";
            this.btnEscribirTodo.UseVisualStyleBackColor = true;
            this.btnEscribirTodo.Click += new System.EventHandler(this.btnEscritura_Click);
            // 
            // btnLeerVariablesOrbita
            // 
            this.btnLeerVariablesOrbita.Location = new System.Drawing.Point(15, 14);
            this.btnLeerVariablesOrbita.Name = "btnLeerVariablesOrbita";
            this.btnLeerVariablesOrbita.Size = new System.Drawing.Size(92, 23);
            this.btnLeerVariablesOrbita.TabIndex = 14;
            this.btnLeerVariablesOrbita.Text = "Leer Variables";
            this.btnLeerVariablesOrbita.UseVisualStyleBackColor = true;
            this.btnLeerVariablesOrbita.Click += new System.EventHandler(this.btnLeerVariables_Click);
            // 
            // btnLeerAlarmasOrbita
            // 
            this.btnLeerAlarmasOrbita.Location = new System.Drawing.Point(113, 14);
            this.btnLeerAlarmasOrbita.Name = "btnLeerAlarmasOrbita";
            this.btnLeerAlarmasOrbita.Size = new System.Drawing.Size(92, 23);
            this.btnLeerAlarmasOrbita.TabIndex = 25;
            this.btnLeerAlarmasOrbita.Text = "Leer Alarmas";
            this.btnLeerAlarmasOrbita.UseVisualStyleBackColor = true;
            this.btnLeerAlarmasOrbita.Click += new System.EventHandler(this.btnLeerAlarmas_Click);
            // 
            // gbInf
            // 
            this.gbInf.Controls.Add(this.splitContainerInf);
            this.gbInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbInf.Location = new System.Drawing.Point(0, 551);
            this.gbInf.Name = "gbInf";
            this.gbInf.Size = new System.Drawing.Size(1018, 253);
            this.gbInf.TabIndex = 40;
            this.gbInf.TabStop = false;
            this.gbInf.Text = "Cambios";
            // 
            // splitContainerInf
            // 
            this.splitContainerInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainerInf.Location = new System.Drawing.Point(3, 41);
            this.splitContainerInf.Name = "splitContainerInf";
            this.splitContainerInf.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerInf.Panel1
            // 
            this.splitContainerInf.Panel1.Controls.Add(this.gbCDato);
            // 
            // splitContainerInf.Panel2
            // 
            this.splitContainerInf.Panel2.Controls.Add(this.gbEventoComs);
            this.splitContainerInf.Size = new System.Drawing.Size(1012, 209);
            this.splitContainerInf.SplitterDistance = 104;
            this.splitContainerInf.TabIndex = 39;
            // 
            // gbCDato
            // 
            this.gbCDato.Controls.Add(this.listViewCDato);
            this.gbCDato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCDato.Location = new System.Drawing.Point(0, 0);
            this.gbCDato.Name = "gbCDato";
            this.gbCDato.Padding = new System.Windows.Forms.Padding(10);
            this.gbCDato.Size = new System.Drawing.Size(1012, 104);
            this.gbCDato.TabIndex = 38;
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
            this.listViewCDato.Size = new System.Drawing.Size(992, 71);
            this.listViewCDato.TabIndex = 13;
            this.listViewCDato.UseCompatibleStateImageBehavior = false;
            this.listViewCDato.View = System.Windows.Forms.View.List;
            // 
            // gbEventoComs
            // 
            this.gbEventoComs.Controls.Add(this.listViewComs);
            this.gbEventoComs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEventoComs.Location = new System.Drawing.Point(0, 0);
            this.gbEventoComs.Name = "gbEventoComs";
            this.gbEventoComs.Padding = new System.Windows.Forms.Padding(10);
            this.gbEventoComs.Size = new System.Drawing.Size(1012, 101);
            this.gbEventoComs.TabIndex = 38;
            this.gbEventoComs.TabStop = false;
            this.gbEventoComs.Text = "Evento Coms";
            // 
            // listViewComs
            // 
            this.listViewComs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewComs.GridLines = true;
            this.listViewComs.Location = new System.Drawing.Point(10, 23);
            this.listViewComs.MultiSelect = false;
            this.listViewComs.Name = "listViewComs";
            this.listViewComs.Size = new System.Drawing.Size(992, 68);
            this.listViewComs.TabIndex = 13;
            this.listViewComs.UseCompatibleStateImageBehavior = false;
            this.listViewComs.View = System.Windows.Forms.View.List;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(309, 14);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(92, 23);
            this.btnLimpiar.TabIndex = 39;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // OrbitaClienteComsMultidispositivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.gbInf);
            this.Controls.Add(this.gbSup);
            this.Name = "OrbitaClienteComsMultidispositivo";
            this.Size = new System.Drawing.Size(1018, 804);
            this.Load += new System.EventHandler(this.OrbitaClienteComsMultidispositivo_Load);
            this.gbSup.ResumeLayout(false);
            this.gbSup.PerformLayout();
            this.gbMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrbita)).EndInit();
            this.pnlOrbitaLecturas.ResumeLayout(false);
            this.gbInf.ResumeLayout(false);
            this.splitContainerInf.Panel1.ResumeLayout(false);
            this.splitContainerInf.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInf)).EndInit();
            this.splitContainerInf.ResumeLayout(false);
            this.gbCDato.ResumeLayout(false);
            this.gbEventoComs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gbSup;
        public System.Windows.Forms.TextBox txtServidorRemoting;
        private System.Windows.Forms.Label lblServidorRemoting;
        public System.Windows.Forms.Label lblIdDispositivo;
        private System.Windows.Forms.Button btnConectar;
        public System.Windows.Forms.TextBox txtPuertoRemoting;
        private System.Windows.Forms.Label lblPuertoRemoting;
        private System.Windows.Forms.ComboBox cmbDispositivo;
        private System.Windows.Forms.Label lblTpoLect;
        public System.Windows.Forms.Label lblCom;
        public System.Windows.Forms.TextBox txtVarLeer;
        private System.Windows.Forms.TextBox txtValLeer;
        private System.Windows.Forms.Button btnLectura;
        private System.Windows.Forms.Button btnEscritura;
        public System.Windows.Forms.TextBox txtCom;
        private System.Windows.Forms.Label lblVarLectura;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.CheckBox checkBoxDispositivo;
        public System.Windows.Forms.DataGridView dataGridViewOrbita;
        public System.Windows.Forms.Panel pnlOrbitaLecturas;
        public System.Windows.Forms.Button btnEscribirTodo;
        public System.Windows.Forms.Button btnLeerVariablesOrbita;
        public System.Windows.Forms.Button btnLeerAlarmasOrbita;
        private System.Windows.Forms.GroupBox gbInf;
        private System.Windows.Forms.SplitContainer splitContainerInf;
        public System.Windows.Forms.GroupBox gbCDato;
        private System.Windows.Forms.ListView listViewCDato;
        public System.Windows.Forms.GroupBox gbEventoComs;
        private System.Windows.Forms.ListView listViewComs;
        private System.Windows.Forms.Button btnReconectar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}
