using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.Utiles;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Implementa un cache de imagenes de disco
    /// </summary>
    public class OCacheImagenes<TImagen>
        where TImagen: OImagen, new()
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de imagenes cargadas de disco
        /// </summary>
        private Dictionary<string, TImagen> CacheImagenes;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Número máximo de imágenes del cache
        /// </summary>
        private int _CapacidadMaxima;
        /// <summary>
        /// Número máximo de imágenes del cache
        /// </summary>
        public int CapacidadMaxima
        {
            get { return _CapacidadMaxima; }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OCacheImagenes(int capacidadMaxima)
        {
            this._CapacidadMaxima = capacidadMaxima;
            this.CacheImagenes = new Dictionary<string, TImagen>(capacidadMaxima);
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Carga una imagen de disco o de cache
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        public bool Cargar(string ruta, out TImagen imagen)
        {
            bool resultado = false;
            imagen = null;

            // Se intenta recuperar la imagen del cache
            resultado = this.CacheImagenes.TryGetValue(ruta, out imagen);

            if (!resultado)
            {
                // Cargo la imagen de disco
                imagen = new TImagen();
                resultado = imagen.Cargar(ruta);

                // Añado la imagen al cache
                if (resultado)
                {
                    this.CacheImagenes[ruta] = imagen;

                    // Si he superado la capacidad máxima borro el más antiguo
                    if ((this.CacheImagenes.Count > this._CapacidadMaxima) && (this._CapacidadMaxima > 0))
                    {
                        string rutaAEliminar = this.CacheImagenes.First().Key;
                        this.CacheImagenes.Remove(rutaAEliminar);
                    }
                }
            }

            return resultado;
        }
        #endregion
    }
}
