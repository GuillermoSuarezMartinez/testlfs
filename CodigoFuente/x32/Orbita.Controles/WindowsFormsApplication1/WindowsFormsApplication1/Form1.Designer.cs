namespace WindowsFormsApplication1
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.orbitaConfiguracionCanal1 = new Orbita.Controles.Comunicaciones.OrbitaConfiguracionCanal(this.components);
            this.orbitaEstadoCanalLabel1 = new Orbita.Controles.Comunicaciones.OrbitaEstadoCanalLabel();
            this.orbitaEstadoCanal1 = new Orbita.Controles.Comunicaciones.OrbitaEstadoCanal();
            this.orbitaEstadoCanal2 = new Orbita.Controles.Comunicaciones.OrbitaEstadoCanal();
            this.orbitaEstadoCanalLabel2 = new Orbita.Controles.Comunicaciones.OrbitaEstadoCanalLabel();
            this.orbitaConfiguracionCanal2 = new Orbita.Controles.Comunicaciones.OrbitaConfiguracionCanal(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(360, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(21, 175);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(21, 204);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(21, 233);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(114, 175);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(114, 204);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // orbitaConfiguracionCanal1
            // 
            this.orbitaConfiguracionCanal1.NombreCanal = "CanalRemoting1";
            this.orbitaConfiguracionCanal1.NombreLogger = "ConfiguracionWrapper";
            this.orbitaConfiguracionCanal1.ReintentosReconexion = 3;
            this.orbitaConfiguracionCanal1.RemotingPuerto = 8000;
            this.orbitaConfiguracionCanal1.SegundosEventoEstado = 5;
            this.orbitaConfiguracionCanal1.SegundosReconexion = 10;
            this.orbitaConfiguracionCanal1.ServidorRemoting = "localhost";
            // 
            // orbitaEstadoCanalLabel1
            // 
            this.orbitaEstadoCanalLabel1.Location = new System.Drawing.Point(191, 42);
            this.orbitaEstadoCanalLabel1.Name = "orbitaEstadoCanalLabel1";
            this.orbitaEstadoCanalLabel1.OI.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas")));
            this.orbitaEstadoCanalLabel1.OI.Alarmas.AlarmasArray = new string[0];
            this.orbitaEstadoCanalLabel1.OI.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios")));
            this.orbitaEstadoCanalLabel1.OI.CambioDato.CambiosArray = new string[0];
            this.orbitaEstadoCanalLabel1.OI.CambioDato.Variable = "stringOrbita1";
            this.orbitaEstadoCanalLabel1.OI.Comunicacion.IdDispositivo = 3;
            this.orbitaEstadoCanalLabel1.OI.Comunicacion.NombreCanal = "CanalRemoting1";
            this.orbitaEstadoCanalLabel1.Size = new System.Drawing.Size(150, 22);
            this.orbitaEstadoCanalLabel1.TabIndex = 7;
            // 
            // orbitaEstadoCanal1
            // 
            this.orbitaEstadoCanal1.Location = new System.Drawing.Point(21, 41);
            this.orbitaEstadoCanal1.Name = "orbitaEstadoCanal1";
            this.orbitaEstadoCanal1.OI.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas1")));
            this.orbitaEstadoCanal1.OI.Alarmas.AlarmasArray = new string[0];
            this.orbitaEstadoCanal1.OI.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios1")));
            this.orbitaEstadoCanal1.OI.CambioDato.CambiosArray = new string[0];
            this.orbitaEstadoCanal1.OI.CambioDato.Variable = null;
            this.orbitaEstadoCanal1.OI.Comunicacion.IdDispositivo = 3;
            this.orbitaEstadoCanal1.OI.Comunicacion.NombreCanal = "CanalRemoting1";
            this.orbitaEstadoCanal1.Size = new System.Drawing.Size(150, 24);
            this.orbitaEstadoCanal1.TabIndex = 8;
            // 
            // orbitaEstadoCanal2
            // 
            this.orbitaEstadoCanal2.Location = new System.Drawing.Point(21, 90);
            this.orbitaEstadoCanal2.Name = "orbitaEstadoCanal2";
            this.orbitaEstadoCanal2.OI.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas2")));
            this.orbitaEstadoCanal2.OI.Alarmas.AlarmasArray = new string[0];
            this.orbitaEstadoCanal2.OI.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios2")));
            this.orbitaEstadoCanal2.OI.CambioDato.CambiosArray = new string[0];
            this.orbitaEstadoCanal2.OI.CambioDato.Variable = null;
            this.orbitaEstadoCanal2.OI.Comunicacion.IdDispositivo = 3;
            this.orbitaEstadoCanal2.OI.Comunicacion.NombreCanal = "CanalRemoting2";
            this.orbitaEstadoCanal2.Size = new System.Drawing.Size(150, 24);
            this.orbitaEstadoCanal2.TabIndex = 10;
            // 
            // orbitaEstadoCanalLabel2
            // 
            this.orbitaEstadoCanalLabel2.Location = new System.Drawing.Point(191, 91);
            this.orbitaEstadoCanalLabel2.Name = "orbitaEstadoCanalLabel2";
            this.orbitaEstadoCanalLabel2.OI.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas3")));
            this.orbitaEstadoCanalLabel2.OI.Alarmas.AlarmasArray = new string[0];
            this.orbitaEstadoCanalLabel2.OI.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios3")));
            this.orbitaEstadoCanalLabel2.OI.CambioDato.CambiosArray = new string[0];
            this.orbitaEstadoCanalLabel2.OI.CambioDato.Variable = "stringOrbita1";
            this.orbitaEstadoCanalLabel2.OI.Comunicacion.IdDispositivo = 3;
            this.orbitaEstadoCanalLabel2.OI.Comunicacion.NombreCanal = "CanalRemoting2";
            this.orbitaEstadoCanalLabel2.Size = new System.Drawing.Size(150, 22);
            this.orbitaEstadoCanalLabel2.TabIndex = 9;
            // 
            // orbitaConfiguracionCanal2
            // 
            this.orbitaConfiguracionCanal2.NombreCanal = "CanalRemoting2";
            this.orbitaConfiguracionCanal2.NombreLogger = "ConfiguracionWrapper";
            this.orbitaConfiguracionCanal2.ReintentosReconexion = 3;
            this.orbitaConfiguracionCanal2.RemotingPuerto = 8002;
            this.orbitaConfiguracionCanal2.SegundosEventoEstado = 5;
            this.orbitaConfiguracionCanal2.SegundosReconexion = 10;
            this.orbitaConfiguracionCanal2.ServidorRemoting = "localhost";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 337);
            this.Controls.Add(this.orbitaEstadoCanal2);
            this.Controls.Add(this.orbitaEstadoCanalLabel2);
            this.Controls.Add(this.orbitaEstadoCanal1);
            this.Controls.Add(this.orbitaEstadoCanalLabel1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Orbita.Controles.Comunicaciones.OrbitaConfiguracionCanal orbitaConfiguracionCanal1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private Orbita.Controles.Comunicaciones.OrbitaEstadoCanalLabel orbitaEstadoCanalLabel1;
        private Orbita.Controles.Comunicaciones.OrbitaEstadoCanal orbitaEstadoCanal1;
        private Orbita.Controles.Comunicaciones.OrbitaEstadoCanal orbitaEstadoCanal2;
        private Orbita.Controles.Comunicaciones.OrbitaEstadoCanalLabel orbitaEstadoCanalLabel2;
        private Orbita.Controles.Comunicaciones.OrbitaConfiguracionCanal orbitaConfiguracionCanal2;
    }
}

