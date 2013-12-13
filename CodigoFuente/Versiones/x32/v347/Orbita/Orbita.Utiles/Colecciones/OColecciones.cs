//***********************************************************************
// Assembly         : Orbita.Utiles
// Author           : aibañez
// Created          : 13-12-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Utiles
{
    /// <summary>
    /// Clase utilizada para almacenar un par de valores
    /// </summary>
    /// <typeparam name="TFirst">Tipo del primer valor.</typeparam>
    /// <typeparam name="TSecond">Tipo del segundo valor.</typeparam>
    public class OPair<TFirst, TSecond>
    {
        #region Atributos
        /// <summary>
        /// Primer valor
        /// </summary>
        public TFirst First;
        /// <summary>
        /// Segundo valor
        /// </summary>
        public TSecond Second;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OPair() { }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OPair(TFirst first, TSecond second)
        {
            this.First = first;
            this.Second = second;
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para almacenar un trío de valores.
    /// </summary>
    /// <typeparam name="TFirst">Tipo del primer valor</typeparam>
    /// <typeparam name="TSecond">Tipo del segundo valor</typeparam>
    /// <typeparam name="TThird">Tipo del tercer valor</typeparam>
    public class OTriplet<TFirst, TSecond, TThird>
    {
        #region Atributos
        /// <summary>
        /// Primer valor
        /// </summary>
        public TFirst First;
        /// <summary>
        /// Segundo valor
        /// </summary>
        public TSecond Second;
        /// <summary>
        /// Tercer valor
        /// </summary>
        public TThird Third;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OTriplet() { }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OTriplet(TFirst first, TSecond second, TThird third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para almacenar un cuarteto de valores
    /// </summary>
    /// <typeparam name="TFirst">Tipo del primer valor</typeparam>
    /// <typeparam name="TSecond">Tipo del segundo valor</typeparam>
    /// <typeparam name="TThird">Tipo del tercer valor</typeparam>
    /// <typeparam name="TFourth">Tipo del cuarto valor</typeparam>
    public class OQuartet<TFirst, TSecond, TThird, TFourth>
    {
        #region Atributos
        /// <summary>
        /// Primer valor
        /// </summary>
        public TFirst First;
        /// <summary>
        /// Segundo valor
        /// </summary>
        public TSecond Second;
        /// <summary>
        /// Tercer valor
        /// </summary>
        public TThird Third;
        /// <summary>
        /// Cuarto valor
        /// </summary>
        public TFourth Fourth;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OQuartet() { }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OQuartet(TFirst first, TSecond second, TThird third, TFourth fourth)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.Fourth = fourth;
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para almacenar un quinteto de valores
    /// </summary>
    /// <typeparam name="TFirst">Tipo del primer valor</typeparam>
    /// <typeparam name="TSecond">Tipo del segundo valor</typeparam>
    /// <typeparam name="TThird">Tipo del tercer valor</typeparam>
    /// <typeparam name="TFourth">Tipo del cuarto valor</typeparam>
    /// <typeparam name="TFifth">Tipo del quinto valor</typeparam>
    public class OQuintet<TFirst, TSecond, TThird, TFourth, TFifth>
    {
        #region Atributos
        /// <summary>
        /// Primer valor
        /// </summary>
        public TFirst First;
        /// <summary>
        /// Segundo valor
        /// </summary>
        public TSecond Second;
        /// <summary>
        /// Tercer valor
        /// </summary>
        public TThird Third;
        /// <summary>
        /// Cuarto valor
        /// </summary>
        public TFourth Fourth;
        /// <summary>
        /// Quinto valor
        /// </summary>
        public TFifth Fifth;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OQuintet() { }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OQuintet(TFirst first, TSecond second, TThird third, TFourth fourth, TFifth fifth)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.Fourth = fourth;
            this.Fifth = fifth;
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para almacenar un sexteto de valores
    /// </summary>
    /// <typeparam name="TFirst">Tipo del primer valor</typeparam>
    /// <typeparam name="TSecond">Tipo del segundo valor</typeparam>
    /// <typeparam name="TThird">Tipo del tercer valor</typeparam>
    /// <typeparam name="TFourth">Tipo del cuarto valor</typeparam>
    /// <typeparam name="TFifth">Tipo del quinto valor</typeparam>
    /// <typeparam name="TSixth">Tipo del sexto valor</typeparam>
    public class OSextet<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>
    {
        #region Atributos
        /// <summary>
        /// Primer valor
        /// </summary>
        public TFirst First;
        /// <summary>
        /// Segundo valor
        /// </summary>
        public TSecond Second;
        /// <summary>
        /// Tercer valor
        /// </summary>
        public TThird Third;
        /// <summary>
        /// Cuarto valor
        /// </summary>
        public TFourth Fourth;
        /// <summary>
        /// Quinto valor
        /// </summary>
        public TFifth Fifth;
        /// <summary>
        /// Sexto valor
        /// </summary>
        public TSixth Sixth;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OSextet() { }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OSextet(TFirst first, TSecond second, TThird third, TFourth fourth, TFifth fifth, TSixth sixth)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.Fourth = fourth;
            this.Fifth = fifth;
            this.Sixth = sixth;
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para almacenar un septeto de valores
    /// </summary>
    /// <typeparam name="TFirst">Tipo del primer valor</typeparam>
    /// <typeparam name="TSecond">Tipo del segundo valor</typeparam>
    /// <typeparam name="TThird">Tipo del tercer valor</typeparam>
    /// <typeparam name="TFourth">Tipo del cuarto valor</typeparam>
    /// <typeparam name="TFifth">Tipo del quinto valor</typeparam>
    /// <typeparam name="TSixth">Tipo del sexto valor</typeparam>
    /// <typeparam name="TSeventh">Tipo del séptimo valor</typeparam>
    public class OSeptet<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>
    {
        #region Atributos
        /// <summary>
        /// Primer valor
        /// </summary>
        public TFirst First;
        /// <summary>
        /// Segundo valor
        /// </summary>
        public TSecond Second;
        /// <summary>
        /// Tercer valor
        /// </summary>
        public TThird Third;
        /// <summary>
        /// Cuarto valor
        /// </summary>
        public TFourth Fourth;
        /// <summary>
        /// Quinto valor
        /// </summary>
        public TFifth Fifth;
        /// <summary>
        /// Sexto valor
        /// </summary>
        public TSixth Sixth;
        /// <summary>
        /// Séptimo valor
        /// </summary>
        public TSeventh Seventh;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OSeptet() { }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OSeptet(TFirst first, TSecond second, TThird third, TFourth fourth, TFifth fifth, TSixth sixth, TSeventh seventh)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.Fourth = fourth;
            this.Fifth = fifth;
            this.Sixth = sixth;
            this.Seventh = seventh;
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para almacenar un octeto de valores
    /// </summary>
    /// <typeparam name="TFirst">Tipo del primer valor</typeparam>
    /// <typeparam name="TSecond">Tipo del segundo valor</typeparam>
    /// <typeparam name="TThird">Tipo del tercer valor</typeparam>
    /// <typeparam name="TFourth">Tipo del cuarto valor</typeparam>
    /// <typeparam name="TFifth">Tipo del quinto valor</typeparam>
    /// <typeparam name="TSixth">Tipo del sexto valor</typeparam>
    /// <typeparam name="TSeventh">Tipo del séptimo valor</typeparam>
    /// <typeparam name="TOctet">Tipo del octavo valor</typeparam>
    public class OOctet<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOctet>
    {
        #region Atributos
        /// <summary>
        /// Primer valor
        /// </summary>
        public TFirst First;
        /// <summary>
        /// Segundo valor
        /// </summary>
        public TSecond Second;
        /// <summary>
        /// Tercer valor
        /// </summary>
        public TThird Third;
        /// <summary>
        /// Cuarto valor
        /// </summary>
        public TFourth Fourth;
        /// <summary>
        /// Quinto valor
        /// </summary>
        public TFifth Fifth;
        /// <summary>
        /// Sexto valor
        /// </summary>
        public TSixth Sixth;
        /// <summary>
        /// Séptimo valor
        /// </summary>
        public TSeventh Seventh;
        /// <summary>
        /// Octavo valor
        /// </summary>
        public TOctet Eighth;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OOctet() { }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OOctet(TFirst first, TSecond second, TThird third, TFourth fourth, TFifth fifth, TSixth sixth, TSeventh seventh, TOctet eighth)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.Fourth = fourth;
            this.Fifth = fifth;
            this.Sixth = sixth;
            this.Seventh = seventh;
            this.Eighth = eighth;
        }
        #endregion
    }
}