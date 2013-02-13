//***********************************************************************
// Assembly         : Orbita.Controles
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using Infragistics.Win.UltraWinGrid;
namespace Orbita.Controles.Grid
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OFilasActivas : OControlBase
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OFilaActiva.
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
        #endregion

        #region Métodos públicos
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
                retorno = this.Control.ActiveRow.Delete(this.Control.Orbita.Filas.ConfirmarBorrado);
                if (indiceFilaActiva > 0 || this.Control.Rows.Count > 0)
                {
                    if (indiceFilaActiva >= this.Control.Rows.Count)
                    {
                        indiceFilaActiva = indiceFilaActiva - 1;
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
        public bool Eliminar(bool prompt)
        {
            if (prompt)
            {
                return this.Eliminar();
            }
            else
            {
                // Guardar el valor del atributo this._confirmarBorrarFilas.
                bool confirmarBorrarFilasAnterior = this.Control.Orbita.Filas.ConfirmarBorrado;
                this.Control.Orbita.Filas.ConfirmarBorrado = false;
                bool res = this.Eliminar();
                // Restaurar el valor del atributo this._confirmarBorrarFilas.
                this.Control.Orbita.Filas.ConfirmarBorrado = confirmarBorrarFilasAnterior;
                return res;
            }
        }
        public bool EliminarSeleccionadas()
        {
            bool res = false;
            if (this.Control.Orbita.Filas.Multiseleccion)
            {
                if (this.Control.Selected != null)
                {
                    int indiceFilaActiva = this.Control.ActiveRow.Index;
                    try
                    {
                        this.Control.DeleteSelectedRows(this.Control.Orbita.Filas.ConfirmarBorrado);
                        res = true;
                    }
                    catch
                    {
                        res = false;
                    }
                    if (indiceFilaActiva > 0 || this.Control.Rows.Count > 0)
                    {
                        if (indiceFilaActiva >= this.Control.Rows.Count)
                        {
                            indiceFilaActiva = indiceFilaActiva - 1;
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
            }
            return res;
        }
        #endregion
    }
}
