//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 06-09-2012
//
// Pendiente        : Los valores decimales deben soportar tambien strings
//
// Last Modified By : aibañez
// Last Modified On : 12-12-2012
// Description      : Modificados validaciones de enteros y enumerados 
//                    para soportar valores string
//                    Cambiado el log de Info por Debug
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Globalization;
using System.Text;
namespace Orbita.Utiles
{
    #region ORobusto
    /// <summary>
    /// Clase estática destinada a alojar métodos genéricos para el manejo de objetos de forma segura
    /// </summary>
    public static class OObjeto
    {
        #region Método(s) estático(s)
        /// <summary>
        /// Función que devuelve si el objeto pertenece a alguno de los tipos listados
        /// </summary>
        /// <param name="o">Objeto que se quiere conocer el tipo</param>
        /// <param name="types">Vector de tipos con lo que se ha de comparar el tipo del objeto</param>
        /// <returns>Verdadero si el tipo del objeto está dentro de la lista de tipos pasados como parámetros</returns>
        public static bool IsTypeOf(object o, params Type[] types)
        {
            foreach (Type t in types)
            {
                if (o.GetType() == t)
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Indica si el objeto pasado es de tipo numérico
        /// </summary>
        /// <param name="o">Objeto que se quiere conocer si es de tipo numérico</param>
        /// <returns>Verdadero si el tipo del objeto es numérico</returns>
        public static bool IsNumeric(object o)
        {
            return (o != null) && IsTypeOf(o, typeof(int), typeof(short), typeof(long), typeof(uint), typeof(ushort), typeof(ulong), typeof(byte), typeof(float), typeof(double), typeof(decimal));
        }
        /// <summary>
        /// Convierte un objeto a string
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string ToString(object valor)
        {
            return valor != null ? valor.ToString() : string.Empty;
        }
        /// <summary>
        /// Realiza una comparación entre dos objetos
        /// </summary>
        /// <param name="valor1">Primer objeto a comparar</param>
        /// <param name="valor2">Segundo objeto a comparar</param>
        /// <returns></returns>
        public static bool CompararObjetos(object valor1, object valor2)
        {
            bool resultado = false;

            if ((valor1 == null) && (valor2 == null))
            {
                // Ambos son null
                return true;
            }

            if ((valor1 != null) && (valor2 != null))
            {
                if (valor1.GetType() != valor2.GetType())
                {
                    // No son del mismo tipo
                    return false;
                }

                if (valor1 is byte[])
                {
                    byte[] valorByte1 = (byte[])valor1;
                    byte[] valorByte2 = (byte[])valor2;

                    if (valorByte1.Length != valorByte2.Length)
                    {
                        // No tienen la misma longitud
                        return false;
                    }

                    for (int i = 0; i < valorByte1.Length; i++)
                    {
                        if (valorByte1[i] != valorByte2[i])
                        {
                            // Tienen algun valor distinto
                            return false;
                        }
                    }

                    // Los arrays son iguales
                    return true;
                }

                return valor1.Equals(valor2);
            }

            return resultado;
        }
        #endregion
    }
    #endregion

    #region Objeto Robusto
    /// <summary>
    /// Clase base para el trabajo de forma robusta con variables
    /// </summary>
    public class OObjetoBase<ClaseTipo>
    {
        #region Atributos
        /// <summary>
        /// Indica que se ha de lanzar una excepción de tipo InvalidValueException cuando el valor a establecer no sea el correcto
        /// </summary>
        public bool LanzarExcepcionSiValorNoValido;
        /// <summary>
        /// Valor por defecto del objeto
        /// </summary>
        public ClaseTipo ValorPorDefecto;
        #endregion

        #region Propiedades
        /// <summary>
        /// Valor del objeto
        /// </summary>
        protected ClaseTipo _Valor;
        /// <summary>
        /// Valor del objeto
        /// </summary>
        public ClaseTipo Valor
        {
            get
            {
                return _Valor;
            }
            set
            {
                this.ValorGenerico = value;
            }
        }
        /// <summary>
        /// Código identificativo de la clase.
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código identificativo de la clase.
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        /// <summary>
        /// Indica que el valor asignado es válido
        /// </summary>
        public bool Valido
        {
            get { return this.Estado == EnumEstadoObjetoRobusto.ResultadoCorrecto; }
        }
        /// <summary>
        /// Estado del valor actual
        /// </summary>
        private EnumEstadoRobusto _Estado;
        /// <summary>
        /// Estado del valor actual
        /// </summary>
        public EnumEstadoRobusto Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        /// <summary>
        /// Valor del objeto
        /// </summary>
        public object ValorGenerico
        {
            get
            {
                return this.Valor;
            }
            set
            {
                // Validación
                object refObj = value;
                this.Estado = this.Validar(ref refObj);

                // Excepción
                if (this.LanzarExcepcionSiValorNoValido && !this.Valido)
                {
                    this.LanzarExcepcion();
                }

                if (this.Valido)
                {
                    // Asignación
                    this._Valor = (ClaseTipo)refObj;
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OObjetoBase(string codigo, ClaseTipo valorDefecto, bool lanzarExcepcionSiValorNoValido)
        {
            this.Codigo = codigo;
            this.LanzarExcepcionSiValorNoValido = lanzarExcepcionSiValorNoValido;
            this.ValorPorDefecto = valorDefecto;
            this._Valor = valorDefecto;
            this.Estado = EnumEstadoObjetoRobusto.ResultadoCorrecto;
        }
        #endregion

        #region Método(s) virtual(es)
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public virtual EnumEstadoRobusto Validar(ref object valor)
        {
            // Inicialización de resultados
            EnumEstadoRobusto validacion = EnumEstadoTextoRobusto.ValorTipoIncorrecto;
            bool correcto = false;

            // Validación
            if (valor is ClaseTipo)
            {
                validacion = EnumEstadoTextoRobusto.ResultadoCorrecto;
                correcto = true;
            }

            // Devolución de resultados
            return validacion;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        /// <param name="valor">valor no permitido</param>
        public virtual void LanzarExcepcion()
        {
            // Implementado en heredados
        }
        #endregion
    }

    public interface IObjetoBase
    {
        #region Propiedades
        /// <summary>
        /// Código identificativo de la clase.
        /// </summary>
        string Codigo { get; set; }
        /// <summary>
        /// Indica que el valor asignado es válido
        /// </summary>
        bool Valido { get; }
        /// <summary>
        /// Estado del valor actual
        /// </summary>
        EnumEstadoRobusto Estado { get; set; }
        /// <summary>
        /// Valor del objeto
        /// </summary>
        object ValorGenerico { get; set; }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        EnumEstadoRobusto Validar(ref object valor);
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        /// <param name="valor">valor no permitido</param>
        void LanzarExcepcion();
        #endregion
    }

    /// <summary>
    /// Define el conjunto de módulos del sistema
    /// </summary>
    public class EnumEstadoObjetoRobusto : OEnumeradosHeredable
    {
        #region Atributos
        /// <summary>
        /// Módulo de funciones comunes del sistema. 
        /// </summary>
        public static EnumEstadoRobusto ResultadoCorrecto = new EnumEstadoRobusto("ResultadoCorrecto", "ResultadoCorrecto", 1);
        /// <summary>
        /// El valor a asignar no es del tipo correcto
        /// </summary>
        public static EnumEstadoRobusto ValorTipoIncorrecto = new EnumEstadoRobusto("ValorTipoIncorrecto", "ValorTipoIncorrecto", 2);
        #endregion
    }

    /// <summary>
    /// Clase que implementa el enumerado de los módulos del sistema
    /// </summary>
    public class EnumEstadoRobusto : OEnumeradoHeredable
    {
        #region Constructor
        /// <summary>
        /// Constuctor de la clase
        /// </summary>
        public EnumEstadoRobusto(string nombre, string descripcion, int valor) :
            base(nombre, descripcion, valor)
        { }
        #endregion
    }
    #endregion

    #region Texto Robusto
    /// <summary>
    /// Asignación de una variable a un campo de tipo texto
    /// </summary>
    public class OTexto : OObjetoBase<string>
    {
        #region Atributos
        /// <summary>
        /// Máxima longitud del string
        /// </summary>
        public int MaxLength;
        /// <summary>
        /// Indica que es admitido como válido la cadena vacia
        /// </summary>
        public bool AdmiteVacio;
        /// <summary>
        /// Corta el texto en caso de sobreparsar la longitud máxima
        /// </summary>
        public bool LimitarLongitud;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OTexto(string codigo, int maxLength, bool admiteVacio, bool limitarLongitud, string valorDefecto, bool lanzarExcepcionSiValorNoValido)
            : base(codigo, valorDefecto, lanzarExcepcionSiValorNoValido)
        {
            this.MaxLength = maxLength;
            this.AdmiteVacio = admiteVacio;
            this.LimitarLongitud = limitarLongitud;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public override EnumEstadoRobusto Validar(ref object valor)
        {
            // Valores por defecto
            EnumEstadoRobusto validacion = EnumEstadoTextoRobusto.ResultadoCorrecto;
            bool correcto = true;
            string outValor = this.ValorPorDefecto;
            string auxValor = this.ValorPorDefecto;

            // Validación nº 1
            if (correcto)
            {
                if (!(valor is string))
                {
                    validacion = EnumEstadoTextoRobusto.ValorTipoIncorrecto;
                    correcto = false;
                }
            }

            // Validación nº 2
            if (correcto)
            {
                auxValor = (string)valor;
                if (auxValor.Length > this.MaxLength)
                {
                    validacion = EnumEstadoTextoRobusto.LongitudSobrepasada;
                    correcto = false;
                }
            }

            // Validación nº 3
            if (correcto)
            {
                if (!this.AdmiteVacio && (auxValor == string.Empty))
                {
                    validacion = EnumEstadoTextoRobusto.CadenaVacia;
                    correcto = false;
                }
            }

            // Composición de resultado
            if (correcto)
            {
                outValor = auxValor;
            }
            else if ((validacion == EnumEstadoTextoRobusto.LongitudSobrepasada) && this.LimitarLongitud)
            {
                outValor = auxValor.Substring(0, this.MaxLength);
            }
            else
            {
                outValor = this.ValorPorDefecto;
            }

            valor = outValor;
            return validacion;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        /// <param name="resultado">valor no permitido</param>
        public override void LanzarExcepcion()
        {
            if (this.Estado == EnumEstadoTextoRobusto.ValorTipoIncorrecto)
                throw new Exception("El campo " + this.Codigo + " no es válido.");
            if (this.Estado == EnumEstadoTextoRobusto.LongitudSobrepasada)
                throw new Exception("El campo " + this.Codigo + " es demasiado largo.");
            if (this.Estado == EnumEstadoTextoRobusto.CadenaVacia)
                throw new Exception("El campo " + this.Codigo + " no puede estar en blanco.");
        }
        #endregion

        #region Método(s) estático(s)
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static string Validar(object valor, out EnumEstadoRobusto validacion, int maxLength, bool admiteVacio, bool limitarLongitud, string defecto)
        {
            OTexto robusto = new OTexto(string.Empty, maxLength, admiteVacio, limitarLongitud, defecto, false);
            robusto.ValorGenerico = valor;
            validacion = robusto.Estado;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static string Validar(object valor, int maxLength, bool admiteVacio, bool limitarLongitud, string defecto)
        {
            OTexto robusto = new OTexto(string.Empty, maxLength, admiteVacio, limitarLongitud, defecto, false);
            robusto.ValorGenerico = valor;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static string Validar(object valor)
        {
            return Validar(valor, int.MaxValue, true, false, string.Empty);
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto Validar(object valor, string codigo, int maxLength, bool admiteVacio, bool limitarLongitud, string defecto, bool lanzarExcepcionSiValorNoValido)
        {
            OTexto robusto = new OTexto(codigo, maxLength, admiteVacio, limitarLongitud, defecto, lanzarExcepcionSiValorNoValido);
            robusto.ValorGenerico = valor;
            return robusto.Estado;
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto ValidarTexto(object valor, string codigo, int maxLength, bool admiteVacio, bool limitarLongitud, string defecto, bool lanzarExcepcionSiValorNoValido)
        {
            return Validar(valor, codigo, maxLength, admiteVacio, limitarLongitud, defecto, lanzarExcepcionSiValorNoValido);
        }
        /// <summary>
        /// Case insensitive version of String.Replace().
        /// </summary>
        /// <param name="s">String that contains patterns to replace</param>
        /// <param name="oldValue">Pattern to find</param>
        /// <param name="newValue">New pattern to replaces old</param>
        /// <param name="comparisonType">String comparison type</param>
        /// <returns></returns>
        public static string Reemplazar(string s, string oldValue, string newValue, StringComparison comparisonType)
        {
            if (s == null)
                return null;

            if (String.IsNullOrEmpty(oldValue))
                return s;

            StringBuilder result = new StringBuilder(Math.Min(4096, s.Length));
            int pos = 0;

            while (true)
            {
                int i = s.IndexOf(oldValue, pos, comparisonType);
                if (i < 0)
                    break;

                result.Append(s, pos, i - pos);
                result.Append(newValue);

                pos = i + oldValue.Length;
            }
            result.Append(s, pos, s.Length - pos);

            return result.ToString();
        }
        #endregion
    }

    /// <summary>
    /// Asignación de una variable a un campo de tipo texto
    /// </summary>
    public static class OTextoExtension
    {
        #region Método(s) de extensión
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static string ValidarTexto(this object valor, out EnumEstadoRobusto validacion, int maxLength, bool admiteVacio, bool limitarLongitud, string defecto)
        {
            return OTexto.Validar(valor, out validacion, maxLength, admiteVacio, limitarLongitud, defecto);
        }
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static string ValidarTexto(this object valor, int maxLength, bool admiteVacio, bool limitarLongitud, string defecto)
        {
            return OTexto.Validar(valor, maxLength, admiteVacio, limitarLongitud, defecto);
        }
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static string ValidarTexto(this object valor)
        {
            return OTexto.Validar(valor);
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto ValidarTexto(this object valor, string codigo, int maxLength, bool admiteVacio, bool limitarLongitud, string defecto, bool lanzarExcepcionSiValorNoValido)
        {
            return OTexto.Validar(valor, codigo, maxLength, admiteVacio, limitarLongitud, defecto, lanzarExcepcionSiValorNoValido);
        }
        /// <summary>
        /// Case insensitive version of String.Replace().
        /// </summary>
        /// <param name="s">String that contains patterns to replace</param>
        /// <param name="oldValue">Pattern to find</param>
        /// <param name="newValue">New pattern to replaces old</param>
        /// <param name="comparisonType">String comparison type</param>
        /// <returns></returns>
        public static string Reemplazar(this string s, string oldValue, string newValue, StringComparison comparisonType)
        {
            return OTexto.Reemplazar(s, oldValue, newValue, comparisonType);
        }
        #endregion
    }

    /// <summary>
    /// Resultado de la validación del SafeBool
    /// </summary>
    public class EnumEstadoTextoRobusto : EnumEstadoObjetoRobusto
    {
        #region Atributos
        /// <summary>
        /// La longitud del texto es demasiado larga
        /// </summary>
        public static EnumEstadoRobusto LongitudSobrepasada = new EnumEstadoRobusto("LongitudSobrepasada", "LongitudSobrepasada", 12);
        /// <summary>
        /// El texto no contiene ningun caracter
        /// </summary>
        public static EnumEstadoRobusto CadenaVacia = new EnumEstadoRobusto("CadenaVacia", "CadenaVacia", 13);
        #endregion
    }
    #endregion

    #region Enumerado Robusto
    /// <summary>
    /// Asignación de una variable a un campo de tipo enumerado (aunque internamente trabaja como un string)
    /// </summary>
    public class OEnumeradoTexto : OObjetoBase<string>
    {
        #region Atributos
        /// <summary>
        /// Valores permitidos para el texto
        /// </summary>
        public string[] ValoresPermitidos;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OEnumeradoTexto(string codigo, string[] valoresPermitidos, string valorDefecto, bool lanzarExcepcionSiValorNoValido)
            : base(codigo, valorDefecto, lanzarExcepcionSiValorNoValido)
        {
            this.ValoresPermitidos = valoresPermitidos;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public override EnumEstadoRobusto Validar(ref object valor)
        {
            // Valores por defecto
            EnumEstadoRobusto validacion = EnumEstadoEnumRobusto.ResultadoCorrecto;
            bool correcto = true;
            string outValor = this.ValorPorDefecto;
            string auxValor = this.ValorPorDefecto;

            // Validación nº 1
            if (correcto)
            {
                if (!(valor is string))
                {
                    validacion = EnumEstadoEnumRobusto.ValorTipoIncorrecto;
                    correcto = false;
                }
            }

            // Validación nº 2
            if (correcto)
            {
                auxValor = (string)valor;
                bool found = false;
                foreach (string loopValor in this.ValoresPermitidos)
                {
                    found = (loopValor == auxValor);
                    if (found)
                    {
                        break;
                    }
                }
                if (!found)
                {
                    validacion = EnumEstadoEnumRobusto.ValorNoPermitido;
                    correcto = false;
                }
            }

            // Composición de resultado
            if (correcto)
            {
                outValor = auxValor;
            }
            else
            {
                outValor = this.ValorPorDefecto;
            }

            // Devolución de resultados
            valor = outValor;
            return validacion;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        /// <param name="resultado">valor no permitido</param>
        public override void LanzarExcepcion()
        {
            if (this.Estado == EnumEstadoEnumRobusto.ValorTipoIncorrecto)
                throw new Exception("El campo " + this.Codigo + " no es válido.");
            if (this.Estado == EnumEstadoEnumRobusto.ValorNoPermitido)
                throw new Exception("El campo " + this.Codigo + " no está permitido.");
        }
        #endregion

        #region Método(s) estático(s)
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static string Validar(object valor, out EnumEstadoRobusto validacion, string[] valoresPermitidos, string defecto)
        {
            OEnumeradoTexto robusto = new OEnumeradoTexto(string.Empty, valoresPermitidos, defecto, false);
            robusto.ValorGenerico = valor;
            validacion = robusto.Estado;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static string Validar(object valor, string[] valoresPermitidos, string defecto)
        {
            OEnumeradoTexto robusto = new OEnumeradoTexto(string.Empty, valoresPermitidos, defecto, false);
            robusto.ValorGenerico = valor;
            return robusto.Valor;
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto Validar(object valor, string codigo, string[] valoresPermitidos, string defecto, bool lanzarExcepcionSiValorNoValido)
        {
            OEnumeradoTexto robusto = new OEnumeradoTexto(codigo, valoresPermitidos, defecto, lanzarExcepcionSiValorNoValido);
            robusto.ValorGenerico = valor;
            valor = robusto.Valor;
            return robusto.Estado;
        }
        #endregion
    }

    /// <summary>
    /// Asignación de una variable a un campo de tipo enumerado (aunque internamente trabaja como un string)
    /// </summary>
    public static class OEnumeradoTextoExtension
    {
        #region Método(s) de extensión
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static string ValidarEnumeradoTexto(this object valor, out EnumEstadoRobusto validacion, string[] valoresPermitidos, string defecto)
        {
            return OEnumeradoTexto.Validar(valor, out validacion, valoresPermitidos, defecto);
        }
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static string ValidarEnumeradoTexto(this object valor, string[] valoresPermitidos, string defecto)
        {
            return OEnumeradoTexto.Validar(valor, valoresPermitidos, defecto);
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto ValidarEnumeradoTexto(this object valor, string codigo, string[] valoresPermitidos, string defecto, bool lanzarExcepcionSiValorNoValido)
        {
            return OEnumeradoTexto.Validar(valor, codigo, valoresPermitidos, defecto, lanzarExcepcionSiValorNoValido);
        }
        #endregion
    }

    /// <summary>
    /// Asignación de una variable a un campo de tipo enumerado (aunque internamente trabaja como un string)
    /// </summary>
    public class OEnumerado<T> : OObjetoBase<T>
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OEnumerado(string codigo, T valorDefecto, bool lanzarExcepcionSiValorNoValido)
            : base(codigo, valorDefecto, lanzarExcepcionSiValorNoValido)
        {
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public override EnumEstadoRobusto Validar(ref object valor)
        {
            // Valores por defecto
            EnumEstadoRobusto validacion = EnumEstadoEnumRobusto.ValorTipoIncorrecto;
            bool correcto = false;
            T outValor = this.ValorPorDefecto;
            T auxValor = this.ValorPorDefecto;

            // Validación nº 1
            if (!correcto)
            {
                if ((valor is T) && (typeof(T).IsEnum))
                {
                    auxValor = (T)valor;
                    validacion = EnumEstadoEnumRobusto.ResultadoCorrecto;
                    correcto = true;
                }
            }

            // Validación nº 2
            if (!correcto)
            {
                if (valor is string)
                {
                    string strValor = (string)valor;
                    try
                    {
                        auxValor = (T)Enum.Parse(typeof(T), strValor, true);
                        validacion = EnumEstadoEnumRobusto.ResultadoCorrecto;
                        correcto = true;
                    }
                    catch { }
                }
            }

            // Validación nº 3
            if (!correcto)
            {
                if (OEntero.EsEntero(valor))
                {
                    try
                    {
                        if (Enum.IsDefined(typeof(T), valor))
                        {
                            auxValor = (T)valor;
                            validacion = EnumEstadoEnumRobusto.ResultadoCorrecto;
                            correcto = true;
                        }
                    }
                    catch { }
                }
            }

            // Composición de resultado
            if (correcto)
            {
                outValor = auxValor;
            }
            else
            {
                outValor = this.ValorPorDefecto;
            }

            // Devolución de resultados
            valor = outValor;
            return validacion;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        /// <param name="resultado">valor no permitido</param>
        public override void LanzarExcepcion()
        {
            if (this.Estado == EnumEstadoEnumRobusto.ValorTipoIncorrecto)
                throw new Exception("El campo " + this.Codigo + " no es válido.");
            if (this.Estado == EnumEstadoEnumRobusto.ValorTipoIncorrecto)
                throw new Exception("El campo " + this.Codigo + " no está permitido.");
        }
        #endregion

        #region Método(s) estático(s)
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static T Validar(object valor, out EnumEstadoRobusto validacion, T defecto)
        {
            OEnumerado<T> robusto = new OEnumerado<T>(string.Empty, defecto, false);
            robusto.ValorGenerico = valor;
            validacion = robusto.Estado;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static T Validar(object valor, T defecto)
        {
            OEnumerado<T> robusto = new OEnumerado<T>(string.Empty, defecto, false);
            robusto.ValorGenerico = valor;
            return robusto.Valor;
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto Validar(object valor, string codigo, T defecto, bool lanzarExcepcionSiValorNoValido)
        {
            OEnumerado<T> robusto = new OEnumerado<T>(codigo, defecto, lanzarExcepcionSiValorNoValido);
            robusto.ValorGenerico = valor;
            valor = robusto.Valor;
            return robusto.Estado;
        }
        /// <summary>
        /// Se utiliza con enumerados para convertir un valor de texto en un enumerado del tipo indicado
        /// </summary>
        /// <param name="enumType">Tipo del enumerado al que deseamos convertir</param>
        /// <param name="valor">Texto que queremos convertir a enumerado</param>
        /// <param name="defecto">Valor por defecto en el caso que el texto no coincida con ningun elemento del enumerado</param>
        /// <returns>Devuelve el enumerado correspondiente con el texto</returns>
        public static object AnalizaEnumerado(Type enumType, string valor, object defecto)
        {
            object resultado;

            try
            {
                resultado = Enum.Parse(enumType, valor);
            }
            catch
            {
                resultado = defecto;
            }

            return resultado;
        }
        /// <summary>
        /// Se utiliza con enumerados y devuelve verdadero si el enumerado está contenido en el valor
        /// </summary>
        /// <param name="valor">Valor del cual se quiere saber si contiene cieto enumerado</param>
        /// <param name="coleccion">Enumerado que deseamos comparar con el valor</param>
        /// <returns>Devuelve verdadero si el enumerado está contenido en el valor</returns>
        public static bool EnColeccion(int valor, int[] coleccion)
        {
            foreach (int i in coleccion)
            {
                if ((valor & i) != 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Método(s) de extensión
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static T ValidarEnumerado(object valor, out EnumEstadoRobusto validacion, T defecto)
        {
            return Validar(valor, out validacion, defecto);
        }
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static T ValidarEnumerado(object valor, T defecto)
        {
            return Validar(valor, defecto);
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto ValidarEnumerado(object valor, string codigo, T defecto, bool lanzarExcepcionSiValorNoValido)
        {
            return Validar(valor, codigo, defecto, lanzarExcepcionSiValorNoValido);
        }
        #endregion
    }

    /// <summary>
    /// Asignación de una variable a un campo de tipo enumerado (aunque internamente trabaja como un string)
    /// </summary>
    public static class OEnumeradoExtension
    {
        #region Método(s) de extensión
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static T ValidarEnumerado<T>(this object valor, out EnumEstadoRobusto validacion, T defecto)
        {
            return OEnumerado<T>.Validar(valor, out validacion, defecto);
        }
        /// <summary>
        /// Evalua si el parámetro es texto
        /// </summary>
        public static T ValidarEnumerado<T>(this object valor, T defecto)
        {
            return OEnumerado<T>.Validar(valor, defecto);
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto ValidarEnumerado<T>(this object valor, string codigo, T defecto, bool lanzarExcepcionSiValorNoValido)
        {
            return OEnumerado<T>.Validar(valor, codigo, defecto, lanzarExcepcionSiValorNoValido);
        }
        #endregion
    }

    /// <summary>
    /// Resultado de la validación del SafeBool
    /// </summary>
    public class EnumEstadoEnumRobusto : EnumEstadoObjetoRobusto
    {
        #region Atributos
        /// <summary>
        /// El valor a asignar no está permitido
        /// </summary>
        public static EnumEstadoRobusto ValorNoPermitido = new EnumEstadoRobusto("ValorNoPermitido", "ValorNoPermitido", 22);
        #endregion
    }
    #endregion

    #region Entero Robusto
    /// <summary>
    /// Asignación de una variable a un campo de tipo entero
    /// </summary>
    public class OEntero : OObjetoBase<int>
    {
        #region Atributos
        /// <summary>
        /// Valor mínimo
        /// </summary>
        public int MinValor;
        /// <summary>
        /// Valor máximo
        /// </summary>
        public int MaxValor;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OEntero(string codigo, int minValor, int maxValor, int valorDefecto, bool lanzarExcepcionSiValorNoValido)
            : base(codigo, valorDefecto, lanzarExcepcionSiValorNoValido)
        {
            this.MinValor = minValor;
            this.MaxValor = maxValor;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public override EnumEstadoRobusto Validar(ref object valor)
        {
            // Valores por defecto
            EnumEstadoRobusto validacion = EnumEstadoEnteroRobusto.ValorTipoIncorrecto;
            bool correcto = false;
            int outValor = this.ValorPorDefecto;
            int auxValor = this.ValorPorDefecto;

            // Validación nº 1
            if (!correcto)
            {
                if (EsEntero(valor))
                {
                    auxValor = Convert.ToInt32(valor);
                    validacion = EnumEstadoEnteroRobusto.ResultadoCorrecto;
                    correcto = true;
                }
            }

            // Validación nº 2
            if (!correcto)
            {
                if (valor is string)
                {
                    int intValor;
                    if (int.TryParse((string)valor, NumberStyles.Any, CultureInfo.InvariantCulture, out intValor))
                    {
                        auxValor = intValor;
                        validacion = EnumEstadoEnteroRobusto.ResultadoCorrecto;
                        correcto = true;
                    }
                }
            }

            // Validación nº 3
            if (!correcto)
            {
                if (valor != null)
                {
                    try
                    {
                        auxValor = Convert.ToInt32(valor);
                        validacion = EnumEstadoEnteroRobusto.ResultadoCorrecto;
                        correcto = true;
                    }
                    catch { }
                }
            }

            // Validación nº 4
            if (correcto)
            {
                if (auxValor < this.MinValor)
                {
                    validacion = EnumEstadoEnteroRobusto.ValorInferiorMinimo;
                    correcto = false;
                }

                if (auxValor > this.MaxValor)
                {
                    validacion = EnumEstadoEnteroRobusto.ValorSuperiorMaximo;
                    correcto = false;
                }
            }

            // Composición de resultado
            if (correcto)
            {
                outValor = auxValor;
            }
            else
            {
                outValor = this.ValorPorDefecto;
            }

            // Devolución de resultados
            valor = outValor;
            return validacion;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        public override void LanzarExcepcion()
        {
            if (this.Estado == EnumEstadoEnteroRobusto.ValorTipoIncorrecto)
                throw new Exception("El campo " + this.Codigo + " no es un número entero.");
            if (this.Estado == EnumEstadoEnteroRobusto.ValorInferiorMinimo)
                throw new Exception("El campo " + this.Codigo + " es inferior al mínimo " + this.MinValor.ToString() + ".");
            if (this.Estado == EnumEstadoEnteroRobusto.ValorSuperiorMaximo)
                throw new Exception("El campo " + this.Codigo + " es superior al máximo " + this.MaxValor.ToString() + ".");
        }
        #endregion

        #region Métodos estático(s)
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static int Validar(object valor, out EnumEstadoRobusto validacion, int min, int max, int defecto)
        {
            OEntero robusto = new OEntero(string.Empty, min, max, defecto, false);
            robusto.ValorGenerico = valor;
            validacion = robusto.Estado;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static int Validar(object valor, int min, int max, int defecto)
        {
            OEntero robusto = new OEntero(string.Empty, min, max, defecto, false);
            robusto.ValorGenerico = valor;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static int Validar(object valor)
        {
            return Validar(valor, int.MinValue, int.MaxValue, default(int));
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="value">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto Validar(object valor, string codigo, int min, int max, int defecto, bool lanzarExcepcionSiValorNoValido)
        {
            OEntero robusto = new OEntero(codigo, min, max, defecto, lanzarExcepcionSiValorNoValido);
            robusto.ValorGenerico = valor;
            valor = robusto.Valor;
            return robusto.Estado;
        }
        /// <summary>
        /// Indica si el objeto pasado es de tipo entero
        /// </summary>
        /// <param name="o">Objeto que se quiere conocer si es de tipo entero</param>
        /// <returns>Verdadero si el tipo del objeto es entero</returns>
        public static bool EsEntero(object o)
        {
            return (o != null) && OObjeto.IsTypeOf(o, typeof(int), typeof(short), typeof(long), typeof(uint), typeof(ushort), typeof(ulong), typeof(byte));
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnRango(int valor, int min, int max)
        {
            return (valor >= min) && (valor <= max);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static int AsegurarRango(int valor, int min, int max)
        {
            int resultado = valor;

            if (valor < min)
            {
                resultado = min;
            }
            if (valor > max)
            {
                resultado = max;
            }

            return resultado;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnTolerancia(int valor, int media, int tolerancia)
        {
            return (valor >= media - tolerancia) && (valor <= media + tolerancia);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static int AsegurarTolerancia(int valor, int media, int tolerancia)
        {
            int resultado = valor;

            if (valor < media - tolerancia)
            {
                resultado = media - tolerancia;
            }
            if (valor > media + tolerancia)
            {
                resultado = media + tolerancia;
            }

            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Asignación de una variable a un campo de tipo entero
    /// </summary>
    public static class OEnteroExtension
    {
        #region Método(s) de extensión
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static int ValidarEntero(this object valor, out EnumEstadoRobusto validacion, int min, int max, int defecto)
        {
            return OEntero.Validar(valor, out validacion, min, max, defecto);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static int ValidarEntero(this object valor, int min, int max, int defecto)
        {
            return OEntero.Validar(valor, min, max, defecto);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static int ValidarEntero(this object valor)
        {
            return OEntero.Validar(valor);
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="value">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto ValidarEntero(this object valor, string codigo, int min, int max, int defecto, bool lanzarExcepcionSiValorNoValido)
        {
            return OEntero.Validar(valor, codigo, min, max, defecto, lanzarExcepcionSiValorNoValido);
        }
        /// <summary>
        /// Indica si el objeto pasado es de tipo entero
        /// </summary>
        /// <param name="o">Objeto que se quiere conocer si es de tipo entero</param>
        /// <returns>Verdadero si el tipo del objeto es entero</returns>
        public static bool EsEntero(this object o)
        {
            return OEntero.EsEntero(o);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnRango(this int valor, int min, int max)
        {
            return OEntero.EnRango(valor, min, max);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static int AsegurarRango(this int valor, int min, int max)
        {
            return OEntero.AsegurarRango(valor, min, max);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnTolerancia(this int valor, int media, int tolerancia)
        {
            return OEntero.EnTolerancia(valor, media, tolerancia);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static int AsegurarTolerancia(this int valor, int media, int tolerancia)
        {
            return OEntero.AsegurarTolerancia(valor, media, tolerancia);
        }
        #endregion
    }

    /// <summary>
    /// Resultado de la validación del SafeBool
    /// </summary>
    public class EnumEstadoEnteroRobusto : EnumEstadoObjetoRobusto
    {
        #region Atributos
        /// <summary>
        /// El valor a asignar es sueprior al máximo permitido
        /// </summary>
        public static EnumEstadoRobusto ValorSuperiorMaximo = new EnumEstadoRobusto("ValorSuperiorMaximo", "ValorSuperiorMaximo", 32);
        /// <summary>
        /// El valor a asignar es inferior al mínimo permitido
        /// </summary>
        public static EnumEstadoRobusto ValorInferiorMinimo = new EnumEstadoRobusto("ValorInferiorMinimo", "ValorInferiorMinimo", 33);
        #endregion
    }
    #endregion

    #region Decimal Robusto
    /// <summary>
    /// Asignación de una variable a un campo de tipo decimal
    /// </summary>
    public class ODecimal : OObjetoBase<double>
    {
        #region Atributos
        /// <summary>
        /// Valor mínimo
        /// </summary>
        public double MinValor;
        /// <summary>
        /// Valor máximo
        /// </summary>
        public double MaxValor;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ODecimal(string codigo, double minValor, double maxValor, double valorDefecto, bool lanzarExcepcionSiValorNoValido)
            : base(codigo, valorDefecto, lanzarExcepcionSiValorNoValido)
        {
            this.MinValor = minValor;
            this.MaxValor = maxValor;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public override EnumEstadoRobusto Validar(ref object valor)
        {
            // Valores por defecto
            EnumEstadoRobusto validacion = EnumEstadoDecimalRobusto.ValorTipoIncorrecto;
            bool correcto = false;
            double outValor = this.ValorPorDefecto;
            double auxValor = this.ValorPorDefecto;

            // Validación nº 1
            if (!correcto)
            {
                if (EsDecimal(valor))
                {
                    auxValor = Convert.ToDouble(valor);
                    validacion = EnumEstadoDecimalRobusto.ResultadoCorrecto;
                    correcto = true;
                }
            }

            // Validación nº 2
            if (!correcto)
            {
                if (valor is string)
                {
                    double doubleValor;
                    if (double.TryParse((string)valor, NumberStyles.Any, CultureInfo.InvariantCulture, out doubleValor))
                    {
                        auxValor = doubleValor;
                        validacion = EnumEstadoDecimalRobusto.ResultadoCorrecto;
                        correcto = true;
                    }
                }
            }

            // Validación nº 3
            if (!correcto)
            {
                if (valor != null)
                {
                    try
                    {
                        auxValor = Convert.ToDouble(valor);
                        validacion = EnumEstadoDecimalRobusto.ResultadoCorrecto;
                        correcto = true;
                    }
                    catch { }
                }
            }

            // Validación nº 4
            if (correcto)
            {
                if (auxValor < this.MinValor)
                {
                    validacion = EnumEstadoDecimalRobusto.ValorInferiorMinimo;
                    correcto = false;
                }

                if (auxValor > this.MaxValor)
                {
                    validacion = EnumEstadoDecimalRobusto.ValorSuperiorMaximo;
                    correcto = false;
                }
            }

            // Composición de resultado
            if (correcto)
            {
                outValor = auxValor;
            }
            else
            {
                outValor = this.ValorPorDefecto;
            }

            valor = outValor;
            return validacion;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        /// <param name="value">valor no permitido</param>
        public override void LanzarExcepcion()
        {
            if (this.Estado == EnumEstadoDecimalRobusto.ValorTipoIncorrecto)
                throw new Exception("El campo " + this.Codigo + " no es un número decimal.");
            if (this.Estado == EnumEstadoDecimalRobusto.ValorInferiorMinimo)
                throw new Exception("El campo " + this.Codigo + " es inferior al mínimo " + this.MinValor.ToString() + ".");
            if (this.Estado == EnumEstadoDecimalRobusto.ValorSuperiorMaximo)
                throw new Exception("El campo " + this.Codigo + " es superior al máximo " + this.MaxValor.ToString() + ".");
        }
        #endregion

        #region Método(s) estático(s)
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static double Validar(object valor, out EnumEstadoRobusto validacion, double min, double max, double defecto)
        {
            ODecimal robusto = new ODecimal(string.Empty, min, max, defecto, false);
            robusto.ValorGenerico = valor;
            validacion = robusto.Estado;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static double Validar(object valor, double min, double max, double defecto)
        {
            ODecimal robusto = new ODecimal(string.Empty, min, max, defecto, false);
            robusto.ValorGenerico = valor;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static double Validar(object valor)
        {
            return Validar(valor, double.MinValue, double.MaxValue, default(double));
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="value">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto Validar(object valor, string codigo, double min, double max, double defecto, bool lanzarExcepcionSiValorNoValido)
        {
            ODecimal robusto = new ODecimal(codigo, min, max, defecto, lanzarExcepcionSiValorNoValido);
            robusto.ValorGenerico = valor;
            valor = robusto.Valor;
            return robusto.Estado;
        }
        /// <summary>
        /// Indica si el objeto pasado es de tipo decimal
        /// </summary>
        /// <param name="o">Objeto que se quiere conocer si es de tipo decimal</param>
        /// <returns>Verdadero si el tipo del objeto es decimal</returns>
        public static bool EsDecimal(object o)
        {
            return (o != null) && OObjeto.IsTypeOf(o, typeof(float), typeof(double), typeof(decimal));
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnRango(double valor, double min, double max)
        {
            return (valor >= min) && (valor <= max);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static double AsegurarRango(double valor, double min, double max)
        {
            double resultado = valor;

            if (valor < min)
            {
                resultado = min;
            }
            if (valor > max)
            {
                resultado = max;
            }

            return resultado;
        }
        /// <summary>
        /// Compara dos valores decimales para definir si son similares, con una diferencia menor que sigma
        /// </summary>
        /// <param name="valor">Primer valor a comparar</param>
        /// <param name="media">Segundo valor a comparar</param>
        /// <param name="tolerancia">Diferencia máxima entre ambos valores</param>
        /// <returns>Verdadero si los valores son menores que sigma</returns>
        public static bool EnTolerancia(double valor, double media, double tolerancia)
        {
            double diff = Math.Abs(valor - media);
            return diff <= tolerancia;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static double AsegurarTolerancia(double valor, double media, double tolerancia)
        {
            double resultado = valor;

            if (valor < media - tolerancia)
            {
                resultado = media - tolerancia;
            }
            if (valor > media + tolerancia)
            {
                resultado = media + tolerancia;
            }

            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Asignación de una variable a un campo de tipo decimal
    /// </summary>
    public static class ODecimalExtension
    {
        #region Método(s) de extensión
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static double ValidarDecimal(this object valor, out EnumEstadoRobusto validacion, double min, double max, double defecto)
        {
            return ODecimal.Validar(valor, out validacion, min, max, defecto);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static double ValidarDecimal(this object valor, double min, double max, double defecto)
        {
            return ODecimal.Validar(valor, min, max, defecto);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static double ValidarDecimal(this object valor)
        {
            return ODecimal.Validar(valor);
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="value">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto ValidarDecimal(this object valor, string codigo, double min, double max, double defecto, bool lanzarExcepcionSiValorNoValido)
        {
            return ODecimal.Validar(valor, codigo, min, max, defecto, lanzarExcepcionSiValorNoValido);
        }
        /// <summary>
        /// Indica si el objeto pasado es de tipo decimal
        /// </summary>
        /// <param name="o">Objeto que se quiere conocer si es de tipo decimal</param>
        /// <returns>Verdadero si el tipo del objeto es decimal</returns>
        public static bool EsDecimal(this object o)
        {
            return ODecimal.EsDecimal(o);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnRango(this double valor, double min, double max)
        {
            return ODecimal.EnRango(valor, min, max);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static double AsegurarRango(this double valor, double min, double max)
        {
            return ODecimal.AsegurarRango(valor, min, max);
        }
        /// <summary>
        /// Compara dos valores decimales para definir si son similares, con una diferencia menor que sigma
        /// </summary>
        /// <param name="valor">Primer valor a comparar</param>
        /// <param name="media">Segundo valor a comparar</param>
        /// <param name="tolerancia">Diferencia máxima entre ambos valores</param>
        /// <returns>Verdadero si los valores son menores que sigma</returns>
        public static bool EnTolerancia(this double valor, double media, double tolerancia)
        {
            return ODecimal.EnTolerancia(valor, media, tolerancia);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static double AsegurarTolerancia(this double valor, double media, double tolerancia)
        {
            return ODecimal.AsegurarTolerancia(valor, media, tolerancia);
        }
        #endregion
    }

    /// <summary>
    /// Resultado de la validación del SafeBool
    /// </summary>
    public class EnumEstadoDecimalRobusto : EnumEstadoObjetoRobusto
    {
        #region Atributos
        /// <summary>
        /// El valor a asignar es sueprior al máximo permitido
        /// </summary>
        public static EnumEstadoRobusto ValorSuperiorMaximo = new EnumEstadoRobusto("ValorSuperiorMaximo", "ValorSuperiorMaximo", 42);
        /// <summary>
        /// El valor a asignar es inferior al mínimo permitido
        /// </summary>
        public static EnumEstadoRobusto ValorInferiorMinimo = new EnumEstadoRobusto("ValorInferiorMinimo", "ValorInferiorMinimo", 43);
        #endregion
    }
    #endregion

    #region Booleano Robusto
    /// <summary>
    /// Asignación de una variable a un campo de tipo booleano
    /// </summary>
    public class OBooleano : OObjetoBase<bool>
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OBooleano(string codigo, bool valorDefecto, bool lanzarExcepcionSiValorNoValido)
            : base(codigo, valorDefecto, lanzarExcepcionSiValorNoValido)
        {
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public override EnumEstadoRobusto Validar(ref object valor)
        {
            // Valores por defecto
            EnumEstadoRobusto validacion = EnumEstadoBoolRobusto.ValorTipoIncorrecto;
            bool correcto = false;
            bool outValor = this.ValorPorDefecto;
            bool auxValor = this.ValorPorDefecto;

            // Validación nº 1
            if (!correcto)
            {
                if (valor is bool)
                {
                    auxValor = (bool)valor;
                    validacion = EnumEstadoBoolRobusto.ResultadoCorrecto;
                    correcto = true;
                }
            }

            // Validación nº 2
            if (!correcto)
            {
                if (valor is string)
                {
                    string strValor = (string)valor;
                    if (string.Compare(strValor, "0") == 0)
                    {
                        auxValor = false;
                        validacion = EnumEstadoBoolRobusto.ResultadoCorrecto;
                        correcto = true;
                    }
                    else if (string.Compare(strValor, "1") == 0)
                    {
                        auxValor = true;
                        validacion = EnumEstadoBoolRobusto.ResultadoCorrecto;
                        correcto = true;
                    }
                }
            }

            // Validación nº 3
            if (!correcto)
            {
                if (valor != null)
                {
                    try
                    {
                        auxValor = Convert.ToBoolean(valor);
                        validacion = EnumEstadoBoolRobusto.ResultadoCorrecto;
                        correcto = true;
                    }
                    catch { }
                }
            }

            // Composición de resultado
            if (correcto)
            {
                outValor = auxValor;
            }
            else
            {
                outValor = this.ValorPorDefecto;
            }

            valor = outValor;
            return validacion;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        public override void LanzarExcepcion()
        {
            if (this.Estado == EnumEstadoBoolRobusto.ValorTipoIncorrecto)
                throw new Exception("El campo " + this.Codigo + " no es booleano.");
        }
        #endregion

        #region Método(s) estático(s)
        /// <summary>
        /// Evalúa si el parámetro es booleano
        /// </summary>
        public static bool Validar(object valor, out EnumEstadoRobusto validacion, bool defecto)
        {
            OBooleano robusto = new OBooleano(string.Empty, defecto, false);
            robusto.ValorGenerico = valor;
            validacion = robusto.Estado;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool Validar(object valor, bool defecto)
        {
            OBooleano robusto = new OBooleano(string.Empty, defecto, false);
            robusto.ValorGenerico = valor;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool Validar(object valor)
        {
            return Validar(valor, default(bool));
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto Validar(object valor, string codigo, bool defecto, bool lanzarExcepcionSiValorNoValido)
        {
            OBooleano robusto = new OBooleano(codigo, defecto, lanzarExcepcionSiValorNoValido);
            robusto.ValorGenerico = valor;
            valor = robusto.Valor;
            return robusto.Estado;
        }
        #endregion
    }

    /// <summary>
    /// Asignación de una variable a un campo de tipo booleano
    /// </summary>
    public static class OBooleanoExtension
    {
        #region Método(s) de extensión
        /// <summary>
        /// Evalúa si el parámetro es booleano
        /// </summary>
        public static bool ValidarBooleano(this object valor, out EnumEstadoRobusto validacion, bool defecto)
        {
            return OBooleano.Validar(valor, out validacion, defecto);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool ValidarBooleano(this object valor, bool defecto)
        {
            return OBooleano.Validar(valor, defecto);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool ValidarBooleano(this object valor)
        {
            return OBooleano.Validar(valor);
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto ValidarBooleano(this object valor, string codigo, bool defecto, bool lanzarExcepcionSiValorNoValido)
        {
            return OBooleano.Validar(valor, codigo, defecto, lanzarExcepcionSiValorNoValido);
        }
        #endregion
    }

    /// <summary>
    /// Resultado de la validación del SafeBool
    /// </summary>
    public class EnumEstadoBoolRobusto : EnumEstadoObjetoRobusto
    {
    }
    #endregion

    #region TimeSpan Robusto
    /// <summary>
    /// Asignación de una variable a un campo de tipo intervalo de tiempo
    /// </summary>
    public class OIntervaloTiempo : OObjetoBase<TimeSpan>
    {
        #region Atributos
        /// <summary>
        /// Valor mínimo
        /// </summary>
        public TimeSpan MinValor;
        /// <summary>
        /// Valor máximo
        /// </summary>
        public TimeSpan MaxValor;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OIntervaloTiempo(string codigo, TimeSpan minValor, TimeSpan maxValor, TimeSpan valorDefecto, bool lanzarExcepcionSiValorNoValido)
            : base(codigo, valorDefecto, lanzarExcepcionSiValorNoValido)
        {
            this.MinValor = minValor;
            this.MaxValor = maxValor;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public override EnumEstadoRobusto Validar(ref object valor)
        {
            // Valores por defecto
            EnumEstadoRobusto validacion = EnumEstadoIntervaloTiempoRobusto.ValorTipoIncorrecto;
            bool correcto = false;
            TimeSpan outValor = this.ValorPorDefecto;
            TimeSpan auxValor = this.ValorPorDefecto;

            // Validación nº 1
            if (!correcto)
            {
                if (valor is TimeSpan)
                {
                    auxValor = (TimeSpan)valor;
                    validacion = EnumEstadoIntervaloTiempoRobusto.ResultadoCorrecto;
                    correcto = true;
                }
            }

            // Validación nº 2
            if (!correcto)
            {
                if (OObjeto.IsNumeric(valor))
                {
                    EnumEstadoRobusto resultConversion;
                    double decimalValue = ODecimal.Validar(valor, out resultConversion, TimeSpan.MinValue.TotalMilliseconds, TimeSpan.MaxValue.TotalMilliseconds, this.ValorPorDefecto.TotalMilliseconds);
                    if (resultConversion == EnumEstadoObjetoRobusto.ResultadoCorrecto)
                    {
                        auxValor = TimeSpan.FromDays(decimalValue);
                        validacion = EnumEstadoIntervaloTiempoRobusto.ResultadoCorrecto;
                        correcto = true;
                    }
                }
            }

            // Validación nº 3
            if (!correcto)
            {
                if (valor is string)
                {
                    string strValue = (string)valor;
                    bool ok = TimeSpan.TryParse(strValue, out auxValor);
                    if (ok)
                    {
                        validacion = EnumEstadoIntervaloTiempoRobusto.ResultadoCorrecto;
                        correcto = true;
                    }
                }
            }

            // Validación nº 4
            if (correcto)
            {
                if (auxValor < this.MinValor)
                {
                    validacion = EnumEstadoIntervaloTiempoRobusto.ValorInferiorMinimo;
                    correcto = false;
                }

                if (auxValor > this.MaxValor)
                {
                    validacion = EnumEstadoIntervaloTiempoRobusto.ValorSuperiorMaximo;
                    correcto = false;
                }
            }

            // Composición de resultado
            if (correcto)
            {
                outValor = auxValor;
            }
            else
            {
                outValor = this.ValorPorDefecto;
            }

            valor = outValor;
            return validacion;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        /// <param name="value">valor no permitido</param>
        public override void LanzarExcepcion()
        {
            if (this.Estado == EnumEstadoIntervaloTiempoRobusto.ValorTipoIncorrecto)
                throw new Exception("El campo " + this.Codigo + " no es un periodo de tiempo válido.");
            if (this.Estado == EnumEstadoIntervaloTiempoRobusto.ValorInferiorMinimo)
                throw new Exception("El campo " + this.Codigo + " es inferior al mínimo " + this.MinValor.ToString() + ".");
            if (this.Estado == EnumEstadoIntervaloTiempoRobusto.ValorSuperiorMaximo)
                throw new Exception("El campo " + this.Codigo + " es superior al máximo " + this.MaxValor.ToString() + ".");
        }
        #endregion

        #region Método(s) estático(s)
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static TimeSpan Validar(object valor, out EnumEstadoRobusto validacion, TimeSpan min, TimeSpan max, TimeSpan defecto)
        {
            OIntervaloTiempo robusto = new OIntervaloTiempo(string.Empty, min, max, defecto, false);
            robusto.ValorGenerico = valor;
            validacion = robusto.Estado;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static TimeSpan Validar(object valor, TimeSpan min, TimeSpan max, TimeSpan defecto)
        {
            OIntervaloTiempo robusto = new OIntervaloTiempo(string.Empty, min, max, defecto, false);
            robusto.ValorGenerico = valor;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static TimeSpan Validar(object valor, TimeSpan defecto)
        {
            OIntervaloTiempo robusto = new OIntervaloTiempo(string.Empty, TimeSpan.MinValue, TimeSpan.MaxValue, defecto, false);
            robusto.ValorGenerico = valor;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static TimeSpan Validar(object valor)
        {
            return Validar(valor, default(TimeSpan));
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto Validar(object valor, string codigo, TimeSpan min, TimeSpan max, TimeSpan defecto, bool lanzarExcepcionSiValorNoValido)
        {
            OIntervaloTiempo robusto = new OIntervaloTiempo(codigo, min, max, defecto, lanzarExcepcionSiValorNoValido);
            robusto.ValorGenerico = valor;
            valor = robusto.Valor;
            return robusto.Estado;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnRango(TimeSpan valor, TimeSpan min, TimeSpan max)
        {
            return (valor >= min) && (valor <= max);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static TimeSpan AseguraRango(TimeSpan valor, TimeSpan min, TimeSpan max)
        {
            TimeSpan resultado = valor;

            if (valor < min)
            {
                resultado = min;
            }
            if (valor > max)
            {
                resultado = max;
            }

            return resultado;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnTolerancia(TimeSpan valor, TimeSpan media, TimeSpan tolerancia)
        {
            return (valor >= media - tolerancia) && (valor <= media + tolerancia);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static TimeSpan AseguraTolerancia(TimeSpan valor, TimeSpan media, TimeSpan tolerancia)
        {
            TimeSpan resultado = valor;

            if (valor < media - tolerancia)
            {
                resultado = media - tolerancia;
            }
            if (valor > media + tolerancia)
            {
                resultado = media + tolerancia;
            }

            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Asignación de una variable a un campo de tipo intervalo de tiempo
    /// </summary>
    public static class OIntervaloTiempoExtension
    {
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static TimeSpan ValidarIntervaloTiempo(this object valor, out EnumEstadoRobusto validacion, TimeSpan min, TimeSpan max, TimeSpan defecto)
        {
            return OIntervaloTiempo.Validar(valor, out validacion, min, max, defecto);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static TimeSpan ValidarIntervaloTiempo(this object valor, TimeSpan min, TimeSpan max, TimeSpan defecto)
        {
            return OIntervaloTiempo.Validar(valor, min, max, defecto);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static TimeSpan ValidarIntervaloTiempo(this object valor, TimeSpan defecto)
        {
            return OIntervaloTiempo.Validar(valor, defecto);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static TimeSpan ValidarIntervaloTiempo(this object valor)
        {
            return OIntervaloTiempo.Validar(valor);
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto ValidarIntervaloTiempo(this object valor, string codigo, TimeSpan min, TimeSpan max, TimeSpan defecto, bool lanzarExcepcionSiValorNoValido)
        {
            return OIntervaloTiempo.Validar(valor, codigo, min, max, defecto, lanzarExcepcionSiValorNoValido);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnRango(this TimeSpan valor, TimeSpan min, TimeSpan max)
        {
            return OIntervaloTiempo.EnRango(valor, min, max);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static TimeSpan AseguraRango(this TimeSpan valor, TimeSpan min, TimeSpan max)
        {
            return OIntervaloTiempo.AseguraRango(valor, min, max);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnTolerancia(this TimeSpan valor, TimeSpan media, TimeSpan tolerancia)
        {
            return OIntervaloTiempo.EnTolerancia(valor, media, tolerancia);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static TimeSpan AseguraTolerancia(this TimeSpan valor, TimeSpan media, TimeSpan tolerancia)
        {
            return OIntervaloTiempo.AseguraTolerancia(valor, media, tolerancia);
        }
    }

    /// <summary>
    /// Resultado de la validación del SafeBool
    /// </summary>
    public class EnumEstadoIntervaloTiempoRobusto : EnumEstadoObjetoRobusto
    {
        #region Atributos
        /// <summary>
        /// El valor a asignar es sueprior al máximo permitido
        /// </summary>
        public static EnumEstadoRobusto ValorSuperiorMaximo = new EnumEstadoRobusto("ValorSuperiorMaximo", "ValorSuperiorMaximo", 51);
        /// <summary>
        /// El valor a asignar es inferior al mínimo permitido
        /// </summary>
        public static EnumEstadoRobusto ValorInferiorMinimo = new EnumEstadoRobusto("ValorInferiorMinimo", "ValorInferiorMinimo", 51);
        #endregion
    }
    #endregion

    #region DateTime Robusto
    /// <summary>
    /// Asignación de una variable a un campo de tipo fecha
    /// </summary>
    public class OFechaHora : OObjetoBase<DateTime>
    {
        #region Atributos
        /// <summary>
        /// Valor mínimo
        /// </summary>
        public DateTime MinValor;
        /// <summary>
        /// Valor máximo
        /// </summary>
        public DateTime MaxValor;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OFechaHora(string codigo, DateTime minValor, DateTime maxValor, DateTime valorDefecto, bool lanzarExcepcionSiValorNoValido)
            : base(codigo, valorDefecto, lanzarExcepcionSiValorNoValido)
        {
            this.MinValor = minValor;
            this.MaxValor = maxValor;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public override EnumEstadoRobusto Validar(ref object valor)
        {
            // Valores por defecto
            EnumEstadoRobusto validacion = EnumEstadoFechaHoraRobusta.ValorTipoIncorrecto;
            bool correcto = false;
            DateTime outValor = this.ValorPorDefecto;
            DateTime auxValor = this.ValorPorDefecto;

            // Validación nº 1
            if (!correcto)
            {
                if (valor is DateTime)
                {
                    auxValor = (DateTime)valor;
                    validacion = EnumEstadoFechaHoraRobusta.ResultadoCorrecto;
                    correcto = true;
                }
            }

            // Validación nº 2
            if (!correcto)
            {
                if (valor is string)
                {
                    string strValue = (string)valor;
                    bool ok = DateTime.TryParse(strValue, out auxValor);
                    if (ok)
                    {
                        validacion = EnumEstadoFechaHoraRobusta.ResultadoCorrecto;
                        correcto = true;
                    }
                }
            }

            // Validación nº 3
            if (correcto)
            {
                if (auxValor < this.MinValor)
                {
                    validacion = EnumEstadoFechaHoraRobusta.ValorInferiorMinimo;
                    correcto = false;
                }

                if (auxValor > this.MaxValor)
                {
                    validacion = EnumEstadoFechaHoraRobusta.ValorSuperiorMaximo;
                    correcto = false;
                }
            }

            // Composición de resultado
            if (correcto)
            {
                outValor = auxValor;
            }
            else
            {
                outValor = this.ValorPorDefecto;
            }

            valor = outValor;
            return validacion;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        public override void LanzarExcepcion()
        {
            if (this.Estado == EnumEstadoFechaHoraRobusta.ValorTipoIncorrecto)
                throw new Exception("El campo " + this.Codigo + " no es una fecha válida.");
            if (this.Estado == EnumEstadoFechaHoraRobusta.ValorInferiorMinimo)
                throw new Exception("El campo " + this.Codigo + " es inferior al mínimo " + this.MinValor.ToString() + ".");
            if (this.Estado == EnumEstadoFechaHoraRobusta.ValorSuperiorMaximo)
                throw new Exception("El campo " + this.Codigo + " es superior al máximo " + this.MaxValor.ToString() + ".");
        }
        #endregion

        #region Método(s) estático(s)
        /// <summary>
        /// Evalúa si el parámetro es booleano
        /// </summary>
        public static DateTime Validar(object valor, out EnumEstadoRobusto validacion, DateTime min, DateTime max, DateTime defecto)
        {
            OFechaHora robusto = new OFechaHora(string.Empty, min, max, defecto, false);
            robusto.ValorGenerico = valor;
            validacion = robusto.Estado;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static DateTime Validar(object valor, DateTime min, DateTime max, DateTime defecto)
        {
            OFechaHora robusto = new OFechaHora(string.Empty, min, max, defecto, false);
            robusto.ValorGenerico = valor;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static DateTime Validar(object valor, DateTime defecto)
        {
            OFechaHora robusto = new OFechaHora(string.Empty, DateTime.MinValue, DateTime.MaxValue, defecto, false);
            robusto.ValorGenerico = valor;
            return robusto.Valor;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static DateTime Validar(object valor)
        {
            return Validar(valor, default(DateTime));
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto Validar(object valor, string codigo, DateTime min, DateTime max, DateTime defecto, bool lanzarExcepcionSiValorNoValido)
        {
            OFechaHora robusto = new OFechaHora(codigo, min, max, defecto, lanzarExcepcionSiValorNoValido);
            robusto.ValorGenerico = valor;
            valor = robusto.Valor;
            return robusto.Estado;
        }
        /// <summary>
        /// Conversión de día gregocriano a juliano
        /// </summary>
        /// <param name="dia">Día</param>
        /// <param name="mes">Mes</param>
        /// <param name="anno">Año</param>
        /// <returns></returns>
        public static long GregorianoAJuliano(int dia, int mes, int anno)
        {
            //dada una fecha del calendario gregoriano, obtiene
            //un entero que la representa
            long tmes, tanno;
            long jdia;
            //marzo es el mes 0 del año
            if (mes > 2)
            {
                tmes = mes - 3;
                tanno = anno;
            }
            else
            //febrero es el mes 11 del año anterior.
            {
                tmes = mes + 9;
                tanno = anno - 1;
            }
            jdia = (tanno / 4000) * 1460969;
            tanno = (tanno % 4000);
            jdia = jdia +
               (((tanno / 100) * 146097) / 4) +
               (((tanno % 100) * 1461) / 4) +
               (((153 * tmes) + 2) / 5) +
               dia +
               1721119;
            return jdia;
        }
        /// <summary>
        /// Conversión de dia juliano a gregoriano
        /// </summary>
        /// <param name="jdia">Día juliano</param>
        /// <returns>Fecha gregoriana</returns>
        public static DateTime JulianoAGregoriano(long jdia)
        {
            long anno, mes, dia;
            long tmp1, tmp2;
            tmp1 = jdia - 1721119;
            anno = ((tmp1 - 1) / 1460969) * 4000;
            tmp1 = ((tmp1 - 1) % 1460969) + 1;
            tmp1 = (4 * tmp1) - 1;
            tmp2 = (4 * ((tmp1 % 146097) / 4)) + 3;
            anno = (100 * (tmp1 / 146097)) + (tmp2 / 1461) + anno;
            tmp1 = (5 * (((tmp2 % 1461) + 4) / 4)) - 3;
            mes = tmp1 / 153;
            dia = ((tmp1 % 153) + 5) / 5;
            if (mes < 10)
                mes = mes + 3;
            else
            {
                mes = mes - 9;
                anno = anno + 1;
            }
            return new DateTime((int)anno, (int)mes, (int)dia);
        }
        /// <summary>
        /// Devuelve una cadena de texto identificativa del día actual (utilizada para indexar ficheros)
        /// </summary>
        /// <returns></returns>
        public static string FechaATextoSimple(DateTime fecha)
        {
            string resultado = string.Empty;

            resultado += fecha.Year.ToString("0000");
            resultado += fecha.Month.ToString("00");
            resultado += fecha.Day.ToString("00");

            return resultado;
        }
        /// <summary>
        /// Devuelve una cadena de texto identificativa del momento actual (utilizada para indexar ficheros)
        /// </summary>
        /// <returns></returns>
        public static string FechaHoraATextoSimple(DateTime fecha)
        {
            string resultado = string.Empty;

            resultado += fecha.Year.ToString("0000");
            resultado += fecha.Month.ToString("00");
            resultado += fecha.Day.ToString("00");
            resultado += fecha.Hour.ToString("00");
            resultado += fecha.Minute.ToString("00");
            resultado += fecha.Second.ToString("00");
            resultado += fecha.Millisecond.ToString("000");

            return resultado;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnRango(DateTime valor, DateTime min, DateTime max)
        {
            return (valor >= min) && (valor <= max);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static DateTime AseguraRango(DateTime valor, DateTime min, DateTime max)
        {
            DateTime resultado = valor;

            if (valor < min)
            {
                resultado = min;
            }
            if (valor > max)
            {
                resultado = max;
            }

            return resultado;
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnTolerancia(DateTime valor, DateTime media, TimeSpan tolerancia)
        {
            return (valor >= media - tolerancia) && (valor <= media + tolerancia);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static DateTime AseguraTolerancia(DateTime valor, DateTime media, TimeSpan tolerancia)
        {
            DateTime resultado = valor;

            if (valor < media - tolerancia)
            {
                resultado = media - tolerancia;
            }
            if (valor > media + tolerancia)
            {
                resultado = media + tolerancia;
            }

            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Asignación de una variable a un campo de tipo fecha
    /// </summary>
    public static class OFechaHoraExtension
    {
        #region Método(s) de extensión
        /// <summary>
        /// Evalúa si el parámetro es booleano
        /// </summary>
        public static DateTime ValidarFechaHora(this object valor, out EnumEstadoRobusto validacion, DateTime min, DateTime max, DateTime defecto)
        {
            return OFechaHora.Validar(valor, out validacion, min, max, defecto);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static DateTime ValidarFechaHora(this object valor, DateTime min, DateTime max, DateTime defecto)
        {
            return OFechaHora.Validar(valor, min, max, defecto);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static DateTime ValidarFechaHora(this object valor, DateTime defecto)
        {
            return OFechaHora.Validar(valor, defecto);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static DateTime ValidarFechaHora(this object valor)
        {
            return OFechaHora.Validar(valor);
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static EnumEstadoRobusto ValidarFechaHora(this object valor, string codigo, DateTime min, DateTime max, DateTime defecto, bool lanzarExcepcionSiValorNoValido)
        {
            return OFechaHora.Validar(valor, codigo, min, max, defecto, lanzarExcepcionSiValorNoValido);
        }
        /// <summary>
        /// Devuelve una cadena de texto identificativa del día actual (utilizada para indexar ficheros)
        /// </summary>
        /// <returns></returns>
        public static string FechaATextoSimple(this DateTime fecha)
        {
            return OFechaHora.FechaATextoSimple(fecha);
        }
        /// <summary>
        /// Devuelve una cadena de texto identificativa del momento actual (utilizada para indexar ficheros)
        /// </summary>
        /// <returns></returns>
        public static string FechaHoraATextoSimple(this DateTime fecha)
        {
            return OFechaHora.FechaHoraATextoSimple(fecha);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnRango(this DateTime valor, DateTime min, DateTime max)
        {
            return OFechaHora.EnRango(valor, min, max);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static DateTime AseguraRango(this DateTime valor, DateTime min, DateTime max)
        {
            return OFechaHora.AseguraRango(valor, min, max);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool EnTolerancia(this DateTime valor, DateTime media, TimeSpan tolerancia)
        {
            return OFechaHora.EnTolerancia(valor, media, tolerancia);
        }
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static DateTime AseguraTolerancia(this DateTime valor, DateTime media, TimeSpan tolerancia)
        {
            return OFechaHora.AseguraTolerancia(valor, media, tolerancia);
        }
        #endregion
    }

    /// <summary>
    /// Resultado de la validación del SafeBool
    /// </summary>
    public class EnumEstadoFechaHoraRobusta : EnumEstadoObjetoRobusto
    {
        #region Atributos
        /// <summary>
        /// El valor a asignar es sueprior al máximo permitido
        /// </summary>
        public static EnumEstadoRobusto ValorSuperiorMaximo = new EnumEstadoRobusto("ValorSuperiorMaximo", "ValorSuperiorMaximo", 62);
        /// <summary>
        /// El valor a asignar es inferior al mínimo permitido
        /// </summary>
        public static EnumEstadoRobusto ValorInferiorMinimo = new EnumEstadoRobusto("ValorInferiorMinimo", "ValorInferiorMinimo", 63);
        #endregion
    }
    #endregion

    #region Binarios
    /// <summary>
    /// Trabajo con números binarios
    /// </summary>
    public static class OBinario
    {
        /// <summary>
        /// Extrae un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos extraer el bit</param>
        /// <param name="posicion">Posición del bit a extraer</param>
        /// <returns>Booleano con el valor del bit extraido</returns>
        public static bool GetBit(this byte numero, int posicion)
        {
            byte mascara = Convert.ToByte(Math.Pow(2, posicion));
            return (numero & mascara) != 0;
        }
        /// <summary>
        /// Extrae un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos extraer el bit</param>
        /// <param name="posicion">Posición del bit a extraer</param>
        /// <returns>Booleano con el valor del bit extraido</returns>
        public static bool GetBit(this ushort numero, int posicion)
        {
            UInt16 mascara = Convert.ToUInt16(Math.Pow(2, posicion));
            return (numero & mascara) != 0;
        }
        /// <summary>
        /// Extrae un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos extraer el bit</param>
        /// <param name="posicion">Posición del bit a extraer</param>
        /// <returns>Booleano con el valor del bit extraido</returns>
        public static bool GetBit(this uint numero, int posicion)
        {
            uint mascara = Convert.ToUInt32(Math.Pow(2, posicion));
            return (numero & mascara) != 0;
        }
        /// <summary>
        /// Establece un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos establecer el bit</param>
        /// <param name="posicion">Posición del bit a establecer</param>
        /// <param name="valor">Booleano con el valor del bit a establecer</param>
        public static void SetBit(ref byte numero, int posicion, bool valor)
        {
            byte mascara = Convert.ToByte(Math.Pow(2, posicion));
            if (valor)
            {
                numero = (byte)(numero | mascara);
            }
            else
            {
                numero = (byte)(numero & ~mascara);
            }
        }
        /// <summary>
        /// Establece un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos establecer el bit</param>
        /// <param name="posicion">Posición del bit a establecer</param>
        /// <param name="valor">Booleano con el valor del bit a establecer</param>
        public static void SetBit(ref ushort numero, int posicion, bool valor)
        {
            ushort mascara = Convert.ToUInt16(Math.Pow(2, posicion));
            if (valor)
            {
                numero = (ushort)(numero | mascara);
            }
            else
            {
                numero = (ushort)(numero & ~mascara);
            }
        }
        /// <summary>
        /// Establece un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos establecer el bit</param>
        /// <param name="posicion">Posición del bit a establecer</param>
        /// <param name="valor">Booleano con el valor del bit a establecer</param>
        public static void SetBit(ref uint numero, int posicion, bool valor)
        {
            uint mascara = Convert.ToUInt32(Math.Pow(2, posicion));
            if (valor)
            {
                numero = (uint)(numero | mascara);
            }
            else
            {
                numero = (uint)(numero & ~mascara);
            }
        }
        /// <summary>
        /// Establece un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos establecer el bit</param>
        /// <param name="posicion">Posición del bit a establecer</param>
        /// <param name="valor">Booleano con el valor del bit a establecer</param>
        public static byte SetBit(this byte numero, int posicion, bool valor)
        {
            byte resultado = numero;
            SetBit(ref resultado, posicion, valor);
            return resultado;
        }
        /// <summary>
        /// Establece un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos establecer el bit</param>
        /// <param name="posicion">Posición del bit a establecer</param>
        /// <param name="valor">Booleano con el valor del bit a establecer</param>
        public static ushort SetBit(this ushort numero, int posicion, bool valor)
        {
            ushort resultado = numero;
            SetBit(ref resultado, posicion, valor);
            return resultado;
        }
        /// <summary>
        /// Establece un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos establecer el bit</param>
        /// <param name="posicion">Posición del bit a establecer</param>
        /// <param name="valor">Booleano con el valor del bit a establecer</param>
        public static uint SetBit(this uint numero, int posicion, bool valor)
        {
            uint resultado = numero;
            SetBit(ref resultado, posicion, valor);
            return resultado;
        }
    }
    #endregion
}