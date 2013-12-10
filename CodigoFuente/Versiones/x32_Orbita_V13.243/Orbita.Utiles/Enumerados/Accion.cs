namespace Orbita.Utiles
{
    /// <summary>
    /// Enumeración que representa las acciones
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