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
    public partial class OrbitaEstadoCanalLabel : OrbitaControlBaseEventosComs
    {
        internal delegate void Delegado(string valor);


        public OrbitaEstadoCanalLabel()
        {
            InitializeComponent();
        }

        public override void ProcesarVariableVisual(Utiles.OEventArgs e)
        {
            try
            {
                OInfoDato dato = (OInfoDato)e.Argumento;
                this.agregarItemOrbita(dato.Valor.ToString());
            }
            catch (Exception)
            {
                
            }
        }

        private void agregarItemOrbita(string valor)
        {
            if (this.lblValor.InvokeRequired)
            {
                Delegado MyDelegado = new Delegado(agregarItemOrbita);
                this.Invoke(MyDelegado, new object[] { valor });
            }
            else
            {
                this.lblValor.Text = valor;
            }
        }
    }
}
