//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 22/03/2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Emgu.CV;
using Orbita.Utiles;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Imagen de tipo VisionPro de Cognex
    /// </summary>
    [Serializable]
    public class OImagenOpenCV<TColor, TDepth> : OImagen
        where TColor : struct, global::Emgu.CV.IColor
        where TDepth : new()
    {
        #region Atributo(s)
        /// <summary>
        /// Propieadad a heredar donde se accede a la imagen
        /// </summary>
        public new Emgu.CV.Image<TColor, TDepth> Image
        {
            get { return (Emgu.CV.Image<TColor, TDepth>)_Image; }
            set { _Image = value; }
        }
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Tamaño en X de la imagen
        /// </summary>
        public override int Width
        {
            get
            {
                int resultado = base.Width;
                if (this.Image is Emgu.CV.Image<TColor, TDepth>)
                {
                    resultado = this.Image.Width;
                }
                return resultado;
            }
        }

        /// <summary>
        /// Tamaño en Y de la imagen
        /// </summary>
        public override int Height
        {
            get
            {
                int resultado = base.Width;
                if (this.Image is Emgu.CV.Image<TColor, TDepth>)
                {
                    resultado = this.Image.Height;
                }
                return resultado;
            }
        }

        /// <summary>
        /// Retorna el tipo de color de la imagen
        /// </summary>
        public Type Color
        {
            get
            {
                return typeof(TColor);
            }
        }

        /// <summary>
        /// Retorna la profundidad imagen
        /// </summary>
        public Type Profundidad
        {
            get
            {
                return typeof(TDepth);
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OImagenOpenCV()
            : this("ImagenOpenCV")
        {
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OImagenOpenCV(string codigo)
            : base(codigo)
        {
            this.TipoImagen = TipoImagen.OpenCV;
        }
        /// <summary>
        /// Constructor de la clase que además se encarga de liberar la memoria de la variable que se le pasa por parámetro
        /// </summary>
        /// <param name="imagenALiberar">Variable que se desea liberar de memoria</param>
        public OImagenOpenCV(object imagen)
            : this("ImagenOpenCV", imagen)
        {
        }
        /// <summary>
        /// Constructor de la clase que además se encarga de liberar la memoria de la variable que se le pasa por parámetro
        /// </summary>
        /// <param name="imagenALiberar">Variable que se desea liberar de memoria</param>
        public OImagenOpenCV(string codigo, object imagen)
            : base(codigo, imagen)
        {
            this.TipoImagen = TipoImagen.OpenCV;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Método a implementar en las clases hijas. Elimina la memoria asignada por el objeto.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (this.Image != null)
                {
                    this.Image.Dispose();
                    this._Image = null;
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Clonado de la imagen
        /// </summary>
        public override object Clone()
        {
            OImagenOpenCV<TColor, TDepth> imagenResultado = new OImagenOpenCV<TColor, TDepth>();
            imagenResultado.Codigo = this.Codigo;
            imagenResultado.MomentoCreacion = this.MomentoCreacion;
            if (this.Image != null)
            {
                try
                {
                    imagenResultado.Image = this.Image.Clone();
                }
                catch (Exception exception)
                {
                    OVALogsManager.Error(ModulosSistema.ImagenGraficos, "ImagenOpenCV_Clone", exception);
                }
            }
            return imagenResultado;
        }

        /// <summary>
        /// Método a implementar en las clases hijas que indica que la imagen es válida
        /// </summary>
        /// <returns></returns>
        public override bool EsValida()
        {
            return base.EsValida();
        }

        /// <summary>
        /// Método a implementar en las clases hijas para guardar la imagen en un fichero de disco
        /// </summary>
        /// <param name="ruta">Ruta donde se ha de guardar la imagen</param>
        /// <returns>Verdadero si la ruta donde se ha de guardar el fichero es válida</returns>
        public override bool Guardar(string ruta)
        {
            try
            {
                if (base.Guardar(ruta))
                {
                    this.Image.Save(ruta);

                    return File.Exists(ruta);
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.ImagenGraficos, "ImagenOpenCV_Guardar", exception);
            }

            return false;
        }

        /// <summary>
        /// Método a implementar en las clases hijas para cargar la imagen de un fichero de disco
        /// </summary>
        /// <param name="ruta">Ruta de donde se ha de cargar la imagen</param>
        /// <returns>Verdadero si el fichero que se ha de cargar existe</returns>
        public override bool Cargar(string ruta)
        {
            try
            {
                if (base.Cargar(ruta))
                {
                    this.Image = new Image<TColor, TDepth>(ruta);
                    this.MomentoCreacion = DateTime.Now;

                    return this.EsValida();
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.ImagenGraficos, "ImagenOpenCV_Cargar", exception);
            }

            return false;
        }

        /// <summary>
        /// Convierte la imagen de tipo bitmap al tipo actual
        /// </summary>
        /// <param name="imagenBitmap">Imagen de tipo bitmap desde el cual se va a importar la imagen</param>
        public override OImagen ConvertFromBitmap(Bitmap imagenBitmap)
        {
            Emgu.CV.Image<TColor, TDepth> img = new Image<TColor, TDepth>(imagenBitmap);
            return new OImagenOpenCV<TColor, TDepth>(img);
        }

        /// <summary>
        /// Convierte la imagen actual al tipo genérico de imagen de tipo bitmap
        /// </summary>
        public override Bitmap ConvertToBitmap()
        {
            return this.Image.ToBitmap();
        }

        /// <summary>
        /// Sirve para reducir la imagen 
        /// </summary>
        /// <param name="img">Imagen a reducir</param>
        /// <param name="width">Ancho de la imagen resultado</param>
        /// <param name="height">Alto de la imagen resultado</param>
        /// <returns>Imagen reducida</returns>
        public override OImagen EscalarImagen(OImagen img, int ancho, int alto)
        {
            Emgu.CV.Image<TColor, TDepth> imgEscalada = this.Image.Resize(ancho, alto, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            OImagenOpenCV<TColor, TDepth> reducida = new OImagenOpenCV<TColor, TDepth>(this.Codigo, imgEscalada);
            reducida.MomentoCreacion = this.MomentoCreacion;

            return reducida;
        }

        /// <summary>
        /// Método que realiza el empaquetado de un objeto para ser enviado por remoting
        /// </summary>
        /// <returns></returns>
        public override byte[] ToArray()
        {
            return Image.Bytes;
        }

        /// <summary>
        /// Método que realiza el empaquetado de un objeto para ser enviado por remoting
        /// </summary>
        /// <returns></returns>
        public override byte[] ToArray(ImageFormat formato, double escalado)
        {
            byte[] resultado = new byte[0];
            if (this.Image is Emgu.CV.Image<TColor, TDepth>)
            {
                try
                {
                    // Escalado de la imagen
                    OImagenOpenCV<TColor, TDepth> imgAux = (OImagenOpenCV<TColor, TDepth>)this.EscalarImagen(this, escalado);
                    return imgAux.Image.Bytes;
                }
                catch
                {
                    resultado = new byte[0];
                }
            }

            return resultado;
        }

        /// <summary>
        /// Método que realiza el desempaquetado de un objeto recibido por remoting
        /// </summary>
        /// <returns></returns>
        public override OImagen FromArray(byte[] arrayValue, int width, int height, int profundidad)
        {
            OImagenOpenCV<TColor, TDepth> resultado = null;

            if (arrayValue.Length > 0)
            {
                try
                {
                    Emgu.CV.Image<TColor, TDepth> imgCV = null;

                    MemoryStream stream = new MemoryStream(arrayValue);
                    BinaryFormatter formateador = new BinaryFormatter();
                    try
                    {
                        imgCV = (Emgu.CV.Image<TColor, TDepth>)formateador.Deserialize(stream);
                        resultado = new OImagenOpenCV<TColor, TDepth>(this.Codigo, imgCV);
                    }
                    catch (Exception exception)
                    {
                        OVALogsManager.Error(ModulosSistema.ImagenGraficos, "ImagenOpenCV_FromArray", exception);
                        resultado = null;
                    }
                    stream.Close();
                }
                catch
                {
                    resultado = null;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Crea una nueva imagen de la misma clase
        /// </summary>
        /// <returns>Nueva instancia de la misma clase de imagen</returns>
        public override OImagen Nueva()
        {
            return new OImagenOpenCV<TColor, TDepth>(this.Codigo);
        }
        #endregion
    }

    /// <summary>
    /// Tipos de color de la imagen de opencv
    /// </summary>
    public enum OOpenCVTiposColor
    {
        [OAtributoEnumerado("Imagen en escala de grises")]
        Gray = 1,
        [OAtributoEnumerado("Imagen en color (Azul, Verde, Rojo)")]
        Bgr = 2,// (Blue Green Red)
        [OAtributoEnumerado("Imagen en color con transparencia (Azul, Verde, Rojo, Alfa)")]
        Bgra = 3,// (Blue Green Red Alpha)
        [OAtributoEnumerado("Imagen en color (Matiz, Saturación, Valor)")]
        Hsv = 4,// (Hue Saturation Value)
        [OAtributoEnumerado("Imagen en color (Matiz, Luminancia, Satuación)")]
        Hls = 5,// (Hue Lightness Saturation)
        [OAtributoEnumerado("Imagen en color (CIE L*a*b)")]
        Lab = 6,// (CIE L*a*b*)
        [OAtributoEnumerado("Imagen en color (CIE L*u*v)")]
        Luv = 7,// (CIE L*u*v*)
        [OAtributoEnumerado("Imagen en color (CIE XYZ.Rec 709 with D65 white point)")]
        Xyz = 8,// (CIE XYZ.Rec 709 with D65 white point)
        [OAtributoEnumerado("Imagen en color (YCrCb JPEG)")]
        Ycc = 9// (YCrCb JPEG) 
    }

    /// <summary>
    /// Tipos de profundidad de la imagen de opencv
    /// </summary>
    public enum OOpenCVTiposProfundidad
    {
        [OAtributoEnumerado("Información de tipo entero de 8 bits sin signo")]
        Byte = 1,
        [OAtributoEnumerado("Información de tipo entero de 8 bits con signo")]
        SByte = 2,
        [OAtributoEnumerado("Información de tipo flotante de 32 bits")]
        Single = 3,// (float)
        [OAtributoEnumerado("Información de tipo flotante de 64 bits")]
        Double = 4,
        [OAtributoEnumerado("Información de tipo entero de 16 bits sin signo")]
        UInt16 = 5,
        [OAtributoEnumerado("Información de tipo entero de 16 bits con signo")]
        Int16 = 6,
        [OAtributoEnumerado("Información de tipo entero de 32 bits con signo")]
        Int32 = 7// (int) 
    }
}
