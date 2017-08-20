namespace Spriten
{
    partial class Spriten
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Spriten));
            this.stat_canvas = new System.Windows.Forms.StatusStrip();
            this.stat_canvasZoom = new System.Windows.Forms.ToolStripDropDownButton();
            this.zoom_1000 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom_500 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom_250 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom_80 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom_50 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom_25 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom_custom = new System.Windows.Forms.ToolStripTextBox();
            this.stat_resolution = new System.Windows.Forms.ToolStripStatusLabel();
            this.stat_empty = new System.Windows.Forms.ToolStripStatusLabel();
            this.stat_progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.stat_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu_mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_mainFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procGenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textureSynthesisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.documentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitOnScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTo100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerCanvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.brushOutlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpritenGithubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSpritenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mDockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.pnl_color = new System.Windows.Forms.Panel();
            this.lbl_foreColor = new System.Windows.Forms.Label();
            this.lbl_backColor = new System.Windows.Forms.Label();
            this.btn_switchColor = new System.Windows.Forms.Button();
            this.tool_actions = new System.Windows.Forms.FlowLayoutPanel();
            this.stat_canvas.SuspendLayout();
            this.menu_mainMenu.SuspendLayout();
            this.pnl_color.SuspendLayout();
            this.tool_actions.SuspendLayout();
            this.SuspendLayout();
            // 
            // stat_canvas
            // 
            this.stat_canvas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stat_canvasZoom,
            this.stat_resolution,
            this.stat_empty,
            this.stat_progressBar,
            this.stat_status});
            this.stat_canvas.Location = new System.Drawing.Point(0, 539);
            this.stat_canvas.Name = "stat_canvas";
            this.stat_canvas.Size = new System.Drawing.Size(784, 22);
            this.stat_canvas.TabIndex = 5;
            this.stat_canvas.Text = "status";
            this.stat_canvas.Visible = false;
            // 
            // stat_canvasZoom
            // 
            this.stat_canvasZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stat_canvasZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoom_1000,
            this.zoom_500,
            this.zoom_250,
            this.zoom_100,
            this.zoom_80,
            this.zoom_50,
            this.zoom_25,
            this.zoom_custom});
            this.stat_canvasZoom.Name = "stat_canvasZoom";
            this.stat_canvasZoom.Size = new System.Drawing.Size(50, 20);
            this.stat_canvasZoom.Text = "zoom";
            this.stat_canvasZoom.ToolTipText = "Zoom percentage";
            this.stat_canvasZoom.DropDownOpened += new System.EventHandler(this.stat_canvasZoom_DropDownOpened);
            // 
            // zoom_1000
            // 
            this.zoom_1000.Name = "zoom_1000";
            this.zoom_1000.Size = new System.Drawing.Size(160, 22);
            this.zoom_1000.Text = "1000%";
            this.zoom_1000.Click += new System.EventHandler(this.stat_canvasZoom_itemClick);
            // 
            // zoom_500
            // 
            this.zoom_500.Name = "zoom_500";
            this.zoom_500.Size = new System.Drawing.Size(160, 22);
            this.zoom_500.Text = "500%";
            this.zoom_500.Click += new System.EventHandler(this.stat_canvasZoom_itemClick);
            // 
            // zoom_250
            // 
            this.zoom_250.Name = "zoom_250";
            this.zoom_250.Size = new System.Drawing.Size(160, 22);
            this.zoom_250.Text = "250%";
            this.zoom_250.Click += new System.EventHandler(this.stat_canvasZoom_itemClick);
            // 
            // zoom_100
            // 
            this.zoom_100.Name = "zoom_100";
            this.zoom_100.Size = new System.Drawing.Size(160, 22);
            this.zoom_100.Text = "100%";
            this.zoom_100.Click += new System.EventHandler(this.stat_canvasZoom_itemClick);
            // 
            // zoom_80
            // 
            this.zoom_80.Name = "zoom_80";
            this.zoom_80.Size = new System.Drawing.Size(160, 22);
            this.zoom_80.Text = "80%";
            this.zoom_80.Click += new System.EventHandler(this.stat_canvasZoom_itemClick);
            // 
            // zoom_50
            // 
            this.zoom_50.Name = "zoom_50";
            this.zoom_50.Size = new System.Drawing.Size(160, 22);
            this.zoom_50.Text = "50%";
            this.zoom_50.Click += new System.EventHandler(this.stat_canvasZoom_itemClick);
            // 
            // zoom_25
            // 
            this.zoom_25.Name = "zoom_25";
            this.zoom_25.Size = new System.Drawing.Size(160, 22);
            this.zoom_25.Text = "25%";
            this.zoom_25.Click += new System.EventHandler(this.stat_canvasZoom_itemClick);
            // 
            // zoom_custom
            // 
            this.zoom_custom.Name = "zoom_custom";
            this.zoom_custom.Size = new System.Drawing.Size(100, 23);
            this.zoom_custom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zoom_custom_KeyDown);
            // 
            // stat_resolution
            // 
            this.stat_resolution.Name = "stat_resolution";
            this.stat_resolution.Size = new System.Drawing.Size(60, 17);
            this.stat_resolution.Text = "resolution";
            // 
            // stat_empty
            // 
            this.stat_empty.Name = "stat_empty";
            this.stat_empty.Size = new System.Drawing.Size(659, 17);
            this.stat_empty.Spring = true;
            // 
            // stat_progressBar
            // 
            this.stat_progressBar.Name = "stat_progressBar";
            this.stat_progressBar.Size = new System.Drawing.Size(100, 16);
            this.stat_progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.stat_progressBar.Visible = false;
            // 
            // stat_status
            // 
            this.stat_status.Name = "stat_status";
            this.stat_status.Size = new System.Drawing.Size(38, 17);
            this.stat_status.Text = "status";
            this.stat_status.Visible = false;
            // 
            // menu_mainMenu
            // 
            this.menu_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu_mainMenu.Location = new System.Drawing.Point(0, 0);
            this.menu_mainMenu.Name = "menu_mainMenu";
            this.menu_mainMenu.Size = new System.Drawing.Size(784, 24);
            this.menu_mainMenu.TabIndex = 6;
            this.menu_mainMenu.Text = "Spriten Menu Strip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_mainFileNew,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.toolStripSeparator6,
            this.documentToolStripMenuItem,
            this.toolStripSeparator7,
            this.closeToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // menu_mainFileNew
            // 
            this.menu_mainFileNew.Name = "menu_mainFileNew";
            this.menu_mainFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menu_mainFileNew.Size = new System.Drawing.Size(195, 22);
            this.menu_mainFileNew.Text = "New";
            this.menu_mainFileNew.Click += new System.EventHandler(this.mainFileNew_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.procGenToolStripMenuItem,
            this.textureSynthesisToolStripMenuItem});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.generateToolStripMenuItem.Text = "Generate...";
            // 
            // procGenToolStripMenuItem
            // 
            this.procGenToolStripMenuItem.Name = "procGenToolStripMenuItem";
            this.procGenToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.procGenToolStripMenuItem.Text = "Procedural Generation";
            this.procGenToolStripMenuItem.Click += new System.EventHandler(this.procGenToolStripMenuItem_Click);
            // 
            // textureSynthesisToolStripMenuItem
            // 
            this.textureSynthesisToolStripMenuItem.Name = "textureSynthesisToolStripMenuItem";
            this.textureSynthesisToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.textureSynthesisToolStripMenuItem.Text = "Texture Synthesis";
            this.textureSynthesisToolStripMenuItem.Click += new System.EventHandler(this.textureSynthesisToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(192, 6);
            // 
            // documentToolStripMenuItem
            // 
            this.documentToolStripMenuItem.Name = "documentToolStripMenuItem";
            this.documentToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.documentToolStripMenuItem.Text = "Document Info";
            this.documentToolStripMenuItem.Click += new System.EventHandler(this.documentToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(192, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.W)));
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator4,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.pasteToGroupToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(159, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // pasteToGroupToolStripMenuItem
            // 
            this.pasteToGroupToolStripMenuItem.Name = "pasteToGroupToolStripMenuItem";
            this.pasteToGroupToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.pasteToGroupToolStripMenuItem.Text = "Paste Into Group";
            this.pasteToGroupToolStripMenuItem.Click += new System.EventHandler(this.pasteToGroupToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.fitOnScreenToolStripMenuItem,
            this.resetTo100ToolStripMenuItem,
            this.centerCanvasToolStripMenuItem,
            this.toolStripSeparator3,
            this.brushOutlineToolStripMenuItem,
            this.pixelGridToolStripMenuItem,
            this.viewMaskToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this.viewToolStripMenuItem_DropDownOpening);
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl ++";
            this.zoomInToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In (+100%)";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+-";
            this.zoomOutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out (-100%)";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // fitOnScreenToolStripMenuItem
            // 
            this.fitOnScreenToolStripMenuItem.Name = "fitOnScreenToolStripMenuItem";
            this.fitOnScreenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.fitOnScreenToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.fitOnScreenToolStripMenuItem.Text = "Fit on Screen";
            this.fitOnScreenToolStripMenuItem.Click += new System.EventHandler(this.fitOnScreenToolStripMenuItem_Click);
            // 
            // resetTo100ToolStripMenuItem
            // 
            this.resetTo100ToolStripMenuItem.Name = "resetTo100ToolStripMenuItem";
            this.resetTo100ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.resetTo100ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.resetTo100ToolStripMenuItem.Text = "Reset to 100%";
            this.resetTo100ToolStripMenuItem.Click += new System.EventHandler(this.resetTo100ToolStripMenuItem_Click);
            // 
            // centerCanvasToolStripMenuItem
            // 
            this.centerCanvasToolStripMenuItem.Name = "centerCanvasToolStripMenuItem";
            this.centerCanvasToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.centerCanvasToolStripMenuItem.Text = "Center Canvas";
            this.centerCanvasToolStripMenuItem.Click += new System.EventHandler(this.centerCanvasToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(209, 6);
            // 
            // brushOutlineToolStripMenuItem
            // 
            this.brushOutlineToolStripMenuItem.CheckOnClick = true;
            this.brushOutlineToolStripMenuItem.Name = "brushOutlineToolStripMenuItem";
            this.brushOutlineToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.brushOutlineToolStripMenuItem.Text = "Brush Outline";
            this.brushOutlineToolStripMenuItem.Click += new System.EventHandler(this.brushOutlineToolStripMenuItem_Click);
            // 
            // pixelGridToolStripMenuItem
            // 
            this.pixelGridToolStripMenuItem.CheckOnClick = true;
            this.pixelGridToolStripMenuItem.Name = "pixelGridToolStripMenuItem";
            this.pixelGridToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.pixelGridToolStripMenuItem.Text = "Pixel Grid";
            this.pixelGridToolStripMenuItem.Click += new System.EventHandler(this.pixelGridToolStripMenuItem_Click);
            // 
            // viewMaskToolStripMenuItem
            // 
            this.viewMaskToolStripMenuItem.CheckOnClick = true;
            this.viewMaskToolStripMenuItem.Name = "viewMaskToolStripMenuItem";
            this.viewMaskToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.viewMaskToolStripMenuItem.Text = "Mask";
            this.viewMaskToolStripMenuItem.Click += new System.EventHandler(this.viewMaskToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.layerToolStripMenuItem,
            this.maskToolStripMenuItem,
            this.toolToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            this.windowToolStripMenuItem.DropDownOpening += new System.EventHandler(this.windowToolStripMenuItem_DropDownOpening);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // layerToolStripMenuItem
            // 
            this.layerToolStripMenuItem.Name = "layerToolStripMenuItem";
            this.layerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.layerToolStripMenuItem.Text = "Layer";
            this.layerToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // maskToolStripMenuItem
            // 
            this.maskToolStripMenuItem.Name = "maskToolStripMenuItem";
            this.maskToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.maskToolStripMenuItem.Text = "Mask";
            this.maskToolStripMenuItem.Click += new System.EventHandler(this.maskToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.toolToolStripMenuItem.Text = "Tool";
            this.toolToolStripMenuItem.Click += new System.EventHandler(this.toolToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SpritenGithubToolStripMenuItem,
            this.aboutSpritenToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // SpritenGithubToolStripMenuItem
            // 
            this.SpritenGithubToolStripMenuItem.Name = "SpritenGithubToolStripMenuItem";
            this.SpritenGithubToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.SpritenGithubToolStripMenuItem.Text = "Spriten GitHub Page";
            this.SpritenGithubToolStripMenuItem.Click += new System.EventHandler(this.SpritenGithubToolStripMenuItem_Click);
            // 
            // aboutSpritenToolStripMenuItem
            // 
            this.aboutSpritenToolStripMenuItem.Name = "aboutSpritenToolStripMenuItem";
            this.aboutSpritenToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.aboutSpritenToolStripMenuItem.Text = "About Spriten...";
            this.aboutSpritenToolStripMenuItem.Click += new System.EventHandler(this.aboutSpritenToolStripMenuItem_Click);
            // 
            // mDockPanel
            // 
            this.mDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mDockPanel.DockBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mDockPanel.DockLeftPortion = 43D;
            this.mDockPanel.DockRightPortion = 236D;
            this.mDockPanel.Location = new System.Drawing.Point(0, 62);
            this.mDockPanel.Name = "mDockPanel";
            this.mDockPanel.Size = new System.Drawing.Size(784, 499);
            this.mDockPanel.TabIndex = 13;
            this.mDockPanel.ActiveContentChanged += new System.EventHandler(this.mDockPanel_ActiveContentChanged);
            // 
            // pnl_color
            // 
            this.pnl_color.Controls.Add(this.lbl_foreColor);
            this.pnl_color.Controls.Add(this.lbl_backColor);
            this.pnl_color.Controls.Add(this.btn_switchColor);
            this.pnl_color.Location = new System.Drawing.Point(6, 3);
            this.pnl_color.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.pnl_color.Name = "pnl_color";
            this.pnl_color.Size = new System.Drawing.Size(32, 32);
            this.pnl_color.TabIndex = 18;
            // 
            // lbl_foreColor
            // 
            this.lbl_foreColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_foreColor.BackColor = System.Drawing.Color.White;
            this.lbl_foreColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_foreColor.Location = new System.Drawing.Point(0, 0);
            this.lbl_foreColor.Name = "lbl_foreColor";
            this.lbl_foreColor.Size = new System.Drawing.Size(20, 20);
            this.lbl_foreColor.TabIndex = 3;
            this.lbl_foreColor.Click += new System.EventHandler(this.lbl_foreColor_Click);
            // 
            // lbl_backColor
            // 
            this.lbl_backColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_backColor.BackColor = System.Drawing.Color.White;
            this.lbl_backColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_backColor.Location = new System.Drawing.Point(12, 12);
            this.lbl_backColor.Name = "lbl_backColor";
            this.lbl_backColor.Size = new System.Drawing.Size(20, 20);
            this.lbl_backColor.TabIndex = 3;
            this.lbl_backColor.Click += new System.EventHandler(this.lbl_backColor_Click);
            // 
            // btn_switchColor
            // 
            this.btn_switchColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_switchColor.AutoSize = true;
            this.btn_switchColor.FlatAppearance.BorderSize = 0;
            this.btn_switchColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_switchColor.Location = new System.Drawing.Point(21, -3);
            this.btn_switchColor.Name = "btn_switchColor";
            this.btn_switchColor.Size = new System.Drawing.Size(12, 12);
            this.btn_switchColor.TabIndex = 4;
            this.btn_switchColor.UseVisualStyleBackColor = true;
            this.btn_switchColor.Click += new System.EventHandler(this.btn_switchColor_Click);
            // 
            // tool_actions
            // 
            this.tool_actions.AutoSize = true;
            this.tool_actions.Controls.Add(this.pnl_color);
            this.tool_actions.Dock = System.Windows.Forms.DockStyle.Top;
            this.tool_actions.Location = new System.Drawing.Point(0, 24);
            this.tool_actions.Name = "tool_actions";
            this.tool_actions.Size = new System.Drawing.Size(784, 38);
            this.tool_actions.TabIndex = 19;
            // 
            // Spriten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.mDockPanel);
            this.Controls.Add(this.stat_canvas);
            this.Controls.Add(this.tool_actions);
            this.Controls.Add(this.menu_mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu_mainMenu;
            this.Name = "Spriten";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spriten";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Spriten_FormClosing);
            this.stat_canvas.ResumeLayout(false);
            this.stat_canvas.PerformLayout();
            this.menu_mainMenu.ResumeLayout(false);
            this.menu_mainMenu.PerformLayout();
            this.pnl_color.ResumeLayout(false);
            this.pnl_color.PerformLayout();
            this.tool_actions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip stat_canvas;
        private System.Windows.Forms.MenuStrip menu_mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_mainFileNew;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton stat_canvasZoom;
        private System.Windows.Forms.ToolStripMenuItem zoom_100;
        private System.Windows.Forms.ToolStripMenuItem zoom_80;
        private System.Windows.Forms.ToolStripMenuItem zoom_50;
        private System.Windows.Forms.ToolStripMenuItem zoom_25;
        private WeifenLuo.WinFormsUI.Docking.DockPanel mDockPanel;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSpritenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel stat_resolution;
        private System.Windows.Forms.ToolStripStatusLabel stat_empty;
        private System.Windows.Forms.ToolStripStatusLabel stat_status;
        private System.Windows.Forms.ToolStripMenuItem zoom_1000;
        private System.Windows.Forms.ToolStripMenuItem zoom_500;
        private System.Windows.Forms.ToolStripMenuItem zoom_250;
        private System.Windows.Forms.ToolStripTextBox zoom_custom;
        private System.Windows.Forms.ToolStripProgressBar stat_progressBar;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitOnScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetTo100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerCanvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem pixelGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SpritenGithubToolStripMenuItem;
        private System.Windows.Forms.Panel pnl_color;
        private System.Windows.Forms.Button btn_switchColor;
        private System.Windows.Forms.Label lbl_foreColor;
        private System.Windows.Forms.Label lbl_backColor;
        private System.Windows.Forms.FlowLayoutPanel tool_actions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem documentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brushOutlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procGenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textureSynthesisToolStripMenuItem;
    }
}

