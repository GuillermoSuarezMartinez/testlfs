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
    public class OFilasActivas : OControlBase
    {
        #region Atributos
        bool confirmarBorrado;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OFilas.
        /// </summary>
        public OFilasActivas(object control)
            : base(control) { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina la apariencia de fila activa.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        [System.ComponentModel.Description("Confirmar borrado de fila.")]
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
            bool retorno = false;
            if (this.Control.ActiveRow != null && this.Control.ActiveRow.IsDataRow && !this.Control.ActiveRow.IsFilteredOut && !this.Control.ActiveRow.IsAddRow)
            {
                int indiceFilaActiva = this.Control.ActiveRow.Index;
                retorno = this.Control.ActiveRow.Delete(this.confirmarBorrado);
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