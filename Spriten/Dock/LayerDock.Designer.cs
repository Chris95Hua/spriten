namespace Spriten.Dock
{
    partial class LayerDock
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treelist_layer = new BrightIdeasSoftware.TreeListView();
            this.olvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvVisibility = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLock = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btn_duplicate = new System.Windows.Forms.Button();
            this.btn_group = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.LayerActionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_moveUp = new System.Windows.Forms.Button();
            this.btn_moveDown = new System.Windows.Forms.Button();
            this.LayerPropertiesPanel = new System.Windows.Forms.Panel();
            this.track_opacity = new System.Windows.Forms.TrackBar();
            this.tip_layer = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treelist_layer)).BeginInit();
            this.LayerActionPanel.SuspendLayout();
            this.LayerPropertiesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_opacity)).BeginInit();
            this.SuspendLayout();
            // 
            // treelist_layer
            // 
            this.treelist_layer.AllColumns.Add(this.olvName);
            this.treelist_layer.AllColumns.Add(this.olvVisibility);
            this.treelist_layer.AllColumns.Add(this.olvLock);
            this.treelist_layer.AutoArrange = false;
            this.treelist_layer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.treelist_layer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treelist_layer.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.treelist_layer.CellEditUseWholeCell = false;
            this.treelist_layer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvName,
            this.olvVisibility,
            this.olvLock});
            this.treelist_layer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treelist_layer.FullRowSelect = true;
            this.treelist_layer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.treelist_layer.HideSelection = false;
            this.treelist_layer.IsSimpleDragSource = true;
            this.treelist_layer.IsSimpleDropSink = true;
            this.treelist_layer.Location = new System.Drawing.Point(0, 30);
            this.treelist_layer.Margin = new System.Windows.Forms.Padding(10);
            this.treelist_layer.Name = "treelist_layer";
            this.treelist_layer.RowHeight = 42;
            this.treelist_layer.SelectColumnsOnRightClick = false;
            this.treelist_layer.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.treelist_layer.ShowFilterMenuOnRightClick = false;
            this.treelist_layer.ShowGroups = false;
            this.treelist_layer.ShowHeaderInAllViews = false;
            this.treelist_layer.ShowImagesOnSubItems = true;
            this.treelist_layer.ShowSortIndicators = false;
            this.treelist_layer.Size = new System.Drawing.Size(204, 261);
            this.treelist_layer.TabIndex = 2;
            this.treelist_layer.UseCompatibleStateImageBehavior = false;
            this.treelist_layer.UseHotControls = false;
            this.treelist_layer.UseOverlays = false;
            this.treelist_layer.UseSubItemCheckBoxes = true;
            this.treelist_layer.View = System.Windows.Forms.View.Details;
            this.treelist_layer.VirtualMode = true;
            this.treelist_layer.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.treelist_layer_SubItemChecking);
            this.treelist_layer.SelectedIndexChanged += new System.EventHandler(this.treelist_layer_SelectedIndexChanged);
            this.treelist_layer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treelist_layer_MouseUp);
            // 
            // olvName
            // 
            this.olvName.AspectName = "Name";
            this.olvName.CellEditUseWholeCell = false;
            this.olvName.FillsFreeSpace = true;
            this.olvName.Groupable = false;
            this.olvName.ImageAspectName = "Thumbnail";
            this.olvName.MinimumWidth = 80;
            this.olvName.Searchable = false;
            this.olvName.Sortable = false;
            this.olvName.Text = "Name";
            this.olvName.UseFiltering = false;
            this.olvName.Width = 80;
            // 
            // olvVisibility
            // 
            this.olvVisibility.AspectName = "Visible";
            this.olvVisibility.CheckBoxes = true;
            this.olvVisibility.Groupable = false;
            this.olvVisibility.MaximumWidth = 20;
            this.olvVisibility.Searchable = false;
            this.olvVisibility.Sortable = false;
            this.olvVisibility.Text = "Visibility";
            this.olvVisibility.UseFiltering = false;
            this.olvVisibility.Width = 20;
            // 
            // olvLock
            // 
            this.olvLock.AspectName = "Locked";
            this.olvLock.CheckBoxes = true;
            this.olvLock.Groupable = false;
            this.olvLock.MaximumWidth = 20;
            this.olvLock.Searchable = false;
            this.olvLock.Sortable = false;
            this.olvLock.Text = "Lock";
            this.olvLock.UseFiltering = false;
            this.olvLock.Width = 16;
            // 
            // btn_duplicate
            // 
            this.btn_duplicate.AutoSize = true;
            this.btn_duplicate.FlatAppearance.BorderSize = 0;
            this.btn_duplicate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_duplicate.Location = new System.Drawing.Point(47, 2);
            this.btn_duplicate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_duplicate.Name = "btn_duplicate";
            this.btn_duplicate.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btn_duplicate.Size = new System.Drawing.Size(16, 16);
            this.btn_duplicate.TabIndex = 2;
            this.tip_layer.SetToolTip(this.btn_duplicate, "Duplicate item");
            this.btn_duplicate.UseVisualStyleBackColor = true;
            this.btn_duplicate.Click += new System.EventHandler(this.DuplicateAction);
            // 
            // btn_group
            // 
            this.btn_group.AutoSize = true;
            this.btn_group.FlatAppearance.BorderSize = 0;
            this.btn_group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_group.Location = new System.Drawing.Point(25, 2);
            this.btn_group.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_group.Name = "btn_group";
            this.btn_group.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btn_group.Size = new System.Drawing.Size(16, 16);
            this.btn_group.TabIndex = 1;
            this.tip_layer.SetToolTip(this.btn_group, "Create new group");
            this.btn_group.UseVisualStyleBackColor = true;
            this.btn_group.Click += new System.EventHandler(this.GroupAction);
            // 
            // btn_remove
            // 
            this.btn_remove.AutoSize = true;
            this.btn_remove.FlatAppearance.BorderSize = 0;
            this.btn_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_remove.Location = new System.Drawing.Point(69, 2);
            this.btn_remove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btn_remove.Size = new System.Drawing.Size(16, 16);
            this.btn_remove.TabIndex = 3;
            this.tip_layer.SetToolTip(this.btn_remove, "Remove item");
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.RemoveAction);
            // 
            // btn_add
            // 
            this.btn_add.AutoSize = true;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(3, 2);
            this.btn_add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_add.Name = "btn_add";
            this.btn_add.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btn_add.Size = new System.Drawing.Size(16, 16);
            this.btn_add.TabIndex = 0;
            this.tip_layer.SetToolTip(this.btn_add, "Create new layer");
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // LayerActionPanel
            // 
            this.LayerActionPanel.AutoSize = true;
            this.LayerActionPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LayerActionPanel.Controls.Add(this.btn_add);
            this.LayerActionPanel.Controls.Add(this.btn_group);
            this.LayerActionPanel.Controls.Add(this.btn_duplicate);
            this.LayerActionPanel.Controls.Add(this.btn_remove);
            this.LayerActionPanel.Controls.Add(this.btn_moveUp);
            this.LayerActionPanel.Controls.Add(this.btn_moveDown);
            this.LayerActionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LayerActionPanel.Location = new System.Drawing.Point(0, 271);
            this.LayerActionPanel.Name = "LayerActionPanel";
            this.LayerActionPanel.Size = new System.Drawing.Size(204, 20);
            this.LayerActionPanel.TabIndex = 1;
            // 
            // btn_moveUp
            // 
            this.btn_moveUp.AutoSize = true;
            this.btn_moveUp.FlatAppearance.BorderSize = 0;
            this.btn_moveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_moveUp.Location = new System.Drawing.Point(91, 2);
            this.btn_moveUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_moveUp.Name = "btn_moveUp";
            this.btn_moveUp.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btn_moveUp.Size = new System.Drawing.Size(16, 16);
            this.btn_moveUp.TabIndex = 4;
            this.tip_layer.SetToolTip(this.btn_moveUp, "Move item up");
            this.btn_moveUp.UseVisualStyleBackColor = true;
            this.btn_moveUp.Click += new System.EventHandler(this.MoveUpAction);
            // 
            // btn_moveDown
            // 
            this.btn_moveDown.AutoSize = true;
            this.btn_moveDown.FlatAppearance.BorderSize = 0;
            this.btn_moveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_moveDown.Location = new System.Drawing.Point(113, 2);
            this.btn_moveDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_moveDown.Name = "btn_moveDown";
            this.btn_moveDown.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btn_moveDown.Size = new System.Drawing.Size(16, 16);
            this.btn_moveDown.TabIndex = 5;
            this.tip_layer.SetToolTip(this.btn_moveDown, "Move item down");
            this.btn_moveDown.UseVisualStyleBackColor = true;
            this.btn_moveDown.Click += new System.EventHandler(this.MoveDownAction);
            // 
            // LayerPropertiesPanel
            // 
            this.LayerPropertiesPanel.Controls.Add(this.track_opacity);
            this.LayerPropertiesPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LayerPropertiesPanel.Location = new System.Drawing.Point(0, 0);
            this.LayerPropertiesPanel.Name = "LayerPropertiesPanel";
            this.LayerPropertiesPanel.Size = new System.Drawing.Size(204, 30);
            this.LayerPropertiesPanel.TabIndex = 1;
            // 
            // track_opacity
            // 
            this.track_opacity.Dock = System.Windows.Forms.DockStyle.Top;
            this.track_opacity.LargeChange = 10;
            this.track_opacity.Location = new System.Drawing.Point(0, 0);
            this.track_opacity.Maximum = 100;
            this.track_opacity.Name = "track_opacity";
            this.track_opacity.Size = new System.Drawing.Size(204, 45);
            this.track_opacity.TabIndex = 0;
            this.track_opacity.TickFrequency = 25;
            this.track_opacity.Value = 100;
            // 
            // LayerDock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(204, 291);
            this.Controls.Add(this.LayerActionPanel);
            this.Controls.Add(this.treelist_layer);
            this.Controls.Add(this.LayerPropertiesPanel);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "LayerDock";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Layer";
            ((System.ComponentModel.ISupportInitialize)(this.treelist_layer)).EndInit();
            this.LayerActionPanel.ResumeLayout(false);
            this.LayerActionPanel.PerformLayout();
            this.LayerPropertiesPanel.ResumeLayout(false);
            this.LayerPropertiesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_opacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BrightIdeasSoftware.TreeListView treelist_layer;
        private BrightIdeasSoftware.OLVColumn olvName;
        private BrightIdeasSoftware.OLVColumn olvVisibility;
        private BrightIdeasSoftware.OLVColumn olvLock;
        private System.Windows.Forms.Button btn_duplicate;
        private System.Windows.Forms.Button btn_group;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_moveUp;
        private System.Windows.Forms.Button btn_moveDown;
        private System.Windows.Forms.TrackBar track_opacity;
        private System.Windows.Forms.ToolTip tip_layer;
        private System.Windows.Forms.Panel LayerPropertiesPanel;
        private System.Windows.Forms.FlowLayoutPanel LayerActionPanel;
    }
}
