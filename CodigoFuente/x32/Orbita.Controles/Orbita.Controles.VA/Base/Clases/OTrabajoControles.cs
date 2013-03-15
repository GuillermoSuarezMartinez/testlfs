//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 02-01-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Orbita.Controles.Combo;
using Orbita.Controles.Comunes;
using Orbita.Controles.Contenedores;
using Orbita.Controles.Editor;
using Orbita.Controles.Grid;
using Orbita.Utiles;
using Orbita.VA.Comun;
namespace Orbita.Controles.VA
{
    #region Clase OTrabajoControles: Destinada a alojar métodos comnes para el trabajo con los controles
    /// <summary>
    /// Clase estática destinada a alojar métodos comnes para el trabajo con los controles
    /// </summary>
    public static class OTrabajoControles
    {
        #region Atributo(s) estático(s)
        /// <summary>
        /// Formulario principal de tipo MDI de la aplicación
        /// </summary>
        public static OrbitaMdiContainerForm FormularioPrincipalMDI
        {
            get { return (OrbitaMdiContainerForm)App.FormularioPrincipal; }
            set { App.FormularioPrincipal = value; }
        }

        /// <summary>
        /// Gestor de anclas de los formularios
        /// </summary>
        public static OrbitaUltraDockManager DockManager;
        #endregion

