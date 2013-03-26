//***********************************************************************
// Assembly         : Orbita.Utiles
// Author           : crodriguez
// Created          : 03-03-2011
//
// Last Modified By : crodriguez
// Last Modified On : 03-03-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
namespace Orbita.Utiles
{
    public class OFichero : IDisposable
    {
        #region Atributos
        /// <summary>
        /// Identificador de fichero.
        /// </summary>
        string identificador;
        /// <summary>
        /// Nombre de fichero.
        /// </summary>
        string nombre;
        /// <summary>
        /// Ruta de fichero.
        /// </summary>
        string ruta;
        /// <summary>
        /// Extensi�n de fichero.
        /// </summary>
        Extension extension;
        /// <summary>
        /// Indica si debe ser copiado en disco.
        /// </summary>
        bool copiarENdisco;
        /// <summary>
        /// Indica si debe ser copiado en Base
        /// de datos.
        /// </summary>
        bool copiarENbaseDEdatos;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OFichero.
        /// </summary>
        public OFichero() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OFichero.
        /// </summary>
        /// <param name="identificador">Identificador del fichero.</param>
        /// <param name="extension">Extensi�n del fichero.</param>
        /// <param name="copiarEnDisco">Determinar si copiar dicho fichero en disco.</param>
        /// <param name="copiarENbd">Determinar si copiar dicho fichero en base de datos.</param>
        public OFichero(string identificador, Extension extension, bool copiarENdisco, bool copiarENbd)
        {
            this.identificador = identificador;
            this.extension = extension;
            this.copiarENdisco = copiarENdisco;
            this.copiarENbaseDEdatos = copiarENbd;
        }
        #endregion

        #region Destructores
        /// <summary>
        /// Indica si ya se llamo al m�todo Dispose. (default = false)
        /// </summary>
        bool disposed = false;
        /// <summary>
        /// Implementa IDisposable.
        /// No  hacer  este  m�todo  virtual.
        /// Una clase derivada no deber�a ser
        /// capaz de  reemplazar este m�todo.
        /// </summary>
        public void Dispose()
        {
            // Llamo al m�todo que  contiene la l�gica
            // para liberar los recursos de esta clase.
            Dispose(true);
            // Este objeto ser� limpiado por el m�todo Dispose.
            // Llama al m�todo del recolector de basura, GC.SuppressFinalize.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// M�todo  sobrecargado de  Dispose que ser�  el que
        /// libera los recursos. Controla que solo se ejecute
        /// dicha l�gica una  vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name="disposing">Indica si llama al m�todo Dispose.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Preguntar si Dispose ya fue llamado.
            if (!this.disposed)
            {
                // Finalizar correctamente los recursos no manejados.
                this.identificador = null;
                this.nombre = null;
                this.ruta = null;

                // Marcar como desechada � desechandose,
                // de forma que no se puede ejecutar el
                // c�digo dos veces.
                disposed = true;
            }
        }
        /// <summary>
        /// Destructor(es) de clase.
        /// En caso de que se nos olvide �desechar� la clase,
        /// el GC llamar� al destructor, que tamb�n ejecuta 
        /// la l�gica anterior para liberar los recursos.
        /// </summary>
        ~OFichero()
        {
            // Llamar a Dispose(false) es �ptimo en terminos
            // de legibilidad y mantenimiento.
            Dispose(false);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Identificador de fichero.
        /// </summary>
        public string Identificador
        {
            get { return this.identificador; }
            set { this.identificador = value; }
        }
        /// <summary>
        /// Nombre de fichero.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        /// <summary>
        /// Ruta de fichero.
        /// </summary>
        public string Ruta
        {
            get { return this.ruta; }
            set { this.ruta = value; }
        }
        /// <summary>
        /// Ruta completa de fichero. Ruta + nombre.
        /// </summary>
        public string RutaCompleta
        {
            get { return string.Format(CultureInfo.CurrentCulture, @"{0}\{1}", this.ruta, this.nombre); }
        }
        /// <summary>
        /// Copiar en disco.
        /// </summary>
        public bool CopiarENdisco
        {
            get { return this.copiarENdisco; }
            set { this.copiarENdisco = value; }
        }
        /// <summary>
        /// Copiar en base de datos.
        /// </summary>
        public bool CopiarENbaseDEdatos
        {
            get { return this.copiarENbaseDEdatos; }
            set { this.copiarENbaseDEdatos = value; }
        }
        /// <summary>
        /// Comprueba la existencia de los directorios
        /// y subdirectorios donde guardar el fichero.
        /// </summary>
        /// <param name="identificador">Identificador del
        /// dispositivo.</param>
        /// <param name="directorio">Directorio origen.</param> 
        /// <returns>Ruta destino del stream.</returns>
        public string this[string identificador, string directorio]
        {
            get
            {
                // Asignar la fecha en el formato adecuado.
                DateTime fecha = DateTime.Now;
                // Fecha en formato yyyymmdd : 8 d�gitos.
                string subdirectorio = string.Concat(
                    fecha.Year.ToString("0000", CultureInfo.CurrentCulture),
                        fecha.Month.ToString("00", CultureInfo.CurrentCulture),
                            fecha.Day.ToString("00", CultureInfo.CurrentCulture));
                // Cada fichero se va a insertar en su correspondiente subdirectorio
                // que hace referencia a la fecha en cuesti�n de lectura.
                string ruta = string.Format(CultureInfo.CurrentCulture, @"{0}\{1}\{2}", Application.StartupPath, directorio, subdirectorio);

                if (!System.IO.Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                string fichero = string.Format(CultureInfo.CurrentCulture, @"{0}{1}{2}{3}{4}.{5}",
                    identificador, fecha.Hour.ToString("00", CultureInfo.CurrentCulture),
                        fecha.Minute.ToString("00", CultureInfo.CurrentCulture),
                            fecha.Second.ToString("00", CultureInfo.CurrentCulture),
                                fecha.Millisecond.ToString("000", CultureInfo.CurrentCulture),
                                    Enum.GetName(typeof(Extension), this.extension));

                // Nombre del fichero en formato:
                // dispositivo : 2 d�gitos.
                // hhmmssfff : 9 d�gitos.
                this.nombre = fichero;
                // Identificador de dispositivo + Hora en formato hhmmssfff : 9 d�gitos.
                this.ruta = ruta;
                return string.Format(CultureInfo.CurrentCulture, @"{0}\{1}", ruta, fichero);
            }
        }
        #endregion
    }
}