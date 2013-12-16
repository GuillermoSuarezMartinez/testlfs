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
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Orbita.Trazabilidad;
namespace Orbita.BBDD.Trazabilidad
{
    /// <summary>
    /// Traza base.
    /// </summary>
    public abstract class BaseTraza : ITraza
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.BaseTraza.
        /// </summary>
        /// <param name="identificador">Identificador de traza.</param>
        protected BaseTraza(string identificador)
        {
            this.Identificador = identificador;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Identificador de traza.
        /// </summary>
        public string Identificador { get; private set; }
        #endregion

        #region M�todos p�blicos

        #region Add
        /// <summary>
        /// M�todo add traza.
        /// </summary>
        /// <param name="procedimiento">Procedimiento almacenado.</param>
        /// <returns>Resultado del procedimiento almacenado.</returns>
        public int Add(string procedimiento)
        {
            return Log(NivelTraza.Add, procedimiento);
        }
        /// <summary>
        /// M�todo add traza.
        /// </summary>
        /// <param name="procedimiento">Procedimiento almacenado.</param>
        /// <param name="args">Argumentos de entrada del procedimiento almacenado.</param>
        /// <returns>Resultado del procedimiento almacenado.</returns>
        public int Add(string procedimiento, ArrayList args)
        {
            return Log(NivelTraza.Add, procedimiento, args);
        }
        #endregion

        #region Del
        /// <summary>
        /// M�todo delete traza.
        /// </summary>
        /// <param name="procedimiento">Procedimiento almacenado.</param>
        /// <returns>Resultado del procedimiento almacenado.</returns>
        public int Del(string procedimiento)
        {
            return Log(NivelTraza.Del, procedimiento);
        }
        /// <summary>
        /// M�todo delete traza.
        /// </summary>
        /// <param name="procedimiento">Procedimiento almacenado.</param>
        /// <param name="args">Argumentos de entrada del procedimiento almacenado.</param>
        /// <returns>Resultado del procedimiento almacenado.</returns>
        public int Del(string procedimiento, ArrayList args)
        {
            return Log(NivelTraza.Del, procedimiento, args);
        }
        #endregion

        #region Mdf
        /// <summary>
        /// M�todo modificar traza.
        /// </summary>
        /// <param name="procedimiento">Procedimiento almacenado.</param>
        /// <returns>Resultado del procedimiento almacenado.</returns>
        public int Mdf(string procedimiento)
        {
            return Log(NivelTraza.Mdf, procedimiento);
        }
        /// <summary>
        /// M�todo modificar traza.
        /// </summary>
        /// <param name="procedimiento">Procedimiento almacenado.</param>
        /// <param name="args">Argumentos de entrada del procedimiento almacenado.</param>
        /// <returns>Resultado del procedimiento almacenado.</returns>
        public int Mdf(string procedimiento, ArrayList args)
        {
            return Log(NivelTraza.Mdf, procedimiento, args);
        }
        #endregion

        #region Log
        /// <summary>
        /// Crea una entrada de registro nuevo basado en un elemento de inicio de sesi�n dado.
        /// </summary>
        /// <param name="item">Encapsula la informaci�n de registro.</param>
        public abstract int Log(ItemTraza item);
        /// <summary>
        /// Crea una entrada de registro nuevo basado en un elemento de inicio de sesi�n dado.
        /// </summary>
        /// <param name="nivel">Nvel de traza.</param>
        /// <param name="procedimiento">Procedimiento almacenado.</param>
        /// <returns>Resultado de ejecuci�n del procedimiento almacenado.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope")]
        public virtual int Log(NivelTraza nivel, string procedimiento)
        {
            ItemTraza item = new ItemTraza(nivel, procedimiento);
            return Log(item);
        }
        /// <summary>
        /// Crea una entrada de registro nuevo basado en un elemento de inicio de sesi�n dado.
        /// </summary>
        /// <param name="nivel">Nivel de traza.</param>
        /// <param name="procedimiento">Procedimiento almacenado.</param>
        /// <param name="args">Argumentos del procedimiento almacenado.</param>
        /// <returns>Resultado de ejecuci�n del procedimiento almacenado.</returns>
        [SuppressMessage("Microsoft.Reliability","CA2000:DisposeObjectsBeforeLosingScope")]
        public virtual int Log(NivelTraza nivel, string procedimiento, ArrayList args)
        {
            ItemTraza item = new ItemTraza(nivel, procedimiento, args);
            return Log(item);
        }
        #endregion

        #endregion
    }
}