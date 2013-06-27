using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orbita.Utiles;
using Orbita.Comunicaciones;

namespace Orbita.Controles.Comunicaciones
{
    public partial class OrbitaEstadoEventos : OrbitaControlBaseEventosComs
    {
        internal delegate void Delegado(string estado);

        public void Limpiar()
        {
            this.listViewEventos.Items.Clear();
        }

        public OrbitaEstadoEventos()
        {
            InitializeComponent();
        }

        public override void ProcesarTodasAlarmas(OEventArgs e)
        {
            OInfoDato estado = (OInfoDato)e.Argumento;
            this.agregarItemOrbita("Alarma " + estado.Texto + " valor " + estado.Valor.ToString());
        }

        public override void ProcesarTodosEventos(OEventArgs e)
        {
            OInfoDato estado = (OInfoDato)e.Argumento;
            this.agregarItemOrbita("CDato " + estado.Texto + " valor " + estado.Valor.ToString());
        }

        private void agregarItemOrbita(string estado)
        {
            if (this.listViewEventos.InvokeRequired)
            {
                Delegado MyDelegado = new Delegado(agregarItemOrbita);
                this.Invoke(MyDelegado, new object[] { estado });
            }
            else
            {
                this.listViewEventos.Items.Add(estado);
            }
        }

    }
}
