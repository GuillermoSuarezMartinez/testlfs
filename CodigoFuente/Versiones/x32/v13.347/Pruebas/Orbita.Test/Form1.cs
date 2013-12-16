using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Orbita.Trazabilidad;

namespace Orbita.Test
{
    public partial class Form1 : Form
    {
        protected static ILogger logger = Orbita.Trazabilidad.LogManager.GetLogger("owrapper");
        public Form1()
        {
            InitializeComponent();
            logger.Info("info");
            logger.Warn("warning");
        }
    }
}
