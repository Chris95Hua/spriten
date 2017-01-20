using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sproc
{
    class Mask : LayerOld
    {
        // TODO: unified size for the project
        private int mWidth, mHeight;
        private Boolean mMirrorX, mMirrorY;
        private Image mMaskingData, mColourData;
        private Graphics mGraphics;
        // TODO: use Property to replace int here, enabling masking for both colour and pixel block
        // masking type - int/char
        // colour - int[3] (RGBA) -1 to indicate random
        private List<List<int>> mMask = new List<List<int>>();
        
        public Mask(int width, int height, String name)
        {
            mWidth = width;
            mHeight = height;
            mName = name;

            mMaskingData = new Bitmap(mWidth, mHeight);
            mGraphics = Graphics.FromImage(mMaskingData);

            
        }

        public Mask(int width, int height, String name, Boolean mirrorX, Boolean mirrorY)
        {
            mWidth = width;
            mHeight = height;
            mName = name;
            mMirrorX = mirrorX;
            mMirrorY = mirrorY;

            mMaskingData = new Bitmap(mWidth, mHeight);
            mGraphics = Graphics.FromImage(mMaskingData);
        }

        public Mask(int width, int height, String name, Boolean mirrorX, Boolean mirrorY, int defaultValue = 0)
        {
            mWidth = width;
            mHeight = height;
            mName = name;
            mMirrorX = mirrorX;
            mMirrorY = mirrorY;

            mMaskingData = new Bitmap(mWidth, mHeight);
            mGraphics = Graphics.FromImage(mMaskingData);
        }

        /// <summary>
        /// Toggle mirror for X axis
        /// </summary>
        public void toggleMirrorX()
        {
            mMirrorX = !mMirrorX;
        }

        /// <summary>
        /// Toggle mirror for Y axis
        /// </summary>
        public void toggleMirrorY()
        {
            mMirrorY = !mMirrorY;
        }

        public Boolean isMirroringX()
        {
            return mMirrorX;
        }

        public Boolean isMirroringY()
        {
            return mMirrorY;
        }

        // masking mode/painting mode?
        // -1 = always border
        // 0 = empty
        // 1 = randomly chosen empty/body
        // 2 = randomly chosen border/body
        public void paint(int x, int y, int value)
        {
            if (x <= mWidth && y <= mHeight)
            {
                mMask[(int)y][(int)x] = value;
            }
        }

        public int getMaskProperty(int x, int y)
        {
            if (x <= mWidth && y <= mHeight)
            {
                return mMask[(int)y][(int)x];
            }
            else
            {
                return -2;
            }
        }
    }
}
