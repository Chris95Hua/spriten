using Spriten.ColorTable;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Spriten.Utility
{
    public static class ThemeHelper
    {
        public enum ThemeStyle { Light, Dark }

        public static Color DockBackColor { get; private set; }
        public static Color Background { get; private set; }
        public static Color Foreground { get; private set; }
        public static Color TreeListBackground { get; private set; }
        public static Color Pressed { get; private set; }
        public static Color Hovered { get; private set; }
        private static ThemeBase mTheme;
        public static ToolStripProfessionalRenderer ToolStripRenderer { get; private set; }

        public static ThemeStyle Style { get; private set; }

        public static ThemeBase Theme {
            get
            {
                return mTheme;
            }
            set
            {
                if(mTheme != null)
                    mTheme.Dispose();

                mTheme = value;

                // general
                Background = Theme.ColorPalette.TabSelectedActive.Background;
                Foreground = Theme.ColorPalette.TabSelectedActive.Text;
                Pressed = Theme.ColorPalette.TabUnselected.Background;
                Hovered = Theme.ColorPalette.TabButtonSelectedActiveHovered.Background;
                ToolStripRenderer = new ToolStripProfessionalRenderer(new MenuStripColorTable(Hovered, Pressed));

                if (Background.GetBrightness() > 0.5)
                {
                    // light
                    DockBackColor = Color.FromArgb(120, 120, 120);
                    TreeListBackground = Color.FromArgb(240, 240, 240);
                    Style = ThemeStyle.Light;
                }
                else
                {
                    // dark
                    DockBackColor = Color.FromArgb(32, 32, 32);
                    TreeListBackground = Color.FromArgb(96, 96, 96);
                    Style = ThemeStyle.Dark;
                }
            }
        }
    }
}
