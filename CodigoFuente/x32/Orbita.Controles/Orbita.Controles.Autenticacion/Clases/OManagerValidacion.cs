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
        /// <summary>
        /// Muestra el formulario de validación.
        /// </summary>
        public void Mostrar()
        {
            FrmValidar frm = new FrmValidar();
            frm.OValidacionControl += new FrmValidar.ODelegadoValidacion(frm_OValidacionControl);
            frm.ShowDialog();
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