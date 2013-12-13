using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Orbita.MS.Clases.Licencias
{
    [XmlRoot("hasp_info")]
    public partial class OLicenciaHASPXMLInfo
    {

        class OLicenciaHASPXMLLicencias
        {

            public class OXMLHasp
            {
                public int id = 0;
                public string type = "HASP-HL";
                [XmlAttribute("feature")]
                public List<OXMLHaspLicenciaFeature> feature = new List<OXMLHaspLicenciaFeature>() { };
            }
            public class OXMLHaspLicenciaFeature
            {
                public int id = 0;

                //OXMLHaspLicencia 
            }

            [XmlAttribute("hasp")]
            List<OXMLHasp> hasp = new List<OXMLHasp>() { };

        }
    }
}
