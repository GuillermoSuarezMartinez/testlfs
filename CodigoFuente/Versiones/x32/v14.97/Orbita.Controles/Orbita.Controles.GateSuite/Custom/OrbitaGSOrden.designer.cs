using Orbita.Controles.Comunes;
namespace Orbita.Controles.GateSuite
{
    partial class OrbitaGSOrden
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaGSOrden));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.lblTextoOrden = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.lblBoton = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblPrecaucion = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.SuspendLayout();
            // 
            // lblTextoOrden
            // 
            this.lblTextoOrden.BackColor = System.Drawing.Color.White;
            this.lblTextoOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTextoOrden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextoOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoOrden.ForeColor = System.Drawing.Color.Black;
            this.lblTextoOrden.Location = new System.Drawing.Point(70, 0);
            this.lblTextoOrden.Margin = new System.Windows.Forms.Padding(15, 14, 15, 14);
            this.lblTextoOrden.Name = "lblTextoOrden";
            this.lblTextoOrden.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblTextoOrden.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblTextoOrden.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblTextoOrden.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblTextoOrden.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblTextoOrden.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblTextoOrden.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblTextoOrden.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas")));
            this.lblTextoOrden.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblTextoOrden.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios")));
            this.lblTextoOrden.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblTextoOrden.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblTextoOrden.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblTextoOrden.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblTextoOrden.Size = new System.Drawing.Size(398, 76);
            this.lblTextoOrden.TabIndex = 86;
            this.lblTextoOrden.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblTextoOrden_OnCambioDato);
            this.lblTextoOrden.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblTextoOrden_OnAlarma);
            this.lblTextoOrden.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblTextoOrden_OnComunicacion);
            // 
            // lblBoton
            // 
            appearance1.ImageBackground = global::Orbita.Controles.GateSuite.Properties.Resources.Teclado_72x72;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.lblBoton.Appearance = appearance1;
            this.lblBoton.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblBoton.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblBoton.ForeColor = System.Drawing.Color.White;
            this.lblBoton.Location = new System.Drawing.Point(0, 0);
            this.lblBoton.Name = "lblBoton";
            this.lblBoton.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Redondeado1;
            this.lblBoton.Size = new System.Drawing.Size(70, 76);
            this.lblBoton.TabIndex = 88;
            this.lblBoton.UseMnemonic = false;
            this.lblBoton.Click += new System.EventHandler(this.lblBoton_Click);
            // 
            // lblPrecaucion
            // 
            appearance2.ImageBackground = global::Orbita.Controles.GateSuite.Properties.Resources.Precaucion_64x64;
            this.lblPrecaucion.Appearance = appearance2;
            this.lblPrecaucion.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblPrecaucion.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblPrecaucion.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPrecaucion.Location = new System.Drawing.Point(468, 0);
            this.lblPrecaucion.Name = "lblPrecaucion";
            this.lblPrecaucion.Size = new System.Drawing.Size(70, 76);
            this.lblPrecaucion.TabIndex = 89;
            this.lblPrecaucion.UseMnemonic = false;
            this.lblPrecaucion.Visible = false;
            // 
            // OrbitaGSOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTextoOrden);
            this.Controls.Add(this.lblBoton);
            this.Controls.Add(this.lblPrecaucion);
            this.Name = "OrbitaGSOrden";                     
            this.Size = new System.Drawing.Size(538, 76);
            this.ResumeLayout(false);

        }

        #endregion

        public OrbitaUltraLabel lblPrecaucion;
        public OrbitaUltraLabel lblBoton;
        public OrbitaGSLabel lblTextoOrden;
    }
}
