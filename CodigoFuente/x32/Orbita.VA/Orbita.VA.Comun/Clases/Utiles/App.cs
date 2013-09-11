//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 16-11-2012
//
// Last Modified By : aibañez
// Last Modified On : 12-12-2012
// Description      : Creados objetos para el trabajo con CGI
//
//      Modified By : aibañez
//      Modified On : 16-11-2012
// Description      : Extraido delegado genérico SimpleMethod fuera de App
//                    Añadidos delegados genérico MessageDelegate y ExceptionDelegate
//                    Añadida función ColectorBasura para centralizar las llamadas al GarbageCollector de .Net
//
//      Modified By : aibañez
//      Modified On : 05-11-2012
// Description      : Añadido un método sobrecargado de Espera donde se le pasa como argumento un delegado
//                    Nuevo método para reemplazar strings especificando el tipo de comparación
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Orbita.Utiles;
                                                            
namespace Orbita.VA.Comun
{
	#region Clase estática App: Contiene métodos genéricos
	/// <summary>
	/// Clase estática con funciones de uso general
	/// </summary>
	public static class App
	{
		#region Atributo(s) de la clase
        /// <summary>
        /// Guarda el vínculo con el formulario principal de la aplicación
        /// </summary>
        public static Form FormularioPrincipal;
		#endregion Campos de la clase

        #region Conversion de colecciones
		/// <summary>
		/// Convierte una colección en una cadena de texto
		/// </summary>
		/// <param name="coleccion">Colección que se desea convertir en texto</param>
		/// <param name="separador">Caracter separador de cada uno de los valores de la colección</param>
		/// <returns>Cadena de texto con todos los valores de la colección separados por el carácter separador</returns>
		public static string Colection2String(ICollection coleccion, char separador)
		{
			string resultado = string.Empty;

			foreach (object valor in coleccion)
			{
                resultado += OObjeto.ToString(valor) + separador;
			}

			return resultado;
		}

		/// <summary>
		/// Delegado para la conversión del tipo string a cualquier tipo
		/// </summary>
		/// <typeparam name="T">Tipo que se desea devolver</typeparam>
		/// <param name="text"></param>
		/// <returns></returns>
		public delegate T ConvertFromString<T>(string text);

		/// <summary>
		/// Convierte una cadena de texto en una colección
		/// </summary>
		/// <typeparam name="T">Tipo de colección que se desea devolver</typeparam>
		/// <param name="texto">Texto que se convertira en colección</param>
		/// <param name="separador">Caracter separador de cada uno de los valores de la colección</param>
		/// <returns>Objeto de tipo colección con todos los valores que contiene el texto separados por el carácter separador</returns>
		public static T String2Collection<T>(string texto, char separador, ConvertFromString<T> conversion)
			where T : IList, new()
		{
			T resultado = new T();

			string[] strArray = texto.Split(separador);
			foreach (string strValue in strArray)
			{
				resultado.Add(conversion(strValue));
			}

			return resultado;
		}
		#endregion

		#region Arrays
		/// <summary>
		/// Función para redimiendionar un Array
		/// </summary>
		/// <param name="orgArray">Array</param>
		/// <param name="tamaño">Tamaño</param>
		/// <returns>Array redimensionado</returns>
		public static Array aRedimensionar(Array orgArray, Int32 tamaño)
		{
			Type t = orgArray.GetType().GetElementType();
			Array nArray = Array.CreateInstance(t, tamaño);
			Array.Copy(orgArray, 0, nArray, 0, Math.Min(orgArray.Length, tamaño));
			return nArray;
		}
		#endregion

		#region Punteros
		/// <summary>
		/// Obtiene el puntero a partir del objeto
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static IntPtr GetPtrToNewObject(object obj)
		{
			IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(obj));
			Marshal.StructureToPtr(obj, ptr, false);
			return ptr;
		}
		#endregion

		#region Reflexión
		/// <summary>
		/// Función capaz de construir una clase dinámicamente
		/// </summary>
		/// <param name="ensamblado">Nombre del ensamblado al que pertenece la clase</param>
		/// <param name="claseImplementadora">Nombre de la clase a construir</param>
		/// <param name="objetoImplementado">Objeto resultado de la implementación</param>
		/// <param name="args">Argumentos</param>
		/// <returns></returns>
		public static bool ConstruirClase(string ensamblado, string claseImplementadora, out object objetoImplementado, params object[] args)
		{
			objetoImplementado = null;
			bool resultado = false;
			try
			{
                ensamblado = ensamblado.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                claseImplementadora = claseImplementadora.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");

				Assembly assembly = Assembly.Load(ensamblado);
				Type tipoClaseImplementadora = assembly.GetType(claseImplementadora);
				if (tipoClaseImplementadora == null)
				{
					OLogsVAComun.Comun.Fatal("Constructor clase", "No se encuentra la clase implementadora " + claseImplementadora);
				}
				else
				{
					objetoImplementado = Activator.CreateInstance(tipoClaseImplementadora, args);
					resultado = true;
				}
			}
			catch (Exception exception)
			{
                OLogsVAComun.Comun.Error(exception, "ConstruirClasePorReflexión", string.Format("Ensamblado: {0}, Clase: {1}", ensamblado, claseImplementadora));
			}
			return resultado;
		}

