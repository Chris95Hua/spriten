using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sproc
{
    /// <summary>
    /// Project session
    /// </summary>
    class Project
    {
        private String mName;           // Project name
        private int mWidth, mHeight;    // Canvas resolution
        private static int mLayerID;    // Records layer created for this project/session
        private String mSelectedLayer;     // Selected layer ID
        private float mScale;           // Scale of project for current working view

        static Project()
        {
            // TODO read project/session layerID
            mLayerID = 0;
        }

        public int getNewLayerID()
        {
            return ++mLayerID;
        }

        public Project(int width, int height, String name)
        {
            mWidth = width;
            mHeight = height;
            mName = name;
            //mMask.Add(new Mask(0, 0, String.Format("Layer {0:D2}", mLayerID)));
            mScale = 1;
        }

        public float Scale
        {
            get
            {
                return mScale;
            }
            set
            {
                mScale = value;
            }
        }

        public int Width
        {
            get
            {
                return mWidth;
            }
            set
            {
                mWidth = value;
            }
        }

        public int Height
        {
            get
            {
                return mHeight;
            }
            set
            {
                mHeight = value;
            }
        }

        public String SelectedLayer
        {
            get
            {
                return mSelectedLayer;
            }
            set
            {
                mSelectedLayer = value;
            }
        }

        public void generateSprite()
        {

        }

        public void save()
        {

        }

        public void saveAs()
        {

        }

        public static void open()
        {

        }
    }
}
