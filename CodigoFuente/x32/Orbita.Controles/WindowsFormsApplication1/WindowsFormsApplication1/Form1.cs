using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orbita.Utiles;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.orbitaConfiguracionCanal1.Iniciar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.orbitaConfiguracionCanal2.Iniciar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] resp = this.orbitaConfiguracionCanal1.GetDispositivos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OHashtable resp = this.orbitaConfiguracionCanal1.GetAlarmas(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OHashtable resp = this.orbitaConfiguracionCanal1.GetVariables(3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] var = new string[1];
            var[0] = "stringOrbita1";
            object[] valores = this.orbitaConfiguracionCanal1.GetLeerComs(3, var);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string[] var = new string[1];
            var[0] = "stringOrbita1";
            object[] val = new object[1];
            val[0] = 2;
            bool ret = this.orbitaConfiguracionCanal1.SetEscribirComs(3,var,val); ;

        }
    }
}
