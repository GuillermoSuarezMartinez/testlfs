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
using System.Data;
using Orbita.MS;
namespace Orbita.Controles.Autenticacion
{
    /// <summary>
    /// Autenticación con base de datos.
    /// </summary>
    public class OLogonBBDD : OLogon
    {
        /// <summary>
        /// Validación con la base de datos.
        /// </summary>
        /// <returns>Mensaje de validación de argumento Orbita.Controles.Autenticacion.OEstadoValidacion.</returns>
        public override AutenticacionChangedEventArgs Validar()
        {
            AutenticacionChangedEventArgs args = new AutenticacionChangedEventArgs();
            OEstadoValidacion validacion = new OEstadoValidacion("NOK", "Sin validar", "Aceptar");
            try
            {
                DataTable dt = AppBD.Get_Autenticacion_BBDD(this.usuario);
                if (dt.Rows.Count > 0)
                {
                    if (this.password == OCifrado.DesencriptarTexto(dt.Rows[0]["FWUP_PASS"].ToString()))
                    {
                        validacion.Estado = "OK";
                        validacion.Mensaje = "";
                    }
                    else
                    {
                        validacion.Mensaje = "Password incorrecto";
                    }
                }
                else
                {
                    validacion.Mensaje = "No existe el usuario";
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