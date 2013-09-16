//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas.Serializacion
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Excepciones;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas.Serializacion
{
    /// <summary>
    /// Protocolo de comunicación predeterminado entre el servidor y los clientes para enviar y recibir un mensaje.
    /// Utiliza serialización binaria .NET para escribir y leer mensajes.
    /// 
    /// Formato de mensaje: [Longitud de mensaje (4 bytes)][Contenido del mensaje serializado].
    /// 
    /// Si un mensaje es serializado en un array de bytes en N bytes, este protocolo añade 4 bytes de
    /// información extra a la cabecera del mensaje, por lo tanto, la longitud total es de (4 + N) bytes.
    /// 
    /// Esta clase se puede derivar para cambiar de serialización (por defecto: BinaryFormatter). Para ello,
    /// SerializarMensaje y DeserializarMensaje deben ser virtuales.
    /// </summary>
    public class Serializacion : ITelegrama
    {
        #region Atributos
        /// <summary>
        /// Máxima longitud del mensaje.
        /// </summary>
        private const int MaximaLongitudMensaje = 128 * 1024 * 1024; // 128 Megabytes.
        /// <summary>
        /// Este MemoryStream se utiliza para recoger los bytes recibidos en la construcción de mensajes.
        /// </summary>
        private MemoryStream _bytesRecibidosMemoryStream;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Serializacion.
        /// </summary>
        public Serializacion()
        {
            _bytesRecibidosMemoryStream = new MemoryStream();
        }
        #endregion Constructor

        #region Implementación de ITelegrama
        /// <summary>
        /// Serializar un mensaje a una matriz de bytes para enviar a la aplicación remota.
        /// Este método está sincronizado. Por lo tanto, sólo un hilo lo puede llamar al mismo tiempo.
        /// </summary>
        /// <param name="mensaje">Mensaje que será serializado.</param>
        /// <exception cref="ExcepcionComunicacion">Throws ExcepcionComunicacion si el mensaje es más grande que la máxima longitud permitida.</exception>
        public byte[] GetBytes(IMensaje mensaje)
        {
            //  Serializar el mensaje a una matriz de bytes.
            var mensajeSerializado = SerializarMensaje(mensaje);

            //  Comprueba la longitud del mensaje.
            var longitudMensaje = mensajeSerializado.Length;
            if (longitudMensaje > MaximaLongitudMensaje)
            {
                throw new ExcepcionComunicacion("El mensaje es demasiado grande (" + longitudMensaje + " bytes). La longitud máxima permitida es " + MaximaLongitudMensaje + " bytes.");
            }

            //  Crear una matriz de bytes incluyendo la longitud del mensaje (4 bytes) y el contenido del mensaje serializado.
            var bytes = new byte[longitudMensaje + 4];
            EscribirInt32(bytes, 0, longitudMensaje);
            Array.Copy(mensajeSerializado, 0, bytes, 4, longitudMensaje);

            //  Devuelve el mensaje serializado por este protocolo.
            return bytes;
        }
        /// <summary>
        /// Generar mensajes de una matriz de bytes que se recibe de la aplicación remota.
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
        public IEnumerable<IMensaje> CrearMensajes(byte[] bytesRecibidos)
        {
            //  Escribe todos los bytes recibidos en _recepcionBytes.
            _bytesRecibidosMemoryStream.Write(bytesRecibidos, 0, bytesRecibidos.Length);

            //  Crear una colección de mensajes (List).
            var mensajes = new List<IMensaje>();

            //  Leer todos los mensajes disponibles y agregar a la colección de mensajes.
            while (LeerMensaje(mensajes)) { }

            //  Devolver la colección de mensajes.
            return mensajes;
        }
        /// <summary>
        /// Este método se llama cuando se restablece la conexión con la aplicación remota (se está reseteando la conexión, o es la primera conexión).
        /// Por lo tanto, el telegrama debe resetearse.
        /// </summary>
        public void Resetear()
        {
            if (_bytesRecibidosMemoryStream.Length > 0)
            {
                _bytesRecibidosMemoryStream = new MemoryStream();
            }
        }
        #endregion Implementación de ITelegrama

        #region Métodos protegidos
        /// <summary>
        /// Este método se utiliza para serializar un IMensaje a una matriz de bytes.
        /// Este método se puede sobreescribir por las clases derivadas para cambiar la estrategia de serialización.
        /// Se trata de una combinación con el método DeserializarMensaje, deben sobreescribirse juntos.
        /// </summary>
        /// <param name="mensaje">Mensaje que será serializado.</param>
        /// <returns>
        /// Mensaje serializado en bytes.
        /// No incluye la longitud del mensaje.
        /// </returns>
        protected virtual byte[] SerializarMensaje(IMensaje mensaje)
        {
            using (var memoryStream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(memoryStream, mensaje);
                return memoryStream.ToArray();
            }
        }
        /// <summary>
        /// Este método se utiliza para deserializar un IMensaje de sus bytes.
        /// Este método se puede sobreescribir por las clases derivadas para cambiar la estrategia de deserialización.
        /// Se trata de una combinación con el método SerializarMensaje, deben sobreescribirse juntos.
        /// </summary>
        /// <param name="bytes">
        /// Bytes de mensaje que serán deserializados (no incluye la longitud del mensaje. Se componen de un solo mensaje entero).
        /// </param>
        /// <returns>Mensaje deserializado.</returns>
        protected virtual IMensaje DeserializarMensaje(byte[] bytes)
        {
            //  Crear un MemoryStream para convertir bytes en una secuencia.
            using (var memoryStreamDeserializado = new MemoryStream(bytes))
            {
                //  Posicionarse en el comienzo del stream.
                memoryStreamDeserializado.Position = 0;

                //  Deserializar el mensaje.
                var binaryFormatter = new BinaryFormatter
                {
                    AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
                    Binder = new DeserializationAppDomainBinder()
                };

                //  Devolver el mensaje deserializado.
                return (IMensaje)binaryFormatter.Deserialize(memoryStreamDeserializado);
            }
        }
        #endregion Métodos protegidos

        #region Métodos privados
        /// <summary>
        /// Este método intenta leer un mensaje y agregarlo a la colección de mensajes. 
        /// </summary>
        /// <param name="mensajes">Colección de mensajes.</param>
        /// <returns>
        /// Devuelve un valor booleano que indica si hay una necesidad de volver a llamar a este método.
        /// </returns>
        /// <exception cref="ExcepcionComunicacion">Throws ExcepcionComunicacion si el mensaje es más grande que la máxima longitud permitida.</exception>
        private bool LeerMensaje(ICollection<IMensaje> mensajes)
        {
            //  Posicionarse en el comienzo del stream.
            _bytesRecibidosMemoryStream.Position = 0;

            //  Si el stream tiene menos de 4 bytes, significa que ni siquiera podemos leer la longitud del mensaje
            //  Por lo tanto, devolver false. Esperar más bytes de la aplicación remota.
            if (_bytesRecibidosMemoryStream.Length < 4)
            {
                return false;
            }

            //  Leer longitud del mensaje.
            var longitudMensaje = LeerInt32(_bytesRecibidosMemoryStream);
            if (longitudMensaje > MaximaLongitudMensaje)
            {
                throw new ExcepcionComunicacion("El mensaje es demasiado grande (" + longitudMensaje + " bytes). La longitud máxima permitida es " + MaximaLongitudMensaje + " bytes.");
            }
            //  Si el mensaje es de longitud cero (No debe ser, pero buen método para comprobarlo).
            if (longitudMensaje == 0)
            {
                //  Si no hay más bytes, devolver inmediatamente.
                if (_bytesRecibidosMemoryStream.Length == 4)
                {
                    _bytesRecibidosMemoryStream = new MemoryStream(); //  Borrar el stream.
                    return false;
                }

                //  Crear un nuevo MemoryStream(), excepto los primeros 4 bytes.
                var bytes = _bytesRecibidosMemoryStream.ToArray();
                _bytesRecibidosMemoryStream = new MemoryStream();
                _bytesRecibidosMemoryStream.Write(bytes, 4, bytes.Length - 4);
                return true;
            }

            //  Si todos los bytes del mensaje no se ha recibido aún, volver a esperar más bytes.
            if (_bytesRecibidosMemoryStream.Length < (4 + longitudMensaje))
            {
                _bytesRecibidosMemoryStream.Position = _bytesRecibidosMemoryStream.Length;
                return false;
            }

            //  Leer bytes del mensaje serializado y deserializarlo.
            var mensajeSerializado = LeerArrayBytes(_bytesRecibidosMemoryStream, longitudMensaje);
            mensajes.Add(DeserializarMensaje(mensajeSerializado));

            //  Leer el resto de bytes y almacenarlos en un array.
            var bytesRestantes = LeerArrayBytes(_bytesRecibidosMemoryStream, (int)(_bytesRecibidosMemoryStream.Length - (4 + longitudMensaje)));

            //  Recrear _bytesRecibidos y escribir los bytes restantes.
            _bytesRecibidosMemoryStream = new MemoryStream();
            _bytesRecibidosMemoryStream.Write(bytesRestantes, 0, bytesRestantes.Length);

            //  Devolver true y volver a llamar a este método para intentar leer el siguiente mensaje.
            return (bytesRestantes.Length > 4);
        }
        /// <summary>
        /// Escribir un valor entero a una matriz de bytes desde un índice inicial.
        /// </summary>
        /// <param name="buffer">Matriz de bytes.</param>
        /// <param name="startIndex">Índice inicial de la matriz de bytes a escribir.</param>
        /// <param name="number">Valor entero a escribir.</param>
        private static void EscribirInt32(byte[] buffer, int startIndex, int number)
        {
            //  Revisar BitConverter.GetBytes(number);
            buffer[startIndex] = (byte)((number >> 24) & 0xFF);
            buffer[startIndex + 1] = (byte)((number >> 16) & 0xFF);
            buffer[startIndex + 2] = (byte)((number >> 8) & 0xFF);
            buffer[startIndex + 3] = (byte)((number) & 0xFF);
        }
        /// <summary>
        /// Deserializar y devolver un entero serializado.
        /// </summary>
        /// <returns>Integer deserializado.</returns>
        private static int LeerInt32(Stream stream)
        {
            var buffer = LeerArrayBytes(stream, 4);
            return ((buffer[0] << 24) |
                    (buffer[1] << 16) |
                    (buffer[2] << 8) |
                    (buffer[3])
                   );
        }
        /// <summary>
        /// Leer una matriz de bytes con la longitud especificada.
        /// </summary>
        /// <param name="stream">Stream para leer.</param>
        /// <param name="longitud">Longitud de la matriz de bytes para leer.</param>
        /// <returns>Matriz de bytes leida.</returns>
        /// <exception cref="EndOfStreamException">Throws EndOfStreamException si no se puede leer del stream.</exception>
        private static byte[] LeerArrayBytes(Stream stream, int longitud)
        {
            var buffer = new byte[longitud];
            var totalBytesLeidos = 0;
            while (totalBytesLeidos < longitud)
            {
                var leidos = stream.Read(buffer, totalBytesLeidos, longitud - totalBytesLeidos);
                if (leidos <= 0)
                {
                    throw new EndOfStreamException("Stream cerrado, no es posible leer.");
                }
                totalBytesLeidos += leidos;
            }
            return buffer;
        }
        #endregion Métodos privados

        #region Clase DeserializationAppDomainBinder
        /// <summary>
        /// Esta clase se utiliza en deserializar para permitir deserializar objetos que se definen en ensamblados que se carga en tiempo de ejecución (como PlugIns).
        /// </summary>
        protected sealed class DeserializationAppDomainBinder : SerializationBinder
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="assemblyName"></param>
            /// <param name="typeName"></param>
            /// <returns></returns>
            public override Type BindToType(string assemblyName, string typeName)
            {
                var toAssemblyName = assemblyName.Split(',')[0];
                return (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                        where assembly.FullName.Split(',')[0] == toAssemblyName
                        select assembly.GetType(typeName)).FirstOrDefault();
            }
        }
        #endregion Clase DeserializationAppDomainBinder
    }
}