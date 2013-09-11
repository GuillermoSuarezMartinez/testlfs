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
        #region Atributos privados
        /// <summary>
        /// Colección de tags de datos.
        /// Key = Identificador numérico
        /// de la variable.
        /// Object = InfoDato.
        /// </summary>
        private OHashtable _htDatos;
        /// <summary>
        /// Colección de tags DB.
        /// Key = Texto de la variable.
        /// Object = InfoDato.
        /// </summary>
        private OHashtable _htDB;
        /// <summary>
        /// Colección de tags de lecturas.
        /// </summary>
        private OHashtable _htLecturas;
        /// <summary>
        /// Colección de tags de alarmas.
        /// </summary>
        private OHashtable _htAlarmas;
        /// <summary>
        /// Colección de alarmas activas.
        /// </summary>
        private ArrayList _alAlarmasActivas;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase OTags.
        /// </summary>
        public OTags()
        {
            // Inicializar cada una de las colecciones.
            this._htDatos = new OHashtable();
            this._htDB = new OHashtable();
            this._htLecturas = new OHashtable();
            this._htAlarmas = new OHashtable();
            this._alAlarmasActivas = new ArrayList();
            this.Config = new OConfigDispositivo();
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Indica si ya se llamo al método Dispose. (default = false)
        /// </summary>
        bool _disposed;
        /// <summary>
        /// Implementa IDisposable.
        /// No  hacer  este  método  virtual.
        /// Una clase derivada no debería ser
        /// capaz de  reemplazar este método.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que  contiene la lógica
            // para liberar los recursos de esta clase.
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
            if (this._disposed) return;
            if (disposing)
            {
                // Llamar a dispose de todos los recursos manejados.
                this._htDatos.Dispose();
                this._htDB.Dispose();
                this._htLecturas.Dispose();
                this._htAlarmas.Dispose();
            }

            this._alAlarmasActivas = null;

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
        #endregion

        #region Propiedades
        /// <summary>
        /// Object = InfoOPCvida.
        /// </summary>
        public OInfoOPCvida HtVida { get; set; }
        /// <summary>
        /// Configuración.
        /// </summary>
        public OConfigDispositivo Config { get; set; }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Obtener la colección de datos, lecturas y alarmas.
        /// </summary>
        public OHashtable GetDatos()
        {
            return this._htDatos;
        }
        /// <summary>
        /// Obtener el objeto i-esimo de la colección.
        /// </summary>
        /// <param name="clave">Clave de la colección.</param>
        /// <returns>Objeto de tipo InfoDatos.</returns>
        public OInfoDato GetDatos(object clave)
        {
            return (OInfoDato)this._htDatos[clave];
        }
        /// <summary>
        /// Asignar la colección de datos, lecturas y alarmas.
        /// </summary>
        /// <param name="datos">Colección de datos, lecturas y alarmas.</param>
        public void SetDatos(OHashtable datos)
        {
            this._htDatos = datos;
        }
        /// <summary>
        /// Asignar la colección de datos, lecturas y alarmas asociado por identificador.
        /// </summary>
        /// <param name="infoDato">Colección de datos, lecturas y alarmas.</param>
        public void SetDatos(OInfoDato infoDato)
        {
            if (infoDato != null)
            {
                
                this._htDatos.Add(infoDato.Identificador, infoDato);
            }
        }
        /// <summary>
        /// Obtener la colección de datos, lecturas y alarmas.
        /// </summary>
        public OHashtable GetDB()
        {
            return this._htDB;
        }
        /// <summary>
        /// Obtener el objeto i-esimo de la colección.
        /// </summary>
        /// <param name="clave">Clave de la colección.</param>
        /// <returns>Objeto de tipo InfoDatos.</returns>
        public OInfoDato GetDB(object clave)
        {
            return (OInfoDato)this._htDB[clave];
        }
        /// <summary>
        /// Asignar la colección de datos, lecturas y alarmas.
        /// </summary>
        /// <param name="db">Colección de datos, lecturas y alarmas.</param>
        public void SetDB(object db)
        {
            this._htDB = (OHashtable)db;
        }
        /// <summary>
        /// Asignar la colección de datos, lecturas y alarmas asociado por nombre.
        /// </summary>
        /// <param name="infoDato">Colección de datos, lecturas y alarmas.</param>
        public void SetDB(OInfoDato infoDato)
        {
            if (infoDato != null)
            {
                this._htDB.Add(infoDato.Texto, infoDato);
            }
        }
        /// <summary>
        /// Obtener la colección de lecturas.
        /// </summary>
        public OHashtable GetLecturas()
        {
            return this._htLecturas;
        }
        /// <summary>
        /// Obtener el objeto i-esimo de la colección.
        /// </summary>
        /// <param name="clave">Clave de la colección.</param>
        /// <returns>Objeto de tipo InfoDatos.</returns>
        public OInfoDato GetLecturas(object clave)
        {
            return (OInfoDato)this._htLecturas[clave];
        }
        /// <summary>
        /// Asignar la colección de lecturas.
        /// </summary>
        /// <param name="lecturas">Colección de lecturas.</param>
        public void SetLecturas(OHashtable lecturas)
        {
            this._htLecturas = lecturas;
        }
        /// <summary>
        /// Asignar la colección de datos, lecturas y alarmas asociado por identificador.
        /// </summary>
        /// <param name="infoDato">Colección de datos, lecturas y alarmas.</param>
        public void SetLecturas(OInfoDato infoDato)
        {
            if (infoDato != null)
            {
                this._htLecturas.Add(infoDato.Identificador, infoDato);
            }
        }
        /// <summary>
        /// Obtener la colección de alarmas.
        /// </summary>
        public OHashtable GetAlarmas()
        {
            return this._htAlarmas;
        }
        /// <summary>
        /// Obtener el objeto i-esimo de la colección.
        /// </summary>
        /// <param name="clave">Clave de la colección.</param>
        /// <returns>Objeto de tipo InfoDatos.</returns>
        public OInfoDato GetAlarmas(object clave)
        {
            return (OInfoDato)this._htAlarmas[clave];
        }
        /// <summary>
        /// Asignar la colección de alarmas.
        /// </summary>
        /// <param name="alarmas">Colección de alarmas.</param>
        public void SetAlarmas(OHashtable alarmas)
        {
            this._htAlarmas = alarmas;
        }
        /// <summary>
        /// Asignar la colección de datos, lecturas y alarmas asociado por identificador.
        /// </summary>
        /// <param name="infoDato">Colección de datos, lecturas y alarmas.</param>
        public void SetAlarmas(OInfoDato infoDato)
        {
            if (infoDato != null)
            {
                this._htAlarmas.Add(infoDato.Identificador, infoDato);
            }
        }
        /// <summary>
        /// Obtener la colección de colecciones.
        /// </summary>
        public OInfoOPCvida GetVida()
        {
            return this.HtVida;
        }
        /// <summary>
        /// Asignar la colección de alarmas.
        /// </summary>
        /// <param name="vida">Colección de colecciones.</param>
        public void SetVida(OInfoOPCvida vida)
        {
            this.HtVida = vida;
        }
        /// <summary>
        /// Obtener la colección de alarmas activas.
        /// </summary>
        public ArrayList GetAlarmasActivas()
        {
            return this._alAlarmasActivas;
        }
        /// <summary>
        /// Obtener el objeto i-esimo de la colección.
        /// </summary>
        /// <param name="indice">Clave de la colección.</param>
        /// <returns>Objeto de tipo InfoDatos.</returns>
        public OInfoDato GetAlarmasActivas(int indice)
        {
            return (OInfoDato)this._alAlarmasActivas[indice];
        }
        /// <summary>
        /// Asignar la colección de alarmas activas.
        /// </summary>
        /// <param name="alarmasActivas">Colección de alarmas activas.</param>
        public void SetAlarmasActivas(ArrayList alarmasActivas)
        {
            this._alAlarmasActivas = alarmasActivas;
        }
        #endregion
    }
}