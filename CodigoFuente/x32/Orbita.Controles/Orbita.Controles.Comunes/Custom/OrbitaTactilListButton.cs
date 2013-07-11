//***********************************************************************
// Assembly         : Orbita.Controles.Comunes
// Author           : aibañez
// Created          : 02-07-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Orbita.Controles.Comunes
{
    /// <summary>
    /// Conjunto de botones táctiles
    /// </summary>
    public partial class OrbitaTactilListButton : UserControl
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de botones añadidos
        /// </summary>
        Dictionary<string, OrbitaTactilButton> ListaBotones;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OrbitaTactilListButton()
        {
            InitializeComponent();

            this.ListaBotones = new Dictionary<string, OrbitaTactilButton>();
            this.Controls.Clear();
        } 
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Agregar nuevo botón
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="desc"></param>
        /// <param name="img"></param>
        /// <param name="eventoClick"></param>
		public void AgregarBoton(string codigo, string texto, string desc, Bitmap img, OrbitaTactilButton.DelegadoEventoClickBotonTactil eventoClick)
        {
            OrbitaTactilButton newBtn = new OrbitaTactilButton(this, texto, desc, img, eventoClick);
            newBtn.Dock = System.Windows.Forms.DockStyle.Top;
            newBtn.Name = codigo;
            this.Controls.Add(newBtn);
            this.ListaBotones[codigo] = newBtn;
        }
        /// <summary>
        /// Selecciona un item del menú
        /// </summary>
        /// <param name="codigo"></param>
        public void Seleccionar(string codigo)
        {
            // Si el botón a seleccionar no está ya seleccionado
            if (this.ListaBotones.ContainsKey(codigo))
            {
                if (!this.ListaBotones[codigo].Seleccionado)
                {
                    this.DesSeleccionarTodos();
                    this.ListaBotones[codigo].Seleccionado = true;
                }
            }
            else
            {
                this.DesSeleccionarTodos();
            }
        }
        /// <summary>
        /// Limpiar todos los botones seleccionados
        /// </summary>
        public void DesSeleccionarTodos()
        {
            foreach (OrbitaTactilButton btn in this.ListaBotones.Values)
            {
                if (btn.Seleccionado)
                {
                    btn.Seleccionado = false;
                }
            }
        }
	    #endregion    
    }
}
