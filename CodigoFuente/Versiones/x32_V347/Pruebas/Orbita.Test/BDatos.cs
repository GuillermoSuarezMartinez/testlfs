using Orbita.BBDD;
namespace Orbita.Controles.Test
{
    public static class BDatos
    {
        #region Atributo(s)

        #region Estático(s)

        /// <summary>
        /// Nombre de la instancia de base de datos.
        /// </summary>
        static string Instancia = @"01x0030";
        /// <summary>
        /// Nombre de la base de datos.
        /// </summary>
        static string BaseDatos = "OrbitaGestionPreProd";
        /// <summary>
        /// Usuario de autenticación de base de datos.
        /// </summary>
        static string Usuario = "desarrollo";
        /// <summary>
        /// Password de autenticación de base de datos.
        /// </summary>
        static string Password = "orbita";

        /// <summary>
        /// Atributo estático compartido por todas las
        /// instancias  de   la  clase  que  indica la
        /// información de la conexión activa.
        /// 
        /// Asignar los atributos del objeto en función
        /// de los valores de app.config  del  proyecto.
        /// </summary>
        static OInfoConexion InfoConexion = new OInfoConexion(Instancia, BaseDatos, Usuario, Password);

        // La construcción del atributo estático de esta
        // forma evita tener constructor en una clase de
        // tipo estático, así no infringe la regla:
        // CA1053: Los tipos titulares estáticos no deben 
        // tener constructores.

        #endregion

        #endregion

        #region Métodos públicos

        /// <summary>
        /// Nombre de la base de datos referenciada.
        /// </summary>
        public static OSqlServer Bd
        {
            get { return (new OSqlServer(InfoConexion)); }
        }

        #endregion
    }
}
