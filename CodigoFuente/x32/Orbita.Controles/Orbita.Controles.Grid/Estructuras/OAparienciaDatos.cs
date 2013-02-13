namespace Orbita.Controles.Grid
{
    public struct OAparienciaDatos
    {
        #region Atributos
        System.Drawing.Color colorBorde;
        System.Drawing.Color colorFondo;
        System.Drawing.Color colorTexto;
        EstiloBorde estiloBorde;
        AlineacionHorizontal alineacionTextoHorizontal;
        AlineacionVertical alineacionTextoVertical;
        AdornoTexto adornoTexto;
        #endregion

        #region Propiedades
        public System.Drawing.Color ColorBorde
        {
            get { return this.colorBorde; }
            set { this.colorBorde = value; }
        }
        public System.Drawing.Color ColorFondo
        {
            get { return this.colorFondo; }
            set { this.colorFondo = value; }
        }
        public System.Drawing.Color ColorTexto
        {
            get { return this.colorTexto; }
            set { this.colorTexto = value; }
        }
        public EstiloBorde EstiloBorde
        {
            get { return this.estiloBorde; }
            set { this.estiloBorde = value; }
        }
        public AlineacionHorizontal AlineacionTextoHorizontal
        {
            get { return this.alineacionTextoHorizontal; }
            set { this.alineacionTextoHorizontal = value; }
        }
        public AlineacionVertical AlineacionTextoVertical
        {
            get { return this.alineacionTextoVertical; }
            set { this.alineacionTextoVertical = value; }
        }
        public AdornoTexto AdornoTexto
        {
            get { return this.adornoTexto; }
            set { this.adornoTexto = value; }
        }
        #endregion
    }
}
