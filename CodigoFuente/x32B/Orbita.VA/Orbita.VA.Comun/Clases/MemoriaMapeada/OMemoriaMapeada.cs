//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : sizquierdo/aibañez
// Created          : 26-03-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//                    
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;
using System.Collections.Generic;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Gestiona las regiones mapeadas de memoria
    /// </summary>
    public class OMemoriaMapeada
    {
        #region Atributos
        /// <summary>
        /// Objeto bloqueante de la lectura
        /// </summary>
        private Dictionary<string, object> ConcurrenteLectura = new Dictionary<string, object>();
        /// <summary>
        /// Objeto bloqueante de la escritura
        /// </summary>
        private Dictionary<string, object> ConcurrenteEscritura = new Dictionary<string, object>();
        /// <summary>
        /// Indica se se ha de liberar memoria al destuirse
        /// </summary>
        private bool LiberarAlFinalizar = false;
        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// Lista de regiones
        /// </summary>
        private Dictionary<string, MemoryMappedFile> _Buffers = new Dictionary<string, MemoryMappedFile>();
        /// <summary>
        /// Lista de regiones
        /// </summary>
        public Dictionary<string, MemoryMappedFile> Buffers
        {
            get { return _Buffers; }
            set { _Buffers = value; }
        }
        #endregion Propiedades

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="liberarAlFinalizar"></param>
        public OMemoriaMapeada(bool liberarAlFinalizar = false)
        {
            LiberarAlFinalizar = liberarAlFinalizar;
        }
        /// <summary>
        /// Destructor de la clase
        /// </summary>
        ~OMemoriaMapeada()
        {
            if (LiberarAlFinalizar)
            {
                foreach (MemoryMappedFile memoria in Buffers.Values)
                {
                   // memoria.Dispose();
                }
            }
        }
        #endregion Constructor

        #region Métodos publicos
        /// <summary>
        /// Verifica si existe una región registrada con el identificador asociado
        /// </summary>
        /// <param name="codigoBuffer"></param>
        /// <returns></returns>
        public bool Existe(string codigoBuffer)
        {
            return Buffers.ContainsKey(codigoBuffer);
        }
        /// <summary>
        /// Inicializa una región de memoria.
        /// </summary>
        /// <param name="codigoBuffer"></param>
        /// <param name="tamaño"></param>
        /// <returns></returns>
        public bool CrearEscritura(string codigoBuffer, long tamaño = 10000, bool sobreescribir = false)
        {
            try
            {
                if (this.Existe(codigoBuffer))
                {
                    if (sobreescribir)
                    {
                        this.Eliminar(codigoBuffer);
                    }
                    else
                    {
                        throw new Exception("Región ya inicializada.");
                    }
                }

                MemoryMappedFile fmemoria = MemoryMappedFile.CreateOrOpen(codigoBuffer, tamaño, MemoryMappedFileAccess.ReadWrite);
                MemoryMappedFileSecurity mseg = new MemoryMappedFileSecurity();
                mseg.AddAccessRule(new System.Security.AccessControl.AccessRule<MemoryMappedFileRights>("Todos", MemoryMappedFileRights.FullControl, System.Security.AccessControl.AccessControlType.Allow));
                fmemoria.SetAccessControl(mseg);

                this.Buffers.Add(codigoBuffer, fmemoria);
                this.ConcurrenteEscritura.Add(codigoBuffer, new object());

                return true;
            }
            catch (Exception exception)
            {
                OLogsVAComun.RegionMemoriaMapeada.Error(exception, "CrearEscritura");
                return false;
            }
        }
        /// <summary>
        /// Inicializa una región de memoria.
        /// </summary>
        /// <param name="codigoBuffer"></param>
        /// <param name="tamaño"></param>
        /// <returns></returns>
        public void CrearLectura(string codigoBuffer)
        {
            try
            {
                this.ConcurrenteLectura.Add(codigoBuffer, new object());
            }
            catch (Exception exception)
            {
                OLogsVAComun.RegionMemoriaMapeada.Error(exception, "CrearLectura");
            }
        }
        /// <summary>
        /// Lectura de determinada región de memoria
        /// </summary>
        /// <param name="codigoBuffer"></param>
        /// <param name="offset"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public bool Leer(string codigoBuffer, out byte[] datos)
        {
            datos = null;
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(codigoBuffer))
                {
                    using (var stream = mmf.CreateViewStream())
                    {
                        using (BinaryReader binReader = new BinaryReader(stream))
                        {
                            datos = binReader.ReadBytes((int)stream.Length);
                        }
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                OLogsVAComun.RegionMemoriaMapeada.Error(exception, "Leer");
                return false;
            }
        }
        /// <summary>
        /// Escritura de determinada región de memoria
        /// </summary>
        /// <param name="codigoBuffer"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Escribir(string codigoBuffer, byte[] datos)
        {
            try
            {
                if (!this.Existe(codigoBuffer))
                {
                    this.CrearEscritura(codigoBuffer, datos.LongLength + 1);
                }
                MemoryMappedFile fmemoria = Buffers[codigoBuffer];
                lock (this.ConcurrenteEscritura[codigoBuffer])
                {
                    using (MemoryMappedViewStream stream = fmemoria.CreateViewStream(0, datos.Length))
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(datos);
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                OLogsVAComun.RegionMemoriaMapeada.Error(exception, "Escribir");
                return false;
            }
        }
        /// <summary>
        /// Acción de eliminar región de memoria
        /// </summary>
        /// <param name="codigoBuffer"></param>
        /// <returns></returns>
        public bool Eliminar(string codigoBuffer)
        {
            try
            {
                if (!Existe(codigoBuffer))
                {
                    return false;
                }
                Buffers[codigoBuffer].Dispose();
                try
                {
                    Buffers.Remove(codigoBuffer);
                }
                catch (Exception exception)
                {
                    OLogsVAComun.RegionMemoriaMapeada.Error(exception, "EliminarRegionMemoria");
                }

                return true;
            }
            catch (Exception exception)
            {
                OLogsVAComun.RegionMemoriaMapeada.Error(exception, "EliminarRegionMemoria");
                return false;
            }
        }
        #endregion Métodos públicos
    }
}



