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
    /// Mostrar una ventana que indica al usuario una espera a un proceso que se está ejecutando.
    /// </summary>
    public class WaitWindow : System.IDisposable
    {
        #region Atributos
        /// <summary>
        /// Acceso a la interfaz gráfica de usuario GUI.
        /// </summary>
        private WaitWindowGUI GUI;
        #endregion

        #region Atributos internos
        internal delegate void MethodInvoker<T>(T parametro);
        internal System.EventHandler<WaitWindowEventArgs> metodoAsincrono;
        internal System.Collections.Generic.IList<object> argumentos;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.WaitWindow.
        /// </summary>
        private WaitWindow() { }
        #endregion

        #region Destructor
        /// <summary>
        /// Indica si ya se llamo al método Dispose. (Default = false)
        /// </summary>
        bool disposed = false;
        /// <summary>
        /// Implementa IDisposable. No  hacer  este  método  virtual.
        /// Una clase derivada no debería ser capaz de  reemplazar este método.
        /// </summary>
        public void Dispose()
        {
            //  Llamo al método que  contiene la lógica
            //  para liberar los recursos de esta clase.
            Dispose(true);
            //  Este objeto será limpiado por el método Dispose.
            //  Llama al método del recolector de basura, GC.SuppressFinalize.
            System.GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Método  sobrecargado de  Dispose que será  el que libera los recursos. Controla que solo se ejecute
        /// dicha lógica una  vez y evita que el GC tenga que llamar al destructor de clase.
        /// </summary>
        /// <param name="disposing">Indica si llama al método Dispose.</param>
        protected virtual void Dispose(bool disposing)
        {
            //  Preguntar si Dispose ya fue llamado.
            if (!this.disposed)
            {
                if (disposing)
                {
                    //  Llamar a dispose de todos los recursos manejados.
                    this.GUI.Dispose();
                }

                //  Finalizar correctamente los recursos no manejados.
                //  { Empty }

                //  Marcar como desechada ó desechandose,
                //  de forma que no se puede ejecutar el
                //  código dos veces.
                disposed = true;
            }
        }
        /// <summary>
        /// Destructor(es) de clase.
        /// En caso de que se nos olvide “desechar” la clase, el GC llamará al destructor, que tambén ejecuta 
        /// la lógica anterior para liberar los recursos.
        /// </summary>
        ~WaitWindow()
        {
            //  Llamar a Dispose(false) es óptimo en terminos de legibilidad y mantenimiento.
            Dispose(false);
        }
        #endregion

        #region Métodos públicos estáticos
        /// <summary>
        /// Mostrar una ventana de espera con el texto "Por favor espere ..." mientras se ejecuta el método aprobado.
        /// </summary>
        /// <param name="workerMethod">Puntero a el método para ejecutar mientras se muestra la ventana de espera.</param>
        /// <returns>Argumento de resultado del método de trabajo.</returns>
        public static object Mostrar(System.EventHandler<WaitWindowEventArgs> workerMethod)
        {
            return WaitWindow.Mostrar(workerMethod, null);
        }
        /// <summary>
        /// Mostrar una ventana de espera con el texto especificado mientras se ejecuta el método aprobado.
        /// </summary>
        /// <param name="workerMethod">Puntero a el método para ejecutar mientras se muestra la ventana de espera.</param>
        /// <param name="mensaje">Texto que se mostrará.</param>
        /// <returns>Argumento de resultado del método de trabajo.</returns>
        public static object Mostrar(System.EventHandler<WaitWindowEventArgs> workerMethod, string mensaje)
        {
            object result = null;
            using (WaitWindow ventanaEspera = new WaitWindow())
            {
                result = ventanaEspera.Mostrar(workerMethod, mensaje, new System.Collections.Generic.List<object>());
            }
            return result;
        }
        /// <summary>
        /// Mostrar una ventana de espera con el texto especificado al ejecutar el método pasado.
        /// </summary>
        /// <param name="workerMethod">Puntero a el método para ejecutar mientras se muestra la ventana de espera.</param>
        /// <param name="mensaje">Texto que se mostrará.</param>
        /// <param name="args">Argumentos a pasar al método de trabajo.</param>
        /// <returns>Argumento de resultado del método de trabajo.</returns>
        public static object Mostrar(System.EventHandler<WaitWindowEventArgs> workerMethod, string mensaje, params object[] args)
        {
            object result = null;
            using (WaitWindow ventanaEspera = new WaitWindow())
            {
                System.Collections.Generic.List<object> argumentos = new System.Collections.Generic.List<object>();
                argumentos.AddRange(args);
                result = ventanaEspera.Mostrar(workerMethod, mensaje, argumentos);
            }
            return result;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Actualizar el mensaje que aparece en la ventana de espera.
        /// </summary>
        public string Mensaje
        {
            get { return this.GUI.Message; }
            set { this.GUI.Invoke(new MethodInvoker<string>(this.GUI.SetMessage), value); }
        }
        /// <summary>
        /// Cancelar el trabajo y sale de las ventanas de espera inmediatamente.
        /// </summary>
        public void Cancelar()
        {
            this.GUI.Invoke(new System.Windows.Forms.MethodInvoker(this.GUI.Cancel), null);
        }
        #endregion

        #region Métodos privados
        private object Mostrar(System.EventHandler<WaitWindowEventArgs> workerMethod, string mensaje, System.Collections.Generic.IList<object> args)
        {
            if (workerMethod == null)
            {
                throw new System.ArgumentException("No se ha especificado un método de trabajo.", "workerMethod");
            }
            else
            {
                this.metodoAsincrono = workerMethod;
            }

            this.argumentos = args;

            //  Configurar la ventana de espera.
            this.GUI = new WaitWindowGUI(this);
            this.GUI.MessageLabel.Text = mensaje;
            //  Mostrar la ventana de espera.
            this.GUI.ShowDialog();

            object result = this.GUI.resultado;

            //  Dispose.
            System.Exception error = this.GUI.error;
            this.GUI.Dispose();

            //  Retornar resultado o excepción.
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