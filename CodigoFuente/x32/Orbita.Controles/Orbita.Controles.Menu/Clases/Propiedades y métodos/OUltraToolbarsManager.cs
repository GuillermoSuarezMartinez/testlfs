//***********************************************************************
// Assembly         : Orbita.Controles.Comunes
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Menu
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OUltraToolbarsManager
    {
        #region Atributos
        OrbitaUltraToolbarsManager control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Menu.OUltraToolbarsManager.
        /// </summary>
        /// <param name="control">Orbita.Controles.Menu.OrbitaUltraToolbarsManager.</param>
        public OUltraToolbarsManager(object control)
            : base()
        {
            this.control = (OrbitaUltraToolbarsManager)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaUltraToolbarsManager Control
        {
            get { return this.control; }
        }
        #endregion

        #region Métodos públicos

        public override string ToString()
        {
            return null;
        }

        #region ToolVisible
        public void ToolVisible(string toolbar, string tool)
        {
            this.ToolVisible(toolbar, tool, true);
        }
        public void ToolVisible(int toolbar, string tool)
        {
            this.ToolVisible(toolbar, tool, true);
        }
        public void ToolVisible(string toolbar, int tool)
        {
            this.ToolVisible(toolbar, tool, true);
        }
        public void ToolVisible(int toolbar, int tool)
        {
            this.ToolVisible(toolbar, tool, true);
        }
        public void ToolVisible(string toolbar, string tool, bool visible)
        {
            this.control.Toolbars[toolbar].Tools[tool].SharedProps.Visible = visible;
        }
        public void ToolVisible(int toolbar, string tool, bool visible)
        {
            this.control.Toolbars[toolbar].Tools[tool].SharedProps.Visible = visible;
        }
        public void ToolVisible(string toolbar, int tool, bool visible)
        {
            this.control.Toolbars[toolbar].Tools[tool].SharedProps.Visible = visible;
        }
        public void ToolVisible(int toolbar, int tool, bool visible)
        {
            this.control.Toolbars[toolbar].Tools[tool].SharedProps.Visible = visible;
        }
        #endregion ToolVisible

        #region ToolEnabled
        public void ToolEnabled(string toolbar, string tool)
        {
            this.ToolEnabled(toolbar, tool, true);
        }
        public void ToolEnabled(int toolbar, string tool)
        {
            this.ToolEnabled(toolbar, tool, true);
        }
        public void ToolEnabled(string toolbar, int tool)
        {
            this.ToolEnabled(toolbar, tool, true);
        }
        public void ToolEnabled(int toolbar, int tool)
        {
            this.ToolEnabled(toolbar, tool, true);
        }
        public void ToolEnabled(string toolbar, string tool, bool habilitar)
        {
            this.control.Toolbars[toolbar].Tools[tool].SharedProps.Enabled = habilitar;
        }
        public void ToolEnabled(int toolbar, string tool, bool habilitar)
        {
            this.control.Toolbars[toolbar].Tools[tool].SharedProps.Enabled = habilitar;
        }
        public void ToolEnabled(string toolbar, int tool, bool habilitar)
        {
            this.control.Toolbars[toolbar].Tools[tool].SharedProps.Enabled = habilitar;
        }
        public void ToolEnabled(int toolbar, int tool, bool habilitar)
        {
            this.control.Toolbars[toolbar].Tools[tool].SharedProps.Enabled = habilitar;
        }
        #endregion ToolEnabled

        #region ToolTipText
        public void ToolTipText(string toolbar, string tool, string texto)
        {
            this.control.Toolbars[toolbar].Tools[tool].SharedProps.ToolTipText = texto;
        }
        public void ToolTipText(int toolbar, string tool, string texto)
        {
            this.control.Toolbars[toolbar].Tools[tool].SharedProps.ToolTipText = texto;
        }
        public void ToolTipText(string toolbar, int tool, string texto)
        {
            this.control.Toolbars[toolbar].Tools[tool].SharedProps.ToolTipText = texto;
        }
        public void ToolTipText(int toolbar, int tool, string texto)
        {
            this.control.Toolbars[toolbar].Tools[tool].SharedProps.ToolTipText = texto;
        }
        #endregion ToolTipText

        #region AgregarTool

        #region AgregarToolContainer
        public void AgregarToolContainer(string toolbar, System.Windows.Forms.Control control, string key)
        {
            if (control == null)
            {
                return;
            }
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.ControlContainerTool toolContainer = new Infragistics.Win.UltraWinToolbars.ControlContainerTool(key);
                toolContainer.SharedProps.Visible = true;
                toolContainer.Control = control;
                this.control.Tools.Add(toolContainer);
                this.control.Toolbars[toolbar].Tools.AddTool(key);
            }
        }
        public void AgregarToolContainer(string toolbar, System.Windows.Forms.Control control, string key, int posicion)
        {
            if (control == null)
            {
                return;
            }
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.ControlContainerTool toolContainer = new Infragistics.Win.UltraWinToolbars.ControlContainerTool(key);
                toolContainer.SharedProps.Visible = true;
                toolContainer.Control = control;
                this.control.Tools.Add(toolContainer);
                if (posicion > this.control.Toolbars[toolbar].Tools.Count - 1)
                {
                    this.control.Toolbars[toolbar].Tools.AddTool(key);
                }
                else
                {
                    if (posicion < 0)
                    {
                        this.control.Toolbars[toolbar].Tools.InsertTool(0, key);
                    }
                    else
                    {
                        this.control.Toolbars[toolbar].Tools.InsertTool(posicion, key);
                    }
                }
            }
        }
        #endregion AgregarToolContainer

        #region AgregarToolLabel
        public void AgregarToolLabel(string toolbar, string tool)
        {
            this.AgregarToolLabel(toolbar, tool, tool);
        }
        public void AgregarToolLabel(string toolbar, string tool, string key)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.LabelTool toolLabel = new Infragistics.Win.UltraWinToolbars.LabelTool(key);
                toolLabel.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.Default;
                toolLabel.SharedProps.Caption = tool;
                this.control.Tools.Add(toolLabel);
                toolLabel.SharedProps.Spring = true;
                this.control.Toolbars[toolbar].Tools.AddTool(key);
            }
        }
        public void AgregarToolLabel(string toolbar, string tool, int posicion)
        {
            this.AgregarToolLabel(toolbar, tool, tool, posicion);
        }
        public void AgregarToolLabel(string toolbar, string tool, string key, int posicion)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.LabelTool toolLabel = new Infragistics.Win.UltraWinToolbars.LabelTool(key);
                toolLabel.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.Default;
                toolLabel.SharedProps.Caption = tool;
                this.control.Tools.Add(toolLabel);
                if (posicion > this.control.Toolbars[toolbar].Tools.Count - 1)
                {
                    toolLabel.SharedProps.Spring = true;
                    this.control.Toolbars[toolbar].Tools.AddTool(key);
                }
                else
                {
                    if (posicion < 0)
                    {
                        this.control.Toolbars[toolbar].Tools.InsertTool(0, key);
                    }
                    else
                    {
                        this.control.Toolbars[toolbar].Tools.InsertTool(posicion, key);
                    }
                }
            }
        }
        #endregion AgregarToolLabel

        #region AgregarToolButton
        public void AgregarToolButton(string toolbar, string tool)
        {
            this.AgregarToolButton(toolbar, tool, tool);
        }
        public void AgregarToolButton(string toolbar, string tool, string key)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.ButtonTool(key);
                toolBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
                toolBoton.SharedProps.Caption = tool;
                this.control.Tools.Add(toolBoton);
                this.control.Toolbars[toolbar].Tools.AddTool(key);
            }
        }
        public void AgregarToolButton(string toolbar, string tool, int posicion)
        {
            this.AgregarToolButton(toolbar, tool, tool, posicion);
        }
        public void AgregarToolButton(string toolbar, string tool, string key, int posicion)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.ButtonTool(key);
                toolBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
                toolBoton.SharedProps.Caption = tool;
                this.control.Tools.Add(toolBoton);
                if (posicion > this.control.Toolbars[toolbar].Tools.Count - 1)
                {
                    this.control.Toolbars[toolbar].Tools.AddTool(key);
                }
                else
                {
                    if (posicion < 0)
                    {
                        this.control.Toolbars[toolbar].Tools.InsertTool(0, key);
                    }
                    else
                    {
                        this.control.Toolbars[toolbar].Tools.InsertTool(posicion, key);
                    }
                }
            }
        }
        public void AgregarToolButton(string toolbar, string tool, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolButton(toolbar, tool, tool, imagen);
        }
        public void AgregarToolButton(string toolbar, string tool, string key, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolButton(toolbar, tool, key, imagen);
        }
        public void AgregarToolButton(string toolbar, string tool, int posicion, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolButton(toolbar, tool, tool, posicion, imagen);
        }
        public void AgregarToolButton(string toolbar, string tool, string key, int posicion, System.Drawing.Bitmap imagen)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.ButtonTool(key);
                toolBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
                toolBoton.SharedProps.AppearancesLarge.Appearance.Image = toolBoton.SharedProps.AppearancesSmall.Appearance.Image = imagen;
                toolBoton.SharedProps.Caption = tool;
                this.control.Tools.Add(toolBoton);
                if (posicion > this.control.Toolbars[toolbar].Tools.Count - 1)
                {
                    this.control.Toolbars[toolbar].Tools.AddTool(key);
                }
                else
                {
                    if (posicion < 0)
                    {
                        this.control.Toolbars[toolbar].Tools.InsertTool(0, key);
                    }
                    else
                    {
                        this.control.Toolbars[toolbar].Tools.InsertTool(posicion, key);
                    }
                }
            }
        }
        #endregion AgregarToolButton

        #region AgregarToolStateButton
        public void AgregarToolStateButton(string toolbar, string tool)
        {
            this.AgregarToolStateButton(toolbar, tool, tool);
        }
        public void AgregarToolStateButton(string toolbar, string tool, string key)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.StateButtonTool toolStateBoton = new Infragistics.Win.UltraWinToolbars.StateButtonTool(key);
                toolStateBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
                toolStateBoton.SharedProps.Caption = tool;
                this.control.Tools.Add(toolStateBoton);
                this.control.Toolbars[toolbar].Tools.AddTool(key);
            }
        }
        public void AgregarToolStateButton(string toolbar, string tool, int posicion)
        {
            this.AgregarToolStateButton(toolbar, tool, tool, posicion);
        }
        public void AgregarToolStateButton(string toolbar, string tool, string key, int posicion)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.StateButtonTool toolStateBoton = new Infragistics.Win.UltraWinToolbars.StateButtonTool(key);
                toolStateBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
                toolStateBoton.SharedProps.Caption = tool;
                this.control.Tools.Add(toolStateBoton);
                if (posicion > this.control.Toolbars[toolbar].Tools.Count - 1)
                {
                    this.control.Toolbars[toolbar].Tools.AddTool(key);
                }
                else
                {
                    if (posicion < 0)
                    {
                        this.control.Toolbars[toolbar].Tools.InsertTool(0, key);
                    }
                    else
                    {
                        this.control.Toolbars[toolbar].Tools.InsertTool(posicion, key);
                    }
                }
            }
        }
        public void AgregarToolStateButton(string toolbar, string tool, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolStateButton(toolbar, tool, tool, imagen);
        }
        public void AgregarToolStateButton(string toolbar, string tool, string key, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolStateButton(toolbar, tool, key, imagen);
        }
        public void AgregarToolStateButton(string toolbar, string tool, int posicion, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolStateButton(toolbar, tool, tool, posicion, imagen);
        }
        public void AgregarToolStateButton(string toolbar, string tool, string key, int posicion, System.Drawing.Bitmap imagen)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.StateButtonTool toolStateBoton = new Infragistics.Win.UltraWinToolbars.StateButtonTool(key);
                toolStateBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
                toolStateBoton.SharedProps.AppearancesLarge.Appearance.Image = toolStateBoton.SharedProps.AppearancesSmall.Appearance.Image = imagen;
                toolStateBoton.SharedProps.Caption = tool;
                this.control.Tools.Add(toolStateBoton);
                if (posicion > this.control.Toolbars[toolbar].Tools.Count - 1)
                {
                    this.control.Toolbars[toolbar].Tools.AddTool(key);
                }
                else
                {
                    if (posicion < 0)
                    {
                        this.control.Toolbars[toolbar].Tools.InsertTool(0, key);
                    }
                    else
                    {
                        this.control.Toolbars[toolbar].Tools.InsertTool(posicion, key);
                    }
                }
            }
        }
        #endregion AgregarToolStateButton

        #endregion AgregarTool

        #endregion Métodos públicos
    }
}