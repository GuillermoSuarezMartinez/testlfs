//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 11/07/2013
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
using Orbita.VA.MaquinasEstados;

namespace Orbita.Controles.VA
{
    /// <summary>
    /// Control de monitorización de máquinas de estado
    /// </summary>
    public partial class CtrlMonitorizacionMaquinaEstadosTactil : OrbitaCtrlTactilBase
    {
        #region Constante(s)
        /// <summary>
        /// Número máximo de elementos en la lista
        /// </summary>
        private const int MaxItems = 25;
        /// <summary>
        /// Número de elementos en la lista al realizar un borrado
        /// </summary>
        private const int MinItems = 10;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Código de la máquina de estados
        /// </summary>
        private string CodMaquinaEstados;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public CtrlMonitorizacionMaquinaEstadosTactil(string codigo, string codMaquinaEstados, string descMaquinaEstados, Control contenedor = null) :
            base(ModoAperturaFormulario.Monitorizacion, codigo, "Monitorización de máquinas de estado [" + descMaquinaEstados + "]", contenedor)
        {
            InitializeComponent();
            this.CodMaquinaEstados = codMaquinaEstados;

            // Se rellena el imagelist
            this.ImageList.Images.Add("ImgNuevoEstado24", global::Orbita.Controles.VA.Properties.Resources.ImgNuevoEstado24);
            this.ImageList.Images.Add("ImgNuevaTransicion24", global::Orbita.Controles.VA.Properties.Resources.ImgNuevaTransicion24);
            this.ImageList.Images.Add("ImgInfo24", global::Orbita.Controles.VA.Properties.Resources.ImgInfo24);
            this.ImageList.Images.Add("ImgWarning24", global::Orbita.Controles.VA.Properties.Resources.ImgWarning24);
            this.ImageList.Images.Add("ImgStop24", global::Orbita.Controles.VA.Properties.Resources.ImgStop24);
        }
	    #endregion    

        #region Método(s) virtual(es)
        /// <summary>
        /// Carga y muestra datos del formulario comunes para los tres modos de funcionamiento
        /// </summary>
        protected override void CargarDatosComunes()
        {
            base.CargarDatosComunes();

            this.CtrlStateMachineDisplay.Inicializar(this.Codigo, this._ModoAperturaFormulario, true);
        }
        /// <summary>
        ///  Funciones a realizar al salir del formulario
        /// </summary>
        protected override void AccionesSalir()
        {
            this.CtrlStateMachineDisplay.Finalizar();
        }
        #endregion Métodos virtuales

        #region Eventos
        /// <summary>
        /// Evento que indica de la llegada de un mensaje de la máquina de estados para visualizarse en la monitorización
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctrlStateMachineDisplay_OnMensajeMaquinaEstadosRecibido(object sender, EventMessageRaised e)
        {
            try
            {
                // Se borra la lista
                if (this.ListMensajes.Items.Count >= MaxItems)
                {
                    while (this.ListMensajes.Items.Count >= MinItems)
                    {
                        this.ListMensajes.Items.RemoveAt(this.ListMensajes.Items.Count - 1);
                    }
                }

                string tipo = e.Tipo.ToString();
                string informacion = e.Informacion;
                string hora = e.Momento.ToString("dd/MM/yyyy HH:mm:ss.FFF");

                ListViewItem item = new ListViewItem();

                item.Name = tipo + hora;
                item.Text = tipo;
                item.ToolTipText = informacion;
                item.Tag = null;
                switch (e.Tipo)
                {
                    case TipoMensajeMaquinaEstados.CambioEstado:
                        item.ImageKey = "ImgNuevoEstado24";
                        break;
                    case TipoMensajeMaquinaEstados.CondicionesTransicion:
                        item.ImageKey = "ImgNuevaTransicion24";
                        break;
                    case TipoMensajeMaquinaEstados.Informacion:
                        item.ImageKey = "ImgInfo24";
                        break;
                    case TipoMensajeMaquinaEstados.Warning:
                        item.ImageKey = "ImgWarning24";
                        break;
                    case TipoMensajeMaquinaEstados.Parada:
                        item.ImageKey = "ImgStop24";
                        break;
                }

                ListViewItem.ListViewSubItem subItemInformacion = new ListViewItem.ListViewSubItem();
                subItemInformacion.Name = "Informacion";
                subItemInformacion.Text = informacion;
                item.SubItems.Add(subItemInformacion);

                ListViewItem.ListViewSubItem subItemHora = new ListViewItem.ListViewSubItem();
                subItemHora.Name = "Hora";
                subItemHora.Text = hora;
                item.SubItems.Add(subItemHora);

                // Insertamos el mensaje en la lista en la primera posición
                this.ListMensajes.Items.Insert(0, item);

                // Borramos los mensajes antiguos de la lista
                while (this.ListMensajes.Items.Count > 30)
                {
                    this.ListMensajes.Items.RemoveAt(this.ListMensajes.Items.Count - 1);
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }
        #endregion
    }
}
