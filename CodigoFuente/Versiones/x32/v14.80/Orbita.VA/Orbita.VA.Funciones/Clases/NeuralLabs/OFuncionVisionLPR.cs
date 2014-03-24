//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 12-12-2012
// Description      : Adaptada la forma de trabajar con el thread
// Last Modified By : fhernandez
// Last Modified On : 13-05-2013
// Description      : Adaptada para funcionar con wrapper propio
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using Orbita.Utiles;
using Orbita.VA.Comun;
using Orbita.Xml;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase que ejecuta continuamente el
    /// </summary>
    internal static class OLPRManager
    {
        #region Propiedad(es)
        /// <summary>
        /// Asignación de paises de NL con la ISO3166-2
        /// </summary>
        private static List<OQuartet<string, string, string, int>> _AsignacionPaisesNL =
            new List<OQuartet<string, string, string, int>>()
            {
                new OQuartet<string, string, string, int>("AFG", "AF", "Afganistán",0),
                new OQuartet<string, string, string, int>("ALA", "AX", "Åland",0),
                new OQuartet<string, string, string, int>("ALB", "AL", "Albania",125),
                new OQuartet<string, string, string, int>("DEU", "DE", "Alemania",108),
                new OQuartet<string, string, string, int>("AND", "AD", "Andorra",0),
                new OQuartet<string, string, string, int>("AGO", "AO", "Angola",0),
                new OQuartet<string, string, string, int>("AIA", "AI", "Anguila",0),
                new OQuartet<string, string, string, int>("ATG", "AG", "Antigua y Barbuda",0),
                new OQuartet<string, string, string, int>("ANT", "AN", "Antillas Neerlandesas",0),
                new OQuartet<string, string, string, int>("SAU", "SA", "Arabia Saudita",0),
                new OQuartet<string, string, string, int>("DZA", "DZ", "Argelia",0),
                new OQuartet<string, string, string, int>("ARG", "AR", "Argentina",204),
                new OQuartet<string, string, string, int>("ARM", "AM", "Armenia",0),
                new OQuartet<string, string, string, int>("ABW", "AW", "Aruba",0),
                new OQuartet<string, string, string, int>("AUS", "AU", "Australia",0),
                new OQuartet<string, string, string, int>("AUT", "AT", "Austria",124),
                new OQuartet<string, string, string, int>("AZE", "AZ", "Azerbaiyán",0),
                new OQuartet<string, string, string, int>("BHS", "BS", "Bahamas",0),
                new OQuartet<string, string, string, int>("BHR", "BH", "Baréin",0),
                new OQuartet<string, string, string, int>("BGD", "BD", "Bangladés",0),
                new OQuartet<string, string, string, int>("BRB", "BB", "Barbados",0),
                new OQuartet<string, string, string, int>("BEL", "BE", "Bélgica",116),
                new OQuartet<string, string, string, int>("BLZ", "BZ", "Belice",0),
                new OQuartet<string, string, string, int>("BEN", "BJ", "Benín",0),
                new OQuartet<string, string, string, int>("BMU", "BM", "Bermudas",0),
                new OQuartet<string, string, string, int>("BLR", "BY", "Bielorrusia",0),
                new OQuartet<string, string, string, int>("MMR", "MM", "Birmania",0),
                new OQuartet<string, string, string, int>("BOL", "BO", "Bolivia",0),
                new OQuartet<string, string, string, int>("BIH", "BA", "Bosnia y Herzegovina",114),
                new OQuartet<string, string, string, int>("BWA", "BW", "Botsuana",0),
                new OQuartet<string, string, string, int>("BVT", "BV", "Isla Bouvet",0),
                new OQuartet<string, string, string, int>("BRA", "BR", "Brasil",203),
                new OQuartet<string, string, string, int>("BRN", "BN", "Brunéi",0),
                new OQuartet<string, string, string, int>("BGR", "BG", "Bulgaria",111),
                new OQuartet<string, string, string, int>("BFA", "BF", "Burkina Faso",0),
                new OQuartet<string, string, string, int>("BDI", "BI", "Burundi",0),
                new OQuartet<string, string, string, int>("BTN", "BT", "Bután",0),
                new OQuartet<string, string, string, int>("CPV", "CV", "Cabo Verde",0),
                new OQuartet<string, string, string, int>("CYM", "KY", "Islas Caimán",0),
                new OQuartet<string, string, string, int>("KHM", "KH", "Camboya",0),
                new OQuartet<string, string, string, int>("CMR", "CM", "Camerún",0),
                new OQuartet<string, string, string, int>("CAN", "CA", "Canadá",561),
                new OQuartet<string, string, string, int>("CAF", "CF", "República Centroafricana",0),
                new OQuartet<string, string, string, int>("TCD", "TD", "Chad",0),
                new OQuartet<string, string, string, int>("CZE", "CZ", "República Checa",0),
                new OQuartet<string, string, string, int>("CHL", "CL", "Chile",201),
                new OQuartet<string, string, string, int>("CHN", "CN", "China",0),
                new OQuartet<string, string, string, int>("CYP", "CY", "Chipre",126),
                new OQuartet<string, string, string, int>("CCK", "CC", "Islas Cocos",0),
                new OQuartet<string, string, string, int>("COL", "CO", "Colombia",0),
                new OQuartet<string, string, string, int>("COM", "KM", "Comoras",0),
                new OQuartet<string, string, string, int>("COG", "CG", "República del Congo",0),
                new OQuartet<string, string, string, int>("COD", "CD", "República Democrática del Congo",0),
                new OQuartet<string, string, string, int>("COK", "CK", "Islas Cook",0),
                new OQuartet<string, string, string, int>("PRK", "KP", "Corea del Norte",0),
                new OQuartet<string, string, string, int>("KOR", "KR", "Corea del Sur",0),
                new OQuartet<string, string, string, int>("CIV", "CI", "Costa de Marfil",0),
                new OQuartet<string, string, string, int>("CRI", "CR", "Costa Rica",0),
                new OQuartet<string, string, string, int>("HRV", "HR", "Croacia",0),
                new OQuartet<string, string, string, int>("CUW", "CW", "Curazao",0),
                new OQuartet<string, string, string, int>("CUB", "CU", "Cuba",0),
                new OQuartet<string, string, string, int>("DNK", "DK", "Dinamarca",118),
                new OQuartet<string, string, string, int>("DMA", "DM", "Dominica",0),
                new OQuartet<string, string, string, int>("DOM", "DO", "República Dominicana",0),
                new OQuartet<string, string, string, int>("ECU", "EC", "Ecuador",206),
                new OQuartet<string, string, string, int>("EGY", "EG", "Egipto",0),
                new OQuartet<string, string, string, int>("SLV", "SV", "El Salvador",209),
                new OQuartet<string, string, string, int>("ARE", "AE", "Emiratos Árabes Unidos",0),
                new OQuartet<string, string, string, int>("ERI", "ER", "Eritrea",0),
                new OQuartet<string, string, string, int>("SVK", "SK", "Eslovaquia",0),
                new OQuartet<string, string, string, int>("SVN", "SI", "Eslovenia",0),
                new OQuartet<string, string, string, int>("ESP", "ES", "España* **",101),
                new OQuartet<string, string, string, int>("USA", "US", "Estados Unidos",501),
                new OQuartet<string, string, string, int>("USA", "US", "Estados Unidos",502),
                new OQuartet<string, string, string, int>("USA", "US", "Estados Unidos",503),
                new OQuartet<string, string, string, int>("USA", "US", "Estados Unidos",504),
                new OQuartet<string, string, string, int>("USA", "US", "Estados Unidos",505),
                new OQuartet<string, string, string, int>("EST", "EE", "Estonia",113),
                new OQuartet<string, string, string, int>("ETH", "ET", "Etiopía",0),
                new OQuartet<string, string, string, int>("FRO", "FO", "Islas Feroe",0),
                new OQuartet<string, string, string, int>("PHL", "PH", "Filipinas",305),
                new OQuartet<string, string, string, int>("FIN", "FI", "Finlandia",0),
                new OQuartet<string, string, string, int>("FJI", "FJ", "Fiyi",0),
                new OQuartet<string, string, string, int>("FRA", "FR", "Francia",103),
                new OQuartet<string, string, string, int>("GAB", "GA", "Gabón",0),
                new OQuartet<string, string, string, int>("GMB", "GM", "Gambia",0),
                new OQuartet<string, string, string, int>("GEO", "GE", "Georgia",0),
                new OQuartet<string, string, string, int>("SGS", "GS", "Islas Georgias del Sur y Sandwich del Sur",0),
                new OQuartet<string, string, string, int>("GHA", "GH", "Ghana",0),
                new OQuartet<string, string, string, int>("GIB", "GI", "Gibraltar",121),
                new OQuartet<string, string, string, int>("GRD", "GD", "Granada",0),
                new OQuartet<string, string, string, int>("GRC", "GR", "Grecia",106),
                new OQuartet<string, string, string, int>("GRL", "GL", "Groenlandia",0),
                new OQuartet<string, string, string, int>("GLP", "GP", "Guadalupe",0),
                new OQuartet<string, string, string, int>("GUM", "GU", "Guam",0),
                new OQuartet<string, string, string, int>("GTM", "GT", "Guatemala",212),
                new OQuartet<string, string, string, int>("GUF", "GF", "Guayana Francesa",0),
                new OQuartet<string, string, string, int>("GGY", "GG", "Guernsey",0),
                new OQuartet<string, string, string, int>("GIN", "GN", "Guinea",0),
                new OQuartet<string, string, string, int>("GNQ", "GQ", "Guinea Ecuatorial",0),
                new OQuartet<string, string, string, int>("GNB", "GW", "Guinea-Bisáu",0),
                new OQuartet<string, string, string, int>("GUY", "GY", "Guyana",0),
                new OQuartet<string, string, string, int>("HTI", "HT", "Haití",0),
                new OQuartet<string, string, string, int>("HMD", "HM", "Islas Heard y McDonald",0),
                new OQuartet<string, string, string, int>("HND", "HN", "Honduras",0),
                new OQuartet<string, string, string, int>("HKG", "HK", "Hong Kong",0),
                new OQuartet<string, string, string, int>("HUN", "HU", "Hungría",0),
                new OQuartet<string, string, string, int>("IND", "IN", "India",0),
                new OQuartet<string, string, string, int>("IDN", "ID", "Indonesia",0),
                new OQuartet<string, string, string, int>("IRN", "IR", "Irán",0),
                new OQuartet<string, string, string, int>("IRQ", "IQ", "Irak",0),
                new OQuartet<string, string, string, int>("IRL", "IE", "Irlanda",107),
                new OQuartet<string, string, string, int>("ISL", "IS", "Islandia",0),
                new OQuartet<string, string, string, int>("ISR", "IL", "Israel",308),
                new OQuartet<string, string, string, int>("ITA", "IT", "Italia",104),
                new OQuartet<string, string, string, int>("JAM", "JM", "Jamaica",0),
                new OQuartet<string, string, string, int>("JPN", "JP", "Japón",0),
                new OQuartet<string, string, string, int>("JEY", "JE", "Jersey",0),
                new OQuartet<string, string, string, int>("JOR", "JO", "Jordania",0),
                new OQuartet<string, string, string, int>("KAZ", "KZ", "Kazajistán",0),
                new OQuartet<string, string, string, int>("KEN", "KE", "Kenia",0),
                new OQuartet<string, string, string, int>("KGZ", "KG", "Kirguistán",0),
                new OQuartet<string, string, string, int>("KIR", "KI", "Kiribati",0),
                new OQuartet<string, string, string, int>("KWT", "KW", "Kuwait",0),
                new OQuartet<string, string, string, int>("LAO", "LA", "Laos",0),
                new OQuartet<string, string, string, int>("LSO", "LS", "Lesoto",0),
                new OQuartet<string, string, string, int>("LVA", "LV", "Letonia",0),
                new OQuartet<string, string, string, int>("LBN", "LB", "Líbano",0),
                new OQuartet<string, string, string, int>("LBR", "LR", "Liberia",0),
                new OQuartet<string, string, string, int>("LBY", "LY", "Libia",0),
                new OQuartet<string, string, string, int>("LIE", "LI", "Liechtenstein",0),
                new OQuartet<string, string, string, int>("LTU", "LT", "Lituania",0),
                new OQuartet<string, string, string, int>("LUX", "LU", "Luxemburgo",0),
                new OQuartet<string, string, string, int>("MAC", "MO", "Macao",0),
                new OQuartet<string, string, string, int>("MKD", "MK", "República de Macedonia",0),
                new OQuartet<string, string, string, int>("MDG", "MG", "Madagascar",0),
                new OQuartet<string, string, string, int>("MYS", "MY", "Malasia",306),
                new OQuartet<string, string, string, int>("MWI", "MW", "Malaui",0),
                new OQuartet<string, string, string, int>("MDV", "MV", "Maldivas",0),
                new OQuartet<string, string, string, int>("MLI", "ML", "Malí",0),
                new OQuartet<string, string, string, int>("MLT", "MT", "Malta",0),
                new OQuartet<string, string, string, int>("FLK", "FK", "Islas Malvinas",0),
                new OQuartet<string, string, string, int>("IMN", "IM", "Isla de Man",0),
                new OQuartet<string, string, string, int>("MNP", "MP", "Islas Marianas del Norte",0),
                new OQuartet<string, string, string, int>("MAR", "MA", "Marruecos",402),
                new OQuartet<string, string, string, int>("MHL", "MH", "Islas Marshall",0),
                new OQuartet<string, string, string, int>("MTQ", "MQ", "Martinica",0),
                new OQuartet<string, string, string, int>("MUS", "MU", "Mauricio",0),
                new OQuartet<string, string, string, int>("MRT", "MR", "Mauritania",0),
                new OQuartet<string, string, string, int>("MYT", "YT", "Mayotte",0),
                new OQuartet<string, string, string, int>("MEX", "MX", "México",205),
                new OQuartet<string, string, string, int>("FSM", "FM", "Micronesia",0),
                new OQuartet<string, string, string, int>("MDA", "MD", "Moldavia",0),
                new OQuartet<string, string, string, int>("MCO", "MC", "Mónaco",0),
                new OQuartet<string, string, string, int>("MNG", "MN", "Mongolia",0),
                new OQuartet<string, string, string, int>("MNE", "ME", "Montenegro",0),
                new OQuartet<string, string, string, int>("MSR", "MS", "Montserrat",0),
                new OQuartet<string, string, string, int>("MOZ", "MZ", "Mozambique",0),
                new OQuartet<string, string, string, int>("NAM", "NA", "Namibia",0),
                new OQuartet<string, string, string, int>("NRU", "NR", "Nauru",0),
                new OQuartet<string, string, string, int>("CXR", "CX", "Isla de Navidad",0),
                new OQuartet<string, string, string, int>("NPL", "NP", "Nepal",0),
                new OQuartet<string, string, string, int>("NIC", "NI", "Nicaragua",0),
                new OQuartet<string, string, string, int>("NER", "NE", "Níger",0),
                new OQuartet<string, string, string, int>("NGA", "NG", "Nigeria",0),
                new OQuartet<string, string, string, int>("NIU", "NU", "Niue",0),
                new OQuartet<string, string, string, int>("NFK", "NF", "Norfolk",0),
                new OQuartet<string, string, string, int>("NOR", "NO", "Noruega",117),
                new OQuartet<string, string, string, int>("NCL", "NC", "Nueva Caledonia",0),
                new OQuartet<string, string, string, int>("NZL", "NZ", "Nueva Zelanda",0),
                new OQuartet<string, string, string, int>("OMN", "OM", "Omán",0),
                new OQuartet<string, string, string, int>("NLD", "NL", "Países Bajos",112),
                new OQuartet<string, string, string, int>("PAK", "PK", "Pakistán",0),
                new OQuartet<string, string, string, int>("PLW", "PW", "Palaos",0),
                new OQuartet<string, string, string, int>("PSE", "PS", "Estado de Palestina",0),
                new OQuartet<string, string, string, int>("PAN", "PA", "Panamá",215),
                new OQuartet<string, string, string, int>("PNG", "PG", "Papúa Nueva Guinea",0),
                new OQuartet<string, string, string, int>("PRY", "PY", "Paraguay",216),
                new OQuartet<string, string, string, int>("PER", "PE", "Perú",208),
                new OQuartet<string, string, string, int>("PCN", "PN", "Islas Pitcairn",0),
                new OQuartet<string, string, string, int>("PYF", "PF", "Polinesia Francesa",0),
                new OQuartet<string, string, string, int>("POL", "PL", "Polonia",110),
                new OQuartet<string, string, string, int>("PRT", "PT", "Portugal",102),
                new OQuartet<string, string, string, int>("PRI", "PR", "Puerto Rico",0),
                new OQuartet<string, string, string, int>("QAT", "QA", "Catar",0),
                new OQuartet<string, string, string, int>("GBR", "GB", "Reino Unido",105),
                new OQuartet<string, string, string, int>("REU", "RE", "Reunión",0),
                new OQuartet<string, string, string, int>("RWA", "RW", "Ruanda",0),
                new OQuartet<string, string, string, int>("ROU", "RO", "Rumania",115),
                new OQuartet<string, string, string, int>("RUS", "RU", "Rusia",301),
                new OQuartet<string, string, string, int>("ESH", "EH", "Sahara Occidental",0),
                new OQuartet<string, string, string, int>("SLB", "SB", "Islas Salomón",0),
                new OQuartet<string, string, string, int>("WSM", "WS", "Samoa",0),
                new OQuartet<string, string, string, int>("ASM", "AS", "Samoa Americana",0),
                new OQuartet<string, string, string, int>("BLM", "BL", "San Bartolomé",0),
                new OQuartet<string, string, string, int>("KNA", "KN", "San Cristóbal y Nieves",0),
                new OQuartet<string, string, string, int>("SMR", "SM", "San Marino",0),
                new OQuartet<string, string, string, int>("MAF", "MF", "San Martín",0),
                new OQuartet<string, string, string, int>("SPM", "PM", "San Pedro y Miquelón",0),
                new OQuartet<string, string, string, int>("VCT", "VC", "San Vicente y las Granadinas",0),
                new OQuartet<string, string, string, int>("SHN", "SH", "Santa Helena, A. y T.",0),
                new OQuartet<string, string, string, int>("LCA", "LC", "Santa Lucía",0),
                new OQuartet<string, string, string, int>("STP", "ST", "Santo Tomé y Príncipe",0),
                new OQuartet<string, string, string, int>("SEN", "SN", "Senegal",0),
                new OQuartet<string, string, string, int>("SRB", "RS", "Serbia",0),
                new OQuartet<string, string, string, int>("SYC", "SC", "Seychelles",0),
                new OQuartet<string, string, string, int>("SLE", "SL", "Sierra Leona",0),
                new OQuartet<string, string, string, int>("SGP", "SG", "Singapur",307),
                new OQuartet<string, string, string, int>("SYR", "SY", "Siria",0),
                new OQuartet<string, string, string, int>("SOM", "SO", "Somalia",0),
                new OQuartet<string, string, string, int>("LKA", "LK", "Sri Lanka",0),
                new OQuartet<string, string, string, int>("SWZ", "SZ", "Suazilandia",0),
                new OQuartet<string, string, string, int>("ZAF", "ZA", "Sudáfrica",401),
                new OQuartet<string, string, string, int>("SDN", "SD", "Sudán",0),
                new OQuartet<string, string, string, int>("SSD", "SS", "Sudán del Sur",0),
                new OQuartet<string, string, string, int>("SWE", "SE", "Suecia",119),
                new OQuartet<string, string, string, int>("CHE", "CH", "Suiza",0),
                new OQuartet<string, string, string, int>("SUR", "SR", "Surinam",0),
                new OQuartet<string, string, string, int>("SJM", "SJ", "Svalbard y Jan Mayen",0),
                new OQuartet<string, string, string, int>("THA", "TH", "Tailandia",0),
                new OQuartet<string, string, string, int>("TWN", "TW", "Taiwán",0),
                new OQuartet<string, string, string, int>("TZA", "TZ", "Tanzania",0),
                new OQuartet<string, string, string, int>("TJK", "TJ", "Tayikistán",0),
                new OQuartet<string, string, string, int>("IOT", "IO", "Territorio Británico del Océano Índico",0),
                new OQuartet<string, string, string, int>("ATF", "TF", "Territorios Australes Franceses",0),
                new OQuartet<string, string, string, int>("TLS", "TL", "Timor Oriental",0),
                new OQuartet<string, string, string, int>("TGO", "TG", "Togo",0),
                new OQuartet<string, string, string, int>("TKL", "TK", "Tokelau",0),
                new OQuartet<string, string, string, int>("TON", "TO", "Tonga",0),
                new OQuartet<string, string, string, int>("TTO", "TT", "Trinidad y Tobago",0),
                new OQuartet<string, string, string, int>("TUN", "TN", "Túnez",0),
                new OQuartet<string, string, string, int>("TCA", "TC", "Islas Turcas y Caicos",0),
                new OQuartet<string, string, string, int>("TKM", "TM", "Turkmenistán",0),
                new OQuartet<string, string, string, int>("TUR", "TR", "Turquía",302),
                new OQuartet<string, string, string, int>("TUV", "TV", "Tuvalu",0),
                new OQuartet<string, string, string, int>("UKR", "UA", "Ucrania",0),
                new OQuartet<string, string, string, int>("UGA", "UG", "Uganda",0),
                new OQuartet<string, string, string, int>("URY", "UY", "Uruguay",211),
                new OQuartet<string, string, string, int>("UZB", "UZ", "Uzbekistán",0),
                new OQuartet<string, string, string, int>("VUT", "VU", "Vanuatu",0),
                new OQuartet<string, string, string, int>("VAT", "VA", "Ciudad del Vaticano",0),
                new OQuartet<string, string, string, int>("VEN", "VE", "Venezuela",207),
                new OQuartet<string, string, string, int>("VNM", "VN", "Vietnam",303),
                new OQuartet<string, string, string, int>("VGB", "VG", "Islas Vírgenes Británicas",0),
                new OQuartet<string, string, string, int>("VIR", "VI", "Islas Vírgenes de los Estados Unidos",0),
                new OQuartet<string, string, string, int>("WLF", "WF", "Wallis y Futuna",0),
                new OQuartet<string, string, string, int>("YEM", "YE", "Yemen",0),
                new OQuartet<string, string, string, int>("DJI", "DJ", "Yibuti",0),
                new OQuartet<string, string, string, int>("ZMB", "ZM", "Zambia",0),
                new OQuartet<string, string, string, int>("ZWE", "ZW", "Zimbabue",0)
            };
        /// <summary>
        /// Asignación de paises de NL con la ISO3166-2
        /// </summary>
        public static List<OQuartet<string, string, string, int>> AsignacionPaisesNL
        {
            get { return _AsignacionPaisesNL; }
        }
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Constante que indica el pais o paises a identificar la matricula
        /// </summary>
        public static int CountryCode = 101;
        /// <summary>
        /// Constante de altura del caracter
        /// </summary>
        public static int AvCharHeight = -1;
        /// <summary>
        /// Parámetro de Vpar
        /// </summary>
        public static int DuplicateLines = 0;
        /// <summary>
        /// Parametro de Vpar
        /// </summary>
        public static int Reordenar = 0;
        /// <summary>
        /// Parametro de Vpar
        /// </summary>
        public static int FilterColor = 0;
        /// <summary>
        /// Trazabilidad
        /// </summary>
        public static int TraceVpar = 1;
        /// <summary>
        /// Thread de ejecución continua del módulo LPR
        /// </summary>
        public static ThreadEjecucionLPR ThreadEjecucionLPR;
        /// <summary>
        /// Indica si alguna función de visión ha demandado el uso del LPR
        /// </summary>
        private static bool UsoDemandado = false;
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Construye los objetos
        /// </summary>
        private static void Constructor()
        {
            ThreadEjecucionLPR = new ThreadEjecucionLPR("LPR", ThreadPriority.Normal);

            // Cargamos valores de la base de datos
            DataTable dtLPR = AppBD.GetConfiguracionLPR();
            if (dtLPR.Rows.Count == 1)
            {
                CountryCode = dtLPR.Rows[0]["CountryCode"].ValidarEntero();
                AvCharHeight = OEntero.Validar(dtLPR.Rows[0]["AvCharHeight"], 1, 10000, -1);
                DuplicateLines = OEntero.Validar(dtLPR.Rows[0]["DuplicateLines"], 0, 10000, 0);
                Reordenar = OEntero.Validar(dtLPR.Rows[0]["Reordenar"], 0, 10000, 0);
                FilterColor = OEntero.Validar(dtLPR.Rows[0]["FilterColor"], 0, 10000, 0);
                TraceVpar = OEntero.Validar(dtLPR.Rows[0]["TraceVpar"], 0, 10000, 0);
            }
        }

        /// <summary>
        /// Destruye los objetos
        /// </summary>
        private static void Destructor()
        {
            ThreadEjecucionLPR.Stop(1000);
            ThreadEjecucionLPR = null;
        }

        /// <summary>
        /// Carga las propiedades de la base de datos
        /// </summary>
        private static void Inicializar()
        {
            try
            {
                // Inicializamos el motor de LPR
                OMTInterfaceLPR.Inicializar();
                // Inicializamos el motor de búsqueda de LPR             
                int id = OMTInterfaceLPR.Init(OLPRManager.CountryCode, OLPRManager.AvCharHeight, OLPRManager.DuplicateLines, OLPRManager.Reordenar, OLPRManager.FilterColor, OLPRManager.TraceVpar);
                // Almacenamos el valor de incio
                if (id == 1)
                {
                    OLogsVAFunciones.LPR.Debug("LPR", "Iniciado correctamente");
                }
                else
                {
                    OLogsVAFunciones.LPR.Error("LPR", "Error de inicialización");
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, "LPR");
            }

            //ThreadEjecucionLPR.Start();
            ThreadEjecucionLPR.StartPaused();
        }

        /// <summary>
        /// Finaliza la ejecución
        /// </summary>
        private static void Finalizar()
        {
            //ThreadEjecucionLPR.Dispose(1000);
            ThreadEjecucionLPR.Stop(1000);

            // Liberamos memoria reservada para la libreria de LPR, cuando termina de procesar las imagenes
            OMTInterfaceLPR.QueryEnd();
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Resetea la función de visión LPR
        /// </summary>
        internal static void Reset(string codigo = "")
        {
            // Detenemos el hilo 
            ThreadEjecucionLPR.Pause();

            int id = 0;
            if (codigo == "")
            {
                id = OMTInterfaceLPR.Reset();
            }
            else
            {
                id = OMTInterfaceLPR.Reset(codigo);
            }
            // Almacenamos el valor de incio
            if (id == 0)
            {
                OLogsVAFunciones.LPR.Debug("LPR", "Error reseteando el wrapper");
                // Lo realizamos a lo bestia como antes
                // Liberamos memoria reservada para la libreria de LPR, cuando termina de procesar las imagenes
                OMTInterfaceLPR.QueryEnd();
                // Inicializamos el motor de búsqueda de LPR
                OMTInterfaceLPR.Init(OLPRManager.CountryCode, OLPRManager.AvCharHeight, OLPRManager.DuplicateLines, OLPRManager.Reordenar, OLPRManager.FilterColor, OLPRManager.TraceVpar);
            }
            // Reiniciamos el hilo
            ThreadEjecucionLPR.Resume();
        }

        /// <summary>
        /// Se demanda el uso del LPR, por lo que se necesita iniciar las librerías correspondientes
        /// </summary>
        internal static void DemandaUso()
        {
            if (!UsoDemandado)
            {
                UsoDemandado = true;

                // Constructor de las funciones LPR
                OLPRManager.Constructor();

                // Inicialización de las funciones LPR
                OLPRManager.Inicializar();
            }
        }

        /// <summary>
        /// Se elimina la demanda el uso del LPR, por lo que se necesita finalizar las librerías correspondientes
        /// </summary>
        internal static void FinDemandaUso()
        {
            if (UsoDemandado)
            {
                UsoDemandado = false;

                // Finalización de las funciones LPR
                OLPRManager.Finalizar();

                // Destructor de las funciones LPR
                OLPRManager.Destructor();
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase que ejecuta el reconocimiento de las matrículas en un thread
    /// </summary>
    internal class ThreadEjecucionLPR : OThreadLoop
    {
        #region Atributo(s)
        /// <summary>
        /// Indica si se ha de finalizar la ejecución del thread
        /// </summary>
        public bool Finalizar;

        /// <summary>
        /// Cola de elementos a procesar en MTInterface
        /// </summary>
        private int QueueSize = -1;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ThreadEjecucionLPR(string codigo)
            : base(codigo)
        {
            this.Finalizar = false;
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ThreadEjecucionLPR(string codigo, ThreadPriority threadPriority)
            : base(codigo, 1, threadPriority)
        {
            this.Finalizar = false;
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Ejecuta el callback en el mismo thread que la Applicación principal
        /// </summary>
        private void CallBack(OInfoInspeccionLPR infoInspeccionLPR)
        {
            try
            {
                EventArgsResultadoParcial argumentoEvento = new EventArgsResultadoParcial(infoInspeccionLPR); // Creación del argumento del evento
                CallBackResultadoParcial callBack = infoInspeccionLPR.Info.CallBackResultadoParcial; // Obtención del callback

                // Llamada al callback
                if (callBack != null)
                {
                    // Llamada desde el thread principal
                    OThreadManager.SincronizarConThreadPrincipal(new CallBackResultadoParcial(callBack), new object[] { this, argumentoEvento });
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, this.Codigo);
            }
        }
        #endregion

        #region Definición de delegado(s)
        /// <summary>
        /// Delegado de ejecución del callback
        /// </summary>
        /// <param name="callBack"></param>
        /// <param name="argumentoEvento"></param>
        private delegate void DelegadoCallBack(CallBackResultadoParcial callBack, EventArgsResultadoParcial argumentoEvento);
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Método heredado para implementar la ejecución del thread.
        /// Este método se está ejecutando en un bucle. Para salir del bucle hay que devolver finalize a true.
        /// </summary>
        protected override void Ejecucion(ref bool finalize)
        {
            finalize = this.Finalizar;

            if (!this.Finalizar)
            {
                // Guardamos la traza únicamente cuando hay un cambio en el tamaño de la cola de elementos a procesar en MTInterface
                if (this.QueueSize != OMTInterfaceLPR.GetQueueSize() + OMTInterfaceLPR.GetQueueSizeVPARMT())
                {
                    OLogsVAFunciones.LPR.Info(this.Codigo, "Total imágenes: " + (OMTInterfaceLPR.GetQueueSize() + OMTInterfaceLPR.GetQueueSizeVPARMT()).ToString());
                    this.QueueSize = OMTInterfaceLPR.GetQueueSize() + OMTInterfaceLPR.GetQueueSizeVPARMT();
                }

                OPair<OLPRCodeInfo, OLPRData> resultado = null;
                // Consulta de resultados
                do
                {
                    //Get firs element where all results are ready
                    resultado = OMTInterfaceLPR.GetResultado();

                    if (resultado != null)
                    {
                        // Obtengo la información de entrada de la inspección
                        OInfoInspeccionLPR infoInspeccionLPR = (OInfoInspeccionLPR)resultado.Second.ImageInformation.GetObject;
                        infoInspeccionLPR.Resultados = new OResultadoLPR(); // Inicializo los resultados

                        OLPRCodeInfo plateInfo = null;
                        do
                        {
                            plateInfo = resultado.Second.GetFirstItem;
                            if (plateInfo != null)
                            {
                                // Obtengo el resultado de una matricula
                                OResultadoSimpleLPR resultadoParcial = new OResultadoSimpleLPR(plateInfo, resultado.Second.ImageInformation.GetTimestamp);
                                // Añado el resultado de la matricula a la lista de matriculas reconocidas de la imagen
                                infoInspeccionLPR.Resultados.Detalles.Add(resultadoParcial);

                                plateInfo.Dispose();
                            }
                        }
                        while (plateInfo != null);

                        this.CallBack(infoInspeccionLPR); // Llamada al callback

                        // Guardamos la traza
                        OLogsVAFunciones.LPR.Debug(this.Codigo, "Fin de ejecución de la función " + this.Codigo);

                        resultado.First.Dispose();
                        resultado.Second.Dispose();
                        resultado = null;
                    }
                }
                while (resultado != null);

                // Se suspende el thread si no hay más elementos que inspeccionar
                if ((OMTInterfaceLPR.GetQueueSizeVPARMT() == 0) && (OMTInterfaceLPR.GetQueueSize() == 0) && (OMTInterfaceLPR.GetUsedCores() == 0))
                {
                    OLogsVAFunciones.LPR.Debug("Thread de procesado de LPR pausado por no haber imagenes que procesar");
                    this.Pause();
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase que realizara la función de reconocimiento de LPR
    /// </summary>
    public class OFuncionVisionLPR : OFuncionVisionEncolada
    {
        #region Constante(s)
        /// <summary>
        /// Número máximo de inspecciones en la cola de ejecución
        /// </summary>
        private const int MaxInspeccionesEnCola = 8;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Siguiente parametros de entrada a procesar en el LPR
        /// </summary>
        private OParametrosLPR ParametrosLPR;
        /// <summary>
        /// Siguiente imágen a procesar en el LPR
        /// </summary>
        private OImagenBitmap Imagen;
        /// <summary>
        /// Siguiente ruta de imágen a procesar en el LPR
        /// </summary>
        private string RutaImagenTemporal;
        /// <summary>
        /// Prioridad de encolamiento
        /// </summary>
        private bool Prioridad = false;
        /// <summary>
        /// Lista de información adicional incorporada por el controlador externo
        /// </summary>
        private Dictionary<string, object> InformacionAdicional;
        /// <summary>
        /// Para saber la cantidad de imagenes guardadas por disco en cada ejecucion
        /// </summary>
        private int ContadorImagenesPorDisco;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public OFuncionVisionLPR(string codFuncionVision)
            : base(codFuncionVision)
        {
            try
            {
                this.TipoFuncionVision = TipoFuncionVision.LPR;

                // Demanda del uso de LPR
                OLPRManager.DemandaUso();

                this.Valido = true;
                this.ParametrosLPR = new OParametrosLPR();
                this.InformacionAdicional = new Dictionary<string, object>();
                this.ContadorImagenesPorDisco = 0;

                // Cargamos valores de la base de datos
                DataTable dtFuncionVision = AppBD.GetFuncionVision(this.Codigo);
                if (dtFuncionVision.Rows.Count == 1)
                {
                    this.ParametrosLPR.Altura = OEntero.Validar(dtFuncionVision.Rows[0]["NL_Altura"], -1, 10000, -1);
                    this.ParametrosLPR.ActivadoRangoAlturas = OEntero.Validar(dtFuncionVision.Rows[0]["NL_ActivadoRangoAlturas"], 0, 1, 0);
                    this.ParametrosLPR.AlturaMin = OEntero.Validar(dtFuncionVision.Rows[0]["NL_AlturaMin"], 1, 10000, 30);
                    this.ParametrosLPR.AlturaMax = OEntero.Validar(dtFuncionVision.Rows[0]["NL_AlturaMax"], 1, 10000, 60);
                    this.ParametrosLPR.VectorAlturas = new int[2] { this.ParametrosLPR.AlturaMin, this.ParametrosLPR.AlturaMax };
                    this.ParametrosLPR.TimeOut = OEntero.Validar(dtFuncionVision.Rows[0]["NL_TimeOut"], 0, 1000000, 0);
                    this.ParametrosLPR.ActivadaAjusteCorreccion = OEntero.Validar(dtFuncionVision.Rows[0]["NL_ActivadaAjusteCorrecion"], 0, 1, 0);
                    this.ParametrosLPR.CoeficienteHorizontal = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_CoeficienteHorizontal"], -100000, +100000, 0);
                    this.ParametrosLPR.CoeficienteVertical = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_CoeficienteVertical"], -100000, +100000, 0);
                    this.ParametrosLPR.CoeficienteRadial = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_CoeficienteRadial"], -100000, +100000, 0);
                    this.ParametrosLPR.AnguloRotacion = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_AnguloRotacion"], -100000, +100000, 0);
                    this.ParametrosLPR.Distancia = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_Distancia"], 0, +100000, 0);
                    this.ParametrosLPR.CoordIzq = OEntero.Validar(dtFuncionVision.Rows[0]["NL_CoordIzq"], 0, 10000, 0);
                    this.ParametrosLPR.CoordArriba = OEntero.Validar(dtFuncionVision.Rows[0]["NL_CoordArriba"], 0, 10000, 0);
                    this.ParametrosLPR.AlturaVentanaBusqueda = OEntero.Validar(dtFuncionVision.Rows[0]["NL_AlturaVentanaBusqueda"], 0, 10000, 0);
                    this.ParametrosLPR.AnchuraVentanaBusqueda = OEntero.Validar(dtFuncionVision.Rows[0]["NL_AnchuraVentanaBusqueda"], 0, 10000, 0);
                    this.ParametrosLPR.ActivadaMasInformacion = OEntero.Validar(dtFuncionVision.Rows[0]["NL_ActivadaMasInformacion"], 0, 10000, 1);
                    this.ParametrosLPR.OrbitaCorreccionPerspectiva = new OCorreccionPerspectiva(dtFuncionVision.Rows[0]);
                    this.ParametrosLPR.RealizarProcesoPorDisco = OBooleano.Validar(dtFuncionVision.Rows[0]["NL_EjecucionPorDisco"], false);
                    this.ParametrosLPR.RutaEjecucionPorDisco = OTexto.Validar(dtFuncionVision.Rows[0]["NL_RutaTemporalEjecucion"], int.MaxValue, true, false, string.Empty);
                    this.ParametrosLPR.StrictMode = OBooleano.Validar(dtFuncionVision.Rows[0]["NL_StrictMode"], true);
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, "FuncionLPR");
            }
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Cargamos la configuracion de los parametros definidos como entrada, es más eficiente alternar con los de por defecto, para tener mejor tasa de acierto
        /// </summary>
        private void EstablecerConfiguracion(OParametrosLPR parametros)
        {
            // Ejecutamos la configuración
            OMTInterfaceLPR.SetConfiguracion(parametros);
        }
        /// <summary>
        /// Comprueba que el archivo no este en uso
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
        #endregion

        #region Método publicos
        /// <summary>
        /// Realiza un reset de la función de visión de LPR que esta en ejecución
        /// </summary>
        public void Reset()
        {
            // Guardamos la traza
            OLogsVAFunciones.LPR.Debug(this.Codigo, "Se procede a resetear la función de visión " + this.Codigo);

            OLPRManager.Reset(this.Codigo);

            // Ya no existen inspecciones pendientes
            this.ContInspeccionesEnCola = 0;
            this.IndiceFotografia = 0;
            this.ContadorImagenesPorDisco = 0;

            // Se finaliza la ejecución de la función de visión
            this.FuncionEjecutada();

            // Guardamos la traza
            OLogsVAFunciones.LPR.Debug(this.Codigo, "Reset de la función de visión " + this.Codigo + " realizado con éxito");
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Ejecución de la función de Vision Pro de forma síncrona
        /// </summary>
        /// <returns></returns>
        protected override bool EjecucionEncolada()
        {
            bool resultado = false;
            resultado = base.EjecucionEncolada();

            // Se añade una nueva inspección a la cola
            try
            {
                // Añadimos inspecciones de forma bloqueante
                if (OMTInterfaceLPR.IsRunning())
                {
                    if (OMTInterfaceLPR.GetQueueSize() + OMTInterfaceLPR.GetQueueSizeVPARMT() < MaxInspeccionesEnCola)
                    {
                        // Se aumenta el número de inspecciones en cola
                        this.ContInspeccionesEnCola++;
                        this.IndiceFotografia++;
                        // Si vamos por disco tenemos que rellenar la ruta
                        if (this.ParametrosLPR.RealizarProcesoPorDisco)
                        {
                            this.RutaImagenTemporal = Path.Combine(this.ParametrosLPR.RutaEjecucionPorDisco, this.Codigo + "_" + this.ContadorImagenesPorDisco.ToString() + ".bmp");
                            this.ContadorImagenesPorDisco++;
                        }

                        // Corrección de perspectiva
                        OImagenBitmap imagenTrabajo = this.Imagen;
                        OImagenBitmap imagenPerspectivaCorregida = null;
                        if (this.Imagen == null)
                        {
                            ONerualLabsUtils.CorreccionPerspectivaDisco(this.RutaImagenTemporal, this.ParametrosLPR.OrbitaCorreccionPerspectiva);
                        }
                        else if (this.ParametrosLPR.OrbitaCorreccionPerspectiva.Activada)
                        {

                            imagenPerspectivaCorregida = ONerualLabsUtils.CorreccionPerspectivaMemoria(this.Imagen, this.ParametrosLPR.OrbitaCorreccionPerspectiva);
                            imagenTrabajo = imagenPerspectivaCorregida;
                        }

                        // Creamos la información de la imagen
                        OInfoInspeccionLPR infoInspeccionLPR = new OInfoInspeccionLPR(
                                this.Imagen,
                                imagenPerspectivaCorregida,
                                this.ParametrosLPR,
                                new OInfoImagenLPR(this.IdEjecucionActual, this.Codigo, this.IndiceFotografia, DateTime.Now, this.RutaImagenTemporal, AñadirResultadoParcial),
                                new OResultadoLPR(),
                                this.InformacionAdicional);

                        // Se carga la configuración
                        this.EstablecerConfiguracion((OParametrosLPR)this.ParametrosLPR);

                        // Variamos la configuración para la siguiente 
                        object info = infoInspeccionLPR;
                        bool resultCode = false;

                        // Se carga la imagen
                        //  Si tenemos ruta y imagenes es null, pasamos la ruta y sino viceversa
                        if (this.Imagen == null)
                        {
                            // adición de imagen
                            if (!OFicheros.FicheroBloqueado(this.RutaImagenTemporal, 5000))
                            {
                                resultCode = OMTInterfaceLPR.Add(this.Codigo, this.RutaImagenTemporal, false, info, this.Prioridad);
                            }
                            else
                            {
                                OLogsVAFunciones.LPR.Info("FuncionLPR: Fichero de imagen bloqueada");
                            }
                        }
                        else
                        {
                            // En caso de tener que pasar las imagenes al motor por disco antes tenemos que guardarlas
                            if (this.ParametrosLPR.RealizarProcesoPorDisco)
                            {
                                imagenTrabajo.Image.Save(this.RutaImagenTemporal);
                                if (!OFicheros.FicheroBloqueado(this.RutaImagenTemporal, 5000))
                                {
                                    resultCode = OMTInterfaceLPR.Add(this.Codigo, this.RutaImagenTemporal, true, info, this.Prioridad);
                                }
                            }
                            else
                            {
                                // adición de imagen
                                resultCode = OMTInterfaceLPR.Add(this.Codigo, imagenTrabajo.Image, info, this.Prioridad);
                            }
                        }

                        if (!resultCode)
                        {
                            OLogsVAFunciones.LPR.Error("FuncionLPR", "Error al añadir imagen a la cola VPAR. Total imágenes: " + (OMTInterfaceLPR.GetQueueSize() + OMTInterfaceLPR.GetQueueSizeVPARMT()).ToString());
                        }
                        OLogsVAFunciones.LPR.Info("FuncionLPR", "Añadida imagen a la cola VPAR. Total imágenes: " + (OMTInterfaceLPR.GetQueueSize() + OMTInterfaceLPR.GetQueueSizeVPARMT()).ToString());

                        // Se despierta el thread
                        OLPRManager.ThreadEjecucionLPR.Resume();
                    }
                    else
                    {
                        // Temporal hasta que lo soluccionen
                        OLogsVAFunciones.LPR.Info("FuncionLPR: Sobrepasado el limite de imagenes en cola");
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, "FuncionLPR");
            }

            // Se reseta el diccionario de informacción adicional
            this.InformacionAdicional = new Dictionary<string, object>();

            return resultado;
        }

        /// <summary>
        /// Indica que hay inspecciones pendientes de ejecución
        /// </summary>
        /// <returns></returns>
        public override bool HayInspeccionesPendientes()
        {
            bool resultado = base.HayInspeccionesPendientes();

            resultado |= OMTInterfaceLPR.GetQueueSize(this.Codigo) > 0;
            resultado |= this.ContInspeccionesEnCola > 0;

            return resultado;
        }

        /// <summary>
        /// Resetea la cola de ejecución
        /// </summary>
        public override void ResetearColaEjecucion()
        {
            base.ResetearColaEjecucion();
            OMTInterfaceLPR.Reset(this.Codigo);
            this.InformacionAdicional = new Dictionary<string, object>();
        }

        /// <summary>
        /// Función para la actualización de parámetros de entrada
        /// </summary>
        /// <param name="ParamName">Nombre identificador del parámetro</param>
        /// <param name="ParamValue">Nuevo valor del parámetro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public override bool SetEntrada(string codigo, object valor, OEnumTipoDato tipoVariable)
        {
            bool resultado = false;

            try
            {
                if (codigo == "Imagen")
                {
                    this.Imagen = (OImagenBitmap)valor;
                }
                else if (codigo == "Parametros")
                {
                    this.ParametrosLPR = (OParametrosLPR)valor;
                }
                else if (codigo == "RutaImagen")
                {
                    this.RutaImagenTemporal = (string)valor;
                }
                else if (codigo == "Prioridad")
                {
                    this.Prioridad = (bool)valor;
                }
                else
                {
                    this.InformacionAdicional[codigo] = valor;
                    //throw new Exception("Error en la asignación del parámetro '" + entrada.Nombre + "' a la función '" + this.Codigo + "'. No se admite este tipo de parámetros.");
                }
                resultado = true;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, this.Codigo);
            }
            return resultado;
        }

        /// <summary>
        /// Función para la actualización de parámetros de entrada
        /// </summary>
        /// <param name="ParamName">Nombre identificador del parámetro</param>
        /// <param name="ParamValue">Nuevo valor del parámetro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public override bool SetEntrada(EnumTipoEntradaFuncionVision tipoEntrada, object valor, OEnumTipoDato tipoVariable)
        {
            return SetEntrada(tipoEntrada.Nombre, valor, tipoVariable);
        }
        #endregion
    }

    /// <summary>
    /// Clase que contiene la información referente a la inspección
    /// </summary>
    /// <typeparam name="TInfo"></typeparam>
    /// <typeparam name="TParametros"></typeparam>
    /// <typeparam name="TResultados"></typeparam>
    public class OInfoInspeccionLPR : OInfoInspeccion<OImagenBitmap, OParametrosLPR, OInfoImagenLPR, OResultadoLPR>
    {
        #region Atributo(s)
        /// <summary>
        /// Imagen inspeccionada
        /// </summary>
        public OImagenBitmap ImagenPerspectivaCorregida;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OInfoInspeccionLPR()
            : base()
        {
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="info"></param>
        /// <param name="parametros"></param>
        /// <param name="resultados"></param>
        public OInfoInspeccionLPR(OImagenBitmap imagen, OImagenBitmap imagenPerspectivaCorregida, OParametrosLPR parametros, OInfoImagenLPR info, OResultadoLPR resultados, Dictionary<string, object> informacionAdicional)
            : base(imagen, parametros, info, resultados, informacionAdicional)
        {
            this.ImagenPerspectivaCorregida = imagenPerspectivaCorregida;
        }
        #endregion
    }

    /// <summary>
    /// Clase que contiene los parametros de configuracion del LPR
    /// </summary>
    public class OParametrosLPR
    {
        #region Atributo(s)
        /// <summary>
        /// Altura del caracter
        /// </summary>
        public int Altura;
        /// <summary>
        /// Para tener en cuenta el rango de alturas
        /// </summary>
        public int ActivadoRangoAlturas;
        /// <summary>
        /// Altura Minima
        /// </summary>
        public int AlturaMin;
        /// <summary>
        /// Altura Máxima
        /// </summary>
        public int AlturaMax;
        /// <summary>
        /// Vector que contendra las alturas
        /// </summary>
        public Int32[] VectorAlturas;
        /// <summary>
        /// timeout de ejecución
        /// </summary>
        public int TimeOut;
        /// <summary>
        /// activa el ajuste de la correcion
        /// </summary>
        public int ActivadaAjusteCorreccion;
        /// <summary>
        /// Coeficiente de Correccion de la perspectiva Horizontal
        /// </summary>
        public float CoeficienteHorizontal;
        /// <summary>
        /// Coeficiente de Correccion de la perspectiva Vertical
        /// </summary>
        public float CoeficienteVertical;
        /// <summary>
        /// Coeficiente para el ojo de pez
        /// </summary>
        public float CoeficienteRadial;
        /// <summary>
        /// Coeficiente de la corrección del ángulo de rotación
        /// </summary>
        public float AnguloRotacion;
        /// <summary>
        /// Distancia al código desde la camara en metros
        /// </summary>
        public float Distancia;
        /// <summary>
        /// Coordenada izquierda ventana
        /// </summary>
        public int CoordIzq;
        /// <summary>
        /// Coordenada superior ventana
        /// </summary>
        public int CoordArriba;
        /// <summary>
        /// Altura de la ventana de búsqueda
        /// </summary>
        public int AlturaVentanaBusqueda;
        /// <summary>
        /// Anchura de la ventana de búsqueda
        /// </summary>
        public int AnchuraVentanaBusqueda;
        /// <summary>
        /// Se le indica si se desea buscar más información extra en la imagén
        /// </summary>
        public int ActivadaMasInformacion;
        /// <summary>
        /// Para saber si han habido modificaciones
        /// </summary>
        public bool Modificado;
        /// <summary>
        /// Escala
        /// </summary>
        public int Escala;
        /// <summary>
        /// Parámetros de corrección de perspectiva de Orbita
        /// </summary>
        public OCorreccionPerspectiva OrbitaCorreccionPerspectiva;
        /// <summary>
        /// Para pasar a las librerias una ruta de imagen y no el bitmap
        /// </summary>
        public bool RealizarProcesoPorDisco;
        /// <summary>
        /// Ruta utilizada para pasar la imagen por disco
        /// </summary>
        public string RutaEjecucionPorDisco;
        /// <summary>
        /// Modo estricto de búsqueda de matriculas multipais
        /// </summary>
        public bool StrictMode;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase sin parámetros
        /// </summary>
        public OParametrosLPR()
        {
            this.Altura = -1;
            this.ActivadoRangoAlturas = 0;
            this.AlturaMin = 30;
            this.AlturaMax = 60;
            this.VectorAlturas = new Int32[2];
            this.VectorAlturas[0] = AlturaMin;
            this.VectorAlturas[1] = AlturaMax;
            this.TimeOut = 0;
            this.ActivadaAjusteCorreccion = 0;
            this.CoeficienteHorizontal = 0;
            this.CoeficienteVertical = 0;
            this.CoeficienteRadial = 0;
            this.AnguloRotacion = 0;
            this.Distancia = 0;
            this.CoordArriba = 0;
            this.CoordIzq = 0;
            this.AlturaVentanaBusqueda = 0;
            this.AnchuraVentanaBusqueda = 0;
            this.ActivadaMasInformacion = 1;
            this.Modificado = true;
            this.Escala = 0;
            this.OrbitaCorreccionPerspectiva = new OCorreccionPerspectiva();
            this.RealizarProcesoPorDisco = false;
            this.RutaEjecucionPorDisco = Path.GetTempPath();
            this.StrictMode = true;
        }
        #endregion Constructores
    }

    /// <summary>
    /// Esta clase contendra la información que queremos pasar con la imagen a la función LPR para recogerla cuando tengamos el resultado
    /// </summary>
    public class OInfoImagenLPR : OConvertibleXML
    {
        #region Propiedades(s)
        /// <summary>
        /// Contiene la información de la identificacion a la que pertenece
        /// </summary>
        private long _IdEjecucionActual;
        /// <summary>
        /// Contiene la información de la identificacion a la que pertenece
        /// </summary>
        public long IdEjecucionActual
        {
            get { return _IdEjecucionActual; }
            set
            {
                this._IdEjecucionActual = value;
                this.Propiedades["IdEjecucionActual"] = value;
            }
        }

        /// <summary>
        /// Contiene la información de la cámara que se le pasa en la imagen
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Contiene la información de la cámara que se le pasa en la imagen
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set
            {
                this._Codigo = value;
                this.Propiedades["CodigoCamara"] = value;
            }
        }

        /// <summary>
        /// Contiene el indice de la imagen añadida
        /// </summary>
        private int _IndiceImagen;
        /// <summary>
        /// Contiene el indice de la imagen añadida
        /// </summary>
        public int IndiceImagen
        {
            get { return _IndiceImagen; }
            set
            {
                this._IndiceImagen = value;
                this.Propiedades["IndiceImagen"] = value;
            }
        }

        /// <summary>
        /// Contiene la fecha exacta en la que se adquirio la imagen
        /// </summary>
        private DateTime _MomentoImagen;
        /// <summary>
        /// Contiene la fecha exacta en la que se adquirio la imagen
        /// </summary>
        public DateTime MomentoImagen
        {
            get { return _MomentoImagen; }
            set
            {
                this._MomentoImagen = value;
                this.Propiedades["MomentoImagen"] = value;
            }
        }

        /// <summary>
        /// Ruta de la imagen temporal
        /// </summary>
        private string _RutaImagenTemporal;
        /// <summary>
        /// Ruta de la imagen temporal
        /// </summary>
        public string RutaImagenTemporal
        {
            get { return _RutaImagenTemporal; }
            set
            {
                this._RutaImagenTemporal = value;
                this.Propiedades["RutaImagenTemporal"] = value;
            }
        }

        /// <summary>
        /// CallBack donde mandar el resultado parcial
        /// </summary>
        internal CallBackResultadoParcial CallBackResultadoParcial;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public OInfoImagenLPR()
        {
            this.IdEjecucionActual = 0;
            this.Codigo = string.Empty;
            this.IndiceImagen = 0;
            this.MomentoImagen = DateTime.Now;
            this.RutaImagenTemporal = string.Empty;
            this.CallBackResultadoParcial = null;
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="codigo">camara que adquiere la imagen</param>
        public OInfoImagenLPR(long idEjecucionActual, string codigo, int indice, DateTime momentoImagen, string rutaImagenTemporal, CallBackResultadoParcial callBackResultadoParcial)
        {
            this.IdEjecucionActual = idEjecucionActual;
            this.Codigo = codigo;
            this.IndiceImagen = indice;
            this.MomentoImagen = momentoImagen;
            this.RutaImagenTemporal = rutaImagenTemporal;
            this.CallBackResultadoParcial = callBackResultadoParcial;
        }
        #endregion
    }

    /// <summary>
    /// Lista de resultados de todas las matriculas de una imagen
    /// </summary>
    public class OResultadoLPR : OConvertibleXML
    {
    }

    /// <summary>
    /// Clase que contiene los resultados que se reciben de la funcion LPR para una imagen pasada 
    /// </summary>
    public class OResultadoSimpleLPR : OConvertibleXML
    {
        #region Propiedad(es)
        /// <summary>
        /// Contiene la cadena la matrícula del vehículo
        /// </summary>
        private string _Matricula;
        /// <summary>
        /// Contiene la cadena la matrícula del vehículo
        /// </summary>
        public string Matricula
        {
            get { return _Matricula; }
            set
            {
                this._Matricula = value;
                this.Propiedades["Matricula"] = value;
            }
        }

        /// <summary>
        /// Fiabilidad de la matrícula
        /// </summary>
        private int _FiabilidadMatricula;
        /// <summary>
        /// Fiabilidad de la matrícula
        /// </summary>
        public int FiabilidadMatricula
        {
            get { return _FiabilidadMatricula; }
            set
            {
                this._FiabilidadMatricula = value;
                this.Propiedades["FiabilidadMatricula"] = value;
            }
        }

        /// <summary>
        /// Altura letras
        /// </summary>
        private int _AlturaLetrasMatricula;
        /// <summary>
        /// Altura letras
        /// </summary>
        public int AlturaLetrasMatricula
        {
            get { return _AlturaLetrasMatricula; }
            set
            {
                this._AlturaLetrasMatricula = value;
                this.Propiedades["AlturaLetrasMatricula"] = value;
            }
        }

        /// <summary>
        /// Fecha en la que se encolo a la cola de LPR (dada por él)
        /// </summary>
        private DateTime _FechaEncolamiento;
        /// <summary>
        /// Fecha en la que se encolo a la cola de LPR (dada por él)
        /// </summary>
        public DateTime FechaEncolamiento
        {
            get { return _FechaEncolamiento; }
            set
            {
                this._FechaEncolamiento = value;
                this.Propiedades["FechaEncolamiento"] = value;
            }
        }

        /// <summary>
        /// Tiempo de proceso
        /// </summary>
        private int _TiempoDeProceso;
        /// <summary>
        /// Tiempo de proceso
        /// </summary>
        public int TiempoDeProceso
        {
            get { return _TiempoDeProceso; }
            set
            {
                this._TiempoDeProceso = value;
                this.Propiedades["TiempoDeProceso"] = value;
            }
        }

        /// <summary>
        /// Posicion Top matricula
        /// </summary>
        private int _TopPosicionMatricula;
        /// <summary>
        /// Posicion Top matricula
        /// </summary>
        public int TopPosicionMatricula
        {
            get { return _TopPosicionMatricula; }
            set
            {
                this._TopPosicionMatricula = value;
                this.Propiedades["TopPosicionMatricula"] = value;
            }
        }

        /// <summary>
        /// Posicion Bottom matricula
        /// </summary>
        public int _BottomPosicionMatricula;
        /// <summary>
        /// Posicion Bottom matricula
        /// </summary>
        public int BottomPosicionMatricula
        {
            get { return _BottomPosicionMatricula; }
            set
            {
                this._BottomPosicionMatricula = value;
                this.Propiedades["BottomPosicionMatricula"] = value;
            }
        }

        /// <summary>
        /// Posicion Right matricula
        /// </summary>
        private int _RightPosicionMatricula;
        /// <summary>
        /// Posicion Right matricula
        /// </summary>
        public int RightPosicionMatricula
        {
            get { return _RightPosicionMatricula; }
            set
            {
                this._RightPosicionMatricula = value;
                this.Propiedades["RightPosicionMatricula"] = value;
            }
        }

        /// <summary>
        /// Posicion Left matricula
        /// </summary>
        private int _LeftPosicionMatricula;
        /// <summary>
        /// Posicion Left matricula
        /// </summary>
        public int LeftPosicionMatricula
        {
            get { return _LeftPosicionMatricula; }
            set
            {
                this._LeftPosicionMatricula = value;
                this.Propiedades["LeftPosicionMatricula"] = value;
            }
        }

        /// <summary>
        /// <summary>Codigo del pais de la matrículaPosicion Left matricula
        /// </summary>
        private int _CodigoPais;
        /// <summary>
        /// <summary>Codigo del pais de la matrículaPosicion Left matricula
        /// </summary>
        public int CodigoPais
        {
            get { return _CodigoPais; }
            set
            {
                this._CodigoPais = value;
                this.Propiedades["CodigoPais"] = value;
                if (value == 0)
                {
                    this._Verificado = false;
                }
                else
                {
                    this._Verificado = true;
                }
            }
        }

        /// <summary>
        /// Si el Codigo de pais es distinto de 0
        /// </summary>
        private bool _Verificado;
        /// <summary>
        /// Si el Codigo de pais es distinto de 0
        /// </summary>
        public bool Verificado
        {
            get { return _Verificado; }
        }
        /// <summary>
        /// <summary>Devuelve el pais que cumple la sintáxis
        /// </summary>
        private string _PaisSintaxis3Caracteres;
        /// <summary>
        /// <summary>Codigo del pais de la matrículaPosicion Left matricula
        /// </summary>
        public string PaisSintaxis3Caracteres
        {
            get { return _PaisSintaxis3Caracteres; }
            set
            {
                this._PaisSintaxis3Caracteres = value;
                this.Propiedades["PaisSintaxis3Caracteres"] = value;
            }
        }
        /// <summary>
        /// <summary>Devuelve el pais que cumple la sintáxis
        /// </summary>
        private string _PaisSintaxis2Caracteres;
        /// <summary>
        /// <summary>Codigo del pais de la matrículaPosicion Left matricula
        /// </summary>
        public string PaisSintaxis2Caracteres
        {
            get { return _PaisSintaxis2Caracteres; }
            set
            {
                this._PaisSintaxis2Caracteres = value;
                this.Propiedades["PaisSintaxis2Caracteres"] = value;
            }
        }

        /// <summary>
        /// Número de carácters de la matrícula
        /// </summary>
        private int _NumCaracteres;
        /// <summary>
        /// Número de carácters de la matrícula
        /// </summary>
        public int NumCaracteres
        {
            get { return _NumCaracteres; }
            set
            {
                this._NumCaracteres = value;
                this.Propiedades["NumCaracteres"] = value;
            }
        }

        /// <summary>
        /// Contiene las fiabilidades de cada letra individual
        /// </summary>
        private float[] _FiabilidadesLetras;
        /// <summary>
        /// Número de carácters de la matrícula
        /// </summary>
        public float[] FiabilidadesLetras
        {
            get { return _FiabilidadesLetras; }
            set
            {
                this._FiabilidadesLetras = value;
                this.Propiedades["FiabilidadesLetras"] = value;
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public OResultadoSimpleLPR()
        {
            this.Matricula = string.Empty;
            this.FiabilidadMatricula = 0;
            this.AlturaLetrasMatricula = 0;
            this.TiempoDeProceso = 0;
            this.TopPosicionMatricula = 0;
            this.BottomPosicionMatricula = 0;
            this.LeftPosicionMatricula = 0;
            this.RightPosicionMatricula = 0;
            this.FechaEncolamiento = DateTime.Now;
            this.CodigoPais = 0;
            this.PaisSintaxis3Caracteres = string.Empty;
            this.PaisSintaxis2Caracteres = string.Empty;
            this.NumCaracteres = 0;
            this.FiabilidadesLetras = new float[0];
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        public OResultadoSimpleLPR(OLPRCodeInfo resultadoImagen, DateTime fechaEncola)
        {
            try
            {
                this.Matricula = OTexto.Validar(resultadoImagen.GetPlateNumber);
                this.FiabilidadMatricula = OEntero.Validar(resultadoImagen.GetGlobalConfidence);
                this.AlturaLetrasMatricula = OEntero.Validar(resultadoImagen.GetAverageCharacterHeigth);
                this.TiempoDeProceso = OEntero.Validar(resultadoImagen.GetProcessingTime);
                this.TopPosicionMatricula = OEntero.Validar(resultadoImagen.GetTopPlatePosition);
                this.BottomPosicionMatricula = OEntero.Validar(resultadoImagen.GetBottomPlatePosition);
                this.LeftPosicionMatricula = OEntero.Validar(resultadoImagen.GetLeftPlatePosition);
                this.RightPosicionMatricula = OEntero.Validar(resultadoImagen.GetRightPlatePosition);
                this.FechaEncolamiento = fechaEncola;
                this.PaisSintaxis3Caracteres = this.ConversionCodigoPais3(OEntero.Validar(resultadoImagen.GetPlateFormat));
                this.PaisSintaxis2Caracteres = this.ConversionCodigoPais2(OEntero.Validar(resultadoImagen.GetPlateFormat));
                this.CodigoPais = OEntero.Validar(resultadoImagen.GetPlateFormat);
                this.NumCaracteres = OEntero.Validar(resultadoImagen.GetNumCharacters);

                // Si tenemos código identificado , obtenemos las fiabilidades de cada una de las letras
                float[] fiabilidadesLetras = new float[0];
                if (!string.IsNullOrEmpty(this.Matricula) && (resultadoImagen.GetCharConfidence() != null) && (resultadoImagen.GetCharConfidence().Length > 0) && (resultadoImagen.GetCharConfidence().Length == this.NumCaracteres))
                {
                    fiabilidadesLetras = new float[this.NumCaracteres];

                    float[] fiabilidades = resultadoImagen.GetCharConfidence();
                    this.FiabilidadesLetras = new float[fiabilidades.Length];
                    for (int i = 0; i < fiabilidades.Length; i++)
                    {
                        fiabilidadesLetras[i] = (float)ODecimal.Validar(fiabilidades[i]);
                    }
                }
                this.FiabilidadesLetras = fiabilidadesLetras;
            }
            catch (Exception exception)
            {
                // En caso de que se produzca cualquier error no contemplado, descartaremos el resultado recibido permitiendo continuar la ejecución
                this.Matricula = string.Empty;
                this.FiabilidadMatricula = 0;
                this.AlturaLetrasMatricula = 0;
                this.TiempoDeProceso = 0;
                this.TopPosicionMatricula = 0;
                this.BottomPosicionMatricula = 0;
                this.LeftPosicionMatricula = 0;
                this.RightPosicionMatricula = 0;
                this.FechaEncolamiento = DateTime.Now;
                this.PaisSintaxis3Caracteres = string.Empty;
                this.PaisSintaxis2Caracteres = string.Empty;
                this.CodigoPais = 0;
                this.NumCaracteres = 0;
                this.FiabilidadesLetras = new float[0];
                OLogsVAFunciones.LPR.Info(exception, "FuncionLPR");
            }
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Conversión de código de pais de NL a estándar de 3 carácteres
        /// </summary>
        /// <param name="codigoPaisNL"></param>
        /// <returns></returns>
        private string ConversionCodigoPais3(int codigoPaisNL)
        {
            string resultado = string.Empty;
            OQuartet<string, string, string, int> registroPais = OLPRManager.AsignacionPaisesNL.Find(tabla => tabla.Fourth == codigoPaisNL);
            if (registroPais is OQuartet<string, string, string, int>)
            {
                resultado = registroPais.First;
            }
            return resultado;
        }

        /// <summary>
        /// Conversión de código de pais de NL a estándar de 2 carácteres
        /// </summary>
        /// <param name="codigoPaisNL"></param>
        /// <returns></returns>
        private string ConversionCodigoPais2(int codigoPaisNL)
        {
            string resultado = string.Empty;
            OQuartet<string, string, string, int> registroPais = OLPRManager.AsignacionPaisesNL.Find(tabla => tabla.Fourth == codigoPaisNL);
            if (registroPais is OQuartet<string, string, string, int>)
            {
                resultado = registroPais.Second;
            }
            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Define el conjunto de tipos de entradas de las funciones de visión LPR
    /// </summary>
    public class EntradasFuncionesVisionLPR : TipoEntradasFuncionesVision
    {
        #region Atributo(s)
        /// <summary>
        /// Ruta en disco de la imagen de entrada
        /// </summary>
        public static EnumTipoEntradaFuncionVision RutaImagen = new EnumTipoEntradaFuncionVision("RutaImagen", "Ruta en disco de la imagen de entrada", 102);
        /// <summary>
        /// Prioridad de encolamiento
        /// </summary>
        public static EnumTipoEntradaFuncionVision Prioridad = new EnumTipoEntradaFuncionVision("Prioridad", "Prioridad de encolamiento", 203);
        #endregion
    }
}
