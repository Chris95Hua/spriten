using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;

using Sproc.Component;

namespace Sproc.Tool
{
    class ColorPicker : ITool
    {
        Bitmap mImage;
        BitmapData mImagedata;
        public void Initialize(Layer layer)
        {
            Bitmap mImage = new Bitmap(layer.Image);
            mImagedata = mImage.LockBits(new Rectangle(0, 0, mImage.Width, mImage.Height), ImageLockMode.ReadOnly, mImage.PixelFormat);
        }

        public void Use(Point point)
        {

        }

        public void CleanUp()
        {
            mImage.UnlockBits(mImagedata);
            mImage.Dispose();
        }

        private Color GetColor(BitmapData data)
        {
            unsafe
            {
                byte* ptrSource = (byte*)data.Scan0;

                for (int y = 0; y < data.Height; ++y)
                {
                    for (int x = 0; x < data.Width; ++x)
                    {
                        // windows stores images in BGR pixel order
                        byte r = ptrSource[2];
                        byte g = ptrSource[1];
                        byte b = ptrSource[0];

                        // next pixel in the row
                        ptrSource += 3;
                    }
                }
            }

            return Color.FromArgb(1, 2, 3, 4);
        }

        public unsafe Image ThresholdUA(float thresh)
        {
            byte bitsPerPixel = (byte)Image.GetPixelFormatSize(mImage.PixelFormat);

            /*This time we convert the IntPtr to a ptr*/
            byte* scan0 = (byte*)mImagedata.Scan0.ToPointer();

            for (int i = 0; i < mImagedata.Height; ++i)
            {
                for (int j = 0; j < mImagedata.Width; ++j)
                {
                    byte* data = scan0 + i * mImagedata.Stride + j * bitsPerPixel / 8;

                    //data is a pointer to the first byte of the 3-byte color data
                }
            }

            mImage.UnlockBits(mImagedata);

            return mImage;
        }

    }
}
