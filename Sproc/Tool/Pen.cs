using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sproc.Tool
{
    class Pen : IDraw
    {
        private static Pen mPen = new Pen();
        SolidBrush mPenBrush;

        private Pen() { }

        public static Pen GetTool()
        {
            return mPen;
        }

        public void Initialize()
        {
            mPenBrush = new SolidBrush(User._PrimaryColor);
        }

        public void PaintPoint(Point point, Graphics graphics)
        {
            graphics.FillRectangle(mPenBrush, point.X, point.Y, 1f, 1f);
        }

        public void CleanUp()
        {
            mPenBrush.Dispose();
        }
    }
}
