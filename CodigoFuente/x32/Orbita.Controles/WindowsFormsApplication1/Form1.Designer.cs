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
            this.orbitaConfiguracionCanal1 = new Orbita.Controles.Comunicaciones.OrbitaConfiguracionCanal(this.components);
            this.orbitaConfiguracionCanal2 = new Orbita.Controles.Comunicaciones.OrbitaConfiguracionCanal(this.components);
            this.orbitaControlBaseEventosComs1 = new Orbita.Controles.Comunicaciones.OrbitaControlBaseEventosComs();
            this.orbitaControlBaseEventosComs2 = new Orbita.Controles.Comunicaciones.OrbitaControlBaseEventosComs();
            this.SuspendLayout();
            // 
            // orbitaConfiguracionCanal1
            // 
            this.orbitaConfiguracionCanal1.NombreCanal = "CanalRemoting1";
            this.orbitaConfiguracionCanal1.NombreLogger = null;
            this.orbitaConfiguracionCanal1.ReintentosReconexion = 3;
            this.orbitaConfiguracionCanal1.RemotingPuerto = 8001;
            this.orbitaConfiguracionCanal1.SegundosEventoEstado = 1;
            this.orbitaConfiguracionCanal1.SegundosReconexion = 2;
            this.orbitaConfiguracionCanal1.ServidorRemoting = "localhost";
            // 
            // orbitaConfiguracionCanal2
            // 
            this.orbitaConfiguracionCanal2.NombreCanal = "CanalRemoting2";
            this.orbitaConfiguracionCanal2.NombreLogger = null;
            this.orbitaConfiguracionCanal2.ReintentosReconexion = 3;
            this.orbitaConfiguracionCanal2.RemotingPuerto = 8002;
            this.orbitaConfiguracionCanal2.SegundosEventoEstado = 1;
            this.orbitaConfiguracionCanal2.SegundosReconexion = 2;
            this.orbitaConfiguracionCanal2.ServidorRemoting = "localhost";
            // 
            // orbitaControlBaseEventosComs1
            // 
            this.orbitaControlBaseEventosComs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orbitaControlBaseEventosComs1.Location = new System.Drawing.Point(49, 61);
            this.orbitaControlBaseEventosComs1.Name = "orbitaControlBaseEventosComs1";
            this.orbitaControlBaseEventosComs1.OI.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas")));
            this.orbitaControlBaseEventosComs1.OI.Alarmas.AlarmasArray = new string[0];
            this.orbitaControlBaseEventosComs1.OI.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios")));
            this.orbitaControlBaseEventosComs1.OI.CambioDato.CambiosArray = new string[0];
            this.orbitaControlBaseEventosComs1.OI.CambioDato.Variable = "stringOrbita1";
            this.orbitaControlBaseEventosComs1.OI.Comunicacion.IdDispositivo = 3;
            this.orbitaControlBaseEventosComs1.OI.Comunicacion.NombreCanal = "CanalRemoting1";
            this.orbitaControlBaseEventosComs1.Size = new System.Drawing.Size(150, 33);
            this.orbitaControlBaseEventosComs1.TabIndex = 0;
            // 
            // orbitaControlBaseEventosComs2
            // 
            this.orbitaControlBaseEventosComs2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orbitaControlBaseEventosComs2.Location = new System.Drawing.Point(253, 61);
            this.orbitaControlBaseEventosComs2.Name = "orbitaControlBaseEventosComs2";
            this.orbitaControlBaseEventosComs2.OI.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas1")));
            this.orbitaControlBaseEventosComs2.OI.Alarmas.AlarmasArray = new string[0];
            this.orbitaControlBaseEventosComs2.OI.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios1")));
            this.orbitaControlBaseEventosComs2.OI.CambioDato.CambiosArray = new string[0];
            this.orbitaControlBaseEventosComs2.OI.CambioDato.Variable = "stringOrbita1";
            this.orbitaControlBaseEventosComs2.OI.Comunicacion.IdDispositivo = 3;
            this.orbitaControlBaseEventosComs2.OI.Comunicacion.NombreCanal = "CanalRemoting2";
            this.orbitaControlBaseEventosComs2.Size = new System.Drawing.Size(150, 33);
            this.orbitaControlBaseEventosComs2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 464);
            this.Controls.Add(this.orbitaControlBaseEventosComs2);
            this.Controls.Add(this.orbitaControlBaseEventosComs1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Orbita.Controles.Comunicaciones.OrbitaConfiguracionCanal orbitaConfiguracionCanal1;
        private Orbita.Controles.Comunicaciones.OrbitaConfiguracionCanal orbitaConfiguracionCanal2;
        private Orbita.Controles.Comunicaciones.OrbitaControlBaseEventosComs orbitaControlBaseEventosComs1;
        private Orbita.Controles.Comunicaciones.OrbitaControlBaseEventosComs orbitaControlBaseEventosComs2;
    }
}