        /// <summary>
        /// Función capaz de construir una clase dinámicamente
        /// </summary>
        /// <param name="claseImplementadora">Tipo de la clase a construir</param>
        /// <param name="objetoImplementado">Objeto resultado de la implementación</param>
        /// <param name="args">Argumentos</param>
        /// <returns></returns>
        public static bool ConstruirClase(Type claseImplementadora, out object objetoImplementado, params object[] args)
        {
            objetoImplementado = null;
            bool resultado = false;
            try
            {
                objetoImplementado = Activator.CreateInstance(claseImplementadora, args);
                resultado = true;
            }
            catch (Exception exception)
            {
                OLogsVAComun.Comun.Error(exception, "ConstruirClasePorReflexión", string.Format("Clase: {0}", claseImplementadora.ToString()));
            }
            return resultado;
        }
        #endregion

        #region Red
        public static bool HttpPing(string url)
        {
            bool resultado = false;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
                request.Method = "HEAD";
                WebResponse webResponse = request.GetResponse();
                resultado = webResponse.ContentLength > 0;
                // do something with response.Headers to find out information about the request
            }
            catch
            {
                //set flag if there was a timeout or some other issues
            }
            return resultado;
        }
        #endregion
	}
	#endregion

	#region Enumerado de capitalización del texto
	/// <summary>
	/// Modifica la capitalización de un texto
	/// </summary>
	public enum OCapitalizacionTexto
	{
		/// <summary>
		/// No realiza ninguna acción
		/// </summary>
		Nada,
		/// <summary>
		/// Convierte el texto a mayusculas
		/// </summary>
		Mayusculas,
		/// <summary>
		/// Convierte el texto a minusculas
		/// </summary>
		Minusculas
	}
	#endregion

    #region Definición de delegado(s) genéricos
    /// <summary>
    /// Delegado de método simple
    /// </summary>
    public delegate void OSimpleMethod();
    /// <summary>
    /// Delegado de método simple con devolución de booleano
    /// </summary>
    public delegate bool OSimpleReturnMethod();
    /// <summary>
    /// Delegado utilizado para devolver mensajes
    /// </summary>
    /// <param name="message"></param>
    public delegate void OMessageDelegate(string mensaje);
    /// <summary>
    /// Delegado utilizado para devolver mensajes
    /// </summary>
    /// <param name="codigo"></param>
    /// <param name="message"></param>
    public delegate void OMessageDelegateAdv(string codigo, string mensaje);

    /// <summary>
    /// Delegado de nuevo mensaje
    /// </summary>
    /// <param name="estadoConexion"></param>
    public delegate void OMessageEvent(object sender, OMessageEventArgs e);
    /// <summary>
    /// Argumentos del evento de mensaje
    /// </summary>
    [Serializable]
    public class OMessageEventArgs: EventArgs
    {
        #region Propiedad(es)
        /// <summary>
        /// Código identificativo de la variable
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código identificativo de la variable
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Nueva imagen
        /// </summary>
        private string _Mensaje;
        /// <summary>
        /// Nueva imagen
        /// </summary>
        public string Mensaje
        {
            get { return _Mensaje; }
            set { _Mensaje = value; }
        }
        #endregion

        #region Constructor de la clase
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codigo">Código identificativo de la variable</param>
        /// <param name="valor">Valor de la variable</param>
        public OMessageEventArgs(string codigo, string mensaje)
        {
            this._Codigo = codigo;
            this._Mensaje = mensaje;
        }
        #endregion
    }

    /// <summary>
    /// Delegado utilizado para devolver una excepción
    /// </summary>
    /// <param name="message"></param>
    public delegate void OExceptionDelegate(Exception exception);
    /// <summary>
    /// Delegado utilizado para devolver una excepción
    /// </summary>
    /// <param name="codigo"></param>
    /// <param name="message"></param>
    public delegate void OExceptionDelegateAdv(string codigo, Exception exception);
    #endregion
}