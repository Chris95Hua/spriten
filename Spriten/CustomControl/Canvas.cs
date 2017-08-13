using Spriten.Data;
using Spriten.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System;
using Spriten.Tool;

namespace Spriten.CustomControl
{
    public partial class Canvas : Control
    {
        public Project Project { get; private set; }
        private Pen mCellGridPen;
        public Point MouseLoc { get; set; }
        public float CanvasScale { get; private set; }
        public int BrushCenterLoc { get; private set; }
        public int BrushScale { get; private set; }
        public Rectangle BrushRectangle { get; set; }
        public DrawableMask SelectedDrawable { get; set; }
        public int[] BitmapBits { get; private set; }
        public Bitmap ImageBuffer { get; private set; }
        private GCHandle BitsHandle { get; set; }
        private Graphics mBufferGraphics;
        private bool mUseCachedImage;

        #region Constructor

        public Canvas(Project project)
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw, true);

            CanvasScale = 1f;
            Project = project;
            Width = project.Width;
            Height = project.Height;
            Cursor = Cursors.Cross;

            mCellGridPen = new Pen(Color.Gray);
            BitmapBits = new int[project.Width * project.Height];
            BitsHandle = GCHandle.Alloc(BitmapBits, GCHandleType.Pinned);
            ImageBuffer = new Bitmap(project.Width, project.Height, project.Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
            mBufferGraphics = Graphics.FromImage(ImageBuffer);
            mBufferGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            mBufferGraphics.PixelOffsetMode = PixelOffsetMode.Half;
            mBufferGraphics.SmoothingMode = SmoothingMode.None;

            DrawCachedImage = true;
            UpdateBrushOutline();
        }

        #endregion

        public void RedrawCachedImage()
        {
            mBufferGraphics.Clear(Color.Transparent);
            for (int i = Project.DrawableList.Count - 1; i >= 0; i--)
            {
                if (!Project.DrawableList[i].Disposed && Project.DrawableList[i].Visible)
                {
                    if (Project.IsUsingMask && User.IsMaskingMode)
                        mBufferGraphics.DrawImageUnscaled(Project.DrawableList[i].Mask, 0, 0, Project.Width, Project.Height);
                    else
                        mBufferGraphics.DrawImageUnscaled(Project.DrawableList[i].Bitmap, 0, 0, Project.Width, Project.Height);
                }
            }
        }

        public int GetPixel(int x, int y)
        {
            if (x >= 0 && x < Project.Width && y >= 0 && y < Project.Height)
                return BitmapBits[x + (y * Project.Width)];
            else
                return -1;
        }

        #region Event

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            pe.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            pe.Graphics.SmoothingMode = SmoothingMode.None;

            if (DrawCachedImage)
                pe.Graphics.DrawImage(ImageBuffer, ClientRectangle, 0f, 0f, Project.Width, Project.Height, GraphicsUnit.Pixel);
            else
            {
                for (int i = Project.DrawableList.Count - 1; i >= 0; i--)
                {
                    if (!Project.DrawableList[i].Disposed && Project.DrawableList[i].Visible)
                    {
                        if (Project.IsUsingMask && User.IsMaskingMode)
                            pe.Graphics.DrawImage(Project.DrawableList[i].Mask, ClientRectangle, 0f, 0f, Project.Width, Project.Height, GraphicsUnit.Pixel);
                        else
                            pe.Graphics.DrawImage(Project.DrawableList[i].Bitmap, ClientRectangle, 0f, 0f, Project.Width, Project.Height, GraphicsUnit.Pixel);
                    }
                }
            }

            // cell grid
            if (User.ShowPixelGrid && CanvasScale >= 10f)
            {
                int totalCells = Project.Width * Project.Height;
                float start, end = totalCells * CanvasScale;
                //System.Diagnostics.Debug.WriteLine(totalCells);
                for (int i = totalCells - 1; i > 0; i--)
                {
                    start = i * CanvasScale;
                    pe.Graphics.DrawLine(mCellGridPen, 0f, start, end, start);
                    pe.Graphics.DrawLine(mCellGridPen, start, 0f, start, end);
                }
            }

            // brush
            if (User.ShowBrushOutline && MouseLoc != Point.Empty && CanvasScale > 5)
                pe.Graphics.DrawRectangle(Pens.Black, BrushRectangle);
        }

        #endregion

        public void Cleanup()
        {
            Project.Cleanup();
            mCellGridPen.Dispose();
            mBufferGraphics.Dispose();
            ImageBuffer.Dispose();
            BitsHandle.Free();
        }

        /// <summary>
        /// Calculate cursor location relative to canvas regardless of canvas scale
        /// </summary>
        /// <param name="cursorLocation">Cursor location relative to canvas</param>
        /// <returns>Cursor location</returns>
        public Point GetRelativePoint(Point location)
        {
            if (Height == Project.Height)
                return location;

            int x = (int)Math.Floor(location.X / CanvasScale);
            int y = (int)Math.Floor(location.Y / CanvasScale);

            return new Point(x, y);
        }

        public void SetScaleFactor(float factor)
        {
            Width = Project.Width;
            Height = Project.Height;
            Scale(new SizeF(factor, factor));
            CanvasScale = factor;

            UpdateBrushOutline();
        }

        public void UpdateBrushOutline()
        {
            int penSize = 1;

            switch (User.ToolMode)
            {
                case ToolMode.Draw:
                    penSize = User.PenSize;
                    break;
                case ToolMode.Erase:
                    penSize = User.PenSize;
                    break;
            }

            float newBrushScale = CanvasScale * penSize;
            BrushScale = (int)newBrushScale;
            BrushCenterLoc = (int)(CanvasScale / 2);
        }

        public bool DrawCachedImage
        {
            set
            {
                mUseCachedImage = value;

                if (value)
                    RedrawCachedImage();
            }
            get
            {
                return mUseCachedImage;
            }
        }
    }
}
