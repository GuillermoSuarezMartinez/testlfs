using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Orbita.VA.Comun.OByteArrayImage b = new Orbita.VA.Comun.OByteArrayImage();
            //Orbita.VA.MaquinasEstados.EventMessageRaised msg = new Orbita.VA.MaquinasEstados.EventMessageRaised(Orbita.VA.MaquinasEstados.TipoMensajeMaquinaEstados.CambioEstado, "", DateTime.Now);
            Orbita.VA.Comun.OImagenOpenCVColor<byte> img = new Orbita.VA.Comun.OImagenOpenCVColor<byte>();
            img.Cargar(@"C:\temp\wallpaper.bmp");
            Orbita.VA.Comun.OImagenVisionPro imgvp = new Orbita.VA.Comun.OImagenVisionPro(new Bitmap(100, 100));
            Orbita.VA.Funciones.OFiltradoOpenCV.Binarizar<byte>(img, 1);
            Orbita.VA.Hardware.OVProGigEBoolFeature bf = new Orbita.VA.Hardware.OVProGigEBoolFeature("", false, 100, false, "");
        }
    }
}
