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
using System.ComponentModel;
namespace Orbita.Controles.Menu
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OUltraToolbarsManager
    {
        #region Atributos
        OrbitaUltraToolbarsManager control;
        #endregion

        #region Constructor
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
        #endregion

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
        #endregion

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
        #endregion

        #region AgregarTool
        public void AgregarToolContainer(string toolbar, System.Windows.Forms.Control control)
        {
            if (control == null)
            {
                return;
            }
            Infragistics.Win.UltraWinToolbars.ControlContainerTool toolContainer = new Infragistics.Win.UltraWinToolbars.ControlContainerTool(control.Name);
            toolContainer.SharedProps.Visible = true;
            toolContainer.Control = control;
            this.control.Tools.Add(toolContainer);
            this.control.Toolbars[toolbar].Tools.AddTool(toolContainer.Key);
        }
        public void AgregarToolContainer(string toolbar, System.Windows.Forms.Control control, int posicion)
        {
            if (control == null)
            {
                return;
            }
            Infragistics.Win.UltraWinToolbars.ControlContainerTool toolContainer = new Infragistics.Win.UltraWinToolbars.ControlContainerTool(control.Name);
            toolContainer.SharedProps.Visible = true;
            toolContainer.Control = control;
            this.control.Tools.Add(toolContainer);
            if (posicion > this.control.Toolbars[toolbar].Tools.Count - 1)
            {
                this.control.Toolbars[toolbar].Tools.AddTool(toolContainer.Key);
            }
            else
            {
                if (posicion < 0)
                {
                    this.control.Toolbars[toolbar].Tools.InsertTool(0, toolContainer.Key);
                }
                else
                {
                    this.control.Toolbars[toolbar].Tools.InsertTool(posicion, toolContainer.Key);
                }
            }
        }
        public void AgregarToolLabel(string toolbar, string tool)
        {
            Infragistics.Win.UltraWinToolbars.LabelTool toolLabel = new Infragistics.Win.UltraWinToolbars.LabelTool(tool);
            //toolLabel.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            toolLabel.SharedProps.Caption = tool;
            this.control.Tools.Add(toolLabel);
            toolLabel.SharedProps.Spring = true;
            this.control.Toolbars[toolbar].Tools.AddTool(tool);
        }
        public void AgregarToolLabel(string toolbar, string tool, int posicion)
        {
            Infragistics.Win.UltraWinToolbars.LabelTool toolLabel = new Infragistics.Win.UltraWinToolbars.LabelTool(tool);
            //toolLabel.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            toolLabel.SharedProps.Caption = tool;
            this.control.Tools.Add(toolLabel);
            if (posicion > this.control.Toolbars[toolbar].Tools.Count - 1)
            {
                toolLabel.SharedProps.Spring = true;
                this.control.Toolbars[toolbar].Tools.AddTool(tool);
            }
            else
            {
                if (posicion < 0)
                {
                    this.control.Toolbars[toolbar].Tools.InsertTool(0, tool);
                }
                else
                {
                    this.control.Toolbars[toolbar].Tools.InsertTool(posicion, tool);
                }
            }
        }
        public void AgregarToolButton(string toolbar, string tool)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.ButtonTool(tool);
            toolBoton.SharedProps.Caption = tool;
            this.control.Tools.Add(toolBoton);
            this.control.Toolbars[toolbar].Tools.AddTool(tool);
        }
        public void AgregarToolButton(string toolbar, string tool, int posicion)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.ButtonTool(tool);
            toolBoton.SharedProps.Caption = tool;
            this.control.Tools.Add(toolBoton);
            if (posicion > this.control.Toolbars[toolbar].Tools.Count - 1)
            {
                this.control.Toolbars[toolbar].Tools.AddTool(tool);
            }
            else
            {
                if (posicion < 0)
                {
                    this.control.Toolbars[toolbar].Tools.InsertTool(0, tool);
                }
                else
                {
                    this.control.Toolbars[toolbar].Tools.InsertTool(posicion, tool);
                }
            }
        }
        public void AgregarToolButton(string toolbar, string tool, System.Drawing.Bitmap imagen)
        {
            AgregarToolButton(toolbar, tool, tool, imagen);
        }
        public void AgregarToolButton(string toolbar, string tool, int posicion, System.Drawing.Bitmap imagen)
        {
            AgregarToolButton(toolbar, tool, tool, posicion, imagen);
        }
        public void AgregarToolButton(string toolbar, string tool, string tooltip, System.Drawing.Bitmap imagen)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.ButtonTool(tool);
            toolBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            toolBoton.SharedProps.AppearancesLarge.Appearance.Image = toolBoton.SharedProps.AppearancesSmall.Appearance.Image = imagen;
            toolBoton.SharedProps.Caption = tool;
            toolBoton.SharedProps.ToolTipText = tooltip;
            this.control.Tools.Add(toolBoton);
            this.control.Toolbars[toolbar].Tools.AddTool(tool);
        }
        public void AgregarToolButton(string toolbar, string tool, string tooltip, int posicion, System.Drawing.Bitmap imagen)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.ButtonTool(tool);
            toolBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            toolBoton.SharedProps.AppearancesLarge.Appearance.Image = toolBoton.SharedProps.AppearancesSmall.Appearance.Image = imagen;
            toolBoton.SharedProps.Caption = tool;
            toolBoton.SharedProps.ToolTipText = tooltip;
            this.control.Tools.Add(toolBoton);
            if (posicion > this.control.Toolbars[toolbar].Tools.Count - 1)
            {
                this.control.Toolbars[toolbar].Tools.AddTool(tool);
            }
            else
            {
                if (posicion < 0)
                {
                    this.control.Toolbars[toolbar].Tools.InsertTool(0, tool);
                }
                else
                {
                    this.control.Toolbars[toolbar].Tools.InsertTool(posicion, tool);
                }
            }
        }
        public void AgregarToolStateButton(string toolbar, string tool)
        {
            Infragistics.Win.UltraWinToolbars.StateButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.StateButtonTool(tool);
            toolBoton.SharedProps.Caption = tool;
            this.control.Tools.Add(toolBoton);
            this.control.Toolbars[toolbar].Tools.AddTool(tool);
        }
        public void AgregarToolStateButton(string toolbar, string tool, int posicion)
        {
            Infragistics.Win.UltraWinToolbars.StateButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.StateButtonTool(tool);
            toolBoton.SharedProps.Caption = tool;
            this.control.Tools.Add(toolBoton);
            if (posicion > this.control.Toolbars[toolbar].Tools.Count - 1)
            {
                this.control.Toolbars[toolbar].Tools.AddTool(tool);
            }
            else
            {
                if (posicion < 0)
                {
                    this.control.Toolbars[toolbar].Tools.InsertTool(0, tool);
                }
                else
                {
                    this.control.Toolbars[toolbar].Tools.InsertTool(posicion, tool);
                }
            }
        }
        public void AgregarToolStateButton(string toolbar, string tool, System.Drawing.Bitmap imagen)
        {
            AgregarToolStateButton(toolbar, tool, tool, imagen);
        }
        public void AgregarToolStateButton(string toolbar, string tool, int posicion, System.Drawing.Bitmap imagen)
        {
            AgregarToolStateButton(toolbar, tool, tool, posicion, imagen);
        }
        public void AgregarToolStateButton(string toolbar, string tool, string tooltip, System.Drawing.Bitmap imagen)
        {
            Infragistics.Win.UltraWinToolbars.StateButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.StateButtonTool(tool);
            toolBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            toolBoton.SharedProps.AppearancesLarge.Appearance.Image = toolBoton.SharedProps.AppearancesSmall.Appearance.Image = imagen;
            toolBoton.SharedProps.Caption = tool;
            toolBoton.SharedProps.ToolTipText = tooltip;
            this.control.Tools.Add(toolBoton);
            this.control.Toolbars[toolbar].Tools.AddTool(tool);
        }
        public void AgregarToolStateButton(string toolbar, string tool, string tooltip, int posicion, System.Drawing.Bitmap imagen)
        {
            Infragistics.Win.UltraWinToolbars.StateButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.StateButtonTool(tool);
            toolBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            toolBoton.SharedProps.AppearancesLarge.Appearance.Image = toolBoton.SharedProps.AppearancesSmall.Appearance.Image = imagen;
            toolBoton.SharedProps.Caption = tool;
            toolBoton.SharedProps.ToolTipText = tooltip;
            this.control.Tools.Add(toolBoton);
            if (posicion > this.control.Toolbars[toolbar].Tools.Count - 1)
            {
                this.control.Toolbars[toolbar].Tools.AddTool(tool);
            }
            else
            {
                if (posicion < 0)
                {
                    this.control.Toolbars[toolbar].Tools.InsertTool(0, tool);
                }
                else
                {
                    this.control.Toolbars[toolbar].Tools.InsertTool(posicion, tool);
                }
            }
        }
        #endregion

        #endregion
    }
}