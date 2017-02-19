using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sproc.Component;
using Sproc.Tool;
using Sproc.Utility;

namespace Sproc
{
    public partial class Sproc : Form
    {
        private Project mSession;
        private Layer mCanvas;
        public Point mCurMousePos = new Point();
        public Point mOldMousePos = new Point();
        ITool tool;

        public Sproc()
        {
            InitializeComponent();
        }

        private void btn_addLayer_Click(object sender, EventArgs e)
        {
            if (mCanvas != null)
            {
                mCanvas.Controls.Add(createLayer(mSession.getNewLayerID(), true));

                Logger.Log("Layer added");
            }
        }

        private void btn_removeLayer_Click(object sender, EventArgs e)
        {
            if (mCanvas != null)
            {
                TreeNode selectedNode = tree_layers.SelectedNode;

                if (selectedNode != null)
                {
                    mCanvas.Controls.Find(selectedNode.Tag.ToString(), true).First().Dispose();
                    //mCanvas.Controls.RemoveByKey(selectedNode.Tag.ToString());
                    tree_layers.Nodes.Remove(selectedNode);

                    Logger.Log("Layer \"" + selectedNode.Text + "\" removed");
                }
                else
                {
                    // node did not exists
                }
            }
        }


        private void getMouseLocation_MouseDown(object sender, MouseEventArgs e)
        {
            mOldMousePos = e.Location;

            if (e.Button == MouseButtons.Left)
            {
                Layer selectedLayer = (Layer)mCanvas.Controls.Find(mSession.SelectedLayer, true).First();
                tool.Initialize(selectedLayer);
            }
        }

        private void canvasAction_MouseMove(object sender, MouseEventArgs e)
        {
            // move canvas
            if (e.Button == MouseButtons.Middle)
            {
                mCanvas.Left += e.X - mOldMousePos.X;
                mCanvas.Top += e.Y - mOldMousePos.Y;
            }

            else if (e.Button == MouseButtons.Left)
            {
                TreeNode selectedNode = tree_layers.SelectedNode;

                if (selectedNode != null)
                {
                    mCurMousePos = e.Location;
                    
                    tool.Use(getCanvasRelativePoint(e.Location));

                    mOldMousePos = mCurMousePos;
                }
                else
                {
                    // node did not exists
                }
            }
        }

        private void canvasAction_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tool.CleanUp();
            }
        }

        private void zoom_MouseWheel(object sender, MouseEventArgs e)
        {
            if (mCanvas != null)
            {
                SizeF scale;

                if (e.Delta < 0)
                {
                    scale = new SizeF(0.9f, 0.9f);
                }
                else
                {
                    scale = new SizeF(1.1f, 1.1f);
                }

                mCanvas.Scale(scale);

                stat_canvasZoom.Text = ((float)mCanvas.Height / mSession.Height * 100).ToString("#.##") + "%";
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
                mCanvas = createCanvas(32, 32);

                int x = (this.Width - mCanvas.Width) / 2;
                int y = (this.Height - mCanvas.Height) / 2;
                mCanvas.Location = new Point(x, y);

                this.Controls.Add(mCanvas);

                mSession = new Project(mCanvas.Width, mCanvas.Height, "Test");

                Logger.Log("New project created");
                //mCanvas.Controls.Add(createLayer(mSession.getNewLayerID(), false));
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            float ratio = (float)mSession.Height / (float)mCanvas.Size.Height;
            SizeF scale = new SizeF(ratio, ratio);
            mCanvas.Scale(scale);

            stat_canvasZoom.Text = "100%";
        }

        private void toolSelected(object sender, EventArgs e)
        {
            // TODO: use ToolFactory
            if (btn_brush.Checked)
            {
                User._UserMode = (int)User.Mode.Draw;
                tool = Tool.Pen.GetTool();

                Logger.Log("Pen tool selected");
            }
            else if (btn_eraser.Checked)
            {
                User._UserMode = (int)User.Mode.Erase;
                tool = Eraser.GetTool();

                Logger.Log("Eraser tool selected");
            }
        }

        private void tree_layers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            mSession.SelectedLayer = tree_layers.SelectedNode.Tag.ToString();
        }
    





        /// <summary>
        /// Create canvas panel
        /// </summary>
        /// <param name="width">Width of the canvas</param>
        /// <param name="height">Height of the canvas</param>
        /// <param name="solid">Whether to fill background with solid colou</param>
        /// <param name="color">Color to be used to fill the background</param>
        /// <returns>Canvas panel</returns>
        private Layer createCanvas(int width, int height, Boolean transparent = false, Color? color = null)
        {
            Layer canvas = new Layer(width, height, "canvas", transparent);
            canvas.MouseDown += getMouseLocation_MouseDown;
            canvas.MouseMove += canvasAction_MouseMove;
            canvas.MouseWheel += zoom_MouseWheel;

            if (transparent)
            {
                canvas.BackColor = color ?? Color.White;
            }
            else
            {
                canvas.BackgroundImage = createTiledBackground(30);
            }

            return canvas;
        }

        /// <summary>
        /// Create tiled background to indicate alpha transparency
        /// </summary>
        /// <param name="tileSize">Width and height of the tile to be drawn (in pixel)</param>
        /// <returns>Image of the tiled background</returns>
        private Image createTiledBackground(int tileSize)
        {
            SolidBrush color1 = new SolidBrush(Color.LightGray);
            SolidBrush color2 = new SolidBrush(Color.GhostWhite);

            // tile
            Image tile = new Bitmap(tileSize * 2, tileSize * 2);
            Graphics tileGraphics = Graphics.FromImage(tile);
            tileGraphics.FillRectangle(color1, 0, 0, tileSize, tileSize);
            tileGraphics.FillRectangle(color2, tileSize, 0, tileSize, tileSize);
            tileGraphics.FillRectangle(color2, tileSize, 0, tileSize, tileSize);
            tileGraphics.FillRectangle(color1, tileSize, tileSize, tileSize, tileSize);

            // dispose brushes and graphics
            color1.Dispose();
            color2.Dispose();
            tileGraphics.Dispose();

            return tile;
        }

        private Layer createLayer(int id, Boolean transparent = true)
        {
            Layer layer = new Layer(mCanvas.Width, mCanvas.Height, id.ToString(), transparent);
            layer.Location = new Point(0, 0);
            layer.MouseDown += getMouseLocation_MouseDown;
            layer.MouseMove += canvasAction_MouseMove;
            layer.MouseUp += canvasAction_MouseUp;
            layer.MouseWheel += zoom_MouseWheel;

            TreeNode newLayer = new TreeNode("Layer " + id);
            newLayer.Tag = id;
            tree_layers.Nodes.Add(newLayer);

            return layer;
        }

        private Point getCanvasRelativePoint(Point cursorLocation)
        {
            int x, y;
            int scale =  mCanvas.Height / mSession.Height;

            x = cursorLocation.X / scale;
            y = cursorLocation.Y / scale;

            return new Point(x, y);
        }
    }
}
