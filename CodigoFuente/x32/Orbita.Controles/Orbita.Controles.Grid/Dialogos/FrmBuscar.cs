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
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
namespace Orbita.Controles.Grid
{
    public partial class FrmBuscar : Orbita.Controles.Contenedores.OrbitaDialog
    {
        #region Atributos
        OrbitaUltraGridToolBar control;
        UltraGridColumn columna;
        #endregion

        #region Constructores
        public FrmBuscar()
        {
            InitializeComponent();
        }
        public FrmBuscar(OrbitaUltraGridToolBar control)
            : this()
        {
            this.control = control;
        }
        #endregion

        #region Métodos privados
        void Buscar()
        {
            OrbitaUltraGrid grid = this.control.Grid;
            if (grid == null)
            {
                return;
            }
            //   See if there is an active row; if there is, use it, otherwise
            //   activate the first row and start the search from there
            UltraGridRow filaActiva = grid.ActiveRow;
            if (filaActiva == null)
            {
                filaActiva = grid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First);
            }
            while (filaActiva != null)
            {
                filaActiva = filaActiva.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
                if (this.MatchText(filaActiva))
                {
                    grid.ActiveRow = filaActiva;
                    if (this.columna != null)
                    {
                        grid.ActiveCell = filaActiva.Cells[this.columna.Key];
                        grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                    }
                    return;
                }
            }
            //   We didn't find it the first time around, so start again from the first row
            filaActiva = grid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First);
            while (filaActiva != null)
            {
                if (this.MatchText(filaActiva))
                {
                    grid.ActiveRow = filaActiva;
                    if (this.columna != null)
                    {
                        grid.ActiveCell = filaActiva.Cells[this.columna.Key];
                        grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                    }
                    return;
                }
                filaActiva = filaActiva.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
            }
            //   If we get this far, we didn//t find the string, so show a message box
            MessageBox.Show("No se encontró '" + this.cboBuscar.Text + "'", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        bool MatchText(UltraGridRow fila)
        {
            if (fila == null)
            {
                return false;
            }
            foreach (UltraGridColumn columna in this.control.Grid.DisplayLayout.Bands[0].Columns)
            {
                if (fila.Cells[columna.Key].Value != null)
                {
                    if (this.Match(this.cboBuscar.Text, fila.Cells[columna.Key].Value.ToString()))
                    {
                        this.columna = columna;
                        return true;
                    }
                }
            }
            return false;
        }
        bool Match(string userString, string cellValue)
        {
            //   If our search is case insensitive, make both strings uppercase
            if (!this.chkMayusculasMinisculas.Checked)
            {
                userString = userString.ToUpper();
                cellValue = cellValue.ToUpper();
            }
            //   If the user string is larger than the cell value, it is by definition
            //   a mismatch, so return false
            if (userString.Length > cellValue.Length)
            {
                return false;
            }
            else if (userString.Length == cellValue.Length)
            {
                return userString == cellValue;
            }
            else
            {
                //   There is probably an easier way to do this
                for (int i = 0; i <= (cellValue.Length - userString.Length); i++)
                {
                    if (userString == cellValue.Substring(i, userString.Length))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        #endregion

        #region Manejadores de eventos
        private void btnBuscarSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                // Añadir la cadena de búsqueda en el control combobox.
                // Limitar la capacidad a 10 items.
                if (!this.cboBuscar.Items.Contains(this.cboBuscar.Text))
                {
                    this.cboBuscar.Items.Insert(0, this.cboBuscar.Text);
                    if (this.cboBuscar.Items.Count > 10)
                    {
                        this.cboBuscar.Items.RemoveAt(10);
                    }
                }
                this.Buscar();
            }
            catch (Exception)
            {
            }
        }
        void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
            }
            catch (Exception)
            {
            }
        }
        #endregion
    }
}
