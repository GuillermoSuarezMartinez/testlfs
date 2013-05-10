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
using System.Windows.Forms;
using Orbita.Utiles;
using Orbita.Controles.Estilos;
using Orbita.VA.Comun;
using Orbita.Controles.Grid;

namespace Orbita.Controles.VA
{
    public partial class FrmGestionVariablesEdicion : FrmDialogoBase
    {
        #region Atributo(s)
        /// <summary>
        /// Almacena el modo en el que se ha abierto el formulario: Nuevo o Modificar
        /// </summary>
        private bool Nuevo;

        /// <summary>
        /// Indica si se está en la fase de inicializacion de los controles y la información del formulario
        /// </summary>
        private bool Inicio;

        /// <summary>
        /// Indica si se ha guardado
        /// </summary>
        private bool Guardado;

        /// <summary>
        /// Indica el ID de la variable modificada
        /// </summary>
        private int Id;
        string Codigo;
        string Descripcion;
        string Grupo;
        string Nombre;
        bool Habilitado;
        bool Trazabilidad;
        int Tipo; 
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// NUEVO
        /// </summary>
        public FrmGestionVariablesEdicion()
        {
            InitializeComponent();
            // Formualrio de variable nueva
            this.Nuevo = true;
        }

        /// <summary>
        /// Constructor sobrecargado
        /// EDICION
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="habilitado"></param>
        /// <param name="grupo"></param>
        /// <param name="trazabilidad"></param>
        /// <param name="tipo"></param>
        public FrmGestionVariablesEdicion(int id, string codigo, string nombre, string descripcion, bool habilitado, string grupo, bool trazabilidad, int tipo)
        {
            InitializeComponent();
            this.Id = id;
            this.Codigo = codigo;
            this.Descripcion = descripcion;
            this.Grupo = grupo;
            this.Nombre = nombre;
            this.Habilitado = habilitado;
            this.Trazabilidad = trazabilidad;
            this.Tipo = tipo;
            // Formulario de variable editada
            this.Nuevo = false;
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Guarda los datos del formulario
        /// </summary>
        /// <returns>True si se ha guardado correctamente; false en caso contrario</returns>
        private bool GuardarDatos()
        {
            if (this.Nuevo)
            {
                AppBD.AddVariable(this.TxtCodigo.Text,
                    this.TxtNombre.Text,
                    this.TxtDescripcion.Text,
                    this.ChkHabilitado.Checked,
                    this.TxtGrupo.Text,
                    this.ChkTrazabilidad.Checked,
                    (int)this.CboTipo.OI.Valor);
            }
            else
            {
                int retorno = AppBD.ModificaVariable(this.Id,
                    this.TxtCodigo.Text,
                    this.TxtNombre.Text,
                    this.TxtDescripcion.Text,
                    this.ChkHabilitado.Checked,
                    this.TxtGrupo.Text,
                    this.ChkTrazabilidad.Checked,
                    (int)this.CboTipo.OI.Valor);
            }
            Guardado = true;
            return true;
        }

        /// <summary>
        /// Comprueba si se ha modificado algún dato en algún campo del formulario
        /// </summary>
        /// <returns>True si se ha modificado algún campo; false en caso contrario</returns>
        private bool ComprobarDatosModificados()
        {
            if (this.TxtCodigo.Modified)
                return true;
            if (this.TxtDescripcion.Modified)
                return true;
            if (this.TxtGrupo.Modified)
                return true;
            if (this.TxtNombre.Modified)
                return true;
            if (this.AlgoModificado)
                return true;

            return false;
        }

        /// <summary>
        /// Inicializa todos los componentes del formulario, cargando los datos si procede
        /// </summary>
        private void InicializarFormulario()
        {
            this.Inicio = true;

            //Aplicamos el formato
            ArrayList cols = new ArrayList();
            cols.Add(new OEstiloColumna("CodTipoVariable", "Codigo"));

            this.CboTipo.OI.Formatear(AppBD.GetTiposVariables(), cols, "CodTipoVariable", "IdTipoVariable");

            if (!Nuevo)
            {
                this.TxtCodigo.Text = this.Codigo;
                this.TxtNombre.Text = this.Nombre;
                this.TxtDescripcion.Text = this.Descripcion;
                this.ChkHabilitado.Checked = this.Habilitado;
                this.TxtGrupo.Text = this.Grupo;
                this.ChkTrazabilidad.Checked = this.Trazabilidad;
                this.CboTipo.OI.Valor = this.Tipo;
            }

            this.Inicio = false;
        }
        #endregion

        #region Eventos
        /// <summary>
        /// modificar el cliente seleccionado, estableciendolo como cabecera de cuenta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.GuardarDatos())
                {
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                OMensajes.MostrarError(exception);
            }
        }

        /// <summary>
        /// cancela la operación y devuelve el dialogResult = cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception exception)
            {
                OMensajes.MostrarError(exception);
            }
        }

        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGestionVariablesEdicion_Load(object sender, EventArgs e)
        {
            try
            {
                this.InicializarFormulario();
            }
            catch (Exception exception)
            {
                OMensajes.MostrarError(exception);
            }

        }

        /// <summary>
        /// Cierre del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGestionVariablesEdicion_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Si hay datos modificados en el formulario, avisar y preguntar qué hacer
                if (this.ComprobarDatosModificados() && !Guardado)
                {
                    switch (OMensajes.MostrarPreguntaSiNoCancelar("¿Desea guardar los cambios realizados de la variable " + this.TxtCodigo.Text + "?", MessageBoxDefaultButton.Button3))
                    {
                        case DialogResult.Yes:
                            if (!this.GuardarDatos())
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                        case DialogResult.No:
                            //Cerrar el formulario, es decir, seguir con la ejecucion
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            return;
                    }
                }
            }
            catch (Exception exception)
            {
                OMensajes.MostrarError(exception);
            }
        }

        /// <summary>
        /// Se ejecuta cuando cambia el valor de los controles
        /// </summary>
        /// <param name="sender">Objeto que envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void EventoValorCambiado(object sender, EventArgs e)
        {
            try
            {
                if (!this.Inicio)
                {
                    this.AlgoModificado = true;
                }
            }
            catch (Exception exception)
            {
                OMensajes.MostrarError(exception);
            }
        } 
        #endregion
    }
}
