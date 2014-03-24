using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS.Clases.Licencias
{
    public class OLicenciaHaspHL4 : OLicenciaHaspBase
    {
        #region Atributos
        protected Type _tipo = typeof(OLicenciaHaspHL4);
        #endregion Atributos
        #region Propiedades
        #endregion Propiedades
        #region Constructores
        public OLicenciaHaspHL4():base()
        {
            this.TipoLicencia = OTipoLicencia.HASP;
            this._soporteSerie = new OLicenciaHaspSoporteSerie(
                "h4+i0gwBGw6ds0AO4X6/UImSTXnkiNGAvhbBfKFuFBCODVMXGAufoHeM6/0wol6eUSXmoOK+cVkgsJjO" + 
                "H+6skQSmD8pL4pzY0I1QpQbg1Cwn8fZGrS4oA5jbKKzsB0vfSvwc3erJZLTBN42wrCC0bF66PuOOq2M+" + 
                "D79nvWHlnEya8E9AUy0/aDhc3dheFuByY0gEmeRfsOVkHJxh+ATjufSLpeWiAixjPDghPoRGhI3nBZD/" + 
                "2DEfZ4MFJ8bJ699waHfW2KIrcoROFa373k2RzPFDDmWscm/KwxO2Iif/IvVeYv3XseYtUqFdCdasRyN8" + 
                "YQ6ach3Uqk6vGCz2Mkq1boGZmzu4/i9Pf7goGlDhq40b2Jk8Q6CH3Q7LsL/0PuCXJQJMOq7sjfESiHB9" + 
                "d3OpOIXIyc1L5M8xILvgTF7/tNFj2cx3iz9QuFRFCN3529MQeohWU+OOuBlVfZOtTVxEmcVLZ01Ur/0X" + 
                "vOlz9Ze+KCEiHr9q7gh9vk/NJX7dY8Cf5yuszFgwKwEqO4MhdJzZ4pjFDWmwPwj06VouNXLv4g9ltsI/" + 
                "osjX4GEUh3WaDjgd4Tm9Iu5OBWlaYOrLvoGWmXqrnRYfDCKtJ/samWAPA/Dhrak7OSe4VqrjKt3Q9qEt" + 
                "hI7hHYw7JV3Lz4ZA/JcR22iN3DNQk2XO20AP5tC6Aedx2/ZgF60oW2MjAqUhbbDKnXHDp0JXkagzkLAK" + 
                "rtdQzTYuw9FlpKaauQu3GBSloBorW8HGbeOCkDBh1vA1y2UP8wVzvFcHFV/BbFBrLlWfa3mgYCubLSkI" + 
                "zb+YrN+B6ezIr00zKNkLjQRfGOc5G4wAk5N0j4Yo8NPKGVFSdNPgYiP+J/KYyT5LoRCGxYD1dSDud920" + 
                "SR8fdka55x2EEEWYZGbeCKwA9kKojpK+x56ot2TuaIh2QwhBe0IoT0z+wbc=", "", 4);
        }

        /*HaspFeature feature = HaspFeature.FromProgNum(2);
feature.SetOptions(FeatureOptions.Process, FeatureOptions.Default);
feature.SetOptions(FeatureOptions.IgnoreTS, FeatureOptions.Default);
feature.SetOptions(FeatureOptions.Classic, FeatureOptions.Default);

string vendorCode = 
"h4+i0gwBGw6ds0AO4X6/UImSTXnkiNGAvhbBfKFuFBCODVMXGAufoHeM6/0wol6eUSXmoOK+cVkgsJjO" + 
"H+6skQSmD8pL4pzY0I1QpQbg1Cwn8fZGrS4oA5jbKKzsB0vfSvwc3erJZLTBN42wrCC0bF66PuOOq2M+" + 
"D79nvWHlnEya8E9AUy0/aDhc3dheFuByY0gEmeRfsOVkHJxh+ATjufSLpeWiAixjPDghPoRGhI3nBZD/" + 
"2DEfZ4MFJ8bJ699waHfW2KIrcoROFa373k2RzPFDDmWscm/KwxO2Iif/IvVeYv3XseYtUqFdCdasRyN8" + 
"YQ6ach3Uqk6vGCz2Mkq1boGZmzu4/i9Pf7goGlDhq40b2Jk8Q6CH3Q7LsL/0PuCXJQJMOq7sjfESiHB9" + 
"d3OpOIXIyc1L5M8xILvgTF7/tNFj2cx3iz9QuFRFCN3529MQeohWU+OOuBlVfZOtTVxEmcVLZ01Ur/0X" + 
"vOlz9Ze+KCEiHr9q7gh9vk/NJX7dY8Cf5yuszFgwKwEqO4MhdJzZ4pjFDWmwPwj06VouNXLv4g9ltsI/" + 
"osjX4GEUh3WaDjgd4Tm9Iu5OBWlaYOrLvoGWmXqrnRYfDCKtJ/samWAPA/Dhrak7OSe4VqrjKt3Q9qEt" + 
"hI7hHYw7JV3Lz4ZA/JcR22iN3DNQk2XO20AP5tC6Aedx2/ZgF60oW2MjAqUhbbDKnXHDp0JXkagzkLAK" + 
"rtdQzTYuw9FlpKaauQu3GBSloBorW8HGbeOCkDBh1vA1y2UP8wVzvFcHFV/BbFBrLlWfa3mgYCubLSkI" + 
"zb+YrN+B6ezIr00zKNkLjQRfGOc5G4wAk5N0j4Yo8NPKGVFSdNPgYiP+J/KYyT5LoRCGxYD1dSDud920" + 
"SR8fdka55x2EEEWYZGbeCKwA9kKojpK+x56ot2TuaIh2QwhBe0IoT0z+wbc=";

Hasp hasp = new Hasp(feature);
HaspStatus status = hasp.Login(vendorCode);

if (HaspStatus.StatusOk != status)
{
    //handle error
}*/
        #endregion Constructores
    }
}
