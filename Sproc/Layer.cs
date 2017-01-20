using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sproc
{
    public partial class Layer : Control
    {
        protected String mName;
        protected Image mImage;
        protected Graphics mGraphics;
        protected Boolean mLocked;
        protected Boolean mTransparent;

        public Layer(int width, int height, String name, Boolean transparent)
        {
            this.Width = width;
            this.Height = height;
            this.Name = name;
            mName = name;
            mTransparent = transparent;

            mImage = new Bitmap(width, height);

            mGraphics = Graphics.FromImage(mImage);

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint, true);

            SetStyle(ControlStyles.UserMouse, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            if (mTransparent)
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            }

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            var bitMap = new Bitmap(mImage);
            // by default the background color for bitmap is white
            // you can modify this to follow your image background 
            // or create a new Property so it can dynamically assigned
            bitMap.MakeTransparent(Color.White);

            mImage = bitMap;
            
            Graphics g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.GammaCorrected;

            float[][] mtxItens = {
            new float[] {1,0,0,0,0},
            new float[] {0,1,0,0,0},
            new float[] {0,0,1,0,0},
            new float[] {0,0,0,1,0},
            new float[] {0,0,0,0,1}};

            ColorMatrix colorMatrix = new ColorMatrix(mtxItens);

            ImageAttributes imgAtb = new ImageAttributes();
            imgAtb.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);

            g.DrawImage(mImage,
                        ClientRectangle,
                        0.0f,
                        0.0f,
                        mImage.Width,
                        mImage.Height,
                        GraphicsUnit.Pixel,
                        imgAtb);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            Graphics g = pevent.Graphics;

            if (Parent != null)
            {
                BackColor = mTransparent ? Color.Transparent : Color.White;
                int index = Parent.Controls.GetChildIndex(this);

                for (int i = Parent.Controls.Count - 1; i > index; i--)
                {
                    Control c = Parent.Controls[i];
                    if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                    {
                        Bitmap bmp = new Bitmap(c.Width, c.Height, g);
                        c.DrawToBitmap(bmp, c.ClientRectangle);

                        g.TranslateTransform(c.Left - Left, c.Top - Top);
                        g.DrawImageUnscaled(bmp, Point.Empty);
                        g.TranslateTransform(Left - c.Left, Top - c.Top);
                        bmp.Dispose();
                    }
                }
            }
            else
            {
                g.Clear(Parent.BackColor);
                g.FillRectangle(new SolidBrush(Color.FromArgb(255, Color.Transparent)), this.ClientRectangle);
            }
        }
        
        public Image Image
        {
            get
            {
                return mImage;
            }
            set
            {
                mImage = value;
                this.Invalidate();
            }
        }

        public Boolean Locked
        {
            get
            {
                return mLocked;
            }
            set
            {
                mLocked = value;
            }
        }

        public Boolean Transparent
        {
            get
            {
                return mTransparent;
            }
            set
            {
                mTransparent = value;
            }
        }

        // Events
        public void paint(object sender, MouseEventArgs e)
        {

        }
    }
}
