using System.Drawing;
using Spriten.Drawing;
using Spriten.Data;
using Spriten.CustomControl;
using Spriten.Utility;

namespace Spriten.Tool
{
    public class Fill : DrawTool
    {
        private static DrawTool mFillTool = new Fill();
        private int mArgbFill, mMaskData, mRegionArgb, width, height, ox, oy, fillWidth, fillHeight;
        private DrawableMask mDrawable;

        private Fill() { }

        public static DrawTool GetTool()
        {
            return mFillTool;
        }

        public void Initialize(Canvas canvas)
        {
            mDrawable = canvas.SelectedDrawable;

            switch (User.MaskMode)
            {
                case SpriteHelper.Mask.BorderBody:
                    mMaskData = User.MaskBorderBody.ToArgb();
                    break;
                case SpriteHelper.Mask.EmptyBody:
                    mMaskData = User.MaskEmptyBody.ToArgb();
                    break;
                default:
                    mMaskData = User.MaskBorder.ToArgb();
                    break;
            }

            width = mDrawable.Width;
            height = mDrawable.Height;
            mArgbFill = User.ForegroundColor.ToArgb();
        }

        public Rectangle Use(Rectangle rect)
        {
            int x = rect.X, y = rect.Y;

            mRegionArgb = mDrawable.GetPixel(x, y);
            if (mRegionArgb != mArgbFill)
                InitFill(x, y);

            mDrawable.IsUpdated = false;

            //Console.WriteLine("startX:" + ox + " startY:" + oy + " fillWidth:" + fillWidth + " fillHeight:" + fillHeight);
            //return new Rectangle(ox, oy, fillWidth, fillHeight);
            return new Rectangle(0, 0, mDrawable.Width, mDrawable.Height);
        }

        /// <summary>
        /// Move to top left
        /// </summary>
        /// <param name="x">Starting x coordinate</param>
        /// <param name="y">Starting y coordinate</param>
        private void InitFill(int x, int y)
        {
            int sx, sy;

            do
            {
                sx = x;
                sy = y;

                // move to top
                while (y > 0 && mDrawable.GetPixel(x, y - 1) == mRegionArgb)
                {
                    y--;
                }

                // move to left
                while (x > 0 && mDrawable.GetPixel(x - 1, y) == mRegionArgb)
                {
                    x--;
                }
            }
            while (x != sx && y != sy);

            FillRegion(x, y);
        }

        /// <summary>
        /// Flood fill at the given coordinates (Adam Milazzo's method)
        /// </summary>
        /// <param name="x">Starting x coordinate</param>
        /// <param name="y">Starting y coordinate</param>
        private void FillRegion(int x, int y)
        {
            int lastRowLength = 0;

            // (x, y) is clear, (x, y - 1) and (x - 1, y) are filled
            // scan down and fill to right
            do
            {
                int rowLength = 0, sx = x;
                int index = x + (y * width);

                // if not first row and left most cell is filled
                if (lastRowLength > 0 && mDrawable.GetPixel(x, y) == mArgbFill)
                {
                    // move to right
                    do
                    {
                        x++;
                    }
                    while (--lastRowLength != 0 && mDrawable.GetPixel(x, y) == mArgbFill);
                    sx = x;
                }
                // left of current cell is not filled
                else
                {
                    for (; x > 0 && mDrawable.GetPixel(x - 1, y) == mRegionArgb; rowLength++, lastRowLength++)
                    {
                        mDrawable.SetPixel(--x, y, mArgbFill);
                        mDrawable.SetMaskPixel(x, y, mMaskData);

                        // if top has unfilled cell, init fill to get to the utmost left and top
                        if (y > 0 && mDrawable.GetPixel(x, y - 1) == mRegionArgb)
                        {
                            InitFill(x, y - 1);
                        }
                    }
                }

                // scan current row
                for (; sx < width && mDrawable.GetPixel(sx, y) == mRegionArgb; rowLength++, sx++)
                {
                    mDrawable.SetPixel(sx, y, mArgbFill);
                    mDrawable.SetMaskPixel(sx, y, mMaskData);
                }

                // current row length is shorter than previous row length, look rightwards
                if (rowLength < lastRowLength)
                {
                    for (int end = x + lastRowLength; ++sx < end;)
                    {
                        if (mDrawable.GetPixel(sx, y) == mRegionArgb)
                        {
                            FillRegion(sx, y);
                        }
                    }
                }
                // current row length is longer than previous row length, look above
                else if (rowLength > lastRowLength && y > 0)
                {
                    for (int ux = x + lastRowLength; ++ux < sx;)
                    {
                        if (mDrawable.GetPixel(ux, y - 1) == mRegionArgb)
                        {
                            InitFill(ux, y - 1);
                        }
                    }
                }

                lastRowLength = rowLength;

                // determine the row length and fill height to refresh
                if (rowLength > fillWidth)
                {
                    fillWidth = rowLength;
                    ox = x;
                }
                if (y > fillHeight)
                {
                    fillHeight = y + 1;
                    oy = y - fillHeight + 1;
                }
            }
            while (lastRowLength > 0 && ++y < height);
        }
    }
}