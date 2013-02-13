using Orbita.Controles.Shared;
using System;
namespace Orbita.Controles.VA
{
    partial class FrmGestionVariablesEdicion
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionVariablesEdicion));
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.cboTipo = new Orbita.Controles.Combo.OrbitaUltraCombo();
            this.lblCodigo = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.txtCodigo = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.checkTrazabilidad = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.txtNombre = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.lblTipo = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblNombre = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblGrupo = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.txtDescripcion = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.txtGrupo = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.lblDescripcion = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.checkHabilitado = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.btnAceptar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.btnCancelar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.pnlInferiorPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInferiorPadre
            // 
            this.pnlInferiorPadre.Location = new System.Drawing.Point(10, 262);
            this.pnlInferiorPadre.Size = new System.Drawing.Size(498, 43);
            // 
            // pnlPanelPrincipalPadre
            // 
            this.pnlPanelPrincipalPadre.Size = new System.Drawing.Size(498, 252);
            // 
            // cboTipo
            // 
            this.cboTipo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipo.Location = new System.Drawing.Point(90, 228);
            this.cboTipo.Margin = new System.Windows.Forms.Padding(0);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.OrbTexto = "";
            this.cboTipo.OrbValor = null;
            this.cboTipo.Size = new System.Drawing.Size(164, 21);
            this.cboTipo.TabIndex = 37;
            this.cboTipo.OrbCambiaValor += new EventHandler<System.EventArgs>(this.EventoValorCambiado);
            // 
            // lblCodigo
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblCodigo.Appearance = appearance1;
            this.lblCodigo.Location = new System.Drawing.Point(12, 12);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(72, 18);
            this.lblCodigo.TabIndex = 26;
            this.lblCodigo.Text = "Código";
            this.lblCodigo.UseMnemonic = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Franklin Gothic Book", 9F);
            this.txtCodigo.Location = new System.Drawing.Point(90, 12);
            this.txtCodigo.Multiline = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(414, 21);
            this.txtCodigo.TabIndex = 25;
            // 
            // checkTrazabilidad
            // 
            this.checkTrazabilidad.Location = new System.Drawing.Point(71, 200);
            this.checkTrazabilidad.Name = "checkTrazabilidad";
            this.checkTrazabilidad.Size = new System.Drawing.Size(228, 20);
            this.checkTrazabilidad.TabIndex = 35;
            this.checkTrazabilidad.Text = "Guardar trazabilidad";
            this.checkTrazabilidad.CheckedChanged += new System.EventHandler(this.EventoValorCambiado);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Franklin Gothic Book", 9F);
            this.txtNombre.Location = new System.Drawing.Point(90, 39);
            this.txtNombre.Multiline = false;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(414, 21);
            this.txtNombre.TabIndex = 27;
            // 
            // lblTipo
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblTipo.Appearance = appearance2;
            this.lblTipo.Location = new System.Drawing.Point(12, 228);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(72, 18);
            this.lblTipo.TabIndex = 33;
            this.lblTipo.Text = "Tipo";
            this.lblTipo.UseMnemonic = false;
            // 
            // lblNombre
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lblNombre.Appearance = appearance3;
            this.lblNombre.Location = new System.Drawing.Point(12, 39);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(72, 18);
            this.lblNombre.TabIndex = 28;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.UseMnemonic = false;
            // 
            // lblGrupo
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.lblGrupo.Appearance = appearance4;
            this.lblGrupo.Location = new System.Drawing.Point(12, 173);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(72, 18);
            this.lblGrupo.TabIndex = 34;
            this.lblGrupo.Text = "Grupo";
            this.lblGrupo.UseMnemonic = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Franklin Gothic Book", 9F);
            this.txtDescripcion.Location = new System.Drawing.Point(90, 66);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(414, 75);
            this.txtDescripcion.TabIndex = 29;
            // 
            // txtGrupo
            // 
            this.txtGrupo.Font = new System.Drawing.Font("Franklin Gothic Book", 9F);
            this.txtGrupo.Location = new System.Drawing.Point(90, 173);
            this.txtGrupo.Multiline = false;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(164, 21);
            this.txtGrupo.TabIndex = 32;
            // 
            // lblDescripcion
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.lblDescripcion.Appearance = appearance5;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 66);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(72, 18);
            this.lblDescripcion.TabIndex = 30;
            this.lblDescripcion.Text = "Descripción";
            this.lblDescripcion.UseMnemonic = false;
            // 
            // checkHabilitado
            // 
            this.checkHabilitado.Location = new System.Drawing.Point(71, 147);
            this.checkHabilitado.Name = "checkHabilitado";
            this.checkHabilitado.Size = new System.Drawing.Size(228, 20);
            this.checkHabilitado.TabIndex = 31;
            this.checkHabilitado.Text = "Habilitado";
            this.checkHabilitado.CheckedChanged += new System.EventHandler(this.EventoValorCambiado);
            // 
            // btnAceptar
            // 
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            this.btnAceptar.Appearance = appearance6;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.ImageSize = new System.Drawing.Size(24, 24);
            this.btnAceptar.Location = new System.Drawing.Point(304, 270);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.OrbTipo = TipoBoton.Aceptar;
            this.btnAceptar.Size = new System.Drawing.Size(98, 33);
            this.btnAceptar.TabIndex = 38;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            this.btnCancelar.Appearance = appearance7;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageSize = new System.Drawing.Size(24, 24);
            this.btnCancelar.Location = new System.Drawing.Point(408, 270);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OrbTipo = Orbita.Controles.Shared.TipoBoton.Cancelar;
            this.btnCancelar.Size = new System.Drawing.Size(98, 33);
            this.btnCancelar.TabIndex = 39;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmGestionVariablesEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 315);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.checkTrazabilidad);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtGrupo);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.checkHabilitado);
            this.Name = "FrmGestionVariablesEdicion";
            this.Text = "Edición variables";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGestionVariablesEdicion_FormClosing);
            this.Load += new System.EventHandler(this.FrmGestionVariablesEdicion_Load);
            this.Controls.SetChildIndex(this.checkHabilitado, 0);
            this.Controls.SetChildIndex(this.lblDescripcion, 0);
            this.Controls.SetChildIndex(this.txtGrupo, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.lblGrupo, 0);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.lblTipo, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.checkTrazabilidad, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.cboTipo, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.pnlInferiorPadre, 0);
            this.Controls.SetChildIndex(this.pnlPanelPrincipalPadre, 0);
            this.pnlInferiorPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrupo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Orbita.Controles.Combo.OrbitaUltraCombo cboTipo;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblCodigo;
        private Orbita.Controles.Comunes.OrbitaTextBox txtCodigo;
        private Orbita.Controles.Comunes.OrbitaUltraCheckEditor checkTrazabilidad;
        private Orbita.Controles.Comunes.OrbitaTextBox txtNombre;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblTipo;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblNombre;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblGrupo;
        private Orbita.Controles.Comunes.OrbitaTextBox txtDescripcion;
        private Orbita.Controles.Comunes.OrbitaTextBox txtGrupo;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblDescripcion;
        private Orbita.Controles.Comunes.OrbitaUltraCheckEditor checkHabilitado;
        private Orbita.Controles.Comunes.OrbitaUltraButton btnAceptar;
        private Orbita.Controles.Comunes.OrbitaUltraButton btnCancelar;
    }
}