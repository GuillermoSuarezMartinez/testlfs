using Orbita.Controles.Comunes;
using System.Windows.Forms;
namespace Orbita.Controles.VA
{
    partial class MensajeError
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.GprInfo = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox ();
            this.label8 = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.Label6 = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.Label5 = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.Label4 = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.Label3 = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.Label2 = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.Label1 = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.PnlInferior = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.TxtFichero = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.TxtMensaje = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.TxtLinea = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.TxtMetodo = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.TxtClase = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.TxtEnsamblado = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.TxtExcepcion = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.LabelTitulo = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.PictureBox = new Orbita.Controles.Comunes.OrbitaPictureBox();
            this.BtnMasInfo_ = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.BtnAceptar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.GprInfo)).BeginInit();
            this.GprInfo.SuspendLayout();
            this.PnlInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFichero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMensaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLinea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMetodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtClase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEnsamblado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtExcepcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GprInfo
            // 
            this.GprInfo.Controls.Add(this.TxtFichero);
            this.GprInfo.Controls.Add(this.TxtMensaje);
            this.GprInfo.Controls.Add(this.TxtLinea);
            this.GprInfo.Controls.Add(this.TxtMetodo);
            this.GprInfo.Controls.Add(this.TxtClase);
            this.GprInfo.Controls.Add(this.TxtEnsamblado);
            this.GprInfo.Controls.Add(this.TxtExcepcion);
            this.GprInfo.Controls.Add(this.label8);
            this.GprInfo.Controls.Add(this.Label6);
            this.GprInfo.Controls.Add(this.Label5);
            this.GprInfo.Controls.Add(this.Label4);
            this.GprInfo.Controls.Add(this.Label3);
            this.GprInfo.Controls.Add(this.Label2);
            this.GprInfo.Controls.Add(this.Label1);
            this.GprInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GprInfo.Location = new System.Drawing.Point(10, 103);
            this.GprInfo.Name = "GprInfo";
            this.GprInfo.Size = new System.Drawing.Size(518, 280);
            this.GprInfo.TabIndex = 15;
            this.GprInfo.Text = "Información del error";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Ensamblado:";
            this.label8.OI.Apariencia.AlineacionTextoHorizontal = AlineacionHorizontal.Derecha;
            this.label8.OI.Apariencia.AlineacionTextoVertical = AlineacionVertical.Arriba;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(61, 245);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(38, 13);
            this.Label6.TabIndex = 15;
            this.Label6.Text = "Línea:";
            this.Label6.OI.Apariencia.AlineacionTextoHorizontal = AlineacionHorizontal.Derecha;
            this.Label6.OI.Apariencia.AlineacionTextoVertical = AlineacionVertical.Arriba;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(53, 182);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(46, 13);
            this.Label5.TabIndex = 14;
            this.Label5.Text = "Método:";
            this.Label5.OI.Apariencia.AlineacionTextoHorizontal = AlineacionHorizontal.Derecha;
            this.Label5.OI.Apariencia.AlineacionTextoVertical = AlineacionVertical.Arriba;

            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(63, 156);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(36, 13);
            this.Label4.TabIndex = 13;
            this.Label4.Text = "Clase:";
            this.Label4.OI.Apariencia.AlineacionTextoHorizontal = AlineacionHorizontal.Derecha;
            this.Label4.OI.Apariencia.AlineacionTextoVertical = AlineacionVertical.Arriba;

            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(54, 208);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(45, 13);
            this.Label3.TabIndex = 18;
            this.Label3.Text = "Fichero:";
            this.Label3.OI.Apariencia.AlineacionTextoHorizontal = AlineacionHorizontal.Derecha;
            this.Label3.OI.Apariencia.AlineacionTextoVertical = AlineacionVertical.Arriba;

            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(39, 103);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(60, 13);
            this.Label2.TabIndex = 17;
            this.Label2.Text = "Excepcion:";
            this.Label2.OI.Apariencia.AlineacionTextoHorizontal = AlineacionHorizontal.Derecha;
            this.Label2.OI.Apariencia.AlineacionTextoVertical = AlineacionVertical.Arriba;

            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(49, 29);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(50, 13);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "Mensaje:";
            this.Label1.OI.Apariencia.AlineacionTextoHorizontal = AlineacionHorizontal.Derecha;
            this.Label1.OI.Apariencia.AlineacionTextoVertical = AlineacionVertical.Arriba;

            // 
            // PnlInferior
            // 
            this.PnlInferior.Controls.Add(this.BtnMasInfo_);
            this.PnlInferior.Controls.Add(this.BtnAceptar);
            this.PnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlInferior.Location = new System.Drawing.Point(10, 383);
            this.PnlInferior.Name = "PnlInferior";
            this.PnlInferior.Size = new System.Drawing.Size(518, 42);
            this.PnlInferior.TabIndex = 16;
            // 
            // TxtFichero
            // 
            this.TxtFichero.Enabled = false;
            this.TxtFichero.Location = new System.Drawing.Point(113, 205);
            this.TxtFichero.Multiline = true;
            this.TxtFichero.Name = "TxtFichero";
            this.TxtFichero.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtFichero.Size = new System.Drawing.Size(396, 32);
            this.TxtFichero.TabIndex = 33;
            // 
            // TxtMensaje
            // 
            this.TxtMensaje.Enabled = false;
            this.TxtMensaje.Location = new System.Drawing.Point(113, 25);
            this.TxtMensaje.Multiline = true;
            this.TxtMensaje.Name = "TxtMensaje";
            this.TxtMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtMensaje.Size = new System.Drawing.Size(396, 69);
            this.TxtMensaje.TabIndex = 32;
            // 
            // TxtLinea
            // 
            this.TxtLinea.Enabled = false;
            this.TxtLinea.Location = new System.Drawing.Point(113, 242);
            this.TxtLinea.Name = "TxtLinea";
            this.TxtLinea.Size = new System.Drawing.Size(396, 21);
            this.TxtLinea.TabIndex = 31;
            // 
            // TxtMetodo
            // 
            this.TxtMetodo.Enabled = false;
            this.TxtMetodo.Location = new System.Drawing.Point(113, 179);
            this.TxtMetodo.Name = "TxtMetodo";
            this.TxtMetodo.Size = new System.Drawing.Size(396, 21);
            this.TxtMetodo.TabIndex = 30;
            // 
            // TxtClase
            // 
            this.TxtClase.Enabled = false;
            this.TxtClase.Location = new System.Drawing.Point(113, 153);
            this.TxtClase.Name = "TxtClase";
            this.TxtClase.Size = new System.Drawing.Size(396, 21);
            this.TxtClase.TabIndex = 29;
            // 
            // TxtEnsamblado
            // 
            this.TxtEnsamblado.Enabled = false;
            this.TxtEnsamblado.Location = new System.Drawing.Point(113, 126);
            this.TxtEnsamblado.Name = "TxtEnsamblado";
            this.TxtEnsamblado.Size = new System.Drawing.Size(396, 21);
            this.TxtEnsamblado.TabIndex = 28;
            // 
            // TxtExcepcion
            // 
            this.TxtExcepcion.Enabled = false;
            this.TxtExcepcion.Location = new System.Drawing.Point(113, 100);
            this.TxtExcepcion.Name = "TxtExcepcion";
            this.TxtExcepcion.Size = new System.Drawing.Size(396, 21);
            this.TxtExcepcion.TabIndex = 27;
            // 
            // LabelTitulo
            // 
            this.LabelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTitulo.Location = new System.Drawing.Point(123, 29);
            this.LabelTitulo.Name = "LabelTitulo";
            this.LabelTitulo.Size = new System.Drawing.Size(361, 47);
            this.LabelTitulo.TabIndex = 14;
            this.LabelTitulo.Text = "Se ha producido un error interno de la aplicación.\r\nA continuación se detalla la " +
                "información relacionada con el error.\r\nEsta información sirve de ayuda para loca" +
                "lizar las causas del error.";
            this.LabelTitulo.UseMnemonic = false;
            // 
            // PictureBox
            // 
            this.PictureBox.Image = global::Orbita.Controles.VA.Properties.Resources.imgError64;
            this.PictureBox.Location = new System.Drawing.Point(16, 16);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(64, 64);
            this.PictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            this.PictureBox.TabIndex = 13;
            this.PictureBox.TabStop = false;
            // 
            // BtnMasInfo_
            // 
            appearance3.Image = global::Orbita.Controles.VA.Properties.Resources.ImgInfo24;
            this.BtnMasInfo_.Appearance = appearance3;
            this.BtnMasInfo_.ImageSize = new System.Drawing.Size(24, 24);
            this.BtnMasInfo_.Location = new System.Drawing.Point(6, 5);
            this.BtnMasInfo_.Name = "BtnMasInfo_";
            this.BtnMasInfo_.OI.Estilo = global::Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.BtnMasInfo_.Size = new System.Drawing.Size(98, 34);
            this.BtnMasInfo_.TabIndex = 33;
            this.BtnMasInfo_.Text = "Más info.";
            this.BtnMasInfo_.Click += new System.EventHandler(this.btnMasInfo_Click);
            // 
            // BtnAceptar
            // 
            appearance4.Image = global::Orbita.Controles.VA.Properties.Resources.btnOk24;
            this.BtnAceptar.Appearance = appearance4;
            this.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnAceptar.ImageSize = new System.Drawing.Size(24, 24);
            this.BtnAceptar.Location = new System.Drawing.Point(411, 5);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.OI.Estilo = global::Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.BtnAceptar.Size = new System.Drawing.Size(98, 34);
            this.BtnAceptar.TabIndex = 32;
            this.BtnAceptar.Text = "Aceptar";
            // 
            // MensajeError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 435);
            this.Controls.Add(this.GprInfo);
            this.Controls.Add(this.LabelTitulo);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.PnlInferior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MensajeError";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error de la aplicación...";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MensajeError_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GprInfo)).EndInit();
            this.GprInfo.ResumeLayout(false);
            this.GprInfo.PerformLayout();
            this.PnlInferior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TxtFichero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMensaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLinea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMetodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtClase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEnsamblado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtExcepcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Comunes.OrbitaUltraLabel LabelTitulo;
        private Contenedores.OrbitaUltraGroupBox  GprInfo;
        private Contenedores.OrbitaPanel PnlInferior;
        protected Comunes.OrbitaUltraButton BtnAceptar;
        protected Comunes.OrbitaUltraButton BtnMasInfo_;
        private Comunes.OrbitaTextBox TxtExcepcion;
        private Comunes.OrbitaTextBox TxtEnsamblado;
        private Comunes.OrbitaTextBox TxtClase;
        private Comunes.OrbitaTextBox TxtLinea;
        private Comunes.OrbitaTextBox TxtMetodo;
        private Comunes.OrbitaTextBox TxtMensaje;
        private Comunes.OrbitaTextBox TxtFichero;
        private Comunes.OrbitaPictureBox PictureBox;
        private Orbita.Controles.Comunes.OrbitaUltraLabel label8;
        private Orbita.Controles.Comunes.OrbitaUltraLabel Label6;
        private Orbita.Controles.Comunes.OrbitaUltraLabel Label5;
        private Orbita.Controles.Comunes.OrbitaUltraLabel Label4;
        private Orbita.Controles.Comunes.OrbitaUltraLabel Label3;
        private Orbita.Controles.Comunes.OrbitaUltraLabel Label2;
        private Orbita.Controles.Comunes.OrbitaUltraLabel Label1;
    }
}