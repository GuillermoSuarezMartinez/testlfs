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
    /// Autenticación con Active Direcotry.
    /// </summary>
    public class OLogonActiveDirectory : OLogon
    {
        #region Métodos públicos
        /// <summary>
        /// Autenticación con Active Directory.
        /// </summary>
        /// <returns>Mensaje de validación de argumento Orbita.Controles.Autenticacion.EstadoAutenticacion.</returns>
        public override EstadoAutenticacion Validar()
        {
            EstadoAutenticacion estado = null;
            try
            {
                using (System.DirectoryServices.DirectoryEntry deDirEntry = new System.DirectoryServices.DirectoryEntry("LDAP://" + this.dominio, this.usuario + "@" + this.dominio, this.password, System.DirectoryServices.AuthenticationTypes.Secure))
                {
                    estado = new EstadoAutenticacionOK();
                }
            }
            catch (System.Exception ex)
            {
                estado = new EstadoAutenticacionNOK("Error en la autenticación LDAP: " + ex.ToString());
            }
            return estado;
        }
        #endregion
    }
}