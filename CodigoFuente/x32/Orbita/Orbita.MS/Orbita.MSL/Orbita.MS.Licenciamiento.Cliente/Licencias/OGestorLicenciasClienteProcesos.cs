using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Management;
using System.ServiceProcess;
using System.Threading;

namespace Orbita.MS
{
    public partial class OGestorLicenciasCliente
    {
        #region Operaciones de cierre
        /// <summary>
        /// Inicia los servicios dependiente del cliente. En el orden indicado en ServiciosAsociados.
        /// </summary>
        /// <param name="espera">Tiempo en milisegundos entre acciones de servicios</param>
        public void IniciarServiciosCliente(int espera = 0)
        {
            foreach (string serv in this._servicios)
            {
                try
                {
                    ServiceController controlador = new ServiceController(serv);
                    controlador.Start();
                }
                catch (Exception e1)
                {
                    _log.Error(e1);
                }
                if (espera > 0) Thread.Sleep(espera);
            }
        }
        /// <summary>
        /// Finaliza los servicios dependiente del cliente. En el orden indicado en ServiciosAsociados.
        /// </summary>
        /// <param name="espera">Tiempo en milisegundos entre acciones de servicios</param>
        public void TerminarServiciosCliente(int espera = 0)
        {
            foreach (string serv in this._servicios)
            {
                try
                {
                    ServiceController controlador = new ServiceController(serv);
                    controlador.Stop();
                }
                catch (Exception e1)
                {
                    _log.Error(e1);
                }
                if (espera > 0) Thread.Sleep(espera);
            }
        }
        /// <summary>
        /// Permite finalizar de forma controlada la aplicación, subprocesos y servicios.
        /// </summary>
        public void ProcesoControladoCierreAplicacion()
        {
            try
            {
                this.TerminarServiciosCliente();
                this.TerminarProcesosCliente();

            }
            catch (Exception e1)
            {
                _log.Error(e1);
            }
        }
        /// <summary>
        /// Detiene todos los procesos del cliente
        /// </summary>
        public void TerminarProcesosCliente()
        {
            _log.Info("Obteniendo información actual de proceso ...");
            Process pr = Process.GetCurrentProcess();
            int pid = pr.Id;
            int hilos = pr.Threads.Count;

            _log.Info(pr.ProcessName + " " + pid + " " + hilos);
            try
            {
                TerminarSubprocesos(pid);
            }
            catch (Exception) { }

            foreach (System.Diagnostics.ProcessThread th in pr.Threads)
            {
                try
                {
                    _log.Info("Finalizando hilo " + th.Id);
                    th.Dispose();
                }
                catch (Exception) { }
            }
        }
        /// <summary>
        /// Termina de forma recursiva con todos los subprocesos de la aplicación
        /// </summary>
        /// <param name="pid"></param>
        private void TerminarSubprocesos(int pid)
        {
            using (var searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid))
            using (ManagementObjectCollection moc = searcher.Get())
            {
                foreach (ManagementObject mo in moc)
                {
                    TerminarSubprocesos(Convert.ToInt32(mo["ProcessID"]));
                }
                try
                {
                    Process proc = Process.GetProcessById(pid);
                    if (!proc.ProcessName.Contains("vshost"))
                    {
                        proc.Kill();
                    }
                }
                catch (ArgumentException)
                { }
            }
        }
        #endregion Operaciones de cierre
    }
}
