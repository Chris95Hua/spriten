using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

using Spriten.Utility;
using Spriten.Data;
using Spriten.Tool;

namespace Spriten.Drawing
{
    [Serializable]
    public class LayerMask : DrawableMask, ISerializable
    {
        public override Bitmap Bitmap { get; set; }
        public override Bitmap Mask { get; set; }
        public int[] BitmapBits { get; private set; }
        public int[] MaskBitmapBits { get; private set; }
        public byte[] MaskBytes { get; private set; }
        int mOpacity = 100;
        private GCHandle BitsHandle { get; set; }
        private GCHandle MaskHandle { get; set; }

        public LayerMask() { }

        public LayerMask(SerializationInfo info, StreamingContext context)
        {
            Project = info.GetValue("Project", typeof(Project)) as Project;
            mOpacity = info.GetInt32("Opacity");
            Name = info.GetString("Name");
            BitmapBits = info.GetValue("Bitmap", typeof(int[])) as int[];
            Locked = info.GetBoolean("Lock");
            Visible = info.GetBoolean("Visible");
            Parent = info.GetValue("Parent", typeof(DrawableMask)) as DrawableMask;

            BitsHandle = GCHandle.Alloc(BitmapBits, GCHandleType.Pinned);
            Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());

            if (IsUsingMask)
                MaskBytes = info.GetValue("Mask", typeof(byte[])) as byte[];
        }

        public LayerMask(string name, Project project, Color color)
        {
            Project = project;
            Name = name;

            if (IsUsingMask)
                CreateMask();

            BitmapBits = new int[Width * Height];
            BitsHandle = GCHandle.Alloc(BitmapBits, GCHandleType.Pinned);
            Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());

