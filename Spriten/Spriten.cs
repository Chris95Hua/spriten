using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

using WeifenLuo.WinFormsUI.Docking;

using static Spriten.Dock.DocumentDock;
using Spriten.Dock;
using Spriten.Drawing;
using Spriten.Dialog;
using Spriten.Utility;
using Spriten.CustomControl;
using Spriten.Tool;
using Spriten.Data;
using static Spriten.Utility.TexSynHelper;

namespace Spriten
{
    public partial class Spriten : Form
    {
        private int mDocumentID;
        private DeserializeDockContent mDeserializeDock;
        private DocumentDock mActiveDoc;
        private LayerDock mLayerDock;
        private ColorDock mColorDock;
        private MaskDock mMaskDock;
        private ToolDock mToolDock;
        private NumericSlider mOpacitySlider;
        private NumericSlider mSizeSlider;

        private Action<Color> ActionToolSetForeColor;
        private Action<ToolMode> ActionToolSetTool;
        private Action<Color> ActionColorSetColor;
        private Action<bool> ActionLayerSetButton;
        private Action<List<DrawableMask>> ActionLayerRefresh;
        private Action<List<DrawableMask>> ActionLayerSet;
        private Action<List<DrawableMask>> ActionLayerUpdate;
        private Action ActionLayerClear;
        private Action<bool> ActionMaskSetControls;
        private Action<bool> ActionMaskCheckUseMask;
        private Action<bool> ActionMaskCheckMaskMode;

        #region Constructors

        /// <summary>
        /// Base constructor to setup the necessary components for the application
        /// </summary>
        public Spriten()
        {
            InitializeComponent();

            RetrieveSettings();
            LoadAndApplyTheme();

            SetupToolStrip();

            // setup docks
            SetupLayerDock();
            SetupColorDock();
            SetupMaskDock();
            SetupToolDock();

            SetupTool();

            mDeserializeDock = new DeserializeDockContent(GetContentFromPersistString);

            // load layout
            string layoutConfig = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Layout.config");

            // check if dockpanel xml file exists
            if (File.Exists(layoutConfig))
            {
                mDockPanel.LoadFromXml(layoutConfig, mDeserializeDock);
            }
            else
            {
                mLayerDock.Show(mDockPanel);
                mColorDock.Show(mLayerDock.Pane, DockAlignment.Top, 0.38);
                mMaskDock.Show(mDockPanel);
                mColorDock.Show();
                mToolDock.Show(mDockPanel);
                mDockPanel.SaveAsXml(layoutConfig);
            }

            // cache frequently used brushes
            ImageHelper.CreateTextureBrushes();

            KeyDown += new KeyEventHandler(Shortcuts);
            KeyPreview = true;
        }

        /// <summary>
        /// Constructor to launch to application and open file(s)
        /// </summary>
        /// <param name="fileNames">Array of file names to be opened</param>
        public Spriten(string[] fileNames) : this()
        {
            for(int i = 0; i < fileNames.Length; i++)
            {
                Open(fileNames[i]);
            }
        }

        #endregion

        /// <summary>
        /// Retrieve frequently used settings from Settings file
        /// </summary>
        private void RetrieveSettings()
        {
            User.ToolMode = (ToolMode)Properties.Settings.Default["UserToolMode"];
            User.ForegroundColor = (Color)Properties.Settings.Default["ForegroundColor"];
            User.BackgroundColor = (Color)Properties.Settings.Default["BackgroundColor"];

            User.MaskBorder = (Color)Properties.Settings.Default["MaskBorderColor"];
            User.MaskBody = (Color)Properties.Settings.Default["MaskBodyColor"];
            User.MaskBorderBody = (Color)Properties.Settings.Default["MaskBorderBodyColor"];
            User.MaskEmptyBody = (Color)Properties.Settings.Default["MaskEmptyBodyColor"];

            User.ColodDockSelector = (ColorSelector)Properties.Settings.Default["ColorDockSelectorMode"];
            User.ShowBrushOutline = (bool)Properties.Settings.Default["ShowBrushOutline"];
            User.ShowPixelGrid = (bool)Properties.Settings.Default["ShowPixelGrid"];
            User.PenSize = (int)Properties.Settings.Default["PenSize"];
            User.PenOpacity = (byte)Properties.Settings.Default["PenOpacity"];

            User.DrawablesClipboard = new List<DrawableMask>();
        }

        /// <summary>
        /// Load and apply theme to main window
        /// </summary>
        private void LoadAndApplyTheme()
        {
            mDockPanel.Theme = ThemeHelper.Theme = new VS2013SpritenDarkTheme();
            //mDockPanel.Theme = ThemeHelper.Theme = new VS2013SpritenLightTheme();

            mDockPanel.DockBackColor = ThemeHelper.DockBackColor;

            // menu bar
            menu_mainMenu.BackColor = ThemeHelper.Background;
            menu_mainMenu.ForeColor = ThemeHelper.Foreground;
            menu_mainMenu.Renderer = ThemeHelper.ToolStripRenderer;

            // tool bar
            tool_actions.BackColor = ThemeHelper.Background;

            // status bar
            stat_canvas.BackColor = ThemeHelper.Background;
            stat_canvas.ForeColor = ThemeHelper.Foreground;

            if(ThemeHelper.Style == ThemeHelper.ThemeStyle.Dark)
                btn_switchColor.Image = Properties.Resources.dark_switch_10;
            else
                btn_switchColor.Image = Properties.Resources.light_switch_10;
        }

