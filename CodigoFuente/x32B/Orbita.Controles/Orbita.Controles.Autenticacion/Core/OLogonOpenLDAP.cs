//***********************************************************************
// Assembly         : Orbita.Controles.Autenticacion
// Author           : jljuan
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Autenticacion
{
    /// <summary>
    /// Autenticación con Open LDAP.
    /// </summary>
    public class OLogonOpenLDAP : OLogon
    {
        #region Métodos protegidos
        /// <summary>
        /// Método de validación con Open LDAP.
        /// </summary>
        /// <returns></returns>
        public override EstadoAutenticacion Validar()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}