using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Orbita.MS.Licencias
{
    [XmlRoot("hasp_info")]
    public partial class OLicenciaHASPXMLInfo
    {
        public class OXMLHasp
        {
            public int id = 0;
            public string type = "HASP-HL";
            [XmlAttribute("feature")]
            public List<OXMLHaspFeature> feature = new List<OXMLHaspFeature>() { };
        }
        public class OXMLHaspFeature
        {
            public int id = 0;
        }

        [XmlAttribute("hasp")]
        List<OXMLHasp> hasp = new List<OXMLHasp>() { };
    }
}
