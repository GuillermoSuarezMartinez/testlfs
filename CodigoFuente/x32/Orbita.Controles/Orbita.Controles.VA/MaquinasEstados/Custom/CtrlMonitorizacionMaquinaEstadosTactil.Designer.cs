namespace Orbita.Controles.VA
{
    partial class CtrlMonitorizacionMaquinaEstadosTactil
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
            this.components = new System.ComponentModel.Container();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.SplitPrincipal = new Orbita.Controles.Contenedores.OrbitaSplitContainer();
            this.CtrlStateMachineDisplay = new Orbita.Controles.VA.OrbitaVisorMaquinaEstados();
            this.PicMaquinaEstados = new Orbita.Controles.Comunes.OrbitaPictureBox();
            this.ListMensajes = new Orbita.Controles.Comunes.OrbitaListView();
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PnlSuperiorPadre.SuspendLayout();
            this.PnlPanelPrincipalPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitPrincipal)).BeginInit();
            this.SplitPrincipal.Panel1.SuspendLayout();
            this.SplitPrincipal.Panel2.SuspendLayout();
            this.SplitPrincipal.SuspendLayout();
            this.CtrlStateMachineDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicMaquinaEstados)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlSuperiorPadre
            // 
            this.PnlSuperiorPadre.Size = new System.Drawing.Size(825, 43);
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.SplitPrincipal);
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(825, 398);
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Location = new System.Drawing.Point(745, 0);
            // 
            // LblMensaje
            // 
            this.LblMensaje.Size = new System.Drawing.Size(705, 43);
            this.LblMensaje.Text = "Monitorización de máquinas de estado";
            // 
            // PicIcono
            // 
            this.PicIcono.BackgroundImage = global::Orbita.Controles.VA.Properties.Resources.ImgEstados24;
            // 
            // ImageList
            // 
            this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList.ImageSize = new System.Drawing.Size(24, 24);
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
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
            this.SplitPrincipal.Size = new System.Drawing.Size(825, 398);
            this.SplitPrincipal.SplitterDistance = 304;
            this.SplitPrincipal.TabIndex = 14;
            // 
            // CtrlStateMachineDisplay
            // 
            this.CtrlStateMachineDisplay.Controls.Add(this.PicMaquinaEstados);
            this.CtrlStateMachineDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlStateMachineDisplay.Location = new System.Drawing.Point(0, 0);
            this.CtrlStateMachineDisplay.Name = "CtrlStateMachineDisplay";
            this.CtrlStateMachineDisplay.Size = new System.Drawing.Size(825, 304);
            this.CtrlStateMachineDisplay.TabIndex = 15;
            this.CtrlStateMachineDisplay.OnMensajeMaquinaEstados += new Orbita.VA.MaquinasEstados.MensajeMaquinaEstadosLanzado(this.ctrlStateMachineDisplay_OnMensajeMaquinaEstadosRecibido);
            // 
            // PicMaquinaEstados
            // 
            this.PicMaquinaEstados.BackColor = System.Drawing.SystemColors.Window;
            this.PicMaquinaEstados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicMaquinaEstados.Location = new System.Drawing.Point(0, 0);
            this.PicMaquinaEstados.Name = "PicMaquinaEstados";
            this.PicMaquinaEstados.Size = new System.Drawing.Size(825, 304);
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
            this.ListMensajes.Size = new System.Drawing.Size(825, 90);
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
            // CtrlMonitorizacionMaquinaEstadosTactil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CtrlMonitorizacionMaquinaEstadosTactil";
            this.Size = new System.Drawing.Size(845, 461);
            this.Titulo = "Monitorización de máquinas de estado";
            this.PnlSuperiorPadre.ResumeLayout(false);
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicIcono)).EndInit();
            this.SplitPrincipal.Panel1.ResumeLayout(false);
            this.SplitPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitPrincipal)).EndInit();
            this.SplitPrincipal.ResumeLayout(false);
            this.CtrlStateMachineDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicMaquinaEstados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList ImageList;
        private Contenedores.OrbitaSplitContainer SplitPrincipal;
        private OrbitaVisorMaquinaEstados CtrlStateMachineDisplay;
        private Comunes.OrbitaPictureBox PicMaquinaEstados;
        private Comunes.OrbitaListView ListMensajes;
        private System.Windows.Forms.ColumnHeader Tipo;
        private System.Windows.Forms.ColumnHeader Descripcion;
        private System.Windows.Forms.ColumnHeader Hora;
    }
}
