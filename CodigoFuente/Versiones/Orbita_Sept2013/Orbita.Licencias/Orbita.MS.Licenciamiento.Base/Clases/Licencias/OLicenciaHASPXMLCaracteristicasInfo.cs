using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
namespace Orbita.MS.Licencias
{
    //[XmlRoot("hasp_info")]
    public partial class OLicenciaHASPXMLInfo
    {
        public class OXMLFeature
        {
            public string id = "";
            public bool locked = true;
            public bool expired = false;
            public bool usable = true;
        }

        [XmlAttribute("feature")]
        List<OXMLFeature> feature = new List<OXMLFeature>() { };
    }
    
}
