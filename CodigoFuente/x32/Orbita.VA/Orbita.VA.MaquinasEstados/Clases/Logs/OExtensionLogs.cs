//***********************************************************************
// Assembly         : Orbita.VA.MaquinasEstados
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using Orbita.VA.Comun;

namespace Orbita.VA.MaquinasEstados
{
    /// <summary>
    /// Define el conjunto de módulos del sistema
    /// </summary>
    public class OModulosControl: ModulosSistema
    {
        #region Atributo(s)
        /// <summary>
        /// Módulo de las máquinas de estado
        /// </summary>
        public static EnumModulosSistema MaquinasEstado = new EnumModulosSistema("MaquinasEstado", "Módulo de funcionamiento de las máquinas de estado", 101);
        /// <summary>
        /// Módulo de las máquinas de estado
        /// </summary>
        public static EnumModulosSistema MonitorizacionMaquinasEstado = new EnumModulosSistema("MonitorizacionMaquinasEstado", "Módulo de monitorización de las máquinas de estado", 102);
        /// <summary>
        /// Módulo de edición y gestión de las máquinas de estado
        /// </summary>
        public static EnumModulosSistema GestionMaquinasEstado = new EnumModulosSistema("GestionMaquinasEstado", "Módulo de gestión de las máquinas de estado", 103);
        #endregion
    }
}
