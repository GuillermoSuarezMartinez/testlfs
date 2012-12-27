namespace Orbita.Controles.Grid
{
    partial class FrmGuardarArchivo
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
            this.components = new System.ComponentModel.Container();
            this.btnAceptar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.btnCancelar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.txtNombre = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.lblNombre = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.chbCrearNuevaPlantilla = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.txtDescripcion = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.lblDescripcion = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbCrearNuevaPlantilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnAceptar.Location = new System.Drawing.Point(293, 69);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(63, 27);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "&Aceptar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnCancelar.Location = new System.Drawing.Point(362, 69);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(63, 27);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Franklin Gothic Book", 9F);
            this.txtNombre.Location = new System.Drawing.Point(79, 12);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Multiline = false;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(345, 21);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNombre.ImageTransparentColor = System.Drawing.Color.Empty;
            this.lblNombre.Location = new System.Drawing.Point(28, 15);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.OrbColorFondo = System.Drawing.Color.Empty;
            this.lblNombre.OrbColorFuente = System.Drawing.Color.Empty;
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.UseMnemonic = false;
            // 
            // chbCrearNuevaPlantilla
            // 
            this.chbCrearNuevaPlantilla.Checked = true;
            this.chbCrearNuevaPlantilla.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCrearNuevaPlantilla.Location = new System.Drawing.Point(79, 73);
            this.chbCrearNuevaPlantilla.Name = "chbCrearNuevaPlantilla";
            this.chbCrearNuevaPlantilla.Size = new System.Drawing.Size(134, 20);
            this.chbCrearNuevaPlantilla.TabIndex = 4;
            this.chbCrearNuevaPlantilla.Text = "Crear nueva plantilla";
            this.chbCrearNuevaPlantilla.Visible = false;
            this.chbCrearNuevaPlantilla.CheckedChanged += new System.EventHandler(this.chbCrearNuevaPlantilla_CheckedChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Franklin Gothic Book", 9F);
            this.txtDescripcion.Location = new System.Drawing.Point(79, 39);
            this.txtDescripcion.MaxLength = 150;
            this.txtDescripcion.Multiline = false;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(346, 21);
            this.txtDescripcion.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDescripcion.ImageTransparentColor = System.Drawing.Color.Empty;
            this.lblDescripcion.Location = new System.Drawing.Point(9, 43);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.OrbColorFondo = System.Drawing.Color.Empty;
            this.lblDescripcion.OrbColorFuente = System.Drawing.Color.Empty;
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripción:";
            this.lblDescripcion.UseMnemonic = false;
            // 
            // DialogoGuardarArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 109);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.chbCrearNuevaPlantilla);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.Name = "DialogoGuardarArchivo";
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbCrearNuevaPlantilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        Orbita.Controles.Comunes.OrbitaUltraButton btnAceptar;
        Orbita.Controles.Comunes.OrbitaUltraButton btnCancelar;
        Orbita.Controles.Comunes.OrbitaTextBox txtNombre;
        Orbita.Controles.Comunes.OrbitaUltraLabel lblNombre;
        Orbita.Controles.Comunes.OrbitaUltraCheckEditor chbCrearNuevaPlantilla;
        Orbita.Controles.Comunes.OrbitaTextBox txtDescripcion;
        Orbita.Controles.Comunes.OrbitaUltraLabel lblDescripcion;
    }
}