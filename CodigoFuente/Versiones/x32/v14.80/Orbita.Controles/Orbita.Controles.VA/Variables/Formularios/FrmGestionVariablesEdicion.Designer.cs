////using Orbita.Controles.;
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.CboTipo = new Orbita.Controles.Combo.OrbitaUltraCombo();
            this.LblCodigo = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.TxtCodigo = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.ChkTrazabilidad = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.TxtNombre = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.LblTipo = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.LblNombre = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.LblGrupo = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.TxtDescripcion = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.TxtGrupo = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.LblDescripcion = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.ChkHabilitado = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.PnlInferiorPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).BeginInit();
            this.PnlPanelPrincipalPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkTrazabilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkHabilitado)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlInferiorPadre
            // 
            this.PnlInferiorPadre.Location = new System.Drawing.Point(10, 224);
            this.PnlInferiorPadre.Size = new System.Drawing.Size(518, 43);
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Location = new System.Drawing.Point(316, 0);
            // 
            // btnCancelar
            // 
            this.btnCancelar.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnCancelar.Size = new System.Drawing.Size(98, 33);
            // 
            // btnGuardar
            // 
            this.btnGuardar.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnGuardar.Size = new System.Drawing.Size(98, 33);
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.CboTipo);
            this.PnlPanelPrincipalPadre.Controls.Add(this.LblCodigo);
            this.PnlPanelPrincipalPadre.Controls.Add(this.TxtCodigo);
            this.PnlPanelPrincipalPadre.Controls.Add(this.ChkTrazabilidad);
            this.PnlPanelPrincipalPadre.Controls.Add(this.TxtNombre);
            this.PnlPanelPrincipalPadre.Controls.Add(this.LblTipo);
            this.PnlPanelPrincipalPadre.Controls.Add(this.LblNombre);
            this.PnlPanelPrincipalPadre.Controls.Add(this.LblGrupo);
            this.PnlPanelPrincipalPadre.Controls.Add(this.TxtDescripcion);
            this.PnlPanelPrincipalPadre.Controls.Add(this.TxtGrupo);
            this.PnlPanelPrincipalPadre.Controls.Add(this.LblDescripcion);
            this.PnlPanelPrincipalPadre.Controls.Add(this.ChkHabilitado);
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(518, 214);
            // 
            // CboTipo
            // 
            this.CboTipo.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.CboTipo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipo.Location = new System.Drawing.Point(90, 174);
            this.CboTipo.Margin = new System.Windows.Forms.Padding(0);
            this.CboTipo.Name = "CboTipo";
            this.CboTipo.Size = new System.Drawing.Size(164, 23);
            this.CboTipo.TabIndex = 37;
            // 
            // LblCodigo
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.LblCodigo.Appearance = appearance1;
            this.LblCodigo.Location = new System.Drawing.Point(12, 12);
            this.LblCodigo.Name = "LblCodigo";
            this.LblCodigo.Size = new System.Drawing.Size(72, 18);
            this.LblCodigo.TabIndex = 26;
            this.LblCodigo.Text = "Código";
            this.LblCodigo.UseMnemonic = false;
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Location = new System.Drawing.Point(90, 12);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(414, 20);
            this.TxtCodigo.TabIndex = 25;
            // 
            // ChkTrazabilidad
            // 
            this.ChkTrazabilidad.Location = new System.Drawing.Point(71, 146);
            this.ChkTrazabilidad.Name = "ChkTrazabilidad";
            this.ChkTrazabilidad.Size = new System.Drawing.Size(228, 20);
            this.ChkTrazabilidad.TabIndex = 35;
            this.ChkTrazabilidad.Text = "Guardar trazabilidad";
            this.ChkTrazabilidad.CheckedChanged += new System.EventHandler(this.EventoValorCambiado);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(90, 39);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(414, 20);
            this.TxtNombre.TabIndex = 27;
            // 
            // LblTipo
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.LblTipo.Appearance = appearance2;
            this.LblTipo.Location = new System.Drawing.Point(12, 174);
            this.LblTipo.Name = "LblTipo";
            this.LblTipo.Size = new System.Drawing.Size(72, 18);
            this.LblTipo.TabIndex = 33;
            this.LblTipo.Text = "Tipo";
            this.LblTipo.UseMnemonic = false;
            // 
            // LblNombre
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.LblNombre.Appearance = appearance3;
            this.LblNombre.Location = new System.Drawing.Point(12, 39);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(72, 18);
            this.LblNombre.TabIndex = 28;
            this.LblNombre.Text = "Nombre";
            this.LblNombre.UseMnemonic = false;
            // 
            // LblGrupo
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.LblGrupo.Appearance = appearance4;
            this.LblGrupo.Location = new System.Drawing.Point(12, 119);
            this.LblGrupo.Name = "LblGrupo";
            this.LblGrupo.Size = new System.Drawing.Size(72, 18);
            this.LblGrupo.TabIndex = 34;
            this.LblGrupo.Text = "Grupo";
            this.LblGrupo.UseMnemonic = false;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(90, 66);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtDescripcion.Size = new System.Drawing.Size(414, 20);
            this.TxtDescripcion.TabIndex = 29;
            // 
            // TxtGrupo
            // 
            this.TxtGrupo.Location = new System.Drawing.Point(90, 119);
            this.TxtGrupo.Name = "TxtGrupo";
            this.TxtGrupo.Size = new System.Drawing.Size(164, 20);
            this.TxtGrupo.TabIndex = 32;
            // 
            // LblDescripcion
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.LblDescripcion.Appearance = appearance5;
            this.LblDescripcion.Location = new System.Drawing.Point(12, 66);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(72, 18);
            this.LblDescripcion.TabIndex = 30;
            this.LblDescripcion.Text = "Descripción";
            this.LblDescripcion.UseMnemonic = false;
            // 
            // ChkHabilitado
            // 
            this.ChkHabilitado.Location = new System.Drawing.Point(71, 93);
            this.ChkHabilitado.Name = "ChkHabilitado";
            this.ChkHabilitado.Size = new System.Drawing.Size(228, 20);
            this.ChkHabilitado.TabIndex = 31;
            this.ChkHabilitado.Text = "Habilitado";
            this.ChkHabilitado.CheckedChanged += new System.EventHandler(this.EventoValorCambiado);
            // 
            // FrmGestionVariablesEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 277);
            this.ModoAperturaFormulario = Orbita.Controles.VA.ModoAperturaFormulario.Modificacion;
            this.Name = "FrmGestionVariablesEdicion";
            this.Text = "Edición variables";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGestionVariablesEdicion_FormClosing);
            this.Load += new System.EventHandler(this.FrmGestionVariablesEdicion_Load);
            this.PnlInferiorPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).EndInit();
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            this.PnlPanelPrincipalPadre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkTrazabilidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkHabilitado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Orbita.Controles.Combo.OrbitaUltraCombo CboTipo;
        private Orbita.Controles.Comunes.OrbitaUltraLabel LblCodigo;
        private Orbita.Controles.Comunes.OrbitaTextBox TxtCodigo;
        private Orbita.Controles.Comunes.OrbitaUltraCheckEditor ChkTrazabilidad;
        private Orbita.Controles.Comunes.OrbitaTextBox TxtNombre;
        private Orbita.Controles.Comunes.OrbitaUltraLabel LblTipo;
        private Orbita.Controles.Comunes.OrbitaUltraLabel LblNombre;
        private Orbita.Controles.Comunes.OrbitaUltraLabel LblGrupo;
        private Orbita.Controles.Comunes.OrbitaTextBox TxtDescripcion;
        private Orbita.Controles.Comunes.OrbitaTextBox TxtGrupo;
        private Orbita.Controles.Comunes.OrbitaUltraLabel LblDescripcion;
        private Orbita.Controles.Comunes.OrbitaUltraCheckEditor ChkHabilitado;
    }
}