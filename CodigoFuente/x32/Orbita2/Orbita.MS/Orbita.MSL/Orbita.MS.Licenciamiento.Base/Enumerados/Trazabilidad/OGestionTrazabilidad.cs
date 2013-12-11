using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Orbita.Trazabilidad;

namespace Orbita.MS.Clases.Trazabilidad
{
    /// <summary>
    /// Gestiona la trazabilidad de las operaciones y resultados
    /// </summary>
    public static class OGestionTrazabilidad
    {
        #region Constantes
        private const string ficheroConfiguracionLog = "Log.config.xml";
        #endregion Constantes
        #region Atributos
        private static bool _inicializado = false;
        private static ILogger _predeterminado = LogManager.GetLogger("General");
        #endregion Atributos
        #region Propiedades
        /// <summary>
        /// Indica si está inicializada
        /// </summary>
        public static bool Inicializado
        {
            get { return _inicializado; }
            set { _inicializado = value; }
        }
        /// <summary>
        /// Obtiene el LoggerPredeterminado
        /// </summary>
        public static ILogger LoggerPredeterminado
        {
            get { if (!_inicializado) InicializarTrazabilidad(); return OGestionTrazabilidad._predeterminado; }
            set { OGestionTrazabilidad._predeterminado = value; }
        }
        #endregion Propiedades
        #region Métodos públicos
        /// <summary>
        /// Inicializa trazabilidad en base al fichero de configuración
        /// </summary>
        /// <returns></returns>
        public static bool InicializarTrazabilidad()
        {
            try
            {
                string directorio = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                LogManager.ConfiguracionLogger(Path.Combine(directorio,ficheroConfiguracionLog));
                _inicializado = true;
                return true;
            }
            catch (Exception e1)
            {
                Console.Error.WriteLine(e1);
                return false;
            }

        }
        /// <summary>
        /// Obtine un logger concreto, si la operación falla obtiene el genérico.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public static ILogger GetLogger(string nombre)
        {
            try
            {
                if (!_inicializado) InicializarTrazabilidad();
                return LogManager.GetLogger(nombre);
            }
            catch (Exception e1)
            {
                if (_inicializado)
                {
                    _predeterminado.Error(e1);
                    return _predeterminado;
                }
                else
                {
                    Console.Error.WriteLine(e1);
                    return null;
                }
            }
        }
        #endregion Métodos públicos
    }
}
