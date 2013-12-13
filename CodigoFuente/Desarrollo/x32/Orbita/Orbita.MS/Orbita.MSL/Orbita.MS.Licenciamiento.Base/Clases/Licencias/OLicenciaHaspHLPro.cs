using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS.Clases.Licencias
{
    public class OLicenciaHaspHLPro : OLicenciaHaspBase
    {
        #region Atributos
        protected Type _tipo = typeof(OLicenciaHaspHLPro);
        #endregion Atributos
        #region Propiedades
        #endregion Propiedades
        #region Constructores
        public OLicenciaHaspHLPro():base()
        {
            this.TipoLicencia = OTipoLicencia.HASP;
            this._soporteSerie = new OLicenciaHaspSoporteSerie(
                "nDziMIFvJOlsEoaQsgo91ii7QN2rTwS91Fd5n6KsPtAGGUaYE+M7v54JBT7VO7AhETH5yW+Q8SvAMTMQ" +
                "u8Sbw9xkbCRjGA+aDqdCgj2V1Xtos+TB7Z71EfiPOK4tmqZxfHwvK3Ybe2w3cuc/oDzHhBsCBlNcYDNs" +
                "sybWuDanQvmZV6RD9wUg1Nnn5viuoVdn4dlhACKLkn1RUg/buPmBaZp4p3luE6R0dWYMEvU671b3Hkxf" +
                "ZICjxhMRd4fq2QpvEJX9nd5UPfBykbG3oqp12apD+K4x/DBBBt3R+oV3NLNeDBw2jTkbKqBmrFfe2dDU" +
                "QNDDYrYHa8HqhK72dQNvambAEpdVjTFRif7cZWdlvOS+FxHrAw2SXrmC/wohjAMFW+PqFZCj+cqwda3+" +
                "7gF8MyeaP4+843lEer/pqiAiD1elM0BTmE8XXnKEdNIK/4QRDrsJqAfzWhsmMJHedZow75jUGtkg/YGB" +
                "ZTmBGQ4+HoVnOa3rURjQi+5Ij+CBjPsFralg/GQIg6mNpRv6UYJh/Sdv7H01e9G/EZOgtqbSu7Kfw6KE" +
                "fFca+3xE5dDwqFT42/HSTidNLDcK5Q5sKBorFI6uUGC4KUM6D5YfDHdL8/okNcKYNI3g/VVuU3eBZY+7" +
                "67iQwVyppJwejXa6lNWv4zixH7aWjw1/WVyOslyjPxHGCTTSabltvLFQbfLQBSaaKCnEGM0VV26W6nFi" +
                "cZm5VOFs0xmInr7bLloa9PpHiJ54ehOQTs/xESmcN3Z9kEHS9wWxIHrwpnYAzlb4xYM7BhMj2BfZByd0" +
                "qX10XbzIRreQa3/nM8A40H1Ods4O5wBmIZkKK8Q8qZecXP/K/hMNvwuA+iCg1g2LyJ2HUKqrhIGXxib9" +
                "4mV04tPfRKbKjVVhzSxZKOPPjpr/S8HGCtWIDjz7dqyaGl+6RUqMU+1jK1c=", "", 1);
        }
        #endregion Constructores
    }
}
