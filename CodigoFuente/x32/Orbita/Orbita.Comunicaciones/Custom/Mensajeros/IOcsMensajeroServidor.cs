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
    /// Representa un objeto que puede enviar y recibir mensajes.
    /// </summary>
    public interface IOcsMensajeroServidor
    {
        void CambioDato(OInfoDato infoDato);
        void Alarma(OInfoDato infoDato);
        void Comunicaciones(OEstadoComms estadoComm);
    }
}