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
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OFilasSeleccionadas : OControlBase
    {
        #region Atributos
        bool confirmarBorrado;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OFilasSeleccionadas.
        /// </summary>
        public OFilasSeleccionadas(object control)
            : base(control) { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina la apariencia de fila seleccionada.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        [System.ComponentModel.Description("Confirmar borrado de fila seleccionada.")]
        public bool ConfirmarBorrado
        {
            get { return this.confirmarBorrado; }
            set { this.confirmarBorrado = value; }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetConfirmarBorrado()
        {
            this.ConfirmarBorrado = Configuracion.DefectoConfirmarBorrado;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeConfirmarBorrado()
        {
            return (this.ConfirmarBorrado != Configuracion.DefectoConfirmarBorrado);
        }
        #endregion

        #region Métodos públicos
        public bool Eliminar()
        {
            bool res = false;
            if (this.Control.Selected != null)
            {
                int indiceFilaActiva = this.Control.ActiveRow.Index;
                try
                {
                    this.Control.DeleteSelectedRows(this.confirmarBorrado);
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
                    res = true;
                }
                catch
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion
    }
}
