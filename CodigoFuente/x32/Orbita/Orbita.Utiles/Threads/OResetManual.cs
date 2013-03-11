//***********************************************************************
// Assembly         : OrbitaUtiles
// Author           : crodriguez
// Created          : 03-03-2011
//
// Last Modified By : crodriguez
// Last Modified On : 03-03-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Threading;
namespace Orbita.Utiles
{
    /// <summary>
    /// Notifica que se ha producido un evento a uno o varios subprocesos en espera.
    /// </summary>
    public class OResetManual
    {
        #region Atributo(s)
        /// <summary>
        /// Atributo que marca la sincronizaci�n.
        /// </summary>
        readonly ManualResetEvent[] _eventoResetManual;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Inicializar una nueva instancia de la clase OResetManual.
        /// </summary>
        public OResetManual()
            : this(1) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OResetManual.
        /// </summary>
        /// <param name="contador">N�mero de eventos ManualResetEvent
        /// que van a ser creados.</param>
        public OResetManual(short contador)
        {
            this._eventoResetManual = new ManualResetEvent[contador];

            // Inicializar contador de eventos.
            Inicializar(contador);
        }
        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// M�todo que devuelve la colecci�n.
        /// </summary>
        public ManualResetEvent[] GetEvento()
        {
            return this._eventoResetManual;
        }
        /// <summary>
        /// Dormir el hilo.
        /// </summary>
        public void Dormir()
        {
            Dormir(0);
        }
        /// <summary>
        /// Dormir el hilo el tiempo establecido en segundos.
        /// Dicho hilo se va a despertar, o bien, por 
        /// trascurrido Tiempo, o por la pulsaci�n del
        /// bot�n Parar (Set).
        /// </summary>
        /// <param name="tiempo">Tiempo en TimeSpan.</param>
        /// <returns></returns>
        public bool Dormir(TimeSpan tiempo)
        {
            return Dormir(0, tiempo);
        }
        /// <summary>
        /// Dormir el hilo.
        /// </summary>
        /// <param name="indice">Indice de reset.</param>
        public void Dormir(short indice)
        {
            this._eventoResetManual[indice].WaitOne();
        }
        /// <summary>
        /// Dormir el hilo el tiempo establecido en segundos.
        /// Dicho hilo se va a despertar, o bien, por 
        /// trascurrido Tiempo, o por la pulsaci�n del
        /// bot�n Parar (Set).
        /// </summary>
        /// <param name="indice">Indice de reset.</param>
        /// <param name="tiempo">Tiempo en segundos.</param>
        /// <returns></returns>
        public bool Dormir(short indice, short tiempo)
        {
            return this._eventoResetManual[indice].WaitOne(tiempo, false);
        }
        /// <summary>
        /// Dormir el hilo el tiempo establecido en segundos.
        /// Dicho hilo se va a despertar, o bien, por 
        /// trascurrido Tiempo, o por la pulsaci�n del
        /// bot�n Parar (Set).
        /// </summary>
        /// <param name="indice">Indice de reset.</param>
        /// <param name="tiempo">Tiempo en TimeSpan.</param>
        /// <returns></returns>
        public bool Dormir(short indice, TimeSpan tiempo)
        {
            return this._eventoResetManual[indice].WaitOne(tiempo, false);
        }
        /// <summary>
        /// Indicar al escritor que escribimos en la cola
        /// de resultados para que salga de su letargo.
        /// </summary>
        public void Despertar()
        {
            Despertar(0);
        }
        /// <summary>
        /// Indicar al escritor que escribimos en la cola
        /// de resultados para que salga de su letargo.
        /// </summary>
        /// <param name="indice">Indice de reset.</param>
        public void Despertar(short indice)
        {
            this._eventoResetManual[indice].Set();
        }
        /// <summary>
        /// Reset para la siguiente vez que se mande un Set.
        /// Es necesario invocarlo por haber utilizado 
        /// ManualResetEvent.
        /// </summary>
        public void Resetear()
        {
            Resetear(0);
        }
        /// <summary>
        /// Reset para la siguiente vez que se mande un Set.
        /// Es necesario invocarlo por haber utilizado 
        /// ManualResetEvent.
        /// </summary>
        /// <param name="indice">Indice de reset.</param>
        public void Resetear(short indice)
        {
            this._eventoResetManual[indice].Reset();
        }
        #endregion

        #region M�todo(s) privado(s)
        /// <summary>
        /// Inicializar el array de ManualResetEvent
        /// en funci�n del contador de eventos.
        /// </summary>
        /// <param name="contador">Contador de eventos.</param>
        void Inicializar(short contador)
        {
            for (int i = 0; i < contador; i++)
            {
                this._eventoResetManual[i] = new ManualResetEvent(false);
            }
        }
        #endregion
    }
}