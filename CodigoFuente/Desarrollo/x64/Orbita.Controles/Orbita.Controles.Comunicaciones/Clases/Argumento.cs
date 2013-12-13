namespace Orbita.Controles.Comunicaciones
{
    /// <summary>
    /// Clase para gestión de argumentos (de log) desde fichero de configuración.
    /// </summary>
    public class Argumento
    {
        #region Atributos
        /// <summary>
        /// Identificador del argumento.
        /// </summary>
        int _id;
        /// <summary>
        /// Nombre del argumento (texto de la columna en grid).
        /// </summary>
        string _nombre;
        /// <summary>
        /// Tag para marcar si se muestra como columna en grid.
        /// </summary>
        bool _mostrarEnGrid;
        /// <summary>
        /// Ancho columna en grid.
        /// </summary>
        int _with;
        /// <summary>
        /// Posición de columna en grid.
        /// </summary>
        int _posicionColumna;
        /// <summary>
        /// Estilo de columna en grid.
        /// </summary>
        Orbita.Controles.Grid.EstiloColumna _estilo;
        /// <summary>
        /// Alineación de columna en grid.
        /// </summary>
        Orbita.Controles.Grid.Alineacion _alineacion;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Argumento()
        {
            this._alineacion = Orbita.Controles.Grid.Alineacion.Izquierda;
            this._estilo = Orbita.Controles.Grid.EstiloColumna.Texto;
            this._id = 0;
            this._mostrarEnGrid = false;
            this._nombre = string.Empty;
            this._posicionColumna = 0;
            this._with = 0;
        }
        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        /// <param name="id">Identificador del argumento.</param>
        /// <param name="nombre">Nombre del argumento (texto de la columna en grid).</param>
        /// <param name="mostrarEnGrid">Tag para marcar si se muestra como columna en grid.</param>
        /// <param name="with">Ancho de columna en grid.</param>
        /// <param name="posicionColumna">Posición de columna en grid.</param>
        /// <param name="estilo">Identificador del estilo de columna.</param>
        public Argumento(int id, string nombre, bool mostrarEnGrid, int with, int posicionColumna, int estilo)
        {
            this._id = id;
            this._mostrarEnGrid = mostrarEnGrid;
            this._nombre = nombre;
            this._with = with;
            this._posicionColumna = posicionColumna;
            this._estilo = this.GetEstilo(estilo);
            this._alineacion = this.GetAlineacion();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Identificador del argumento.
        /// </summary>
        public int ID
        {
            get { return this._id; }
            set { this._id = value; }
        }
        /// <summary>
        /// Nombre del argumento (texto de la columna en grid).
        /// </summary>
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        /// <summary>
        /// Tag para marcar si se muestra como columna en grid.
        /// </summary>
        public bool MostrarEnGrid
        {
            get { return this._mostrarEnGrid; }
            set { this._mostrarEnGrid = value; }
        }
        /// <summary>
        /// Ancho columna en grid.
        /// </summary>
        public int With
        {
            get { return this._with; }
            set { this._with = value; }
        }
        /// <summary>
        /// Ancho columna en grid.
        /// </summary>
        public int PosicionColumna
        {
            get { return this._posicionColumna; }
            set { this._posicionColumna = value; }
        }
        /// <summary>
        /// Estilo columna en grid.
        /// </summary>
        public Orbita.Controles.Grid.EstiloColumna Estilo
        {
            get { return this._estilo; }
            set { this._estilo = value; }
        }
        /// <summary>
        /// Alineación columna en grid.
        /// </summary>
        public Orbita.Controles.Grid.Alineacion Alineacion
        {
            get { return this._alineacion; }
            set { this._alineacion = value; }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Obtiene el estilo de una columna a partir del identificador.
        /// </summary>
        /// <param name="idEstilo">Identificador estilo columna.</param>
        /// <returns>Estilo columna orbita.</returns>
        Orbita.Controles.Grid.EstiloColumna GetEstilo(int idEstilo)
        {
            switch (idEstilo)
            {
                case 1:
                    return Orbita.Controles.Grid.EstiloColumna.Texto;
                case 2:
                    return Orbita.Controles.Grid.EstiloColumna.Numerico;
                case 3:
                    return Orbita.Controles.Grid.EstiloColumna.NumericoDecimal;
                case 4:
                    return Orbita.Controles.Grid.EstiloColumna.FechaHora;
                case 5:
                    return Orbita.Controles.Grid.EstiloColumna.Check;
                default:
                    return Orbita.Controles.Grid.EstiloColumna.Texto;
            }
        }
        /// <summary>
        /// Obtiene la alineación de la columna.
        /// </summary>
        /// <returns>Alineación columna Orbita.</returns>
        Orbita.Controles.Grid.Alineacion GetAlineacion()
        {
            switch (_estilo)
            {
                case Orbita.Controles.Grid.EstiloColumna.Check:
                case Orbita.Controles.Grid.EstiloColumna.FechaHora:
                    return Orbita.Controles.Grid.Alineacion.Centrado;
                case Orbita.Controles.Grid.EstiloColumna.Numerico:
                case Orbita.Controles.Grid.EstiloColumna.NumericoDecimal:
                    return Orbita.Controles.Grid.Alineacion.Derecha;
                default:
                    return Orbita.Controles.Grid.Alineacion.Izquierda;
            }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Asigna los estilos de columna.
        /// </summary>
        /// <param name="idEstilo">Identificador del estilo.</param>
        public void SetEstilosGrid(int idEstilo)
        {
            this._estilo = this.GetEstilo(idEstilo);
            this._alineacion = this.GetAlineacion();
        }
        #endregion
    }
}