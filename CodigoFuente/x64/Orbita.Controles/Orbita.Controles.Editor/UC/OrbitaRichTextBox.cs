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
using System.Windows.Forms;
namespace Orbita.Controles.Editor
{
    /// <summary>
    /// Orbita.Controles.OrbitaRichTextBox.
    /// Represents a standard <see cref="RichTextBox"/> with some minor added functionality.
    /// </summary>
    /// <remarks>
    /// AdvRichTextBox provides methods to maintain performance
    /// while it is being updated. Additional formatting features
    /// have also been added.
    /// </remarks>
    public partial class OrbitaRichTextBox : System.Windows.Forms.RichTextBox
    {
        #region Atributos
        int _updating = 0;
        int _oldEventMask = 0;
        // Constants from the Platform SDK.
        const int EM_SETEVENTMASK = 1073;
        const int EM_GETPARAFORMAT = 1085;
        const int EM_SETPARAFORMAT = 1095;
        const int EM_SETTYPOGRAPHYOPTIONS = 1226;
        const int WM_SETREDRAW = 11;
        const int TO_ADVANCEDTYPOGRAPHY = 1;
        const int PFM_ALIGNMENT = 8;
        const int SCF_SELECTION = 1;
        // It makes no difference if we use PARAFORMAT or
        // PARAFORMAT2 here, so I have opted for PARAFORMAT2.
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        struct PARAFORMAT
        {
            public int cbSize;
            public uint dwMask;
            public short wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            // PARAFORMAT2 from here onwards.
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public short sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public short wShadingWeight;
            public short wShadingStyle;
            public short wNumberingStart;
            public short wNumberingStyle;
            public short wNumberingTab;
            public short wBorderSpace;
            public short wBorderWidth;
            public short wBorders;
        }
        [System.Runtime.InteropServices.DllImport("user32", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern int SendMessage(System.Runtime.InteropServices.HandleRef hWnd, int msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern int SendMessage(System.Runtime.InteropServices.HandleRef hWnd, int msg, int wParam, ref PARAFORMAT lp);
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.OrbitaRichTextBox.
        /// </summary>
        public OrbitaRichTextBox() 
            : base() { }
        #endregion

        #region Propiedades
        /// <summary>
        /// Gets or sets the alignment to apply to the current selection or insertion point.
        /// </summary>
        /// <remarks>
        /// Replaces the SelectionAlignment from <see cref="RichTextBox"/>.
        /// </remarks>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Permite alinear el texto a la derecha, a la izquierda, centrarlo o justificarlo.")]
        [System.ComponentModel.DefaultValue(TextAlign.Left)]
        public new TextAlign SelectionAlignment
        {
            get
            {
                PARAFORMAT fmt = new PARAFORMAT();
                fmt.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(fmt);
                // Get the alignment.
                SendMessage(new System.Runtime.InteropServices.HandleRef(this, Handle), EM_GETPARAFORMAT, SCF_SELECTION, ref fmt);
                // Default to Left align.
                if ((fmt.dwMask & PFM_ALIGNMENT) == 0)
                {
                    return TextAlign.Left;
                }
                return (TextAlign)fmt.wAlignment;
            }
            set
            {
                try
                {
                    PARAFORMAT fmt = new PARAFORMAT();
                    fmt.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(fmt);
                    fmt.dwMask = PFM_ALIGNMENT;
                    fmt.wAlignment = (short)value;
                    // Set the alignment.
                    SendMessage(new System.Runtime.InteropServices.HandleRef(this, Handle), EM_SETPARAFORMAT, SCF_SELECTION, ref fmt);
                }
                catch
                {
                    // Ignorar el error.
                }
            }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Maintains performance while updating.
        /// </summary>
        /// <remarks>
        /// <para>
        /// It is recommended to call this method before doing
        /// any major updates that you do not wish the user to
        /// see. Remember to call EndUpdate when you are finished
        /// with the update. Nested calls are supported.
        /// </para>
        /// <para>
        /// Calling this method will prevent redrawing. It will
        /// also setup the event mask of the underlying richedit
        /// control so that no events are sent.
        /// </para>
        /// </remarks>
        public void BeginUpdate()
        {
            // Deal with nested calls.
            ++this._updating;
            if (this._updating > 1)
            {
                return;
            }
            // Prevent the control from raising any events.
            this._oldEventMask = SendMessage(new System.Runtime.InteropServices.HandleRef(this, Handle), EM_SETEVENTMASK, 0, 0);
            // Prevent the control from redrawing itself.
            SendMessage(new System.Runtime.InteropServices.HandleRef(this, Handle), WM_SETREDRAW, 0, 0);
        }
        /// <summary>
        /// Resumes drawing and event handling.
        /// </summary>
        /// <remarks>
        /// This method should be called every time a call is made
        /// made to BeginUpdate. It resets the event mask to it's
        /// original value and enables redrawing of the control.
        /// </remarks>
        public void EndUpdate()
        {
            // Deal with nested calls.
            --this._updating;
            if (this._updating > 0)
            {
                return;
            }
            // Allow the control to redraw itself.
            SendMessage(new System.Runtime.InteropServices.HandleRef(this, Handle), WM_SETREDRAW, 1, 0);
            // Allow the control to raise event messages.
            SendMessage(new System.Runtime.InteropServices.HandleRef(this, Handle), EM_SETEVENTMASK, 0, _oldEventMask);
        }
        /// <summary>
        /// This member overrides <see cref="Control"/>.OnHandleCreated.
        /// </summary>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected override void OnHandleCreated(System.EventArgs e)
        {
            base.OnHandleCreated(e);
            // Enable support for justification.
            SendMessage(new System.Runtime.InteropServices.HandleRef(this, Handle), EM_SETTYPOGRAPHYOPTIONS, TO_ADVANCEDTYPOGRAPHY, TO_ADVANCEDTYPOGRAPHY);
        }
        #endregion
    }
}