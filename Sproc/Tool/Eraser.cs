using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Sproc.Component;

namespace Sproc.Tool
{
    class Eraser : DrawTool
    {
        private static DrawTool mEraser = new Eraser();

        private Eraser() { }

        public static ITool GetTool()
        {
            return mEraser;
        }

        override
        public void Initialize(Layer layer)
        {
            mDrawingBrush = new SolidBrush(Color.Transparent);
            mGraphics = layer.Graphics; 
        }

        override
        public void Use(Point point)
        {
            // TODO: set CompositingMode to default in Dispose
            mGraphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            mGraphics.FillRectangle(mDrawingBrush, point.X, point.Y, 1, 1);
        }
    }
}
