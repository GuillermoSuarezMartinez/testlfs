namespace Orbita.Controles.Grid
{
    partial class FrmListadoPlantillasBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        System.ComponentModel.IContainer components = null;

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
        void InitializeComponent()
        {
            this.pnlBotones = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.btnCancelar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.btnAceptar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.lstView = new Orbita.Controles.Comunes.OrbitaListView();
            this.lblCabecera = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.pnlContenedor = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.lblSinElementos = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.pnlBotones.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnAceptar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBotones.Location = new System.Drawing.Point(572, 27);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(70, 319);
            this.pnlBotones.TabIndex = 14;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnCancelar.Location = new System.Drawing.Point(6, 33);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(63, 27);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "&Cancelar";
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnAceptar.Location = new System.Drawing.Point(6, 0);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(63, 27);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "&Aceptar";
            // 
            // lstView
            // 
            this.lstView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstView.Location = new System.Drawing.Point(0, 14);
            this.lstView.MultiSelect = false;
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(565, 303);
            this.lstView.TabIndex = 13;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            // 
            // lblCabecera
            // 
            this.lblCabecera.AutoSize = true;
            this.lblCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCabecera.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCabecera.ImageTransparentColor = System.Drawing.Color.Empty;
            this.lblCabecera.Location = new System.Drawing.Point(5, 5);
            this.lblCabecera.Name = "lblCabecera";
            this.lblCabecera.Padding = new System.Drawing.Size(0, 4);
            this.lblCabecera.Size = new System.Drawing.Size(637, 22);
            this.lblCabecera.TabIndex = 10;
            this.lblCabecera.Text = "cabecera";
            this.lblCabecera.UseMnemonic = false;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.SystemColors.Window;
            this.pnlContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContenedor.Controls.Add(this.lstView);
            this.pnlContenedor.Controls.Add(this.lblSinElementos);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(5, 27);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(567, 319);
            this.pnlContenedor.TabIndex = 15;
            // 
            // lblSinElementos
            // 
            this.lblSinElementos.AutoSize = true;
            this.lblSinElementos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSinElementos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSinElementos.ImageTransparentColor = System.Drawing.Color.Empty;
            this.lblSinElementos.Location = new System.Drawing.Point(0, 0);
            this.lblSinElementos.Name = "lblSinElementos";
            this.lblSinElementos.Size = new System.Drawing.Size(565, 14);
            this.lblSinElementos.TabIndex = 14;
            this.lblSinElementos.Text = "No existen elementos";
            this.lblSinElementos.UseMnemonic = false;
            // 
            // FrmListadoPlantillasBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 351);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.lblCabecera);
            this.MaximizeBox = false;
            this.Name = "FrmListadoPlantillasBase";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBotones.ResumeLayout(false);
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Orbita.Controles.Comunes.OrbitaUltraLabel lblCabecera;
        protected Orbita.Controles.Comunes.OrbitaListView lstView;
        protected Orbita.Controles.Contenedores.OrbitaPanel pnlBotones;
        protected Orbita.Controles.Contenedores.OrbitaPanel pnlContenedor;
        protected Orbita.Controles.Comunes.OrbitaUltraLabel lblSinElementos;
        Orbita.Controles.Comunes.OrbitaUltraButton btnCancelar;
        Orbita.Controles.Comunes.OrbitaUltraButton btnAceptar;
    }
}