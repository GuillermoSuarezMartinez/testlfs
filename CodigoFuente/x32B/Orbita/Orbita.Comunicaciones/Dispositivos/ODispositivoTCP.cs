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
            Wrapper.Info("Creando dispositivo [ODispositivoTCP]...");
            try
            {
                // Asignación de las colecciones de datos, lecturas y alarmas.
                _tags = tags;
                _configuracionDispositivo = tags.Config;
                _eventArgs = new OEventArgs();

                // Actualizando las variables de dispositivo.
                Identificador = dispositivo.Identificador;
                Nombre = dispositivo.Nombre;
                Tipo = dispositivo.Tipo;
                Direccion = dispositivo.Direccion;
                Local = dispositivo.Local;

                // Asignar colección de hilos.
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
            get { return _tags.GetDatos(); }
        }
        /// <summary>
        /// Colección de alarmas activas.
        /// </summary>
        private ArrayList AlarmasActivas
        {
            get { return _tags.GetAlarmasActivas(); }
        }
        #endregion Propiedades

        #region Métodos públicos
        /// <summary>
        /// Inicializar grupos, punteros e items.
        /// </summary>
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public override void Iniciar()
        {
            IniciarValores();
            InicializarHiloVida();
        }
        /// <summary>
        /// Inicia los valores por defecto en las variables del dispositivo.
        /// </summary>
        private void IniciarValores()
        {
            var cont = Datos.Count;
            var variables = new string[cont];
            var valores = new object[cont];
            int i = 0;
            foreach (OInfoDato dato in from DictionaryEntry item in GetDatos() select (OInfoDato)item.Value)
            {
                variables[i] = dato.Texto;
                valores[i] = dato.ValorDefecto;
                i++;
            }
            Escribir(variables, valores);
            _inicioVariables = true;
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
            string variable = string.Empty;
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
                        variable = variables[i];
                        resultado[i] = _tags.GetDB(variable).Valor;
                    }
                }
            }
            catch (Exception ex)
            {
                Wrapper.Fatal(string.Format("ODispositivoTCP [Leer] Variable= {0}; {1}", variable, ex));
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
            return Escribir(variables, valores, string.Empty);
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
                        OInfoDato infoDBdato = _tags.GetDB(variables[i]);
                        infoDBdato.UltimoValor = infoDBdato.Valor;
                        infoDBdato.Valor = valores[i];
                        infoDBdato.CanalCambioDato = canal;
                        if (_tags.GetLecturas(infoDBdato.Identificador) != null)
                        {
                            var ultimoValor = infoDBdato.UltimoValor == null ? string.Empty : infoDBdato.UltimoValor.ToString();
                            var valor = infoDBdato.Valor == null ? string.Empty : infoDBdato.Valor.ToString();
                            Wrapper.Info("ODispositivoTCP [Escribir] Variable=" + infoDBdato.Texto + "=" +
                                (infoDBdato.Valor == null || infoDBdato.Valor.ToString() == "" ? "empty" : infoDBdato.Valor) + " (" +
                                (infoDBdato.UltimoValor == null || infoDBdato.UltimoValor.ToString() == "" ? "empty" : infoDBdato.UltimoValor) + ")");

                            switch ((TiposVariables)Enum.Parse(typeof(TiposVariables), infoDBdato.Tipo.ToUpper()))
                            {
                                case TiposVariables.STRING:
                                case TiposVariables.INT:
                                case TiposVariables.REAL:
                                case TiposVariables.X:
                                    if (!ultimoValor.Equals(valor))
                                    {
                                        OnCambioDato(new OEventArgs(infoDBdato));
                                        Wrapper.Info("ODispositivoTCP [Escribir] Variable de cambio de dato=" + infoDBdato.Texto + "=" + (valor == "" ? "empty" : valor) + " (" + (ultimoValor == "" ? "empty" : ultimoValor) + ")");
                                    }
                                    break;
                                case TiposVariables.OBJECT:
                                    if (!ultimoValor.Equals(valor))
                                    {
                                        OnCambioDato(new OEventArgs(infoDBdato));
                                        Wrapper.Info("ODispositivoTCP [Escribir] [OBJECT] Variable de cambio de dato=" + infoDBdato.Texto + "=" + (valor == "" ? "empty" : valor) + " (" + (ultimoValor == "" ? "empty" : ultimoValor) + ")");
                                    }
                                    break;
                            }
                        }

                        if (_tags.GetAlarmas(infoDBdato.Identificador) == null) continue;
                        try
                        {
                            var ultimoValor = infoDBdato.UltimoValor == null ? string.Empty : infoDBdato.UltimoValor.ToString();
                            var valor = infoDBdato.Valor == null ? string.Empty : infoDBdato.Valor.ToString();

                            if (ultimoValor.Equals(valor)) continue;

                            // Elevar el evento Alarma.
                            OnAlarma(new OEventArgs(infoDBdato));
                            bool valorX;
                            if (!bool.TryParse(valor, out valorX)) continue;
                            if (valorX)
                            {
                                if (!AlarmasActivas.Contains(infoDBdato.Texto))
                                {
                                    AlarmasActivas.Add(infoDBdato.Texto);
                                }
                            }
                            else
                            {
                                if (AlarmasActivas.Contains(infoDBdato.Texto))
                                {
                                    AlarmasActivas.Remove(infoDBdato.Texto);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (_inicioVariables)
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
                string dispositivo = Nombre;
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
                Wrapper.Fatal("ODispositivoTCP [Escribir] Error en la escritura de variables en dispositivo= " + dispositivo + "; con variables= " + vars + "; " + ex);
            }
            return resultado;
        }
        /// <summary>
        /// Devuelva las alarmas alctivas del sistemas
        /// </summary>
        /// <returns></returns>
        public override ArrayList GetAlarmasActivas()
        {
            return _tags.GetAlarmasActivas();
        }
        /// <summary>
        /// Devuelve los datos del dipositivo y su valor
        /// </summary>
        /// <returns></returns>
        public override OHashtable GetDatos()
        {
            return _tags.GetDatos();
        }
        /// <summary>
        /// Devuelve las lectuas del dipositivo y su valor
        /// </summary>
        /// <returns></returns>
        public override OHashtable GetLecturas()
        {
            return _tags.GetLecturas();
        }
        /// <summary>
        /// Devuelve las alarmas del dipositivo y su valor
        /// </summary>
        /// <returns></returns>
        public override OHashtable GetAlarmas()
        {
            return _tags.GetAlarmas();
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
        /// Inicializar hilo de vida.
        /// </summary>
        private void InicializarHiloVida()
        {
            // Crear el objeto Hilo e iniciarlo. El parámetro iniciar indica
            // a la colección que una vez añadido el hilo se iniciado.
            _hilos.Add(ProcesarHiloVida, true);
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
                    estado.Nombre = Nombre;
                    estado.Id = Identificador;
                    _eventArgs.Argumento = estado;
                    TimeSpan ts = DateTime.Now.Subtract(FechaUltimoEventoComm);
                    if (ts.TotalSeconds > (double)_configuracionDispositivo.SegEventoComs)
                    {
                        OnComm(_eventArgs);
                        FechaUltimoEventoComm = DateTime.Now;
                    }

                    Thread.Sleep(_configuracionDispositivo.TiempoVida);
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
        /// <summary>
        /// Variable de tipo Bit.
        /// </summary>
        X,

        /// <summary>
        /// Variable de tipo Real.
        /// </summary>
        REAL,

        /// <summary>
        /// Variable de tipo Int32.
        /// </summary>
        INT,

        /// <summary>
        /// Variable de tipo Int64.
        /// </summary>
        DINT,

        /// <summary>
        /// Variable de tipo Word.
        /// </summary>
        W,

        /// <summary>
        /// Variable de tipo Doble Word.
        /// </summary>
        DWORD,

        /// <summary>
        /// Variable de tipo Char.
        /// </summary>
        CHAR,

        /// <summary>
        /// Variable de tipo String.
        /// </summary>
        STRING,

        /// <summary>
        /// Variable de tipo Byte.
        /// </summary>
        B,

        /// <summary>
        /// Variable de tipo Dt.
        /// </summary>
        DT,

        /// <summary>
        /// Variable de tipo Object.
        /// </summary>
        OBJECT
    }
}