using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.MS.Excepciones;

namespace Orbita.MS.Licencias
{    /// <summary>
    /// Define un elemento de licencia
    /// </summary>
    public class OLicenciaElemento
    {
        #region Atributos

        #region Identificación

        /// <summary>
        /// Identificador de característica
        /// </summary>
        protected int _id = -1;
        /// <summary>
        /// Nombre interno
        /// </summary>
        protected string _nombreInterno = "";
        /// <summary>
        /// Nombre completo
        /// </summary>
        protected string _nombre = "";
        /// <summary>
        /// Descripción
        /// </summary>
        protected string _descripcion = "";
        #endregion Identificación

        #region Información estadística y de control
        /// <summary>
        /// Elementos usados
        /// </summary>
        protected int _usadas = 0;
        /// <summary>
        /// Elementos inválidos
        /// </summary>
        protected int _invalidas = 0;
        /// <summary>
        /// Elementos en conflicto
        /// </summary>
        protected int _conflicto = 0;
        /// <summary>
        /// Elementos totales
        /// </summary>
        protected int _total = 0;

        /// <summary>
        /// Anota los dispositivos que consumen licencias.
        /// </summary>
        private List<string> _dispositivoConsumo = new List<string>() { };
        /// <summary>
        /// Dispositivos de origen.
        /// </summary>
        private List<string> _dispositivoOrigen = new List<string>() { };




        #endregion Informacion estádistica y de control

        #region Auxiliares
        /// <summary>
        /// Objeto de control para valores activos.
        /// </summary>
        object _valoresActivos = new object();
        #endregion Auxiliares
        #endregion Atributos

        #region Propiedades
        #region Identificación

        /// <summary>
        /// Identificador de característica
        /// </summary>
        public int Id
        {
            get { return _id; }
        }
        /// <summary>
        /// Nombre interno
        /// </summary>
        public string NombreInterno
        {
            get { return _nombreInterno; }
        }
        /// <summary>
        /// Nombre completo
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        #endregion Identificación

        #region Información estadística y de control

        /// <summary>
        /// Elementos disponibles
        /// </summary>
        public int Disponibles
        {
            get { lock (_valoresActivos) { return _total - _usadas - _invalidas - _conflicto; } }
        }
        /// <summary>
        /// Elementos usados
        /// </summary>
        public int Usadas
        {
            get { lock (_valoresActivos) { return _usadas; } }
        }
        /// <summary>
        /// Elementos inválidos
        /// </summary>
        public int Invalidas
        {
            get { lock (_valoresActivos) { return _invalidas; } }
        }
        /// <summary>
        /// Elementos en conflicto
        /// </summary>
        public int Conflicto
        {
            get { lock (_valoresActivos) { return _conflicto; } }
        }
        /// <summary>
        /// Elementos totales
        /// </summary>
        public int Total
        {
            get { lock (_valoresActivos) { return _total; } }
        }

        /// <summary>
        /// Contiene los dispositivos que consumen licencias.
        /// </summary>
        public List<string> DispositivoConsumo
        {
            get { return _dispositivoConsumo; }
            set { _dispositivoConsumo = value; }
        }
        /// <summary>
        /// Contiene los dispositivos de origen
        /// </summary>
        public List<string> DispositivoOrigen
        {
            get { return _dispositivoOrigen; }
            set { _dispositivoOrigen = value; }
        }
        #endregion Informacion estádistica y de control
        #endregion Propiedades
        #region Constructor
        public OLicenciaElemento()
        {

        }
        public OLicenciaElemento(int id, string nombreInterno)
        {
            this._id = id;
            this._nombreInterno = nombreInterno;
            this._nombre = NombreInterno;
        }
        #endregion Constructor

        #region Métodos privados
        #endregion Métodos privados

        #region Métodos públicos

        public override string ToString()
        {
            return this.Id + ": " + this.NombreInterno + " (" + this.Nombre + ") [" + _total + "-" + _usadas + "-" + _invalidas + "-" + _conflicto + "]";
        }
        /// <summary>
        /// Anota que hay disponibles N nuevos elementos en el recurso.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public virtual bool IncrementarRecurso(int n=1)
        {
            if (n < 1)
            {
                throw new ArgumentException("Deben ser valores positivos >0");
            }
            lock (_valoresActivos)
            {
                _total += n;
            }
            return true;
        }
        /// <summary>
        /// Elimina N unidades del recurso.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public virtual bool DecrementarRecurso(int n = 1)
        {
            if (n < 1)
            {
                throw new ArgumentException("Deben ser valores positivos >0.");
            }

            lock (_valoresActivos)
            {

                _total -= n;
               
                if (_total < 0)
                { //Salvaguarda en caso de corrupción
                    _total = 0;
                }
            }

            return true;
        }
        /// <summary>
        /// Anota los N elementos del recurso
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public virtual bool IncrementarUso(string idDispositivo, int n=1)
        {
            
            if (n < 1)
            {
                throw new ArgumentException("Deben ser valores positivos >0.");
            }
            
            lock (_valoresActivos)
            {
                if (_usadas + _conflicto + _invalidas > _total)
                {
                    throw new OExcepcionLicenciaUso(n,Disponibles, _nombre);
                }
                _usadas += n;
                try
                {
                    _dispositivoConsumo.Add(idDispositivo);
                }
                catch (Exception) { }
            }

            return true;
        }
        
        /// <summary>
        /// Libera N unidades bloqueadas del recurso
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public virtual bool LiberarUso(string idDispositivo, int n = 1)
        {


            if (n < 1)
            {
                throw new ArgumentException("Deben ser valores positivos >0.");
            }

            lock (_valoresActivos)
            {
                _usadas -= n;
                if (_usadas < 0)
                { //Salvaguarda en caso de corrupción
                    _usadas = 0;
                }
                try
                {
                    _dispositivoConsumo.Remove(idDispositivo);
                }
                catch (Exception) { }
            }

            return true;
        }
        #endregion Métodos públicos
    }
}
