using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS
{
    /// <summary>
    /// Clase base para la gestión de licencias
    /// </summary>
    public class OLicenciaUSB : OLicenciaBase
    {
        #region Atributos
        protected Type _tipo = typeof(OLicenciaUSB);
        #endregion Atributos

        #region Propiedades

        #endregion Propiedades

        #region Delegados

        #endregion Delegados

        #region Eventos

        #endregion Eventos

        #region Constructores
        public OLicenciaUSB()
            : base()
        {
            this.TipoLicencia = OTipoLicencia.USB;
        }
        #endregion Constructores

        #region Métodos públicos

        #endregion Métodos públicos

        #region Métodos privados

        #endregion Métodos privados

    }
}
