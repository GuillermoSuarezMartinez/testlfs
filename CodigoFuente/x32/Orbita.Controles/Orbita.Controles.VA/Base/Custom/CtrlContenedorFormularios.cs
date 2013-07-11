//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 04-07-2013
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
using Infragistics.Win.UltraWinTabControl;
using Orbita.Controles.VA;
using Orbita.Utiles;

namespace Orbita.Controles.VA
{
    /// <summary>
    /// Control contenedor principal
    /// </summary>
    public partial class CtrlContenedorFormularios : UserControl, IDisposable
    {
        #region Propiedad(es)
        /// <summary>
        /// Lista de formularios abiertos
        /// </summary>
        public Dictionary<string, OPair<UltraTab, OrbitaCtrlTactilBase>> ListaFormularios;
        #endregion

        #region Declaración de Delegado(s)
        /// <summary>
        /// Delegado de activación de formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoFormularioActivo(object sender, EventArgsFormularioActivo e);

        /// <summary>
        /// Delegado de acticación
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Evento de activación de un formulario")]
        public event DelegadoFormularioActivo OnFormularioActivo;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructores
        /// </summary>
        public CtrlContenedorFormularios()
        {
            InitializeComponent();

            this.ListaFormularios = new Dictionary<string, OPair<UltraTab, OrbitaCtrlTactilBase>>();
        } 
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Evento de libración
        /// </summary>
        private void Dispose()
        {
            
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Visualización de un formulario
        /// </summary>
        /// <param name="formulario"></param>
        public void NuevoFormulario(OrbitaCtrlTactilBase formulario)
        {
            string codFormulario = formulario.Codigo;

            // Si el formulario no está abierto lo incrustamos en un nuevo tab
            if (!this.ListaFormularios.ContainsKey(codFormulario))
            {
                // Creación del tab que lo contendrá
                UltraTab ultraTab = new UltraTab();
                ultraTab.Text = codFormulario;
                ultraTab.Key = codFormulario;
                this.TabContenedor.Tabs.AddRange(new UltraTab[] { ultraTab });
                ultraTab.TabPage.Controls.Add(formulario);

                // Añadimos 
                this.ListaFormularios[codFormulario] = new OPair<UltraTab, OrbitaCtrlTactilBase>(ultraTab, formulario);
                formulario.Parent = ultraTab.TabPage;
                ultraTab.TabPage.Visible = true;
            }

            // Activación del tab actual
            this.TabContenedor.SelectedTab = this.TabContenedor.Tabs[codFormulario];

            // Evento de activación del formulario
            if (this.OnFormularioActivo != null)
            {
                this.OnFormularioActivo(formulario, new EventArgsFormularioActivo(codFormulario));
            }
        }

        /// <summary>
        /// Visualización de un formulario
        /// </summary>
        /// <param name="formulario"></param>
        public void AbrirFormulario(string codFormulario)
        {
            if (this.ListaFormularios.ContainsKey(codFormulario))
            {
                // Activación del tab actual
                this.TabContenedor.SelectedTab = this.TabContenedor.Tabs[codFormulario];

                // Evento de activación del formulario
                if (this.OnFormularioActivo != null)
                {
                    OrbitaCtrlTactilBase formulario = this.ListaFormularios[codFormulario].Second;
                    this.OnFormularioActivo(formulario, new EventArgsFormularioActivo(codFormulario));
                }
            }
        }

        /// <summary>
        /// Cierre de un determinado formulario
        /// </summary>
        /// <param name="formulario"></param>
        public void CerrarFormuario(OrbitaCtrlTactilBase formulario)
        {
            string codFormulario = formulario.Codigo;
            this.CerrarFormuario(codFormulario);
        }

        /// <summary>
        /// Cierre de un determinado formulario
        /// </summary>
        /// <param name="formulario"></param>
        public void CerrarFormuario(string codFormulario)
        {
            if (this.ListaFormularios.ContainsKey(codFormulario))
            {
                // Cierre del formulario
                //OrbitaCtrlTactilBase formulario = this.ListaFormularios[codFormulario].Second;
                //formulario.Close();

                // Cierre del tab
                UltraTab tab = this.ListaFormularios[codFormulario].First;
                this.TabContenedor.Tabs.Remove(tab);

                // Eliminación de la lista
                this.ListaFormularios[codFormulario].First = null;
                this.ListaFormularios[codFormulario].Second = null;
                this.ListaFormularios.Remove(codFormulario);

                // Evento de activación del formulario
                OrbitaCtrlTactilBase nuevoFormulario = null;
                string codigoNuevoFormulario = string.Empty;
                if (this.TabContenedor.SelectedTab is UltraTab)
                {
                    codigoNuevoFormulario = this.TabContenedor.SelectedTab.Key;
                    if (this.OnFormularioActivo != null)
                    {
                        nuevoFormulario = this.ListaFormularios[codigoNuevoFormulario].Second;
                    }
                }
                this.OnFormularioActivo(nuevoFormulario, new EventArgsFormularioActivo(codigoNuevoFormulario));
            }
        }

        /// <summary>
        /// Cierre de todas las ventanas abiertas
        /// </summary>
        public void CerrarTodosFormularios()
        {
            var frms = this.ListaFormularios.Values.Select(pair => pair.Second);
            foreach (OrbitaCtrlTactilBase frmBase in frms)
            {
                if (frmBase.ModoAperturaFormulario != ModoAperturaFormulario.Sistema)
                {
                    frmBase.Close();
                }
            }
        }

        /// <summary>
        /// Obtiene un determinado formulario
        /// </summary>
        /// <param name="codFormulario">Código identificativo del formulario</param>
        /// <param name="formulario">Formularoi</param>
        /// <returns>Verdadero si el formulario existe</returns>
        public bool GetFormulario(string codFormulario, out OrbitaCtrlTactilBase formulario)
        {
            bool resultado = false;
            formulario = null;

            if (this.ListaFormularios.ContainsKey(codFormulario))
            {
                formulario = this.ListaFormularios[codFormulario].Second;
                resultado = true;
            }

            return resultado;
        }

        /// <summary>
        /// Indica si el formulario esta en la lista de formularios visualizados
        /// </summary>
        /// <returns></returns>
        public bool ExisteFormulario(string codFormulario)
        {
            return this.ListaFormularios.ContainsKey(codFormulario);
        }

        /// <summary>
        /// Indica si el formulario esta en la lista de formularios visualizados
        /// </summary>
        /// <returns></returns>
        public bool ExisteFormulario(OrbitaCtrlTactilBase formulario)
        {
            return this.ListaFormularios.ContainsKey(formulario.Codigo);
        }
        #endregion
    }

    /// <summary>
    /// Evento del delegado de activación de un formulario
    /// </summary>
    public class EventArgsFormularioActivo : EventArgs
    {
        #region Propiedad(es)
		/// <summary>
        /// Código del formulario activo
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código del formulario activo
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
	    #endregion    

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codigo"></param>
        public EventArgsFormularioActivo(string codigo)
        {
            this.Codigo = codigo;
        }
        #endregion
    }

}
