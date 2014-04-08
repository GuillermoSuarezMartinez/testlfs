//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 02-04-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase utilizada para serializar imagenes
    /// </summary>
    [Serializable]
    public class OByteArrayImage
    {
        #region Atributo(s)
        /// <summary>
        /// Datos de la imagen serializada
        /// </summary>
        public byte[] DatosImagen;
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
        /// Indica que contiene una imagen serializada
        /// </summary>
        public bool Serializado;
        /// <summary>
        /// Profundidad en bytes de cada píxel
        /// </summary>
        public int Profundidad;
        /// <summary>
        /// Indica si la imagen es a color o Monocromo
        /// </summary>
        public bool Color;
        /// <summary>
        /// Tipo de serialización realizada en la imagen
        /// </summary>
        public TipoSerializacionImagen TipoSerializacionImagen;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OByteArrayImage()
        {
            this.Serializado = false;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OByteArrayImage(string codigo, byte[] datosImagen, TipoImagen tipoImagen, bool color = true, int profundidad = 3)
        {
            this.Codigo = codigo;
            this.DatosImagen = datosImagen;
            this.MomentoCreacion = DateTime.Now;
            this.Color = color;
            this.Profundidad = profundidad;
            this.Serializado = true;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Serializa una imagen
        /// </summary>
        public void Serializar(OImagen imagen, TipoSerializacionImagen tipoSerializacionImagen)
        {
            this.Codigo = imagen.Codigo;
            this.TipoImagen = imagen.TipoImagen;
            this.Width = imagen.Width;
            this.Height = imagen.Height;
            this.MomentoCreacion = imagen.MomentoCreacion;
            this.TipoSerializacionImagen = tipoSerializacionImagen;
            switch (tipoSerializacionImagen)
            {
                case TipoSerializacionImagen.Dato:
                default:
                    this.DatosImagen = imagen.ToDataArray();
                    break;
                case TipoSerializacionImagen.Pixel:
                    this.DatosImagen = imagen.ToPixelArray();
                    break;
            }
            this.Serializado = true;
            this.Profundidad = imagen.Profundidad;
            this.Color = imagen.Color;
        }

        /// <summary>
        /// Desserializa una imagen
        /// </summary>
        public OImagen Desserializar()
        {
            OImagen resultado = OImagen.Nueva(this.TipoImagen, this.Color);
            switch (this.TipoSerializacionImagen)
            {
                case TipoSerializacionImagen.Dato:
                default:
                    resultado.FromDataArray(this.DatosImagen, ref resultado);
                    break;
                case TipoSerializacionImagen.Pixel:
                    resultado.FromPixelArray(this.DatosImagen, ref resultado, this.Width, this.Height, this.Profundidad);
                    break;
            }

            resultado.MomentoCreacion = this.MomentoCreacion;
            resultado.Codigo = this.Codigo;

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

    /// <summary>
    /// Tipo de serialización de la imagen
    /// </summary>
    public enum TipoSerializacionImagen
    {
        /// <summary>
        /// Serialización a nivel de formato. (Array de bits del Bitmap, JPG, PNG, etc...)
        /// </summary>
        Dato,
        /// <summary>
        /// Serialización a nivel del mapa de bits
        /// </summary>
        Pixel
    }
}
