//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : 12-12-2012
// Last Modified On : aibañez
// Description      : Cambiado el trabajo con el thread
//
// Last Modified By : 15-11-2012 
// Last Modified On : aibañez
// Description      : Añadidas instrucciones en la finalización del thread
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading;
using System.Drawing.Imaging;
using Orbita.Utiles;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase que guarda imagenes en un thread separado
    /// </summary>
    public static class OAlmacenImagenesManager
    {
        #region Atributo(s)
        /// <summary>
        ///  Clase que guarda imagenes en un thread separado
        /// </summary>
        private static AlmacenImagenes AlmacenObjetosVisuales;
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Construye los objetos
        /// </summary>
        public static void Constructor()
        {
            AlmacenObjetosVisuales = new AlmacenImagenes();
        }

        /// <summary>
        /// Destruye los campos de la clase
        /// </summary>
        public static void Destructor()
        {
            AlmacenObjetosVisuales.Dispose();
            AlmacenObjetosVisuales = null;
        }

        /// <summary>
        /// Se cargan los valores de la clase
        /// </summary>
        public static void Inicializar()
        {
            AlmacenObjetosVisuales.Inicializar();
        }

        /// <summary>
        /// Se realizan las acciones de finalización
        /// </summary>
        public static void Finalizar()
        {
            AlmacenObjetosVisuales.Finalizar();
        }

        /// <summary>
        /// Método que añade una determinada imagen a la cola de imagenes a ser guardadas
        /// </summary>
        /// <param name="ruta">Ruta donde se ha de guardar la imagen</param>
        /// <param name="imagen">Imagen a guardar</param>
        public static void GuardarImagen(string ruta, OImagen imagen)
        {
            AlmacenObjetosVisuales.GuardarImagen(ruta, imagen);
        }

        /// <summary>
        /// Método que añade un determinado gráfico a la cola de graficos a ser guardados
        /// </summary>
        /// <param name="ruta">Ruta donde se ha de guardar el gráfico</param>
        /// <param name="grafico">Grafico a guardar</param>
        public static void GuardarGrafico(string ruta, OGrafico grafico)
        {
            AlmacenObjetosVisuales.GuardarGrafico(ruta, grafico);
        }
        #endregion
    }

    /// <summary>
    /// Clase que guarda imagenes en un thread separado
    /// </summary>
    internal class AlmacenImagenes : IDisposable
    {
        #region Constante(s)
        /// <summary>
        /// Capacidad máxima de la cola
        /// </summary>
        private const int MaxCapacidadCola = 50;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Campo donde se guarda la cola de imágenes a guardar
        /// </summary>
        private Queue<OTriplet<string, OImagen, ImageFormat>> ColaImagenes;

        /// <summary>
        /// Campo donde se guarda la cola de gráficos a guardar
        /// </summary>
        private Queue<KeyValuePair<string, OGrafico>> ColaGraficos;

        /// <summary>
        /// Thread donde se ejecutará el guardado de imágenes o gráficos
        /// </summary>
        private OThreadLoop Thread;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public AlmacenImagenes()
        {
            this.ColaImagenes = new Queue<OTriplet<string, OImagen, ImageFormat>>();
            this.ColaGraficos = new Queue<KeyValuePair<string, OGrafico>>();
            this.Thread = new OThreadLoop("AlmacenObjetosVisuales", 50, ThreadPriority.Lowest);
            //this.Thread.OnEjecucion = Ejecutar;
            this.Thread.CrearSuscripcionRun(Ejecutar, true);
        }
        #endregion

        #region Método(s) privado(s)
        private void Ejecutar(ref bool finalize)
        {
            try
            {
                if (this.ColaImagenes.Count > 0)
                {
                    OTriplet<string, OImagen, ImageFormat> trio = new OTriplet<string, OImagen, ImageFormat>();

                    lock (this.ColaImagenes)
                    {
                        trio = this.ColaImagenes.Dequeue();
                    }
                    string ruta = trio.First;
                    OImagen imagen = trio.Second;
                    ImageFormat formato = trio.Third;

                    imagen.Guardar(ruta, formato);
                    OLogsVAComun.AlmacenInformacion.Info("Thread Guardado", "Se procede a guardar la imagen (" + this.ColaImagenes.Count.ToString() + " elementos en la cola)");
                }

                if (this.ColaGraficos.Count > 0)
                {
                    KeyValuePair<string, OGrafico> pareja = new KeyValuePair<string, OGrafico>();

                    lock (this.ColaGraficos)
                    {
                        pareja = this.ColaGraficos.Dequeue();
                    }

                    OGrafico grafico = pareja.Value;
                    string ruta = pareja.Key;

                    grafico.Guardar(ruta);
                    OLogsVAComun.AlmacenInformacion.Info("Thread Guardado", "Se procede a guardar el gráfico (" + this.ColaGraficos.Count.ToString() + " elementos en la cola)");
                }

                if ((this.ColaImagenes.Count > 10) || (this.ColaGraficos.Count > 10))
                {
                    this.Thread.ChangePriority(ThreadPriority.Normal);
                }
                else
                {
                    this.Thread.ChangePriority(ThreadPriority.Lowest);
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.AlmacenInformacion.Error(exception, "Almacen");
            }

            finalize = false;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Inicialización de la clase
        /// </summary>
        public void Inicializar()
        {
            this.Thread.Start();
        }

        /// <summary>
        /// Finalización de la clase
        /// </summary>
        public void Finalizar()
        {
            this.Thread.Dispose(500);
            this.Thread = null;
        }

        /// <summary>
        /// Elimina la memoria asignada por el objeto.
        /// </summary>
        public void Dispose()
        {
            if (this.Thread != null)
            {
                this.Thread.Dispose();
                this.Thread = null;
            }
        }

        /// <summary>
        /// Método que añade una determinada imagen a la cola de imagenes a ser guardadas
        /// </summary>
        /// <param name="ruta">Ruta donde se ha de guardar la imagen</param>
        /// <param name="imagen">Imagen a guardar</param>
        public void GuardarImagen(string ruta, OImagen imagen, ImageFormat formato = null)
        {
            // Se clona la imagen
            OImagen imagenClonada = (OImagen)imagen.Clone();

            // Se crea la pareja de ruta + imagen
            OTriplet<string, OImagen, ImageFormat> trio = new OTriplet<string, OImagen, ImageFormat>(ruta, imagenClonada, formato);

            // Se añade a la cola de imagenes a guardar
            lock (this.ColaImagenes)
            {
                if (this.ColaImagenes.Count < MaxCapacidadCola) // Si hay más de 50 no añadimos el elemento a guardar
                {
                    this.ColaImagenes.Enqueue(trio);
                    OLogsVAComun.AlmacenInformacion.Info("Guardado", "Se apila la imagen en la cola de guardado (" + this.ColaImagenes.Count.ToString() + " elementos en la cola)");
                }
                else
                {
                    OLogsVAComun.AlmacenInformacion.Warn("Guardado", "Capacidad de la cola de guardado de imágenes sobrepasada (" + this.ColaImagenes.Count.ToString() + " elementos en la cola)");
                }
            }
        }

        /// <summary>
        /// Método que añade un determinado gráfico a la cola de graficos a ser guardados
        /// </summary>
        /// <param name="ruta">Ruta donde se ha de guardar el gráfico</param>
        /// <param name="grafico">Grafico a guardar</param>
        public void GuardarGrafico(string ruta, OGrafico grafico)
        {
            // Se clona el gráfico
            OGrafico graficoClonado = (OGrafico)grafico.Clone();

            // Se crea la pareja de ruta + gráfico
            KeyValuePair<string, OGrafico> pareja = new KeyValuePair<string, OGrafico>(ruta, graficoClonado);

            // Se añade a la cola de gráficos a guardar
            lock (this.ColaGraficos)
            {
                if (this.ColaGraficos.Count < MaxCapacidadCola) // Si hay más de 50 no añadimos el elemento a guardar
                {
                    this.ColaGraficos.Enqueue(pareja);
                    OLogsVAComun.AlmacenInformacion.Info("Guardado", "Se apila el gráfico en la cola de guardado (" + this.ColaGraficos.Count.ToString() + " elementos en la cola)");
                }
                else
                {
                    OLogsVAComun.AlmacenInformacion.Warn("Guardado", "Capacidad de la cola de guardado de gráficos sobrepasada (" + this.ColaImagenes.Count.ToString() + " elementos en la cola)");
                }
            }
        }
        #endregion
    }
}
