//***********************************************************************
// Assembly         : Orbita.Framework.Extensiones
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Framework.Extensiones
{
    internal static class ExtendedFile
    {
        #region Atributos internos estáticos
        /// <summary>
        /// Atributo estático volátil de bloqueo.
        /// </summary>
        internal static volatile object Bloqueo = new object();
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Leer fichero de texto.
        /// </summary>
        /// <param name="nombre">Ruta del fichero.</param>
        /// <returns>Fichero de tipo StreamReader.</returns>
        public static string Leer(string nombre)
        {
            lock (Bloqueo)
            {
                //  Escribir el texto en el fichero de datos de disco.
                System.IO.FileStream fs = null;
                try
                {
                    //  Abrir el Fichero = Nombre del fichero, en modo escritura con lectura compartida y modo de creacion.
                    fs = new System.IO.FileStream(nombre, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(fs))
                    {
                        //  Referencia: necesario para evitar CA2202: No aplicar Dispose a los objetos varias veces.
                        fs = null;
                        return sr.ReadToEnd();
                    }
                }
                catch (System.IO.DirectoryNotFoundException)
                {
                    return string.Empty;
                }
                catch (System.Exception)
                {
                    throw;
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                }
            }
        }
        #endregion
    }
}