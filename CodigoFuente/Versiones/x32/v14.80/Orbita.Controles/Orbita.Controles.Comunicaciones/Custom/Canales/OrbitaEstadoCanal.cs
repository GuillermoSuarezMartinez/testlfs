using System.Drawing;
using Orbita.Utiles;
using Orbita.Winsock;
namespace Orbita.Controles.Comunicaciones
{
    public partial class OrbitaEstadoCanal : OrbitaControlBaseEventosComs
    {
        #region Internal delegados
        internal delegate void Delegado(WinsockStates estado);
        #endregion

        #region Constructor
        public OrbitaEstadoCanal()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos públicos
        public override void ProcesarEstadoCanal(OEventArgs e)
        {
            WinsockStates estado = (WinsockStates)e.Argumento;
            this.agregarItemOrbita(estado);
        }
        #endregion

        #region Métodos privados
        private void agregarItemOrbita(WinsockStates estado)
        {
            if (this.lblEstadoCanal.InvokeRequired)
            {
                Delegado MyDelegado = new Delegado(agregarItemOrbita);
                this.Invoke(MyDelegado, new object[] { estado });
            }
            else
            {
                switch (estado)
                {
                    case WinsockStates.Connected:
                        this.lblEstadoCanal.BackColor = Color.Green;
                        this.lblEstadoCanal.Text = estado.ToString();
                        break;
                    case WinsockStates.Closed:
                        this.lblEstadoCanal.BackColor = Color.Red;
                        this.lblEstadoCanal.Text = estado.ToString();
                        break;
                    default:
                        this.lblEstadoCanal.BackColor = Color.Yellow;
                        this.lblEstadoCanal.Text = estado.ToString();
                        break;
                }
            }
        }
        #endregion
    }
}