        private void SetupToolStrip()
        {
            SetToolStripForeColor(User.ForegroundColor);
            SetToolStripBackColor(User.BackgroundColor);
            
            mSizeSlider = new NumericSlider();
            mSizeSlider.AlwaysRoundDown = true;
            mSizeSlider.DisplayText = "Size: ";
            mSizeSlider.PostFix = "px";
            mSizeSlider.DisplayStringFormat = "{0:#}";
            mSizeSlider.Value = User.PenSize;
            mSizeSlider.Width = 140;
            mSizeSlider.OnValueChanged += OnSizeValueChanged;
            tool_actions.Controls.Add(mSizeSlider);

            mOpacitySlider = new NumericSlider();
            mOpacitySlider.DisplayText = "Opacity: ";
            mOpacitySlider.Minimum = 0f;
            mOpacitySlider.Maximum = 1f;
            mOpacitySlider.MouseWheelStep = 0.1f;
            mOpacitySlider.UpDownStep = 0.1f;
            mOpacitySlider.Value = (float)User.PenOpacity / byte.MaxValue;
            mOpacitySlider.Width = 140;
            mOpacitySlider.OnValueChanged += OnOpacityValueChanged;
            tool_actions.Controls.Add(mOpacitySlider);

        }

        void Shortcuts(object sender, KeyEventArgs e)
        {
            // export (alt shift ctrl w)???

            // cut (ctrl x)

            // copy (ctrl c)

            // paste (ctrl v)

            // center?

            // pixel grid

            // mask

            // opacity dec (i), inc (o) or number (photoshop)

            // color dock (f6)

            // layer dock (f7)

            // tool, mask

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
                saveToolStripMenuItem_Click(sender, e);
            else if (e.Modifiers == (Keys.Control | Keys.Shift) && e.KeyCode == Keys.S)
                saveAsToolStripMenuItem_Click(sender, e);
            else if (e.Modifiers == (Keys.Control | Keys.Alt) && e.KeyCode == Keys.W)
                closeAllToolStripMenuItem_Click(sender, e);
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.W)
                closeToolStripMenuItem_Click(sender, e);

            switch (e.KeyCode)
            {
                case Keys.X:
                    btn_switchColor_Click(sender, e);
                    break;
                case Keys.B:
                    User.ToolMode = ToolMode.Draw;
                    ActionToolSetTool?.Invoke(User.ToolMode);
                    break;
                case Keys.E:
                    User.ToolMode = ToolMode.Erase;
                    ActionToolSetTool?.Invoke(User.ToolMode);
                    break;
                case Keys.G:
                    User.ToolMode = ToolMode.Fill;
                    ActionToolSetTool?.Invoke(User.ToolMode);
                    break;
                case Keys.P:
                    User.ToolMode = ToolMode.ColorPicker;
                    ActionToolSetTool?.Invoke(User.ToolMode);
                    break;
                case Keys.OemOpenBrackets:
                    SetPenSize((int)--mSizeSlider.Value);
                    break;
                case Keys.OemCloseBrackets:
                    SetPenSize((int)++mSizeSlider.Value);
                    break;
            }
        }

        private void OnSizeValueChanged(object sender, EventArgs e)
        {
            SetPenSize((int)mSizeSlider.Value);
        }

        private void SetPenSize(int size)
        {
            if(size <= mSizeSlider.Maximum && size >= mSizeSlider.Minimum)
            {
                User.PenSize = size;
                UpdateDocumentsBrush();
            }
        }

        private void OnOpacityValueChanged(object sender, EventArgs e)
        {
            User.PenOpacity = (byte)(mOpacitySlider.Value * byte.MaxValue);
        }

        #region Docks and themes setup

        /// <summary>
        /// Setup layer dock components and style
        /// </summary>
        private void SetupLayerDock()
        {
            mLayerDock = new LayerDock();
            mLayerDock.InsertDrawable = InsertDrawable;
            mLayerDock.RemoveDrawable = RemoveDrawable;
            mLayerDock.SelectDrawable = SelectDrawable;
            mLayerDock.MergeWithBelow = MergeWithBelow;
            mLayerDock.FlattenGroup = FlattenGroup;
            mLayerDock.MergeDrawables = MergeDrawables;
            mLayerDock.DuplicateDrawables = DuplicateDrawables;
            mLayerDock.CreateGroup = CreateGroup;
            mLayerDock.HasActiveDocument = HasActiveDocument;
            mLayerDock.MoveDrawablesToRoot = MoveDrawablesToRoot;
            mLayerDock.MoveDrawablesToGroup = MoveDrawablesToGroup;
            mLayerDock.MoveDrawablesToSibling = MoveDrawablesToSibling;
            mLayerDock.MoveDrawables = MoveDrawables;
            mLayerDock.RefreshCanvas = RefreshActiveCanvas;
            mLayerDock.PasteDrawables = PasteDrawables;

            ActionLayerSet = mLayerDock.SetDrawableList;
            ActionLayerRefresh = mLayerDock.RefreshDrawableList;
            ActionLayerSetButton = mLayerDock.SetButtons;
            ActionLayerClear = mLayerDock.ClearList;
            ActionLayerUpdate = mLayerDock.UpdateList;
        }

