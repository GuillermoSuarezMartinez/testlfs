namespace Orbita.Framework
{
    /// <summary>
    /// Lista de plugins disponibles en el entorno.
    /// </summary>
    partial class PluginsDisponibles
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
            this.lstPluginsDisponibles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstPluginsDisponibles
            // 
            this.lstPluginsDisponibles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPluginsDisponibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPluginsDisponibles.FormattingEnabled = true;
            this.lstPluginsDisponibles.Location = new System.Drawing.Point(0, 0);
            this.lstPluginsDisponibles.Name = "lstPluginsDisponibles";
            this.lstPluginsDisponibles.Size = new System.Drawing.Size(391, 395);
            this.lstPluginsDisponibles.TabIndex = 0;
            // 
            // PluginsDisponibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 395);
            this.Controls.Add(this.lstPluginsDisponibles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginsDisponibles";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = Properties.Resources.Plugins;
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.ListBox lstPluginsDisponibles;
    }
}