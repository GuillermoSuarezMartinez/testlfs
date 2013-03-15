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
namespace Orbita.Controles.Grid
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
        /// <summary>
        /// Filas nuevas.
        /// </summary>
        OFilasNuevas nuevas;
        /// <summary>
        /// Filas seleccionadas.
        /// </summary>
        OFilasSeleccionadas seleccionadas;
        bool mostrarIndicador;
        bool multiseleccion;
        bool confirmarBorrado;
        int alto;
        bool permitirBorrar;
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
        [System.ComponentModel.Description("Determina la configuración de la fila nueva.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content), System.ComponentModel.Category("Fila")]
        public OFilasNuevas Nuevas
        {
            get
            {
                if (this.nuevas == null)
                {
                    this.nuevas = new OFilasNuevas();
                }
                return this.nuevas;
            }
            set { this.nuevas = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de la fila seleccionada.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content), System.ComponentModel.Category("Fila")]
        public OFilasSeleccionadas Seleccionadas
        {
            get
            {
                if (this.seleccionadas == null)
                {
                    this.seleccionadas = new OFilasSeleccionadas(this.Control);
                }
                return this.seleccionadas;
            }
            set { this.seleccionadas = value; }
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
        [System.ComponentModel.Description("Permitir multiselección de filas.")]
        public bool Multiseleccion
        {
            get { return this.multiseleccion; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("Multiseleccion"));
                }
                this.multiseleccion = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("Multiseleccion"));
                }
            }
        }
        [System.ComponentModel.Description("Confirmar borrado de fila.")]
        public bool ConfirmarBorrado
        {
            get { return this.confirmarBorrado; }
            set { this.confirmarBorrado = value; }
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
        [System.ComponentModel.Description("Determina si se permite eliminar filas.")]
        public bool PermitirBorrar
        {
            get { return this.permitirBorrar; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("PermitirBorrar"));
                }
                this.permitirBorrar = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("PermitirBorrar"));
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
        protected void ResetMultiseleccion()
        {
            this.Multiseleccion = Configuracion.DefectoMultiseleccion;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetConfirmarBorrado()
        {
            this.ConfirmarBorrado = Configuracion.DefectoConfirmarBorrado;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetAlto()
        {
            this.Alto = Configuracion.DefectoAlto;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetPermitirBorrar()
        {
            this.PermitirBorrar = Configuracion.DefectoPermitirBorrar;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarIndicador()
        {
            return (this.MostrarIndicador != Configuracion.DefectoMostrarIndicador);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMultiseleccion()
        {
            return (this.Multiseleccion != Configuracion.DefectoMultiseleccion);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeConfirmarBorrado()
        {
            return (this.ConfirmarBorrado != Configuracion.DefectoConfirmarBorrado);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeAlto()
        {
            return (this.Alto != Configuracion.DefectoAlto);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializePermitirBorrar()
        {
            return (this.PermitirBorrar != Configuracion.DefectoPermitirBorrar);
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
        public void Actualizar()
        {
            UltraGridRow fila = this.Control.ActiveRow;
            if (fila != null && fila.IsDataRow && !fila.IsFilteredOut && fila.IsAddRow)
            {
                fila.Update();
            }
        }
        public bool Eliminar()
        {
            bool retorno = false;
            if (this.Control.ActiveRow != null && this.Control.ActiveRow.IsDataRow && !this.Control.ActiveRow.IsFilteredOut && !this.Control.ActiveRow.IsAddRow)
            {
                int indiceFilaActiva = this.Control.ActiveRow.Index;
                this.Control.DeleteSelectedRows(false);
                this.Control.ActiveRow.Delete(false);
                retorno = true;
                if (indiceFilaActiva > 0 || this.Control.Rows.Count > 0)
                {
                    if (indiceFilaActiva >= this.Control.Rows.Count)
                    {
                        indiceFilaActiva -= 1;
                    }
                    for (int indice = indiceFilaActiva; indice > -1; indice--)
                    {
                        if (!this.Control.Rows[indice].IsFilteredOut)
                        {
                            this.Control.ActiveRow = this.Control.Rows[indice];
                            break;
                        }
                    }
                }
            }
            return retorno;
        }
        #endregion
    }
}