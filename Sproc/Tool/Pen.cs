using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Sproc.Component;

namespace Sproc.Tool
{
    class Pen : DrawTool
    {
        private static DrawTool mPen = new Pen();

        private Pen() { }

        public static ITool GetTool()
        {
            return mPen;
        }

        override
        public void Initialize(Layer layer)
        {
            mDrawingBrush = new SolidBrush(User._PrimaryColor);
            mGraphics = layer.Graphics;
        }

        override
        public void Use(Point point)
        {
            mGraphics.FillRectangle(mDrawingBrush, point.X, point.Y, 1, 1);
        }
    }
}
