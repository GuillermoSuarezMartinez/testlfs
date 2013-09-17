//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 04-03-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Orbita.Utiles;
using Orbita.VA.Comun;
using Orbita.VA.MaquinasEstados;

namespace Orbita.Controles.VA
{
    /// <summary>
    /// Formulario para la monitorización de variables
    /// </summary>
    public partial class CtrlMonitorizacionVariablesTactil : OrbitaCtrlTactilBase
    {
        #region Constante(s)
        /// <summary>
        /// Intervalo entre muestreo
        /// </summary>
        private const int CadenciaMonitorizacionMs = 100;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Momento en el que se produjo el último refresco de las variables
        /// </summary>
        private DateTime MomentoUltimoRefresco;

        /// <summary>
        /// Código del escenario actual
        /// </summary>
        private string CodEscenarioActual;

        /// <summary>
        /// Listado de las variables que se están visualizando actualmente
        /// </summary>
        private List<string> ListaCodVariablesActuales;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la calse
        /// </summary>
        public CtrlMonitorizacionVariablesTactil(string codigo, Control contenedor = null) :
            base(ModoAperturaFormulario.Monitorizacion, codigo, "Monitor de las variables del sistema", contenedor)
        {
            InitializeComponent();

            this.ImageListLarge.Images.Add("imgVariableInactiva", global::Orbita.Controles.VA.Properties.Resources.ImgBit0Tactil32);
            this.ImageListLarge.Images.Add("imgVariableInactivaForzada", global::Orbita.Controles.VA.Properties.Resources.ImgBit0LockTactil32);
            this.ImageListLarge.Images.Add("imgVariableActiva", global::Orbita.Controles.VA.Properties.Resources.ImgBit1Tactil32);
            this.ImageListLarge.Images.Add("imgVariableActivaForzada", global::Orbita.Controles.VA.Properties.Resources.ImgBit1LockTactil32);
            this.ImageListLarge.Images.Add("imgTexto", global::Orbita.Controles.VA.Properties.Resources.ImgTextoTactil32);
            this.ImageListLarge.Images.Add("imgTextoForzada", global::Orbita.Controles.VA.Properties.Resources.ImgTextoLockTactil32);
            this.ImageListLarge.Images.Add("imgNumero", global::Orbita.Controles.VA.Properties.Resources.ImgNumeroTactil32);
            this.ImageListLarge.Images.Add("imgNumeroForzada", global::Orbita.Controles.VA.Properties.Resources.ImgNumeroLockTactil32);
            this.ImageListLarge.Images.Add("imgFoto", global::Orbita.Controles.VA.Properties.Resources.ImgImagenTactil32);
            this.ImageListLarge.Images.Add("imgFotoForzada", global::Orbita.Controles.VA.Properties.Resources.ImgImagenLockTactil32);

            this.ImageListSmall.Images.Add("imgVariableInactiva", global::Orbita.Controles.VA.Properties.Resources.ImgBit0Tactil32);
            this.ImageListSmall.Images.Add("imgVariableInactivaForzada", global::Orbita.Controles.VA.Properties.Resources.ImgBit0LockTactil32);
            this.ImageListSmall.Images.Add("imgVariableActiva", global::Orbita.Controles.VA.Properties.Resources.ImgBit1Tactil32);
            this.ImageListSmall.Images.Add("imgVariableActivaForzada", global::Orbita.Controles.VA.Properties.Resources.ImgBit1LockTactil32);
            this.ImageListSmall.Images.Add("imgTexto", global::Orbita.Controles.VA.Properties.Resources.ImgTextoTactil32);
            this.ImageListSmall.Images.Add("imgTextoForzada", global::Orbita.Controles.VA.Properties.Resources.ImgTextoLockTactil32);
            this.ImageListSmall.Images.Add("imgNumero", global::Orbita.Controles.VA.Properties.Resources.ImgNumeroTactil32);
            this.ImageListSmall.Images.Add("imgNumeroForzada", global::Orbita.Controles.VA.Properties.Resources.ImgNumeroLockTactil32);
            this.ImageListSmall.Images.Add("imgFoto", global::Orbita.Controles.VA.Properties.Resources.ImgImagenTactil32);
            this.ImageListSmall.Images.Add("imgFotoForzada", global::Orbita.Controles.VA.Properties.Resources.ImgImagenLockTactil32);

            // Inicialización de las variables
            this.CodEscenarioActual = string.Empty;
            this.ListaCodVariablesActuales = new List<string>();

            // Rellenamos el menú de escenarios
            PopupMenuTool menuEscenarios = (PopupMenuTool)this.ToolbarsManager.Tools["Escenarios"];
            menuEscenarios.SharedProps.Visible = OSistemaManager.IntegraMaquinaEstados;
            if (OSistemaManager.IntegraMaquinaEstados)
            {
                // Menu de todos los escenarios
                ButtonTool btnEscenarioTodos = new ButtonTool("Todos");
                btnEscenarioTodos.SharedProps.Caption = "Todos";
                btnEscenarioTodos.ToolClick += EscenarioClick;
                this.ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] { btnEscenarioTodos });
                menuEscenarios.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] { btnEscenarioTodos });

                // Menu de cada escenario
                DataTable dt = global::Orbita.VA.Comun.AppBD.GetEscenarios();
                foreach (DataRow dr in dt.Rows)
                {
                    string codEscenario = dr["CodEscenario"].ToString();
                    string nombreEscenario = dr["NombreEscenario"].ToString();
                    ButtonTool btnVista = new ButtonTool(codEscenario);
                    btnVista.SharedProps.Caption = nombreEscenario;
                    btnVista.ToolClick += EscenarioClick;
                    this.ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] { btnVista });
                    menuEscenarios.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] { btnVista });
                }
            }
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Carga y muestra datos del formulario comunes para los tres modos de funcionamiento
        /// </summary>
        protected override void CargarDatosComunes()
        {
            base.CargarDatosComunes();

            // Inicializamos el timer de refresco
            this.MomentoUltimoRefresco = DateTime.Now;
            this.TimerRefresco.Interval = CadenciaMonitorizacionMs;
        }
        /// <summary>
        /// Carga y muestra datos del formulario en modo nuevo. Se cargan todos datos que se muestran en 
        /// el formulario: grids, combos, etc... Cada carga de elementos estará encapsulada en un método
        /// </summary>
        protected override void CargarDatosModoMonitorizacion()
        {
            base.CargarDatosModoMonitorizacion();

            this.CrearItems();
        }
        /// <summary>
        /// Establece la habiliacion adecuada de los controles para el modo visualizacion
        /// </summary>
        protected override void EstablecerModoMonitorizacion()
        {
            base.EstablecerModoMonitorizacion();
        }
        /// <summary>
        ///  Funciones a realizar al salir del formulario
        /// </summary>
        protected override void AccionesSalir()
        {
            base.AccionesSalir();

            this.TimerRefresco.Enabled = false;
            this.DestruirItems();
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Crea los items de las variables
        /// </summary>
        private void CrearItems()
        {
            // Creamos la lista de variables
            if (this.CodEscenarioActual == string.Empty)
            {
                // Todas las variables
                foreach (OVariable variable in OVariablesManager.ListaVariables.Values)
                {
                    this.ListaCodVariablesActuales.Add(variable.Codigo);
                }
            }
            else
            {
                // Variables de una vista
                OEscenarioVariable OEscenarioVariable = OVariablesManager.Escenarios[this.CodEscenarioActual]; // Extraigo la vista acutal
                foreach (KeyValuePair<string, string> aliasPair in OEscenarioVariable.ListaAlias) // Para cada alias
                {
                    this.ListaCodVariablesActuales.Add(aliasPair.Value); // Guardo el código de la variable al que hace referencia
                }
            }

            foreach (string codVariable in this.ListaCodVariablesActuales)
            {
                OVariable variable = OVariablesManager.GetVariable(codVariable);
                this.CrearItem(variable);

                switch (variable.Tipo)
                {
                    case OEnumTipoDato.Bit:
                    case OEnumTipoDato.Entero:
                    case OEnumTipoDato.Texto:
                    case OEnumTipoDato.Decimal:
                    case OEnumTipoDato.Fecha:
                        OVariablesManager.CrearSuscripcion(variable.Codigo, "Monitorización", this.Name, this.EventoRefrescarVariables);
                        break;
                }
            }
        }

        /// <summary>
        /// Destruye los items de todas las variables
        /// </summary>
        private void DestruirItems()
        {
            foreach (string codVariable in this.ListaCodVariablesActuales)
            {
                OVariablesManager.EliminarSuscripcion(codVariable, "Monitorización", this.Name, this.EventoRefrescarVariables);
            }

            this.ListaCodVariablesActuales.Clear();
            this.ListView.Items.Clear();
        }

        /// <summary>
        /// Dibuja un item en la lista de variables
        /// </summary>
        /// <param name="variable">Variable a visualizar</param>
        private void CrearItem(OVariable variable)
        {
            string codigo = variable.Codigo.ToString();
            string descripcion = variable.Descripcion.ToString();
            string grupo = variable.Grupo.ToString();
            string momentoUltimaActualizacion = variable.GetMomentoUltimaActualizacion().ToString();

            ListViewItem item = new ListViewItem();

            item.Name = codigo;
            item.Text = codigo;
            item.ToolTipText = descripcion;
            item.Tag = variable;

            if (grupo != string.Empty)
            {
                if (this.ListView.Groups[grupo] == null)
                {
                    item.Group = this.ListView.Groups.Add(grupo, grupo);
                }
                else
                {
                    item.Group = this.ListView.Groups[grupo];
                }
            }

            ListViewItem.ListViewSubItem subItemValor = new ListViewItem.ListViewSubItem();
            subItemValor.Name = "Valor";
            item.SubItems.Add(subItemValor);
            this.PintarItem(codigo, variable.GetValor(), item);

            ListViewItem.ListViewSubItem subItemDescVariable = new ListViewItem.ListViewSubItem();
            subItemDescVariable.Name = "DescVariable";
            subItemDescVariable.Text = descripcion;
            item.SubItems.Add(subItemDescVariable);

            ListViewItem.ListViewSubItem subItemMomentoUltimaActualizacion = new ListViewItem.ListViewSubItem();
            subItemMomentoUltimaActualizacion.Name = "MomentoUltimaActualizacion";
            subItemMomentoUltimaActualizacion.Text = momentoUltimaActualizacion;
            item.SubItems.Add(subItemMomentoUltimaActualizacion);

            this.ListView.Items.Add(item);
        }

        /// <summary>
        /// Extrae el valor del objeto para visualizarlo en la lista
        /// </summary>
        /// <param name="valor">Valor de la variable</param>
        /// <param name="activo">Resultado de tipo bool que indica si la variable está activa o desactiva</param>
        /// <param name="textoValor">Resultado de tipo texto que informa del valor de la variable</param>
        private void ExtraerValorVariable(object valor, ref bool activo, ref string textoValor)
        {
            activo = false;
            textoValor = string.Empty;
            if (valor != null)
            {
                textoValor = valor.ToString();
                //activo = OBooleano.Validar(valor, false);
                activo = false;
                if ((valor is bool) || (valor is string) || (OEntero.EsEntero(valor)))
                {
                    activo = OBooleano.Validar(valor, false);
                }
            }
        }

        /// <summary>
        /// Visualiza el valor del item
        /// </summary>
        /// <param name="codigo">código de la variable</param>
        /// <param name="valor">valor genérico de la variable</param>
        /// <param name="item">item del componente listview</param>
        private void PintarItem(string codigo, object valor, ListViewItem item)
        {
            string textoValor = string.Empty;
            bool verdadero = false;
            this.ExtraerValorVariable(valor, ref verdadero, ref textoValor);
            OVariable variable = (OVariable)item.Tag;
            bool bloqueado = variable.Bloqueado;

            item.SubItems["Valor"].Text = textoValor;

            OEnumTipoDato tipo = variable.Tipo;
            switch (tipo)
            {
                case OEnumTipoDato.SinDefinir:
                case OEnumTipoDato.Flag:
                case OEnumTipoDato.Bit:
                    if (verdadero && !bloqueado)
                    {
                        item.ImageKey = "imgVariableActiva";
                    }
                    else if (!verdadero && !bloqueado)
                    {
                        item.ImageKey = "imgVariableInactiva";
                    }
                    else if (verdadero && bloqueado)
                    {
                        item.ImageKey = "imgVariableActivaForzada";
                    }
                    else if (!verdadero && bloqueado)
                    {
                        item.ImageKey = "imgVariableInactivaForzada";
                    }
                    break;
                case OEnumTipoDato.Entero:
                case OEnumTipoDato.Decimal:
                case OEnumTipoDato.Fecha:
                    if (bloqueado)
                    {
                        item.ImageKey = "imgNumeroForzada";
                    }
                    else
                    {
                        item.ImageKey = "imgNumero";
                    }
                    break;
                case OEnumTipoDato.Texto:
                    if (bloqueado)
                    {
                        item.ImageKey = "imgTextoForzada";
                    }
                    else
                    {
                        item.ImageKey = "imgTexto";
                    }
                    break;
                case OEnumTipoDato.Imagen:
                case OEnumTipoDato.Grafico:
                    if (bloqueado)
                    {
                        item.ImageKey = "imgFotoForzada";
                    }
                    else
                    {
                        item.ImageKey = "imgFoto";
                    }
                    break;
            }
        }

        /// <summary>
        /// Fuerza el valor de una variable
        /// </summary>
        /// <param name="variable"></param>
        private void ForzarValor(OVariable variable)
        {
            if (variable.Bloqueado)
            {
                object objValor = variable.GetValor();
                switch (variable.Tipo)
                {
                    case OEnumTipoDato.Entero:
                        InputIntegerBox.Show(variable.Codigo, "Forzado de número entero", "Escriba el nuevo valor de la variable " + variable.Codigo, objValor.ValidarEntero(), this.EnteroImputadoPorUsuario);
                        break;
                    case OEnumTipoDato.Texto:
                        InputTextBox.Show(variable.Codigo, "Forzado de texto", "Escriba el nuevo valor de la variable " + variable.Codigo, OObjeto.ToString(objValor), this.TextoImputadoPorUsuario);
                        break;
                    case OEnumTipoDato.Decimal:
                        InputDoubleBox.Show(variable.Codigo, "Forzado de número real", "Escriba el nuevo valor de la variable " + variable.Codigo, objValor.ValidarDecimal(), this.DecimalImputadoPorUsuario);
                        break;
                    case OEnumTipoDato.Fecha:
                        break;
                }
            }
        }

        /// <summary>
        /// Se lanza cuando el usuario imputa el número de una variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnteroImputadoPorUsuario(object sender, EventArgsInput e)
        {
            try
            {
                OVariablesManager.ForzarValor(e.Codigo, (int)e.ObjetoImputado, "Monitorizacion", this.Name);
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }

        /// <summary>
        /// Se lanza cuando el usuario imputa el texto de una variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextoImputadoPorUsuario(object sender, EventArgsInput e)
        {
            try
            {
                OVariablesManager.ForzarValor(e.Codigo, (string)e.ObjetoImputado, "Monitorizacion", this.Name);
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }

        /// <summary>
        /// Se lanza cuando el usuario imputa el número de una variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecimalImputadoPorUsuario(object sender, EventArgsInput e)
        {
            try
            {
                OVariablesManager.ForzarValor(e.Codigo, (double)e.ObjetoImputado, "Monitorizacion", this.Name);
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }

        /// <summary>
        /// Evento que se ejecuta al abrir el menú popup de las variables
        /// </summary>
        private void ConfeccionarMenuVariable()
        {
            if (this.ListView.FocusedItem != null)
            {
                OVariable variable = (OVariable)this.ListView.FocusedItem.Tag;

                // Menú de bloqueo
                this.ToolbarsManager.Tools["Bloquear"].SharedProps.Enabled = !variable.Bloqueado;
                this.ToolbarsManager.Tools["Desbloquear"].SharedProps.Enabled = variable.Bloqueado;
                this.ToolbarsManager.Tools["ForzarValor"].SharedProps.Enabled = variable.Bloqueado;
                this.ToolbarsManager.Tools["ForzarVerdadero"].SharedProps.Enabled = variable.Bloqueado;
                this.ToolbarsManager.Tools["ForzarFalso"].SharedProps.Enabled = variable.Bloqueado;
                this.ToolbarsManager.Tools["CargarImagen"].SharedProps.Enabled = variable.Bloqueado;
                this.ToolbarsManager.Tools["GuardarImagen"].SharedProps.Enabled = variable.Bloqueado;

                // Menú de Forzado
                switch (variable.Tipo)
                {
                    case OEnumTipoDato.Flag:
                        this.ToolbarsManager.Tools["ForzarValor"].SharedProps.Visible = true;
                        this.ToolbarsManager.Tools["ForzarValor"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["ForzarVerdadero"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["ForzarFalso"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["CargarImagen"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["GuardarImagen"].SharedProps.Visible = false;
                        break;
                    case OEnumTipoDato.Bit:
                        bool boolValorTrue = false;
                        bool boolValorFalse = false;
                        object objValor = variable.GetValor();
                        if (objValor is bool)
                        {
                            boolValorTrue = (bool)objValor;
                            boolValorFalse = !(bool)objValor;
                        }

                        this.ToolbarsManager.Tools["ForzarValor"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["ForzarVerdadero"].SharedProps.Visible = !boolValorTrue;
                        this.ToolbarsManager.Tools["ForzarFalso"].SharedProps.Visible = !boolValorFalse;
                        this.ToolbarsManager.Tools["CargarImagen"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["GuardarImagen"].SharedProps.Visible = false;
                        break;
                    case OEnumTipoDato.Entero:
                    case OEnumTipoDato.Decimal:
                    case OEnumTipoDato.Texto:
                    case OEnumTipoDato.Fecha:
                        this.ToolbarsManager.Tools["ForzarValor"].SharedProps.Visible = true;
                        this.ToolbarsManager.Tools["ForzarVerdadero"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["ForzarFalso"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["CargarImagen"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["GuardarImagen"].SharedProps.Visible = false;
                        break;
                    case OEnumTipoDato.Imagen:
                    case OEnumTipoDato.Grafico:
                        this.ToolbarsManager.Tools["ForzarValor"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["ForzarVerdadero"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["ForzarFalso"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["CargarImagen"].SharedProps.Visible = true;
                        this.ToolbarsManager.Tools["GuardarImagen"].SharedProps.Visible = true;
                        break;
                    default:
                        this.ToolbarsManager.Tools["ForzarValor"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["ForzarVerdadero"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["ForzarFalso"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["CargarImagen"].SharedProps.Visible = false;
                        this.ToolbarsManager.Tools["GuardarImagen"].SharedProps.Visible = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Monitorizar la variable seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonitorizarVariable()
        {
            switch (this._ModoAperturaFormulario)
            {
                case ModoAperturaFormulario.Monitorizacion:
                    {
                        if (this.ListView.SelectedItems.Count > 0)
                        {
                            foreach (ListViewItem item in this.ListView.SelectedItems)
                            {
                                try
                                {
                                    FrmVariableChart frm = new FrmVariableChart(item.Text);
                                    frm.Show();
                                }
                                catch (Exception exception)
                                {
                                    OLogsControlesVA.ControlesVA.Fatal(exception, this.Name);
                                }
                            }
                        }
                        break;
                    }
            }
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Refresca la visualización de las variables
        /// </summary>
        private void EventoRefrescarVariables(string codigo, object valor)
        {
            try
            {
                TimeSpan tiempoSinRefrescar = DateTime.Now - MomentoUltimoRefresco;
                if (tiempoSinRefrescar.TotalMilliseconds > CadenciaMonitorizacionMs)
                {
                    // Si hace más de x tiempo que se refresco, volvemos a referescar
                    ListViewItem[] items = this.ListView.Items.Find(codigo, false);

                    if (items.Length > 0)
                    {
                        this.RefrescarVariables(codigo, valor, items[0]);
                    }
                }
                else
                {
                    // Si hace menos de x tiempo que se refresco, ponemos un timer
                    if (!this.TimerRefresco.Enabled)
                    {
                        this.TimerRefresco.Enabled = true;
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }

        /// <summary>
        /// Refresca la visualización de las variables
        /// </summary>
        private void RefrescarVariables(string codigo, object valor, ListViewItem item)
        {
            try
            {
                // Reseteamos el timer para que no se vuelva a refrescar
                this.MomentoUltimoRefresco = DateTime.Now;
                this.TimerRefresco.Enabled = false;

                this.PintarItem(codigo, valor, item);
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }

        /// <summary>
        /// Refresca la visualización de las variables
        /// </summary>
        private void RefrescarTodasVariables()
        {
            try
            {
                foreach (ListViewItem item in this.ListView.Items)
                {
                    string codigo = item.Text;
                    object valor = OVariablesManager.GetValue(codigo);
                    OVariable variable = (OVariable)item.Tag;

                    //switch (variable.Tipo)
                    //{
                    //    case OEnumTipoDato.Bit:
                    //    case OEnumTipoDato.Entero:
                    //    case OEnumTipoDato.Texto:
                    //    case OEnumTipoDato.Decimal:
                    //    case OEnumTipoDato.Fecha:
                    //        this.RefrescarVariables(codigo, valor, item);
                    //        break;
                    //}
                    this.RefrescarVariables(codigo, valor, item);
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }

        /// <summary>
        /// Doble clic sobre una variable fuerza su cambio de valor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.ListView.FocusedItem != null)
                {
                    OVariable variable = (OVariable)this.ListView.FocusedItem.Tag;
                    string codigo = this.ListView.FocusedItem.Text;
                    object objValor = OVariablesManager.GetValue(codigo);

                    switch (variable.Tipo)
                    {
                        case OEnumTipoDato.Flag:
                            OVariablesManager.Dispara(codigo, "Monitorizacion", this.Name);
                            break;
                        case OEnumTipoDato.Bit:
                            bool valor = true;
                            if (objValor is bool)
                            {
                                valor = !(bool)objValor;
                            }
                            OVariablesManager.ForzarValor(codigo, valor, "Monitorizacion", this.Name);
                            break;
                        case OEnumTipoDato.Entero:
                        case OEnumTipoDato.Decimal:
                        case OEnumTipoDato.Texto:
                        case OEnumTipoDato.Fecha:
                            this.ForzarValor(variable);
                            break;
                    }
                    this.ListView.SelectedItems.Clear();
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }

        /// <summary>
        /// Clic en la lista del botón desplegable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            try
            {
                switch (e.Tool.Key)
                {
                    case "KeyIconosGrandes":
                        this.ListView.View = View.LargeIcon;
                        break;
                    case "KeyIconosPequeños":
                        this.ListView.View = View.SmallIcon;
                        break;
                    case "KeyLista":
                        this.ListView.View = View.List;
                        break;
                    case "KeyDetalles":
                        this.ListView.View = View.Details;
                        break;
                    case "Monitorizar":    // ButtonTool
                        this.MonitorizarVariable();
                        break;
                    case "Bloquear":    // StateButtonTool
                        if (this.ListView.FocusedItem != null)
                        {
                            string codigo = this.ListView.FocusedItem.Text;
                            OVariablesManager.Bloquear(codigo, "Monitorizacion", this.Name);

                            this.PintarItem(codigo, OVariablesManager.GetValue(codigo), this.ListView.FocusedItem);
                            this.ConfeccionarMenuVariable();
                        }
                        break;
                    case "Desbloquear":    // StateButtonTool
                        if (this.ListView.FocusedItem != null)
                        {
                            string codigo = this.ListView.FocusedItem.Text;
                            OVariablesManager.Desbloquear(codigo, "Monitorizacion", this.Name);

                            this.PintarItem(codigo, OVariablesManager.GetValue(codigo), this.ListView.FocusedItem);
                            this.ConfeccionarMenuVariable();
                        }
                        break;
                    case "ForzarValor":    // ButtonTool
                        if (this.ListView.FocusedItem != null)
                        {
                            OVariable variable = (OVariable)this.ListView.FocusedItem.Tag;
                            string codigo = this.ListView.FocusedItem.Text;
                            switch (variable.Tipo)
                            {
                                case OEnumTipoDato.Entero:
                                case OEnumTipoDato.Texto:
                                case OEnumTipoDato.Decimal:
                                case OEnumTipoDato.Fecha:
                                    this.ForzarValor(variable);
                                    break;
                            }
                            this.ConfeccionarMenuVariable();
                        }
                        break;
                    case "ForzarVerdadero":    // ButtonTool
                        if (this.ListView.FocusedItem != null)
                        {
                            OVariable variable = (OVariable)this.ListView.FocusedItem.Tag;
                            if ((variable.Bloqueado) && (variable.Tipo == OEnumTipoDato.Bit))
                            {
                                string codigo = this.ListView.FocusedItem.Text;
                                OVariablesManager.ForzarValor(codigo, true, "Monitorizacion", this.Name);
                            }
                            this.ConfeccionarMenuVariable();
                        }
                        break;
                    case "ForzarFalso":    // ButtonTool
                        if (this.ListView.FocusedItem != null)
                        {
                            OVariable variable = (OVariable)this.ListView.FocusedItem.Tag;
                            if ((variable.Bloqueado) && (variable.Tipo == OEnumTipoDato.Bit))
                            {
                                string codigo = this.ListView.FocusedItem.Text;
                                OVariablesManager.ForzarValor(codigo, false, "Monitorizacion", this.Name);
                            }
                            this.ConfeccionarMenuVariable();
                        }
                        break;
                    case "CargarImagen":    // ButtonTool
                        if (this.ListView.FocusedItem != null)
                        {
                            OVariable variable = (OVariable)this.ListView.FocusedItem.Tag;
                            if ((variable.Bloqueado) && (variable.Tipo == OEnumTipoDato.Imagen))
                            {
                                string codigo = this.ListView.FocusedItem.Text;
                                string rutaArchivo = ORutaParametrizable.AppFolder;
                                bool archivoSeleccionadoOK = OTrabajoControles.FormularioSeleccionArchivo(this.openFileDialog, ref rutaArchivo);
                                if (archivoSeleccionadoOK)
                                {
                                    OImagen imagen;
                                    object objImagen = OVariablesManager.GetValue(codigo);

                                    // Por defecto se crea una imagen de tipo BitmapImage
                                    if ((objImagen == null) || !(objImagen is OImagen))
                                    {
                                        imagen = new OImagenBitmap();
                                    }
                                    else
                                    {
                                        imagen = ((OImagen)objImagen).Nueva();
                                    }

                                    imagen.Cargar(rutaArchivo);
                                    OVariablesManager.ForzarValor(codigo, imagen, "Monitorizacion", this.Name);
                                }
                            }
                            this.ConfeccionarMenuVariable();
                        }
                        break;
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }

        /// <summary>
        /// Evento de selección de item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ConfeccionarMenuVariable();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }

        /// <summary>
        /// Clic en un escenario
        /// </summary>
        private void EscenarioClick(object sender, ToolClickEventArgs e)
        {
            try
            {
                string codNuevoEscenario = e.Tool.Key;
                codNuevoEscenario = codNuevoEscenario == "Todos" ? string.Empty : codNuevoEscenario;

                if (this.CodEscenarioActual != codNuevoEscenario)
                {
                    this.CodEscenarioActual = codNuevoEscenario;

                    // Recargamos los items
                    this.DestruirItems();
                    this.CrearItems();
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }

        /// <summary>
        /// Timer de refresco del estado actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerRefresco_Tick(object sender, EventArgs e)
        {
            try
            {
                this.RefrescarTodasVariables();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }
        #endregion
    }
}
