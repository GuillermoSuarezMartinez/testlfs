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
                // Conversión de tipo
                OImagen imgVisualizada = this.VisorBitmapOriginal.ImagenActual;
                OImagenOpenCV<Emgu.CV.Structure.Bgr, byte> imgOriginal;
                imgVisualizada.Convert<OImagenOpenCV<Emgu.CV.Structure.Bgr, byte>>(out imgOriginal);

                // Extracción de información de ampliación del lienzo
                int xAmpliacion = this.NumericEditorXAmpliacion.Value.ValidarEntero(-10000, 10000, 0);
                int yAmpliacion = this.NumericEditorYAmpliacion.Value.ValidarEntero(-10000, 10000, 0);

                // Ampliación del lienzo
                OImagenOpenCV<Emgu.CV.Structure.Bgr, byte> imgAmpliada;
                imgAmpliada = imgOriginal.CrearBorde(xAmpliacion, yAmpliacion);

                // Extracción de información de la imagen original
                PointF puntoOriginal1 = new PointF();
                PointF puntoOriginal2 = new PointF();
                PointF puntoOriginal3 = new PointF();
                PointF puntoOriginal4 = new PointF();

                puntoOriginal1.X = (float)ODecimal.Validar(this.NumericEditorX1Origen.Value);
                puntoOriginal1.Y = (float)ODecimal.Validar(this.NumericEditorY1Origen.Value);
                puntoOriginal2.X = (float)ODecimal.Validar(this.NumericEditorX2Origen.Value);
                puntoOriginal2.Y = (float)ODecimal.Validar(this.NumericEditorY2Origen.Value);
                puntoOriginal3.X = (float)ODecimal.Validar(this.NumericEditorX3Origen.Value);
                puntoOriginal3.Y = (float)ODecimal.Validar(this.NumericEditorY3Origen.Value);
                puntoOriginal4.X = (float)ODecimal.Validar(this.NumericEditorX4Origen.Value);
                puntoOriginal4.Y = (float)ODecimal.Validar(this.NumericEditorY4Origen.Value);

                PointF puntoOriginal1Offset = new PointF(puntoOriginal1.X + xAmpliacion, puntoOriginal1.Y + yAmpliacion);
                PointF puntoOriginal2Offset = new PointF(puntoOriginal2.X + xAmpliacion, puntoOriginal2.Y + yAmpliacion);
                PointF puntoOriginal3Offset = new PointF(puntoOriginal3.X + xAmpliacion, puntoOriginal3.Y + yAmpliacion);
                PointF puntoOriginal4Offset = new PointF(puntoOriginal4.X + xAmpliacion, puntoOriginal4.Y + yAmpliacion);

                // Extracción de información de la imagen destino
                float x = (float)ODecimal.Validar(this.NumericEditorX.Value, -10000, 10000, 0);
                float y = (float)ODecimal.Validar(this.NumericEditorY.Value, -10000, 10000, 0);
                float ancho = (float)ODecimal.Validar(this.NumericEditorAncho.Value, 1, 10000, 800);
                float alto = (float)ODecimal.Validar(this.NumericEditorAlto.Value, 1, 10000, 600);

                // Corrección de perspectiva
                OImagenOpenCV<Emgu.CV.Structure.Bgr, byte> imgDestino;
                imgDestino = imgAmpliada.CorregirPerspectiva(puntoOriginal1Offset, puntoOriginal2Offset, puntoOriginal3Offset, puntoOriginal4Offset, x, y, ancho, alto);

                this.VisorBitmapDestino.Visualizar(imgDestino);
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Procesar");
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

            if (this.RadioButtonPuntoOriginal1.Checked)
            {
                PointF puntoOriginal1 = pos;
                this.NumericEditorX1Origen.Value = puntoOriginal1.X;
                this.NumericEditorY1Origen.Value = puntoOriginal1.Y;
            }
            else if (this.RadioButtonPuntoOriginal2.Checked)
            {
                PointF puntoOriginal2 = pos;
                this.NumericEditorX2Origen.Value = puntoOriginal2.X;
                this.NumericEditorY2Origen.Value = puntoOriginal2.Y;
            }
            else if (this.RadioButtonPuntoOriginal3.Checked)
            {
                PointF puntoOriginal3 = pos;
                this.NumericEditorX3Origen.Value = puntoOriginal3.X;
                this.NumericEditorY3Origen.Value = puntoOriginal3.Y;
            }
            else if (this.RadioButtonPuntoOriginal4.Checked)
            {
                PointF puntoOriginal4 = pos;
                this.NumericEditorX4Origen.Value = puntoOriginal4.X;
                this.NumericEditorY4Origen.Value = puntoOriginal4.Y;
            }
        }
	    #endregion    
    }
}
