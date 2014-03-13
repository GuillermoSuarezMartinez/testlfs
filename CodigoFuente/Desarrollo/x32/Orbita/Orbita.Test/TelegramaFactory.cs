using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas;

namespace Orbita.Test
{
    public class TelegramaFactory : ITelegramaFactory
    {
        public ITelegrama CrearTelegrama()
        {
            return new Telegrama();
        }
    }
}
