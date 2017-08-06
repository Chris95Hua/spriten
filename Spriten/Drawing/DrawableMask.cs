using Spriten.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Spriten.Drawing
{
    [Serializable]
    public abstract class DrawableMask : IDisposable
    {
        public Project Project { get; set; }
        public string Name { get; set; }
        public bool Disposed { get; protected set; }
        public DrawableMask Parent { get; set; }
        public abstract int Opacity { get; set; }
        public abstract bool IsNested { get; }
        public abstract bool IsLayer { get; }
        public abstract Bitmap Bitmap { get; set; }
        public abstract Image Thumbnail { get; }
        public abstract Bitmap Mask { get; set; }
        public abstract bool IsUsingMask { get; set; }
        protected Image mThumbnail;
        protected Graphics mThumbnailGraphics;
        protected bool mThumbnailUpdated, mAlphaLock, mLock, mVisible;

        public DrawableMask()
        {
            mVisible = true;
            mThumbnail = new Bitmap(40, 40);
            mThumbnailGraphics = Graphics.FromImage(mThumbnail);
            mThumbnailGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            mThumbnailGraphics.SmoothingMode = SmoothingMode.None;
            mThumbnailGraphics.PixelOffsetMode = PixelOffsetMode.Half;
        }
        public abstract void Insert(int index, DrawableMask drawable);
        public abstract void Insert(int index, List<DrawableMask> drawables);
        public abstract void Remove(DrawableMask drawable);
        public abstract void SetPixel(int x, int y, int argb);
        public abstract int GetPixel(int x, int y);
        public abstract void SetMaskPixel(int x, int y, int argb);
        public abstract int GetMaskPixel(int x, int y);
        public abstract void ReplaceMaskPixel(byte type, int argb);
        public abstract DrawableMask GetCopy(string name);
        public abstract void Dispose();
        
        public bool IsParent(DrawableMask drawable)
        {
            if (this == drawable)
                return true;

            if (Parent == null)
                return false;

            return Parent.IsParent(drawable);
        }

        public int Width
        {
            get
            {
                return Project.Width;
            }
        }

        public int Height
        {
            get
            {
                return Project.Height;
            }
        }

        public bool IsUpdated {
            get
            {
                return mThumbnailUpdated;
            }

            set
            {
                mThumbnailUpdated = value;

                if (Parent != null)
                    Parent.IsUpdated = value;
            }
        }

        public bool AlphaLocked
        {
            get
            {
                DrawableMask parent = Parent;
                bool hasLockedParent = false;

                while (parent != null && !hasLockedParent)
                {
                    hasLockedParent = parent.AlphaLocked;
                    parent = parent.Parent;
                }

                return (mAlphaLock || hasLockedParent);
            }
            set
            {
                mAlphaLock = value;
            }
        }

        public bool Locked
        {
            get
            {
                DrawableMask parent = Parent;
                bool hasLockedParent = false;

                while (parent != null && !hasLockedParent)
                {
                    hasLockedParent = parent.Locked;
                    parent = parent.Parent;
                }

                return (mLock || hasLockedParent);
            }
            set
            {
                mLock = value;
            }
        }

        public bool Visible
        {
            get
            {
                DrawableMask parent = Parent;
                bool hasVisibleParent = true;

                while (parent != null && hasVisibleParent)
                {
                    parent.IsUpdated = false;
                    hasVisibleParent = parent.Visible;
                    parent = parent.Parent;
                }

                return (mVisible && hasVisibleParent);
            }
            set
            {
                mVisible = value;
            }
        }
    }
}
