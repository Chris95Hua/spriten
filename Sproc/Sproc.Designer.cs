namespace Sproc
{
    partial class Sproc
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
            this.btn_addLayer = new System.Windows.Forms.Button();
            this.btn_removeLayer = new System.Windows.Forms.Button();
            this.tree_layers = new System.Windows.Forms.TreeView();
            this.stat_canvas = new System.Windows.Forms.StatusStrip();
            this.stat_canvasZoom = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_mainFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_brush = new System.Windows.Forms.RadioButton();
            this.btn_eraser = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stat_canvas.SuspendLayout();
            this.menu_mainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_addLayer
            // 
            this.btn_addLayer.Location = new System.Drawing.Point(697, 200);
            this.btn_addLayer.Name = "btn_addLayer";
            this.btn_addLayer.Size = new System.Drawing.Size(75, 23);
            this.btn_addLayer.TabIndex = 2;
            this.btn_addLayer.Text = "Add";
            this.btn_addLayer.UseVisualStyleBackColor = true;
            this.btn_addLayer.Click += new System.EventHandler(this.btn_addLayer_Click);
            // 
            // btn_removeLayer
            // 
            this.btn_removeLayer.Location = new System.Drawing.Point(697, 230);
            this.btn_removeLayer.Name = "btn_removeLayer";
            this.btn_removeLayer.Size = new System.Drawing.Size(75, 23);
            this.btn_removeLayer.TabIndex = 3;
            this.btn_removeLayer.Text = "Remove";
            this.btn_removeLayer.UseVisualStyleBackColor = true;
            this.btn_removeLayer.Click += new System.EventHandler(this.btn_removeLayer_Click);
            // 
            // tree_layers
            // 
            this.tree_layers.HideSelection = false;
            this.tree_layers.Location = new System.Drawing.Point(651, 36);
            this.tree_layers.Name = "tree_layers";
            this.tree_layers.ShowLines = false;
            this.tree_layers.ShowNodeToolTips = true;
            this.tree_layers.Size = new System.Drawing.Size(121, 142);
            this.tree_layers.TabIndex = 4;
            this.tree_layers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_layers_AfterSelect);
            // 
            // stat_canvas
            // 
            this.stat_canvas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stat_canvasZoom});
            this.stat_canvas.Location = new System.Drawing.Point(0, 539);
            this.stat_canvas.Name = "stat_canvas";
            this.stat_canvas.Size = new System.Drawing.Size(784, 22);
            this.stat_canvas.TabIndex = 5;
            this.stat_canvas.Text = "status";
            // 
            // stat_canvasZoom
            // 
            this.stat_canvasZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripMenuItem5,
            this.toolStripMenuItem4,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2});
            this.stat_canvasZoom.Name = "stat_canvasZoom";
            this.stat_canvasZoom.Size = new System.Drawing.Size(50, 20);
            this.stat_canvasZoom.Text = "zoom";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem6.Text = "100%";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem5.Text = "80%";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem4.Text = "50%";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem3.Text = "20%";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem2.Text = "10%";
            // 
            // menu_mainMenu
            // 
            this.menu_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu_mainMenu.Location = new System.Drawing.Point(0, 0);
            this.menu_mainMenu.Name = "menu_mainMenu";
            this.menu_mainMenu.Size = new System.Drawing.Size(784, 24);
            this.menu_mainMenu.TabIndex = 6;
            this.menu_mainMenu.Text = "Sproc Menu Strip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_mainFileNew,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menu_mainFileNew
            // 
            this.menu_mainFileNew.Name = "menu_mainFileNew";
            this.menu_mainFileNew.Size = new System.Drawing.Size(114, 22);
            this.menu_mainFileNew.Text = "New";
            this.menu_mainFileNew.Click += new System.EventHandler(this.mainFileNew_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // btn_brush
            // 
            this.btn_brush.Appearance = System.Windows.Forms.Appearance.Button;
            this.btn_brush.AutoSize = true;
            this.btn_brush.Location = new System.Drawing.Point(20, 34);
            this.btn_brush.Name = "btn_brush";
            this.btn_brush.Size = new System.Drawing.Size(44, 23);
            this.btn_brush.TabIndex = 9;
            this.btn_brush.TabStop = true;
            this.btn_brush.Text = "Brush";
            this.btn_brush.UseVisualStyleBackColor = true;
            this.btn_brush.CheckedChanged += new System.EventHandler(this.toolSelected);
            // 
            // btn_eraser
            // 
            this.btn_eraser.Appearance = System.Windows.Forms.Appearance.Button;
            this.btn_eraser.AutoSize = true;
            this.btn_eraser.Location = new System.Drawing.Point(20, 64);
            this.btn_eraser.Name = "btn_eraser";
            this.btn_eraser.Size = new System.Drawing.Size(47, 23);
            this.btn_eraser.TabIndex = 10;
            this.btn_eraser.TabStop = true;
            this.btn_eraser.Text = "Eraser";
            this.btn_eraser.UseVisualStyleBackColor = true;
            this.btn_eraser.CheckedChanged += new System.EventHandler(this.toolSelected);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_eraser);
            this.panel1.Controls.Add(this.btn_brush);
            this.panel1.Location = new System.Drawing.Point(678, 285);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(94, 167);
            this.panel1.TabIndex = 11;
            // 
            // Sproc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.stat_canvas);
            this.Controls.Add(this.menu_mainMenu);
            this.Controls.Add(this.tree_layers);
            this.Controls.Add(this.btn_removeLayer);
            this.Controls.Add(this.btn_addLayer);
            this.MainMenuStrip = this.menu_mainMenu;
            this.Name = "Sproc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sproc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.stat_canvas.ResumeLayout(false);
            this.stat_canvas.PerformLayout();
            this.menu_mainMenu.ResumeLayout(false);
            this.menu_mainMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_addLayer;
        private System.Windows.Forms.Button btn_removeLayer;
        private System.Windows.Forms.TreeView tree_layers;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.RadioButton btn_brush;
        private System.Windows.Forms.RadioButton btn_eraser;
        private System.Windows.Forms.Panel panel1;
    }
}

