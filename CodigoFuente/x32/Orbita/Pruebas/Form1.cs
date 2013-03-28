using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orbita.Trazabilidad;

namespace Pruebas
{
    public partial class Form1 : Form
    {
        ILogger logger1 = LogManager.GetLogger("odebug");
        //ILogger logger2 = LogManager.GetLogger("FormulariosServidorCamaras");

        public Form1()
        {
            InitializeComponent();
            Exception ex = new Exception();
            logger1.Debug(ex);
          //  logger2.Debug("pp2");
        }
    }
}
