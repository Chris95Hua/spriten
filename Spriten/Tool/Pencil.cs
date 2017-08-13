using System.Drawing;

using Spriten.Drawing;
using Spriten.Utility;
using Spriten.Data;
using Spriten.CustomControl;

namespace Spriten.Tool
{
    class Pencil : DrawTool
    {
        private static DrawTool mPencil = new Pencil();
        private int maskColor, argb;
        private DrawableMask mDrawable;

        private Pencil() { }

        public static DrawTool GetTool()
        {
            return mPencil;
        }

        public void Initialize(Canvas canvas)
        {
            mDrawable = canvas.SelectedDrawable;

            switch (User.MaskMode)
            {
                case SpriteHelper.Mask.Body:
                    maskColor = User.MaskBody.ToArgb();
                    break;
                case SpriteHelper.Mask.BorderBody:
                    maskColor = User.MaskBorderBody.ToArgb();
                    break;
                case SpriteHelper.Mask.EmptyBody:
                    maskColor = User.MaskEmptyBody.ToArgb();
                    break;
                default:
                    maskColor = User.MaskBorder.ToArgb();
                    break;
            }
            
            argb = ImageHelper.PremultiplyAlpha(User.ForegroundColor, User.PenOpacity);
        }

        public Rectangle Use(Rectangle rect)
        {
            int locX = rect.X, locY = rect.Y;

            for (int x = rect.Width - 1; x >= 0 && argb != 0; x--)
            {
                for (int y = rect.Height - 1; y >= 0; y--)
                {
                    mDrawable.SetPixel(locX + x, locY + y, argb);
                    mDrawable.SetMaskPixel(locX + x, locY + y, maskColor);
                }
            }

            mDrawable.IsUpdated = false;

            return rect;
        }
    }
}
