namespace Orbita.Controles.Grid
{
    /// <summary>
    /// OIColumnaInfo.
    /// </summary>
    public class OColumnaInfo : System.IComparable<OColumnaInfo>
    {
        #region Atributos privados
        /// <summary>
        /// Posición.
        /// </summary>
        int posicion;
        /// <summary>
        /// Identificador.
        /// </summary>
        string identificador;
        /// <summary>
        /// Nombre.
        /// </summary>
        string nombre;
        /// <summary>
        /// Banda.
        /// </summary>
        int banda;
        /// <summary>
        /// Visibilidad.
        /// </summary>
        bool visible;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Columna.
        /// </summary>
        public OColumnaInfo() { }
        #endregion

        #region Propiedades
        public int Posicion
        {
            get { return this.posicion; }
            set { this.posicion = value; }
        }
        public string Identificador
        {
            get { return this.identificador; }
            set { this.identificador = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Banda
        {
            get { return this.banda; }
            set { this.banda = value; }
        }
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
        public string ColumnaInfo
        {
            get;
            private set;
        }
        #endregion

        #region IComparable
        public int CompareTo(OColumnaInfo other)
        {
            if (other == null) return 0;
            if (this.posicion < other.posicion) return -1;
            else if (this.posicion > other.posicion) return 1;
            else return 0;
        }
        public static int Compare(OColumnaInfo left, OColumnaInfo right)
        {
            if (object.ReferenceEquals(left, right))
            {
                return 0;
            }
            if (object.ReferenceEquals(left, null))
            {
                return -1;
            }
            return left.CompareTo(right);
        }
        // Omitting Equals violates rule: OverrideMethodsOnComparableTypes.
        public override bool Equals(object obj)
        {
            OColumnaInfo other = obj as OColumnaInfo; //avoid double casting
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return this.CompareTo(other) == 0;
        }
        // Omitting getHashCode violates rule: OverrideGetHashCodeOnOverridingEquals.
        public override int GetHashCode()
        {
            char[] c = this.ColumnaInfo.ToCharArray();
            return (int)c[0];
        }
        // Omitting any of the following operator overloads 
        // violates rule: OverrideMethodsOnComparableTypes.
        public static bool operator ==(OColumnaInfo left, OColumnaInfo right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return object.ReferenceEquals(right, null);
            }
            return left.Equals(right);
        }
        public static bool operator !=(OColumnaInfo left, OColumnaInfo right)
        {
            return !(left == right);
        }
        public static bool operator <(OColumnaInfo left, OColumnaInfo right)
        {
            return (Compare(left, right) < 0);
        }
        public static bool operator >(OColumnaInfo left, OColumnaInfo right)
        {
            return (Compare(left, right) > 0);
        }
        #endregion
    }
}
