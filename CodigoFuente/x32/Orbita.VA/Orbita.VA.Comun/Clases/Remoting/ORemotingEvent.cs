//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 18-04-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.Utiles;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase encargada de lanzar el evento remoto
    /// </summary>
    public class ORemotingEvent<T>
        where T: EventArgs
    {
        #region Atributo(s)
        /// <summary>
        /// Cola Consumidora
        /// </summary>
        private OProductorConsumidorThread<T> Consumidor;

        private EventHandler<T> ManejadorEvento;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Número de elementos en la cola
        /// </summary>
        public int Count
        {
            get
            {
                return this.Consumidor.Count;
            }
        }

        /// <summary>
        /// Indica que la cola está llena y no puede ser insertado ningun elemento más
        /// </summary>
        public bool Lleno
        {
            get
            {
                return this.Consumidor.Lleno;
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ORemotingEvent(string codigo, int capacidadMaxima, EventHandler<T> manejadorEvento)
        {
            this.Consumidor = new OProductorConsumidorThread<T>(codigo, 1, 1, System.Threading.ThreadPriority.Normal, capacidadMaxima, true);
            this.Consumidor.CrearSuscripcionConsumidor(this.ConsumidorRun, true);
            this.ManejadorEvento = manejadorEvento;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Añade el valor a encolar
        /// </summary>
        /// <param name="valor"></param>
        public bool LanzarEvento(T valor)
        {
            return this.Consumidor.Encolar(valor, 0);
        }

        /// <summary>
        /// Inicio del thread
        /// </summary>
        public void Start()
        {
            this.Consumidor.StartPaused();
        }

        /// <summary>
        /// Fin del thread
        /// </summary>
        public void Stop()
        {
            this.Consumidor.Stop();
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Ejecución del consumidor
        /// </summary>
        private void ConsumidorRun(T valor)
        {
            if (this.ManejadorEvento != null)
            {
                this.ManejadorEvento(null, valor);
            }
        }
        #endregion
    }
}
