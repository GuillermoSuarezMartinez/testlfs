//***********************************************************************
// Assembly         : Orbita.Utiles
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
namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Clase que representa eventos con argumentos
    /// adicionales tipados (EventArgs).
    /// </summary>
    [Serializable]
    public class OEventArgsComs : EventArgs
    {
        #region Atributos
        /// <summary>
        /// Identificador del dispositivo
        /// </summary>
        int _idDisp;
        /// <summary>
        /// Identificador del mensaje
        /// </summary>
        int _idMensaje;
        /// <summary>
        /// Variables del dispositivo
        /// </summary>
        object _variables;
        /// <summary>
        /// Valores de las variables
        /// </summary>
        object _valores;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OEventArgs.
        /// </summary>
        public OEventArgsComs() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OEventArgs.
        /// </summary>
        /// <param name="arg">Argumento adicional.</param>
        public OEventArgsComs(int idMensaje)
        {
            this._idMensaje = idMensaje;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Valores de las variables
        /// </summary>
        public object Valores
        {
            get { return this._valores; }
            set { this._valores = value; }
        }
        /// <summary>
        /// Variables del dispositivo
        /// </summary>
        public object Variables
        {
            get { return this._variables; }
            set { this._variables = value; }
        }
        /// <summary>
        /// Identificador del mensaje
        /// </summary>
        public int Id
        {
            get { return _idMensaje; }
            set { this._idMensaje = value; }
        }
        /// <summary>
        /// Identificador del mensaje
        /// </summary>
        public int IdDispositivo
        {
            get { return _idDisp; }
            set { this._idDisp = value; }
        }
        #endregion
    }
}