        /// <summary>
        /// Setup color dock components and style
        /// </summary>
        private void SetupColorDock()
        {
            mColorDock = new ColorDock(User.ColodDockSelector);

            ActionColorSetColor = mColorDock.UpdateRgbFields;

            mColorDock.SetPrimaryColor += SetToolStripForeColor;
            mColorDock.SetPrimaryColor += SetToolForeColor;
        }

        /// <summary>
        /// Setup mask dock components and style
        /// </summary>
        private void SetupMaskDock()
        {
            mMaskDock = new MaskDock();

            ActionMaskSetControls = mMaskDock.SetMaskControls;
            ActionMaskCheckUseMask = mMaskDock.CheckUseMask;
            ActionMaskCheckMaskMode = mMaskDock.CheckMaskMode;

            mMaskDock.ReplaceMaskColor = ReplaceMaskColor;
            mMaskDock.RefreshDocuments = RefreshDocuments;
            mMaskDock.RefreshActiveDocument = RefreshActiveCanvas;
            mMaskDock.UseMask = UseMaskForProject;
        }

        /// <summary>
        /// Setup tool dock components and style
        /// </summary>
        private void SetupToolDock()
        {
            mToolDock = new ToolDock();
            mToolDock.SetColorDockColor = SetColorDockColor;
            mToolDock.SetToolStripForeColor = SetToolStripForeColor;
            mToolDock.SetToolStripBackColor = SetToolStripBackColor;
            mToolDock.UpdateBrush = UpdateDocumentsBrush;

            ActionToolSetForeColor = mToolDock.SetForegroundColor;
            ActionToolSetTool = mToolDock.SelectTool;
        }

        #endregion

        #region Tool setup

        private void SetupTool()
        {
            // Color picker
            ColorPicker picker = (ColorPicker)ColorPicker.GetTool();
            picker.SetPrimaryColor += SetToolForeColor;
            picker.SetPrimaryColor += SetToolStripForeColor;
            picker.SetPrimaryColor += SetColorDockColor;
        }

        #endregion

