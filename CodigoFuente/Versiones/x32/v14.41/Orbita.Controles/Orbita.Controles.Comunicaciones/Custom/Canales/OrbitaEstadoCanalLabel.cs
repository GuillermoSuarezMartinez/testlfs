using System;
using Orbita.Comunicaciones;
namespace Orbita.Controles.Comunicaciones
{
    public partial class OrbitaEstadoCanalLabel : OrbitaControlBaseEventosComs
    {
        #region Internal delegados
        internal delegate void Delegado(string valor);
        #endregion

        #region Constructor

        public OrbitaEstadoCanalLabel()
        {
            InitializeComponent();
        }

        #endregion

        public override void ProcesarVariableVisual(Utiles.OEventArgs e)
        {
            try
            {
                OInfoDato dato = (OInfoDato)e.Argumento;
                this.agregarItemOrbita(dato.Valor.ToString());
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaEstadoCanalLabel ProcesarVariableVisual ", ex);
            }
        }

        private void agregarItemOrbita(string valor)
        {
            if (this.lblValor.InvokeRequired)
            {
                Delegado MyDelegado = new Delegado(agregarItemOrbita);
                this.Invoke(MyDelegado, new object[] { valor });
            }
            else
            {
                this.lblValor.Text = valor;
            }
        }
    }
}