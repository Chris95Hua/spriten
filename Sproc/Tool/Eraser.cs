using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Sproc.Tool
{
    class Eraser : IDraw
    {
        private static Eraser mEraser = new Eraser();
        SolidBrush mEraserBrush;

        private Eraser() { }

        public static Eraser GetTool()
        {
            return mEraser;
        }

        public void Initialize()
        {
            mEraserBrush = new SolidBrush(Color.Transparent);
        }

        public void PaintPoint(Point point, Graphics graphics)
        {
            graphics.FillRectangle(mEraserBrush, point.X, point.Y, 1f, 1f);
        }

        public void CleanUp()
        {
            mEraserBrush.Dispose();
        }
    }
}
