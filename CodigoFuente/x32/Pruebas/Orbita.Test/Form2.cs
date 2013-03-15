﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orbita.Controles.Contenedores;
using Orbita.Controles.Test;
using System.Collections;
using System.Data.SqlClient;

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
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@IdSede", 1));
            DataTable dt = BDatos.Bd.SeleccionProcedimientoAlmacenado("ADM_GET_ACCIONESTODAS", list);
            this.orbitaUltraCombo1.OI.Formatear(dt, "IdAccion", "NombreAccion");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.orbitaUltraCombo1.OI.Valor.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.orbitaUltraCombo1.OI.Texto.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.orbitaUltraCombo1.OI.ActivarPrimeraFilaAlFormatear = false;
            ArrayList list = new ArrayList();
            list.Add(new SqlParameter("@IdSede", 1));
            DataTable dt = BDatos.Bd.SeleccionProcedimientoAlmacenado("ADM_GET_ACCIONESTODAS", list);
        }
    }
}
