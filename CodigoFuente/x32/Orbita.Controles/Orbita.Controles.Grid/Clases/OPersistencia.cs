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
    /// <summary>
    /// Clase necesaria para establecer la persistencia entre el control OrbitaGridPro y las aplicaciones que usen el control.
    /// </summary>
    public abstract class OPersistencia : IPersistencia
    {
        /// <summary>
        /// Método abstracto que permite eliminar las plantillas seleccionadas.
        /// </summary>
        /// <param name="identificador"></param>
        /// <returns></returns>
        public abstract int SetPlantilla(int identificador);
        /// <summary>
        /// Método abstracto que permite almacener el estado actual del control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="publico"></param>
        /// <returns></returns>
        public abstract int SetPlantilla(object sender, string nombre, string descripcion, bool publico);
        /// <summary>
        /// Actualizar el estado de plantilla activa/inactiva.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        public abstract int SetPlantilla(object sender, object clave);
        /// <summary>
        /// Actualizar el estado de plantilla activa/inactiva.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="nombre"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public abstract void SetPlantilla(object sender, string nombre, bool activo);
        /// <summary>
        /// GetPlantilla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="plantilla"></param>
        public abstract void GetPlantilla(object sender, OPlantilla plantilla);
        /// <summary>
        /// Método abstracto que permite cargar la plantilla activa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public abstract void GetPlantilla(object sender, string args);
        /// <summary>
        /// GetPlantillas.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public abstract System.Collections.Generic.Dictionary<string, OPlantilla> GetPlantillas(object sender);
        /// <summary>
        /// Método abstracto que permite cargar todas las plantillas almacenadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="publico"></param>
        /// <returns></returns>
        public abstract System.Collections.Generic.Dictionary<string, OPlantilla> GetPlantillas(object sender, bool publico);
    }
}