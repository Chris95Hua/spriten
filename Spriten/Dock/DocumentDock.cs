using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Spriten.Drawing;
using Spriten.Tool;
using Spriten.Utility;
using Spriten.Data;
using Spriten.CustomControl;

namespace Spriten.Dock
{
    public partial class DocumentDock : DockContent
    {
        private Point mMouseLoc;
        public string ProjectPath { get; set; }
        public Project Project { get; private set; }
        public Canvas Canvas { get; private set; }
        private int mLayerID, mGroupID;
        private Rectangle mCanvasBrushRect, mDocBrushRect;
        private bool mCanDraw;

        Spriten mMain;
        private DrawTool mTool;

        public enum InsertMode
        {
            Above, Below, ToGroup
        }

        #region Constructors

        public DocumentDock(Spriten mainWindow, Project project)
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);

            Cursor = Cursors.Cross;
            mMain = mainWindow;
            Project = project;
            Text = project.Title;
            //AutoScrollMinSize = new Size(project.Width, project.Height);

            // Canvas
            Canvas = new Canvas(project);
            Canvas.Anchor = AnchorStyles.None;
            Canvas.MouseDown += canvasAction_MouseDown;
            Canvas.MouseMove += canvasAction_MouseMove;
            Canvas.MouseUp += canvasAction_MouseUp;
            Canvas.MouseLeave += canvasAction_MouseLeave;
            MouseWheel += zoom_MouseWheel;

            Canvas.BackgroundImage = ImageHelper.CanvasBg;
            Controls.Add(Canvas);

