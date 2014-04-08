namespace Orbita.Framework
{
    /// <summary>
    /// Contenedor principal de plugins.
    /// </summary>
    partial class Main
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
                this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.OrbitaFramework_KeyDown);
                this.Shown -= new System.EventHandler(OrbitaFramework_Shown);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.SuspendLayout();
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(485, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "<Título>";
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrbitaFramework_KeyDown);
            this.ResumeLayout(false);

        }
        private void InitializeComponentMenuStrip()
        {
            this.SuspendLayout();
            //
            // MenuStrip
            //
            this.pluginMenuStrip.AllowMerge = true;
            this.Controls.Add(this.pluginMenuStrip);
            this.MainMenuStrip = this.pluginMenuStrip;
            this.Controls.SetChildIndex(this.pluginMenuStrip, 0);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private PluginManager.PluginOMenuStrip pluginMenuStrip;
    }
}