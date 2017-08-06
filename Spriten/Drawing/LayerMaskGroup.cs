using Spriten.Data;
using Spriten.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.Serialization;

namespace Spriten.Drawing
{
    [Serializable]
    public class LayerMaskGroup : DrawableMask, ISerializable
    {
        public List<DrawableMask> DrawableMaskList { get; private set; }
        private Bitmap mBitmap, mMask;
        private Graphics mImageGraphics, mMaskGraphics;

        #region Constructors

        public LayerMaskGroup() { }

        public LayerMaskGroup(SerializationInfo info, StreamingContext context) : this(info.GetString("Name"), info.GetValue("Project", typeof(Project)) as Project)
        {
            Parent = info.GetValue("Parent", typeof(DrawableMask)) as DrawableMask;
            DrawableMaskList = info.GetValue("DrawableMaskList", typeof(List<DrawableMask>)) as List<DrawableMask>;
            Locked = info.GetBoolean("Lock");
            Visible = info.GetBoolean("Visible");
        }

        public LayerMaskGroup(string name, Project project)
        {
            Project = project;
            Name = name;
            DrawableMaskList = new List<DrawableMask>();

            IsUsingMask = project.IsUsingMask;

            mBitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
            mImageGraphics = Graphics.FromImage(mBitmap);
            mImageGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            mImageGraphics.SmoothingMode = SmoothingMode.None;
            mImageGraphics.PixelOffsetMode = PixelOffsetMode.Half;
        }

        private LayerMaskGroup(string name, LayerMaskGroup group) : this(name, group.Project)
        {
            Parent = group.Parent;
            Locked = group.Locked;
            Visible = group.Visible;
            int totalLayer = group.DrawableMaskList.Count;
            List<DrawableMask> duplicate = new List<DrawableMask>(group.DrawableMaskList.Count);

            for (int i = 0; i < totalLayer; i++)
            {
                string itemName = group.DrawableMaskList[i].Name;
                DrawableMask copy = group.DrawableMaskList[i].GetCopy(itemName);
                copy.Parent = this;
                duplicate.Add(copy);
            }

            DrawableMaskList.AddRange(duplicate);
        }

        #endregion

        public override void Insert(int index, DrawableMask drawable)
        {
            drawable.Parent = this;
            DrawableMaskList.Insert(index, drawable);
            IsUpdated = false;
        }

        public override void Insert(int index, List<DrawableMask> drawables)
        {
            drawables.ForEach(drawable => drawable.Parent = this);
            DrawableMaskList.InsertRange(index, drawables);
            IsUpdated = false;
        }
        
        public override void Remove(DrawableMask drawable)
        {
            DrawableMaskList.Remove(drawable);
            IsUpdated = false;
        }

        public override void SetPixel(int x, int y, int argb)
        {
            // do nothing
        }

        public override void SetMaskPixel(int x, int y, int argb)
        {
            // do nothing
        }

        public override int GetPixel(int x, int y)
        {
            int pixel = 0;

            for (int i = DrawableMaskList.Count - 1; i >= 0; i--)
            {
                pixel = DrawableMaskList[i].GetPixel(x, y);

                if (pixel != 0)
                    return pixel;
            }

            return pixel;
        }

        public override int GetMaskPixel(int x, int y)
        {
            int pixel = 0;

            for (int i = DrawableMaskList.Count - 1; IsUsingMask && i >= 0; i--)
            {
                pixel = DrawableMaskList[i].GetMaskPixel(x, y);

                if (pixel != 0)
                    return pixel;
            }

            return pixel;
        }

        public override void ReplaceMaskPixel(byte type, int argb)
        {
            for(int i = DrawableMaskList.Count - 1; IsUsingMask && i >= 0; i--)
            {
                DrawableMaskList[i].ReplaceMaskPixel(type, argb);
            }
        }

        public override void Dispose()
        {
            if (Disposed)
                return;

            Disposed = true;

            for (int i = DrawableMaskList.Count; i > 0; i--)
            {
                DrawableMaskList[i - 1].Dispose();
            }

            DisposeMaskResource();

            mImageGraphics.Dispose();
            mThumbnailGraphics.Dispose();
            mBitmap.Dispose();
            mThumbnail.Dispose();
        }

        private void CreateMaskResource()
        {
            mMask = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
            mMaskGraphics = Graphics.FromImage(mMask);
            mMaskGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            mMaskGraphics.SmoothingMode = SmoothingMode.None;
            mMaskGraphics.PixelOffsetMode = PixelOffsetMode.Half;
        }

        private void DisposeMaskResource()
        {
            if (IsUsingMask)
            {
                mMask.Dispose();
                mMaskGraphics.Dispose();
            }
        }

        public override DrawableMask GetCopy(string name)
        {
            return new LayerMaskGroup(name, this);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Project", Project);
            info.AddValue("Name", Name);
            info.AddValue("Lock", Locked);
            info.AddValue("Visible", Visible);
            info.AddValue("Parent", Parent);
            info.AddValue("DrawableMaskList", DrawableMaskList);
        }

        public override Bitmap Bitmap
        {
            get
            {
                mImageGraphics.Clear(Color.Transparent);

                for (int i = DrawableMaskList.Count - 1; i >= 0; i--)
                {
                    if (DrawableMaskList[i].Visible)
                        mImageGraphics.DrawImage(DrawableMaskList[i].Bitmap, 0, 0, Width, Height);
                }

                return mBitmap;
            }

            set
            {
                // do nothing
            }
        }

        public override Bitmap Mask
        {
            get
            {
                mMaskGraphics.Clear(Color.Transparent);

                for (int i = DrawableMaskList.Count - 1; i >= 0; i--)
                {
                    if (DrawableMaskList[i].Visible)
                        mMaskGraphics.DrawImage(DrawableMaskList[i].Mask, 0, 0, Width, Height);
                }

                return mMask;
            }

            set 
            {
                // do nothing
            }
        }

        public override bool IsNested
        {
            get
            {
                return DrawableMaskList.Count > 0;
            }
        }

        public override bool IsLayer
        {
            get
            {
                return false;
            }
        }

        public override Image Thumbnail
        {
            get
            {
                if (!Disposed && !IsUpdated)
                {
                    mThumbnailGraphics.FillRectangle(ImageHelper.ThumbnailBgBrush, Project.ThumbnailX, Project.ThumbnailY, Project.ThumbnailWidth, Project.ThumbnailHeight);

                    for (int i = DrawableMaskList.Count - 1; i >= 0; i--)
                    {
                        if (DrawableMaskList[i].Visible)
                            mThumbnailGraphics.DrawImage(DrawableMaskList[i].Bitmap, Project.ThumbnailX, Project.ThumbnailY, Project.ThumbnailWidth, Project.ThumbnailHeight);
                    }
                    
                    mThumbnailGraphics.FillRectangle(ImageHelper.GroupBrush, ImageHelper.GroupRect);
                    mThumbnailGraphics.DrawImage(Properties.Resources.dark_folder_16, 24, 24, 12, 12);

                    IsUpdated = true;
                }

                return mThumbnail;
            }
        }

        public override bool IsUsingMask
        {
            get
            {
                return Project.IsUsingMask;
            }

            set
            {
                for (int i = DrawableMaskList.Count - 1; i >= 0; i--)
                {
                    DrawableMaskList[i].IsUsingMask = value;
                }

                if (value)
                    CreateMaskResource();
                else
                    DisposeMaskResource();
            }
        }

        public override int Opacity
        {
            get { return 100; }

            set { }
        }
    }
}