            InvalidateBrush();
        }

        public DocumentDock(Spriten mainWindow, Project project, Color background) : this(mainWindow, project)
        {
            if (background != Color.Transparent)
                Project.DrawableList.Add(new LayerMask("Background", Project, background));
        }

        #endregion

        private Rectangle BrushArea(Point location)
        {
            if (User.PenSize == 1)
                return new Rectangle(location.X, location.Y, 1, 1);

            int x = location.X, y = location.Y, width = User.PenSize, height = User.PenSize, overX, overY;

            if(x < 0)
            {
                width += x;
                x = 0;
            }
            if ((overX = x + width) > Project.Width)
            {
                width = overX - x + 1;
            }

            if (y < 0)
            {
                height += y;
                y = 0;
            }
            if ((overY = y + height) > Project.Height)
                height = overY - y + 1;

            return new Rectangle(x, y, width, height);
        }

        #region Events

        /// <summary>
        /// Mouse down action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvasAction_MouseDown(object sender, MouseEventArgs e)
        {
            // Use Tool on selected layer
            if (e.Button == MouseButtons.Left && Canvas.SelectedDrawable != null)
            {
                Canvas.DrawCachedImage = false;
                InitTool();
                mTool.Initialize(Canvas);
                mCanDraw = true;
                Rectangle updateArea = mTool.Use(BrushArea(Canvas.GetRelativePoint(e.Location)));
                if (updateArea != Rectangle.Empty)
                {
                    updateArea.Width = (int)Math.Ceiling(updateArea.Width * Canvas.CanvasScale);
                    updateArea.Height = (int)Math.Ceiling(updateArea.Height * Canvas.CanvasScale);
                    updateArea.X = (int)Math.Floor(updateArea.X * Canvas.CanvasScale);
                    updateArea.Y = (int)Math.Floor(updateArea.Y * Canvas.CanvasScale);
                    Canvas.Invalidate(updateArea, false);
                }
            }
            else
            {
                mMouseLoc = e.Location;
            }
        }

        /// <summary>
        /// Mouse move
        /// </summary>
        private void canvasAction_MouseMove(object sender, MouseEventArgs e)
        {
            Canvas.MouseLoc = e.Location;

            // Use tool on layer
            if (e.Button == MouseButtons.Left && mCanDraw)
            {
                Rectangle updateArea = mTool.Use(BrushArea(Canvas.GetRelativePoint(e.Location)));
                if (updateArea != Rectangle.Empty)
                {
                    updateArea.Width = (int)Math.Ceiling(updateArea.Width * Canvas.CanvasScale);
                    updateArea.Height = (int)Math.Ceiling(updateArea.Height * Canvas.CanvasScale);
                    updateArea.X = (int)Math.Floor(updateArea.X * Canvas.CanvasScale);
                    updateArea.Y = (int)Math.Floor(updateArea.Y * Canvas.CanvasScale);
                    Canvas.Invalidate(updateArea, false);
                }
            }

            // Move canvas
            else if (e.Button == MouseButtons.Middle)
            {
                Canvas.Top += e.Y - mMouseLoc.Y;
                Canvas.Left += e.X - mMouseLoc.X;
                // TODO: fix update scroll (breaks zoom to cursor ability)
                //UpdateScroll();
            }

            if (User.ShowBrushOutline)
                InvalidateBrush();
        }

        // Update thumbnail in layer dock
        private void canvasAction_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Project.DrawableList.Count > 0)
            {
                mCanDraw = false;
                mMain.UpdateLayerList(Project.DrawableList);
                Canvas.DrawCachedImage = true;
            }
        }

        private void canvasAction_MouseLeave(object sender, EventArgs e)
        {
            Canvas.MouseLoc = Point.Empty;
            if (User.ShowBrushOutline)
                InvalidateBrush();
        }

        // Canvas zoom
        private void zoom_MouseWheel(object sender, MouseEventArgs e)
        {
            mMouseLoc = e.Location;
            float factor, zoomFac = 0.5f;

            // zoom out
            if (e.Delta < 0)
                factor = Canvas.CanvasScale - zoomFac;
            // zoom in
            else
                factor = Canvas.CanvasScale + zoomFac;
            
            SetZoomFactor(factor);

            // TODO: fix update scroll (breaks zoom to cursor ability)
            //UpdateScroll();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Canvas.MouseLoc = mMouseLoc = Point.Empty;
            if (User.ShowBrushOutline)
                InvalidateBrush();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Canvas.SelectedDrawable != null)
            {
                Canvas.DrawCachedImage = false;
                InitTool();
                mTool.Initialize(Canvas);
                mCanDraw = true;
                Rectangle updateArea = mTool.Use(BrushArea(Canvas.GetRelativePoint(Canvas.PointToClient(MousePosition))));
                if (updateArea != Rectangle.Empty)
                {
                    updateArea.Width = (int)Math.Ceiling(updateArea.Width * Canvas.CanvasScale);
                    updateArea.Height = (int)Math.Ceiling(updateArea.Height * Canvas.CanvasScale);
                    updateArea.X = (int)Math.Floor(updateArea.X * Canvas.CanvasScale);
                    updateArea.Y = (int)Math.Floor(updateArea.Y * Canvas.CanvasScale);
                    Canvas.Invalidate(updateArea, false);
                }
            }
            else
            {
                mMouseLoc = e.Location;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mCanDraw)
            {
                Rectangle updateArea = mTool.Use(BrushArea(Canvas.GetRelativePoint(Canvas.PointToClient(MousePosition))));
                if (updateArea != Rectangle.Empty)
                {
                    updateArea.Width = (int)Math.Ceiling(updateArea.Width * Canvas.CanvasScale);
                    updateArea.Height = (int)Math.Ceiling(updateArea.Height * Canvas.CanvasScale);
                    updateArea.X = (int)Math.Floor(updateArea.X * Canvas.CanvasScale);
                    updateArea.Y = (int)Math.Floor(updateArea.Y * Canvas.CanvasScale);
                    Canvas.Invalidate(updateArea, false);
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                Canvas.Top += e.Y - mMouseLoc.Y;
                Canvas.Left += e.X - mMouseLoc.X;
                mMouseLoc = e.Location;
                // TODO: fix update scroll (breaks zoom to cursor ability)
                //UpdateScroll();
            }

            Canvas.MouseLoc = new Point(e.Location.X - Canvas.Location.X, e.Location.Y - Canvas.Location.Y);

            if(User.ShowBrushOutline)
                InvalidateBrush();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Project.DrawableList.Count > 0)
            {
                mCanDraw = false;
                mMain.UpdateLayerList(Project.DrawableList);
                Canvas.DrawCachedImage = true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (User.ShowBrushOutline && Canvas.MouseLoc != Point.Empty && Canvas.CanvasScale > 5)
            {
                Point brushLoc = PointToClient(MousePosition);
                mDocBrushRect = new Rectangle(brushLoc.X - Canvas.BrushCenterLoc - 1, brushLoc.Y - Canvas.BrushCenterLoc - 1, Canvas.BrushScale, Canvas.BrushScale);
                e.Graphics.DrawRectangle(Pens.Black, mDocBrushRect);
            }
        }

        public void InvalidateBrush()
        {
            // if its in canvas
            mCanvasBrushRect.Inflate(2, 2);
            Canvas.Invalidate(mCanvasBrushRect);

            mCanvasBrushRect = Canvas.BrushRectangle = new Rectangle(Canvas.MouseLoc.X - Canvas.BrushCenterLoc, Canvas.MouseLoc.Y - Canvas.BrushCenterLoc, Canvas.BrushScale, Canvas.BrushScale);
                
            // if its in outside of canvas
            mDocBrushRect.Inflate(2, 2);
            Invalidate(mDocBrushRect);
        }

        public void RefreshCanvas()
        {
            Canvas.RedrawCachedImage();
            Canvas.Invalidate();
        }

        private void DocumentDock_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScroll();
        }

        // Release resources
        private void DocumentDock_FormClosing(object sender, FormClosingEventArgs e)
        {
            Canvas.Cleanup();
            Canvas.Dispose();
            mMain.ClearLayerDockList();
            Dispose();
        }

        #endregion

        /// <summary>
        /// Insert a new layer into roots or parent of given drawable with specified location and colour
        /// </summary>
        /// <param name="color">Color of the layer</param>
        /// <param name="selected">Targetted drawable to insert</param>
        /// <param name="location">Insert mode</param>
        public void InsertDrawable(Color color, DrawableMask selected, InsertMode location)
        {
            string layerName = "Layer " + ++mLayerID;
            DrawableMask newLayer = new LayerMask(layerName, Project, color);
            
            if(selected == null)
                Project.DrawableList.Insert(0, newLayer);
            else
            {
                List<DrawableMask> parent = selected.Parent == null ? Project.DrawableList : ((LayerMaskGroup)selected.Parent).DrawableMaskList;

                if (location == InsertMode.Above)
                {
                    newLayer.Parent = selected.Parent;
                    parent.Insert(parent.IndexOf(selected), newLayer);
                }
                else if(location == InsertMode.Below)
                {
                    newLayer.Parent = selected.Parent;
                    parent.Insert(parent.IndexOf(selected) + 1, newLayer);
                }
                else if(location == InsertMode.ToGroup && !selected.IsLayer)
                {
                    selected.Insert(0, newLayer);
                }
            }

            RefreshCanvas();
        }

        /// <summary>
        /// Remove drawable from its parent
        /// </summary>
        /// <param name="drawable">Drawable to be removed</param>
        /// <param name="dispose">Should the drawable get disposed</param>
        public void RemoveDrawable(DrawableMask drawable, bool dispose)
        {
            if(drawable.Parent == null)
                Project.DrawableList.Remove(drawable);
            else
                drawable.Parent.Remove(drawable);

            if (dispose)
                drawable.Dispose();
        }

        /// <summary>
        /// Group selected drawables
        /// </summary>
        /// <param name="drawables">Drawables to be grouped</param>
        public void CreateGroup(List<DrawableMask> drawables)
        {
            LayerMaskGroup group = new LayerMaskGroup("Group " + ++mGroupID, Project);

            if (drawables.Count > 0)
            {
                // insert all drawables into group
                DrawableMask selected = drawables[0];
                List<DrawableMask> parent = selected.Parent == null ? Project.DrawableList : ((LayerMaskGroup)selected.Parent).DrawableMaskList;
                group.Parent = selected.Parent;
                parent.Insert(parent.IndexOf(selected), group);

                for (int i = drawables.Count - 1; i >= 0; i--)
                {
                    if (drawables.Contains(drawables[i].Parent))
                        drawables.Remove(drawables[i]);
                    else
                        RemoveDrawable(drawables[i], false);
                }

                group.Insert(0, drawables);
            }
            else
            {
                // insert new group in root
                Project.DrawableList.Insert(0, group);
            }

            RefreshCanvas();
        }

        /// <summary>
        /// Merge the drawable with the next drawable in the same list
        /// </summary>
        /// <param name="drawable">Drawable to merge</param>
        public void MergeWithBelow(DrawableMask drawable)
        {
            List<DrawableMask> parent = drawable.Parent == null ? Project.DrawableList : ((LayerMaskGroup)drawable.Parent).DrawableMaskList;

            if (parent.IndexOf(drawable) < parent.Count - 1)
            {
                int index = parent.IndexOf(drawable);
                DrawableMask target = parent[index + 1];

                Bitmap mergedImage = new Bitmap(Project.Width, Project.Height, PixelFormat.Format32bppArgb);
                Graphics imageGraphics = Graphics.FromImage(mergedImage);
                imageGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                imageGraphics.SmoothingMode = SmoothingMode.None;
                imageGraphics.PixelOffsetMode = PixelOffsetMode.Half;

                Bitmap mergedMask = null;
                Graphics maskGraphics = null;

                // if contain mask
                if (drawable.IsUsingMask)
                {
                    mergedMask = new Bitmap(Project.Width, Project.Height, PixelFormat.Format32bppArgb);
                    maskGraphics = Graphics.FromImage(mergedMask);
                    maskGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                    maskGraphics.SmoothingMode = SmoothingMode.None;
                    maskGraphics.PixelOffsetMode = PixelOffsetMode.Half;
                }
                
                // merge with layer below
                if (parent[index + 1].Visible)
                {
                    imageGraphics.DrawImageUnscaled(parent[index + 1].Bitmap, 0, 0, Project.Width, Project.Height);

                    // if contain mask
                    if(parent[index + 1].IsUsingMask)
                        maskGraphics.DrawImageUnscaled(parent[index + 1].Mask, 0, 0, Project.Width, Project.Height);
                }

                if(parent[index].Visible)
                {
                    imageGraphics.DrawImageUnscaled(parent[index].Bitmap, 0, 0, Project.Width, Project.Height);

                    // if contain mask
                    if (parent[index].IsUsingMask)
                        maskGraphics.DrawImageUnscaled(parent[index].Mask, 0, 0, Project.Width, Project.Height);
                }

                DrawableMask flattenLayer = new LayerMask(drawable.Name, Project, mergedImage, mergedMask);
                flattenLayer.Parent = drawable.Parent;

                // clean up
                mergedImage.Dispose();
                imageGraphics.Dispose();

                // if contain mask
                if (drawable.IsUsingMask)
                {
                    mergedMask.Dispose();
                    maskGraphics.Dispose();
                }

                // insert flatten layer
                parent.Insert(parent.IndexOf(drawable), flattenLayer);

                // remove layers
                parent.RemoveRange(parent.IndexOf(drawable), 2);
                drawable.Dispose();
                target.Dispose();

                RefreshCanvas();
            }
        }

        /// <summary>
        /// Merge a list of drawables into a single layer
        /// </summary>
        /// <param name="drawables">Drawables to be merged</param>
        public void MergeDrawables(List<DrawableMask> drawables)
        {
            if (drawables.Count > 1)
            {
                Bitmap mergedImage = new Bitmap(Project.Width, Project.Height, PixelFormat.Format32bppArgb);
                Graphics imageGraphics = Graphics.FromImage(mergedImage);
                imageGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                imageGraphics.SmoothingMode = SmoothingMode.None;
                imageGraphics.PixelOffsetMode = PixelOffsetMode.Half;

                DrawableMask selected = drawables[0];
                List<DrawableMask> parent = selected.Parent == null ? Project.DrawableList : ((LayerMaskGroup)selected.Parent).DrawableMaskList;

                // mask
                Bitmap mergedMask = null;
                Graphics maskGraphics = null;

                if (selected.IsUsingMask)
                {
                    mergedMask = new Bitmap(Project.Width, Project.Height, PixelFormat.Format32bppArgb);
                    maskGraphics = Graphics.FromImage(mergedMask);
                    maskGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                    maskGraphics.SmoothingMode = SmoothingMode.None;
                    maskGraphics.PixelOffsetMode = PixelOffsetMode.Half;
                }

                // merge selected
                for (int i = drawables.Count - 1; i >= 0; i--)
                {
                    // paint and remove drawable
                    if (!drawables.Contains(drawables[i].Parent))
                    {
                        if (drawables[i].Visible)
                        {
                            imageGraphics.DrawImageUnscaled(drawables[i].Bitmap, 0, 0, Project.Width, Project.Height);

                            if (drawables[i].IsUsingMask)
                                maskGraphics.DrawImageUnscaled(drawables[i].Mask, 0, 0, Project.Width, Project.Height);
                        }

                        if (i != 0)
                            RemoveDrawable(drawables[i], true);
                    }
                }

                DrawableMask flattenLayer = new LayerMask(selected.Name, Project, mergedImage, mergedMask);
                flattenLayer.Parent = selected.Parent;

                // clean up
                mergedImage.Dispose();
                imageGraphics.Dispose();
                if (selected.IsUsingMask)
                {
                    mergedMask.Dispose();
                    maskGraphics.Dispose();
                }

                parent.Insert(parent.IndexOf(selected), flattenLayer);
                RemoveDrawable(selected, true);

                RefreshCanvas();
            }
        }

        /// <summary>
        /// Flatten LayerGroup to Layer
        /// </summary>
        /// <param name="drawable">LayerGroup to be flatten</param>
        public void FlattenGroup(DrawableMask drawable)
        {
            if (!drawable.IsLayer)
            {
                LayerMaskGroup selected = (LayerMaskGroup)drawable;
                Bitmap groupImage = selected.Bitmap;
                Bitmap maskImage = selected.IsUsingMask ? selected.Mask : null;
                DrawableMask flattenGroup = new LayerMask("Flatten " + drawable.Name, Project, groupImage, maskImage);

                groupImage.Dispose();
                maskImage.Dispose();

                flattenGroup.Parent = drawable.Parent;
                List<DrawableMask> parent = drawable.Parent == null ? Project.DrawableList : ((LayerMaskGroup)drawable.Parent).DrawableMaskList;
                parent.Insert(parent.IndexOf(drawable), flattenGroup);
                parent.Remove(drawable);
                drawable.Dispose();

                RefreshCanvas();
            }
        }

        /// <summary>
        /// Make a deep copy of drawables
        /// </summary>
        /// <param name="drawables">Drawables to clone</param>
        public void DuplicateDrawables(List<DrawableMask> drawables)
        {
            DrawableMask selected = drawables[0], copy;
            List<DrawableMask> parent = selected.Parent == null ? Project.DrawableList : ((LayerMaskGroup)selected.Parent).DrawableMaskList;
            List<DrawableMask> duplicate = new List<DrawableMask>(drawables.Count);

            for (int i = 0; i < drawables.Count; i++)
            {
                if (!drawables.Contains(drawables[i].Parent))
                {
                    copy = drawables[i].GetCopy(drawables[i].Name + " Copy");
                    copy.Parent = selected.Parent;

                    duplicate.Add(copy);
                }
            }

            parent.InsertRange(parent.IndexOf(selected), duplicate);

            RefreshCanvas();
        }

        /// <summary>
        /// Move drawables to root
        /// </summary>
        /// <param name="drawables">Selected drawables</param>
        public void MoveDrawablesToRoot(List<DrawableMask> drawables)
        {
            for(int i = drawables.Count - 1; i >= 0; i--)
            {
                if (drawables[i].Parent != null)
                {
                    // remove from parent
                    drawables[i].Parent.Remove(drawables[i]);
                    drawables[i].Parent = null;

                    // move to root
                    Project.DrawableList.Add(drawables[i]);
                }
            }

            // redraw canvas
            RefreshCanvas();
        }

        /// <summary>
        /// Group drawables with target
        /// </summary>
        /// <param name="target">Targetted drawable</param>
        /// <param name="drawables">Selected drawables</param>
        public void MoveDrawablesToGroup(DrawableMask target, List<DrawableMask> drawables)
        {
            if (target.IsLayer)
            {
                // create a new group and group all the layers
                drawables.Insert(0, target);
                CreateGroup(drawables);
            }
            else
            {
                for (int i = drawables.Count - 1; i >= 0; i--)
                {
                    // remove from existing parent
                    if (drawables[i].Parent == null)
                        Project.DrawableList.Remove(drawables[i]);
                    else
                        drawables[i].Parent.Remove(drawables[i]);

                    // insert into target (group)
                    target.Insert(0, drawables[i]);
                }
            }

            // redraw canvas
            RefreshCanvas();
        }

        /// <summary>
        /// Move drawables to the sides of target
        /// </summary>
        /// <param name="target">Targetted drawable</param>
        /// <param name="drawables">Selected drawables</param>
        /// <param name="offset">Location offset</param>
        public void MoveDrawablesToSibling(DrawableMask target, List<DrawableMask> drawables, int offset)
        {
            for (int i = drawables.Count - 1; i >= 0; i--)
            {
                // remove from parent
                if (drawables[i].Parent == null)
                    Project.DrawableList.Remove(drawables[i]);
                else
                    drawables[i].Parent.Remove(drawables[i]);

                // set target parent as the parent
                drawables[i].Parent = target.Parent;
            }

            // insert selected drawables into parent of target
            if (target.Parent == null)
            {
                Project.DrawableList.InsertRange(Project.DrawableList.IndexOf(target) + offset, drawables);
            }
            else
            {
                LayerMaskGroup group = (LayerMaskGroup)target.Parent;
                group.Insert(group.DrawableMaskList.IndexOf(target) + offset, drawables);
            }

            // redraw canvas
            RefreshCanvas();
        }

        public void MoveDrawablesUp(List<DrawableMask> drawables)
        {
            DrawableMask target = drawables[0];
            List<DrawableMask> parent = target.Parent == null ? Project.DrawableList : ((LayerMaskGroup)target.Parent).DrawableMaskList;
            int index = parent.IndexOf(target) - 1;

            if (index < 0)
            {
                target = target.Parent;

                if (target == null)
                    return;

                parent = target.Parent == null ? Project.DrawableList : ((LayerMaskGroup)target.Parent).DrawableMaskList;
                index = parent.IndexOf(target);
            }

            for (int i = drawables.Count - 1; i >= 0; i--)
            {
                if (drawables.Contains(drawables[i].Parent))
                    drawables.Remove(drawables[i]);
                else
                    RemoveDrawable(drawables[i], false);
            }
            
            if(!parent[index].IsLayer && drawables[0].Parent != parent[index])
            {
                LayerMaskGroup group = (LayerMaskGroup)parent[index];
                group.Insert(group.DrawableMaskList.Count, drawables);
            }
            else
            {
                for(int i = drawables.Count - 1; i >= 0; i--)
                {
                    parent.Insert(index, drawables[i]);
                    drawables[i].Parent = target.Parent;
                }
            }

            // redraw canvas
            RefreshCanvas();
        }

        public void MoveDrawablesDown(List<DrawableMask> drawables)
        {
            DrawableMask target = drawables[0];
            List<DrawableMask> parent = target.Parent == null ? Project.DrawableList : ((LayerMaskGroup)target.Parent).DrawableMaskList;
            int index = parent.IndexOf(target);
            // check if target is the first in list
            if (index + 1 >= parent.Count)
            {
                target = target.Parent;

                if (target == null)
                    return;
                
                parent = target.Parent == null ? Project.DrawableList : ((LayerMaskGroup)target.Parent).DrawableMaskList;
                index = parent.IndexOf(target);
            }

            for (int i = drawables.Count - 1; i >= 0; i--)
            {
                if (drawables.Contains(drawables[i].Parent))
                    drawables.Remove(drawables[i]);
                else
                    RemoveDrawable(drawables[i], false);
            }
            
            if (index >= parent.Count)
                index = parent.Count - 1;

            if (parent.Count > 0 && !parent[index].IsLayer && drawables[0].Parent != parent[index])
            {
                LayerMaskGroup group = (LayerMaskGroup)parent[index];
                group.Insert(0, drawables);
            }
            else
            {
                if (parent.Count >= 0)
                    index++;

                for (int i = drawables.Count - 1; i >= 0; i--)
                {
                    parent.Insert(index, drawables[i]);
                    drawables[i].Parent = target.Parent;
                }
            }

            // redraw canvas
            RefreshCanvas();
        }

        public void InsertDrawablesFromClipboard(DrawableMask target, bool toGroup)
        {
            if (target == null)
            {
                DrawableMask copy;
                for (int i = User.DrawablesClipboard.Count - 1; i >= 0; i--)
                {
                    copy = User.DrawablesClipboard[i].GetCopy(User.DrawablesClipboard[i].Name);
                    copy.Parent = null;
                    Project.DrawableList.Insert(0, copy);
                }
            }
            else if (toGroup && !target.IsLayer)
            {
                for (int i = User.DrawablesClipboard.Count - 1; i >= 0; i--)
                {
                    target.Insert(0, User.DrawablesClipboard[i].GetCopy(User.DrawablesClipboard[i].Name));
                }
            }
            else
            {
                DrawableMask copy;
                List<DrawableMask> parent = target.Parent == null ? Project.DrawableList : ((LayerMaskGroup)target.Parent).DrawableMaskList;
                int index = parent.IndexOf(target);

                for (int i = User.DrawablesClipboard.Count - 1; i >= 0; i--)
                {
                    copy = User.DrawablesClipboard[i].GetCopy(User.DrawablesClipboard[i].Name);
                    copy.Parent = target.Parent;
                    parent.Insert(index, copy);
                }
            }

            RefreshCanvas();
        }

        /// <summary>
        /// Replace mask color
        /// </summary>
        /// <param name="oldColor">Color to be replaced</param>
        /// <param name="newColor">New color to use</param>
        public void ReplaceMaskColor(byte type, int argb)
        {
            for(int i = Project.DrawableList.Count - 1; i >= 0 && Project.IsUsingMask; i--)
            {
                Project.DrawableList[i].ReplaceMaskPixel(type, argb);
            }
        }

        /// <summary>
        /// Set the zoom percentage of the canvas
        /// </summary>
        /// <param name="percentage">Zoom percentage</param>
        public void SetZoomPercentage(float percentage)
        {
            SetZoomFactor(percentage / 100);
        }

        /// <summary>
        /// Set the zoom factor of the canvas
        /// </summary>
        /// <param name="factor">Zoom factor</param>
        public void SetZoomFactor(float factor)
        {
            // min zoom = 10%
            if(factor > 0.1)
            {
                int oldTop = Canvas.Top, oldLeft = Canvas.Left, oldY, oldX;
                if (mMouseLoc != Point.Empty)
                {
                    oldY = mMouseLoc.Y;
                    oldX = mMouseLoc.X;
                }
                else
                {
                    oldY = (ClientRectangle.Height / 2);
                    oldX = (ClientRectangle.Width / 2);
                }

                float ratio = factor / Canvas.CanvasScale;
                Canvas.SetScaleFactor(factor);
                mMain.SetStatusBarZoomPercentage(factor * 100);

                Canvas.Top = (int)(oldY - ratio * (oldY - oldTop));
                Canvas.Left = (int)(oldX - ratio * (oldX - oldLeft));
            }
        }

        /// <summary>
        /// Increment/Decrement the zoom level by the given percentange
        /// </summary>
        /// <param name="percentage">Zoom percentage</param>
        public void ZoomByPercentage(float percentage)
        {
            SetZoomPercentage(Canvas.CanvasScale * 100 + percentage);
        }

        /// <summary>
        /// Center the canvas in the document dock
        /// </summary>
        public void CenterCanvas()
        {
            int x = (Width - Canvas.Width) / 2;
            int y = (Height - Canvas.Height) / 2;

            Canvas.Location = new Point(x, y);
        }

        /// <summary>
        /// Resize canvas to fit the screen
        /// </summary>
        public void FitCanvasToScreen()
        {
            float ratioX = (float)ClientRectangle.Width / Canvas.Width;
            float ratioY = (float)ClientRectangle.Height / Canvas.Height;

            if (ratioX > ratioY)
                SetZoomFactor(ratioY * Canvas.CanvasScale);
            else
                SetZoomFactor(ratioX * Canvas.CanvasScale);

            CenterCanvas();
        }

        /// <summary>
        /// Merge all the drawables into a single image
        /// </summary>
        /// <param name="background">Background color</param>
        /// <returns>Flattened image of drawables</returns>
        public Bitmap GenerateImage(Color background)
        {
            Bitmap output = new Bitmap(Project.Width, Project.Height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(output))
            {
                graphics.Clear(background);

                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.PixelOffsetMode = PixelOffsetMode.Half;
                graphics.SmoothingMode = SmoothingMode.None;

                for (int i = Project.DrawableList.Count - 1; i >= 0; i--)
                {
                    if(Project.DrawableList[i].Visible)
                        graphics.DrawImage(Project.DrawableList[i].Bitmap, 0, 0, Project.Width, Project.Height);
                }
            }

            return output;
        }

        /// <summary>
        /// Initialize tools to use on canvas
        /// </summary>
        private void InitTool()
        {
            switch (User.ToolMode)
            {
                case Tool.ToolMode.Draw:
                    mTool = Pencil.GetTool();
                    break;
                case Tool.ToolMode.Erase:
                    mTool = Eraser.GetTool();
                    break;
                case Tool.ToolMode.ColorPicker:
                    mTool = ColorPicker.GetTool();
                    break;
                case Tool.ToolMode.Fill:
                    mTool = Fill.GetTool();
                    break;
            }
        }

        /// <summary>
        /// Update the scroll margin for DocumentDock
        /// </summary>
        private void UpdateScroll()
        {
            // TODO: set scroll margin
            int x = Math.Abs(Canvas.Left) + Canvas.Width;
            int y = Math.Abs(Canvas.Top) + Canvas.Height;
            AutoScrollMargin = new Size(x, y);
        }
    }
}
