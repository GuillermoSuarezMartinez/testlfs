using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.MS.Excepciones;

namespace Orbita.MS.Licencias
{
    /// <summary>
    /// Gestiona las licencias
    /// </summary>
    public class OGestorLicencias
    {
        #region Atributos
        /// <summary>
        /// Características de las licencias registradas.
        /// </summary>
        private static Dictionary<int, OLicenciaCaracteristica> _caracteristicasLicenciadas = new Dictionary<int, OLicenciaCaracteristica>();
        /// <summary>
        /// Productos de las licencias registradas.
        /// </summary>
        private static Dictionary<int, OLicenciaProducto> _productosLicenciados = new Dictionary<int, OLicenciaProducto>();
        /// <summary>
        /// Alias de las características.
        /// </summary>
        private static Dictionary<string, int> _aliasCaracteristicas = new Dictionary<string, int>() { };
        /// <summary>
        /// Alias de los productos.
        /// </summary>
        private static Dictionary<string, int> _aliasProductos = new Dictionary<string, int>() { };

        #endregion Atributos

        #region Propiedades


        #endregion Propiedades

        #region Constructor
        #endregion Constructor

        #region Métodos privados
        private static bool VerificaExistenciaCaracteristica(string nombre)
        {
            if (_aliasCaracteristicas.ContainsKey(nombre))
            {
                int id = _aliasCaracteristicas[nombre];
                if (!VerificaExistenciaCaracteristica(id))
                {
                    _aliasCaracteristicas.Remove(nombre);
                    throw new OExcepcionLicenciaNoDisponible(nombre, "El alias registrado no es válido. Se elimina su referencia en futuras llamadas.");
                }
                //Si todo es correcto
                    return true;
            }
            else
            {
                //No existe un alias de esa caracteristica
                return false;
            }
            
        }
        private static bool VerificaExistenciaCaracteristica(int id)
        {
            return _caracteristicasLicenciadas.ContainsKey(id);
        }


        private static bool VerificaExistenciaProducto(string nombre)
        {
            if (_aliasProductos.ContainsKey(nombre))
            {
                int id = _aliasProductos[nombre];
                if (!VerificaExistenciaProducto(id))
                {
                    _aliasProductos.Remove(nombre);
                    throw new OExcepcionLicenciaNoDisponible(nombre, "El ID del producto registrado no es válido. Se elimina su referencia en futuras llamadas.");
                }
                //Si todo es correcto
                return true;
            }
            else
            {
                //No existe un alias de ese producto
                return false;
            }
        }
        private static bool VerificaExistenciaProducto(int id)
        {
            return _productosLicenciados.ContainsKey(id);
        }
        #endregion Métodos privados


        #region Métodos públicos
        /// <summary>
        /// Obtiene una instancia de la característica indicada.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public static OLicenciaCaracteristica GetCaracteristicaLicenciada(string nombre)
        {
            if (!VerificaExistenciaCaracteristica(nombre))
            {
                throw new OExcepcionLicenciaNoDisponible(nombre, "Característica no registrada");
            }
            //La verificación valida tanto el ID como el nombre.
            int id = _aliasCaracteristicas[nombre];
            return _caracteristicasLicenciadas[id];
        }
        /// <summary>
        /// Obtiene una instancia de la característica indicada.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public static OLicenciaCaracteristica GetCaracteristicaLicenciada(int id)
        {
            if (!VerificaExistenciaCaracteristica(id))
            {
                throw new OExcepcionLicenciaNoDisponible(id.ToString(), "Característica no registrada");
            }
            return _caracteristicasLicenciadas[id];
        }
        /// <summary>
        /// Obtiene una instancia del producto indicado.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public static OLicenciaProducto GetProductoLicenciado(string nombre)
        {
            if (!VerificaExistenciaProducto(nombre))
            {
                throw new OExcepcionLicenciaNoDisponible(nombre, "Producto no registrado");
            }
            //La verificación valida tanto el ID como el nombre.
            int id = _aliasProductos[nombre];
            return _productosLicenciados[id];
        }
        /// <summary>
        /// Obtiene una instancia del producto indicado.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public static OLicenciaProducto GetProductoLicenciado(int id)
        {
            if (!VerificaExistenciaProducto(id))
            {
                throw new OExcepcionLicenciaNoDisponible(id.ToString(), "Producto no registrado");
            }
            return _productosLicenciados[id];
        }
        /// <summary>
        /// Añadir una nueva característica licenciada.
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        public static bool NuevaCaracteristicaLicenciada(OLicenciaCaracteristica elemento, string dispositivo)
        {
            if (VerificaExistenciaCaracteristica(elemento.Id) || VerificaExistenciaCaracteristica(elemento.Nombre))
            {
                return false; //Ya existe
            }
            //Añadimos el alias
            _aliasCaracteristicas.Add(elemento.NombreInterno, elemento.Id);
            //Añadimos la entrada
            _caracteristicasLicenciadas.Add(elemento.Id, elemento);

            return false;
        }
        /// <summary>
        /// Añadir un nuevo producto licenciado
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        public static bool NuevoProductoLicenciado(OLicenciaProducto elemento, string dispositivo)
        {
            if (VerificaExistenciaProducto(elemento.Id) || VerificaExistenciaProducto(elemento.Nombre))
            {
                return false; //Ya existe
            }
            //Añadimos el alias
            _aliasProductos.Add(elemento.NombreInterno, elemento.Id);
            //Añadimos la entrada
            _productosLicenciados.Add(elemento.Id, elemento);
            return false;
        }
        
        #endregion Métodos públicos
    }
}
