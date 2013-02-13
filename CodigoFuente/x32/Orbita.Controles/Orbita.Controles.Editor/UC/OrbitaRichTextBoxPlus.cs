using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Orbita.Controles.Editor.UC
{
    public partial class OrbitaRichTextBoxPlus : OrbitaRichTextBox
    {
        public OrbitaRichTextBoxPlus()
        {
            InitializeComponent();
        }

        public OrbitaRichTextBoxPlus(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
