﻿//***********************************************************************
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
    /// Autenticación con base de datos.
    /// </summary>
    public class OLogonBBDD : OLogon
    {
        #region Métodos públicos
        /// <summary>
        /// Autenticación con la base de datos.
        /// </summary>
        /// <returns>Mensaje de validación de argumento Orbita.Controles.Autenticacion.OLogonBBDD.</returns>
        public override EstadoAutenticacion Validar()
        {
            EstadoAutenticacion estado = null;
            try
            {
                System.Data.DataTable dt = AppBD.GetAutenticacionBBDD(this.usuario);
                if (dt.Rows.Count > 0)
                {
                    if (this.password == Orbita.MS.OCifrado.DesencriptarTexto(dt.Rows[0]["FWUP_PASS"].ToString()))
                    {
                        estado = new EstadoAutenticacionOK();
                    }
                    else
                    {
                        estado = new EstadoAutenticacionNOK(MensajesAutenticacion.ContraseñaIncorrecta);
                    }
                }
                else
                {
                    estado = new EstadoAutenticacionNOK(MensajesAutenticacion.UsuarioIncorrecto);
                }
            }
            catch (System.Exception ex)
            {
                estado = new EstadoAutenticacionNOK("Error al validar: " + ex.ToString());
            }
            return estado;
        }
        #endregion
    }
}