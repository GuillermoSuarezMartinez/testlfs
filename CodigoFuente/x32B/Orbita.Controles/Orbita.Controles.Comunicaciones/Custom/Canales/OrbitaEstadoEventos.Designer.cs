namespace Orbita.Controles.Comunicaciones
{
    partial class OrbitaEstadoEventos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaEstadoEventos));
            this.listViewEventos = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listViewEventos
            // 
            this.listViewEventos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEventos.Location = new System.Drawing.Point(0, 0);
            this.listViewEventos.Name = "listViewEventos";
            this.listViewEventos.Size = new System.Drawing.Size(584, 214);
            this.listViewEventos.TabIndex = 0;
            this.listViewEventos.UseCompatibleStateImageBehavior = false;
            this.listViewEventos.View = System.Windows.Forms.View.List;
            // 
            // OrbitaEstadoEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewEventos);
            this.Name = "OrbitaEstadoEventos";
            this.OI.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas")));
            this.OI.Alarmas.AlarmasArray = new string[0];
            this.OI.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios")));
            this.OI.CambioDato.CambiosArray = new string[0];
            this.OI.CambioDato.Variable = null;
            this.OI.Comunicacion.IdDispositivo = 0;
            this.OI.Comunicacion.NombreCanal = "";
            this.Size = new System.Drawing.Size(584, 214);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewEventos;
    }
}
