//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : aiba�ez
// Created          : 06-09-2012
//
// Last Modified By : aiba�ez
// Last Modified On : 16-11-2012
// Description      : Modificados m�todos de finalizaci�n
//                    Deshabiliada la gesti�n de memoria por parte de VisionPro
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.ComponentModel;
using System.IO;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using Orbita.VA.Comun;
using Orbita.VA.Hardware;
using Orbita.Utiles;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Funci�n de visi�n de VisionPro
    /// </summary>
    public class OFuncionVisionPro : OFuncionVisionBase
    {
        #region Constante(s)
        /// <summary>
        /// Se optimizar� la velocidad de la primera ejecuci�n, realizando una ejecuci�n al cargarse el archivo vpp
        /// </summary>
        private const bool OptimizarVelocidad = true;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Variable CogToolBlock que carga la aplicaci�n
        /// </summary>
        public CogToolBlock ToolBlock;

        /// <summary>
        /// Trabajo en segundo plano
        /// </summary>
        private BackgroundWorker ThreadEjecucion;

        #endregion

        #region Constructor(es)
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public OFuncionVisionPro(string codFuncionVision)
            : base(codFuncionVision)
        {
            try
            {
                this.TipoFuncionVision = TipoFuncionVision.VisionPro;

                // Creaci�n de los campos
                this.ThreadEjecucion = new BackgroundWorker();
                this.ThreadEjecucion.WorkerSupportsCancellation = true;
                this.ThreadEjecucion.DoWork += new DoWorkEventHandler(this.EjecucionEnThread);
                this.ThreadEjecucion.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.FinEjecucionThread);

                // Carga del fichero vpp
                if (Path.IsPathRooted(this.RutaFichero) && File.Exists(this.RutaFichero))
                {
                    // Se carga el job
                    object vppFile;
                    //Encriptado con extensi�n vpe
                    if (this.RutaFichero.Contains(".vpe"))
                    {
                        Stream streamVPE = new MemoryStream(OEncriptacion.DecryptFileToBytes(this.RutaFichero, "OrbitaIng06"));
                        vppFile = CogSerializer.LoadObjectFromStream(streamVPE);
                    }
                    else
                    {
                        // Sin Encriptar
                        vppFile = CogSerializer.LoadObjectFromFile(this.RutaFichero);
                    }

                    if (vppFile is CogToolBlock)
                    {
                        this.ToolBlock = (CogToolBlock)vppFile;

                        this.Valido = true;
                    }
                }

                if (!this.Valido)
                {
                    throw new Exception("Ha sido imposible cargar la funci�n de visi�n pro '" + codFuncionVision + "'. El archivo '" + this.RutaFichero + "' no existe o est� da�ado.");
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosFunciones.VisionPro, this.Codigo, exception);
            }
        }

        #endregion

        #region M�todo(s) privado(s)
        /// <summary>
        /// Ejecuci�n de la funci�n a trav�s de otro hilo de ejecuci�n distinto al de la aplicaci�n principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EjecucionEnThread(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Run the toolblock
                this.ToolBlock.Run();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosFunciones.VisionPro, this.Codigo, exception);
            }
        }

        /// <summary>
        /// Final de la ejecuci�n de la funci�n
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinEjecucionThread(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                OThreadManager.SincronizarConThreadPrincipal(new RunWorkerCompletedEventHandler(this.FinEjecucionThread), new object[] { sender, e });
                return;
            }

            this.FuncionEjecutada();
        }

        #endregion

        #region M�todo(s) heredado(s)
        /// <summary>
        /// Carga el fichero de QuickBuild Application
        /// </summary>
        public override void Inicializar()
        {
            base.Inicializar();

            try
            {
                if (this.Valido)
                {
                    //this.ToolBlock.GarbageCollectionEnabled = true;
                    this.ToolBlock.GarbageCollectionEnabled = false;
                    if (OptimizarVelocidad)
                    {
                        // La primera ejecuci�n es muy lenta por lo que se realiza una ejecuci�n de prueba al cargar el toolblock
                        this.ToolBlock.Run();
                    }

                    this.Valido = true;
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosFunciones.VisionPro, this.Codigo, exception);
            }
        }

        /// <summary>
        /// M�todo a heredar donde se descarga el fichero de la funci�n de visi�n
        /// </summary>
        public override void Finalizar()
        {
            base.Finalizar();

            // Disconnect the event handlers before disposing the object
            if (this.ThreadEjecucion != null)
            {
                this.ThreadEjecucion.CancelAsync();
                this.ThreadEjecucion.Dispose();
                this.ThreadEjecucion = null;
            }

            if (this.ToolBlock != null)
            {
                this.ToolBlock.Dispose();
                this.ToolBlock = null;
            }
        }

        /// <summary>
        /// Ejecuci�n de la funci�n de Vision Pro de forma s�ncrona
        /// </summary>
        /// <returns></returns>
        protected override bool EjecucionSincrona()
        {
            bool resultado = false;
            resultado = base.EjecucionSincrona();

            try
            {
                // Run the toolblock
                this.ToolBlock.Run();
                this.FuncionEjecutada();
                resultado = true;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosFunciones.VisionPro, this.Codigo, exception);
            }

            return resultado;
        }

        /// <summary>
        /// Ejecuci�n de la funci�n de Vision Pro de forma as�ncrona
        /// </summary>
        /// <returns></returns>
        protected override bool EjecucionAsincrona()
        {
            bool resultado = false;
            resultado = base.EjecucionAsincrona();

            try
            {
                // Ejecutamos el thread
                this.ThreadEjecucion.RunWorkerAsync();
                resultado = true;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosFunciones.VisionPro, this.Codigo, exception);
            }

            return resultado;
        }

        /// <summary>
        /// Funci�n para la actualizaci�n de par�metros de entrada
        /// </summary>
        /// <param name="ParamName">Nombre identificador del par�metro</param>
        /// <param name="ParamValue">Nuevo valor del par�metro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public override bool SetEntrada(string codigo, object valor, OEnumTipoDato tipoVariable)
        {
            bool functionReturnValue = false;
            try
            {
                if (this.ToolBlock.Inputs[codigo].ValueType == valor.GetType())
                {
                    this.ToolBlock.Inputs[codigo].Value = valor;
                    functionReturnValue = true;
                }
                else
                {
                    if (tipoVariable == OEnumTipoDato.Imagen)
                    {
                        if (valor is OImagenVisionPro)
                        {
                            OImagenVisionPro visionProImage = (OImagenVisionPro)valor;
                            this.ToolBlock.Inputs[codigo].Value = visionProImage.Image;
                            functionReturnValue = true;
                        }
                        else
                        {
                            OImage orbitaImage = (OImage)valor;
                            OImagenVisionPro visionProImage;
                            if (orbitaImage.Convert<OImagenVisionPro>(out visionProImage))
                            {
                                this.ToolBlock.Inputs[codigo].Value = visionProImage.Image;
                                functionReturnValue = true;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Error en la asignaci�n del par�metro '" + codigo + "' a la funci�n '" + this.Codigo + "'. No coinciden los tipos.");
                    }
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosFunciones.VisionPro, this.Codigo, exception);
            }
            return functionReturnValue;
        }

        /// <summary>
        /// Funci�n para la consulta de par�metros de salida
        /// </summary>
        /// <param name="ParamName">Nombre identificador del par�metro</param>
        /// <param name="ParamValue">Nuevo valor del par�metro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public override bool GetSalida(string codigo, out object valor, OEnumTipoDato tipoVariable)
        {
            valor = null;
            bool functionReturnValue = false;
            try
            {
                object objValor = this.ToolBlock.Outputs[codigo].Value;

                switch (tipoVariable)
                {
                    case OEnumTipoDato.Imagen:
                        {
                            OImagenVisionPro visionProImage = new OImagenVisionPro(objValor);
                            valor = visionProImage;
                            break;
                        }
                    case OEnumTipoDato.Grafico:
                        {
                            OVisionProGrafico visionProGrafico = new OVisionProGrafico(objValor);
                            valor = visionProGrafico;
                            break;
                        }
                    default:
                        {
                            valor = objValor;
                            break;
                        }
                }

                functionReturnValue = true;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosFunciones.VisionPro, this.Codigo, exception);
            }
            return functionReturnValue;
        }

        #endregion
    }
}
