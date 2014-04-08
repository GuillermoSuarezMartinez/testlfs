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
    public interface IPersistencia
    {
        int SetPlantilla(object sender, string nombre, string descripcion, bool publico);
        int SetPlantilla(object sender, object clave);
        void SetPlantilla(object sender, string nombre, bool activo);
        void GetPlantilla(object sender, OPlantilla plantilla);
        void GetPlantilla(object sender, string args);
        System.Collections.Generic.Dictionary<string, OPlantilla> GetPlantillas(object sender);
        System.Collections.Generic.Dictionary<string, OPlantilla> GetPlantillas(object sender, bool publico);
    }
}