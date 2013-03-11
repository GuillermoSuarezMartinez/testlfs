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
using System.Collections;
using System.Data;
using System.Windows.Forms;
using Orbita.Utiles;
using Orbita.VA.Comun;
using Orbita.Controles.Grid;

namespace Orbita.Controles.VA
{
    public partial class FrmGestionVariables : FrmBase
    {
        #region Constructor(es)
        /// <summary>
        /// Constructor de la calse
        /// </summary>
        /// <param name="modoAperturaFormulario">Modo de apertura del formulario</param>
        public FrmGestionVariables() :
            base()
        {
            InitializeComponent();
        } 
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Carga y muestra datos del formulario comunes para los tres modos de funcionamiento
        /// </summary>
        protected override void CargarDatosComunes()
        {
            base.CargarDatosComunes();

            CargarVariables();
        }
        /// <summary>
        ///  Método para que sea sobreescrito en el hijo y realizar funciones si el usuario no desea guardar los cambios 
        /// </summary>
        protected override void AccionesNoGuardar()
        {
        }
        #endregion Métodos virtuales

        #region Eventos
        /// <summary>
        /// Evento que refresca el grid de varibles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridVariables_OrbBotonRefrescarClick(object sender, EventArgs e)
        {
            try
            {
                CargarVariables();
            }
            catch (Exception exception)
            {
                //OVALogsManager.Error(OModulosSistema.Comun, "DirectoryCopy", exception);
                //MensajeError.MostrarExcepcion(ex);
            }
        }
        /// <summary>
        ///  Evento que elimina una variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridVariables_OrbBotonEliminarFilaClick(object sender, EventArgs e)
        {
            try
            {
                if (OMensajes.MostrarPreguntaSiNo("¿Desea eliminar la variable " + gridVariables.Grid.ActiveRow.Cells["CodVariable"].Value.ToString() + "?") == DialogResult.Yes)
                {
                    //Indice en la tabla
                    int indice = this.gridVariables.Grid.ActiveRow.VisibleIndex;

                    //LLamada a la funcion que llama al procedimiento SQL
                    global::Orbita.VA.Comun.AppBD.EliminaVariable((int)gridVariables.Grid.ActiveRow.Cells["IdVariable"].Value);

                    //Refrescamos la lista
                    this.CargarVariables();

                    //Dejar seleccionada la fila con la entidad
                    this.gridVariables.OI.Filas.Activar(indice);
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Fatal(ModulosSistema.GestionVariables, "Eliminación", exception);
            }
        }
        /// <summary>
        /// Evento que muestra el formulario para añadir variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridVariables_OrbBotonAñadirClick(object sender, EventArgs e)
        {
            // Creamos el formulario de nueva variable
            FrmGestionVariablesEdicion frmGestionVariablesEdicion = new FrmGestionVariablesEdicion();

            if (frmGestionVariablesEdicion.ShowDialog() == DialogResult.OK)
            {
                CargarVariables();
            }
        }
        /// <summary>
        /// Evento que muestra el formulario para modificar la variable seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridVariables_OrbBotonModificarClick(object sender, EventArgs e)
        {
            // Creamos el formaulario de edicion de la variable
            FrmGestionVariablesEdicion frmGestionVariablesEdicion = new FrmGestionVariablesEdicion(
                (int)gridVariables.Grid.ActiveRow.Cells["IdVariable"].Value,
                gridVariables.Grid.ActiveRow.Cells["CodVariable"].Value.ToString(),
                gridVariables.Grid.ActiveRow.Cells["NombreVariable"].Value.ToString(),
                gridVariables.Grid.ActiveRow.Cells["DescVariable"].Value.ToString(),
                (bool)gridVariables.Grid.ActiveRow.Cells["HabilitadoVariable"].Value,
                gridVariables.Grid.ActiveRow.Cells["Grupo"].Value.ToString(),
                (bool)gridVariables.Grid.ActiveRow.Cells["GuardarTrazabilidad"].Value,
                (int)gridVariables.Grid.ActiveRow.Cells["IdTipoVariable"].Value);

            if (frmGestionVariablesEdicion.ShowDialog() == DialogResult.OK)
            {
                //Indice en la tabla
                int indice = this.gridVariables.Grid.ActiveRow.VisibleIndex;

                // Cargamos las variables
                CargarVariables();

                //Dejar seleccionada la fila con la entidad
                this.gridVariables.OI.Filas.Activar(indice);
            }
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        ///  Metodo para cargar las variables
        /// </summary>
        private void CargarVariables()
        {
            DataTable dt = global::Orbita.VA.Comun.AppBD.GetListaVariables();
            if (dt != null)
            {
                //Formateamos y cargamos el grid
                ArrayList cols = new ArrayList();
                cols.Add(new OEstiloColumna("CodVariable", "Código",150));
                cols.Add(new OEstiloColumna("NombreVariable", "Nombre", 190));
                cols.Add(new OEstiloColumna("DescVariable", "Descripción", 270));
                cols.Add(new OEstiloColumna("HabilitadoVariable", "Habilitado", EstiloColumna.Check, Alineacion.Centrado, 80));
                cols.Add(new OEstiloColumna("Grupo", "Grupo", 114));
                cols.Add(new OEstiloColumna("GuardarTrazabilidad", "Trazabilidad", EstiloColumna.Check, Alineacion.Centrado, 80));
                cols.Add(new OEstiloColumna("NombreTipoVariable", "Tipo", 80));

                gridVariables.OI.Formatear(dt, cols);
            }
        }
        #endregion

    }
}
