//***********************************************************************
// Assembly         : Orbita.Framework.Core
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Framework.Core
{
    /// <summary>
    /// El diálogo muestra una instancia WaitWindow.
    /// </summary>
    internal partial class WaitWindowGUI : System.Windows.Forms.Form
    {
        #region Atributos
        WaitWindow parent;
        System.IAsyncResult threadResult;
        #endregion

        #region Atributos internos
        internal object result;
        internal System.Exception error;
        #endregion

        #region Delegados
        delegate T FunctionInvoker<T>();
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.WaitWindowGUI.
        /// </summary>
        /// <param name="parent"></param>
        public WaitWindowGUI(WaitWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        #endregion

        #region Métodos privados
        void WorkComplete(System.IAsyncResult results)
        {
            if (!this.IsDisposed)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new WaitWindow.MethodInvoker<System.IAsyncResult>(this.WorkComplete), results);
                }
                else
                {
                    //  Capturar el resultado.
                    try
                    {
                        this.result = ((FunctionInvoker<object>)results.AsyncState).EndInvoke(results);
                    }
                    catch (System.Exception ex)
                    {
                        this.error = ex;
                    }
                    this.Close();
                }
            }
        }
        #endregion

        #region Métodos internos
        internal object DoWork()
        {
            //  Invocar el workerMethod y devolver el resultado.
            WaitWindowEventArgs e = new WaitWindowEventArgs(this.parent, this.parent.args);
            if ((this.parent.workerMethod != null))
            {
                this.parent.workerMethod(this, e);
            }
            return e.Resultado;
        }
        internal void SetMessage(string message)
        {
            this.MessageLabel.Text = message;
        }
        internal void Cancel()
        {
            this.Invoke(new System.Windows.Forms.MethodInvoker(this.Close), null);
        }
        #endregion

        #region Manejadores de eventos
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                //  Pintar un borde coloreado.
                System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, System.Drawing.Color.Gray, System.Windows.Forms.ButtonBorderStyle.Solid);
            }
            catch (System.NullReferenceException) { }
        }
        protected override void OnShown(System.EventArgs e)
        {
            base.OnShown(e);

            //  Crear delegado.
            FunctionInvoker<object> threadController = new FunctionInvoker<object>(this.DoWork);
            //  Ejecutar un hilo secundario.
            this.threadResult = threadController.BeginInvoke(this.WorkComplete, threadController);
        }
        #endregion
    }
}