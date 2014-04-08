//***********************************************************************
// Assembly         : Orbita.Trazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-22-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Contiene datos de eventos relativos a escritura en remoting.
    /// </summary>
    public class RemotingEventArgs : System.EventArgs
    {
        #region Atributos privados
        /// <summary>
        /// El elemento que va a ser registrado.
        /// </summary>
        private readonly ItemLog _item;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingEventArgs.
        /// </summary>
        public RemotingEventArgs() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.RemotingEventArgs.
        /// </summary>
        /// <param name="item">El elemento que va a ser registrado.</param>
        public RemotingEventArgs(ItemLog item)
            : this()
        {
            _item = item;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// El elemento que va a ser registrado.
        /// </summary>
        public ItemLog ItemLog
        {
            get { return _item; }
        }
        #endregion
    }
}