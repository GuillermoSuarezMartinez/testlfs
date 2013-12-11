using System.Collections;
using System.IO;
using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas
    /// </summary>
    public interface IOCommRemoting
    {
        #region Eventos
        /// <summary>
        /// Evento de cambio de dato.
        /// </summary>
        event OManejadorEventoComm OrbitaCambioDato;
        /// <summary>
        /// Evento de alarma.
        /// </summary>
        event OManejadorEventoComm OrbitaAlarma;
        /// <summary>
        /// Evento de comunicaciones.
        /// </summary>
        event OManejadorEventoComm OrbitaComm;
        #endregion Eventos

        #region Métodos privados
        /// <summary>
        /// Método de conexión entre procesos.
        /// </summary>
        /// <param name="ip">Dirección Ip de conexión.</param>
        /// <param name="estado">Estado de la máquina; conectado, desconectado.</param>
        void OrbitaConectar(string ip, bool estado);
        /// <summary>
        /// Método de escritura de valores.
        /// </summary>
        /// <param name="dispositivo">Identificador de dispositivo de escritura.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <returns>Estado correcto o incorrecto de escritura.</returns>
        bool OrbitaEscribir(int dispositivo, string[] variables, object[] valores);
        /// <summary>
        /// Método de escritura de valores.
        /// </summary>
        /// <param name="dispositivo">Identificador de dispositivo de escritura.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <param name="canal"></param>
        /// <returns>Estado correcto o incorrecto de escritura.</returns>
        bool OrbitaEscribir(int dispositivo, string[] variables, object[] valores, string canal);
        /// <summary>
        /// Método de lectura de variables.
        /// </summary>
        /// <param name="dispositivo">Identificador de dispositivo de lectura.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="demanda">Indica si la lectura se realiza bajo demanda al dispositivo.</param>
        /// <returns>Colección de resultados.</returns>
        object[] OrbitaLeer(int dispositivo, string[] variables, bool demanda);
        /// <summary>
        /// Obtener la colección de datos, lecturas y alarmas.
        /// </summary>
        /// <returns>Colección de datos, lecturas y alarmas.</returns>
        OHashtable OrbitaGetDatos(int dispositivo);
        /// <summary>
        /// Obtener la colección de lecturas.
        /// </summary>
        /// <returns>Colección de lecturas.</returns>
        OHashtable OrbitaGetLecturas(int dispositivo);
        /// <summary>
        /// Obtener la colección de alarmas.
        /// </summary>
        /// <returns>Colección de alarmas.</returns>
        OHashtable OrbitaGetAlarmas(int dispositivo);
        /// <summary>
        /// Obtener la colección de alarmas.
        /// </summary>
        /// <returns>Colección de alarmas.</returns>
        ArrayList OrbitaGetAlarmasActivas(int dispositivo);
        /// <summary>
        /// Obtener los dispositivos del servicio
        /// </summary>
        /// <returns></returns>
        int[] OrbitaGetDispositivos();
        /// <summary>
        /// Obtener los dispositivos del servicio
        /// </summary>
        /// <returns></returns>
        Stream OrbitaGetDispositivosXML();
        #endregion Métodos privados
    }

    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting1 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting2 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting3 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting4 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting5 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting6 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting7 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting8 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting9 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting10 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting11 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting12 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting13 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting14 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting15 : IOCommRemoting { }
    /// <summary>
    /// Interfaz para la generación de comunicaciones remotas.
    /// </summary>
    public interface IOCommRemoting16 : IOCommRemoting { }
}