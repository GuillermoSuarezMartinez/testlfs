﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowHookNet;
namespace Orbita.MS.Licenciamiento.PruebasCliente
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            WindowHookNet.WindowHookNet wh = new WindowHookNet.WindowHookNet();
        }
    }
}
