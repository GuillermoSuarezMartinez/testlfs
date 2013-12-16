using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase utilizada para pasar imagenes por memoria mapeada
    /// </summary>
    [Serializable]
    public class OImagenMemoriaMapeada
    {
        #region Atributo(s)
        /// <summary>
        /// Código identificativo
        /// </summary>
        public string Codigo;
        /// <summary>
        /// Tipo de la imagen serializada
        /// </summary>
        public TipoImagen TipoImagen;
        /// <summary>
        /// Tamaño en X de la imagen
        /// </summary>
        public int Width;
        /// <summary>
        /// Tamaño en Y de la imagen
        /// </summary>
        public int Height;
        /// <summary>
        /// Informa del momento de la creación de la imagen
        /// </summary>
        public DateTime MomentoCreacion;
        /// <summary>
        /// Profundidad en bytes de cada píxel
        /// </summary>
        public int Profundidad;
        /// <summary>
        /// Color o monocromo
        /// </summary>
        public bool Color;
        /// <summary>
        /// Indica si la imagen está mapeada en memoria
        /// </summary>
        public bool Mapeado;
        /// <summary>
        /// Identificador del buffer de memoria
        /// </summary>
        public string IdentificacionBuffer;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OImagenMemoriaMapeada()
        {
            this.Mapeado = false;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Serializa una imagen
        /// </summary>
        public void EscribirImagen(OImagen imagen, OMemoriaMapeadaMultiBuffer memoriaMapeada, string identificadorRegion)
        {
            this.Codigo = imagen.Codigo;
            this.TipoImagen = imagen.TipoImagen;
            this.Width = imagen.Width;
            this.Height = imagen.Height;
            this.MomentoCreacion = imagen.MomentoCreacion;
            this.Mapeado = true;
            this.Profundidad = imagen.Profundidad;
            this.Color = imagen.Color;

            byte[] datos = imagen.ToPixelArray();
            //byte[] datos2 = imagen.ToDataArray(); // Prueba de rendimiento
            //imagen.FromPixelArray(datos, ref imagen, imagen.Width, imagen.Height, imagen.Profundidad); // Prueba de rendimiento
            //imagen.FromDataArray(datos, ref imagen); // Prueba de rendimiento
            this.IdentificacionBuffer = memoriaMapeada.Escribir(identificadorRegion, datos);
        }

        /// <summary>
        /// Serializa una imagen
        /// </summary>
        public void EscribirBuffer(OByteArrayImage imagen, OMemoriaMapeadaMultiBuffer memoriaMapeada, string identificadorRegion)
        {
            this.Codigo = imagen.Codigo;
            this.TipoImagen = imagen.TipoImagen;
            this.Width = imagen.Width;
            this.Height = imagen.Height;
            this.MomentoCreacion = imagen.MomentoCreacion;
            this.Mapeado = true;
            this.Profundidad = imagen.Profundidad;
            this.Color = imagen.Color;

            byte[] datos = imagen.DatosImagen;
            this.IdentificacionBuffer = memoriaMapeada.Escribir(identificadorRegion, datos);
        }

        /// <summary>
        /// Desserializa una imagen
        /// </summary>
        public bool LeerImagen(OMemoriaMapeadaMultiBuffer memoriaMapeada, ref OImagen imagen)
        {
            bool resultado = false;

            if (this.Mapeado)
            {
                byte[] arrayBytes;
                bool ok = memoriaMapeada.Leer(this.IdentificacionBuffer, out arrayBytes);
                if (ok)
                {
                    if (imagen == null)
                    {
                        imagen = OImagen.Nueva(this.TipoImagen, this.Color);
                    }

                    imagen.FromPixelArray(arrayBytes, ref imagen, this.Width, this.Height, this.Profundidad);
                    //imagen.FromDataArray(arrayBytes, ref imagen); // Prueba de rendimiento
                    imagen.MomentoCreacion = this.MomentoCreacion;
                    imagen.Codigo = this.Codigo;
                    resultado = true;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Desserializa una imagen
        /// </summary>
        public OByteArrayImage LeerBuffer(OMemoriaMapeadaMultiBuffer memoriaMapeada)
        {
            OByteArrayImage resultado = null;

            if (this.Mapeado)
            {
                byte[] arrayBytes;
                bool ok = memoriaMapeada.Leer(this.IdentificacionBuffer, out arrayBytes);
                if (ok)
                {
                    resultado = new OByteArrayImage(this.Codigo, arrayBytes, this.TipoImagen, this.Color);
                    resultado.MomentoCreacion = this.MomentoCreacion;
                }
            }

            return resultado;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Devuelve una clase System.String que representa la clase System.Object actual.
        /// </summary>
        /// <returns>Una clase System.String que representa la clase System.Object actual.</returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}x{4}, {5}", this.GetType().ToString(), this.Codigo, this.MomentoCreacion.ToString("yyyyMMddHHmmssfff"), this.Width, this.Height, this.Color ? "Color" : "Mono");
        }
        #endregion
    }
}
