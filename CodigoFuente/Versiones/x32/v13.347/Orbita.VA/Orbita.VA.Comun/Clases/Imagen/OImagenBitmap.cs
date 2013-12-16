//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 12-12-2012
// Description      : Corregido problema con With y Height
//                    Se completa informaciónd el código y la fecha de creación
//
// Last Modified By : aibañez
// Last Modified On : 16-11-2012
// Description      : Modificados métodos constructores y destructores para heredar de LargeObject
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Imagen de tipo Bitmap de windows
    /// </summary>
    [Serializable]
    public class OImagenBitmap : OImagen
    {
        #region Atributo(s)
        /// <summary>
        /// Propieadad a heredar donde se accede a la imagen
        /// </summary>
        public new Bitmap Image
        {
            get { return (Bitmap)_Image; }
            set { _Image = value; }
        }
        
        /// <summary>
        /// Tamaño en X de la imagen
        /// </summary>
        public override int Width
        {
            get 
            {
                int resultado = base.Width;
                if (this.Image is Bitmap)
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
                int resultado = base.Height;
                if (this.Image is Bitmap)
                {
                    resultado = this.Image.Height;
                }
                return resultado;
            }
        }
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Profundidad en bytes de cada píxel
        /// </summary>
        public override int Profundidad
        {
            get
            {
                int resultado = base.Profundidad;
                if (this.Image is Bitmap)
                {
                    return BitmapFactory.GetProfundidad(this.Image.PixelFormat);
                }
                return resultado;
            }
        }

        /// <summary>
        /// Indica si las imagenes son a color o monocromo
        /// </summary>
        public override bool Color
        {
            get 
            {
                bool resultado = base.Color;
                if (this.Image is Bitmap)
                {
                    return BitmapFactory.GetColor(this.Image.PixelFormat);
                }
                return resultado;
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OImagenBitmap()
            : this("BitmapImage")
        {
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OImagenBitmap(string codigo)
            : base(codigo)
        {
            this.TipoImagen = TipoImagen.Bitmap;
        }
        /// <summary>
        /// Constructor de la clase que además se encarga de liberar la memoria de la variable que se le pasa por parámetro
        /// </summary>
        /// <param name="imagenALiberar">Variable que se desea liberar de memoria</param>
        public OImagenBitmap(object imagen)
            : this("BitmapImage", imagen)
        {
        }
        /// <summary>
        /// Constructor de la clase que además se encarga de liberar la memoria de la variable que se le pasa por parámetro
        /// </summary>
        /// <param name="imagenALiberar">Variable que se desea liberar de memoria</param>
        public OImagenBitmap(string codigo, object imagen)
            : base(codigo, imagen)
        {
            this.TipoImagen = TipoImagen.Bitmap;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Método a implementar en las clases hijas. Elimina la memoria asignada por el objeto.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (this.Image != null)
                {
                    //if (disposing)
                    //{
                        //this.Image.Dispose(); // No se elimina porque otro objeto puede hacer referencia a ella
                    //}
                    this.Image = null;
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Clonado de la imagen
        /// </summary>
        public override object Clone()
        {
            OImagenBitmap imagenResultado = new OImagenBitmap();
            imagenResultado.Codigo = this.Codigo;
            imagenResultado.MomentoCreacion = this.MomentoCreacion;
            if (this._Image != null)
            {
                try
                {
                    // OPCIÓN 1
                    //imagenResultado._Image = this.Image.Clone();

                    // OPCIÓN 2
                    //Bitmap b = new Bitmap(this.Width, this.Height);
                    //Graphics g = Graphics.FromImage((Image)b);
                    //g.DrawImage(this.Image, 0, 0, this.Width, this.Height);
                    //g.Dispose();
                    //g = null;
                    //imagenResultado.Image = b;

                    // OPCIÓN 3
                    // Fase 1: Copia de la imagen a Array de Bytes
                    OByteArrayImage imagenByteArray = new OByteArrayImage();
                    imagenByteArray.Serializar(this, TipoSerializacionImagen.Dato);
                    // Fase 2: Restauración del Array de Bytes a la Imagen
                    imagenResultado = (OImagenBitmap)imagenByteArray.Desserializar();

                    // OPCIÓN 4
                    //imagenResultado._Image = new Bitmap(this.Image);
                }
                catch (Exception exception)
                {
                    OLogsVAComun.ImagenGraficos.Error(exception, "ImagenBitmap_Clone");
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
            if (base.Guardar(ruta))
            {
                this.Image.Save(ruta);

                return File.Exists(ruta);
            }
            return false;
        }

        /// <summary>
        /// Método a implementar en las clases hijas para guardar la imagen en un fichero de disco
        /// </summary>
        /// <param name="ruta">Ruta donde se ha de guardar la imagen</param>
        /// <param name="formato">Formato del archivo a guardar</param>
        /// <returns>Verdadero si la ruta donde se ha de guardar el fichero es válida</returns>
        public override bool Guardar(string ruta, ImageFormat formato)
        {
            if (base.Guardar(ruta))
            {
                this.Image.Save(ruta, formato);

                return File.Exists(ruta);
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
            if (base.Cargar(ruta))
            {
                this.Image = (Bitmap)Bitmap.FromFile(ruta);
                this.MomentoCreacion = DateTime.Now;

                return this.EsValida();
            }
            return false;
        }

        /// <summary>
        /// Convierte la imagen de tipo bitmap al tipo actual
        /// </summary>
        /// <param name="imagenBitmap">Imagen de tipo bitmap desde el cual se va a importar la imagen</param>
        public override OImagen ConvertFromBitmap(Bitmap imagenBitmap)
        {
            this.Image = imagenBitmap;
            return this;
        }

        /// <summary>
        /// Convierte la imagen actual al tipo genérico de imagen de tipo bitmap
        /// </summary>
        public override Bitmap ConvertToBitmap()
        {
            return this.Image;
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
            Bitmap b = new Bitmap(ancho, alto);
            
            OImagen reducida = new OImagenBitmap(this.Codigo);
            reducida.MomentoCreacion = this.MomentoCreacion;
            Graphics g = Graphics.FromImage((Image)b);

            g.DrawImage((Image)img.Image, 0, 0, ancho, alto);
            g.Dispose();
            g = null;

            reducida.Image = (Image)b;
            Image prueba = (Image)b;
            return reducida;
        }

        /// <summary>
        /// Método que realiza el empaquetado del fichero de la imagen
        /// </summary>
        /// <returns></returns>
        public override byte[] ToDataArray()
        {
            byte[] resultado = new byte[0];
            if (this.Image is Bitmap)
            {
                try
                {
                    MemoryStream stream = new MemoryStream();
                    this.Image.Save(stream, this.Image.RawFormat); // Nuevo
                    //this.Image.Save(stream, ImageFormat.Bmp);
                    resultado = stream.ToArray();
                }
                catch
                {
                    resultado = new byte[0];
                }
            }

            return resultado;
        }

        /// <summary>
        /// Método que realiza el empaquetado de un objeto para ser enviado por remoting
        /// </summary>
        /// <returns></returns>
        public override byte[] ToDataArray(ImageFormat formato, double escalado)
        {
            byte[] resultado = new byte[0];
            if (this.Image is Bitmap)
            {
                try
                {
                    // Escalado de la imagen
                    OImagenBitmap imgAux = (OImagenBitmap)this.EscalarImagen(this, escalado);

                    MemoryStream stream = new MemoryStream();
                    imgAux.Image.Save(stream, formato);
                    resultado = stream.ToArray();
                    //stream.Close(); // Nuevo
                    //stream.Dispose(); // Nuevo
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
        public override bool FromDataArray(byte[] arrayValue, ref OImagen imagen)
        {
            bool resultado = false;

            if (arrayValue.Length > 0)
            {
                try
                {
                    MemoryStream stream = new MemoryStream(arrayValue);
                    Bitmap bmp = new Bitmap(stream);

                    imagen = new OImagenBitmap(this.Codigo, bmp);
                    //stream.Close(); // Nuevo
                    //stream.Dispose(); // Nuevo
                    resultado = true;
                }
                catch
                {
                }
            }

            return resultado;
        }

        /// <summary>
        /// Método que realiza el empaquetado del mapa de bits la imagen.
        /// </summary>
        /// <returns></returns>
        public override byte[] ToPixelArray()
        {
            byte[] resultado = new byte[0];
            if (this.Image is Bitmap)
            {
                try
                {
                    BitmapFactory.ExtractBufferArray(this.Image, out resultado);
                }
                catch
                {
                    resultado = new byte[0];
                }
            }

            return resultado;
        }

        /// <summary>
        /// Método que realiza el empaquetado del mapa de bits la imagen.
        /// </summary>
        /// <returns></returns>
        public override byte[] ToPixelArray(ImageFormat formato, double escalado)
        {
            byte[] resultado = new byte[0];
            if (this.Image is Bitmap)
            {
                try
                {
                    // Escalado de la imagen
                    OImagenBitmap imgAux = (OImagenBitmap)this.EscalarImagen(this, escalado);
                    BitmapFactory.ExtractBufferArray(imgAux.Image, out resultado);
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
        public override bool FromPixelArray(byte[] arrayValue, ref OImagen imagen, int width, int height, int profundidad)
        {
            bool resultado = false;

            if (arrayValue.Length > 0)
            {
                try
                {
                    Bitmap bmp = null;
                    //if ((imagen is OImagenBitmap) && (imagen.Image is Bitmap))
                    //{
                    //    bmp = (Bitmap)imagen.Image;
                    //}
                    //BitmapFactory.CreateOrUpdateBitmap(ref bmp, arrayValue, width, height, profundidad);

                    BitmapFactory.CreateBitmap(out bmp, width, height, profundidad);
                    BitmapFactory.UpdateBitmap(bmp, arrayValue, width, height, profundidad);
                    imagen.Image = bmp;
                    imagen.MomentoCreacion = this.MomentoCreacion;

                    resultado = true;
                }
                catch
                {
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
            return new OImagenBitmap(this.Codigo);
        }
        #endregion
    }
}
