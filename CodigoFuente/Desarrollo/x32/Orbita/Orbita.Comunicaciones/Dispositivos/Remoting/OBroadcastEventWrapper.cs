﻿using System;
using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Elemento para la generación de eventos por remoting
    /// </summary>
    [Serializable]
    public class OBroadcastEventWrapper : MarshalByRefObject
    {
        #region Eventos
        /// <summary>
        /// Evento de cambio de dato.
        /// </summary>
        public event OManejadorEventoComm OrbitaCambioDato;
        /// <summary>
        /// Evento de alarma.
        /// </summary>
        public event OManejadorEventoComm OrbitaAlarma;
        /// <summary>
        /// Evento de comunicaciones.
        /// </summary>
        public event OManejadorEventoComm OrbitaComm;
        #endregion Eventos

        #region Métodos públicos
        /// <summary>
        /// Evento de cambio de dato.
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        public void OnCambioDato(OEventArgs e)
        {
            if (OrbitaCambioDato != null)
            {
                OrbitaCambioDato(e);
            }
        }
        /// <summary>
        /// Evento de alarma.
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        public void OnAlarma(OEventArgs e)
        {
            if (OrbitaAlarma != null)
            {
                OrbitaAlarma(e);
            }
        }
        /// <summary>
        /// Evento de comunicaciones.
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        public void OnComm(OEventArgs e)
        {
            if (OrbitaComm != null)
            {
                OrbitaComm(e);
            }
        }
        #endregion Métodos públicos
    }
}