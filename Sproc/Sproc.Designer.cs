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
            this.menu_mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_addLayer
            // 
            this.btn_addLayer.Location = new System.Drawing.Point(540, 333);
            this.btn_addLayer.Name = "btn_addLayer";
            this.btn_addLayer.Size = new System.Drawing.Size(75, 23);
            this.btn_addLayer.TabIndex = 2;
            this.btn_addLayer.Text = "Add";
            this.btn_addLayer.UseVisualStyleBackColor = true;
            this.btn_addLayer.Click += new System.EventHandler(this.btn_addLayer_Click);
            // 
            // btn_removeLayer
            // 
            this.btn_removeLayer.Location = new System.Drawing.Point(540, 363);
            this.btn_removeLayer.Name = "btn_removeLayer";
            this.btn_removeLayer.Size = new System.Drawing.Size(75, 23);
            this.btn_removeLayer.TabIndex = 3;
            this.btn_removeLayer.Text = "Remove";
            this.btn_removeLayer.UseVisualStyleBackColor = true;
            this.btn_removeLayer.Click += new System.EventHandler(this.btn_removeLayer_Click);
            // 
            // tree_layers
            // 
            this.tree_layers.Location = new System.Drawing.Point(540, 133);
            this.tree_layers.Name = "tree_layers";
            this.tree_layers.Size = new System.Drawing.Size(121, 142);
            this.tree_layers.TabIndex = 4;
            // 
            // stat_canvas
            // 
            this.stat_canvas.Location = new System.Drawing.Point(0, 539);
            this.stat_canvas.Name = "stat_canvas";
            this.stat_canvas.Size = new System.Drawing.Size(784, 22);
            this.stat_canvas.TabIndex = 5;
            this.stat_canvas.Text = "status";
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
            // Sproc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
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
            this.menu_mainMenu.ResumeLayout(false);
            this.menu_mainMenu.PerformLayout();
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
    }
}

