namespace Orbita.Controles.Comunicaciones
{
    partial class OrbitaRemotingClienteBase
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
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.txtServidorRemoting = new System.Windows.Forms.TextBox();
            this.lblServidorRemoting = new System.Windows.Forms.Label();
            this.txtIdDispositivo = new System.Windows.Forms.TextBox();
            this.lblIdDispositivo = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtPuertoRemoting = new System.Windows.Forms.TextBox();
            this.lblPuertoRemoting = new System.Windows.Forms.Label();
            this.pnlInf = new System.Windows.Forms.Panel();
            this.SContMain = new System.Windows.Forms.SplitContainer();
            this.SContMainSup = new System.Windows.Forms.SplitContainer();
            this.pnlComs = new System.Windows.Forms.Panel();
            this.lblTpoEsc = new System.Windows.Forms.Label();
            this.lblTpoLect = new System.Windows.Forms.Label();
            this.lblCom = new System.Windows.Forms.Label();
            this.txtVarLeer = new System.Windows.Forms.TextBox();
            this.txtValLeer = new System.Windows.Forms.TextBox();
            this.btnLectura = new System.Windows.Forms.Button();
            this.btnEscritura = new System.Windows.Forms.Button();
            this.txtCom = new System.Windows.Forms.TextBox();
            this.lblVarLectura = new System.Windows.Forms.Label();
            this.gbEscrituras = new System.Windows.Forms.GroupBox();
            this.dataGridViewEscrituras = new System.Windows.Forms.DataGridView();
            this.SContMainInf = new System.Windows.Forms.SplitContainer();
            this.gbVariables = new System.Windows.Forms.GroupBox();
            this.dataGridViewLecturas = new System.Windows.Forms.DataGridView();
            this.pnlLecturas = new System.Windows.Forms.Panel();
            this.btnLeerVariables = new System.Windows.Forms.Button();
            this.btnLeerAlarmas = new System.Windows.Forms.Button();
            this.gbCDato = new System.Windows.Forms.GroupBox();
            this.listViewCDato = new System.Windows.Forms.ListView();
            this.gbConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SContMain)).BeginInit();
            this.SContMain.Panel1.SuspendLayout();
            this.SContMain.Panel2.SuspendLayout();
            this.SContMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SContMainSup)).BeginInit();
            this.SContMainSup.Panel1.SuspendLayout();
            this.SContMainSup.Panel2.SuspendLayout();
            this.SContMainSup.SuspendLayout();
            this.pnlComs.SuspendLayout();
            this.gbEscrituras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEscrituras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SContMainInf)).BeginInit();
            this.SContMainInf.Panel1.SuspendLayout();
            this.SContMainInf.Panel2.SuspendLayout();
            this.SContMainInf.SuspendLayout();
            this.gbVariables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLecturas)).BeginInit();
            this.pnlLecturas.SuspendLayout();
            this.gbCDato.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConfig
            // 
            this.gbConfig.Controls.Add(this.txtServidorRemoting);
            this.gbConfig.Controls.Add(this.lblServidorRemoting);
            this.gbConfig.Controls.Add(this.txtIdDispositivo);
            this.gbConfig.Controls.Add(this.lblIdDispositivo);
            this.gbConfig.Controls.Add(this.btnConectar);
            this.gbConfig.Controls.Add(this.txtPuertoRemoting);
            this.gbConfig.Controls.Add(this.lblPuertoRemoting);
            this.gbConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbConfig.Location = new System.Drawing.Point(0, 0);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(1020, 65);
            this.gbConfig.TabIndex = 31;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "Configuración";
            // 
            // txtServidorRemoting
            // 
            this.txtServidorRemoting.Location = new System.Drawing.Point(521, 25);
            this.txtServidorRemoting.Name = "txtServidorRemoting";
            this.txtServidorRemoting.Size = new System.Drawing.Size(100, 20);
            this.txtServidorRemoting.TabIndex = 27;
            this.txtServidorRemoting.Text = "localhost";
            // 
            // lblServidorRemoting
            // 
            this.lblServidorRemoting.AutoSize = true;
            this.lblServidorRemoting.Location = new System.Drawing.Point(425, 29);
            this.lblServidorRemoting.Name = "lblServidorRemoting";
            this.lblServidorRemoting.Size = new System.Drawing.Size(97, 13);
            this.lblServidorRemoting.TabIndex = 26;
            this.lblServidorRemoting.Text = "Servidor Remoting:";
            // 
            // txtIdDispositivo
            // 
            this.txtIdDispositivo.Location = new System.Drawing.Point(319, 25);
            this.txtIdDispositivo.Name = "txtIdDispositivo";
            this.txtIdDispositivo.Size = new System.Drawing.Size(100, 20);
            this.txtIdDispositivo.TabIndex = 21;
            this.txtIdDispositivo.Text = "1";
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
            this.btnConectar.Location = new System.Drawing.Point(711, 23);
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
            this.txtPuertoRemoting.Text = "1852";
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
            // pnlInf
            // 
            this.pnlInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInf.Location = new System.Drawing.Point(0, 424);
            this.pnlInf.Name = "pnlInf";
            this.pnlInf.Size = new System.Drawing.Size(1020, 119);
            this.pnlInf.TabIndex = 33;
            // 
            // SContMain
            // 
            this.SContMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SContMain.Location = new System.Drawing.Point(0, 65);
            this.SContMain.Name = "SContMain";
            this.SContMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SContMain.Panel1
            // 
            this.SContMain.Panel1.Controls.Add(this.SContMainSup);
            // 
            // SContMain.Panel2
            // 
            this.SContMain.Panel2.Controls.Add(this.SContMainInf);
            this.SContMain.Size = new System.Drawing.Size(1020, 359);
            this.SContMain.SplitterDistance = 113;
            this.SContMain.TabIndex = 34;
            // 
            // SContMainSup
            // 
            this.SContMainSup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SContMainSup.Location = new System.Drawing.Point(0, 0);
            this.SContMainSup.Name = "SContMainSup";
            this.SContMainSup.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SContMainSup.Panel1
            // 
            this.SContMainSup.Panel1.Controls.Add(this.pnlComs);
            // 
            // SContMainSup.Panel2
            // 
            this.SContMainSup.Panel2.Controls.Add(this.gbEscrituras);
            this.SContMainSup.Size = new System.Drawing.Size(1020, 113);
            this.SContMainSup.SplitterDistance = 40;
            this.SContMainSup.TabIndex = 0;
            // 
            // pnlComs
            // 
            this.pnlComs.Controls.Add(this.lblTpoEsc);
            this.pnlComs.Controls.Add(this.lblTpoLect);
            this.pnlComs.Controls.Add(this.lblCom);
            this.pnlComs.Controls.Add(this.txtVarLeer);
            this.pnlComs.Controls.Add(this.txtValLeer);
            this.pnlComs.Controls.Add(this.btnLectura);
            this.pnlComs.Controls.Add(this.btnEscritura);
            this.pnlComs.Controls.Add(this.txtCom);
            this.pnlComs.Controls.Add(this.lblVarLectura);
            this.pnlComs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComs.Location = new System.Drawing.Point(0, 0);
            this.pnlComs.Name = "pnlComs";
            this.pnlComs.Size = new System.Drawing.Size(1020, 40);
            this.pnlComs.TabIndex = 21;
            // 
            // lblTpoEsc
            // 
            this.lblTpoEsc.AutoSize = true;
            this.lblTpoEsc.Location = new System.Drawing.Point(794, 17);
            this.lblTpoEsc.Name = "lblTpoEsc";
            this.lblTpoEsc.Size = new System.Drawing.Size(0, 13);
            this.lblTpoEsc.TabIndex = 18;
            // 
            // lblTpoLect
            // 
            this.lblTpoLect.AutoSize = true;
            this.lblTpoLect.Location = new System.Drawing.Point(627, 17);
            this.lblTpoLect.Name = "lblTpoLect";
            this.lblTpoLect.Size = new System.Drawing.Size(0, 13);
            this.lblTpoLect.TabIndex = 17;
            // 
            // lblCom
            // 
            this.lblCom.AutoSize = true;
            this.lblCom.Location = new System.Drawing.Point(23, 17);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(88, 13);
            this.lblCom.TabIndex = 16;
            this.lblCom.Text = "Comunicaciones:";
            // 
            // txtVarLeer
            // 
            this.txtVarLeer.Location = new System.Drawing.Point(319, 13);
            this.txtVarLeer.Name = "txtVarLeer";
            this.txtVarLeer.Size = new System.Drawing.Size(100, 20);
            this.txtVarLeer.TabIndex = 1;
            // 
            // txtValLeer
            // 
            this.txtValLeer.Location = new System.Drawing.Point(521, 13);
            this.txtValLeer.Name = "txtValLeer";
            this.txtValLeer.Size = new System.Drawing.Size(100, 20);
            this.txtValLeer.TabIndex = 2;
            // 
            // btnLectura
            // 
            this.btnLectura.Location = new System.Drawing.Point(440, 12);
            this.btnLectura.Name = "btnLectura";
            this.btnLectura.Size = new System.Drawing.Size(75, 23);
            this.btnLectura.TabIndex = 0;
            this.btnLectura.Text = "leer";
            this.btnLectura.UseVisualStyleBackColor = true;
            this.btnLectura.Click += new System.EventHandler(this.btnLectura_Click);
            // 
            // btnEscritura
            // 
            this.btnEscritura.Location = new System.Drawing.Point(711, 12);
            this.btnEscritura.Name = "btnEscritura";
            this.btnEscritura.Size = new System.Drawing.Size(75, 23);
            this.btnEscritura.TabIndex = 3;
            this.btnEscritura.Text = "escribir";
            this.btnEscritura.UseVisualStyleBackColor = true;
            this.btnEscritura.Click += new System.EventHandler(this.btnEscritura_Click);
            // 
            // txtCom
            // 
            this.txtCom.Location = new System.Drawing.Point(116, 13);
            this.txtCom.Name = "txtCom";
            this.txtCom.Size = new System.Drawing.Size(100, 20);
            this.txtCom.TabIndex = 15;
            // 
            // lblVarLectura
            // 
            this.lblVarLectura.AutoSize = true;
            this.lblVarLectura.Location = new System.Drawing.Point(226, 17);
            this.lblVarLectura.Name = "lblVarLectura";
            this.lblVarLectura.Size = new System.Drawing.Size(87, 13);
            this.lblVarLectura.TabIndex = 10;
            this.lblVarLectura.Text = "Variable Lectura:";
            // 
            // gbEscrituras
            // 
            this.gbEscrituras.Controls.Add(this.dataGridViewEscrituras);
            this.gbEscrituras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEscrituras.Location = new System.Drawing.Point(0, 0);
            this.gbEscrituras.Name = "gbEscrituras";
            this.gbEscrituras.Size = new System.Drawing.Size(1020, 69);
            this.gbEscrituras.TabIndex = 18;
            this.gbEscrituras.TabStop = false;
            this.gbEscrituras.Text = "Escrituras";
            // 
            // dataGridViewEscrituras
            // 
            this.dataGridViewEscrituras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEscrituras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEscrituras.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewEscrituras.Name = "dataGridViewEscrituras";
            this.dataGridViewEscrituras.Size = new System.Drawing.Size(1014, 50);
            this.dataGridViewEscrituras.TabIndex = 0;
            // 
            // SContMainInf
            // 
            this.SContMainInf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SContMainInf.Location = new System.Drawing.Point(0, 0);
            this.SContMainInf.Name = "SContMainInf";
            this.SContMainInf.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SContMainInf.Panel1
            // 
            this.SContMainInf.Panel1.Controls.Add(this.gbVariables);
            // 
            // SContMainInf.Panel2
            // 
            this.SContMainInf.Panel2.Controls.Add(this.gbCDato);
            this.SContMainInf.Size = new System.Drawing.Size(1020, 242);
            this.SContMainInf.SplitterDistance = 116;
            this.SContMainInf.TabIndex = 0;
            // 
            // gbVariables
            // 
            this.gbVariables.Controls.Add(this.dataGridViewLecturas);
            this.gbVariables.Controls.Add(this.pnlLecturas);
            this.gbVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbVariables.Location = new System.Drawing.Point(0, 0);
            this.gbVariables.Name = "gbVariables";
            this.gbVariables.Padding = new System.Windows.Forms.Padding(10);
            this.gbVariables.Size = new System.Drawing.Size(1020, 116);
            this.gbVariables.TabIndex = 28;
            this.gbVariables.TabStop = false;
            this.gbVariables.Text = "Lecturas";
            // 
            // dataGridViewLecturas
            // 
            this.dataGridViewLecturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLecturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLecturas.Location = new System.Drawing.Point(10, 68);
            this.dataGridViewLecturas.Name = "dataGridViewLecturas";
            this.dataGridViewLecturas.Size = new System.Drawing.Size(1000, 38);
            this.dataGridViewLecturas.TabIndex = 12;
            // 
            // pnlLecturas
            // 
            this.pnlLecturas.Controls.Add(this.btnLeerVariables);
            this.pnlLecturas.Controls.Add(this.btnLeerAlarmas);
            this.pnlLecturas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLecturas.Location = new System.Drawing.Point(10, 23);
            this.pnlLecturas.Name = "pnlLecturas";
            this.pnlLecturas.Size = new System.Drawing.Size(1000, 45);
            this.pnlLecturas.TabIndex = 28;
            // 
            // btnLeerVariables
            // 
            this.btnLeerVariables.Location = new System.Drawing.Point(15, 14);
            this.btnLeerVariables.Name = "btnLeerVariables";
            this.btnLeerVariables.Size = new System.Drawing.Size(92, 23);
            this.btnLeerVariables.TabIndex = 14;
            this.btnLeerVariables.Text = "Leer Variables";
            this.btnLeerVariables.UseVisualStyleBackColor = true;
            this.btnLeerVariables.Click += new System.EventHandler(this.btnLeerVariables_Click);
            // 
            // btnLeerAlarmas
            // 
            this.btnLeerAlarmas.Location = new System.Drawing.Point(113, 14);
            this.btnLeerAlarmas.Name = "btnLeerAlarmas";
            this.btnLeerAlarmas.Size = new System.Drawing.Size(92, 23);
            this.btnLeerAlarmas.TabIndex = 25;
            this.btnLeerAlarmas.Text = "Leer Alarmas";
            this.btnLeerAlarmas.UseVisualStyleBackColor = true;
            this.btnLeerAlarmas.Click += new System.EventHandler(this.btnLeerAlarmas_Click);
            // 
            // gbCDato
            // 
            this.gbCDato.Controls.Add(this.listViewCDato);
            this.gbCDato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCDato.Location = new System.Drawing.Point(0, 0);
            this.gbCDato.Name = "gbCDato";
            this.gbCDato.Padding = new System.Windows.Forms.Padding(10);
            this.gbCDato.Size = new System.Drawing.Size(1020, 122);
            this.gbCDato.TabIndex = 29;
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
            this.listViewCDato.Size = new System.Drawing.Size(1000, 89);
            this.listViewCDato.TabIndex = 13;
            this.listViewCDato.UseCompatibleStateImageBehavior = false;
            this.listViewCDato.View = System.Windows.Forms.View.List;
            // 
            // OrbitaClienteComs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SContMain);
            this.Controls.Add(this.gbConfig);
            this.Controls.Add(this.pnlInf);
            this.Name = "OrbitaClienteComs";
            this.Size = new System.Drawing.Size(1020, 543);
            this.Load += new System.EventHandler(this.OClienteComs_Load);
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            this.SContMain.Panel1.ResumeLayout(false);
            this.SContMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SContMain)).EndInit();
            this.SContMain.ResumeLayout(false);
            this.SContMainSup.Panel1.ResumeLayout(false);
            this.SContMainSup.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SContMainSup)).EndInit();
            this.SContMainSup.ResumeLayout(false);
            this.pnlComs.ResumeLayout(false);
            this.pnlComs.PerformLayout();
            this.gbEscrituras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEscrituras)).EndInit();
            this.SContMainInf.Panel1.ResumeLayout(false);
            this.SContMainInf.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SContMainInf)).EndInit();
            this.SContMainInf.ResumeLayout(false);
            this.gbVariables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLecturas)).EndInit();
            this.pnlLecturas.ResumeLayout(false);
            this.gbCDato.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblServidorRemoting;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label lblPuertoRemoting;
        /// <summary>
        /// panel de configuración
        /// </summary>
        public System.Windows.Forms.GroupBox gbConfig;
        /// <summary>
        /// Nombre del servidor remoting
        /// </summary>
        public System.Windows.Forms.TextBox txtServidorRemoting;
        /// <summary>
        /// Identificador del dispositivo
        /// </summary>
        public System.Windows.Forms.TextBox txtIdDispositivo;
        /// <summary>
        /// Puerto remoting
        /// </summary>
        public System.Windows.Forms.TextBox txtPuertoRemoting;
        /// <summary>
        /// Panel de información
        /// </summary>
        public System.Windows.Forms.Panel pnlInf;
        /// <summary>
        /// Contenedor principal
        /// </summary>
        public System.Windows.Forms.SplitContainer SContMain;
        /// <summary>
        /// Contenedor superior
        /// </summary>
        public System.Windows.Forms.SplitContainer SContMainSup;
        private System.Windows.Forms.Panel pnlComs;
        /// <summary>
        /// Etiqueta de comunicaciones
        /// </summary>
        public System.Windows.Forms.Label lblCom;
        /// <summary>
        /// Variables de lectura
        /// </summary>
        public System.Windows.Forms.TextBox txtVarLeer;
        private System.Windows.Forms.TextBox txtValLeer;
        private System.Windows.Forms.Button btnLectura;
        private System.Windows.Forms.Button btnEscritura;
        /// <summary>
        /// Variables de comunicación
        /// </summary>
        public System.Windows.Forms.TextBox txtCom;
        private System.Windows.Forms.Label lblVarLectura;
        /// <summary>
        /// Panel de escrituras
        /// </summary>
        public System.Windows.Forms.GroupBox gbEscrituras;
        private System.Windows.Forms.DataGridView dataGridViewEscrituras;
        /// <summary>
        /// Contenedor inferior
        /// </summary>
        public System.Windows.Forms.SplitContainer SContMainInf;
        /// <summary>
        /// Contendor de variables
        /// </summary>
        public System.Windows.Forms.GroupBox gbVariables;
        private System.Windows.Forms.DataGridView dataGridViewLecturas;
        private System.Windows.Forms.Panel pnlLecturas;
        private System.Windows.Forms.Button btnLeerVariables;
        private System.Windows.Forms.Button btnLeerAlarmas;
        /// <summary>
        /// 
        /// </summary>
        public System.Windows.Forms.GroupBox gbCDato;
        private System.Windows.Forms.ListView listViewCDato;
        private System.Windows.Forms.Label lblTpoLect;
        private System.Windows.Forms.Label lblTpoEsc;
        public System.Windows.Forms.Label lblIdDispositivo;
    }
}
