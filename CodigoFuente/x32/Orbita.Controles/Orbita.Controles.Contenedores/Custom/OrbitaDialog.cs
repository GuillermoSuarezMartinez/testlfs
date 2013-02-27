//***********************************************************************
// Assembly         : Orbita.Controles.Contenedores
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Contenedores
{
	public partial class OrbitaDialog : System.Windows.Forms.Form
	{
		#region Constructor
		/// <summary>
		/// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.OrbitaDialog.
		/// </summary>
		public OrbitaDialog()
		{
			InitializeComponent();
			InitializeProperties();
		}
		#endregion

		#region Métodos privados
		void InitializeProperties()
		{
			this.toolTip.Active = OConfiguracion.OrbFormVerToolTips;
		}
		#endregion

		#region Manejadores de eventos
		protected virtual void OnKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{
				if (e == null)
				{
					return;
				}
				if (e.KeyChar == (char)System.ConsoleKey.Escape)
				{
					this.Close();
				}
			}
			catch (Orbita.Controles.Shared.OExcepcion ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString(), "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
			}
		}
		#endregion
	}
}