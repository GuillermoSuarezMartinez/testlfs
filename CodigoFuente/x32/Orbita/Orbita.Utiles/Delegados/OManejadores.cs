//***********************************************************************
// Assembly         : Orbita.Utiles
// Author           : crodriguez
// Created          : 03-03-2011
//
// Last Modified By : aibañez
// Last Modified On : 18/04/2013
// Description      : Añadido un manejador de evento genérico
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Utiles
{
    /// <summary>
    /// Delegado asociado al evento.
    /// </summary>
    /// <param name="sender">Objeto que lanza el evento.</param>
    /// <param name="e">Dato que puede ser usado en el manejador de evento.</param>
    public delegate void ManejadorEvento(object sender, OEventArgs e);

    /// <summary>
    /// Delegado asociado al evento.
    /// </summary>
    /// <param name="sender">Objeto que lanza el evento.</param>
    /// <param name="e">Dato que puede ser usado en el manejador de evento.</param>
    public delegate void ManejadorEvento<T>(object sender, T e)
       where T: OEventArgs;
}