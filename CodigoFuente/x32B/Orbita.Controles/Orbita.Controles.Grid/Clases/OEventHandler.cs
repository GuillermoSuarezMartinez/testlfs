//***********************************************************************
// Assembly         : Orbita.Controles.Grid
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Grid
{
    public class OEventHandler
    {
        #region Atributos privados
        string evento;
        System.Delegate delegado;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEventHandler.
        /// </summary>
        public OEventHandler() { }
        public OEventHandler(string evento, System.Delegate delegado) 
        {
            this.evento = evento;
            this.delegado = delegado;
        }
        #endregion

        #region Propiedades
        public string Evento
        {
            get { return this.evento; }
            set { this.evento = value; }
        }
        public System.Delegate Delegado
        {
            get { return this.delegado; }
            set { this.delegado = value; }
        }
        #endregion
    }
}