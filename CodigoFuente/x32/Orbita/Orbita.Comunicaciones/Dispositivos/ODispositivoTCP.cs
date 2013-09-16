using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
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
        #region Atributos
        /// <summary>
        /// Atributo que indica las  colecciones
        /// de tags de datos, lecturas y alarmas.
        /// </summary>
        private readonly OTags _tags;
        /// <summary>
        /// Colección de hilos.
        /// </summary>
        private static OHilos _hilos;
        /// <summary>
        /// Datos de configuración del canal
        /// </summary>
        private readonly OConfigDispositivo _configuracionDispositivo;
        /// <summary>
        /// Argumentos para generar los eventos
        /// </summary>
        private readonly OEventArgs _eventArgs;
        /// <summary>
        /// Indica si las variables han sido iniciadas
        /// </summary>
        private bool _inicioVariables;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ODispositivoTCP.
        /// </summary>
        public ODispositivoTCP(OTags tags, OHilos hilos, ODispositivo dispositivo)
        {
            Wrapper.Info("Creando dispositivo ODispositivoTCP...");
            try
            {
                // Asignación de las colecciones de datos, lecturas y alarmas.
                this._tags = tags;
                this._configuracionDispositivo = tags.Config;
                this._eventArgs = new OEventArgs();

                // Actualizando las variables de dispositivo.
                this.Identificador = dispositivo.Identificador;
                this.Nombre = dispositivo.Nombre;
                this.Tipo = dispositivo.Tipo;
                this.Direccion = dispositivo.Direccion;
                this.Local = dispositivo.Local;
                _hilos = hilos;
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoTCP [ODispositivoTCP]: ", ex);
                throw;
            }
        }
        #endregion Constructor

        #region Propiedades
        /// <summary>
        /// Colección de datos.
        /// </summary>
        private OHashtable Datos
        {
            get { return this._tags.GetDatos(); }
        }
        /// <summary>
        /// Colección de alarmas activas.
        /// </summary>
        private ArrayList AlarmasActivas
        {
            get { return this._tags.GetAlarmasActivas(); }
        }
        #endregion Propiedades

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
        /// Inicia los valores por defecto en las variables del dispositivo.
        /// </summary>
        private void IniciarValores()
        {
            var variables = new string[this.Datos.Count];
            var valores = new object[this.Datos.Count];
            int i = 0;
            foreach (OInfoDato dato in from DictionaryEntry item in this.GetDatos() select (OInfoDato)item.Value)
            {
                variables[i] = dato.Texto;
                valores[i] = dato.ValorDefecto;
                i++;
            }
            Escribir(variables, valores);
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
                        resultado[i] = this._tags.GetDB(variables[i]).Valor;
                    }
                }
            }
            catch (Exception ex)
            {
                Wrapper.Fatal("ODispositivoTCP [Leer]: ", ex);
                throw;
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
        /// <param name="canal"></param>
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
                            Wrapper.Info("ODispositivoTCP [Escribir] Escritura: " + infoDBdato.Texto + " valor: " + infoDBdato.Valor);
                            switch ((TiposVariables)Enum.Parse(typeof(TiposVariables), infoDBdato.Tipo.ToUpper()))
                            {
                                case TiposVariables.STRING:
                                case TiposVariables.INT:
                                case TiposVariables.REAL:
                                case TiposVariables.X:
                                    if (infoDBdato.Valor != null && infoDBdato.UltimoValor != null)
                                    {
                                        if (infoDBdato.UltimoValor.ToString() != infoDBdato.Valor.ToString())
                                        {
                                            this.OnCambioDato(new OEventArgs(infoDBdato));
                                            Wrapper.Info("ODispositivoTCP [Escribir] CambioDato: " + infoDBdato.Texto + " valor: " + infoDBdato.Valor);
                                        }
                                    }
                                    break;
                                case TiposVariables.OBJECT:
                                    if (infoDBdato.UltimoValor != infoDBdato.Valor)
                                    {
                                        this.OnCambioDato(new OEventArgs(infoDBdato));
                                        Wrapper.Info("ODispositivoTCP [Escribir] CambioDato: " + infoDBdato.Texto + " valor: " + infoDBdato.Valor);
                                    }
                                    break;
                            }

                        }
                        if (this._tags.GetAlarmas(infoDBdato.Identificador) == null) continue;
                        try
                        {
                            if (infoDBdato.Valor == null || infoDBdato.UltimoValor == null) continue;
                            var ultimoValor = infoDBdato.UltimoValor.ToString();
                            var valor = infoDBdato.Valor.ToString();
                            if (ultimoValor.Equals(valor)) continue;

                            // Elevar el evento Alarma.
                            OnAlarma(new OEventArgs(infoDBdato));
                            bool valorX;
                            if (!bool.TryParse(valor, out valorX)) continue;
                            if (valorX)
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
                        catch (Exception ex)
                        {
                            if (this._inicioVariables)
                            {
                                Wrapper.Fatal("ODispositivoTCP [Escribir] Error al escribir la alarma: ", ex);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string vars = "";
                string dispositivo = this.Nombre;
                try
                {
                    vars = variables.Aggregate(vars, (current, t) => current + "#" + t.ToString(CultureInfo.CurrentCulture));
                }
                catch (Exception)
                {
                    vars = "";
                    dispositivo = "";
                }
                resultado = false;
                Wrapper.Fatal("ODispositivoTCP [Escribir] Error en la escritura de variables en dispositivo " + dispositivo + " con variables " + vars + " " + ex);
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
            _tags.Dispose();
            _hilos.Destruir();
        }
        #endregion Métodos públicos

        #region Métodos privados
        /// <summary>
        /// Inicia hilo de vida.
        /// </summary>
        private void InicHiloVida()
        {
            // Crear el objeto Hilo e iniciarlo. El parámetro iniciar indica
            // a la colección que una vez añadido el hilo se iniciado.
            _hilos.Add(new ThreadStart(ProcesarHiloVida), true);
        }
        /// <summary>
        /// Proceso del hilo de vida.
        /// </summary>
        private void ProcesarHiloVida()
        {
            var estado = new OEstadoComms();
            while (true)
            {
                try
                {
                    estado.Estado = "OK";
                    estado.Nombre = this.Nombre;
                    estado.Id = this.Identificador;
                    this._eventArgs.Argumento = estado;
                    TimeSpan ts = DateTime.Now.Subtract(this.FechaUltimoEventoComm);
                    if (ts.TotalSeconds > (double)this._configuracionDispositivo.SegEventoComs)
                    {
                        this.OnComm(this._eventArgs);
                        this.FechaUltimoEventoComm = DateTime.Now;
                    }

                    Thread.Sleep(this._configuracionDispositivo.TiempoVida);
                }
                catch (ThreadAbortException)
                {
                }
                catch (Exception ex)
                {
                    Wrapper.Fatal("ODispositivoTCP [ProcesarHiloVida]: ", ex);
                }
            }
        }
        #endregion Métodos privados
    }

    /// <summary>
    /// Tipos de variables.
    /// </summary>
    public enum TiposVariables
    {
        X,
        REAL,
        INT,
        DINT,
        W,
        DWORD,
        CHAR,
        STRING,
        B,
        DT,
        OBJECT
    }
}