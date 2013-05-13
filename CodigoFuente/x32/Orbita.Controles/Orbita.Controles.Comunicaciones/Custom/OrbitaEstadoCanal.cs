using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orbita.Utiles;

namespace Orbita.Controles.Comunicaciones
{
    public partial class OrbitaEstadoCanal : OrbitaControlBaseEventosComs
    {
        internal delegate void Delegado(OEstadoCanalCliente estado);

        public OrbitaEstadoCanal()
        {
            InitializeComponent();
        }

        public override void ProcesarEstadoCanal(OEventArgs e)
        {
            OEstadoCanalCliente dato = (OEstadoCanalCliente)e.Argumento;
            this.agregarItemOrbita(dato);
        }

        private void agregarItemOrbita(OEstadoCanalCliente estado)
        {
            if (this.lblEstadoCanal.InvokeRequired)
            {
                Delegado MyDelegado = new Delegado(agregarItemOrbita);
                this.Invoke(MyDelegado, new object[] { estado });
            }
            else
            {
                switch (estado)
                {
                    case OEstadoCanalCliente.Conectado:
                        this.lblEstadoCanal.BackColor = Color.Green;
                        break;
                    case OEstadoCanalCliente.PendienteReconectar:
                        this.lblEstadoCanal.BackColor = Color.Yellow;
                        break;
                    case OEstadoCanalCliente.Reconectando:
                        this.lblEstadoCanal.BackColor = Color.Blue;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