        /// <summary>
        /// Setup dock content using persistent string
        /// </summary>
        /// <param name="persistString">String value</param>
        /// <returns>Dock content</returns>
        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(LayerDock).ToString())
                return mLayerDock;
            else if (persistString == typeof(ToolDock).ToString())
                return mToolDock;
            else if (persistString == typeof(ColorDock).ToString())
                return mColorDock;
            else if (persistString == typeof(MaskDock).ToString())
                return mMaskDock;
            else
                return null;
        }

        /// <summary>
        /// Clear the tree list view contents in Layer Dock
        /// </summary>
        public void ClearLayerDockList()
        {
            ActionLayerClear?.Invoke();
        }

        private void InsertDrawable(DrawableMask drawable, InsertMode location)
        {
            mActiveDoc.InsertDrawable(Color.Transparent, drawable, location);
            ActionLayerSet?.Invoke(mActiveDoc.Project.DrawableList);
        }

        private void RemoveDrawable(DrawableMask drawable)
        {
            mActiveDoc.RemoveDrawable(drawable, true);
        }

        /// <summary>
        /// Set selected drawable in the active document
        /// </summary>
        /// <param name="drawable">Selected drawable</param>
        private void SelectDrawable(DrawableMask drawable)
        {
            mActiveDoc.Canvas.SelectedDrawable = drawable;
        }

        private void PasteDrawables(DrawableMask target, bool toGroup)
        {
            mActiveDoc.InsertDrawablesFromClipboard(target, toGroup);
            ActionLayerSet?.Invoke(mActiveDoc.Project.DrawableList);
        }

        private void CreateGroup(List<DrawableMask> drawables)
        {
            mActiveDoc.CreateGroup(drawables);
            ActionLayerSet?.Invoke(mActiveDoc.Project.DrawableList);
        }

        private void MergeWithBelow(DrawableMask drawable)
        {
            mActiveDoc.MergeWithBelow(drawable);
            ActionLayerSet?.Invoke(mActiveDoc.Project.DrawableList);
        }

        private void FlattenGroup(DrawableMask drawable)
        {
            mActiveDoc.FlattenGroup(drawable);
            ActionLayerSet?.Invoke(mActiveDoc.Project.DrawableList);
        }

        private void MergeDrawables(List<DrawableMask> drawables)
        {
            mActiveDoc.MergeDrawables(drawables);
            ActionLayerSet?.Invoke(mActiveDoc.Project.DrawableList);
        }

        private void DuplicateDrawables(List<DrawableMask> drawables)
        {
            mActiveDoc.DuplicateDrawables(drawables);
            ActionLayerSet?.Invoke(mActiveDoc.Project.DrawableList);
        }

        private void MoveDrawablesToRoot(List<DrawableMask> drawables)
        {
            mActiveDoc.MoveDrawablesToRoot(drawables);
            ActionLayerSet?.Invoke(mActiveDoc.Project.DrawableList);
        }

        private void MoveDrawablesToGroup(DrawableMask target, List<DrawableMask> drawables)
        {
            mActiveDoc.MoveDrawablesToGroup(target, drawables);
            ActionLayerSet?.Invoke(mActiveDoc.Project.DrawableList);
        }

        private void MoveDrawablesToSibling(DrawableMask target, List<DrawableMask> drawables, int offset)
        {
            mActiveDoc.MoveDrawablesToSibling(target, drawables, offset);
            ActionLayerSet?.Invoke(mActiveDoc.Project.DrawableList);
        }

        private void MoveDrawables(List<DrawableMask> drawables, bool up)
        {
            if (up)
                mActiveDoc.MoveDrawablesUp(drawables);
            else
                mActiveDoc.MoveDrawablesDown(drawables);

            ActionLayerSet?.Invoke(mActiveDoc.Project.DrawableList);
        }

        /// <summary>
        /// Check if there is any active document selected
        /// </summary>
        /// <returns></returns>
        private bool HasActiveDocument()
        {
            if(mActiveDoc != null)
            {
                if(mActiveDoc.IsDisposed)
                    mActiveDoc = null;
            }

            return mActiveDoc != null;
        }

        /// <summary>
        /// Check if there is any document
        /// </summary>
        /// <returns></returns>
        private bool HasDocument()
        {
            for(int i = mDockPanel.Contents.Count - 1; i >= 0; i--)
            {
                if ((mDockPanel.Contents[i] as DocumentDock) != null)
                    return true;
            }

            return false;
        }

        private void RefreshDocuments()
        {
            DocumentDock doc;
            for (int i = mDockPanel.Contents.Count - 1; i >= 0; i--)
            {
                if ((doc = mDockPanel.Contents[i] as DocumentDock) != null)
                    doc.RefreshCanvas();
            }
        }
        
        private void SetToolForeColor(Color color)
        {
            User.ForegroundColor = color;
            ActionToolSetForeColor?.Invoke(color);
        }

        private void SetColorDockColor(Color color)
        {
            ActionColorSetColor?.Invoke(color);
        }
        
        public void SetStatusBarZoomPercentage(float percentage)
        {
            stat_canvasZoom.Text = (percentage).ToString("#.##") + "%";
        }

        private void SetStatusBarDocResolution(int width, int height)
        {
            stat_resolution.Text = width + " x " + height + " (pixel)";
        }

        private void UseMaskForProject(bool enable)
        {
            mActiveDoc.Project.IsUsingMask = enable;
        }

        private void SetFormTitle(string title)
        {
            Text = string.IsNullOrEmpty(title) ? "Spriten" : title + " - Spriten";
        }

        public void UpdateLayerList(List<DrawableMask> drawables)
        {
            ActionLayerUpdate?.Invoke(drawables);
        }

        private void RefreshActiveCanvas()
        {
            mActiveDoc.RefreshCanvas();
        }

        private void UpdateDocumentsBrush()
        {
            DocumentDock doc;
            for (int i = mDockPanel.Contents.Count - 1; i >= 0; i--)
            {
                if ((doc = mDockPanel.Contents[i] as DocumentDock) != null)
                {
                    doc.Canvas.UpdateBrushOutline();
                    doc.InvalidateBrush();
                }
            }
        }

        private void ReplaceMaskColor(byte type, int argb)
        {
            DocumentDock doc;
            for (int i = mDockPanel.Contents.Count - 1; i >= 0; i--)
            {
                if ((doc = mDockPanel.Contents[i] as DocumentDock) != null && doc.Project.IsUsingMask)
                {
                    doc.ReplaceMaskColor(type, argb);
                    doc.RefreshCanvas();
                }
            }
        }

        private void Open(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                DocumentDock documentDock = new DocumentDock(this, FileHelper.DeserializeBinary<Project>(fileName));
                documentDock.ProjectPath = fileName;

                if (mDockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    documentDock.MdiParent = this;
                    documentDock.Show();
                }
                else
                {
                    documentDock.Show(mDockPanel);
                }

                documentDock.FitCanvasToScreen();
            }
        }

        #region Status strip events

        private void stat_canvasZoom_itemClick(object sender, EventArgs e)
        {
            string percentage = (sender as ToolStripMenuItem).Text;
            mActiveDoc.SetZoomPercentage(float.Parse(percentage.Remove(percentage.Length - 1)));
        }

        private void zoom_custom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string input = zoom_custom.Text;
                if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, "^[0-9]{0,4}([.,][0-9]{0,2})?(%)?$"))
                {
                    int lastCharIndex = input.Length - 1;
                    if (input[lastCharIndex] == '%')
                    {
                        input = input.Remove(lastCharIndex);
                    }
                    mActiveDoc.SetZoomPercentage(float.Parse(input));
                    zoom_custom.Owner.Hide();
                }

                zoom_custom.Clear();
            }
        }

        private void stat_canvasZoom_DropDownOpened(object sender, EventArgs e)
        {
            zoom_custom.Text = stat_canvasZoom.Text;
            zoom_custom.Focus();
            zoom_custom.SelectAll();
        }

        #endregion

        #region Menu strip events

        #region File

        // Display available file actions
        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            bool enabled = HasActiveDocument();

            saveToolStripMenuItem.Enabled = enabled;
            saveAsToolStripMenuItem.Enabled = enabled;
            exportToolStripMenuItem.Enabled = enabled;
            documentToolStripMenuItem.Enabled = enabled;
            closeToolStripMenuItem.Enabled = enabled;
            closeAllToolStripMenuItem.Enabled = HasDocument();
            generateToolStripMenuItem.Enabled = enabled;
            procGenToolStripMenuItem.Enabled = enabled && mActiveDoc.Project.IsUsingMask && mActiveDoc.Project.DrawableList.Count > 0;
        }

        // New document
        private void mainFileNew_Click(object sender, EventArgs e)
        {
            using (DocumentDialog docDialog = new DocumentDialog("Untitled-" + (mDocumentID + 1)))
            {
                if (docDialog.ShowDialog() == DialogResult.OK)
                {
                    DocumentDock documentDock = new DocumentDock(this, docDialog.Project, docDialog.DocBackground);
                    documentDock.InsertDrawable(Color.Transparent, null, InsertMode.Above);

                    if (mDockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                    {
                        documentDock.MdiParent = this;
                        documentDock.Show();
                    }
                    else
                    {
                        documentDock.Show(mDockPanel);
                    }

                    documentDock.FitCanvasToScreen();
                    mDocumentID++;
                }
            }
        }

        // Open project
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Spriten Raster Object (*.sro)|*.sro";
                openDialog.Multiselect = false;

                if (openDialog.ShowDialog() == DialogResult.OK)
                    Open(openDialog.FileName);
            }
        }

        // Save project
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mActiveDoc != null && !string.IsNullOrEmpty(mActiveDoc.ProjectPath))
            {
                mActiveDoc.Canvas.Project.LastSaved = DateTime.Now;
                FileHelper.SerializeBinary(mActiveDoc.Project, mActiveDoc.ProjectPath);
            }
            else
                saveAsToolStripMenuItem_Click(sender, e);
        }

        // Save project as
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mActiveDoc != null)
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.FileName = mActiveDoc.Text;
                    saveDialog.Filter = "Spriten Raster Object (*.sro)|*.sro";

                    if (saveDialog.ShowDialog() == DialogResult.OK && saveDialog.FileName != "")
                    {
                        string fileName = saveDialog.FileName;
                        mActiveDoc.Canvas.Project.LastSaved = DateTime.Now;
                        FileHelper.SerializeBinary(mActiveDoc.Project, fileName);
                        mActiveDoc.ProjectPath = fileName;
                    }
                }
            }
        }

        // Export image
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.FileName = mActiveDoc.Text;
                saveDialog.Filter = "Bitmap Image (*.bmp)|*.bmp|Gif Image (*.gif)|*.gif|Jpeg Image (*.jpg, *jpeg)|*.jpg|PNG Image (*.png)|*.png|Spriten Masking Data (*.smd)|*.smd";

                if (saveDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(saveDialog.FileName))
                {
                    var fileName = saveDialog.FileName;
                    var image = mActiveDoc.GenerateImage(Color.Transparent);

                    switch (saveDialog.FilterIndex)
                    {
                        case 1:
                            image.Save(fileName, ImageFormat.Bmp);
                            break;
                        case 2:
                            image.Save(fileName, ImageFormat.Gif);
                            break;
                        case 3:
                            image.Save(fileName, ImageFormat.Jpeg);
                            break;
                        case 4:
                            image.Save(fileName, ImageFormat.Png);
                            break;
                    }

                    image.Dispose();
                }
            }
        }

        // Generate procedural sprite
        private void procGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.FileName = mActiveDoc.Text;
                saveDialog.Filter = "Bitmap Image (*.bmp)|*.bmp|Gif Image (*.gif)|*.gif|Jpeg Image (*.jpg, *jpeg)|*.jpg|PNG Image (*.png)|*.png";

                if (saveDialog.ShowDialog() == DialogResult.OK && saveDialog.FileName != "")
                {
                    var fileName = saveDialog.FileName;

                    using (ProcGenDialog genDialog = new ProcGenDialog(mActiveDoc.Project.DrawableList))
                    {
                        // generate image and save
                        if (genDialog.ShowDialog() == DialogResult.OK)
                        {
                            SpriteSettings settings = genDialog.Settings;
                            if (settings.ExportIndividual)
                            {
                                string name = Path.GetFileNameWithoutExtension(fileName);
                                string path = Path.GetDirectoryName(fileName);
                                string ext = Path.GetExtension(fileName);

                                for (int i = 0; i < settings.SpriteCount; i++)
                                {
                                    Bitmap image = SpriteHelper.GenerateSprite(mActiveDoc.Project.DrawableList, settings);
                                    string newFilename = Path.Combine(path, name + "-" + (i + 1) + ext);

                                    switch (saveDialog.FilterIndex)
                                    {
                                        case 1:
                                            image.Save(newFilename, ImageFormat.Bmp);
                                            break;
                                        case 2:
                                            image.Save(newFilename, ImageFormat.Gif);
                                            break;
                                        case 3:
                                            image.Save(newFilename, ImageFormat.Jpeg);
                                            break;
                                        case 4:
                                            image.Save(newFilename, ImageFormat.Png);
                                            break;
                                    }

                                    image.Dispose();
                                }
                            }
                            else
                            {
                                Bitmap image = SpriteHelper.GenerateSpriteAtlas(mActiveDoc.Project.DrawableList, settings, settings.SpriteCount, 0);

                                switch (saveDialog.FilterIndex)
                                {
                                    case 1:
                                        image.Save(fileName, ImageFormat.Bmp);
                                        break;
                                    case 2:
                                        image.Save(fileName, ImageFormat.Gif);
                                        break;
                                    case 3:
                                        image.Save(fileName, ImageFormat.Jpeg);
                                        break;
                                    case 4:
                                        image.Save(fileName, ImageFormat.Png);
                                        break;
                                }

                                image.Dispose();
                            }
                        }
                    }
                }
            }
        }

        // Texture synthesis
        private void textureSynthesisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.FileName = mActiveDoc.Text;
                saveDialog.Filter = "Bitmap Image (*.bmp)|*.bmp|Gif Image (*.gif)|*.gif|Jpeg Image (*.jpg, *jpeg)|*.jpg|PNG Image (*.png)|*.png";

                if (saveDialog.ShowDialog() == DialogResult.OK && saveDialog.FileName != "")
                {
                    var fileName = saveDialog.FileName;
                    Bitmap image = mActiveDoc.GenerateImage(Color.Transparent);
                    int imgWidth = image.Width, imgHeight = image.Height;
                    int[] bitmapArr = ImageHelper.GetArgbFromBmp(image);
                    image.Dispose();

                    using (TexSynDialog texSynDialog = new TexSynDialog(bitmapArr, imgWidth, imgHeight))
                    {
                        // generate image and save
                        if (texSynDialog.ShowDialog() == DialogResult.OK)
                        {
                            TexSynSettings settings = texSynDialog.Settings;
                            string name = Path.GetFileNameWithoutExtension(fileName);
                            string path = Path.GetDirectoryName(fileName);
                            string ext = Path.GetExtension(fileName);
                            int[] outputArr;

                            for (int i = 0; i < settings.GenerateCount; i++)
                            {
                                switch (settings.Mode)
                                {
                                    case SynMode.Coherent:
                                        outputArr = TexSynHelper.CoherentSynthesis(bitmapArr, imgWidth, imgHeight, settings.K, settings.N, settings.OutputWidth, settings.OutputHeight, settings.Temperature, settings.Indexed);
                                        break;
                                    case SynMode.Harrison:
                                        outputArr = TexSynHelper.ReSynthesis(bitmapArr, imgWidth, imgHeight, settings.N, settings.M, settings.Polish, settings.OutputWidth, settings.OutputHeight, settings.Indexed);
                                        break;
                                    default:
                                        outputArr = TexSynHelper.FullSynthesis(bitmapArr, imgWidth, imgHeight, settings.N, settings.OutputWidth, settings.OutputHeight, settings.Temperature, settings.Indexed);
                                        break;
                                }

                                Bitmap texture = ImageHelper.GetBmpFromArgb(outputArr, settings.OutputWidth, settings.OutputHeight);
                                Bitmap output = ImageHelper.ResizeBitmap(texture, settings.OutputWidth * settings.Scale, settings.OutputHeight * settings.Scale);
                                string newFilename = Path.Combine(path, name + "-" + (i + 1) + ext);
                                
                                switch (saveDialog.FilterIndex)
                                {
                                    case 1:
                                        output.Save(newFilename, ImageFormat.Bmp);
                                        break;
                                    case 2:
                                        output.Save(newFilename, ImageFormat.Gif);
                                        break;
                                    case 3:
                                        output.Save(newFilename, ImageFormat.Jpeg);
                                        break;
                                    case 4:
                                        output.Save(newFilename, ImageFormat.Png);
                                        break;
                                }

                                texture.Dispose();
                                output.Dispose();
                            }
                        }
                    }
                }
            }
        }

        // Document info
        private void documentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(DocInfoDialog docDlg = new DocInfoDialog(mActiveDoc.Canvas.Project))
            {
                if(docDlg.ShowDialog() == DialogResult.OK)
                {
                    mActiveDoc.Canvas.Project.Title = mActiveDoc.Text = docDlg.DocTitle;
                    SetFormTitle(docDlg.DocTitle);
                }
            }
        }

        // Close
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mActiveDoc != null)
                mActiveDoc.Dispose();
        }

        // Close all
        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentDock doc;

            for (int i = mDockPanel.Contents.Count - 1; i >= 0; i--)
            {
                if ((doc = mDockPanel.Contents[i] as DocumentDock) != null)
                {
                    doc.Dispose();
                    doc = null;
                }
            }
        }

        // Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region View

        private void viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            bool enabled = HasActiveDocument();

            zoomInToolStripMenuItem.Enabled = enabled;
            zoomOutToolStripMenuItem.Enabled = enabled;
            fitOnScreenToolStripMenuItem.Enabled = enabled;
            resetTo100ToolStripMenuItem.Enabled = enabled;
            centerCanvasToolStripMenuItem.Enabled = enabled;

            pixelGridToolStripMenuItem.Checked = User.ShowPixelGrid;
            brushOutlineToolStripMenuItem.Checked = User.ShowBrushOutline;

            bool maskEnabled = enabled && mActiveDoc.Project.IsUsingMask;
            viewMaskToolStripMenuItem.Enabled = maskEnabled;
            viewMaskToolStripMenuItem.Checked = maskEnabled && User.IsMaskingMode;
        }

        // Zoom in by 10%
        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mActiveDoc != null)
                mActiveDoc.ZoomByPercentage(100f);
        }

        // Zoom out by 10%
        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mActiveDoc != null)
                mActiveDoc.ZoomByPercentage(-100f);
        }

        // Fit canvas on screen
        private void fitOnScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mActiveDoc?.FitCanvasToScreen();
        }

        // Reset zoom level to 100%
        private void resetTo100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mActiveDoc != null)
            {
                mActiveDoc.SetZoomFactor(1);
                mActiveDoc.CenterCanvas();
            }
        }

        // Center canvas
        private void centerCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mActiveDoc?.CenterCanvas();
        }

        // Toggle brush outline visibility
        private void brushOutlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User.ShowBrushOutline = brushOutlineToolStripMenuItem.Checked;
        }

        // Toggle pixel grid visibility
        private void pixelGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User.ShowPixelGrid = pixelGridToolStripMenuItem.Checked;
            RefreshDocuments();
        }

        // Toggle mask mode
        private void viewMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User.IsMaskingMode = viewMaskToolStripMenuItem.Checked;
            ActionMaskCheckMaskMode?.Invoke(User.IsMaskingMode);

            DocumentDock doc;
            for (int i = mDockPanel.Contents.Count - 1; i >= 0; i--)
            {
                if ((doc = mDockPanel.Contents[i] as DocumentDock) != null && doc.Project.IsUsingMask)
                    doc.RefreshCanvas();
            }
        }

        #endregion

        #region Edit

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            bool hasSelectedLayer = mLayerDock.IsHandleCreated ? mLayerDock.HasItemSelected() : false;
            bool clipboardHasItem = User.DrawablesClipboard.Count > 0;

            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = false;

            cutToolStripMenuItem.Enabled = hasSelectedLayer;
            copyToolStripMenuItem.Enabled = hasSelectedLayer;
            pasteToolStripMenuItem.Enabled = clipboardHasItem;
            pasteToGroupToolStripMenuItem.Visible = hasSelectedLayer && mLayerDock.IsSelectingGroup();
            pasteToGroupToolStripMenuItem.Enabled = clipboardHasItem;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mLayerDock.CutAction(sender, e);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mLayerDock.CopyAction(sender, e);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mLayerDock.PasteAction(sender, e);
        }

        private void pasteToGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mLayerDock.PasteToGroupAction(sender, e);
        }

        #endregion

        #region Window

        // Display status of the docks
        private void windowToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            colorToolStripMenuItem.Checked = mColorDock.IsHandleCreated;
            layerToolStripMenuItem.Checked = mLayerDock.IsHandleCreated;
            maskToolStripMenuItem.Checked = mMaskDock.IsHandleCreated;
            toolToolStripMenuItem.Checked = mToolDock.IsHandleCreated;
        }

        // Toggle color dock
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mColorDock.IsHandleCreated)
            {
                SetupColorDock();

                if (mMaskDock.IsHandleCreated)
                {
                    mMaskDock.Select();
                    mColorDock.Show(mDockPanel);
                }
                else if (mLayerDock.IsHandleCreated)
                    mColorDock.Show(mLayerDock.Pane, DockAlignment.Top, 0.38);
                else
                    mColorDock.Show(mDockPanel);
            }
            else
            {
                mColorDock.Close();
                mColorDock.Dispose();
            }
        }

        // Toggle layer dock
        private void layerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mLayerDock.IsHandleCreated)
            {
                SetupLayerDock();

                if (mColorDock.IsHandleCreated)
                    mLayerDock.Show(mColorDock.Pane, DockAlignment.Bottom, 0.62);
                else if (mMaskDock.IsHandleCreated)
                    mLayerDock.Show(mMaskDock.Pane, DockAlignment.Bottom, 0.62);
                else
                    mLayerDock.Show(mDockPanel);

                if (HasActiveDocument())
                    ActionLayerRefresh(mActiveDoc.Project.DrawableList);
            }
            else
            {
                mLayerDock.Close();
                mLayerDock.Dispose();
            }
        }

        // Toggle mask dock
        private void maskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mMaskDock.IsHandleCreated)
            {
                SetupMaskDock();

                if (mColorDock.IsHandleCreated)
                {
                    mColorDock.Select();
                    mMaskDock.Show(mDockPanel);
                }
                else if (mLayerDock.IsHandleCreated)
                    mMaskDock.Show(mLayerDock.Pane, DockAlignment.Top, 0.38);
                else
                    mMaskDock.Show(mDockPanel);
            }
            else
            {
                mMaskDock.Close();
                mMaskDock.Dispose();
            }
        }

        // Toggle tool dock
        private void toolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mToolDock.IsHandleCreated)
            {
                SetupToolDock();
                mToolDock.Show(mDockPanel);
            }
            else
            {
                mToolDock.Close();
                mToolDock.Dispose();
            }
        }

        #endregion

        #region Help

        // GitHub page
        private void SpritenGithubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Chris95Hua/spriten");
        }

        // About
        private void aboutSpritenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(AboutDialog aboutDlg = new AboutDialog())
            {
                aboutDlg.ShowDialog();
            }
        }

        #endregion

        #endregion

        #region Dock panel events

        private void mDockPanel_ActiveContentChanged(object sender, EventArgs e)
        {
            DocumentDock doc = mDockPanel.ActiveContent as DocumentDock;

            if (doc != null)
            {
                mActiveDoc = doc;
                ActionLayerRefresh?.Invoke(mActiveDoc.Project.DrawableList);
                ActionMaskCheckUseMask?.Invoke(mActiveDoc.Project.IsUsingMask);
                ActionLayerSetButton?.Invoke(true);
                SetFormTitle(mActiveDoc.Text);
                SetStatusBarDocResolution(mActiveDoc.Project.Width, mActiveDoc.Project.Height);
                SetStatusBarZoomPercentage(mActiveDoc.Canvas.CanvasScale * 100f);
                stat_canvas.Visible = true;
            }
            else if (!HasActiveDocument())
            {
                SetFormTitle(string.Empty);
                stat_canvas.Visible = false;
                ActionLayerSetButton?.Invoke(false);
                ActionMaskSetControls?.Invoke(false);
            }
        }

        #endregion

        #region Form events

        // Save docks layout and colors
        private void Spriten_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close all
            closeAllToolStripMenuItem_Click(sender, e);

            // cleanup
            User.ClearClipboard();
            ImageHelper.DisposeTextureBrushes();

            // save layout
            string layoutConfig = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Layout.config");
            mDockPanel.SaveAsXml(layoutConfig);

            // save settings
            Properties.Settings.Default["UserToolMode"] = User.ToolMode;
            Properties.Settings.Default["ForegroundColor"] = User.ForegroundColor;
            Properties.Settings.Default["BackgroundColor"] = User.BackgroundColor;
            Properties.Settings.Default["MaskBorderColor"] = User.MaskBorder;
            Properties.Settings.Default["MaskBodyColor"] = User.MaskBody;
            Properties.Settings.Default["MaskBorderBodyColor"] = User.MaskBorderBody;
            Properties.Settings.Default["MaskEmptyBodyColor"] = User.MaskEmptyBody;
            Properties.Settings.Default["ShowBrushOutline"] = User.ShowBrushOutline;
            Properties.Settings.Default["ShowPixelGrid"] = User.ShowPixelGrid;
            Properties.Settings.Default["ColorDockSelectorMode"] = User.ColodDockSelector;
            Properties.Settings.Default["PenSize"] = User.PenSize;
            Properties.Settings.Default["PenOpacity"] = User.PenOpacity;

            Properties.Settings.Default.Save();
        }

        #endregion

        private void lbl_foreColor_Click(object sender, EventArgs e)
        {
            using (Dialog.ColorDialog colDialog = new Dialog.ColorDialog(User.ForegroundColor))
            {
                if (colDialog.ShowDialog() == DialogResult.OK)
                {
                    SetToolStripForeColor(colDialog.SelectedColor);
                    mToolDock?.SetForegroundColor(User.ForegroundColor);
                    SetColorDockColor(User.ForegroundColor);
                }
            }
        }

        private void lbl_backColor_Click(object sender, EventArgs e)
        {
            using (Dialog.ColorDialog colDialog = new Dialog.ColorDialog(User.BackgroundColor))
            {
                if (colDialog.ShowDialog() == DialogResult.OK)
                {
                    SetToolStripBackColor(colDialog.SelectedColor);
                    mToolDock?.SetBackgroundColor(User.BackgroundColor);
                }
            }
        }

        private void btn_switchColor_Click(object sender, EventArgs e)
        {
            Color temp = User.ForegroundColor;
            SetToolStripForeColor(User.BackgroundColor);
            mToolDock?.SetForegroundColor(User.ForegroundColor);
            SetToolStripBackColor(temp);
            mToolDock?.SetBackgroundColor(temp);
            SetColorDockColor(User.ForegroundColor);
        }

        public void SetToolStripForeColor(Color color)
        {
            lbl_foreColor.BackColor = User.ForegroundColor = color;
        }

        public void SetToolStripBackColor(Color color)
        {
            lbl_backColor.BackColor = User.BackgroundColor = color;
        }
    }
}
