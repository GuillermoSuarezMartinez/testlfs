namespace Orbita.Controles.Grid
{
    /// <summary>
    /// Orbita.Controles.Grid.OMascara.
    /// </summary>
    public class OMascara
    {
        #region Atributos
        /// <summary>
        /// Expresión de máscara.
        /// </summary>
        string nombre = string.Empty;
        /// <summary>
        /// Caracter de separación.
        /// </summary>
        char prompt = ' ';
        /// <summary>
        /// Valor máximo del campo.
        /// </summary>
        object maximo = null;
        /// <summary>
        /// Valor mínimo del campo.
        /// </summary>
        object minimo = null;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Mascara.
        /// </summary>
        /// <param name="nombre">Expresión de máscara</param>
        public OMascara(string nombre)
        {
            this.nombre = nombre;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Mascara.
        /// </summary>
        /// <param name="nombre">Expresión de máscara.</param>
        /// <param name="prompt">Caracter de separación.</param>
        public OMascara(string nombre, char prompt)
            : this(nombre)
        {
            this.prompt = prompt;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Mascara.
        /// </summary>
        /// <param name="nombre">Expresión de máscara</param>
        /// <param name="maximo">Valor máximo del campo</param>
        /// <param name="minimo">Valor mínimo del campo</param>
        public OMascara(string nombre, object maximo, object minimo)
            : this(nombre)
        {
            this.maximo = maximo;
            this.minimo = minimo;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Mascara.
        /// </summary>
        /// <param name="nombre">Expresión de máscara</param>
        /// <param name="prompt">Caracter de separación</param>
        /// <param name="maximo">Valor máximo del campo</param>
        /// <param name="minimo">Valor mínimo del campo</param>
        public OMascara(string nombre, char prompt, object maximo, object minimo)
            : this(nombre, maximo, minimo)
        {
            this.prompt = prompt;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Expresión de máscara.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        /// <summary>
        /// Caracter de separación.
        /// </summary>
        public char Prompt
        {
            get { return this.prompt; }
            set { this.prompt = value; }
        }
        /// <summary>
        /// Valor máximo del campo.
        /// </summary>
        public object Maximo
        {
            get { return this.maximo; }
            set { this.maximo = value; }
        }
        /// <summary>
        /// Valor mínimo del campo.
        /// </summary>
        public object Minimo
        {
            get { return this.minimo; }
            set { this.minimo = value; }
        }
        #endregion
    }
}
