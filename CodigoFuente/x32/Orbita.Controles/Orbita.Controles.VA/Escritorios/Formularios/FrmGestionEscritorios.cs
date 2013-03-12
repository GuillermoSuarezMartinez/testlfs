//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 16-11-2012
// Description      : Movido al proyecto Orbita.Controles.VA
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using Infragistics.Win.UltraWinGrid;
using Orbita.Controles.Grid;
using Orbita.Utiles;
using Orbita.VA.Comun;
namespace Orbita.Controles.VA
{
    /// <summary>
    /// Formulario utilizado para la gestión de escritorios
    /// </summary>
    public partial class FrmGestionEscritorios : FrmDialogoBase
    {
        #region Atributo(s)
        /// <summary>
        /// Parametros que se están editando
        /// </summary>
        internal OpcionesEscritorios OpcionesEscritorios;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public FrmGestionEscritorios()
            : base(ModoAperturaFormulario.Modificacion)
        {
            this.InitializeComponent();

            this.OpcionesEscritorios = OEscritoriosManager.OpcionesEscritorios;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Carga y muestra datos del formulario comunes para los tres modos de funcionamiento
        /// </summary>
        protected override void CargarDatosComunes()
        {
            base.CargarDatosComunes();

            this.SuspendLayout();

            // Escritorios
            this.CargarGridEscritorios();

            // General
            this.CheckHabilitado.Checked = this.OpcionesEscritorios.ManejoAvanzadoEscritorio;
            this.ChkAnclaje.Checked = this.OpcionesEscritorios.PermiteAnclajes;
            this.checkHabilitado_CheckedChanged(this.CheckHabilitado, new EventArgs());
            this.ChkAutoAbrirFoms.Checked = this.OpcionesEscritorios.AutoAbrirFoms;
            this.ChkPreferenciaMaximizado.Checked = this.OpcionesEscritorios.PreferenciaMaximizado;
            this.CargarComboEscritorios();

            this.ResumeLayout();
        }
        /// <summary>
        /// Se añade el evento de monitorización a los controles del formulario
        /// </summary>
        protected override void IniciarMonitorizarModificaciones()
        {
            base.IniciarMonitorizarModificaciones();

            //this.GridEscritorios.ToolAñadirClick += this.EventoCambioValor;
            //this.GridEscritorios.ToolEliminarClick += this.EventoCambioValor;
        }
        /// <summary>
        /// Se elimina el evento de monitorización a los controles del formulario
        /// </summary>
        protected override void FinalizarMonitorizarModificaciones()
        {
            base.FinalizarMonitorizarModificaciones();

            //this.GridEscritorios_.ToolAñadirClick -= this.EventoCambioValor;
            //this.GridEscritorios_.ToolEliminarClick -= this.EventoCambioValor;
        }
        /// <summary>
        /// Realiza las comprobaciones pertinentes antes de realizar un guardado de los datos. Se usa para el caso en que hayan restricciones en el momento de guardar los datos
        /// </summary>
        /// <returns>True si todo está correcto para ser guardado; false en caso contrario</returns>
        protected override bool ComprobacionesDeCampos()
        {
            bool resultado = base.ComprobacionesDeCampos();
            try
            {
                //foreach (UltraGridRow row in this.GridEscritorios_.Grid.Rows)
                //{
                //    if (!(row.Cells["Valor"].Value is OpcionesEscritorio))
                //    {    
                //        resultado = false;
                //        throw new Exception("La lista de escritorios no es válida");
                //    }

                //    OpcionesEscritorio opcionesEscritorio = (OpcionesEscritorio)row.Cells["Valor"].Value;
                //    if (resultado)
                //    {
                //        OTexto textoRobusto = new OTexto("Lista Escritorios", 50, false, false, string.Empty, true);
                //        textoRobusto.ValorGenerico = opcionesEscritorio.Nombre;
                //        resultado = textoRobusto.Valido;
                //    }
                //    //resultado &= OTextoRobusto.Validar(opcionesEscritorio.Nombre, "Lista Escritorios", 50, false, true);
                //}

                //if (resultado && this.CheckHabilitado.Checked)
                //{
                //    if (!OTrabajoControles.ComprobarFila(this.CboEscritorios.ActiveRow))
                //    {
                //        resultado = false;
                //        throw new Exception("El campo Escritorio Predefinido no es válido");
                //    }
                //    resultado &= OTexto.Validar(this.CboEscritorios.ActiveRow.Cells["Indice"].Value, "Escritorio Predefinido", 50, false, false, string.Empty, true) == EnumEstadoObjetoRobusto.ResultadoCorrecto;
                //    string nombreEscritorioPredefinido = (string)this.CboEscritorios.ActiveRow.Cells["Indice"].Value;

                //    // Escritorios
                //    List<OpcionesEscritorio> listaOpcionesEscritorio = this.ObtenerListaOpcionesEscritoriosDeGrid();
                //    bool existeEscritorio = listaOpcionesEscritorio.Exists(delegate(OpcionesEscritorio opcionesEscritorio) { return opcionesEscritorio.Nombre == nombreEscritorioPredefinido; });
                //    if (!existeEscritorio)
                //    {
                //        resultado = false;
                //        throw new Exception("No existe el Escritorio Predefinido seleccionado");
                //    }
                //}
            }
            catch (Exception exception)
            {
                //OVALogsManager.Error(OModulosSistema.Escritorios, "ComprobacionesDeCampos", exception);
                OMensajes.MostrarAviso(exception.Message);
                resultado = false;
            }

            return resultado;
        }
        /// <summary>
        /// Guarda los datos cuando el formulario está abierto en modo Modificación
        /// </summary>
        /// <returns>True si la operación de guardado de datos ha tenido éxito; false en caso contrario</returns>
        protected override bool GuardarDatosModoModificacion()
        {
            bool resultado = false;
            base.GuardarDatosModoModificacion();
            resultado = this.VolcarDatosOpcionesEscritorios();
            this.OpcionesEscritorios.Guardar();
            return resultado;
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Carga y aplica un formato al Combo con los datos existentes
        /// </summary>
        private void CargarComboEscritorios()
        {
            this.CboEscritorios.OI.ResetValor();

            List<OpcionesEscritorio> listaOpcionesEscritorio = this.ObtenerListaOpcionesEscritoriosDeGrid();
            if (listaOpcionesEscritorio.Count > 0)
            {
                Dictionary<object, string> valores = new Dictionary<object, string>();
                foreach (OpcionesEscritorio opcionesEscritorio in listaOpcionesEscritorio)
                {
                    valores.Add(opcionesEscritorio.Nombre, opcionesEscritorio.Nombre);
                }
                OTrabajoControles.CargarCombo(this.CboEscritorios, valores, typeof(string), this.OpcionesEscritorios.NombreEscritorioActual);
            }
        }

        /// <summary>
        /// Carga y aplica un formato al Combo con los datos existentes
        /// </summary>
        private void RefrescarComboEscritorios()
        {
            //Obtenemos información sobre el registro está actualmente seleccionado
            string nombreEscritorioSeleccionado = this.CboEscritorios.OI.Texto; // Nunca puede ser null

            // Limpiamos los valores del combo
            this.CboEscritorios.OI.ResetValor();

            List<OpcionesEscritorio> listaOpcionesEscritorio = this.ObtenerListaOpcionesEscritoriosDeGrid();
            if (listaOpcionesEscritorio.Count > 0)
            {
                Dictionary<object, string> valores = new Dictionary<object, string>();
                foreach (OpcionesEscritorio opcionesEscritorio in listaOpcionesEscritorio)
                {
                    valores.Add(opcionesEscritorio.Nombre, opcionesEscritorio.Nombre);
                }
                OTrabajoControles.CargarCombo(this.CboEscritorios, valores, typeof(string), nombreEscritorioSeleccionado);
            }
        }

        /// <summary>
        /// Carga y aplica un formato al Grid con los datos existentes
        /// </summary>
        private void CargarGridEscritorios()
        {
            List<object> valores = new List<object>();
            foreach (OpcionesEscritorio opcionesEscritorio in this.OpcionesEscritorios.ListaOpcionesEscritorio)
            {
                valores.Add(opcionesEscritorio);
            }

            OTrabajoControles.CargarGridSimple(this.GridEscritorios, valores, typeof(OpcionesEscritorio), EstiloColumna.Texto, Alineacion.Izquierda, null, 150, null);
            this.GridEscritorios.Toolbar.OI.AgregarToolButton("Establecer", "Establecer", "Establece el escritorio seleccionado", 2, global::Orbita.Controles.VA.Properties.Resources.btnEstablecerEscritorio16);
        }

        /// <summary>
        /// Método que guarda los valores de los componentes de edición del formulario a la clase XMLTarea
        /// </summary>
        private bool VolcarDatosOpcionesEscritorios()
        {
            bool resultado = true;
            try
            {
                // General
                this.OpcionesEscritorios.AutoAbrirFoms = this.ChkAutoAbrirFoms.Checked;
                this.OpcionesEscritorios.ManejoAvanzadoEscritorio = this.CheckHabilitado.Checked;
                this.OpcionesEscritorios.PermiteAnclajes = this.ChkAnclaje.Checked;
                this.OpcionesEscritorios.PreferenciaMaximizado = this.ChkPreferenciaMaximizado.Checked;
                this.OpcionesEscritorios.NombreEscritorioActual = string.Empty;
                if (this.CboEscritorios.ActiveRow != null)
                {
                    this.OpcionesEscritorios.NombreEscritorioActual = (string)this.CboEscritorios.ActiveRow.Cells["Indice"].Value;
                }

                // Escritorios
                this.OpcionesEscritorios.ListaOpcionesEscritorio = this.ObtenerListaOpcionesEscritoriosDeGrid();
            }
            catch (System.Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.Escritorios, "Guardar datos", exception);
                resultado = false;
            }
            return resultado;
        }

        /// <summary>
        /// añade una nueva fila a un grid simple (Una sóla columna)
        /// </summary>
        private void NuevaFila(OrbitaUltraGridToolBar grid, object valor)
        {
            grid.Grid.ActiveRow = grid.Grid.DisplayLayout.Bands[0].AddNew();
            grid.Grid.ActiveRow.Cells[0].Value = valor;

            //grid.Grid.ActiveRow = grid.OrbGrid.DisplayLayout.Bands[0].AddNew();
            //grid.Grid.ActiveRow.Cells[0].Value = valor;
        }

        /// <summary>
        /// Extrae la lista de escritorios del grid
        /// </summary>
        private List<OpcionesEscritorio> ObtenerListaOpcionesEscritoriosDeGrid()
        {
            List<OpcionesEscritorio> listaOpcionesEscritorio = new List<OpcionesEscritorio>();
            //foreach (UltraGridRow row in this.GridEscritorios_.Grid.Rows)
            //{
            //    if (row.Cells["Valor"].Value is OpcionesEscritorio)
            //    {
            //        listaOpcionesEscritorio.Add((OpcionesEscritorio)row.Cells["Valor"].Value);
            //    }
            //}

            return listaOpcionesEscritorio;
        }

        /// <summary>
        /// Valida que el nuevo nombre no exista previamente entre los nombres dados de alta en el grid
        /// </summary>
        /// <param name="anteriorNombre">Nombre anterior</param>
        /// <param name="nuevoNombre">Nuevo nombre</param>
        /// <returns></returns>
        private bool ValidarNuevoNombreEscritorioEnGrid(string anteriorNombre, string nuevoNombre)
        {
            bool resultado = true;

            if (anteriorNombre != nuevoNombre)
            {
                List<OpcionesEscritorio> listaOpcionesEscritorio = this.ObtenerListaOpcionesEscritoriosDeGrid();
                foreach (OpcionesEscritorio opcionesEscriorio in listaOpcionesEscritorio)
                {
                    if (nuevoNombre == opcionesEscriorio.Nombre)
                    {
                        resultado = false;
                        break;
                    }
                }
            }

            return resultado;
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Cambio de habilitar/deshabilitar manejo de escritorios
        /// </summary>
        /// <param name="sender">Objeto que envía el evento</param>
        /// <param name="celda">Argumentos del evento</param>
        private void checkHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            this.PnlOpcionesEscritorios.Visible = this.CheckHabilitado.Checked;
        }

        private void GridEscritorios_ToolAñadirClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                string nombreNuevoEscritorio = "Nuevo";
                string nombreDefinitivoNuevoEscritorio = nombreNuevoEscritorio;
                int i = 1;
                while (!this.ValidarNuevoNombreEscritorioEnGrid(string.Empty, nombreDefinitivoNuevoEscritorio))
                {
                    nombreDefinitivoNuevoEscritorio = nombreNuevoEscritorio + i.ToString();
                    i++;
                }

                OEscritorio escritorio = new OEscritorio(nombreDefinitivoNuevoEscritorio);
                escritorio.ObtenerEscritorioAplicacion();

                OpcionesEscritorio opcionesEscritorio = new OpcionesEscritorio();
                opcionesEscritorio.Nombre = escritorio.Nombre;
                opcionesEscritorio.ListaInfoPosForms = escritorio.ListaInfoPosForms;

                //this.NuevaFila(this.GridEscritorios_, opcionesEscritorio);

                this.RefrescarComboEscritorios();
            }
            catch (System.Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.Escritorios, "Nuevo escritorio", exception);
            }
        }

        private void GridEscritorios_ToolEliminarClick(object sender, Orbita.Controles.Grid.OToolClickCollectionEventArgs e)
        {
            try
            {
                //if (OTrabajoControles.ComprobarGrid(this.GridEscritorios_)) // Si hay alguna selección en el grid
                //{
                //    if (OMensajes.MostrarPreguntaSiNo("¿Desea eliminar el escritorio " + this.GridEscritorios_.Grid.ActiveRow.Cells["Valor"].Text + "?") == DialogResult.Yes)
                //    {
                //        this.GridEscritorios_.OI.Filas.Activas.Eliminar();
                //        this.RefrescarComboEscritorios();
                //    }
                //}
            }
            catch (System.Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.Escritorios, "Eliminar escritorio", exception);
            }
        }

        private void GridEscritorios_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                if (e.Tool.Key == "Establecer")
                {
                    //if (OTrabajoControles.ComprobarGrid(this.GridEscritorios_)) // Si hay alguna selección en el grid
                    //{
                    //    //Obtenemos información sobre el registro está actualmente seleccionado
                    //    object valorCeldaActiva = this.GridEscritorios_.Grid.ActiveRow.Cells["Valor"].Value;
                    //    if (valorCeldaActiva is OpcionesEscritorio)
                    //    {
                    //        OpcionesEscritorio opcionesEscritorio = (OpcionesEscritorio)valorCeldaActiva;
                    //        OEscritorio escritorio = new OEscritorio(opcionesEscritorio.Nombre, opcionesEscritorio.ListaInfoPosForms);
                    //        escritorio.EstablecerEscritorioAplicacion();
                    //    }
                    //}
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.Escritorios, "ClickEnBarraGridEscritorios", exception);
            }
        }

        private void GridEscritorios_AfterCellUpdate(object sender, CellEventArgs e)
        {
            try
            {
                if ((e.Cell.Value is string) && (e.Cell.OriginalValue is OpcionesEscritorio))
                {
                    string anteriorNombre = ((OpcionesEscritorio)e.Cell.OriginalValue).Nombre;
                    string nuevoNombre = (string)e.Cell.Value;
                    if (!this.ValidarNuevoNombreEscritorioEnGrid(anteriorNombre, nuevoNombre))
                    {
                        OMensajes.MostrarAviso("Ya existe un escritorio con el nombre " + nuevoNombre);
                        nuevoNombre = anteriorNombre;
                    }

                    OpcionesEscritorio opcionesEscritorio = (OpcionesEscritorio)e.Cell.OriginalValue;
                    opcionesEscritorio.Nombre = nuevoNombre;
                    e.Cell.Value = opcionesEscritorio;

                    this.RefrescarComboEscritorios();
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.Escritorios, "FinEdicionGridEscritorios", exception);
            }
        }
        #endregion
    }
}