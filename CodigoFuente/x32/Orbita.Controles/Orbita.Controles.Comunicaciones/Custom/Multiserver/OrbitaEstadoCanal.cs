using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orbita.Utiles;
using Orbita.Winsock;

namespace Orbita.Controles.Comunicaciones
{
    public partial class OrbitaEstadoCanal : OrbitaControlBaseEventosComs
    {
        internal delegate void Delegado(WinsockStates estado);

        public OrbitaEstadoCanal()
        {
            InitializeComponent();
        }

        public override void ProcesarEstadoCanal(OEventArgs e)
        {
            WinsockStates estado = (WinsockStates)e.Argumento;
            this.agregarItemOrbita(estado);
        }

        private void agregarItemOrbita(WinsockStates estado)
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
                    case WinsockStates.Connected:
                        this.lblEstadoCanal.BackColor = Color.Green;
                        this.lblEstadoCanal.Text = estado.ToString();
                        break;
                    case WinsockStates.Closed:
                        this.lblEstadoCanal.BackColor = Color.Red;
                        this.lblEstadoCanal.Text = estado.ToString();
                        break;
                    default:
                        this.lblEstadoCanal.BackColor = Color.Yellow;
                        this.lblEstadoCanal.Text = estado.ToString();
                        break;
                }
            }
        }

    }
}
