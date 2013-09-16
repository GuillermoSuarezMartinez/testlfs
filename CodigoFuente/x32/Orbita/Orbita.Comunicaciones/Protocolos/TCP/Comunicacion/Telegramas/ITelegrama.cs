//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System.Collections.Generic;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas
{
    /// <summary>
    /// Representa un protocolo de comunicación a nivel de bytes entre aplicaciones.
    /// </summary>
    public interface ITelegrama
    {
        /// <summary>
        /// Serializa un mensaje a una matriz de bytes para enviar a la aplicación remota.
        /// Este método está sincronizado. Por lo tanto, sólo un hilo lo puede llamar al mismo tiempo.
        /// </summary>
        /// <param name="mensaje">Mensaje que será serializado.</param>
        byte[] GetBytes(IMensaje mensaje);
        /// <summary>
        /// Genera mensajes de una matriz de bytes que se recibe de la aplicación remota.
        /// La matriz de bytes puede contener sólo una parte de un mensaje, el protocolo debe 
        /// acumular bytes para construir mensajes.
        /// Este método está sincronizado. Por lo tanto, sólo un hilo lo puede llamar al mismo tiempo.
        /// </summary>
        /// <param name="bytesRecibidos">Bytes recibidos desde aplicaciones remotas.</param>
        /// <returns>
        /// Colección de mensajes.
        /// Protocolo puede generar más de un mensaje de una matriz de bytes.
        /// Además, si los bytes recibidos no son suficientes para construir un mensaje, el protocolo 
        /// puede devolver una lista vacía (y guardar bytes para combinar con la próxima llamada al método).
        /// </returns>
        IEnumerable<IMensaje> CrearMensajes(byte[] bytesRecibidos);
        /// <summary>
        /// Este método se llama cuando se restablece la conexión con la aplicación remota (se está reseteando la conexión, o es la primera conexión).
        /// Por lo tanto, el telegrama debe resetearse.
        /// </summary>
        void Resetear();
    }
}
