using Spriten.CustomControl;
using Spriten.Drawing;
using System.Drawing;

namespace Spriten.Tool
{
    class Eraser : DrawTool
    {
        private static DrawTool mEraser = new Eraser();
        private DrawableMask mDrawable;

        private Eraser() { }

        public static DrawTool GetTool()
        {
            return mEraser;
        }
        
        public override void Initialize(Canvas canvas)
        {
            mDrawable = canvas.SelectedDrawable;
        }
        
        public override Rectangle Use(Rectangle rect)
        {
            int locX = rect.X, locY = rect.Y;

            for (int x = rect.Width - 1; x >= 0; x--)
            {
                for (int y = rect.Height - 1; y >= 0; y--)
                {
                    mDrawable.SetPixel(locX + x, locY + y, 0);
                    mDrawable.SetMaskPixel(locX + x, locY + y, 0);
                }
            }

            mDrawable.IsUpdated = false;

            return rect;
        }
    }
}