            using (Graphics gr = Graphics.FromImage(Bitmap))
            {
                gr.Clear(color);
                if(color != Color.Transparent && IsUsingMask)
                {
                    int fill = User.MaskBody.ToArgb();
                    for(int i = MaskBytes.Length - 1; i >= 0; i--)
                    {
                        MaskBytes[i] = SpriteHelper.BODY;
                        MaskBitmapBits[i] = fill;
                    }
                }
            }
        }

        public LayerMask(string name, Project project, Bitmap bmp, Bitmap mask)
        {
            Project = project;
            Name = name;
            BitmapBits = ImageHelper.GetArgbFromBmp(bmp);
            BitsHandle = GCHandle.Alloc(BitmapBits, GCHandleType.Pinned);
            Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());

            if (mask != null)
            {
                MaskBytes = new byte[Width * Height];
                MaskBitmapBits = ImageHelper.GetArgbFromBmp(mask);
                MaskHandle = GCHandle.Alloc(MaskBitmapBits, GCHandleType.Pinned);
                Mask = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, MaskHandle.AddrOfPinnedObject());

                int border = User.MaskBorder.ToArgb();
                int body = User.MaskBody.ToArgb();
                int borderBody = User.MaskBorderBody.ToArgb();
                int emptyBody = User.MaskEmptyBody.ToArgb();

                for (int i = MaskBytes.Length - 1; i >= 0; i--)
                {
                    if (MaskBitmapBits[i] == border)
                        MaskBytes[i] = SpriteHelper.BORDER;
                    else if (MaskBitmapBits[i] == body)
                        MaskBytes[i] = SpriteHelper.BODY;
                    else if (MaskBitmapBits[i] == borderBody)
                        MaskBytes[i] = SpriteHelper.BORDER_BODY;
                    else if (MaskBitmapBits[i] == emptyBody)
                        MaskBytes[i] = SpriteHelper.EMPTY_BODY;
                }
            }
        }

        private LayerMask(string name, LayerMask copy)
        {
            Project = copy.Project;
            Name = name;
            Parent = copy.Parent;
            Locked = copy.Locked;
            Visible = copy.Visible;
            BitmapBits = (int[])copy.BitmapBits.Clone();
            BitsHandle = GCHandle.Alloc(BitmapBits, GCHandleType.Pinned);
            Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());

            if (copy.IsUsingMask)
            {
                MaskBytes = (byte[])copy.MaskBytes.Clone();
                MaskBitmapBits = (int[])copy.MaskBitmapBits.Clone();
                MaskHandle = GCHandle.Alloc(MaskBitmapBits, GCHandleType.Pinned);
                Mask = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, MaskHandle.AddrOfPinnedObject());
            }
        }

        [OnDeserialized]
        private void SetupMaskBitmap(StreamingContext context)
        {
            if (IsUsingMask)
            {
                MaskBitmapBits = new int[Width * Height];
                MaskHandle = GCHandle.Alloc(MaskBitmapBits, GCHandleType.Pinned);
                Mask = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, MaskHandle.AddrOfPinnedObject());

                int solid = User.MaskBorder.ToArgb();
                int body = User.MaskBody.ToArgb();
                int solidBody = User.MaskBorderBody.ToArgb();
                int emptyBody = User.MaskEmptyBody.ToArgb();

                for (int i = MaskBytes.Length - 1; i >= 0; i--)
                {
                    switch (MaskBytes[i])
                    {
                        case SpriteHelper.BORDER:
                            MaskBitmapBits[i] = solid;
                            break;
                        case SpriteHelper.BODY:
                            MaskBitmapBits[i] = body;
                            break;
                        case SpriteHelper.BORDER_BODY:
                            MaskBitmapBits[i] = solidBody;
                            break;
                        case SpriteHelper.EMPTY_BODY:
                            MaskBitmapBits[i] = emptyBody;
                            break;
                    }
                }
            }
        }

        public override void Insert(int index, DrawableMask drawable)
        {
            // do nothing
        }

        public override void Insert(int index, List<DrawableMask> drawables)
        {
            // do nothing
        }

        public override void Remove(DrawableMask drawable)
        {
            // do nothing
        }

        public override void SetPixel(int x, int y, int argb)
        {
            if (!Locked && Visible && x >= 0 && x < Width && y >= 0 && y < Height)
            {
                int index = x + (y * Width);

                BitmapBits[index] = ImageHelper.BlendAlpha(argb, BitmapBits[index]);
            }
        }

        public override void SetMaskPixel(int x, int y, int argb)
        {
            if (!Disposed && IsUsingMask && !Locked && Visible && x >= 0 && x < Width && y >= 0 && y < Height)
            {
                int index = x + (y * Width);
                MaskBitmapBits[index] = argb;

                if (User.ToolMode == ToolMode.Erase)
                    MaskBytes[index] = SpriteHelper.EMPTY;
                else if (User.MaskMode == SpriteHelper.Mask.Border)
                    MaskBytes[index] = SpriteHelper.BORDER;
                else if (User.MaskMode == SpriteHelper.Mask.Body)
                    MaskBytes[index] = SpriteHelper.BODY;
                else if (User.MaskMode == SpriteHelper.Mask.EmptyBody)
                    MaskBytes[index] = SpriteHelper.EMPTY_BODY;
                else if (User.MaskMode == SpriteHelper.Mask.BorderBody)
                    MaskBytes[index] = SpriteHelper.BORDER_BODY;
            }
        }

        public override int GetPixel(int x, int y)
        {
            if (Visible && x >= 0 && x < Width && y >= 0 && y < Height)
                return BitmapBits[x + (y * Width)];
            else
                return -1;
        }

        public override int GetMaskPixel(int x, int y)
        {
            if (IsUsingMask && Visible && x >= 0 && x < Width && y >= 0 && y < Height)
                return MaskBitmapBits[x + (y * Width)];
            else
                return -1;
        }

        public override void ReplaceMaskPixel(byte type, int argb)
        {
            if (IsUsingMask)
            {
                for (int i = MaskBitmapBits.Length - 1; i >= 0; i--)
                {
                    if (MaskBytes[i] == type)
                        MaskBitmapBits[i] = argb;
                }
            }
        }

        public override void Dispose()
        {
            if (Disposed)
                return;

            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
            mThumbnailGraphics.Dispose();
            mThumbnail.Dispose();

            if (IsUsingMask)
                DisposeMask();          
        }

        public override DrawableMask GetCopy(string name)
        {
            return new LayerMask(name, this);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Project", Project);
            info.AddValue("Opacity", mOpacity);
            info.AddValue("Name", Name);
            info.AddValue("Bitmap", BitmapBits);
            info.AddValue("Lock", Locked);
            info.AddValue("Visible", Visible);
            info.AddValue("Parent", Parent);

            if (IsUsingMask)
                info.AddValue("Mask", MaskBytes);
        }

        private void CreateMask()
        {
            MaskBytes = new byte[Width * Height];
            MaskBitmapBits = new int[Width * Height];
            MaskHandle = GCHandle.Alloc(MaskBitmapBits, GCHandleType.Pinned);
            Mask = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, MaskHandle.AddrOfPinnedObject());

            // if image exists
            if (Bitmap != null)
            {
                int borderArgb = User.MaskBorder.ToArgb();

                for(int i = BitmapBits.Length - 1; i >= 0; i--)
                {
                    if(BitmapBits[i] != 0)
                    {
                        MaskBytes[i] = SpriteHelper.BORDER;
                        MaskBitmapBits[i] = borderArgb;
                    }
                }
            }
        }

        private void DisposeMask()
        {
            Array.Clear(MaskBytes, 0, MaskBytes.Length);
            MaskBitmapBits = null;
            Mask.Dispose();
            MaskHandle.Free();
        }

        #region Properties

        public override int Opacity
        {
            get
            {
                if (mOpacity > 100)
                    mOpacity = 100;
                else if (mOpacity < 1)
                    mOpacity = 1;
                return mOpacity;
            }
            set
            {
                mOpacity = value;
            }
        }

        public override bool IsNested
        {
            get
            {
                return false;
            }
        }

        public override bool IsLayer
        {
            get
            {
                return true;
            }
        }

        // TODO rerender thumbnail to show Mask
        public override Image Thumbnail
        {
            get
            {
                if(!Disposed && !IsUpdated)
                {
                    mThumbnailGraphics.FillRectangle(ImageHelper.ThumbnailBgBrush, Project.ThumbnailX, Project.ThumbnailY, Project.ThumbnailWidth, Project.ThumbnailHeight);
                    mThumbnailGraphics.DrawImage(Bitmap, Project.ThumbnailX, Project.ThumbnailY, Project.ThumbnailWidth, Project.ThumbnailHeight);

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
                if (value)
                    CreateMask();
                else
                    DisposeMask();
            }
        }

        #endregion
    }
}