using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.ServiceProcess;
namespace Orbita.Utiles
{
    /// <summary>
    /// OServicioWindows.
    /// </summary>
    public class OServicioWindows : IDisposable
    {
        #region Atributos
        /// <summary>
        /// Nombre del servicio.
        /// </summary>
        string nombre;
        /// <summary>
        /// Ruta del ejecutable.
        /// </summary>
        string ruta;
        /// <summary>
        /// M�quina donde se encuentra el servicio Windows.
        /// </summary>
        string maquina = ".";
        /// <summary>
        /// TimeOut de espera hasta el inicio/paro del servicio Windows.
        /// </summary>
        int timeOutMilisegundos = 10000;
        /// <summary>
        /// Controlador del servicio instalado.
        /// </summary>
        ServiceController controlador;
        #endregion

        #region Propiedades
        /// <summary>
        /// Informa si existe alg�n servicio con el nombre especificado, en caso contrario se supone que el servicio no est� instalado
        /// </summary>
        public bool Instalado
        {
            get { return this.IsInstalled(); }
            set { this.Instalar(value); }
        }
        /// <summary>
        /// Estado del servicio
        /// </summary>
        public ServiceControllerStatus Estado
        {
            get { return this.controlador.Status; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre">Nombre del servicio.</param>
        /// <param name="ruta">Ruta del servicio.</param>
        public OServicioWindows(string nombre, string ruta)
        {
            this.nombre = nombre;
            this.ruta = ruta;
            this.controlador = new ServiceController(this.nombre, this.maquina);
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="nombre">Nombre del servicio</param>
        public OServicioWindows(string nombre, string ruta, string maquina)
        {
            this.nombre = nombre;
            this.ruta = ruta;
            this.maquina = maquina;
            this.controlador = new ServiceController(this.nombre, this.maquina);
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="nombre">Nombre del servicio</param>
        public OServicioWindows(string nombre, string ruta, int timeOutMilisegundos)
        {
            this.nombre = nombre;
            this.ruta = ruta;
            this.timeOutMilisegundos = timeOutMilisegundos;

            this.controlador = new ServiceController(this.nombre, this.maquina);
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="nombre">Nombre del servicio</param>
        public OServicioWindows(string nombre, string ruta, string maquina, int timeOutMilisegundos)
        {
            this.nombre = nombre;
            this.ruta = ruta;
            this.maquina = maquina;
            this.timeOutMilisegundos = timeOutMilisegundos;
            this.controlador = new ServiceController(this.nombre, this.maquina);
        }
        #endregion

        #region Destructores
        /// <summary>
        /// Indica si ya se llamo al m�todo Dispose. (default = false)
        /// </summary>
        bool disposed = false;
        /// <summary>
        /// Implementa IDisposable.
        /// No  hacer  este  m�todo  virtual.
        /// Una clase derivada no deber�a ser
        /// capaz de  reemplazar este m�todo.
        /// </summary>
        public void Dispose()
        {
            // Llamo al m�todo que  contiene la l�gica
            // para liberar los recursos de esta clase.
            Dispose(true);
            // Este objeto ser� limpiado por el m�todo Dispose.
            // Llama al m�todo del recolector de basura, GC.SuppressFinalize.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// M�todo  sobrecargado de  Dispose que ser�  el que
        /// libera los recursos. Controla que solo se ejecute
        /// dicha l�gica una  vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name="disposing">Indica si llama al m�todo Dispose.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Preguntar si Dispose ya fue llamado.
            if (!this.disposed)
            {
                // Finalizar correctamente los recursos no manejados.
                this.nombre = null;
                this.maquina = null;

                // Marcar como desechada � desechandose,
                // de forma que no se puede ejecutar el
                // c�digo dos veces.
                disposed = true;
            }
        }
        /// <summary>
        /// Destructor(es) de clase.
        /// En caso de que se nos olvide �desechar� la clase,
        /// el GC llamar� al destructor, que tamb�n ejecuta 
        /// la l�gica anterior para liberar los recursos.
        /// </summary>
        ~OServicioWindows()
        {
            // Llamar a Dispose(false) es �ptimo en terminos
            // de legibilidad y mantenimiento.
            Dispose(false);
        }
        #endregion

        #region M�todos p�blicos
        /// <summary>
        /// Instala el servicio
        /// </summary>
        /// <returns>Verdadero si el proceso ha finalizado con �xito</returns>
        public bool Instalar()
        {
            return this.Instalar(true);
        }
        /// <summary>
        /// Desinstala el servicio
        /// </summary>
        /// <returns>Verdadero si el proceso ha finalizado con �xito</returns>
        public bool Desinstalar()
        {
            return this.Instalar(false);
        }
        /// <summary>
        /// Inicia el servicio
        /// </summary>
        /// <returns>Verdadero si se ha iniciado con �xtio</returns>
        public bool Iniciar()
        {
            if (this.controlador is ServiceController)
            {
                if ((this.controlador.Status == ServiceControllerStatus.Stopped) || (this.controlador.Status == ServiceControllerStatus.Paused))
                {
                    this.controlador.Start();
                    this.controlador.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(this.timeOutMilisegundos));
                }
            }
            return this.controlador.Status == ServiceControllerStatus.Running;
        }
        /// <summary>
        /// Inicia el servicio
        /// </summary>
        /// <returns>Verdadero si se ha iniciado con �xtio</returns>
        public bool Detener()
        {
            if (this.controlador is ServiceController)
            {
                if ((this.controlador.Status == ServiceControllerStatus.Running) || (this.controlador.Status == ServiceControllerStatus.Paused))
                {
                    this.controlador.Stop();
                    this.controlador.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(this.timeOutMilisegundos));
                }
            }
            return this.controlador.Status == ServiceControllerStatus.Stopped;
        }
        #endregion

        #region M�todos privados
        /// <summary>
        /// Instala o desinstala el servicio
        /// </summary>
        /// <returns>Verdadero si el proceso ha finalizado con �xito</returns>
        private bool Instalar(bool valor)
        {
            Process proceso = new Process();
            string netFolder = RuntimeEnvironment.GetRuntimeDirectory();
            string rutaInstalador = Path.Combine(netFolder, "installutil.exe");
            if (File.Exists(rutaInstalador))
            {
                proceso.StartInfo.FileName = Path.Combine(netFolder, "installutil.exe");
                proceso.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                if (valor)
                {
                    proceso.StartInfo.Arguments = this.ruta;
                }
                else
                {
                    proceso.StartInfo.Arguments = "-u " + this.ruta;
                }
                proceso.Start();
                proceso.WaitForExit();
                return this.IsInstalled();
            }
            return false;
        }
        /// <summary>
        /// Consulta si el servicio est� instalado
        /// </summary>
        /// <returns></returns>
        private bool IsInstalled()
        {
            this.controlador = null;
            ServiceController[] listaServicios = ServiceController.GetServices();
            foreach (ServiceController servicio in listaServicios)
            {
                if ((servicio.ServiceName == this.nombre) && (servicio.MachineName == this.maquina))
                {
                    this.controlador = servicio;
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}