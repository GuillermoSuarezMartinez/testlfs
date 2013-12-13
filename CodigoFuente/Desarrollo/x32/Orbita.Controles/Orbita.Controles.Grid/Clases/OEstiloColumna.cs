//***********************************************************************
// Assembly         : Orbita.Controles.Grid
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
    public class OEstiloColumna
    {
        #region Atributos
        /// <summary>
        /// Nombre del campo en base de datos.
        /// </summary>
        string campo;
        /// <summary>
        /// Texto del header del campo.
        /// </summary>
        string nombre;
        /// <summary>
        /// Estilo de la columna.
        /// </summary>
        EstiloColumna estilo = EstiloColumna.Texto;
        /// <summary>
        /// Alineación del campo (celdas).
        /// </summary>
        Alineacion alinear = Alineacion.Izquierda;
        /// <summary>
        /// Ancho de la columna.
        /// </summary>
        int ancho = -1;
        /// <summary>
        /// Máscara aplicada.
        /// </summary>
        OMascara mascara = null;
        /// <summary>
        /// Sumario de columna.
        /// </summary>
        OColumnaSumario sumario = null;
        /// <summary>
        /// Columna no accesible en edición.
        /// </summary>
        bool bloqueado = false;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        public OEstiloColumna(string campo, string nombre)
        {
            this.campo = campo;
            this.nombre = nombre;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="ancho">Ancho de la columna</param>
        public OEstiloColumna(string campo, string nombre, int ancho)
            : this(campo, nombre)
        {
            this.ancho = ancho;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo)
            : this(campo, nombre)
        {
            this.estilo = estilo;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="ancho">Ancho de la columna</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, int ancho)
            : this(campo, nombre, ancho)
        {
            this.estilo = estilo;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="mascara">Máscara aplicada</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, OMascara mascara)
            : this(campo, nombre, estilo)
        {
            this.mascara = mascara;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="ancho">Ancho de la columna</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, OMascara mascara, int ancho)
            : this(campo, nombre, estilo, mascara)
        {
            this.ancho = ancho;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="alinear">Alineación del campo (celdas)</param>
        public OEstiloColumna(string campo, string nombre, Alineacion alinear)
            : this(campo, nombre)
        {
            this.alinear = alinear;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param>
        public OEstiloColumna(string campo, string nombre, Alineacion alinear, int ancho)
            : this(campo, nombre, ancho)
        {
            this.alinear = alinear;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, Alineacion alinear)
            : this(campo, nombre, estilo)
        {
            this.alinear = alinear;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param>
        /// <param name="ancho">Ancho de la columna</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, Alineacion alinear, int ancho)
            : this(campo, nombre, estilo, ancho)
        {
            this.alinear = alinear;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param> 
        /// <param name="mascara">Máscara aplicada</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, Alineacion alinear, OMascara mascara)
            : this(campo, nombre, estilo, mascara)
        {
            this.alinear = alinear;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param>
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="ancho">Ancho de la columna</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, Alineacion alinear, OMascara mascara, int ancho)
            : this(campo, nombre, estilo, mascara, ancho)
        {
            this.alinear = alinear;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="sumario">Sumario de columna</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, OMascara mascara, OColumnaSumario sumario)
            : this(campo, nombre, estilo, mascara)
        {
            this.sumario = sumario;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="sumario">Sumario de columna</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, OMascara mascara, int ancho, OColumnaSumario sumario)
            : this(campo, nombre, estilo, mascara, ancho)
        {
            this.sumario = sumario;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param> 
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="sumario">Sumario de columna</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, Alineacion alinear, OMascara mascara, OColumnaSumario sumario)
            : this(campo, nombre, estilo, alinear, mascara)
        {
            this.sumario = sumario;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param>
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="sumario">Sumario de columna</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, Alineacion alinear, OMascara mascara, OColumnaSumario sumario, int ancho)
            : this(campo, nombre, estilo, alinear, mascara, ancho)
        {
            this.sumario = sumario;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, bool bloqueado)
            : this(campo, nombre)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, int ancho, bool bloqueado)
            : this(campo, nombre, ancho)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, bool bloqueado)
            : this(campo, nombre, estilo)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, int ancho, bool bloqueado)
            : this(campo, nombre, estilo, ancho)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, OMascara mascara, bool bloqueado)
            : this(campo, nombre, estilo, mascara)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, OMascara mascara, int ancho, bool bloqueado)
            : this(campo, nombre, estilo, mascara, ancho)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="alinear">Alineación del campo (celdas)</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, Alineacion alinear, bool bloqueado)
            : this(campo, nombre, alinear)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, Alineacion alinear, int ancho, bool bloqueado)
            : this(campo, nombre, alinear, ancho)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, Alineacion alinear, bool bloqueado)
            : this(campo, nombre, estilo, alinear)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, Alineacion alinear, int ancho, bool bloqueado)
            : this(campo, nombre, estilo, alinear, ancho)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param> 
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, Alineacion alinear, OMascara mascara, bool bloqueado)
            : this(campo, nombre, estilo, alinear, mascara)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param>
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, Alineacion alinear, OMascara mascara, int ancho, bool bloqueado)
            : this(campo, nombre, estilo, alinear, mascara, ancho)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="sumario">Sumario de columna</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, OMascara mascara, OColumnaSumario sumario, bool bloqueado)
            : this(campo, nombre, estilo, mascara, sumario)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="sumario">Sumario de columna</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, OMascara mascara, int ancho, OColumnaSumario sumario, bool bloqueado)
            : this(campo, nombre, estilo, mascara, ancho, sumario)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param> 
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="sumario">Sumario de columna</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, Alineacion alinear, OMascara mascara, OColumnaSumario sumario, bool bloqueado)
            : this(campo, nombre, estilo, alinear, mascara, sumario)
        {
            this.bloqueado = bloqueado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OEstiloColumna.
        /// </summary>
        /// <param name="campo">Nombre del campo en base de datos</param>
        /// <param name="nombre">Texto del header del campo</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param>
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="sumario">Sumario de columna</param>
        /// <param name="bloqueado">Columna no accesible en edición</param>
        public OEstiloColumna(string campo, string nombre, EstiloColumna estilo, Alineacion alinear, OMascara mascara, OColumnaSumario sumario, int ancho, bool bloqueado)
            : this(campo, nombre, estilo, alinear, mascara, sumario, ancho)
        {
            this.bloqueado = bloqueado;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Nombre del campo en base de datos.
        /// </summary>
        public string Campo
        {
            get { return this.campo; }
            set { this.campo = value; }
        }
        /// <summary>
        /// Texto de la cabecera del campo.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        /// <summary>
        /// Estilo de la columna.
        /// </summary>
        public EstiloColumna Estilo
        {
            get { return this.estilo; }
            set { this.estilo = value; }
        }
        /// <summary>
        /// Alineación del campo (celdas).
        /// </summary>
        public Alineacion Alinear
        {
            get { return this.alinear; }
            set { this.alinear = value; }
        }
        /// <summary>
        /// Ancho de la columna.
        /// </summary>
        public int Ancho
        {
            get { return this.ancho; }
            set { this.ancho = value; }
        }
        /// <summary>
        /// Máscara aplicada. \n
        /// #  Digito \n
        /// n  Numero \n
        /// .  Separador decimal \n
        /// ,  Separador de miles \n
        /// :  Separador de hora \n
        /// /  Separador de fecha \n
        /// hh,mm,ss,tt  Fecha"
        /// </summary>
        public OMascara Mascara
        {
            get { return this.mascara; }
            set { this.mascara = value; }
        }
        /// <summary>
        /// Indica el sumario de la columna
        /// </summary>
        public OColumnaSumario Sumario
        {
            get { return this.sumario; }
            set { this.sumario = value; }
        }
        /// <summary>
        /// Indica si la columna es accesible
        /// </summary>
        public bool Bloqueado
        {
            get { return this.bloqueado; }
            set { this.bloqueado = value; }
        }
        #endregion
    }
}