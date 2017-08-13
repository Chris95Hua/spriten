using System;
using System.Drawing;

using Spriten.CustomControl;

namespace Spriten.Tool
{
    class ColorPicker : DrawTool
    {
        private static DrawTool mColorPicker = new ColorPicker();
        public Action<Color> SetPrimaryColor;
        private Canvas mCanvas;

        private ColorPicker() { }

        public static DrawTool GetTool()
        {
            return mColorPicker;
        }

        public void Initialize(Canvas canvas)
        {
            mCanvas = canvas;
        }

        public Rectangle Use(Rectangle rect)
        {
            int argb = mCanvas.GetPixel(rect.X, rect.Y);

            if (argb != 0)
                SetPrimaryColor?.Invoke(Color.FromArgb(argb));

            return Rectangle.Empty;
        }
    }
}
