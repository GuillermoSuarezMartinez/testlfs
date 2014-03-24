using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS.Licencias
{

    public class OLicenciaProducto : OLicenciaElemento
    {
        #region Atributos
        /// <summary>
        /// Lista de características del producto
        /// </summary>
        private List<int> _listaCaracteristicas = new List<int> { };


        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// Lista de características del producto
        /// </summary>
        public List<int> ListaCaracteristicas
        {
            get { return _listaCaracteristicas; }
            set { _listaCaracteristicas = value; }
        }
        #endregion Propiedades

        #region Constructor
        public OLicenciaProducto()
            : base()
        {

        }
        public OLicenciaProducto(int id, string nombre)
            : base(id, nombre)
        {

        }
        #endregion Constructor

        #region Métodos privados
        #endregion Métodos privados

        #region Métodos públicos

        public override bool IncrementarUso(string idDispositivo, int n = 1)
        {
            try
            {
                if (base.IncrementarUso(idDispositivo, n))
                {
                    foreach (int id in _listaCaracteristicas)
                    {
                        OLicenciaCaracteristica car = OGestorLicencias.GetCaracteristicaLicenciada(id);
                        try
                        {
                            car.IncrementarUso(idDispositivo, n);
                        }
                        catch(Exception e2)
                        {
                            throw e2;
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                throw e1;
            }
            return true;

        }

        public override bool LiberarUso(string idDispositivo, int n = 1)
        {
            try
            {
                if (base.LiberarUso(idDispositivo, n))
                {
                    foreach (int id in _listaCaracteristicas)
                    {
                        OLicenciaCaracteristica car = OGestorLicencias.GetCaracteristicaLicenciada(id);
                        try
                        {
                            car.LiberarUso(idDispositivo, n);
                        }
                        catch (Exception e2)
                        {
                            throw e2;
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                throw e1;
            }
            return true;

        }
        
        
        #endregion Métodos públicos
    }
}

