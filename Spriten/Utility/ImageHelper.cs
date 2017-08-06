using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Spriten.Utility
{
    public static class ImageHelper
    {
        public static Image CanvasBg { get; set; }
        public static TextureBrush ThumbnailBgBrush { get; set; }
        public static Brush GroupBrush { get; private set; }
        public static Rectangle GroupRect { get; private set; }

        public static void CreateTextureBrushes()
        {
            // cache tiled background and brush as they'll be used a lot
            CanvasBg = CreateTiledBackground(30);
            ThumbnailBgBrush = new TextureBrush(CreateTiledBackground(10), WrapMode.Tile);
            GroupBrush = new SolidBrush(ThemeHelper.TreeListBackground);
            GroupRect = new Rectangle(22, 22, 16, 16);
        }

        public static void DisposeTextureBrushes()
        {
            CanvasBg.Dispose();
            ThumbnailBgBrush.Dispose();
            GroupBrush.Dispose();
        }

        /// <summary>
        /// Create tiled background to indicate alpha transparency
        /// </summary>
        /// <param name="tileSize">Width and height of the tile to be drawn (in pixel)</param>
        /// <returns>Image of the tiled background</returns>
        public static Image CreateTiledBackground(int tileSize)
        {
            SolidBrush color1 = new SolidBrush(Color.LightGray);
            SolidBrush color2 = new SolidBrush(Color.GhostWhite);

            // tile
            Image tile = new Bitmap(tileSize * 2, tileSize * 2);
            Graphics tileGraphics = Graphics.FromImage(tile);
            tileGraphics.FillRectangle(color1, 0, 0, tileSize, tileSize);
            tileGraphics.FillRectangle(color2, tileSize, 0, tileSize, tileSize);
            tileGraphics.FillRectangle(color2, 0, tileSize, tileSize, tileSize);
            tileGraphics.FillRectangle(color1, tileSize, tileSize, tileSize, tileSize);

            // dispose brushes and graphics
            color1.Dispose();
            color2.Dispose();
            tileGraphics.Dispose();

            return tile;
        }

        /// <summary>
        /// Convert bitmap to ARGB array
        /// </summary>
        /// <param name="bmp">Bitmap to be converted</param>
        /// <returns>ARGB array of the image</returns>
        public static int[] GetArgbFromBmp(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            //int bytesPerPixel = Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
            int bytesPerPixel = 4;
            int stride = width * bytesPerPixel;
            int totalSize = stride * height;
            byte R, G, B, A;
            int[] argb = new int[width * height];

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppPArgb);

            unsafe
            {
                byte* scan0 = (byte*)data.Scan0.ToPointer();

                for (int i = 0; i < totalSize; i += 4)
                {
                    B = scan0[i];
                    G = scan0[i + 1];
                    R = scan0[i + 2];
                    A = scan0[i + 3];

                    argb[(i / 4)] = Color.FromArgb(A, R, G, B).ToArgb();
                }
            }
            
            bmp.UnlockBits(data);
            bmp.Dispose();

            return argb;
        }

        public static Bitmap GetBmpFromArgb(int[] argb, int width, int height)
        {
            GCHandle handle = GCHandle.Alloc(argb, GCHandleType.Pinned);
            Bitmap output = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, handle.AddrOfPinnedObject());
            handle.Free();
            return output;
        }

        public static Bitmap ResizeBitmap(Bitmap bitmap, int width, int height)
        {
            if (bitmap.Width == width && bitmap.Height == height)
                return bitmap;

            Bitmap resizedBmp = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(resizedBmp);
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphics.PixelOffsetMode = PixelOffsetMode.Half;
            graphics.SmoothingMode = SmoothingMode.None;

            graphics.DrawImage(bitmap, 0, 0, width, height);
            graphics.Dispose();

            return resizedBmp;
        }

        public static int PremultiplyAlpha(Color color, byte alpha)
        {
            if (alpha == byte.MinValue)
                return 0;

            return (alpha << 24) | (MultiplyAlpha(color.R, alpha) << 16) | (MultiplyAlpha(color.G, alpha) << 8) | MultiplyAlpha(color.B, alpha);
        }

        public static byte MultiplyAlpha(int source, byte alpha)
        {
            return (byte)((float)source * alpha / byte.MaxValue + 0.5f);
        }

        public static int BlendAlpha(int forePixel, int backPixel)
        {
            if (forePixel == 0 || backPixel == 0)
                return forePixel;

            byte maxVal = byte.MaxValue;
            int alphaTotal = maxVal * maxVal;
            byte aA = (byte)(forePixel >> 24);
            int aAdiff = byte.MaxValue - aA;
            byte aB = (byte)(backPixel >> 24);
            
            int aOut = aA + (aB * aAdiff / maxVal);
            int rOut = (((byte)(forePixel >> 16)) * aA / maxVal) + (((byte)(backPixel >> 16)) * aB * aAdiff / alphaTotal);
            int gOut = (((byte)(forePixel >> 8)) * aA / maxVal) + (((byte)(backPixel >> 8)) * aB * aAdiff / alphaTotal);
            int bOut = (((byte)forePixel) * aA / maxVal) + (((byte)backPixel) * aB * aAdiff / alphaTotal);
            
            return (aOut << 24) | (rOut << 16) | (gOut << 8) | bOut;
        }
    }
}
