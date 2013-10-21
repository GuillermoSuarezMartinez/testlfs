using System;
using System.Collections;
using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Colecciones de tags.
    /// </summary>
    [Serializable]
    public class OTags : IDisposable
    {
        #region Atributos
        /// <summary>
        /// Colección de tags de datos.
        /// Key = Identificador numérico de la variable.
        /// Object = InfoDato.
        /// </summary>
        private OHashtable _datos;
        /// <summary>
        /// Colección de tags DB.
        /// Key = Texto de la variable.
        /// Object = InfoDato.
        /// </summary>
        private OHashtable _db;
        /// <summary>
        /// Colección de tags de lecturas.
        /// </summary>
        private OHashtable _lecturas;
        /// <summary>
        /// Colección de tags de alarmas.
        /// </summary>
        private OHashtable _alarmas;
        /// <summary>
        /// Colección de alarmas activas.
        /// </summary>
        private ArrayList _alarmasActivas;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase OTags.
        /// </summary>
        public OTags()
        {
            // Inicializar cada una de las colecciones.
            _datos = new OHashtable();
            _db = new OHashtable();
            _lecturas = new OHashtable();
            _alarmas = new OHashtable();
            _alarmasActivas = new ArrayList();

            Config = new OConfigDispositivo();
        }
        #endregion Constructor

        #region Miembros de IDisposable
        /// <summary>
        /// Indica si ya se llamo al método Dispose. (default = false)
        /// </summary>
        bool _disposed;
        /// <summary>
        /// Implementa IDisposable.
        /// No  hacer  este  método  virtual.
        /// Una clase derivada no debería ser capaz de  reemplazar este método.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que  contiene la lógica para liberar los recursos de esta clase.
            Dispose(true);
            // Este objeto será limpiado por el método Dispose.
            // Llama al método del recolector de basura, GC.SuppressFinalize.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Método  sobrecargado de  Dispose que será  el que
        /// libera los recursos. Controla que solo se ejecute
        /// dicha lógica una  vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name="disposing">Indica si llama al método Dispose.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Preguntar si Dispose ya fue llamado.
            if (_disposed) return;
            if (disposing)
            {
                // Llamar a dispose de todos los recursos manejados.
                _datos.Dispose();
                _db.Dispose();
                _lecturas.Dispose();
                _alarmas.Dispose();
            }

            _alarmasActivas = null;

            // Marcar como desechada ó desechandose,
            // de forma que no se puede ejecutar el
            // código dos veces.
            _disposed = true;
        }
        /// <summary>
        /// Destructor(es) de clase.
        /// En caso de que se nos olvide “desechar” la clase,
        /// el GC llamará al destructor, que tambén ejecuta 
        /// la lógica anterior para liberar los recursos.
        /// </summary>
        ~OTags()
        {
            // Llamar a Dispose(false) es óptimo en terminos
            // de legibilidad y mantenimiento.
            Dispose(false);
        }
        #endregion Miembros de IDisposable

        #region Propiedades
        /// <summary>
        /// Object = InfoOPCvida.
        /// </summary>
        public OInfoOPCvida HtVida { get; set; }
        /// <summary>
        /// Configuración.
        /// </summary>
        public OConfigDispositivo Config { get; set; }
        #endregion Propiedades

        #region Métodos públicos
        /// <summary>
        /// Obtener la colección de datos, lecturas y alarmas.
        /// </summary>
        public OHashtable GetDatos()
        {
            return _datos;
        }
        /// <summary>
        /// Obtener el objeto i-esimo de la colección.
        /// </summary>
        /// <param name="clave">Clave de la colección.</param>
        /// <returns>Objeto de tipo InfoDatos.</returns>
        public OInfoDato GetDatos(object clave)
        {
            return (OInfoDato)_datos[clave];
        }
        /// <summary>
        /// Asignar la colección de datos, lecturas y alarmas.
        /// </summary>
        /// <param name="datos">Colección de datos, lecturas y alarmas.</param>
        public void SetDatos(OHashtable datos)
        {
            _datos = datos;
        }
        /// <summary>
        /// Asignar la colección de datos, lecturas y alarmas asociado por identificador.
        /// </summary>
        /// <param name="infoDato">Colección de datos, lecturas y alarmas.</param>
        public void SetDatos(OInfoDato infoDato)
        {
            if (infoDato != null)
            {
                _datos.Add(infoDato.Identificador, infoDato);
            }
        }
        /// <summary>
        /// Obtener la colección de datos, lecturas y alarmas.
        /// </summary>
        public OHashtable GetDB()
        {
            return _db;
        }
        /// <summary>
        /// Obtener el objeto i-esimo de la colección.
        /// </summary>
        /// <param name="clave">Clave de la colección.</param>
        /// <returns>Objeto de tipo InfoDatos.</returns>
        public OInfoDato GetDB(object clave)
        {
            return (OInfoDato)_db[clave];
        }
        /// <summary>
        /// Asignar la colección de datos, lecturas y alarmas.
        /// </summary>
        /// <param name="db">Colección de datos, lecturas y alarmas.</param>
        public void SetDB(object db)
        {
            _db = (OHashtable)db;
        }
        /// <summary>
        /// Asignar la colección de datos, lecturas y alarmas asociado por nombre.
        /// </summary>
        /// <param name="infoDato">Colección de datos, lecturas y alarmas.</param>
        public void SetDB(OInfoDato infoDato)
        {
            if (infoDato != null)
            {
                _db.Add(infoDato.Texto, infoDato);
            }
        }
        /// <summary>
        /// Obtener la colección de lecturas.
        /// </summary>
        public OHashtable GetLecturas()
        {
            return _lecturas;
        }
        /// <summary>
        /// Obtener el objeto i-esimo de la colección.
        /// </summary>
        /// <param name="clave">Clave de la colección.</param>
        /// <returns>Objeto de tipo InfoDatos.</returns>
        public OInfoDato GetLecturas(object clave)
        {
            return (OInfoDato)_lecturas[clave];
        }
        /// <summary>
        /// Asignar la colección de lecturas.
        /// </summary>
        /// <param name="lecturas">Colección de lecturas.</param>
        public void SetLecturas(OHashtable lecturas)
        {
            _lecturas = lecturas;
        }
        /// <summary>
        /// Asignar la colección de datos, lecturas y alarmas asociado por identificador.
        /// </summary>
        /// <param name="infoDato">Colección de datos, lecturas y alarmas.</param>
        public void SetLecturas(OInfoDato infoDato)
        {
            if (infoDato != null)
            {
                _lecturas.Add(infoDato.Identificador, infoDato);
            }
        }
        /// <summary>
        /// Obtener la colección de alarmas.
        /// </summary>
        public OHashtable GetAlarmas()
        {
            return _alarmas;
        }
        /// <summary>
        /// Obtener el objeto i-esimo de la colección.
        /// </summary>
        /// <param name="clave">Clave de la colección.</param>
        /// <returns>Objeto de tipo InfoDatos.</returns>
        public OInfoDato GetAlarmas(object clave)
        {
            return (OInfoDato)_alarmas[clave];
        }
        /// <summary>
        /// Asignar la colección de alarmas.
        /// </summary>
        /// <param name="alarmas">Colección de alarmas.</param>
        public void SetAlarmas(OHashtable alarmas)
        {
            _alarmas = alarmas;
        }
        /// <summary>
        /// Asignar la colección de datos, lecturas y alarmas asociado por identificador.
        /// </summary>
        /// <param name="infoDato">Colección de datos, lecturas y alarmas.</param>
        public void SetAlarmas(OInfoDato infoDato)
        {
            if (infoDato != null)
            {
                _alarmas.Add(infoDato.Identificador, infoDato);
            }
        }
        /// <summary>
        /// Obtener la colección de colecciones.
        /// </summary>
        public OInfoOPCvida GetVida()
        {
            return HtVida;
        }
        /// <summary>
        /// Asignar la colección de alarmas.
        /// </summary>
        /// <param name="vida">Colección de colecciones.</param>
        public void SetVida(OInfoOPCvida vida)
        {
            HtVida = vida;
        }
        /// <summary>
        /// Obtener la colección de alarmas activas.
        /// </summary>
        public ArrayList GetAlarmasActivas()
        {
            return _alarmasActivas;
        }
        /// <summary>
        /// Obtener el objeto i-esimo de la colección.
        /// </summary>
        /// <param name="indice">Clave de la colección.</param>
        /// <returns>Objeto de tipo InfoDatos.</returns>
        public OInfoDato GetAlarmasActivas(int indice)
        {
            return (OInfoDato)_alarmasActivas[indice];
        }
        /// <summary>
        /// Asignar la colección de alarmas activas.
        /// </summary>
        /// <param name="alarmasActivas">Colección de alarmas activas.</param>
        public void SetAlarmasActivas(ArrayList alarmasActivas)
        {
            _alarmasActivas = alarmasActivas;
        }
        #endregion Métodos públicos
    }
}