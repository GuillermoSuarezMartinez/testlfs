//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 16-09-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Windows.Forms;
using Orbita.Utiles;
namespace Orbita.Controles.VA
{
    /// <summary>
    /// Formulario de entrada de texto por parte del usuario
    /// </summary>
    public partial class FrmInputBox : FrmDialogoBase
    {
        #region Atributo(s)
        /// <summary>
        /// Código identificativo
        /// </summary>
        public string Codigo;
        /// <summary>
        /// Título del formulario
        /// </summary>
        public string Titulo;
        /// <summary>
        /// Explicación de la entrada de texto
        /// </summary>
        public string Explicacion;
        /// <summary>
        /// Texto escrito
        /// </summary>
        public IObjetoBase ValorImputado;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public FrmInputBox(string codigo, string titulo, string explicacion, IObjetoBase valorDefecto)
            : base()
        {
            InitializeComponent();

            this.Codigo = codigo;
            this.Titulo = titulo;
            this.Explicacion = explicacion;
            this.ValorImputado = valorDefecto;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Muestra la ventana de diálogo
        /// </summary>
        /// <param name="numero"></param>
        public new bool ShowDialog(out IObjetoBase valor)
        {
            DialogResult dialogResult = base.ShowDialog();
            valor = this.ValorImputado;

            return dialogResult == DialogResult.OK;
        }
        #endregion

        #region Método(s) heredado(s)

        /// <summary>
        /// Carga y muestra datos del formulario en modo Modificación. Se cargan todos datos que se muestran en 
        /// el formulario: grids, combos, etc... Cada carga de elementos estará encapsulada en un método
        /// </summary>
        protected override void CargarDatosModoModificacion()
        {
            base.CargarDatosModoModificacion();

            this.Text = this.Titulo;
            this.LblExplicacion.Text = this.Explicacion;

            this.NumericEditorInput.Visible = false;
            this.TxtInput.Visible = false;

            if (this.ValorImputado is OEntero)
            {
                this.NumericEditorInput.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Integer;
                this.NumericEditorInput.Value = ((OEntero)this.ValorImputado).Valor;
                this.NumericEditorInput.Visible = true;
            }
            if (this.ValorImputado is ODecimal)
            {
                this.NumericEditorInput.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
                this.NumericEditorInput.Value = ((ODecimal)this.ValorImputado).Valor;
                this.NumericEditorInput.Visible = true;
            }
            else if (this.ValorImputado is OTexto)
            {
                this.TxtInput.Text = ((OTexto)this.ValorImputado).Valor;
                this.TxtInput.Visible = true;
            }
        }

        /// <summary>
        /// Realiza las comprobaciones pertinentes antes de realizar un guardado de los datos. Se usa para el caso en que hayan restricciones en el momento de guardar los datos
        /// </summary>
        /// <returns>True si todo está correcto para ser guardado; false en caso contrario</returns>
        protected override bool ComprobacionesDeCampos()
        {
            bool resultado = base.ComprobacionesDeCampos();

            if (this.ValorImputado is OEntero)
            {
                object objValor = this.NumericEditorInput.Value;
                EnumEstadoRobusto estado = ((OEntero)this.ValorImputado).Validar(ref objValor);
                resultado = estado == EnumEstadoEnteroRobusto.ResultadoCorrecto;
            }
            if (this.ValorImputado is ODecimal)
            {
                object objValor = this.NumericEditorInput.Value;
                EnumEstadoRobusto estado = ((ODecimal)this.ValorImputado).Validar(ref objValor);
                resultado = estado == EnumEstadoDecimalRobusto.ResultadoCorrecto;
            }
            else if (this.ValorImputado is OTexto)
            {
                object objValor = this.TxtInput.Text;
                EnumEstadoRobusto estado = ((OTexto)this.ValorImputado).Validar(ref objValor);
                resultado = estado == EnumEstadoTextoRobusto.ResultadoCorrecto;
            }

            return resultado;
        }

        /// <summary>
        /// Guarda los datos cuando el formulario está abierto en modo Modificación
        /// </summary>
        /// <returns>True si la operación de guardado de datos ha tenido éxito; false en caso contrario</returns>
        protected override bool GuardarDatosModoModificacion()
        {
            bool resultado = base.GuardarDatosModoModificacion();

            object objValor = null;
            if (this.ValorImputado is OEntero)
            {
                objValor =  this.NumericEditorInput.Value;
            }
            if (this.ValorImputado is ODecimal)
            {
                objValor = this.NumericEditorInput.Value;
            }
            else if (this.ValorImputado is OTexto)
            {
                objValor = this.TxtInput.Text;
            }
            this.ValorImputado.ValorGenerico = objValor;

            if (this.OnInputObject != null)
            {
                EventArgsInput e = new EventArgsInput(this.Codigo, this.ValorImputado.ValorGenerico);
                this.OnInputObject(this, e);
                resultado = true;
            }

            return resultado;
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Se ejecuta cuando se activa el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInputTextBox_Activated(object sender, EventArgs e)
        {

            if (this.ValorImputado is OEntero)
            {
                this.NumericEditorInput.Focus();
            }
            if (this.ValorImputado is ODecimal)
            {
                this.NumericEditorInput.Focus();
            }
            else if (this.ValorImputado is OTexto)
            {
                this.TxtInput.Focus();
            }
        }

        /// <summary>
        /// Evento que se lanza cuando el usuario ha aceptado la imputació del texto
        /// </summary>
        public EventHandlerInput OnInputObject;
        #endregion
    }

    /// <summary>
    /// Clase estática para la imputación de datos de texto
    /// </summary>
    public static class InputIntegerBox
    {
        #region Método(s) público(s)
        /// <summary>
        /// Imputación de número por parte del usuario
        /// </summary>
        /// <param name="titulo">Título de la ventana de diálogo</param>
        /// <param name="explicacion">Explicación del dato a imputar</param>
        /// <param name="valor">Valor por defecto</param>
        /// <returns>Verdadero si el usuario ha aceptado la imputación</returns>
        public static bool ShowModal(string codigo, string titulo, string explicacion, ref int valor, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            IObjetoBase entero = new OEntero(codigo, minValue, maxValue, valor, false);

            FrmInputBox frm = new FrmInputBox(codigo, titulo, explicacion, entero);

            bool ok = frm.ShowDialog(out entero);

            valor = ((OEntero)entero).Valor;
            return ok;
        }

        /// <summary>
        /// Imputación de número por parte del usuario
        /// </summary>
        /// <param name="titulo">Título de la ventana de diálogo</param>
        /// <param name="explicacion">Explicación del dato a imputar</param>
        /// <param name="texto">Valor por defecto</param>
        /// <returns>Verdadero si el usuario ha aceptado la imputación</returns>
        public static void Show(string codigo, string titulo, string explicacion, int valor, EventHandlerInput onInputObject, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            IObjetoBase entero = new OEntero(codigo, minValue, maxValue, valor, false);

            FrmInputBox frm = new FrmInputBox(codigo, titulo, explicacion, entero);
            frm.OnInputObject = onInputObject;
            frm.Show();
        }
        #endregion
    }

    /// <summary>
    /// Clase estática para la imputación de datos de texto
    /// </summary>
    public static class InputDoubleBox
    {
        #region Método(s) público(s)
        /// <summary>
        /// Imputación de número por parte del usuario
        /// </summary>
        /// <param name="titulo">Título de la ventana de diálogo</param>
        /// <param name="explicacion">Explicación del dato a imputar</param>
        /// <param name="valor">Valor por defecto</param>
        /// <returns>Verdadero si el usuario ha aceptado la imputación</returns>
        public static bool ShowModal(string codigo, string titulo, string explicacion, ref double valor, double minValue = double.MinValue, double maxValue = double.MaxValue)
        {
            IObjetoBase entero = new ODecimal(codigo, minValue, maxValue, valor, false);

            FrmInputBox frm = new FrmInputBox(codigo, titulo, explicacion, entero);
            bool ok = frm.ShowDialog(out entero);

            valor = ((ODecimal)entero).Valor;
            return ok;
        }

        /// <summary>
        /// Imputación de número por parte del usuario
        /// </summary>
        /// <param name="titulo">Título de la ventana de diálogo</param>
        /// <param name="explicacion">Explicación del dato a imputar</param>
        /// <param name="texto">Valor por defecto</param>
        /// <returns>Verdadero si el usuario ha aceptado la imputación</returns>
        public static void Show(string codigo, string titulo, string explicacion, double valor, EventHandlerInput onInputObject, double minValue = double.MinValue, double maxValue = double.MaxValue)
        {
            IObjetoBase entero = new ODecimal(codigo, minValue, maxValue, valor, false);

            FrmInputBox frm = new FrmInputBox(codigo, titulo, explicacion, entero);
            frm.OnInputObject = onInputObject;
            frm.Show();
        }
        #endregion
    }

    /// <summary>
    /// Clase estática para la imputación de datos de texto
    /// </summary>
    public static class InputTextBox
    {
        #region Método(s) público(s)
        /// <summary>
        /// Imputación de texto por parte del usuario
        /// </summary>
        /// <param name="titulo">Título de la ventana de diálogo</param>
        /// <param name="explicacion">Explicación del dato a imputar</param>
        /// <param name="valor">Texto por defecto</param>
        /// <returns>Verdadero si el usuario ha aceptado la imputación</returns>
        public static bool ShowModal(string codigo, string titulo, string explicacion, ref string valor, int maxLength = int.MaxValue, bool admiteVacio = true, bool limitarLongitud = false)
        {
            IObjetoBase texto = new OTexto(codigo, maxLength, admiteVacio, limitarLongitud, valor, false);

            FrmInputBox frm = new FrmInputBox(codigo, titulo, explicacion, texto);
            bool ok = frm.ShowDialog(out texto);

            valor = ((OTexto)texto).Valor;
            return ok;
        }

        /// <summary>
        /// Imputación de texto por parte del usuario
        /// </summary>
        /// <param name="titulo">Título de la ventana de diálogo</param>
        /// <param name="explicacion">Explicación del dato a imputar</param>
        /// <param name="texto">Texto por defecto</param>
        /// <returns>Verdadero si el usuario ha aceptado la imputación</returns>
        public static void Show(string codigo, string titulo, string explicacion, string valor, EventHandlerInput onInputObject, int maxLength = int.MaxValue, bool admiteVacio = true, bool limitarLongitud = false)
        {
            IObjetoBase texto = new OTexto(codigo, maxLength, admiteVacio, limitarLongitud, valor, false);

            FrmInputBox frm = new FrmInputBox(codigo, titulo, explicacion, texto);
            frm.OnInputObject = onInputObject;
            frm.Show();
        }
        #endregion
    }

    #region Definición de delegado(s)
    /// <summary>
    /// Parametros de retorno del evento que indica de la llegada de un mensaje actualizacion
    /// </summary>
    public class EventArgsInput : EventArgs
    {
        #region Atributo(s)
        /// <summary>
        /// Código identificativo
        /// </summary>
        public string Codigo;

        /// <summary>
        /// Texto imputado por el usuario
        /// </summary>
        public object ObjetoImputado;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public EventArgsInput()
        {
            this.ObjetoImputado = string.Empty;
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public EventArgsInput(string codigo, object objetoImputado)
        {
            this.Codigo = codigo;
            this.ObjetoImputado = objetoImputado;
        }
        #endregion
    }

    /// <summary>
    /// Delegado que indica de la llegada de un nuevo resultado parcial
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void EventHandlerInput(object sender, EventArgsInput e);
    #endregion
}