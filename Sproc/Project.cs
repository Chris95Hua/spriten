using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sproc
{
    class Project
    {
        private static int mLayerID;
        private String mName;
        private int mWidth, mHeight;
        private int SelectedLayerID { set; get; }

        static Project()
        {
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

        public void open()
        {

        }
    }
}
