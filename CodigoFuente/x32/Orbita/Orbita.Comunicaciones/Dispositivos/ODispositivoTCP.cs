using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Security.Permissions;
using System.Threading;
using Orbita.Utiles;
namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Dispositivo TCP de Orbita
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "El origen del nombre abreviado.")]
    [Serializable]
    public class ODispositivoTCP : ODispositivo
    {
        #region Atributos privados
        /// <summary>
        /// Atributo que indica las  colecciones
        /// de tags de datos, lecturas y alarmas.
        /// </summary>
        OTags _tags;
        /// <summary>
        /// Colección de hilos.
        /// </summary>
        static OHilos Hilos;
        /// <summary>
        /// Datos de configuración del canal
        /// </summary>
        OConfigDispositivo _config;
        /// <summary>
        /// Argumentos para generar los eventos
        /// </summary>
        OEventArgs _oEventargs;
        /// <summary>
        /// Indica si las variables han sido iniciadas
        /// </summary>
        private bool _inicioVariables = false;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase SiemensOPC.
        /// </summary>
        public ODispositivoTCP(OTags tags, OHilos hilos, ODispositivo dispositivo)
        {
            wrapper.Info("Creando dispositivo ODispositivoTCP");
            try
            {
                // Asignación de las colecciones de datos, lecturas y alarmas.
                this._tags = tags;
                this._config = tags.Config;
                this._oEventargs = new OEventArgs();
                //Actualizando las variables de dispositivo
                this.Identificador = dispositivo.Identificador;
                this.Nombre = dispositivo.Nombre;
                this.Tipo = dispositivo.Tipo;
                this.Direccion = dispositivo.Direccion;
                this.Local = dispositivo.Local;
                Hilos = hilos;
            }
            catch (Exception ex)
            {
                wrapper.Error("Error en ODispositivoTCP. ", ex);
                throw ex;
            }
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Colección de datos.
        /// </summary>
        private OHashtable Datos
        {
            get { return this._tags.GetDatos(); }
        }
        /// <summary>
        /// Colección de lecturas.
        /// </summary>
        private OHashtable Lecturas
        {
            get { return this._tags.GetLecturas(); }
        }
        /// <summary>
        /// Colección de alarmas.
        /// </summary>
        private OHashtable Alarmas
        {
            get { return this._tags.GetAlarmas(); }
        }
        /// <summary>
        /// Colección de alarmas activas.
        /// </summary>
        private ArrayList AlarmasActivas
        {
            get { return this._tags.GetAlarmasActivas(); }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Inicializar grupos, punteros e items.
        /// </summary>
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public override void Iniciar()
        {
            this.IniciarValores();
            this.InicHiloVida();
        }
        /// <summary>
        /// Inicia los valores por defecto en las variables del dispositivo
        /// </summary>
        private void IniciarValores()
        {
            string[] variables;
            object[] valores;

            variables = new string[this.Datos.Count];
            valores = new string[this.Datos.Count];
            int i=0;
            foreach (DictionaryEntry item in this.GetDatos())
            {
                OInfoDato dato = (OInfoDato)item.Value;
                variables[i] = dato.Texto;
                valores[i] = dato.ValorDefecto;
                i++;
            }

            this.Escribir(variables, valores);

            this._inicioVariables = true;

        }
        /// <summary>
        /// Leer el valor de las descripciones de variables de la colección
        /// a partir del valor de la colección de datos DB actualiza  en el
        /// proceso del hilo vida.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="demanda">Indica si la lectura se ejecuta sobre el dispositivo</param>
        /// <returns>Colección de resultados.</returns>
        public override object[] Leer(string[] variables, bool demanda)
        {
            object[] resultado = null;

            try
            {
                if (variables != null)
                {
                    // Inicializar contador de variables.
                    int contador = variables.Length;

                    // Asignar a la colección resultado el número
                    // de variables de la colección de variables.
                    resultado = new object[contador];
                    for (int i = 0; i < contador; i++)
                    {
                        object res = this._tags.GetDB(variables[i]).Valor;
                        resultado[i] = res;
                    }
                }
            }
            catch (Exception ex)
            {
                wrapper.Fatal("OdispositivoTCP Leer[]: ", ex);
                throw ex;
            }
            return resultado;
        }
        /// <summary>
        /// Escribir el valor de los identificadores de variables de la colección.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <returns></returns>
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public override bool Escribir(string[] variables, object[] valores)
        {
            return this.Escribir(variables, valores, string.Empty);
        }
        /// <summary>
        /// Escribir el valor de los identificadores de variables de la colección.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <returns></returns>
        public override bool Escribir(string[] variables, object[] valores, string canal)
        {
            bool resultado = true;
            try
            {
                if (variables != null)
                {
                    // Inicializar contador de variables.
                    int contador = variables.Length;

                    for (int i = 0; i < contador; i++)
                    {
                        OInfoDato infoDBdato = this._tags.GetDB(variables[i]);
                        infoDBdato.UltimoValor = infoDBdato.Valor;
                        infoDBdato.Valor = valores[i];
                        infoDBdato.CanalCambioDato = canal;

                        if (this._tags.GetLecturas(infoDBdato.Identificador) != null)
                        {
                            if (infoDBdato.UltimoValor != infoDBdato.Valor)
                            {
                                this.OnCambioDato(new OEventArgs(infoDBdato));
                            }
                        }
                        if (this._tags.GetAlarmas(infoDBdato.Identificador) != null)
                        {
                            try
                            {
                                if (infoDBdato.UltimoValor != infoDBdato.Valor)
                                {
                                    this.OnAlarma(new OEventArgs(infoDBdato));
                                    if (Convert.ToInt16(infoDBdato.Valor) == 1)
                                    {
                                        if (!AlarmasActivas.Contains(infoDBdato.Texto))
                                        {
                                            this.AlarmasActivas.Add(infoDBdato.Texto);
                                        }
                                    }
                                    else
                                    {
                                        if (AlarmasActivas.Contains(infoDBdato.Texto))
                                        {
                                            this.AlarmasActivas.Remove(infoDBdato.Texto);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                if (this._inicioVariables)
                                {
                                    wrapper.Fatal("ODispositivoTCP Escribir Error al escribir la alarma: ", ex);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string vars = "";
                string disp = this.Nombre;

                try
                {
                    for (int i = 0; i < variables.Length; i++)
                    {
                        vars = vars + "#" + variables[i].ToString();
                    }
                }
                catch (Exception)
                {
                    vars = "";
                    disp = "";
                }
                resultado = false;
                wrapper.Fatal("ODispositivoTCP Escribir Error en la escritura de variables en dispositivo " +
                    disp.ToString() + " con variables " + vars + " " + ex.ToString());
            }

            return resultado;
        }
        /// <summary>
        /// Devuelva las alarmas alctivas del sistemas
        /// </summary>
        /// <returns></returns>
        public override ArrayList GetAlarmasActivas()
        {
            return this._tags.GetAlarmasActivas();
        }
        /// <summary>
        /// Devuelve los datos del dipositivo y su valor
        /// </summary>
        /// <returns></returns>
        public override OHashtable GetDatos()
        {
            return this._tags.GetDatos();
        }
        /// <summary>
        /// Devuelve las lectuas del dipositivo y su valor
        /// </summary>
        /// <returns></returns>
        public override OHashtable GetLecturas()
        {
            return this._tags.GetLecturas();
        }
        /// <summary>
        /// Devuelve las alarmas del dipositivo y su valor
        /// </summary>
        /// <returns></returns>
        public override OHashtable GetAlarmas()
        {
            return this._tags.GetAlarmas();
        }
        /// <summary>
        /// Limpia los objetos en memoria
        /// </summary>
        /// <param name="disposing"></param>
        public override void Dispose(bool disposing)
        {
            this._tags.Dispose();
            Hilos.Destruir();
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicia hilo de vida.
        /// </summary>
        private void InicHiloVida()
        {
            // Crear el objeto Hilo e iniciarlo. El parámetro iniciar indica
            // a la colección que una vez añadido el hilo se iniciado.
            Hilos.Add(new ThreadStart(ProcesarHiloVida), true);
        }
        /// <summary>
        /// Proceso del hilo de vida.
        /// </summary>
        private void ProcesarHiloVida()
        {
            OInfoOPCvida infoVida = (OInfoOPCvida)this._tags.HtVida;
            OEstadoComms estado = new OEstadoComms();
            TimeSpan ts;
            while (true)
            {
                try
                {
                    estado.Estado = "OK";
                    estado.Nombre = this.Nombre;
                    estado.Id = this.Identificador;
                    this._oEventargs.Argumento = estado;
                    ts = DateTime.Now.Subtract(this._fechaUltimoEventoComs);
                    if (ts.TotalSeconds>(double)this._config.SegEventoComs)
                    {
                        this.OnComm(this._oEventargs);
                        this._fechaUltimoEventoComs = DateTime.Now;
                    }
                    
                    Thread.Sleep(this._config.TiempoVida);
                }
                catch (ThreadAbortException)
                {
                }
                catch (Exception ex)
                {
                    wrapper.Fatal("ODispositivoTCP ProcesarHiloVida: ", ex);
                }

                
            }
        }
        #endregion
    }
}