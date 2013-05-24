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
    /// Muestra una ventana que indica al usuario una espera a un proceso que se está ejecutando.
    /// </summary>
    public sealed class WaitWindow
    {
        #region Atributos
        WaitWindowGUI GUI;
        #endregion

        #region Atributos internos
        internal delegate void MethodInvoker<T>(T parametro);
        internal System.EventHandler<WaitWindowEventArgs> workerMethod;
        internal System.Collections.Generic.List<object> args;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.WaitWindow.
        /// </summary>
        WaitWindow() { }
        #endregion

        #region Métodos públicos estáticos
        /// <summary>
        /// Muestra una ventana de espera con el texto "Por favor espere ..." mientras se ejecuta el método aprobado.
        /// </summary>
        /// <param name="workerMethod">Puntero a el método para ejecutar mientras se muestra la ventana de espera.</param>
        /// <returns>El argumento de resultado del método de trabajo.</returns>
        public static object Mostrar(System.EventHandler<WaitWindowEventArgs> workerMethod)
        {
            return WaitWindow.Mostrar(workerMethod, null);
        }
        /// <summary>
        /// Muestra una ventana de espera con el texto especificado mientras se ejecuta el método aprobado.
        /// </summary>
        /// <param name="workerMethod">Puntero a el método para ejecutar mientras se muestra la ventana de espera.</param>
        /// <param name="mensaje">El texto que se mostrará.</param>
        /// <returns>El argumento de resultado del método de trabajo.</returns>
        public static object Mostrar(System.EventHandler<WaitWindowEventArgs> workerMethod, string mensaje)
        {
            return new WaitWindow().Mostrar(workerMethod, mensaje, new System.Collections.Generic.List<object>());
        }
        /// <summary>
        /// Muestra una ventana de espera con el texto especificado al ejecutar el método pasado.
        /// </summary>
        /// <param name="workerMethod">Puntero a el método para ejecutar mientras se muestra la ventana de espera.</param>
        /// <param name="mensaje">El texto que se mostrará.</param>
        /// <param name="args">Argumentos a pasar al método de trabajo.</param>
        /// <returns>El argumento de resultado del método de trabajo.</returns>
        public static object Mostrar(System.EventHandler<WaitWindowEventArgs> workerMethod, string mensaje, params object[] args)
        {
            System.Collections.Generic.List<object> argumentos = new System.Collections.Generic.List<object>();
            argumentos.AddRange(args);
            return new WaitWindow().Mostrar(workerMethod, mensaje, argumentos);
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Actualiza el mensaje que aparece en la ventana de espera.
        /// </summary>
        public string Mensaje
        {
            set { this.GUI.Invoke(new MethodInvoker<string>(this.GUI.SetMessage), value); }
        }
        /// <summary>
        /// Cancela el trabajo y sale de las ventanas de espera inmediatamente.
        /// </summary>
        public void Cancelar()
        {
            this.GUI.Invoke(new System.Windows.Forms.MethodInvoker(this.GUI.Cancel), null);
        }
        #endregion

        #region Métodos privados
        object Mostrar(System.EventHandler<WaitWindowEventArgs> workerMethod, string mensaje, System.Collections.Generic.List<object> args)
        {
            if (workerMethod == null)
            {
                throw new System.ArgumentException("No se ha especificado un método de trabajo.", "workerMethod");
            }
            else
            {
                this.workerMethod = workerMethod;
            }

            this.args = args;
            if (string.IsNullOrEmpty(mensaje))
            {
                mensaje = "Espere por favor...";
            }

            // Configurar la ventana.
            this.GUI = new WaitWindowGUI(this);
            this.GUI.MessageLabel.Text = mensaje;

            this.GUI.ShowDialog();

            object result = this.GUI.result;

            // Dispose.
            System.Exception error = this.GUI.error;
            this.GUI.Dispose();

            // Retornar resultado o excepción.
            if (error != null)
            {
                throw error;
            }
            else
            {
                return result;
            }
        }
        #endregion
    }
}