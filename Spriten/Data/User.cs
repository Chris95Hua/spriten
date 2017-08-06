using Spriten.Dock;
using Spriten.Drawing;
using Spriten.Tool;
using System.Collections.Generic;
using System.Drawing;
using static Spriten.Utility.SpriteHelper;

namespace Spriten.Data
{
    /// <summary>
    /// User session
    /// </summary>
    public static class User
    {
        // Fore/back colors
        public static Color ForegroundColor { get; set; }
        public static Color BackgroundColor { get; set; }

        public static bool IsMaskingMode { get; set; }

        // Mask colors
        public static Color MaskBorder { get; set; }
        public static Color MaskBody { get; set; }
        public static Color MaskBorderBody { get; set; }
        public static Color MaskEmptyBody { get; set; }

        // Canvas settings
        public static bool ShowPixelGrid { get; set; }
        public static bool ShowBrushOutline { get; set; }

        // Pen settings
        public static int PenSize { get; set; }
        public static byte PenOpacity { get; set; }

        // Selected Tool
        public static ToolMode ToolMode { get; set; }

        // Selected color selector
        public static ColorSelector ColodDockSelector { get; set; }

        public static List<DrawableMask> DrawablesClipboard { get; set; }
        public static Mask MaskMode = Mask.Border;

        public static void ClearClipboard()
        {
            if (DrawablesClipboard != null && DrawablesClipboard.Count > 0)
            {
                for (int i = DrawablesClipboard.Count - 1; i >= 0; i--)
                {
                    DrawablesClipboard[i].Dispose();
                }

                DrawablesClipboard.Clear();
            }
        }
    }
}
