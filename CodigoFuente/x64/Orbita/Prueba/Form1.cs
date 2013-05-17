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
            Orbita.BBDD.OInfoConexion c = new Orbita.BBDD.OInfoConexion();
            Orbita.Comunicaciones.OBroadcastEventWrapper a = new Orbita.Comunicaciones.OBroadcastEventWrapper();
            Orbita.Winsock.WinsockProtocol p = new Orbita.Winsock.WinsockProtocol();
            Orbita.Trazabilidad.FullPath f = new Orbita.Trazabilidad.FullPath();
            Orbita.Compresion.BZip2Exception z = new Orbita.Compresion.BZip2Exception();
            Orbita.MS.OEncriptacion k = new Orbita.MS.OEncriptacion("");
            Orbita.Utiles.OCola n = new Orbita.Utiles.OCola();
            Orbita.Xml.OXml x = new Orbita.Xml.OXml();
        }
    }
}
