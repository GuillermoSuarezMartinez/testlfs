namespace Orbita.Utiles
{
    /// <summary>
    /// Enumeraci�n que representa la sobrecarga del
    /// m�todo de tiempo restante de la clase OTimer.
    /// </summary>
    public enum Tiempo
    {
        /// <summary>
        /// Hora.
        /// </summary>
        Hora,
        /// <summary>
        /// Minuto.
        /// </summary>
        Minuto,
        /// <summary>
        /// Segundo.
        /// </summary>
        Segundo,
        /// <summary>
        /// Milisegundo.
        /// </summary>
        Milisegundo
    }
    /// <summary>
    /// Enumeraci�n que representa las posibles 
    /// extensiones que puede tener un fichero.
    /// </summary>
    public enum Extension
    {
        /// <summary>
        /// Extensi�n .XML.
        /// </summary>
        Xml = 0,
        /// <summary>
        /// Extensi�n .JPG.
        /// </summary>
        Jpg = 1,
    }
    /// <summary>
    /// Enumeraci�n que representa las acciones
    /// propias correspondientes a hilos.
    /// </summary>
    public enum Accion
    {
        /// <summary>
        /// Hilo inicializado.
        /// </summary>
        Inicializado,
        /// <summary>
        /// Hilo iniciado.
        /// </summary>
        Iniciado,
        /// <summary>
        /// Hilo suspendido.
        /// </summary>
        Suspendido,
        /// <summary>
        /// Hilo reanudado.
        /// </summary>
        Reanudado,
        /// <summary>
        /// Hilo terminado.
        /// </summary>
        Terminado,
        /// <summary>
        /// Join.
        /// </summary>
        EnEspera
    }
}

