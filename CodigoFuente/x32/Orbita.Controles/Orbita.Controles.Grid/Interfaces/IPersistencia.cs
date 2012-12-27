//***********************************************************************
// Assembly         : Orbita.Controles
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
    /// <summary>
    /// Orbita.Controles.IPersistencia.
    /// </summary>
    public interface IPersistencia
    {
        /// <summary>
        /// SetPlantilla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="publico"></param>
        /// <returns></returns>
        int SetPlantilla(object sender, string nombre, string descripcion, bool publico);
        /// <summary>
        /// SetPlantilla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        int SetPlantilla(object sender, object clave);
        /// <summary>
        /// SetPlantilla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="nombre"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        void SetPlantilla(object sender, string nombre, bool activo);
        /// <summary>
        /// GetPlantilla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="plantilla"></param>
        void GetPlantilla(object sender, OPlantilla plantilla);
        /// <summary>
        /// GetPlantilla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void GetPlantilla(object sender, string args);
        /// <summary>
        /// GetPlantillas.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        System.Collections.Generic.Dictionary<string, OPlantilla> GetPlantillas(object sender);
        /// <summary>
        /// GetPlantillas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="publico"></param>
        /// <returns></returns>
        System.Collections.Generic.Dictionary<string, OPlantilla> GetPlantillas(object sender, bool publico);
    }
}
