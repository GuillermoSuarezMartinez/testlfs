using System;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Orbita.Utiles;

namespace oVisorTCP
{
    public partial class FrmConfigLogger : Form
    {
        #region Atributo(s)
        /// <summary>
        /// lista con elementos configuración.
        /// </summary>
        NameValueCollection _listaConfiguracion;
        /// <summary>
        /// fichero de configuración de la aplicación.
        /// </summary>
        string _ficheroConfiguracion;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public FrmConfigLogger(NameValueCollection listaConfiguracion, string ficheroConfiguracion)
        {
            InitializeComponent();

            this._listaConfiguracion = listaConfiguracion;
            this._ficheroConfiguracion = ficheroConfiguracion;
        }
        #endregion

        #region Método(s) Privado(s)
        /// <summary>
        /// Carga los controles del formulario con los valores de la configuración.
        /// </summary>
        void CargarFormulario()
        {
            this.txtCaracter.Text = this._listaConfiguracion.GetValues("CaracterSeparador")[0].ToString();
            this.txtExtensionFicheros.Text = this._listaConfiguracion.GetValues("ExtensionLogs")[0].ToString();
            this.txtFilasError.Text = this._listaConfiguracion.GetValues("FilasVisualizacionError")[0].ToString();
            this.txtFilasTrazas.Text = this._listaConfiguracion.GetValues("FilasVisualizacionTrazas")[0].ToString();
            this.txtLogger.Text = this._listaConfiguracion.GetValues("Logger")[0].ToString();
            this.txtRutaBackup.Text = this._listaConfiguracion.GetValues("RutaLogs")[0].ToString();
            this.txtPuerto.Text = this._listaConfiguracion.GetValues("Puerto")[0].ToString();
        }
        /// <summary>
        /// Actualiza el fichero de configuración con los nuevos valores.
        /// </summary>
        /// <returns></returns>
        bool SetSettings()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(this._ficheroConfiguracion);

            XmlNodeList listaNodos = doc.GetElementsByTagName("appSettings");

            foreach (XmlNode nodo in listaNodos)
            {
                foreach (XmlNode clave in nodo.ChildNodes)
                {
                    if (clave.Attributes != null)
                    {
                        switch (clave.Attributes["key"].Value)
                        {
                            case "FilasVisualizacionTrazas":
                                {
                                    int filas = 0;
                                    if (int.TryParse(txtFilasTrazas.Text, out filas))
                                        clave.Attributes["value"].Value = filas.ToString();
                                    else
                                    {
                                        OMensajes.MostrarError("El número de filas del grid de trazas es incorrecto.");
                                        txtFilasTrazas.Focus();
                                        return false;
                                    }
                                    break;
                                }
                            case "FilasVisualizacionError":
                                {
                                    int filas = 0;
                                    if (int.TryParse(txtFilasError.Text, out filas))
                                        clave.Attributes["value"].Value = filas.ToString();
                                    else
                                    {
                                        OMensajes.MostrarError("El número de filas del grid de errores es incorrecto.");
                                        txtFilasError.Focus();
                                        return false;
                                    }
                                    break;
                                }
                            case "RutaLogs":
                                {
                                    if (!Directory.Exists(txtRutaBackup.Text))
                                    {
                                        OMensajes.MostrarError("La ruta del servicio no existe.");
                                        txtRutaBackup.Focus();
                                        return false;
                                    }
                                    else
                                        clave.Attributes["value"].Value = txtRutaBackup.Text;
                                    break;
                                }
                            case "Logger":
                                clave.Attributes["value"].Value = txtLogger.Text;
                                break;
                            case "Puerto":
                                {
                                    int puerto = 0;
                                    if (int.TryParse(txtPuerto.Text, out puerto))
                                        clave.Attributes["value"].Value = puerto.ToString();
                                    else
                                    {
                                        OMensajes.MostrarError("El número de puerto es incorrecto.");
                                        txtPuerto.Focus();
                                        return false;
                                    }
                                    break;
                                }
                            case "ExtensionLogs":
                                {
                                    if (!txtExtensionFicheros.Text.StartsWith("."))
                                        txtExtensionFicheros.Text = "." + txtExtensionFicheros.Text;

                                    clave.Attributes["value"].Value = txtExtensionFicheros.Text;
                                    break;
                                }
                            case "CaracterSeparador":
                                clave.Attributes["value"].Value = txtCaracter.Text;
                                break;

                        }
                    }
                }
            }
            doc.Save(_ficheroConfiguracion);
            return true;
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Evento aceptar, comprueba y almacena las settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAceptar_Click(object sender, EventArgs e)
        {
            if (SetSettings())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Carga del formulario principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FrmConfigLogger_Load(object sender, EventArgs e)
        {
            CargarFormulario();
        }
        #endregion
    }
}
