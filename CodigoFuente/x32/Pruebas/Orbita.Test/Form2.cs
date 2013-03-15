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
    public partial class Form2 : OrbitaMdiContainerForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void orbitaUltraButton1_Click(object sender, EventArgs e)
        {
            this.orbitaUltraToolbarsManager1.OI.AgregarToolButton("pp", "mikey");
            this.orbitaUltraGridToolBar1.Toolbar.OI.AgregarToolButton("pp", "mikey");
            //Form3 form = new Form3();
            //this.OI.MostrarFormulario(form);
        }
    }
}
