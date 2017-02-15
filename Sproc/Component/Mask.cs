using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sproc.Component
{
    class Mask : Layer
    {
        // TODO: unified size for the project
        private Boolean mMirrorX, mMirrorY;
        private Image mMaskingData, mColourData;
        // TODO: use Property to replace int here, enabling masking for both colour and pixel block
        // masking type - int/char
        // colour - int[3] (RGBA) -1 to indicate random
        
        public Mask(int width, int height, String name) : base(width, height, name, false)
        {
            mMaskingData = new Bitmap(width, height);
            mGraphics = Graphics.FromImage(mMaskingData);
        }
        /**
        public Mask(int width, int height, String name, Boolean mirrorX, Boolean mirrorY)
        {
            mMirrorX = mirrorX;
            mMirrorY = mirrorY;

            mMaskingData = new Bitmap(width, height);
            mGraphics = Graphics.FromImage(mMaskingData);
        }

        public Mask(int width, int height, String name, Boolean mirrorX, Boolean mirrorY, int defaultValue = 0)
        {
            mMirrorX = mirrorX;
            mMirrorY = mirrorY;

            mMaskingData = new Bitmap(width, height);
            mGraphics = Graphics.FromImage(mMaskingData);
        }
    */
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
    }
}
