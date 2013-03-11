namespace Orbita.Controles.Grid
{
    partial class FrmPersonalizar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPersonalizar));
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Filas");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Columnas");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Entorno", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Agregar o quitar columnas", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Columnas agrupadas", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.orbitaTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.grpEntornoMostrar = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.chbEntornoFilasVacias = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.orbitaTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.grpFilasApariencia = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.chbFilasColorAlternas = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.grpFilasMostrar = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.chbFilasSelector = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.chbFilasFijas = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.grpFilasConfiguracion = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.chbFilasAutoajuste = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.orbitaTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.lblColumnasOperadores = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.grpColumnasOperadores = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.lblColumnasNotaOperadores = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.cboColumnasOperadores = new System.Windows.Forms.ComboBox();
            this.lblColumnaAutoajustar = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.grpColumnasAutoajustar = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.cboColumnasAutoajustar = new System.Windows.Forms.ComboBox();
            this.lblColumnasMostrar = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.grpColumnasMostrar = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.chbColumnasSumarios = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.chbColumnasFijas = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.chbColumnasFiltros = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.orbitaTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.pnlListView = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.lsvColumnas = new Orbita.Controles.Comunes.OrbitaListView();
            this.pnlMoverColumnas = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.btnBajar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnSubir = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.lblColumnaAgregarQuitar = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.orbitaTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.orbitaPanel1 = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.lsvColumnasAgrupadas = new Orbita.Controles.Comunes.OrbitaListView();
            this.orbitaUltraLabel2 = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.pnlFillPersonalizar = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.OrbitaUltraTabControl = new Orbita.Controles.Contenedores.OrbitaUltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.trvOpciones = new System.Windows.Forms.TreeView();
            this.pnlBottomPersonalizar = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.btnCancelar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.orbitaTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpEntornoMostrar)).BeginInit();
            this.grpEntornoMostrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbEntornoFilasVacias)).BeginInit();
            this.orbitaTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpFilasApariencia)).BeginInit();
            this.grpFilasApariencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbFilasColorAlternas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFilasMostrar)).BeginInit();
            this.grpFilasMostrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbFilasSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbFilasFijas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFilasConfiguracion)).BeginInit();
            this.grpFilasConfiguracion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbFilasAutoajuste)).BeginInit();
            this.orbitaTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpColumnasOperadores)).BeginInit();
            this.grpColumnasOperadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpColumnasAutoajustar)).BeginInit();
            this.grpColumnasAutoajustar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpColumnasMostrar)).BeginInit();
            this.grpColumnasMostrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbColumnasSumarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbColumnasFijas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbColumnasFiltros)).BeginInit();
            this.orbitaTabPageControl4.SuspendLayout();
            this.pnlListView.SuspendLayout();
            this.pnlMoverColumnas.SuspendLayout();
            this.orbitaTabPageControl5.SuspendLayout();
            this.orbitaPanel1.SuspendLayout();
            this.pnlFillPersonalizar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrbitaUltraTabControl)).BeginInit();
            this.OrbitaUltraTabControl.SuspendLayout();
            this.pnlBottomPersonalizar.SuspendLayout();
            this.SuspendLayout();
            // 
            // orbitaTabPageControl1
            // 
            this.orbitaTabPageControl1.Controls.Add(this.grpEntornoMostrar);
            this.orbitaTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.orbitaTabPageControl1.Name = "orbitaTabPageControl1";
            this.orbitaTabPageControl1.Size = new System.Drawing.Size(375, 305);
            // 
            // grpEntornoMostrar
            // 
            this.grpEntornoMostrar.Controls.Add(this.chbEntornoFilasVacias);
            this.grpEntornoMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpEntornoMostrar.Location = new System.Drawing.Point(6, 3);
            this.grpEntornoMostrar.Name = "grpEntornoMostrar";
            this.grpEntornoMostrar.Size = new System.Drawing.Size(387, 56);
            this.grpEntornoMostrar.TabIndex = 10;
            this.grpEntornoMostrar.Text = "Mostrar";
            // 
            // chbEntornoFilasVacias
            // 
            this.chbEntornoFilasVacias.AutoSize = true;
            this.chbEntornoFilasVacias.Location = new System.Drawing.Point(16, 25);
            this.chbEntornoFilasVacias.Name = "chbEntornoFilasVacias";
            this.chbEntornoFilasVacias.Size = new System.Drawing.Size(237, 17);
            this.chbEntornoFilasVacias.TabIndex = 7;
            this.chbEntornoFilasVacias.Text = "Filas vacías que completan la visualización";
            // 
            // orbitaTabPageControl2
            // 
            this.orbitaTabPageControl2.Controls.Add(this.grpFilasApariencia);
            this.orbitaTabPageControl2.Controls.Add(this.grpFilasMostrar);
            this.orbitaTabPageControl2.Controls.Add(this.grpFilasConfiguracion);
            this.orbitaTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.orbitaTabPageControl2.Name = "orbitaTabPageControl2";
            this.orbitaTabPageControl2.Size = new System.Drawing.Size(375, 305);
            // 
            // grpFilasApariencia
            // 
            this.grpFilasApariencia.Controls.Add(this.chbFilasColorAlternas);
            this.grpFilasApariencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpFilasApariencia.Location = new System.Drawing.Point(6, 143);
            this.grpFilasApariencia.Name = "grpFilasApariencia";
            this.grpFilasApariencia.Size = new System.Drawing.Size(387, 50);
            this.grpFilasApariencia.TabIndex = 10;
            this.grpFilasApariencia.Text = "Apariencia";
            // 
            // chbFilasColorAlternas
            // 
            this.chbFilasColorAlternas.AutoSize = true;
            this.chbFilasColorAlternas.Location = new System.Drawing.Point(16, 18);
            this.chbFilasColorAlternas.Name = "chbFilasColorAlternas";
            this.chbFilasColorAlternas.Size = new System.Drawing.Size(185, 17);
            this.chbFilasColorAlternas.TabIndex = 4;
            this.chbFilasColorAlternas.Text = "Mostrar filas alternas coloreadas";
            // 
            // grpFilasMostrar
            // 
            this.grpFilasMostrar.Controls.Add(this.chbFilasSelector);
            this.grpFilasMostrar.Controls.Add(this.chbFilasFijas);
            this.grpFilasMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpFilasMostrar.Location = new System.Drawing.Point(6, 66);
            this.grpFilasMostrar.Name = "grpFilasMostrar";
            this.grpFilasMostrar.Size = new System.Drawing.Size(387, 71);
            this.grpFilasMostrar.TabIndex = 9;
            this.grpFilasMostrar.Text = "Mostrar";
            // 
            // chbFilasSelector
            // 
            this.chbFilasSelector.AutoSize = true;
            this.chbFilasSelector.Location = new System.Drawing.Point(16, 21);
            this.chbFilasSelector.Name = "chbFilasSelector";
            this.chbFilasSelector.Size = new System.Drawing.Size(245, 17);
            this.chbFilasSelector.TabIndex = 5;
            this.chbFilasSelector.Text = "Selector de filas que permiten multiselección";
            // 
            // chbFilasFijas
            // 
            this.chbFilasFijas.AutoSize = true;
            this.chbFilasFijas.Location = new System.Drawing.Point(16, 39);
            this.chbFilasFijas.Name = "chbFilasFijas";
            this.chbFilasFijas.Size = new System.Drawing.Size(130, 17);
            this.chbFilasFijas.TabIndex = 6;
            this.chbFilasFijas.Text = "Indicador de filas fijas";
            // 
            // grpFilasConfiguracion
            // 
            this.grpFilasConfiguracion.Controls.Add(this.chbFilasAutoajuste);
            this.grpFilasConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpFilasConfiguracion.Location = new System.Drawing.Point(6, 3);
            this.grpFilasConfiguracion.Name = "grpFilasConfiguracion";
            this.grpFilasConfiguracion.Size = new System.Drawing.Size(387, 57);
            this.grpFilasConfiguracion.TabIndex = 8;
            this.grpFilasConfiguracion.Text = "Configuración";
            // 
            // chbFilasAutoajuste
            // 
            this.chbFilasAutoajuste.AutoSize = true;
            this.chbFilasAutoajuste.Location = new System.Drawing.Point(16, 25);
            this.chbFilasAutoajuste.Name = "chbFilasAutoajuste";
            this.chbFilasAutoajuste.Size = new System.Drawing.Size(224, 17);
            this.chbFilasAutoajuste.TabIndex = 3;
            this.chbFilasAutoajuste.Text = "Autoajustar filas al contenido de la celda";
            // 
            // orbitaTabPageControl3
            // 
            this.orbitaTabPageControl3.Controls.Add(this.lblColumnasOperadores);
            this.orbitaTabPageControl3.Controls.Add(this.grpColumnasOperadores);
            this.orbitaTabPageControl3.Controls.Add(this.lblColumnaAutoajustar);
            this.orbitaTabPageControl3.Controls.Add(this.grpColumnasAutoajustar);
            this.orbitaTabPageControl3.Controls.Add(this.lblColumnasMostrar);
            this.orbitaTabPageControl3.Controls.Add(this.grpColumnasMostrar);
            this.orbitaTabPageControl3.Location = new System.Drawing.Point(0, 0);
            this.orbitaTabPageControl3.Name = "orbitaTabPageControl3";
            this.orbitaTabPageControl3.Size = new System.Drawing.Size(418, 305);
            // 
            // lblColumnasOperadores
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.lblColumnasOperadores.Appearance = appearance1;
            this.lblColumnasOperadores.AutoSize = true;
            this.lblColumnasOperadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblColumnasOperadores.Location = new System.Drawing.Point(9, 148);
            this.lblColumnasOperadores.Name = "lblColumnasOperadores";
            this.lblColumnasOperadores.Size = new System.Drawing.Size(104, 14);
            this.lblColumnasOperadores.TabIndex = 14;
            this.lblColumnasOperadores.Text = "Operadores de filtro";
            this.lblColumnasOperadores.UseMnemonic = false;
            // 
            // grpColumnasOperadores
            // 
            this.grpColumnasOperadores.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Header3D;
            this.grpColumnasOperadores.Controls.Add(this.lblColumnasNotaOperadores);
            this.grpColumnasOperadores.Controls.Add(this.cboColumnasOperadores);
            this.grpColumnasOperadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpColumnasOperadores.Location = new System.Drawing.Point(9, 155);
            this.grpColumnasOperadores.Name = "grpColumnasOperadores";
            this.grpColumnasOperadores.Size = new System.Drawing.Size(387, 90);
            this.grpColumnasOperadores.TabIndex = 15;
            // 
            // lblColumnasNotaOperadores
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.lblColumnasNotaOperadores.Appearance = appearance2;
            this.lblColumnasNotaOperadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblColumnasNotaOperadores.Location = new System.Drawing.Point(16, 39);
            this.lblColumnasNotaOperadores.Name = "lblColumnasNotaOperadores";
            this.lblColumnasNotaOperadores.Size = new System.Drawing.Size(335, 32);
            this.lblColumnasNotaOperadores.TabIndex = 15;
            this.lblColumnasNotaOperadores.Text = "Nota: la opción de operador de filtro, solo se aplicacará en el caso que se estab" +
                "lezcan filtros por fila.";
            this.lblColumnasNotaOperadores.UseMnemonic = false;
            // 
            // cboColumnasOperadores
            // 
            this.cboColumnasOperadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColumnasOperadores.FormattingEnabled = true;
            this.cboColumnasOperadores.Items.AddRange(new object[] {
            "Ocultar operadores de filtros",
            "Mostrar sobre la fila de filtros",
            "Mostrar en la fila de filtros"});
            this.cboColumnasOperadores.Location = new System.Drawing.Point(16, 12);
            this.cboColumnasOperadores.Name = "cboColumnasOperadores";
            this.cboColumnasOperadores.Size = new System.Drawing.Size(336, 21);
            this.cboColumnasOperadores.TabIndex = 7;
            // 
            // lblColumnaAutoajustar
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.lblColumnaAutoajustar.Appearance = appearance3;
            this.lblColumnaAutoajustar.AutoSize = true;
            this.lblColumnaAutoajustar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblColumnaAutoajustar.Location = new System.Drawing.Point(9, 5);
            this.lblColumnaAutoajustar.Name = "lblColumnaAutoajustar";
            this.lblColumnaAutoajustar.Size = new System.Drawing.Size(119, 14);
            this.lblColumnaAutoajustar.TabIndex = 3;
            this.lblColumnaAutoajustar.Text = "Autoajuste de columna";
            this.lblColumnaAutoajustar.UseMnemonic = false;
            // 
            // grpColumnasAutoajustar
            // 
            this.grpColumnasAutoajustar.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Header3D;
            this.grpColumnasAutoajustar.Controls.Add(this.cboColumnasAutoajustar);
            this.grpColumnasAutoajustar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpColumnasAutoajustar.Location = new System.Drawing.Point(9, 12);
            this.grpColumnasAutoajustar.Name = "grpColumnasAutoajustar";
            this.grpColumnasAutoajustar.Size = new System.Drawing.Size(387, 46);
            this.grpColumnasAutoajustar.TabIndex = 13;
            // 
            // cboColumnasAutoajustar
            // 
            this.cboColumnasAutoajustar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColumnasAutoajustar.FormattingEnabled = true;
            this.cboColumnasAutoajustar.Items.AddRange(new object[] {
            "Sin autoajuste",
            "Redimensionar todas las columnas",
            "Extender la última columna"});
            this.cboColumnasAutoajustar.Location = new System.Drawing.Point(16, 12);
            this.cboColumnasAutoajustar.Name = "cboColumnasAutoajustar";
            this.cboColumnasAutoajustar.Size = new System.Drawing.Size(336, 21);
            this.cboColumnasAutoajustar.TabIndex = 4;
            // 
            // lblColumnasMostrar
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.lblColumnasMostrar.Appearance = appearance4;
            this.lblColumnasMostrar.AutoSize = true;
            this.lblColumnasMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblColumnasMostrar.Location = new System.Drawing.Point(9, 63);
            this.lblColumnasMostrar.Name = "lblColumnasMostrar";
            this.lblColumnasMostrar.Size = new System.Drawing.Size(43, 14);
            this.lblColumnasMostrar.TabIndex = 12;
            this.lblColumnasMostrar.Text = "Mostrar";
            this.lblColumnasMostrar.UseMnemonic = false;
            // 
            // grpColumnasMostrar
            // 
            this.grpColumnasMostrar.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Header3D;
            this.grpColumnasMostrar.Controls.Add(this.chbColumnasSumarios);
            this.grpColumnasMostrar.Controls.Add(this.chbColumnasFijas);
            this.grpColumnasMostrar.Controls.Add(this.chbColumnasFiltros);
            this.grpColumnasMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpColumnasMostrar.Location = new System.Drawing.Point(9, 69);
            this.grpColumnasMostrar.Name = "grpColumnasMostrar";
            this.grpColumnasMostrar.Size = new System.Drawing.Size(387, 69);
            this.grpColumnasMostrar.TabIndex = 9;
            // 
            // chbColumnasSumarios
            // 
            this.chbColumnasSumarios.AutoSize = true;
            this.chbColumnasSumarios.Location = new System.Drawing.Point(17, 30);
            this.chbColumnasSumarios.Name = "chbColumnasSumarios";
            this.chbColumnasSumarios.Size = new System.Drawing.Size(125, 17);
            this.chbColumnasSumarios.TabIndex = 1;
            this.chbColumnasSumarios.Text = "Sumario de columna";
            // 
            // chbColumnasFijas
            // 
            this.chbColumnasFijas.AutoSize = true;
            this.chbColumnasFijas.Location = new System.Drawing.Point(17, 13);
            this.chbColumnasFijas.Name = "chbColumnasFijas";
            this.chbColumnasFijas.Size = new System.Drawing.Size(158, 17);
            this.chbColumnasFijas.TabIndex = 0;
            this.chbColumnasFijas.Text = "Indicador de columnas fijas";
            // 
            // chbColumnasFiltros
            // 
            this.chbColumnasFiltros.AutoSize = true;
            this.chbColumnasFiltros.Location = new System.Drawing.Point(17, 47);
            this.chbColumnasFiltros.Name = "chbColumnasFiltros";
            this.chbColumnasFiltros.Size = new System.Drawing.Size(129, 17);
            this.chbColumnasFiltros.TabIndex = 2;
            this.chbColumnasFiltros.Text = "Filtros en la cabecera";
            // 
            // orbitaTabPageControl4
            // 
            this.orbitaTabPageControl4.Controls.Add(this.pnlListView);
            this.orbitaTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.orbitaTabPageControl4.Name = "orbitaTabPageControl4";
            this.orbitaTabPageControl4.Size = new System.Drawing.Size(375, 305);
            // 
            // pnlListView
            // 
            this.pnlListView.Controls.Add(this.lsvColumnas);
            this.pnlListView.Controls.Add(this.pnlMoverColumnas);
            this.pnlListView.Controls.Add(this.lblColumnaAgregarQuitar);
            this.pnlListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListView.Location = new System.Drawing.Point(0, 0);
            this.pnlListView.Name = "pnlListView";
            this.pnlListView.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.pnlListView.Size = new System.Drawing.Size(375, 305);
            this.pnlListView.TabIndex = 0;
            // 
            // lsvColumnas
            // 
            this.lsvColumnas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvColumnas.CheckBoxes = true;
            this.lsvColumnas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvColumnas.FullRowSelect = true;
            this.lsvColumnas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvColumnas.HideSelection = false;
            this.lsvColumnas.Location = new System.Drawing.Point(6, 19);
            this.lsvColumnas.MultiSelect = false;
            this.lsvColumnas.Name = "lsvColumnas";
            this.lsvColumnas.Size = new System.Drawing.Size(337, 286);
            this.lsvColumnas.TabIndex = 15;
            this.lsvColumnas.UseCompatibleStateImageBehavior = false;
            this.lsvColumnas.View = System.Windows.Forms.View.Details;
            this.lsvColumnas.SelectedIndexChanged += new System.EventHandler(this.lsvColumnas_SelectedIndexChanged);
            // 
            // pnlMoverColumnas
            // 
            this.pnlMoverColumnas.Controls.Add(this.btnBajar);
            this.pnlMoverColumnas.Controls.Add(this.btnSubir);
            this.pnlMoverColumnas.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMoverColumnas.Location = new System.Drawing.Point(343, 19);
            this.pnlMoverColumnas.Name = "pnlMoverColumnas";
            this.pnlMoverColumnas.Size = new System.Drawing.Size(32, 286);
            this.pnlMoverColumnas.TabIndex = 17;
            // 
            // btnBajar
            // 
            appearance5.Image = "arrow_down.png";
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.btnBajar.Appearance = appearance5;
            this.btnBajar.Enabled = false;
            this.btnBajar.ImageList = this.imageList;
            this.btnBajar.Location = new System.Drawing.Point(4, 28);
            this.btnBajar.Name = "btnBajar";
            this.btnBajar.Size = new System.Drawing.Size(29, 27);
            this.btnBajar.TabIndex = 1;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Empty;
            this.imageList.Images.SetKeyName(0, "arrow_up.png");
            this.imageList.Images.SetKeyName(1, "arrow_down.png");
            // 
            // btnSubir
            // 
            appearance6.Image = "arrow_up.png";
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.btnSubir.Appearance = appearance6;
            this.btnSubir.Enabled = false;
            this.btnSubir.ImageList = this.imageList;
            this.btnSubir.Location = new System.Drawing.Point(4, -1);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(29, 27);
            this.btnSubir.TabIndex = 0;
            // 
            // lblColumnaAgregarQuitar
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.lblColumnaAgregarQuitar.Appearance = appearance7;
            this.lblColumnaAgregarQuitar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblColumnaAgregarQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblColumnaAgregarQuitar.Location = new System.Drawing.Point(6, 0);
            this.lblColumnaAgregarQuitar.Name = "lblColumnaAgregarQuitar";
            this.lblColumnaAgregarQuitar.Size = new System.Drawing.Size(369, 19);
            this.lblColumnaAgregarQuitar.TabIndex = 16;
            this.lblColumnaAgregarQuitar.Text = "Columnas:";
            this.lblColumnaAgregarQuitar.UseMnemonic = false;
            // 
            // orbitaTabPageControl5
            // 
            this.orbitaTabPageControl5.Controls.Add(this.orbitaPanel1);
            this.orbitaTabPageControl5.Location = new System.Drawing.Point(-10000, -10000);
            this.orbitaTabPageControl5.Name = "orbitaTabPageControl5";
            this.orbitaTabPageControl5.Size = new System.Drawing.Size(375, 305);
            // 
            // orbitaPanel1
            // 
            this.orbitaPanel1.Controls.Add(this.lsvColumnasAgrupadas);
            this.orbitaPanel1.Controls.Add(this.orbitaUltraLabel2);
            this.orbitaPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orbitaPanel1.Location = new System.Drawing.Point(0, 0);
            this.orbitaPanel1.Name = "orbitaPanel1";
            this.orbitaPanel1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.orbitaPanel1.Size = new System.Drawing.Size(375, 305);
            this.orbitaPanel1.TabIndex = 18;
            // 
            // lsvColumnasAgrupadas
            // 
            this.lsvColumnasAgrupadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvColumnasAgrupadas.CheckBoxes = true;
            this.lsvColumnasAgrupadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvColumnasAgrupadas.FullRowSelect = true;
            this.lsvColumnasAgrupadas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvColumnasAgrupadas.HideSelection = false;
            this.lsvColumnasAgrupadas.Location = new System.Drawing.Point(6, 19);
            this.lsvColumnasAgrupadas.MultiSelect = false;
            this.lsvColumnasAgrupadas.Name = "lsvColumnasAgrupadas";
            this.lsvColumnasAgrupadas.Size = new System.Drawing.Size(369, 286);
            this.lsvColumnasAgrupadas.TabIndex = 15;
            this.lsvColumnasAgrupadas.UseCompatibleStateImageBehavior = false;
            this.lsvColumnasAgrupadas.View = System.Windows.Forms.View.Details;
            // 
            // orbitaUltraLabel2
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.orbitaUltraLabel2.Appearance = appearance8;
            this.orbitaUltraLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.orbitaUltraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.orbitaUltraLabel2.Location = new System.Drawing.Point(6, 0);
            this.orbitaUltraLabel2.Name = "orbitaUltraLabel2";
            this.orbitaUltraLabel2.Size = new System.Drawing.Size(369, 19);
            this.orbitaUltraLabel2.TabIndex = 16;
            this.orbitaUltraLabel2.Text = "Columnas agrupadas:";
            this.orbitaUltraLabel2.UseMnemonic = false;
            // 
            // pnlFillPersonalizar
            // 
            this.pnlFillPersonalizar.Controls.Add(this.OrbitaUltraTabControl);
            this.pnlFillPersonalizar.Controls.Add(this.trvOpciones);
            this.pnlFillPersonalizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFillPersonalizar.Location = new System.Drawing.Point(5, 5);
            this.pnlFillPersonalizar.Name = "pnlFillPersonalizar";
            this.pnlFillPersonalizar.Size = new System.Drawing.Size(597, 305);
            this.pnlFillPersonalizar.TabIndex = 16;
            // 
            // OrbitaUltraTabControl
            // 
            this.OrbitaUltraTabControl.Controls.Add(this.orbitaTabPageControl1);
            this.OrbitaUltraTabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.OrbitaUltraTabControl.Controls.Add(this.orbitaTabPageControl2);
            this.OrbitaUltraTabControl.Controls.Add(this.orbitaTabPageControl3);
            this.OrbitaUltraTabControl.Controls.Add(this.orbitaTabPageControl4);
            this.OrbitaUltraTabControl.Controls.Add(this.orbitaTabPageControl5);
            this.OrbitaUltraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrbitaUltraTabControl.Location = new System.Drawing.Point(179, 0);
            this.OrbitaUltraTabControl.Name = "OrbitaUltraTabControl";
            this.OrbitaUltraTabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.OrbitaUltraTabControl.Size = new System.Drawing.Size(418, 305);
            this.OrbitaUltraTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.OrbitaUltraTabControl.TabIndex = 2;
            ultraTab3.TabPage = this.orbitaTabPageControl1;
            ultraTab3.Text = "tab1";
            ultraTab4.TabPage = this.orbitaTabPageControl2;
            ultraTab4.Text = "tab2";
            ultraTab5.TabPage = this.orbitaTabPageControl3;
            ultraTab5.Text = "tab3";
            ultraTab6.TabPage = this.orbitaTabPageControl4;
            ultraTab6.Text = "tab4";
            ultraTab1.TabPage = this.orbitaTabPageControl5;
            ultraTab1.Text = "tab5";
            this.OrbitaUltraTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab3,
            ultraTab4,
            ultraTab5,
            ultraTab6,
            ultraTab1});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(418, 305);
            // 
            // trvOpciones
            // 
            this.trvOpciones.Dock = System.Windows.Forms.DockStyle.Left;
            this.trvOpciones.FullRowSelect = true;
            this.trvOpciones.HideSelection = false;
            this.trvOpciones.Location = new System.Drawing.Point(0, 0);
            this.trvOpciones.Name = "trvOpciones";
            treeNode1.Name = "General";
            treeNode1.Tag = "1";
            treeNode1.Text = "General";
            treeNode2.Name = "Filas";
            treeNode2.Tag = "2";
            treeNode2.Text = "Filas";
            treeNode3.Name = "Columnas";
            treeNode3.Tag = "3";
            treeNode3.Text = "Columnas";
            treeNode4.Name = "Entorno";
            treeNode4.Tag = "0";
            treeNode4.Text = "Entorno";
            treeNode5.Name = "General";
            treeNode5.Tag = "5";
            treeNode5.Text = "General";
            treeNode6.Name = "Agregar o quitar columnas";
            treeNode6.Tag = "4";
            treeNode6.Text = "Agregar o quitar columnas";
            treeNode7.Name = "General";
            treeNode7.Tag = "7";
            treeNode7.Text = "General";
            treeNode8.Name = "Columnas agrupadas";
            treeNode8.Tag = "6";
            treeNode8.Text = "Columnas agrupadas";
            this.trvOpciones.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode6,
            treeNode8});
            this.trvOpciones.Size = new System.Drawing.Size(179, 305);
            this.trvOpciones.TabIndex = 1;
            this.trvOpciones.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvOpciones_AfterSelect);
            this.trvOpciones.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trvOpciones_MouseMove);
            // 
            // pnlBottomPersonalizar
            // 
            this.pnlBottomPersonalizar.Controls.Add(this.btnCancelar);
            this.pnlBottomPersonalizar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomPersonalizar.Location = new System.Drawing.Point(5, 310);
            this.pnlBottomPersonalizar.Name = "pnlBottomPersonalizar";
            this.pnlBottomPersonalizar.Size = new System.Drawing.Size(597, 35);
            this.pnlBottomPersonalizar.TabIndex = 15;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnCancelar.Location = new System.Drawing.Point(534, 7);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(63, 27);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "&Cerrar";
            // 
            // FrmPersonalizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 350);
            this.Controls.Add(this.pnlFillPersonalizar);
            this.Controls.Add(this.pnlBottomPersonalizar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPersonalizar";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Personalizar";
            this.Shown += new System.EventHandler(this.Personalizar_Shown);
            this.orbitaTabPageControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpEntornoMostrar)).EndInit();
            this.grpEntornoMostrar.ResumeLayout(false);
            this.grpEntornoMostrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbEntornoFilasVacias)).EndInit();
            this.orbitaTabPageControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpFilasApariencia)).EndInit();
            this.grpFilasApariencia.ResumeLayout(false);
            this.grpFilasApariencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbFilasColorAlternas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFilasMostrar)).EndInit();
            this.grpFilasMostrar.ResumeLayout(false);
            this.grpFilasMostrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbFilasSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbFilasFijas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFilasConfiguracion)).EndInit();
            this.grpFilasConfiguracion.ResumeLayout(false);
            this.grpFilasConfiguracion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbFilasAutoajuste)).EndInit();
            this.orbitaTabPageControl3.ResumeLayout(false);
            this.orbitaTabPageControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpColumnasOperadores)).EndInit();
            this.grpColumnasOperadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpColumnasAutoajustar)).EndInit();
            this.grpColumnasAutoajustar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpColumnasMostrar)).EndInit();
            this.grpColumnasMostrar.ResumeLayout(false);
            this.grpColumnasMostrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbColumnasSumarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbColumnasFijas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbColumnasFiltros)).EndInit();
            this.orbitaTabPageControl4.ResumeLayout(false);
            this.pnlListView.ResumeLayout(false);
            this.pnlMoverColumnas.ResumeLayout(false);
            this.orbitaTabPageControl5.ResumeLayout(false);
            this.orbitaPanel1.ResumeLayout(false);
            this.pnlFillPersonalizar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrbitaUltraTabControl)).EndInit();
            this.OrbitaUltraTabControl.ResumeLayout(false);
            this.pnlBottomPersonalizar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        Orbita.Controles.Contenedores.OrbitaPanel pnlBottomPersonalizar;
        Orbita.Controles.Contenedores.OrbitaPanel pnlFillPersonalizar;
        Orbita.Controles.Comunes.OrbitaUltraButton btnCancelar;
        System.Windows.Forms.TreeView trvOpciones;
        Orbita.Controles.Contenedores.OrbitaUltraTabControl OrbitaUltraTabControl;
        Infragistics.Win.UltraWinTabControl.UltraTabPageControl orbitaTabPageControl1;
        Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        Infragistics.Win.UltraWinTabControl.UltraTabPageControl orbitaTabPageControl2;
        Infragistics.Win.UltraWinTabControl.UltraTabPageControl orbitaTabPageControl3;
        Orbita.Controles.Comunes.OrbitaUltraCheckEditor chbColumnasFijas;
        Orbita.Controles.Comunes.OrbitaUltraCheckEditor chbColumnasSumarios;
        Orbita.Controles.Comunes.OrbitaUltraCheckEditor chbColumnasFiltros;
        Orbita.Controles.Comunes.OrbitaUltraCheckEditor chbFilasColorAlternas;
        Orbita.Controles.Comunes.OrbitaUltraCheckEditor chbFilasAutoajuste;
        System.Windows.Forms.ComboBox cboColumnasAutoajustar;
        Orbita.Controles.Comunes.OrbitaUltraLabel lblColumnaAutoajustar;
        Infragistics.Win.UltraWinTabControl.UltraTabPageControl orbitaTabPageControl4;
        Orbita.Controles.Contenedores.OrbitaPanel pnlListView;
        Orbita.Controles.Comunes.OrbitaListView lsvColumnas;
        Orbita.Controles.Comunes.OrbitaUltraLabel lblColumnaAgregarQuitar;
        Orbita.Controles.Contenedores.OrbitaPanel pnlMoverColumnas;
        Orbita.Controles.Comunes.OrbitaUltraButton btnBajar;
        Orbita.Controles.Comunes.OrbitaUltraButton btnSubir;
        Orbita.Controles.Comunes.OrbitaUltraCheckEditor chbFilasSelector;
        System.Windows.Forms.ComboBox cboColumnasOperadores;
        Orbita.Controles.Comunes.OrbitaUltraCheckEditor chbFilasFijas;
        Orbita.Controles.Contenedores.OrbitaUltraGroupBox grpFilasMostrar;
        Orbita.Controles.Contenedores.OrbitaUltraGroupBox grpFilasConfiguracion;
        Orbita.Controles.Comunes.OrbitaUltraLabel lblColumnasMostrar;
        Orbita.Controles.Contenedores.OrbitaUltraGroupBox grpColumnasMostrar;
        Orbita.Controles.Contenedores.OrbitaUltraGroupBox grpColumnasAutoajustar;
        Orbita.Controles.Comunes.OrbitaUltraLabel lblColumnasOperadores;
        Orbita.Controles.Contenedores.OrbitaUltraGroupBox grpColumnasOperadores;
        Orbita.Controles.Comunes.OrbitaUltraLabel lblColumnasNotaOperadores;
        Orbita.Controles.Contenedores.OrbitaUltraGroupBox grpFilasApariencia;
        Orbita.Controles.Contenedores.OrbitaUltraGroupBox grpEntornoMostrar;
        Orbita.Controles.Comunes.OrbitaUltraCheckEditor chbEntornoFilasVacias;
        System.Windows.Forms.ImageList imageList;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl orbitaTabPageControl5;
        private Contenedores.OrbitaPanel orbitaPanel1;
        private Comunes.OrbitaListView lsvColumnasAgrupadas;
        private Comunes.OrbitaUltraLabel orbitaUltraLabel2;
    }
}