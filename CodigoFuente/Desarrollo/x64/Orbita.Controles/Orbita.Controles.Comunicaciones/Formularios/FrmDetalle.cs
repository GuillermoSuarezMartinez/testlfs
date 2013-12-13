using System;
using System.Windows.Forms;
using Orbita.Trazabilidad;
namespace Orbita.Controles.Comunicaciones
{
    public partial class FrmDetalle : Form
    {
        #region Atributo(s)
        /// <summary>
        /// Fila a mostrar.
        /// </summary>
        Infragistics.Win.UltraWinGrid.UltraGridRow _fila;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        /// <param name="fila">Fila del grid con datos.</param>
        public FrmDetalle(Infragistics.Win.UltraWinGrid.UltraGridRow fila)
        {
            InitializeComponent();
            this._fila = fila;
            this.Incializar(fila);
        }
        #endregion

        #region Métodos Privado(s)
        /// <summary>
        /// Inicializa el formulario.
        /// </summary>
        /// <param name="fila">Fila del grid con datos.</param>
        void Incializar(Infragistics.Win.UltraWinGrid.UltraGridRow fila)
        {
            txtNivel.Text = fila.Cells["Nivel"].Value.ToString();
            txtFecha.Text = fila.Cells["Fecha"].Value.ToString();
            txtMensaje.Text = fila.Cells["Mensaje"].Value.ToString();

            //Se carga el PictureBox
            switch ((NivelLog)Enum.Parse(typeof(NivelLog), fila.Cells["Nivel"].Value.ToString(), true))
            {
                case NivelLog.Debug:
                case NivelLog.Info:
                    if (!String.IsNullOrEmpty(Convert.ToString(fila.Cells["Mensaje"].Value)))
                    {
                        if (Convert.ToString(fila.Cells["Mensaje"].Value).Length >= 9)
                        {
                            if (Convert.ToString(fila.Cells["Mensaje"].Value).Substring(1, 9) == "KeepAlive")
                                picNivel.Image = Properties.Resources.MensajeKeepAlive;
                            else
                                picNivel.Image = Properties.Resources.MensajeInformacion;
                        }
                    }
                    break;
                case NivelLog.Warn:
                    picNivel.Image = Properties.Resources.MensajeAdvertencia;
                    break;
                case NivelLog.Error:
                    picNivel.Image = Properties.Resources.MensajeError;
                    break;
                case NivelLog.Fatal:
                    picNivel.Image = Properties.Resources.MensajeFatal;
                    break;
                default:
                    picNivel.Image = Properties.Resources.MensajeInformacion;
                    break;
            }
        }
        #endregion
    }
}