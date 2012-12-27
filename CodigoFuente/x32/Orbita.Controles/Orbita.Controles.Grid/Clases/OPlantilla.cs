//***********************************************************************
// Assembly         : Orbita.Controles
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Grid
{
    /// <summary>
    /// Plantilla.
    /// </summary>
    public class OPlantilla
    {
        #region Atributos privados
        /// <summary>
        /// Identificador.
        /// </summary>
        int identificador;
        /// <summary>
        /// Control.
        /// </summary>
        string control;
        /// <summary>
        /// Nombre.
        /// </summary>
        string nombre;
        /// <summary>
        /// Descripción.
        /// </summary>
        string descripcion;
        /// <summary>
        /// Estructura.
        /// </summary>
        byte[] estructura;
        /// <summary>
        /// Usuario.
        /// </summary>
        string usuario;
        /// <summary>
        /// Activo.
        /// </summary>
        bool activo;
        /// <summary>
        /// Primero.
        /// </summary>
        bool primero;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.Plantilla.
        /// </summary>
        public OPlantilla() { }
        #endregion

        #region Propiedades
        /// <summary>
        /// Identificador.
        /// </summary>
        public int Identificador
        {
            get { return this.identificador; }
            set { this.identificador = value; }
        }
        /// <summary>
        /// Clave.
        /// </summary>
        public string Clave
        {
            get { return this.identificador.ToString(System.Globalization.CultureInfo.CurrentCulture); }
        }
        /// <summary>
        /// Control.
        /// </summary>
        public string Control
        {
            get { return this.control; }
            set { this.control = value; }
        }
        /// <summary>
        /// Nombre.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        /// <summary>
        /// Descripción.
        /// </summary>
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }
        /// <summary>
        /// Usuario.
        /// </summary>
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }
        /// <summary>
        /// Activo.
        /// </summary>
        public bool Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }
        /// <summary>
        /// Primero.
        /// </summary>
        public bool Primero
        {
            get { return this.primero; }
            set { this.primero = value; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Estructura.
        /// </summary>
        public byte[] GetEstructura()
        {
            return this.estructura;
        }
        /// <summary>
        /// Estructura.
        /// </summary>
        public void SetEstructura(byte[] valor)
        {
            this.estructura = valor;
        }
        #endregion
    }
}