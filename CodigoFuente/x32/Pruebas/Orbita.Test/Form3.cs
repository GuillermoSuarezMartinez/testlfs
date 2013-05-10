using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orbita.Controles.Contenedores;

namespace Orbita.Test
{
    public partial class Form3 : OrbitaMdiContainerForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void ddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            this.OI.MostrarFormulario(form);
        }
    }
}
