using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sproc
{
    public partial class Sproc : Form
    {
        private Project mSession;
        private Layer mCanvas;
        public Point mCurMousePos = new Point();
        public Point mOldMousePos = new Point();


        //public Pen pen = new Pen(Color.Black, 1);
        // set a single pixel
        //e.Graphics.FillRectangle(aBrush, x, y, 1, 1);
        //public Pen eraser = new Pen(Color.Transparent, 5);

        public Sproc()
        {
            InitializeComponent();
            //pen.SetLineCap(System.Drawing.Drawing2D.LineCap.Square, System.Drawing.Drawing2D.LineCap.Square, System.Drawing.Drawing2D.DashCap.Flat);
        }

        private void btn_addLayer_Click(object sender, EventArgs e)
        {
            if (mCanvas != null)
            {
                //User._UserMode = User.ERASE;
                mCanvas.Controls.Add(createLayer(mSession.getNewLayerID(), false));
            }
            // show invalid command
        }

        private void btn_removeLayer_Click(object sender, EventArgs e)
        {
            if (mCanvas != null)
            {
                TreeNode selectedNode = tree_layers.SelectedNode;

                if (selectedNode != null)
                {
                    mCanvas.Controls.RemoveByKey(selectedNode.Tag.ToString());
                    tree_layers.Nodes.Remove(selectedNode);
                }
                else
                {
                    // node did not exists
                }
            }
            else
            {
                // show invalid command
            }
        }

        private void getMouseLocation_MouseDown(object sender, MouseEventArgs e)
        {
            mOldMousePos = e.Location;
        }

        private void moveCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // move canvas
            if (e.Button == MouseButtons.Middle)
            {
                mCanvas.Left += e.X - mOldMousePos.X;
                mCanvas.Top += e.Y - mOldMousePos.Y;
            }
        }

        private void mainFileNew_Click(object sender, EventArgs e)
        {
            if (mCanvas != null)
            {
                // new form or clear this form
                MessageBox.Show("canvas existed");
            }
            else
            {
                mCanvas = createCanvas(256, 256);

                int x = (this.Width - mCanvas.Width) / 2;
                int y = (this.Height - mCanvas.Height) / 2;
                mCanvas.Location = new Point(x, y);
                mCanvas.MouseClick += new MouseEventHandler(getMouseLocation_MouseDown);
                mCanvas.MouseMove += new MouseEventHandler(moveCanvas_MouseMove);

                this.Controls.Add(mCanvas);

                mSession = new Project(mCanvas.Width, mCanvas.Height, "Test");

                //mCanvas.Controls.Add(createLayer(mSession.getNewLayerID(), false));
            }
        }

        /// <summary>
        /// Create canvas panel
        /// </summary>
        /// <param name="width">Width of the canvas</param>
        /// <param name="height">Height of the canvas</param>
        /// <param name="solid">Whether to fill background with solid colou</param>
        /// <param name="color">Color to be used to fill the background</param>
        /// <returns>Canvas panel</returns>
        private Layer createCanvas(int width, int height, Boolean solid = false, Color? color = null)
        {
            Layer canvas = new Layer(width, height, "canvas", !solid);
            canvas.Width = width;
            canvas.Height = height;

            if (solid)
            {
                canvas.BackColor = color ?? Color.White;
            }
            else
            {
                canvas.BackgroundImage = createTiledBackground(width, height);
            }

            return canvas;
        }

        /// <summary>
        /// Create tiled background to indicate alpha transparency
        /// </summary>
        /// <param name="width">Width of the image to be created</param>
        /// <param name="height">Height of the image to be created</param>
        /// <returns>Image of the tiled background</returns>
        private Image createTiledBackground(int width, int height)
        {
            int tileSize = 20;
            SolidBrush color1 = new SolidBrush(Color.LightGray);
            SolidBrush color2 = new SolidBrush(Color.GhostWhite);

            // tile
            Image tile = new Bitmap(tileSize * 2, tileSize * 2);
            Graphics tileGraphics = Graphics.FromImage(tile);
            tileGraphics.FillRectangle(color1, 0, 0, tileSize, tileSize);
            tileGraphics.FillRectangle(color2, tileSize, 0, tileSize, tileSize);
            tileGraphics.FillRectangle(color2, tileSize, 0, tileSize, tileSize);
            tileGraphics.FillRectangle(color1, tileSize, tileSize, tileSize, tileSize);

            // tiled tile
            Image alphaBg = new Bitmap(width, height);
            Graphics alphaBgGraphics = Graphics.FromImage(alphaBg);
            TextureBrush tBrush = new TextureBrush(tile);
            tBrush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile ;
            alphaBgGraphics.FillRectangle(tBrush, new Rectangle(0, 0, width, height));

            // dispose brushes and graphics
            color1.Dispose();
            color2.Dispose();
            tileGraphics.Dispose();
            alphaBgGraphics.Dispose();

            return alphaBg;
        }

        private Layer createLayer(int id, Boolean transparent = true)
        {
            Layer layer = new Layer(mCanvas.Width, mCanvas.Height, id.ToString(), transparent);
            layer.Location = new Point(0, 0);
            layer.MouseDown += getMouseLocation_MouseDown;
            layer.MouseMove += moveCanvas_MouseMove;

            TreeNode newLayer = new TreeNode("Layer " + id);
            newLayer.Tag = id;
            tree_layers.Nodes.Add(newLayer);

            return layer;
        }
    }
}
