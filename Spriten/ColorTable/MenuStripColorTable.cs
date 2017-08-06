
using System.Drawing;
using System.Windows.Forms;

namespace Spriten.ColorTable
{
    public class MenuStripColorTable : ProfessionalColorTable
    {
        public Color SelectedBackground { get; set; }
        public Color PressedBackground { get; set; }

        public MenuStripColorTable(Color selected, Color pressed)
        {
            SelectedBackground = selected;
            PressedBackground = pressed;
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return PressedBackground; }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return PressedBackground; }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return SelectedBackground; }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return SelectedBackground; }
        }

        public override Color MenuBorder
        {
            get { return Color.Transparent; }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(128, 128, 128); }
        }
    }
}
