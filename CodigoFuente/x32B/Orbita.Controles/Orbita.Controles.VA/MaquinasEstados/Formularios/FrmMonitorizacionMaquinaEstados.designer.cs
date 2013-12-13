using Orbita.VA.MaquinasEstados;
namespace Orbita.Controles.VA
{
	partial class FrmMonitorizacionMaquinaEstados
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
            this.SplitPrincipal = new Orbita.Controles.Contenedores.OrbitaSplitContainer();
            this.CtrlStateMachineDisplay = new Orbita.Controles.VA.OrbitaVisorMaquinaEstados();
            this.PicMaquinaEstados = new Orbita.Controles.Comunes.OrbitaPictureBox();
            this.ListMensajes = new Orbita.Controles.Comunes.OrbitaListView();
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.PnlPanelPrincipalPadre.SuspendLayout();
            this.PnlInferiorPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitPrincipal)).BeginInit();
            this.SplitPrincipal.Panel1.SuspendLayout();
            this.SplitPrincipal.Panel2.SuspendLayout();
            this.SplitPrincipal.SuspendLayout();
            this.CtrlStateMachineDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicMaquinaEstados)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.SplitPrincipal);
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(851, 466);
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
            // PnlInferiorPadre
            // 
            this.PnlInferiorPadre.Location = new System.Drawing.Point(10, 476);
            this.PnlInferiorPadre.Size = new System.Drawing.Size(851, 43);
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Location = new System.Drawing.Point(649, 0);
            // 
            // SplitPrincipal
            // 
            this.SplitPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitPrincipal.Location = new System.Drawing.Point(0, 0);
            this.SplitPrincipal.Name = "SplitPrincipal";
            this.SplitPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitPrincipal.Panel1
            // 
            this.SplitPrincipal.Panel1.Controls.Add(this.CtrlStateMachineDisplay);
            this.SplitPrincipal.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // SplitPrincipal.Panel2
            // 
            this.SplitPrincipal.Panel2.Controls.Add(this.ListMensajes);
            this.SplitPrincipal.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SplitPrincipal.Panel2MinSize = 50;
            this.SplitPrincipal.Size = new System.Drawing.Size(851, 466);
            this.SplitPrincipal.SplitterDistance = 357;
            this.SplitPrincipal.TabIndex = 13;
            // 
            // CtrlStateMachineDisplay
            // 
            this.CtrlStateMachineDisplay.Controls.Add(this.PicMaquinaEstados);
            this.CtrlStateMachineDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlStateMachineDisplay.Location = new System.Drawing.Point(0, 0);
            this.CtrlStateMachineDisplay.Name = "CtrlStateMachineDisplay";
            this.CtrlStateMachineDisplay.Size = new System.Drawing.Size(851, 357);
            this.CtrlStateMachineDisplay.TabIndex = 15;
            this.CtrlStateMachineDisplay.OnMensajeMaquinaEstados += new Orbita.VA.MaquinasEstados.MensajeMaquinaEstadosLanzado(this.ctrlStateMachineDisplay_OnMensajeMaquinaEstadosRecibido);
            // 
            // PicMaquinaEstados
            // 
            this.PicMaquinaEstados.BackColor = System.Drawing.SystemColors.Window;
            this.PicMaquinaEstados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicMaquinaEstados.Location = new System.Drawing.Point(0, 0);
            this.PicMaquinaEstados.Name = "PicMaquinaEstados";
            this.PicMaquinaEstados.Size = new System.Drawing.Size(851, 357);
            this.PicMaquinaEstados.TabIndex = 0;
            this.PicMaquinaEstados.TabStop = false;
            // 
            // ListMensajes
            // 
            this.ListMensajes.AllowColumnReorder = true;
            this.ListMensajes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Tipo,
            this.Descripcion,
            this.Hora});
            this.ListMensajes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListMensajes.FullRowSelect = true;
            this.ListMensajes.GridLines = true;
            this.ListMensajes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListMensajes.LargeImageList = this.ImageList;
            this.ListMensajes.Location = new System.Drawing.Point(0, 0);
            this.ListMensajes.MultiSelect = false;
            this.ListMensajes.Name = "ListMensajes";
            this.ListMensajes.ShowItemToolTips = true;
            this.ListMensajes.Size = new System.Drawing.Size(851, 105);
            this.ListMensajes.SmallImageList = this.ImageList;
            this.ListMensajes.TabIndex = 16;
            this.ListMensajes.UseCompatibleStateImageBehavior = false;
            this.ListMensajes.View = System.Windows.Forms.View.Details;
            // 
            // Tipo
            // 
            this.Tipo.Text = "Tipo";
            this.Tipo.Width = 150;
            // 
            // Descripcion
            // 
            this.Descripcion.Text = "Descripción";
            this.Descripcion.Width = 500;
            // 
            // Hora
            // 
            this.Hora.Text = "Hora";
            this.Hora.Width = 150;
            // 
            // ImageList
            // 
            this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList.ImageSize = new System.Drawing.Size(24, 24);
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmMonitorizacionMaquinaEstados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 529);
            this.ModoAperturaFormulario = Orbita.Controles.VA.ModoAperturaFormulario.Monitorizacion;
            this.MultiplesInstancias = true;
            this.Name = "FrmMonitorizacionMaquinaEstados";
            this.Text = "Monitorización de máquinas de estado";
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            this.PnlInferiorPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).EndInit();
            this.SplitPrincipal.Panel1.ResumeLayout(false);
            this.SplitPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitPrincipal)).EndInit();
            this.SplitPrincipal.ResumeLayout(false);
            this.CtrlStateMachineDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicMaquinaEstados)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private Orbita.Controles.Contenedores.OrbitaSplitContainer SplitPrincipal;
        private Orbita.Controles.Comunes.OrbitaListView ListMensajes;
        private System.Windows.Forms.ColumnHeader Tipo;
        private System.Windows.Forms.ColumnHeader Descripcion;
        private System.Windows.Forms.ColumnHeader Hora;
        private Orbita.Controles.VA.OrbitaVisorMaquinaEstados CtrlStateMachineDisplay;
        private Orbita.Controles.Comunes.OrbitaPictureBox PicMaquinaEstados;
        private System.Windows.Forms.ImageList ImageList;


    }
}