        #region Método(s) estático(s)
        /// <summary>
        /// Indica si existe algún formulario MDI hijo que este maximizado
        /// </summary>
        /// <returns>Ture si existe algún formulario MDI hijo que este maximizado; false en caso contrario</returns>
        public static bool HayFormulariosMDIHijosMaximizados()
        {
            foreach (Form f in OTrabajoControles.FormularioPrincipalMDI.MdiChildren)
            {
                if (f.WindowState == FormWindowState.Maximized)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Ajusta el tamaño y posición de la imagen del fondo en función del tamaño y posición del área de cliente del formulario
        /// </summary>
        public static void AjustarFondoAplicacion(Size tamaño, Image imagen)
        {
            OTrabajoControles.FormularioPrincipalMDI.SuspendLayout();
            // Constantes paras tunear la imagen de fondo de la aplicación //
            float valorOpacidad = (float)0.3; //Entre 0 y 1 (0 invisible, 1 totalmente visible)
            //Tamaño del área donde irá la imagen
            Size p = tamaño;

            if (OTrabajoControles.FormularioPrincipalMDI.WindowState != FormWindowState.Minimized)
            {
                if (p.Width > 0 && p.Height > 0)
                {
                    //Obtener una subimagen proporcional al tamaño del fondo, alineada desde la derecha, recortando el exceso de imagen por la izquierda
                    Image imagenOriginal = imagen;
                    Image imagenFondo = new Bitmap(p.Width, p.Height);

                    //Tratar la imagen para escalarla y trasladarla, y así que quede alineada por la derecha.
                    //Tambien tratamos la opacidad para simular una marca de agua
                    float factorEscalaY = (float)imagenFondo.Height / (float)imagenOriginal.Height;
                    float factorEscalaX = factorEscalaY;

                    using (Graphics g = Graphics.FromImage(imagenFondo))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                        //Escalado
                        g.ScaleTransform(factorEscalaX, factorEscalaY);

                        //Traslacion
                        int traslacion = (int)(g.VisibleClipBounds.Width - imagenOriginal.Width);
                        g.TranslateTransform(traslacion, 0);

                        //Opacidad
                        ColorMatrix cm = new ColorMatrix();
                        cm.Matrix33 = valorOpacidad;
                        ImageAttributes ia = new ImageAttributes();
                        ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                        //Dibujamos la imagen creada en imagenFondo
                        g.DrawImage(imagenOriginal, new Rectangle(0, 0, imagenOriginal.Width, imagenOriginal.Height), 0, 0, imagenOriginal.Width, imagenOriginal.Height, GraphicsUnit.Pixel, ia);

                        //Establecemos la imagen obtenida como fondo de la aplicación
                        OTrabajoControles.FormularioPrincipalMDI.BackgroundImage = imagenFondo;
                    }
                }
            }
            OTrabajoControles.FormularioPrincipalMDI.ResumeLayout();
        }
        /// <summary>
        /// Comprueba que hay una fila correctamente activada para lanzar un nuevo formulario
        /// </summary>
        /// <param name="grid">OrbitaUltraGrid que se desea comprobar</param>
        /// <returns>True si se puede lanzar un nuevo formulario basado en la selección; false en caso contrario</returns>
        public static bool ComprobarGrid(OrbitaUltraGridToolBar grid)
        {
            return ((grid.Grid.ActiveRow != null) &&
                    (grid.Grid.ActiveRow.IsDataRow) &&
                    (!grid.Grid.ActiveRow.IsFilteredOut) &&
                    (!grid.Grid.ActiveRow.IsAddRow));
        }
        /// <summary>
        /// Comprueba que la fila cumple todos los requisitos para trabajar con los campos de la misma
        /// </summary>
        /// <param name="fila">Fila que se desea comprobar</param>
        /// <returns>True si se puede lanzar un nuevo formulario basado en la selección; false en caso contrario</returns>
        public static bool ComprobarFila(Infragistics.Win.UltraWinGrid.UltraGridRow fila)
        {
            return ((fila != null) &&
                    (fila.IsDataRow) &&
                    (!fila.IsFilteredOut) &&
                    (!fila.IsAddRow));
        }
        /// <summary>
        /// Carga el combo con la lista de módulos de la aplicación
        /// </summary>
        public static void CargarCombo(OrbitaUltraCombo combo, Type enumType, object valorDefecto)
        {
            // Creación de una nueva tabla.
            DataTable table = new DataTable("DesplegableCombo");

            // Creación de las columnas
            table.Columns.Add(new DataColumn("Indice", enumType));
            table.Columns.Add(new DataColumn("Descripcion", typeof(string)));

            // Se rellena la tabla
            DataRow row;
            foreach (object value in Enum.GetValues(enumType))
            {
                row = table.NewRow();
                row["Indice"] = value;
                row["Descripcion"] = OAtributoEnumerado.GetStringValue((Enum)value);
                table.Rows.Add(row);
            }

            // Se diseña el grid
            ArrayList cols = new ArrayList();
            cols.Add(new OEstiloColumna("Descripcion", "Descripción"));

            // Se rellena el grid
            //*//combo.OI.Formatear(table, cols, "Descripcion", "Descripcion");

            // Se establece el valor actual
            combo.OI.Valor = OAtributoEnumerado.GetStringValue((Enum)valorDefecto);
        }
        /// <summary>
        /// Carga el combo con la lista de módulos de la aplicación
        /// </summary>
        public static void CargarCombo(OrbitaUltraCombo combo, Dictionary<object, string> valores, Type tipo, object valorDefecto)
        {
            // Creación de una nueva tabla.
            DataTable table = new DataTable("DesplegableCombo");

            // Creación de las columnas
            table.Columns.Add(new DataColumn("Indice", tipo));
            table.Columns.Add(new DataColumn("Descripcion", typeof(string)));

            // Se rellena la tabla
            DataRow row;
            foreach (KeyValuePair<object, string> value in valores)
            {
                row = table.NewRow();
                row["Indice"] = value.Key;
                row["Descripcion"] = value.Value;
                table.Rows.Add(row);
            }

            // Se diseña el grid
            ArrayList cols = new ArrayList();
            cols.Add(new OEstiloColumna("Descripcion", "Descripción"));
            cols.Add(new OEstiloColumna("Indice", "Índice"));

            // Se rellena el grid
            //*//combo.OI.Formatear(table, cols, "Descripcion", "Indice");

            // Se establece el valor actual
            combo.OI.Valor = valorDefecto;

            // Se oculta el índice
            combo.DisplayLayout.Bands[0].Columns["Indice"].Hidden = true;
            combo.DisplayLayout.Bands[0].ColHeadersVisible = false;
            combo.DisplayLayout.Bands[0].Columns["Descripcion"].AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows;
        }
        /// <summary>
        /// Carga de un grid de un único campo
        /// </summary>
        /// <param name="grid">Componente sobre el cual se va a trabajar</param>
        /// <param name="valores">Lista de valores a incluir en el grid</param>
        /// <param name="tipo">Tipo de datos de los valores</param>
        /// <param name="estilo">Estilo de la columna</param>
        /// <param name="alinear">Alineación del campo (celdas)</param>
        /// <param name="mascara">Máscara aplicada</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="editorControl">Control con el cual se modificarán los valores</param>
        public static void CargarGridSimple(OrbitaUltraGridToolBar grid, List<object> valores, Type tipo, EstiloColumna estilo, Alineacion alinear, OMascara mascara, int ancho, Control editorControl)
        {
            // Bloqueamos el grid
            grid.Grid.BeginUpdate();
            grid.Grid.SuspendLayout();

            // Creación de una nueva tabla.
            DataTable table = new DataTable("Table");

            // Creación de las columnas
            table.Columns.Add(new DataColumn("Valor", typeof(object)));
            //table.Columns.Add(new DataColumn("Visualizado", tipo));

            // Se rellena la tabla
            DataRow row;
            foreach (object objeto in valores)
            {
                row = table.NewRow();
                row["Valor"] = objeto;
                table.Rows.Add(row);
            }

            // Se carga el grid
            ArrayList list = new ArrayList();
            list.Add(new OEstiloColumna("Valor", "Valor", estilo, alinear, mascara, ancho, false));

            // Formateamos las columnas y las rellenamos de datos
            grid.OI.Formatear(table, list);

            // Formato
            grid.Grid.DisplayLayout.Bands[0].ColHeadersVisible = false;
            if (editorControl != null)
            {
                grid.Grid.DisplayLayout.Bands[0].Columns[0].EditorComponent = editorControl;
            }

            // Desbloqueamos el grid
            grid.Grid.EndUpdate();
            grid.ResumeLayout();
        }
        /// <summary>
        /// Añade texto a un RichTextBox
        /// </summary>
        /// <param name="box"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void RichTextBoxAppendText(OrbitaRichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            Color colorAnterior = box.SelectionColor;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = colorAnterior;
        }
        /// <summary>
        /// Añade texto a un RichTextBox
        /// </summary>
        /// <param name="box"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        public static void RichTextBoxAppendText(OrbitaRichTextBox box, string text, Font font)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            Font fuenteAnterior = box.SelectionFont;
            box.SelectionFont = font;
            box.AppendText(text);
            box.SelectionFont = fuenteAnterior;
        }
        /// <summary>
        /// Añade texto a un RichTextBox
        /// </summary>
        /// <param name="box"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="font"></param>
        public static void RichTextBoxAppendText(OrbitaRichTextBox box, string text, Color color, Font font)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            Color colorAnterior = box.SelectionColor;
            Font fuenteAnterior = box.SelectionFont;
            box.SelectionColor = color;
            box.SelectionFont = font;
            box.AppendText(text);
            box.SelectionColor = colorAnterior;
            box.SelectionFont = fuenteAnterior;
        }
        /// <summary>
        /// Muestra el formulario para la selección de un archivo
        /// </summary>
        /// <param name="p"></param>
        public static bool FormularioSeleccionArchivo(OpenFileDialog openFileDialog, ref string rutaArchivo)
        {
            bool resultado = false;
            bool existeRuta = false;

            if (System.IO.Path.IsPathRooted(rutaArchivo)) // Si la ruta del archivo es válida
            {
                existeRuta = true;
                string rutaCarpeta = System.IO.Path.GetDirectoryName(rutaArchivo);
                if (File.Exists(rutaArchivo)) // Si el archivo existe se selecciona por defecto
                {
                    openFileDialog.FileName = rutaArchivo;
                    openFileDialog.InitialDirectory = rutaCarpeta;
                }
                else // si el archivo no existe pero si su carpeta, esta será la carpeta inicial del formulario
                {
                    if (Directory.Exists(rutaCarpeta))
                    {
                        openFileDialog.FileName = string.Empty;
                        openFileDialog.InitialDirectory = rutaCarpeta;
                    }
                    else
                    {
                        existeRuta = false;
                    }
                }
            }

            if (!existeRuta)
            {
                openFileDialog.FileName = string.Empty;
                openFileDialog.InitialDirectory = ORutaParametrizable.AppFolder;
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog.FileName))
                {
                    rutaArchivo = openFileDialog.FileName;
                    resultado = true;
                }
            }

            return resultado;
        }
        /// <summary>
        /// Muestra el formulario para guardar un archivo
        /// </summary>
        /// <param name="p"></param>
        public static bool FormularioGuardarArchivo(SaveFileDialog saveFileDialog, ref string rutaArchivo)
        {
            bool resultado = false;
            bool existeRuta = false;

            if (System.IO.Path.IsPathRooted(rutaArchivo)) // Si la ruta del archivo es válida
            {
                existeRuta = true;
                string rutaCarpeta = System.IO.Path.GetDirectoryName(rutaArchivo);
                if (File.Exists(rutaArchivo)) // Si el archivo existe se selecciona por defecto
                {
                    saveFileDialog.FileName = rutaArchivo;
                    saveFileDialog.InitialDirectory = rutaCarpeta;
                }
                else // si el archivo no existe pero si su carpeta, esta será la carpeta inicial del formulario
                {
                    if (Directory.Exists(rutaCarpeta))
                    {
                        saveFileDialog.FileName = string.Empty;
                        saveFileDialog.InitialDirectory = rutaCarpeta;
                    }
                    else
                    {
                        existeRuta = false;
                    }
                }
            }

            if (!existeRuta)
            {
                saveFileDialog.FileName = string.Empty;
                saveFileDialog.InitialDirectory = ORutaParametrizable.AppFolder;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = saveFileDialog.FileName;
                resultado = true;
            }

            return resultado;
        }
        /// <summary>
        /// Muestra el formulario para la selección de una carpeta
        /// </summary>
        /// <param name="p"></param>
        public static bool FormularioSeleccionCarpeta(FolderBrowserDialog folderBrowserDialog, ref string rutaCarpeta)
        {
            bool resultado = false;
            bool existeRuta = false;

            if (System.IO.Path.IsPathRooted(rutaCarpeta)) // Si la ruta de la carpeta es válida
            {
                existeRuta = true;
                string rutaCarpetaAnterior = System.IO.Path.GetDirectoryName(rutaCarpeta);
                if (Directory.Exists(rutaCarpeta)) // Si la carpeta existe se selecciona por defecto
                {
                    folderBrowserDialog.SelectedPath = rutaCarpeta;
                }
                else // si el archivo no existe pero si su carpeta, esta será la carpeta inicial del formulario
                {
                    if (Directory.Exists(rutaCarpetaAnterior))
                    {
                        folderBrowserDialog.SelectedPath = rutaCarpetaAnterior;
                    }
                    else
                    {
                        existeRuta = false;
                    }
                }
            }

            if (!existeRuta)
            {
                folderBrowserDialog.SelectedPath = ORutaParametrizable.AppFolder;
            }

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(folderBrowserDialog.SelectedPath))
                {
                    rutaCarpeta = folderBrowserDialog.SelectedPath;
                    resultado = true;
                }
            }

            return resultado;
        }
        #endregion
    }
    #endregion

    #region Clase EnumeracionCombo: Utilizada para visualizar en el componente OrbitaUltraCombo enumerados
    /// <summary>
    /// Clase destinada a los combos de los formularios databinding que representan un enumerado
    /// </summary>
    public class OEnumeracionCombo
    {
        #region Propiedad(es)
        /// <summary>
        /// Enumerado a elegir en el comobo box
        /// </summary>
        private object _Enumerado;
        /// <summary>
        /// Enumerado a elegir en el comobo box
        /// </summary>
        public object Enumerado
        {
            get { return _Enumerado; }
            set { _Enumerado = value; }
        }
        /// <summary>
        /// Descripción a mostrar en el combo box
        /// </summary>
        private string _Descripcion;
        /// <summary>
        /// Descripción a mostrar en el combo box
        /// </summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="enumerado">Enumerado a elegir en el comobo box</param>
        /// <param name="descripcion">Descripción a mostrar en el combo box</param>
        public OEnumeracionCombo(object enumerado, string descripcion)
        {
            this._Enumerado = enumerado;
            this._Descripcion = descripcion;
        }
        #endregion
    }
    #endregion
}