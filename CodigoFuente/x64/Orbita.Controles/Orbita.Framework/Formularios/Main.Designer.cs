﻿namespace Orbita.Framework
{
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
                this.Shown -= new System.EventHandler(this.OrbitaFramework_Shown);
                this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.OrbitaFramework_KeyDown);
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
            this.SuspendLayout();
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(491, 365);
            this.Name = "Main";
            this.Shown += new System.EventHandler(this.OrbitaFramework_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrbitaFramework_KeyDown);
            this.ResumeLayout(false);

        }
        #endregion
    }
}