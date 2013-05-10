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
using System;
using Infragistics.Win.UltraWinGrid;
using System.ComponentModel;
using Orbita.Controles.Grid;
namespace Orbita.Controles.Combo
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OFilas : OControlBase
    {
        #region Atributos
        /// <summary>
        /// Filas activas.
        /// </summary>
        OFilasActivas activas;
        /// <summary>
        /// Filas alternas.
        /// </summary>
        OFilasAlternas alternas;
        bool mostrarIndicador;
        int alto;
        TipoSeleccionFila tipoSeleccion;
        #endregion

        #region Delegado
        /// <summary>
        /// Delegado útil para que el manejador de evento eliminar ejecute el método de clase adecuado.
        /// </summary>
        public delegate bool TipoSeleccionFila();
        #endregion

        #region Eventos
        public event EventHandler<OPropiedadEventArgs> PropertyChanging;
        public event EventHandler<OPropiedadEventArgs> PropertyChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OFilas.
        /// </summary>
        public OFilas(object control)
            : base(control) { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina la apariencia de fila.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de la fila activa.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content), System.ComponentModel.Category("Fila")]
        public OFilasActivas Activas
        {
            get
            {
                if (this.activas == null)
                {
                    this.activas = new OFilasActivas(this.Control);
                }
                return this.activas;
            }
            set { this.activas = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de la fila alterna.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content), System.ComponentModel.Category("Fila")]
        public OFilasAlternas Alternas
        {
            get
            {
                if (this.alternas == null)
                {
                    this.alternas = new OFilasAlternas();
                }
                return this.alternas;
            }
            set { this.alternas = value; }
        }
        [System.ComponentModel.Description("Muestra indicador de fila.")]
        public bool MostrarIndicador
        {
            get { return this.mostrarIndicador; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("MostrarIndicador"));
                }
                this.mostrarIndicador = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("MostrarIndicador"));
                }
            }
        }
        [System.ComponentModel.Description("Alto de fila.")]
        public int Alto
        {
            get { return this.alto; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("Alto"));
                }
                this.alto = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("Alto"));
                }
            }
        }
        [Browsable(false)]
        public TipoSeleccionFila TipoSeleccion
        {
            get { return this.tipoSeleccion; }
            set { this.tipoSeleccion = value; }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarIndicador()
        {
            this.MostrarIndicador = Configuracion.DefectoMostrarIndicador;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetAlto()
        {
            this.Alto = Configuracion.DefectoAlto;
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarIndicador()
        {
            return (this.MostrarIndicador != Configuracion.DefectoMostrarIndicador);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeAlto()
        {
            return (this.Alto != Configuracion.DefectoAlto);
        }
        #endregion

        #region Métodos públicos
        public void Activar(string campo, string valor)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow fila in this.Control.Rows)
            {
                if (fila.Cells[campo] != null && fila.Cells[campo].Value.ToString() == valor)
                {
                    this.Control.ActiveRow = fila;
                    break;
                }
            }
        }
        public void Activar(string[] campos, string[] valor)
        {
            if (campos == null || valor == null)
            {
                return;
            }
            bool esFila = true;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow fila in this.Control.Rows)
            {
                for (int i = 0; i < campos.Length; i++)
                {
                    if ((fila.Cells[campos[i]] != null) && (fila.Cells[campos[i]].Value.ToString() != valor[i]))
                    {
                        esFila = false;
                    }
                }
                if (esFila)
                {
                    this.Control.ActiveRow = fila;
                    return;
                }
                esFila = true;
            }
        }
        public void Activar(int indiceVisible)
        {
            this.Control.ActiveRow = this.Control.Rows.GetRowAtVisibleIndex(indiceVisible);
        }
        #endregion
    }
}