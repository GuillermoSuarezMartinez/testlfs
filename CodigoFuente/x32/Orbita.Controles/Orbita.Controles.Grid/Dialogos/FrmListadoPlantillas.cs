//***********************************************************************
// Assembly         : Orbita.Controles.Grid
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Grid
{
    public partial class FrmListadoPlantillas : Orbita.Controles.Grid.FrmListadoPlantillasBase
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.FrmListadoPlantillas.
        /// </summary>
        public FrmListadoPlantillas()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.FrmListadoPlantillas.
        /// </summary>
        /// <param name="plantillas">Colección de plantillas.</param>
        /// <param name="error">Si error, no existen plantillas a mostrar.</param>
        public FrmListadoPlantillas(System.Collections.Generic.Dictionary<string, Orbita.Controles.Grid.OPlantilla> plantillas, bool error)
            : this()
        {
            if (plantillas != null)
            {
                this.lblSinElementos.Visible = error;
                this.Lista.Visible = !error;
                if (!error)
                {
                    this.Lista.OI.Columnas.Add(new Orbita.Controles.Comunes.OColumnHeader("Nombre", 100, System.Windows.Forms.HorizontalAlignment.Left));
                    this.Lista.OI.Columnas.Add(new Orbita.Controles.Comunes.OColumnHeader("Descripción", 100, System.Windows.Forms.HorizontalAlignment.Left));
                    this.Lista.OI.Columnas.Add(new Orbita.Controles.Comunes.OColumnHeader("Identificador", 50, System.Windows.Forms.HorizontalAlignment.Left));
                    foreach (System.Collections.Generic.KeyValuePair<string, OPlantilla> plantilla in plantillas)
                    {
                        if (!plantilla.Value.Activo)
                        {
                            System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(plantilla.Value.Nombre);
                            item.Name = "nombre";
                            System.Windows.Forms.ListViewItem.ListViewSubItem descripcion = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                            descripcion.Name = "descripcion";
                            descripcion.Text = plantilla.Value.Descripcion;
                            item.SubItems.Add(descripcion);
                            System.Windows.Forms.ListViewItem.ListViewSubItem identificador = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                            identificador.Name = "identificador";
                            identificador.Text = plantilla.Value.Clave;
                            item.SubItems.Add(identificador);
                            // Añadir el item a la colección.
                            this.Lista.Items.Add(item);
                        }
                    }
                    // Ocultar la columna identificador.
                    this.Lista.OI.Columnas[2].Visible = false;
                }
            }
        }
        #endregion
    }
}