//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 25-03-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
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
    /// <summary>
    /// Formulario de test de corrección de distorsión
    /// </summary>
    public partial class FrmCorreccionDistorsionOpenCV : FrmBase
    {
        #region Atributo(s)
        PointF PuntoOriginal1 = new PointF();
        PointF PuntoOriginal2 = new PointF();
        PointF PuntoOriginal3 = new PointF();
        PointF PuntoOriginal4 = new PointF(); 
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public FrmCorreccionDistorsionOpenCV()
            :base(ModoAperturaFormulario.Monitorizacion)
        {
            InitializeComponent();
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Evento de procesado de la imagen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void BtnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.ImagenGraficos, "Procesar", exception);
            }

        }

        /// <summary>
        /// Evento de clic con el ratón en la imagen original
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisorBitmapOriginal_MouseClick(object sender, MouseEventArgs e)
        {
            PointF pos = this.VisorBitmapOriginal.CurrentCursorPosition;

            this.PuntoOriginal1 = this.RadioButtonPuntoOriginal1.Checked ? pos : PuntoOriginal1;
            this.PuntoOriginal2 = this.RadioButtonPuntoOriginal2.Checked ? pos : PuntoOriginal2;
            this.PuntoOriginal3 = this.RadioButtonPuntoOriginal3.Checked ? pos : PuntoOriginal3;
            this.PuntoOriginal4 = this.RadioButtonPuntoOriginal4.Checked ? pos : PuntoOriginal4;
        }
	    #endregion    
    }
}
