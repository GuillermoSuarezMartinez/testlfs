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
        public void ToolVisible(string key)
        {
            this.ToolVisible(0, key, true);
        }
        public void ToolVisible(string key, bool visible)
        {
            if (this.control.Toolbars[0].Tools.Exists(key))
            {
                this.control.Toolbars[0].Tools[key].SharedProps.Visible = visible;
            }
        }
        public void ToolVisible(int toolbar, string key)
        {
            this.ToolVisible(toolbar, key, true);
        }
        public void ToolVisible(int toolbar, int index)
        {
            this.ToolVisible(toolbar, index, true);
        }
        public void ToolVisible(int toolbar, string key, bool visible)
        {
            if (this.control.Toolbars[toolbar].Tools.Exists(key))
            {
                this.control.Toolbars[toolbar].Tools[key].SharedProps.Visible = visible;
            }
        }
        public void ToolVisible(int toolbar, int index, bool visible)
        {
            this.control.Toolbars[toolbar].Tools[index].SharedProps.Visible = visible;
        }
        #endregion ToolVisible

        #region ToolEnabled
        public void ToolEnabled(string key)
        {
            this.ToolEnabled(0, key, true);
        }
        public void ToolEnabled(string key, bool enabled)
        {
            if (this.control.Toolbars[0].Tools.Exists(key))
            {
                this.control.Toolbars[0].Tools[key].SharedProps.Enabled = enabled;
            }
        }
        public void ToolEnabled(int toolbar, string key)
        {
            this.ToolEnabled(toolbar, key, true);
        }
        public void ToolEnabled(int toolbar, int index)
        {
            this.ToolEnabled(toolbar, index, true);
        }
        public void ToolEnabled(int toolbar, string key, bool enabled)
        {
            if (this.control.Toolbars[toolbar].Tools.Exists(key))
            {
                this.control.Toolbars[toolbar].Tools[key].SharedProps.Enabled = enabled;
            }
        }
        public void ToolEnabled(int toolbar, int index, bool enabled)
        {
            this.control.Toolbars[toolbar].Tools[index].SharedProps.Enabled = enabled;
        }
        #endregion ToolEnabled

        #region ToolTipText
        public void ToolTipText(string key, string tooltip)
        {
            if (this.control.Toolbars[0].Tools.Exists(key))
            {
                this.control.Toolbars[0].Tools[key].SharedProps.ToolTipText = tooltip;
            }
        }
        public void ToolTipText(int toolbar, string key, string tooltip)
        {
            if (this.control.Toolbars[toolbar].Tools.Exists(key))
            {
                this.control.Toolbars[toolbar].Tools[key].SharedProps.ToolTipText = tooltip;
            }
        }
        public void ToolTipText(int toolbar, int index, string tooltip)
        {
            this.control.Toolbars[toolbar].Tools[index].SharedProps.ToolTipText = tooltip;
        }
        #endregion ToolTipText

        #region AgregarTool

        #region AgregarToolContainer
        public void AgregarToolContainer(System.Windows.Forms.Control control, string key)
        {
            this.AgregarToolContainer(0, control, key);
        }
        public void AgregarToolContainer(System.Windows.Forms.Control control, string key, int posicion)
        {
            this.AgregarToolContainer(0, control, key, posicion);
        }
        public void AgregarToolContainer(int toolbar, System.Windows.Forms.Control control, string key)
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
        public void AgregarToolContainer(int toolbar, System.Windows.Forms.Control control, string key, int posicion)
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
        public void AgregarToolLabel(string caption)
        {
            this.AgregarToolLabel(0, caption);
        }
        public void AgregarToolLabel(string caption, string key)
        {
            this.AgregarToolLabel(0, caption, key);
        }
        public void AgregarToolLabel(string caption, int posicion)
        {
            this.AgregarToolLabel(0, caption, posicion);
        }
        public void AgregarToolLabel(string caption, string key, int posicion)
        {
            this.AgregarToolLabel(0, caption, key, posicion);
        }
        public void AgregarToolLabel(int toolbar, string caption)
        {
            this.AgregarToolLabel(toolbar, caption, caption);
        }
        public void AgregarToolLabel(int toolbar, string caption, string key)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.LabelTool toolLabel = new Infragistics.Win.UltraWinToolbars.LabelTool(key);
                toolLabel.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.Default;
                toolLabel.SharedProps.Caption = caption;
                this.control.Tools.Add(toolLabel);
                toolLabel.SharedProps.Spring = true;
                this.control.Toolbars[toolbar].Tools.AddTool(key);
            }
        }
        public void AgregarToolLabel(int toolbar, string caption, int posicion)
        {
            this.AgregarToolLabel(toolbar, caption, caption, posicion);
        }
        public void AgregarToolLabel(int toolbar, string caption, string key, int posicion)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.LabelTool toolLabel = new Infragistics.Win.UltraWinToolbars.LabelTool(key);
                toolLabel.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.Default;
                toolLabel.SharedProps.Caption = caption;
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
        public void AgregarToolButton(string caption)
        {
            this.AgregarToolButton(0, caption);
        }
        public void AgregarToolButton(string caption, string key)
        {
            this.AgregarToolButton(0, caption, key);
        }
        public void AgregarToolButton(string caption, int posicion)
        {
            this.AgregarToolButton(0, caption, posicion);
        }
        public void AgregarToolButton(string caption, string key, int posicion)
        {
            this.AgregarToolButton(0, caption, key, posicion);
        }
        public void AgregarToolButton(string caption, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolButton(0, caption, imagen);
        }
        public void AgregarToolButton(string caption, string key, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolButton(0, caption, key, imagen);
        }
        public void AgregarToolButton(string caption, int posicion, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolButton(0, caption, posicion, imagen);
        }
        public void AgregarToolButton(string caption, string key, int posicion, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolButton(0, caption, key, posicion, imagen);
        }
        public void AgregarToolButton(int toolbar, string caption)
        {
            this.AgregarToolButton(toolbar, caption, caption);
        }
        public void AgregarToolButton(int toolbar, string caption, string key)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.ButtonTool(key);
                toolBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
                toolBoton.SharedProps.Caption = caption;
                this.control.Tools.Add(toolBoton);
                this.control.Toolbars[toolbar].Tools.AddTool(key);
            }
        }
        public void AgregarToolButton(int toolbar, string caption, int posicion)
        {
            this.AgregarToolButton(toolbar, caption, caption, posicion);
        }
        public void AgregarToolButton(int toolbar, string caption, string key, int posicion)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.ButtonTool(key);
                toolBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
                toolBoton.SharedProps.Caption = caption;
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
        public void AgregarToolButton(int toolbar, string caption, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolButton(toolbar, caption, caption, imagen);
        }
        public void AgregarToolButton(int toolbar, string caption, string key, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolButton(toolbar, caption, key, imagen);
        }
        public void AgregarToolButton(int toolbar, string caption, int posicion, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolButton(toolbar, caption, caption, posicion, imagen);
        }
        public void AgregarToolButton(int toolbar, string caption, string key, int posicion, System.Drawing.Bitmap imagen)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool toolBoton = new Infragistics.Win.UltraWinToolbars.ButtonTool(key);
                toolBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
                toolBoton.SharedProps.AppearancesLarge.Appearance.Image = toolBoton.SharedProps.AppearancesSmall.Appearance.Image = imagen;
                toolBoton.SharedProps.Caption = caption;
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
        public void AgregarToolStateButton(string caption)
        {
            this.AgregarToolStateButton(0, caption);
        }
        public void AgregarToolStateButton(string caption, string key)
        {
            this.AgregarToolStateButton(0, caption, key);
        }
        public void AgregarToolStateButton(string caption, int posicion)
        {
            this.AgregarToolStateButton(0, caption, posicion);
        }
        public void AgregarToolStateButton(string caption, string key, int posicion)
        {
            this.AgregarToolStateButton(0, caption, key, posicion);
        }
        public void AgregarToolStateButton(string caption, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolStateButton(0, caption, imagen);
        }
        public void AgregarToolStateButton(string caption, string key, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolStateButton(0, caption, key, imagen);
        }
        public void AgregarToolStateButton(string caption, int posicion, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolStateButton(0, caption, posicion, imagen);
        }
        public void AgregarToolStateButton(string caption, string key, int posicion, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolStateButton(0, caption, key, posicion, imagen);
        }
        public void AgregarToolStateButton(int toolbar, string caption)
        {
            this.AgregarToolStateButton(toolbar, caption, caption);
        }
        public void AgregarToolStateButton(int toolbar, string caption, string key)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.StateButtonTool toolStateBoton = new Infragistics.Win.UltraWinToolbars.StateButtonTool(key);
                toolStateBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
                toolStateBoton.SharedProps.Caption = caption;
                this.control.Tools.Add(toolStateBoton);
                this.control.Toolbars[toolbar].Tools.AddTool(key);
            }
        }
        public void AgregarToolStateButton(int toolbar, string caption, int posicion)
        {
            this.AgregarToolStateButton(toolbar, caption, caption, posicion);
        }
        public void AgregarToolStateButton(int toolbar, string caption, string key, int posicion)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.StateButtonTool toolStateBoton = new Infragistics.Win.UltraWinToolbars.StateButtonTool(key);
                toolStateBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
                toolStateBoton.SharedProps.Caption = caption;
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
        public void AgregarToolStateButton(int toolbar, string caption, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolStateButton(toolbar, caption, caption, imagen);
        }
        public void AgregarToolStateButton(int toolbar, string caption, string key, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolStateButton(toolbar, caption, key, imagen);
        }
        public void AgregarToolStateButton(int toolbar, string caption, int posicion, System.Drawing.Bitmap imagen)
        {
            this.AgregarToolStateButton(toolbar, caption, caption, posicion, imagen);
        }
        public void AgregarToolStateButton(int toolbar, string caption, string key, int posicion, System.Drawing.Bitmap imagen)
        {
            if (!this.control.Tools.Exists(key))
            {
                Infragistics.Win.UltraWinToolbars.StateButtonTool toolStateBoton = new Infragistics.Win.UltraWinToolbars.StateButtonTool(key);
                toolStateBoton.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
                toolStateBoton.SharedProps.AppearancesLarge.Appearance.Image = toolStateBoton.SharedProps.AppearancesSmall.Appearance.Image = imagen;
                toolStateBoton.SharedProps.Caption = caption;
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