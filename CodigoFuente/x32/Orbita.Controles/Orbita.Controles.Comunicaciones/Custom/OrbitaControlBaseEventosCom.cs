using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orbita.Comunicaciones;

namespace Orbita.Controles.Comunicaciones
{
    public partial class OrbitaControlBaseEventosComs : UserControl
    {
        public class ControlNuevaDefinicion : OBaseEventosComs
        {
            public ControlNuevaDefinicion(OrbitaControlBaseEventosComs sender)
                : base(sender) { }
        };

        #region Atributos
        public ControlNuevaDefinicion definicion;
        #endregion

        #region Propiedades
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicion OI
        {
            get { return this.definicion; }
            set { this.definicion = value; }
        }
        #endregion

        #region Constructor
        public OrbitaControlBaseEventosComs()
        {
            InitializeComponent();
            this.InitializeAttributes();
            this.Iniciar();
        }
        #endregion

        #region Métodos públicos
        public virtual void ProcesarAlarma(Orbita.Utiles.OEventArgs e)
        {

        }

        public virtual void ProcesarVariableVisual(Orbita.Utiles.OEventArgs e)
        {

        }

        public virtual void ProcesarComunicaciones(Orbita.Utiles.OEventArgs e)
        {


        }

        public virtual void ProcesarCambioDato(Orbita.Utiles.OEventArgs e)
        {

        }

        public virtual void ProcesarEstadoCanal(Orbita.Utiles.OEventArgs e)
        {

        }
        #endregion

        #region Métodos privados
        void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new ControlNuevaDefinicion(this);
            }
        }

        public void Iniciar()
        {
            try
            {
                OrbitaConfiguracionCanal.OEventoClienteComs += new EventoClienteComs(OrbitaConfiguracionCanal_OEventoClienteComs);
                OrbitaConfiguracionCanal.OEventoClienteCambioDato += new EventoClienteCambioDato(OrbitaConfiguracionCanal_OEventoClienteCambioDato);
                OrbitaConfiguracionCanal.OEventoClienteAlarma += new EventoClienteAlarma(OrbitaConfiguracionCanal_OEventoClienteAlarma);
                OrbitaConfiguracionCanal.OEventoEstadoCanal += new EventoClienteAlarma(OrbitaConfiguracionCanal_OEventoEstadoCanal);
            }
            catch (Exception)
            {

            }
        }


        public void Finalizar()
        {
            try
            {
                OrbitaConfiguracionCanal.OEventoClienteComs -= new EventoClienteComs(OrbitaConfiguracionCanal_OEventoClienteComs);
                OrbitaConfiguracionCanal.OEventoClienteCambioDato -= new EventoClienteCambioDato(OrbitaConfiguracionCanal_OEventoClienteCambioDato);
                OrbitaConfiguracionCanal.OEventoClienteAlarma -= new EventoClienteAlarma(OrbitaConfiguracionCanal_OEventoClienteAlarma);
                OrbitaConfiguracionCanal.OEventoEstadoCanal -= new EventoClienteAlarma(OrbitaConfiguracionCanal_OEventoEstadoCanal);
            }
            catch (Exception)
            {

            }
        }
        private void OrbitaConfiguracionCanal_OEventoClienteAlarma(Orbita.Utiles.OEventArgs e, string canal)
        {
            OInfoDato info = (OInfoDato)e.Argumento;
            if (canal == this.OI.Comunicacion.NombreCanal && info.Dispositivo == this.OI.Comunicacion.IdDispositivo && this.OI.Alarmas.Alarmas.Exists(x => x == info.Texto))
            {
                this.ProcesarAlarma(e);
            }
        }

        private void OrbitaConfiguracionCanal_OEventoClienteCambioDato(Orbita.Utiles.OEventArgs e, string canal)
        {
            lock (this)
            {
                OInfoDato info = (OInfoDato)e.Argumento;
                if (canal == this.OI.Comunicacion.NombreCanal && info.Dispositivo == this.OI.Comunicacion.IdDispositivo && info.Texto == this.OI.CambioDato.Variable)
                {
                    this.ProcesarVariableVisual(e);
                }
                if (canal == this.OI.Comunicacion.NombreCanal && info.Dispositivo == this.OI.Comunicacion.IdDispositivo && this.OI.CambioDato.Cambios.Exists(x => x == info.Texto))
                {
                    this.ProcesarCambioDato(e);
                }
            }            
        }

        private void OrbitaConfiguracionCanal_OEventoClienteComs(Orbita.Utiles.OEventArgs e, string canal)
        {
            OEstadoComms estado = (OEstadoComms)e.Argumento;
            if (canal == this.OI.Comunicacion.NombreCanal && estado.Id == this.OI.Comunicacion.IdDispositivo)
            {
                this.ProcesarComunicaciones(e);
            }
        }

        void OrbitaConfiguracionCanal_OEventoEstadoCanal(Orbita.Utiles.OEventArgs e, string canal)
        {
            if (canal == this.OI.Comunicacion.NombreCanal)
            {
                this.ProcesarEstadoCanal(e);
            }
        }

        #endregion
    }
}
