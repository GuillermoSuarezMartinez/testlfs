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
using System;
using System.DirectoryServices;
namespace Orbita.Controles.Autenticacion
{
    /// <summary>
    /// Autenticación con Active Direcotry.
    /// </summary>
    public class OLogonAD : OLogon
    {
        /// <summary>
        /// Validación con Active Directory.
        /// </summary>
        /// <returns>Mensaje de validación de argumento Orbita.Controles.Autenticacion.OEstadoValidacion.</returns>
        public override AutenticacionChangedEventArgs Validar()
        {
            AutenticacionChangedEventArgs args = new AutenticacionChangedEventArgs();
            OEstadoValidacion validacion = new OEstadoValidacion("NOK", "Sin validar", "Aceptar");
            try
            {
                using (DirectoryEntry deDirEntry = new DirectoryEntry("LDAP://" + this.dominio, this.usuario + "@" + this.dominio, this.password, AuthenticationTypes.Secure))
                {
                    try
                    {
                        string entry = deDirEntry.Name;
                        validacion.Resultado = "OK";
                        validacion.Mensaje = "";
                    }
                    catch (Exception ex)
                    {
                        validacion.Mensaje = "Error en el login LDAP " + ex.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                validacion.Mensaje = "Error al validar: " + ex.ToString();
            }
            args.Estado = validacion;
            return args;
        }
    }
}