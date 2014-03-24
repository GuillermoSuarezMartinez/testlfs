//***********************************************************************
// Assembly         : Orbita.Utiles
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//                    
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.Utiles
{
    /// <summary>
    /// Utilidades para el trabajo con cáracteres ASCII
    /// </summary>
    public class OASCIIUtiles
    {
        #region Atributo(s) estático(s)
        /// <summary>
        /// Tabla ASCII
        /// </summary>
        public static Dictionary<byte, string> TablaASCII = GenerarTablaASCII();
        #endregion

        #region Método(s) privado(s) estático(s)
        public static Dictionary<byte, string> GenerarTablaASCII()
        {
            Dictionary<byte, string> tablaASCII = new Dictionary<byte, string>();
        
            tablaASCII.Add(0, "[NUL]");
            tablaASCII.Add(1, "[SOH]");
            tablaASCII.Add(2, "[STX]");
            tablaASCII.Add(3, "[ETX]");
            tablaASCII.Add(4, "[EOT]");
            tablaASCII.Add(5, "[ENQ]");
            tablaASCII.Add(6, "[ACK]");
            tablaASCII.Add(7, "[BEL]");
            tablaASCII.Add(8, "[BS]");
            tablaASCII.Add(9, "[TAB]");
            tablaASCII.Add(10, "[LF]");
            tablaASCII.Add(11, "[VT]");
            tablaASCII.Add(12, "[FF]");
            tablaASCII.Add(13, "[CR]");
            tablaASCII.Add(14, "[SO]");
            tablaASCII.Add(15, "[SI]");
            tablaASCII.Add(16, "[DLE]");
            tablaASCII.Add(17, "[DC1]");
            tablaASCII.Add(18, "[DC2]");
            tablaASCII.Add(19, "[DC3]");
            tablaASCII.Add(20, "[DC4]");
            tablaASCII.Add(21, "[NAK]");
            tablaASCII.Add(22, "[SYN]");
            tablaASCII.Add(23, "[ETB]");
            tablaASCII.Add(24, "[CAN]");
            tablaASCII.Add(25, "[EM]");
            tablaASCII.Add(26, "[SUB]");
            tablaASCII.Add(27, "[ESC]");
            tablaASCII.Add(28, "[FS]");
            tablaASCII.Add(29, "[GS]");
            tablaASCII.Add(30, "[RS]");
            tablaASCII.Add(31, "[US]");
            for (byte i = 32; i < 127; i++)
            {
                byte[] item = new byte[1];
                item[0] = byte.Parse(i.ToString());
                tablaASCII.Add(i, ASCIIEncoding.ASCII.GetString(item));
            }
            tablaASCII.Add(127, "[DEL]");

            return tablaASCII;
        }
        #endregion

        #region Método(s) público(s) estático(s)
        /// <summary>
        /// Convierte un caracter ASCII en texto inteligible para su interpretación
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public static string ASCII2String(byte dato)
        {
            if (TablaASCII.ContainsKey(dato))
            {
                return TablaASCII[dato];
            }
            else
            {
                return "[" + dato + "]";
            }
        }

        /// <summary>
        /// Convierte un conjunto de caracteres ASCII en texto inteligible para su interpretación
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public static string ASCII2String(byte[] datos)
        {
            string retorno = string.Empty;
            if (datos != null)
            {
                for (int i = 0; i < datos.Length; i++)
                {
                    byte dato = datos[i];
                    retorno += ASCII2String(dato);
                }
            }
            return retorno;
        }

        /// <summary>
        /// Convierte un conjunto de caracteres ASCII en texto inteligible para su interpretación
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public static string ASCII2String(List<byte> datos)
        {
            string retorno = string.Empty;
            if (datos != null)
            {
                for (int i = 0; i < datos.Count; i++)
                {
                    byte dato = datos[i];
                    retorno += ASCII2String(dato);
                }
            }
            return retorno;
        }

        /// <summary>
        /// Convierte un caracter ASCII en texto inteligible para su interpretación
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public static string ASCII2String(char dato)
        {
            if (TablaASCII.ContainsKey((byte)dato))
            {
                return TablaASCII[(byte)dato];
            }
            else
            {
                return "[" + dato + "]";
            }
        }

        /// <summary>
        /// Convierte un conjunto de caracteres ASCII en texto inteligible para su interpretación
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public static string ASCII2String(char[] datos)
        {
            string retorno = string.Empty;
            if (datos != null)
            {
                for (int i = 0; i < datos.Length; i++)
                {
                    byte dato = (byte)datos[i];
                    retorno += ASCII2String(dato);
                }
            }
            return retorno;
        }

        /// <summary>
        /// Convierte un conjunto de caracteres ASCII en texto inteligible para su interpretación
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public static string ASCII2String(List<char> datos)
        {
            string retorno = string.Empty;
            if (datos != null)
            {
                for (int i = 0; i < datos.Count; i++)
                {
                    byte dato = (byte)datos[i];
                    retorno += ASCII2String(dato);
                }
            }
            return retorno;
        }

        /// <summary>
        /// Convierte un conjunto de caracteres ASCII en texto inteligible para su interpretación
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public static string ASCII2String(string datos)
        {
            string retorno = string.Empty;
            if (datos != null)
            {
                for (int i = 0; i < datos.Length; i++)
                {
                    byte dato = (byte)datos[i];
                    retorno += ASCII2String(dato);
                }
            }
            return retorno;
        }
        #endregion
    }
}
