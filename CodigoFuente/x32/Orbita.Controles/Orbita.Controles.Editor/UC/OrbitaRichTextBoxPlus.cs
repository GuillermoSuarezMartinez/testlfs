using System.ComponentModel;
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