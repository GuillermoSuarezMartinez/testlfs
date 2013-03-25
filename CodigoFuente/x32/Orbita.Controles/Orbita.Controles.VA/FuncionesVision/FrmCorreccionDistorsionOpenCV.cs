using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orbita.VA.Comun;
using Orbita.VA.Funciones;
using Orbita.Utiles;

namespace Orbita.Controles.VA
{
    public partial class FrmCorreccionDistorsionOpenCV : FrmBase
    {
        PointF PuntoOriginal1 = new PointF();
        PointF PuntoOriginal2 = new PointF();
        PointF PuntoOriginal3 = new PointF();
        PointF PuntoOriginal4 = new PointF();

        public FrmCorreccionDistorsionOpenCV()
        {
            InitializeComponent();
        }

        private void BtnProcesar_Click(object sender, EventArgs e)
        {
            Orbita.VA.Comun.ODebug.WaitRemoteDebug();
            float x = (float)ODecimal.Validar(this.NumericEditorX.Value, -10000, 10000, 0);
            float y = (float)ODecimal.Validar(this.NumericEditorY.Value, -10000, 10000, 0);
            float ancho = (float)ODecimal.Validar(this.NumericEditorAncho.Value, 1, 10000, 800);
            float alto = (float)ODecimal.Validar(this.NumericEditorAlto.Value, 1, 10000, 600);

            OImagen imgVisualizada = this.VisorBitmapOriginal.ImagenActual;
            OImagenOpenCV<Emgu.CV.Structure.Rgb, byte> imgOriginal;
            imgVisualizada.Convert<OImagenOpenCV<Emgu.CV.Structure.Rgb, byte>>(out imgOriginal);

            OImagenOpenCV<Emgu.CV.Structure.Rgb, byte> imgDestino;
            imgDestino = imgOriginal.CorregirDistorsion(PuntoOriginal1, PuntoOriginal2, PuntoOriginal3, PuntoOriginal4, x, y, ancho, alto);

            this.VisorBitmapDestino.Visualizar(imgDestino);
        }

        private void VisorBitmapOriginal_MouseClick(object sender, MouseEventArgs e)
        {
            Orbita.VA.Comun.ODebug.WaitRemoteDebug();
            PointF pos = this.VisorBitmapOriginal.CurrentCursorPosition;

            this.PuntoOriginal1 = this.RadioButtonPuntoOriginal1.Checked ? pos : PuntoOriginal1;
            this.PuntoOriginal2 = this.RadioButtonPuntoOriginal2.Checked ? pos : PuntoOriginal2;
            this.PuntoOriginal3 = this.RadioButtonPuntoOriginal3.Checked ? pos : PuntoOriginal3;
            this.PuntoOriginal4 = this.RadioButtonPuntoOriginal4.Checked ? pos : PuntoOriginal4;
        }
    }
}
