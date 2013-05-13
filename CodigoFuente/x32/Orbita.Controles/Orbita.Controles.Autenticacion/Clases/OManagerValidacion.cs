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
using System.Windows.Forms;
namespace Orbita.Controles.Autenticacion
{
    public class OManagerValidacion
    {
        #region Delegados y eventos
        public delegate void ODelegadoManagerValidacion(object sender, AutenticacionChangedEventArgs e);
        public event ODelegadoManagerValidacion OValidacion;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.OManagerValidacion.
        /// </summary>
        public OManagerValidacion() { }
        #endregion

        #region Métodos públicos
        public void Mostrar(Form parent, bool mostrar)
        {
            if (!mostrar)
            {
                OEstadoValidacion validar = new OEstadoValidacion("OK", "", "");
                AutenticacionChangedEventArgs args = new AutenticacionChangedEventArgs(validar);
                this.OValidacion(this, args);
            }
            else
            {
                FrmValidar frm = new FrmValidar(parent);
                frm.OValidacionControl += new FrmValidar.ODelegadoValidacion(frm_OValidacionControl);
                frm.Show();
            }
        }
        #endregion

        #region Manejadores de eventos
        void frm_OValidacionControl(object sender, AutenticacionChangedEventArgs e)
        {
            this.OValidacion(sender, e);
        }
        #endregion
    }
}