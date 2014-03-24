using Orbita.Comunicaciones;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Excepciones;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas.Serializacion;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Orbita.Test
{
    /// <summary>
    /// Esta clase es un protocolo de conexión personalizada para utilizar como protocolo de conexión
    /// en el marco de la librería de comunicaciones.
    /// 
    /// Se extiende de Serializacion.
    /// Se utiliza solo para enviar/recibir mensajes de texto sin conocer el número de bytes de la trama.
    /// </summary>
    public class Telegrama : Serializacion
    {
        protected override byte[] SerializarMensaje(IMensaje mensaje)
        {
            return Encoding.UTF8.GetBytes(((MensajeTexto)mensaje).Texto);
        }

        protected override IMensaje DeserializarMensaje(byte[] bytes)
        {
            //  Decodificar el mensaje codificado en UTF8 y crear un objecto de MensajeTexto.
            return new MensajeTexto(Encoding.UTF8.GetString(bytes));
        }
        /// <summary>
        /// Este método intenta leer un mensaje y agregarlo a la colección de mensajes. 
        /// </summary>
        /// <param name="mensajes">Colección de mensajes.</param>
        /// <returns>
        /// Devuelve un valor booleano que indica si hay una necesidad de volver a llamar a este método.
        /// </returns>
        /// <exception cref="ExcepcionComunicacion">Throws ExcepcionComunicacion si el mensaje es más grande que la máxima longitud permitida.</exception>
        protected override bool LeerMensaje(ICollection<IMensaje> mensajes)
        {
            //  Posicionarse en el comienzo del stream.
            BytesRecibidosMemoryStream.Position = 0;

            //  Leer longitud del mensaje.
            var longitudMensaje = (int)BytesRecibidosMemoryStream.Length;
            if (longitudMensaje > MaximaLongitudMensaje)
            {
                throw new ExcepcionComunicacion("El mensaje es demasiado grande (" + longitudMensaje + " bytes). La longitud máxima permitida es " + MaximaLongitudMensaje + " bytes.");
            }
            //  Si el mensaje es de longitud cero (No debe ser, pero buen método para comprobarlo).
            if (longitudMensaje == 0)
            {
                //  Si no hay más bytes, devolver inmediatamente.
                if (BytesRecibidosMemoryStream.Length == 0)
                {
                    BytesRecibidosMemoryStream = new MemoryStream(); //  Borrar el stream.
                    return false;
                }

                //  Crear un nuevo MemoryStream().
                var bytes = BytesRecibidosMemoryStream.ToArray();
                BytesRecibidosMemoryStream = new MemoryStream();
                BytesRecibidosMemoryStream.Write(bytes, 0, bytes.Length);
                return true;
            }

            //  Si todos los bytes del mensaje no se ha recibido aún, volver a esperar más bytes.
            if (BytesRecibidosMemoryStream.Length < longitudMensaje)
            {
                BytesRecibidosMemoryStream.Position = BytesRecibidosMemoryStream.Length;
                return false;
            }

            //  Leer bytes del mensaje serializado y deserializarlo.
            var mensajeSerializado = LeerArrayBytes(BytesRecibidosMemoryStream, longitudMensaje);
            mensajes.Add(DeserializarMensaje(mensajeSerializado));

            //  Leer el resto de bytes y almacenarlos en un array.
            var bytesRestantes = LeerArrayBytes(BytesRecibidosMemoryStream, (int)(BytesRecibidosMemoryStream.Length - longitudMensaje));

            //  Recrear _bytesRecibidos y escribir los bytes restantes.
            BytesRecibidosMemoryStream = new MemoryStream();
            BytesRecibidosMemoryStream.Write(bytesRestantes, 0, bytesRestantes.Length);

            //  Devolver true y volver a llamar a este método para intentar leer el siguiente mensaje.
            return (bytesRestantes.Length > 0);
        }
    }
}
