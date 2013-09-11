//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Esta clase proporciona la funcionalidad básica para el cliente conectado al listener.
    /// </summary>
    public interface IOcsClienteConectable
    {
        /// <summary>
        /// Iniciar los mensajeros.
        /// </summary>
        void Iniciar();
        /// <summary>
        /// Terminar los mensajeros.
        /// </summary>
        void Terminar();
    }
}