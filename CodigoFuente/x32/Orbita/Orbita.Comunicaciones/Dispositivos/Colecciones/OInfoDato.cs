using System;
namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Clase para todos las variables del servidor de comunicaciones.
    /// </summary>
    [Serializable]
    public class OInfoDato
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase OInfoDato.
        /// </summary>
        public OInfoDato()
        {
            ESAlarma = false;
            ESVisualizacion = false;
            ESLectura = false;
        }
        #endregion Constructor

        #region Propiedades
        /// <summary>
        /// Identificador.
        /// </summary>
        public int Identificador { get; set; }
        /// <summary>
        /// Identificador de lectura.
        /// </summary>
        public int IdLectura { get; set; }
        /// <summary>
        /// Conexión.
        /// </summary>
        public string Conexion { get; set; }
        /// <summary>
        /// DB.
        /// </summary>
        public int DB { get; set; }
        /// <summary>
        /// Direccion.
        /// </summary>
        public int Direccion { get; set; }
        /// <summary>
        /// Bit.
        /// </summary>
        public int Bit { get; set; }
        /// <summary>
        /// Texto.
        /// </summary>
        public string Texto { get; set; }
        /// <summary>
        /// Descripción.
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Enlace.
        /// </summary>
        public string Enlace { get; set; }
        /// <summary>
        /// Tipo.
        /// </summary>
        public string Tipo { get; set; }
        /// <summary>
        /// Valor.
        /// </summary>
        public object Valor { get; set; }
        /// <summary>
        /// Valor por defecto de la variable.
        /// </summary>
        public object ValorDefecto { get; set; }
        /// <summary>
        /// Último valor.
        /// </summary>
        public object UltimoValor { get; set; }
        /// <summary>
        /// Error.
        /// </summary>
        public int Error { get; set; }
        /// <summary>
        /// Calidad.
        /// </summary>
        public string Calidad { get; set; }
        /// <summary>
        /// Alarma.
        /// </summary>
        public bool ESAlarma { get; set; }
        /// <summary>
        /// Lectura.
        /// </summary>
        public bool ESLectura { get; set; }
        /// <summary>
        /// Visualización.
        /// </summary>
        public bool ESVisualizacion { get; set; }
        /// <summary>
        /// Dispositivo.
        /// </summary>
        public int Dispositivo { get; set; }
        /// <summary>
        /// Indica si la variable es una entrada.
        /// </summary>
        public bool EsEntrada { get; set; }
        /// <summary>
        /// Canal que ejecuta el cambio de valor.
        /// </summary>
        public string CanalCambioDato { get; set; }
        #endregion Propiedades
    }
}