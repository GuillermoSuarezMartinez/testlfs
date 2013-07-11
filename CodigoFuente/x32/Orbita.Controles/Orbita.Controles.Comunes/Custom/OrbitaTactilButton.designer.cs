namespace Orbita.Controles.Comunes
{
    partial class OrbitaTactilButton
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance("normal", 95622015);
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.PnlFondo = new Infragistics.Win.Misc.UltraPanel();
            this.TableLayoutFondo = new Orbita.Controles.Contenedores.OrbitaTableLayoutPanel();
            this.lblIcono = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.pnlData = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.lblDescripcion = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblTitulo = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblSeleccionado = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.PnlSeparador = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.PnlFondo.ClientArea.SuspendLayout();
            this.PnlFondo.SuspendLayout();
            this.TableLayoutFondo.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlFondo
            // 
            appearance1.AlphaLevel = ((short)(1));
            appearance1.BackColor = System.Drawing.Color.White;
            this.PnlFondo.Appearance = appearance1;
            // 
            // PnlFondo.ClientArea
            // 
            this.PnlFondo.ClientArea.Controls.Add(this.TableLayoutFondo);
            this.PnlFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlFondo.Location = new System.Drawing.Point(0, 0);
            this.PnlFondo.Margin = new System.Windows.Forms.Padding(0);
            this.PnlFondo.Name = "PnlFondo";
            this.PnlFondo.Size = new System.Drawing.Size(221, 50);
            this.PnlFondo.TabIndex = 4;
            // 
            // TableLayoutFondo
            // 
            this.TableLayoutFondo.BackColor = System.Drawing.Color.Transparent;
            this.TableLayoutFondo.BackgroundImage = Properties.Resources.ImgFondoBotonTactil;
            this.TableLayoutFondo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TableLayoutFondo.ColumnCount = 3;
            this.TableLayoutFondo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.TableLayoutFondo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.TableLayoutFondo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutFondo.Controls.Add(this.lblIcono, 1, 0);
            this.TableLayoutFondo.Controls.Add(this.pnlData, 2, 0);
            this.TableLayoutFondo.Controls.Add(this.lblSeleccionado, 0, 0);
            this.TableLayoutFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutFondo.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutFondo.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutFondo.Name = "TableLayoutFondo";
            this.TableLayoutFondo.RowCount = 1;
            this.TableLayoutFondo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutFondo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.TableLayoutFondo.Size = new System.Drawing.Size(221, 50);
            this.TableLayoutFondo.TabIndex = 3;
            // 
            // lblIcono
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.ImageBackground = Properties.Resources.ImgEjemplo24;
            appearance2.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.lblIcono.Appearance = appearance2;
            this.lblIcono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblIcono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIcono.Location = new System.Drawing.Point(9, 0);
            this.lblIcono.Margin = new System.Windows.Forms.Padding(0);
            this.lblIcono.Name = "lblIcono";
            this.lblIcono.Padding = new System.Drawing.Size(20, 20);
            this.lblIcono.Size = new System.Drawing.Size(42, 52);
            this.lblIcono.TabIndex = 0;
            this.lblIcono.UseMnemonic = false;
            this.lblIcono.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAccion_MouseDown);
            this.lblIcono.MouseEnter += new System.EventHandler(this.btnAccion_MouseEnter);
            this.lblIcono.MouseLeave += new System.EventHandler(this.btnAccion_MouseLeave);
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.Transparent;
            this.pnlData.Controls.Add(this.lblDescripcion);
            this.pnlData.Controls.Add(this.lblTitulo);
            this.pnlData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(51, 0);
            this.pnlData.Margin = new System.Windows.Forms.Padding(0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(170, 52);
            this.pnlData.TabIndex = 3;
            this.pnlData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAccion_MouseDown);
            this.pnlData.MouseEnter += new System.EventHandler(this.btnAccion_MouseEnter);
            this.pnlData.MouseLeave += new System.EventHandler(this.btnAccion_MouseLeave);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.FontData.SizeInPoints = 8F;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.ForegroundAlpha = Infragistics.Win.Alpha.Opaque;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Top";
            this.lblDescripcion.Appearance = appearance3;
            this.lblDescripcion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(0, 28);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(157, 16);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción de la acción";
            this.lblDescripcion.UseMnemonic = false;
            this.lblDescripcion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAccion_MouseDown);
            this.lblDescripcion.MouseEnter += new System.EventHandler(this.btnAccion_MouseEnter);
            this.lblDescripcion.MouseLeave += new System.EventHandler(this.btnAccion_MouseLeave);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.SizeInPoints = 13F;
            appearance4.ForeColor = System.Drawing.Color.White;
            appearance4.ForegroundAlpha = Infragistics.Win.Alpha.Opaque;
            appearance4.TextHAlignAsString = "Left";
            this.lblTitulo.Appearance = appearance4;
            this.lblTitulo.Appearances.Add(appearance5);
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 4);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(157, 24);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Título Botón";
            this.lblTitulo.UseMnemonic = false;
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAccion_MouseDown);
            this.lblTitulo.MouseEnter += new System.EventHandler(this.btnAccion_MouseEnter);
            this.lblTitulo.MouseLeave += new System.EventHandler(this.btnAccion_MouseLeave);
            // 
            // lblSeleccionado
            // 
            appearance6.AlphaLevel = ((short)(150));
            appearance6.BackColor = System.Drawing.Color.White;
            this.lblSeleccionado.Appearance = appearance6;
            this.lblSeleccionado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSeleccionado.Location = new System.Drawing.Point(0, 0);
            this.lblSeleccionado.Margin = new System.Windows.Forms.Padding(0);
            this.lblSeleccionado.Name = "lblSeleccionado";
            this.lblSeleccionado.Size = new System.Drawing.Size(9, 52);
            this.lblSeleccionado.TabIndex = 4;
            this.lblSeleccionado.UseMnemonic = false;
            this.lblSeleccionado.Visible = false;
            // 
            // PnlSeparador
            // 
            this.PnlSeparador.BackColor = System.Drawing.Color.Transparent;
            this.PnlSeparador.BackgroundImage = Properties.Resources.ImgSeparador250;
            this.PnlSeparador.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlSeparador.Location = new System.Drawing.Point(0, 50);
            this.PnlSeparador.Name = "PnlSeparador";
            this.PnlSeparador.Size = new System.Drawing.Size(221, 2);
            this.PnlSeparador.TabIndex = 3;
            // 
            // BotonTactil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.Controls.Add(this.PnlFondo);
            this.Controls.Add(this.PnlSeparador);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BotonTactil";
            this.Size = new System.Drawing.Size(221, 52);
            this.PnlFondo.ClientArea.ResumeLayout(false);
            this.PnlFondo.ResumeLayout(false);
            this.TableLayoutFondo.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Orbita.Controles.Contenedores.OrbitaPanel PnlSeparador;
        private Infragistics.Win.Misc.UltraPanel PnlFondo;
        private Orbita.Controles.Contenedores.OrbitaTableLayoutPanel TableLayoutFondo;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblIcono;
        private Orbita.Controles.Contenedores.OrbitaPanel pnlData;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblDescripcion;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblTitulo;
        private Orbita.Controles.Comunes.OrbitaUltraLabel lblSeleccionado;
    }
}
