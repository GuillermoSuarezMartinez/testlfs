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
    public class AutenticacionManager
    {
        #region Delegados y eventos
        public event System.EventHandler<AutenticacionChangedEventArgs> ControlAutenticacion;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.AutenticacionManager.
        /// </summary>
        public AutenticacionManager() { }
        #endregion

        #region Métodos públicos
        public void Mostrar(System.Windows.Forms.Form parent)
        {
            FrmValidar form = new FrmValidar(parent);
            form.ControlAutenticacion += new System.EventHandler<AutenticacionChangedEventArgs>(OnControlAutenticacion);
            form.BringToFront();
            form.Show();
            form.Refresh();
        }
        public void Validar()
        {
            EstadoAutenticacion validar = new EstadoAutenticacionOK();
            this.OnControlAutenticacion(this, new AutenticacionChangedEventArgs(validar));
        }
        #endregion

        #region Manejadores de eventos
        protected void OnControlAutenticacion(object sender, AutenticacionChangedEventArgs e)
        {
            if (this.ControlAutenticacion != null)
            {
                this.ControlAutenticacion(sender, e);
            }
        }
        #endregion
    }
}