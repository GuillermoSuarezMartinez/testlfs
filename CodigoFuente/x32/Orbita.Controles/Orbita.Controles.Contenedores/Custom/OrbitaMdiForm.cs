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
using System.ComponentModel;
namespace Orbita.Controles.Contenedores
{
    public partial class OrbitaMdiForm : System.Windows.Forms.Form
    {
        public class ControlNuevaDefinicion : OForm
        {
            public ControlNuevaDefinicion(OrbitaForm sender)
                : base(sender) { }
        };

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.OrbitaForm.
        /// </summary>
        public OrbitaMdiForm()
            : base()
        {
            InitializeComponent();
            //InitializeAttributes();
            //InitializeProperties();
        }
        #endregion

        //#region Propiedades
        //[System.ComponentModel.Category("Gestión de controles")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //public ControlNuevaDefinicion OI
        //{
        //    get { return this.definicion; }
        //    set { this.definicion = value; }
        //}
        //#endregion

        //#region Métodos privados
        //void InitializeAttributes()
        //{
        //    if (this.definicion == null)
        //    {
        //        this.definicion = new ControlNuevaDefinicion(this);
        //    }
        //}
        //void InitializeProperties()
        //{
        //    this.toolTip.Active = Configuracion.DefectoVerToolTips;
        //    this.Orbita.NumeroMaximoFormulariosAbiertosEnMdi = Configuracion.DefectoNumeroMaximoFormulariosAbiertosEnMdi;
        //}
        //#endregion
    }
}