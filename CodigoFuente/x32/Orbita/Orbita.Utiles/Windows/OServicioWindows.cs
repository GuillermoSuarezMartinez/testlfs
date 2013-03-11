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
        #region Atributo(s)
        /// <summary>
        /// Nombre del servicio
        /// </summary>
        string Nombre;
        /// <summary>
        /// Ruta del ejecutable
        /// </summary>
        string Ruta;
        /// <summary>
        /// Máquina donde se encuentra el servicio Windows.
        /// </summary>
        string Maquina = ".";
        /// <summary>
        /// TimeOut de espera hasta el inicio/paro
        /// del servicio Windows.
        /// </summary>
        int TimeOutMilisegundos = 10000;
        /// <summary>
        /// Controlador del servicio instalado
        /// </summary>
        private ServiceController Controlador;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Informa si existe algún servicio con el nombre especificado, en caso contrario se supone que el servicio no está instalado
        /// </summary>
        public bool Instalado
        {
            get
            {
                return this.IsInstalled();
            }
            set
            {
                this.Instalar(value);
            }
        }

        /// <summary>
        /// Estado del servicio
        /// </summary>
        public ServiceControllerStatus Estado
        {
            get { return this.Controlador.Status; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="nombre">Nombre del servicio</param>
        public OServicioWindows(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;

            this.Controlador = new ServiceController(this.Nombre, this.Maquina);
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="nombre">Nombre del servicio</param>
        public OServicioWindows(string nombre, string ruta, string maquina)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
            this.Maquina = maquina;

            this.Controlador = new ServiceController(this.Nombre, this.Maquina);
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="nombre">Nombre del servicio</param>
        public OServicioWindows(string nombre, string ruta, int timeOutMilisegundos)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
            this.TimeOutMilisegundos = timeOutMilisegundos;

            this.Controlador = new ServiceController(this.Nombre, this.Maquina);
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="nombre">Nombre del servicio</param>
        public OServicioWindows(string nombre, string ruta, string maquina, int timeOutMilisegundos)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
            this.Maquina = maquina;
            this.TimeOutMilisegundos = timeOutMilisegundos;

            this.Controlador = new ServiceController(this.Nombre, this.Maquina);
        }
        #endregion

        #region Destructor(es)
        /// <summary>
        /// Indica si ya se llamo al método Dispose. (default = false)
        /// </summary>
        bool disposed = false;
        /// <summary>
        /// Implementa IDisposable.
        /// No  hacer  este  método  virtual.
        /// Una clase derivada no debería ser
        /// capaz de  reemplazar este método.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que  contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
            // Este objeto será limpiado por el método Dispose.
            // Llama al método del recolector de basura, GC.SuppressFinalize.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Método  sobrecargado de  Dispose que será  el que
        /// libera los recursos. Controla que solo se ejecute
        /// dicha lógica una  vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name="disposing">Indica si llama al método Dispose.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Preguntar si Dispose ya fue llamado.
            if (!this.disposed)
            {
                // Finalizar correctamente los recursos no manejados.
                this.Nombre = null;
                this.Maquina = null;

                // Marcar como desechada ó desechandose,
                // de forma que no se puede ejecutar el
                // código dos veces.
                disposed = true;
            }
        }
        /// <summary>
        /// Destructor(es) de clase.
        /// En caso de que se nos olvide “desechar” la clase,
        /// el GC llamará al destructor, que tambén ejecuta 
        /// la lógica anterior para liberar los recursos.
        /// </summary>
        ~OServicioWindows()
        {
            // Llamar a Dispose(false) es óptimo en terminos
            // de legibilidad y mantenimiento.
            Dispose(false);
        }
        #endregion

        #region Método(s) público
        /// <summary>
        /// Instala el servicio
        /// </summary>
        /// <returns>Verdadero si el proceso ha finalizado con éxito</returns>
        public bool Instalar()
        {
            return this.Instalar(true);
        }
        /// <summary>
        /// Desinstala el servicio
        /// </summary>
        /// <returns>Verdadero si el proceso ha finalizado con éxito</returns>
        public bool Desinstalar()
        {
            return this.Instalar(false);
        }
        /// <summary>
        /// Inicia el servicio
        /// </summary>
        /// <returns>Verdadero si se ha iniciado con éxtio</returns>
        public bool Iniciar()
        {
            if (this.Controlador is ServiceController)
            {
                if ((this.Controlador.Status == ServiceControllerStatus.Stopped) || (this.Controlador.Status == ServiceControllerStatus.Paused))
                {
                    this.Controlador.Start();
                    this.Controlador.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(this.TimeOutMilisegundos));
                }

            }
            return this.Controlador.Status == ServiceControllerStatus.Running;
        }
        /// <summary>
        /// Inicia el servicio
        /// </summary>
        /// <returns>Verdadero si se ha iniciado con éxtio</returns>
        public bool Detener()
        {
            if (this.Controlador is ServiceController)
            {
                if ((this.Controlador.Status == ServiceControllerStatus.Running) || (this.Controlador.Status == ServiceControllerStatus.Paused))
                {
                    this.Controlador.Stop();
                    this.Controlador.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(this.TimeOutMilisegundos));
                }
            }
            return this.Controlador.Status == ServiceControllerStatus.Stopped;
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Instala o desinstala el servicio
        /// </summary>
        /// <returns>Verdadero si el proceso ha finalizado con éxito</returns>
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
                    proceso.StartInfo.Arguments = this.Ruta;
                }
                else
                {
                    proceso.StartInfo.Arguments = "-u " + this.Ruta;
                }
                proceso.Start();
                proceso.WaitForExit();
                return this.IsInstalled();
            }
            return false;
        }
        /// <summary>
        /// Consulta si el servicio está instalado
        /// </summary>
        /// <returns></returns>
        private bool IsInstalled()
        {
            this.Controlador = null;
            ServiceController[] listaServicios = ServiceController.GetServices();
            foreach (ServiceController servicio in listaServicios)
            {
                if ((servicio.ServiceName == this.Nombre) && (servicio.MachineName == this.Maquina))
                {
                    this.Controlador = servicio;
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}