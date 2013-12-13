namespace Orbita.Controles.VA
{
    partial class OrbitaLogItemViewer
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.Pnl = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.lblMensaje = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.picImage = new Orbita.Controles.Comunes.OrbitaPictureBox();
            this.lblTime = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.orbitaUltraLabel1 = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.TableLayoutPanel = new Orbita.Controles.Contenedores.OrbitaTableLayoutPanel();
            this.Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pnl
            // 
            this.Pnl.Controls.Add(this.lblMensaje);
            this.Pnl.Controls.Add(this.picImage);
            this.Pnl.Controls.Add(this.lblTime);
            this.Pnl.Controls.Add(this.orbitaUltraLabel1);
            this.Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnl.Location = new System.Drawing.Point(0, 0);
            this.Pnl.Margin = new System.Windows.Forms.Padding(0);
            this.Pnl.Name = "Pnl";
            this.Pnl.Size = new System.Drawing.Size(883, 64);
            this.Pnl.TabIndex = 0;
            // 
            // lblMensaje
            // 
            appearance1.FontData.SizeInPoints = 10F;
            appearance1.TextVAlignAsString = "Middle";
            this.lblMensaje.Appearance = appearance1;
            this.lblMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMensaje.Location = new System.Drawing.Point(64, 0);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Padding = new System.Drawing.Size(10, 0);
            this.lblMensaje.Size = new System.Drawing.Size(578, 63);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.Text = "Descripción del evento";
            this.lblMensaje.UseMnemonic = false;
            // 
            // picImage
            // 
            this.picImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.picImage.InitialImage = null;
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(64, 63);
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            // 
            // lblTime
            // 
            appearance2.FontData.SizeInPoints = 14F;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblTime.Appearance = appearance2;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTime.Location = new System.Drawing.Point(642, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Padding = new System.Drawing.Size(10, 0);
            this.lblTime.Size = new System.Drawing.Size(241, 63);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "04/05/2013 23:48:15";
            this.lblTime.UseMnemonic = false;
            // 
            // orbitaUltraLabel1
            // 
            appearance3.FontData.SizeInPoints = 14F;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.orbitaUltraLabel1.Appearance = appearance3;
            this.orbitaUltraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.orbitaUltraLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.orbitaUltraLabel1.Location = new System.Drawing.Point(0, 63);
            this.orbitaUltraLabel1.Name = "orbitaUltraLabel1";
            this.orbitaUltraLabel1.Padding = new System.Drawing.Size(10, 0);
            this.orbitaUltraLabel1.Size = new System.Drawing.Size(883, 1);
            this.orbitaUltraLabel1.TabIndex = 5;
            this.orbitaUltraLabel1.UseMnemonic = false;
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.ColumnCount = 1;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel.Controls.Add(this.Pnl, 0, 0);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 1;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.41176F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(883, 64);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // OrbitaLogItemViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.TableLayoutPanel);
            this.Name = "OrbitaLogItemViewer";
            this.Size = new System.Drawing.Size(883, 64);
            this.Pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.TableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Orbita.Controles.Contenedores.OrbitaPanel Pnl;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblMensaje;
        private Orbita.Controles.Comunes.OrbitaPictureBox picImage;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblTime;
        private Orbita.Controles.Contenedores.OrbitaTableLayoutPanel TableLayoutPanel;
        private Orbita.Controles.Comunes.OrbitaUltraLabel orbitaUltraLabel1;


    }
}
