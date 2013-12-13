namespace Orbita.Controles.Comunicaciones
{
    /// <summary>
    /// Control para visor de trazas diferidas
    /// </summary>
    partial class OrbitaVisorDiferido
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
            this.splitContenedorLogs = new Orbita.Controles.Contenedores.OrbitaSplitContainer();
            this.gridLog = new Orbita.Controles.Grid.OrbitaUltraGridToolBar();
            this.gridLogError = new Orbita.Controles.Grid.OrbitaUltraGridToolBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContenedorLogs)).BeginInit();
            this.splitContenedorLogs.Panel1.SuspendLayout();
            this.splitContenedorLogs.Panel2.SuspendLayout();
            this.splitContenedorLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContenedorLogs
            // 
            this.splitContenedorLogs.BackColor = System.Drawing.Color.Transparent;
            this.splitContenedorLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContenedorLogs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContenedorLogs.Location = new System.Drawing.Point(0, 0);
            this.splitContenedorLogs.Name = "splitContenedorLogs";
            this.splitContenedorLogs.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContenedorLogs.Panel1
            // 
            this.splitContenedorLogs.Panel1.Controls.Add(this.gridLog);
            this.splitContenedorLogs.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // splitContenedorLogs.Panel2
            // 
            this.splitContenedorLogs.Panel2.Controls.Add(this.gridLogError);
            this.splitContenedorLogs.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.splitContenedorLogs.Size = new System.Drawing.Size(844, 508);
            this.splitContenedorLogs.SplitterDistance = 331;
            this.splitContenedorLogs.TabIndex = 3;
            // 
            // gridLog
            // 
            this.gridLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLog.Location = new System.Drawing.Point(2, 2);
            this.gridLog.Name = "gridLog";
            this.gridLog.OI.CampoPosicionable = null;
            this.gridLog.Size = new System.Drawing.Size(840, 327);
            this.gridLog.TabIndex = 2;
            this.gridLog.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolClick);
            this.gridLog.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.DoubleClickRow);
            this.gridLog.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.InitializeLayoutWithHeader);
            this.gridLog.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.InitializeRow);
            // 
            // gridLogError
            // 
            this.gridLogError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLogError.Location = new System.Drawing.Point(2, 2);
            this.gridLogError.Name = "gridLogError";
            this.gridLogError.OI.CampoPosicionable = null;
            this.gridLogError.Size = new System.Drawing.Size(840, 169);
            this.gridLogError.TabIndex = 2;
            this.gridLogError.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolClick);
            this.gridLogError.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.DoubleClickRow);
            this.gridLogError.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.InitializeLayoutWithoutHeader);
            this.gridLogError.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.InitializeRow);
            // 
            // oVisorDiferido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContenedorLogs);
            this.Name = "oVisorDiferido";
            this.Size = new System.Drawing.Size(844, 508);
            this.splitContenedorLogs.Panel1.ResumeLayout(false);
            this.splitContenedorLogs.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContenedorLogs)).EndInit();
            this.splitContenedorLogs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Orbita.Controles.Contenedores.OrbitaSplitContainer splitContenedorLogs;
        private Orbita.Controles.Grid.OrbitaUltraGridToolBar gridLog;
        private Orbita.Controles.Grid.OrbitaUltraGridToolBar gridLogError;
    }
}
