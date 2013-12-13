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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.SplitPrincipal = new Orbita.Controles.Contenedores.OrbitaSplitContainer();
            this.CtrlStateMachineDisplay = new Orbita.Controles.VA.OrbitaVisorMaquinaEstados();
            this.PicMaquinaEstados = new Orbita.Controles.Comunes.OrbitaPictureBox();
            this.GrpMensajes = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
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
            ((System.ComponentModel.ISupportInitialize)(this.GrpMensajes)).BeginInit();
            this.GrpMensajes.SuspendLayout();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlSuperiorPadre
            // 
            this.PnlSuperiorPadre.Size = new System.Drawing.Size(825, 43);
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.SplitPrincipal);
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(825, 462);
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
            this.SplitPrincipal.Panel2.Controls.Add(this.GrpMensajes);
            this.SplitPrincipal.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SplitPrincipal.Panel2MinSize = 50;
            this.SplitPrincipal.Size = new System.Drawing.Size(825, 462);
            this.SplitPrincipal.SplitterDistance = 279;
            this.SplitPrincipal.TabIndex = 14;
            // 
            // CtrlStateMachineDisplay
            // 
            this.CtrlStateMachineDisplay.Controls.Add(this.PicMaquinaEstados);
            this.CtrlStateMachineDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlStateMachineDisplay.Location = new System.Drawing.Point(0, 0);
            this.CtrlStateMachineDisplay.Name = "CtrlStateMachineDisplay";
            this.CtrlStateMachineDisplay.Size = new System.Drawing.Size(825, 279);
            this.CtrlStateMachineDisplay.TabIndex = 15;
            this.CtrlStateMachineDisplay.OnMensajeMaquinaEstados += new Orbita.VA.MaquinasEstados.MensajeMaquinaEstadosLanzado(this.ctrlStateMachineDisplay_OnMensajeMaquinaEstadosRecibido);
            // 
            // PicMaquinaEstados
            // 
            this.PicMaquinaEstados.BackColor = System.Drawing.SystemColors.Window;
            this.PicMaquinaEstados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicMaquinaEstados.Location = new System.Drawing.Point(0, 0);
            this.PicMaquinaEstados.Name = "PicMaquinaEstados";
            this.PicMaquinaEstados.Size = new System.Drawing.Size(825, 279);
            this.PicMaquinaEstados.TabIndex = 0;
            this.PicMaquinaEstados.TabStop = false;
            // 
            // GrpMensajes
            // 
            this.GrpMensajes.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.GrpMensajes.ContentAreaAppearance = appearance1;
            this.GrpMensajes.ContentPadding.Bottom = 1;
            this.GrpMensajes.ContentPadding.Left = 1;
            this.GrpMensajes.ContentPadding.Right = 1;
            this.GrpMensajes.ContentPadding.Top = 1;
            this.GrpMensajes.Controls.Add(this.ultraPanel3);
            this.GrpMensajes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpMensajes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpMensajes.ForeColor = System.Drawing.Color.WhiteSmoke;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.GrpMensajes.HeaderAppearance = appearance3;
            this.GrpMensajes.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOutsideBorder;
            this.GrpMensajes.Location = new System.Drawing.Point(0, 0);
            this.GrpMensajes.Margin = new System.Windows.Forms.Padding(7);
            this.GrpMensajes.Name = "GrpMensajes";
            this.GrpMensajes.Size = new System.Drawing.Size(825, 179);
            this.GrpMensajes.TabIndex = 20;
            this.GrpMensajes.Text = "Lista de mensajes";
            // 
            // ultraPanel3
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            appearance2.BackColor2 = System.Drawing.Color.White;
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Opaque;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraPanel3.Appearance = appearance2;
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.ListMensajes);
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel3.Location = new System.Drawing.Point(3, 24);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(819, 152);
            this.ultraPanel3.TabIndex = 21;
            // 
            // ListMensajes
            // 
            this.ListMensajes.BackColor = System.Drawing.Color.WhiteSmoke;
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
            this.ListMensajes.Size = new System.Drawing.Size(819, 152);
            this.ListMensajes.SmallImageList = this.ImageList;
            this.ListMensajes.TabIndex = 17;
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
            this.Size = new System.Drawing.Size(845, 525);
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
            ((System.ComponentModel.ISupportInitialize)(this.GrpMensajes)).EndInit();
            this.GrpMensajes.ResumeLayout(false);
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList ImageList;
        private Contenedores.OrbitaSplitContainer SplitPrincipal;
        private OrbitaVisorMaquinaEstados CtrlStateMachineDisplay;
        private Comunes.OrbitaPictureBox PicMaquinaEstados;
        private Contenedores.OrbitaUltraGroupBox GrpMensajes;
        private Infragistics.Win.Misc.UltraPanel ultraPanel3;
        private Comunes.OrbitaListView ListMensajes;
        private System.Windows.Forms.ColumnHeader Tipo;
        private System.Windows.Forms.ColumnHeader Descripcion;
        private System.Windows.Forms.ColumnHeader Hora;
    }
}
