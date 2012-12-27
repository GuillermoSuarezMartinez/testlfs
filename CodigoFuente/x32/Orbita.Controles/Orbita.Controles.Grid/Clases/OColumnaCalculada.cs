namespace Orbita.Controles.Grid
{
    /// <summary>
    /// Orbita.Controles.ColumnaCalculada.
    /// </summary>
    public class OColumnaCalculada : OEstiloColumna, System.IDisposable
    {
        #region Atributos
        System.Data.DataColumn columna = new System.Data.DataColumn();
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.CampoCalculado.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos.</param>
        /// <param name="nombre">Texto del header del campo.</param>
        /// <param name="estilo">Estilo de la columna.</param>
        /// <param name="mascara">Máscara aplicada.</param>
        /// <param name="tipo">Tipo de campo.</param>
        /// <param name="formula">Expresión que genera el cálculo.</param>
        public OColumnaCalculada(string campo, string nombre, EstiloColumna estilo, OMascara mascara, string tipo, string formula)
            : base(campo, nombre, estilo, mascara, true)
        {
            this.columna.DataType = System.Type.GetType(tipo);
            this.columna.ColumnName = campo;
            this.columna.Expression = formula;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.CampoCalculado.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param> 
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="tipo">Tipo de campo</param>
        /// <param name="formula">Expresión que genera el cálculo</param>
        public OColumnaCalculada(string campo, string nombre, EstiloColumna estilo, Alineacion alinear, OMascara mascara, int ancho, string tipo, string formula)
            : base(campo, nombre, estilo, alinear, mascara, ancho, true)
        {
            this.columna.DataType = System.Type.GetType(tipo);
            this.columna.ColumnName = campo;
            this.columna.Expression = formula;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.CampoCalculado.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="sumario">Sumario de columna</param>
        /// <param name="tipo">Tipo de campo</param>
        /// <param name="formula">Expresión que genera el cálculo</param>
        public OColumnaCalculada(string campo, string nombre, EstiloColumna estilo, OMascara mascara, OSumario sumario, string tipo, string formula)
            : base(campo, nombre, estilo, mascara, sumario, true)
        {
            this.columna.DataType = System.Type.GetType(tipo);
            this.columna.ColumnName = campo;
            this.columna.Expression = formula;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.CampoCalculado.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param> 
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="sumario">Sumario de columna</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="tipo">Tipo de campo</param>
        /// <param name="formula">Expresión que genera el cálculo</param>
        public OColumnaCalculada(string campo, string nombre, EstiloColumna estilo, Alineacion alinear, OMascara mascara, OSumario sumario, int ancho, string tipo, string formula)
            : base(campo, nombre, estilo, alinear, mascara, sumario, ancho, true)
        {
            this.columna.DataType = System.Type.GetType(tipo);
            this.columna.ColumnName = campo;
            this.columna.Expression = formula;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Indica si ya se llamo al método Dispose. (Default = false)
        /// </summary>
        bool disposed = false;
        /// <summary>
        /// Implementa IDisposable.
        /// No  hacer  este  método  virtual.
        /// Una clase derivada no debería ser
        /// capaz de  reemplazar este método.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que  contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
            // Este objeto será limpiado por el método Dispose.
            // Llama al método del recolector de basura, GC.SuppressFinalize.
            System.GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Método  sobrecargado de  Dispose que será  el que
        /// libera los recursos. Controla que solo se ejecute
        /// dicha lógica una  vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name="disposing">Indica si llama al método Dispose.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Preguntar si Dispose ya fue llamado.
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Llamar a dispose de todos los recursos manejados.
                    this.columna.Dispose();
                }
                disposed = true;
            }
        }
        /// <summary>
        /// Destructor(es) de clase.
        /// En caso de que se nos olvide “desechar” la clase,
        /// el GC llamará al destructor, que tambén ejecuta 
        /// la lógica anterior para liberar los recursos.
        /// </summary>
        ~OColumnaCalculada()
        {
            // Llamar a Dispose(false) es óptimo en terminos de legibilidad y mantenimiento.
            Dispose(false);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Hace referencia a la columna.
        /// </summary>
        public System.Data.DataColumn Calculada
        {
            get { return this.columna; }
            set { this.columna = value; }
        }
        #endregion
    }
}
