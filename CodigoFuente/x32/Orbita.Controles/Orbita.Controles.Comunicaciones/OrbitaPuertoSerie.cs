using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using Orbita.Comunicaciones;
using Orbita.Utiles;
namespace Orbita.Controles.Comunicaciones
{
    public partial class OrbitaPuertoSerie : UserControl
    {
        #region Atributos
        /// <summary>
        /// Puerto serie
        /// </summary>
        private OPuertoRS PuertoSerie;
        /// <summary>
        /// Delegado para mostar elementos del manejador de puerto serie
        /// </summary>
        /// <param name="Elemento"></param>
        internal delegate void DelegadoManejadorSerie(string Elemento);
        #endregion

        public OrbitaPuertoSerie()
        {
            InitializeComponent();
            this.IniciarFormulario();
        }

        #region Métodos
        /// <summary>
        /// Inicializa el control
        /// </summary>
        private void IniciarFormulario()
        {
            this.PuertoSerie = new OPuertoRS(); //Se crea con la configuración por defecto
            //Carga de los combos de configuración del puerto
            this.CargarPuertosDisponbiles();
            this.PuertoSerie.OrbitaRX += new OPuertoRS.OManejadorEventoSerie(PuertoSerie_OrbitaRX);

            this.CargarComboConEnumerado(this.cmbVelocidad, typeof(OVelocidad));
            this.cmbVelocidad.SelectedValue = 9600;
            this.CargarComboConEnumerado(this.cmbBitsDatos, typeof(OBitsDatos));
            this.cmbBitsDatos.SelectedValue = 8;
            this.CargarComboConEnumerado(this.cmbParidad, typeof(OParidades));
            this.CargarComboConEnumerado(this.cmbBitsParada, typeof(OBitsStop));
            this.CargarComboConEnumerado(this.cmbControlFlujo, typeof(OHandShakes));
        }
        /// <summary>
        /// Muestra los elementos recibidos por consola
        /// </summary>
        /// <param name="texto"></param>
        private void agregarItemSerie(string texto)
        {
            if (this.txtConsola.InvokeRequired)
            {
                DelegadoManejadorSerie MyDelegado = new DelegadoManejadorSerie(agregarItemSerie);
                this.Invoke(MyDelegado, new object[] { texto });
            }
            else
            {
                this.txtConsola.AppendText(texto);
            }
        }
        /// <summary>
        /// Recepción de datos
        /// </summary>
        /// <param name="e"></param>
        void PuertoSerie_OrbitaRX(OEventArgs e)
        {
            string s = e.Argumento.ToString();
            try
            {
                this.agregarItemSerie(s);
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// Carga los puertos series de la máquina
        /// </summary>
        private void CargarPuertosDisponbiles()
        {
            //Obtenemos el datatable con laa información del enumerado
            DataTable dt = this.PuertoSerie.ObtenerPuertosDisponibles();

            //Aplicamos el formato
            ArrayList cols = new ArrayList();

            this.cmbPuerto.DataSource = dt;
            this.cmbPuerto.ValueMember = "NumeroCOM";
            this.cmbPuerto.DisplayMember = "Nombre";
        }
        /// <summary>
        /// Carga los combos con los valores de las colecciones
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="enumerado"></param>
        private void CargarComboConEnumerado(ComboBox cbo, Type enumerado)
        {
            //Obtenemos el datatable con laa información del enumerado
            DataTable dt = ODataTableEnumerado.GetValoresDataTable(enumerado, true);

            //Aplicamos el formato
            ArrayList cols = new ArrayList();

            cbo.DataSource = dt;
            cbo.ValueMember = "Identificador";
            cbo.DisplayMember = "Valor";
        }
        /// <summary>
        /// Abre el puerto serie
        /// </summary>
        private void AbrirPuerto()
        {
            try
            {
                OConfiguracionPuertoRS c = new OConfiguracionPuertoRS(Convert.ToInt32(this.cmbPuerto.SelectedValue),
                    Convert.ToInt32(this.cmbVelocidad.SelectedValue), Convert.ToInt32(this.cmbBitsDatos.SelectedValue),
                    (OParidades)this.cmbParidad.SelectedIndex, (OBitsStop)this.cmbBitsParada.SelectedIndex,
                    (OHandShakes)this.cmbControlFlujo.SelectedIndex);

                this.PuertoSerie.ConfigurarPuerto(c);

                this.PuertoSerie.Abrir();
            }
            catch (System.Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
        }
        /// <summary>
        /// Cierra el puerto serie
        /// </summary>
        private void CerrarPuerto()
        {
            try
            {
                this.PuertoSerie.Cerrar();
            }
            catch (System.Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
        }
        #endregion

        #region Eventos
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            this.AbrirPuerto();
        }
        private void brnCerrar_Click(object sender, EventArgs e)
        {
            this.CerrarPuerto();
        }
        private void btnRecibir_Click(object sender, EventArgs e)
        {
            try
            {
                string s = this.PuertoSerie.RecibirCadena();
                this.txtConsola.AppendText(s);
            }
            catch (System.Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                this.PuertoSerie.Enviar(this.txtEnviar.Text);
                this.txtEnviar.Text = string.Empty;
            }
            catch (System.Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
        }
        #endregion
    }
}