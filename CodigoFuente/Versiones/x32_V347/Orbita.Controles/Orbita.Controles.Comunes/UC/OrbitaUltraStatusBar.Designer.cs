﻿namespace Orbita.Controles.Comunes
{
    partial class OrbitaUltraStatusBar : Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    {
        /// <summary> 
        /// Proporciona funcionalidad para contenedores. Los contenedores son objetos que contienen cero o más componentes de forma lógica.
        /// </summary>
        System.ComponentModel.IContainer components = null;

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
        /// Método necesario para admitir el Diseñador. No se puede modificar el contenido del método con el editor de código.
        /// </summary>
        void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion
    }
}
