using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Sproc.Component;

namespace Sproc.Tool
{
    abstract class DrawTool : ITool
    {
        protected SolidBrush mDrawingBrush;
        protected Graphics mGraphics;

        public abstract void Initialize(Layer layer);

        public abstract void Use(Point point);

        public void CleanUp()
        {
            mDrawingBrush.Dispose();
            mGraphics = null;
        }
    }
}
