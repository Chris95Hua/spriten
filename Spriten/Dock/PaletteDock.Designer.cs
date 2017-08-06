namespace Spriten.Dock
{
    partial class PaletteDock
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
            this.components = new System.ComponentModel.Container();
            this.pnl_palette = new System.Windows.Forms.FlowLayoutPanel();
            this.PaletteActionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_add = new System.Windows.Forms.Button();
            this.tip_layer = new System.Windows.Forms.ToolTip(this.components);
            this.PaletteActionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_palette
            // 
            this.pnl_palette.AllowDrop = true;
            this.pnl_palette.AutoScroll = true;
            this.pnl_palette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_palette.Location = new System.Drawing.Point(0, 20);
            this.pnl_palette.Name = "pnl_palette";
            this.pnl_palette.Size = new System.Drawing.Size(218, 154);
            this.pnl_palette.TabIndex = 0;
            // 
            // PaletteActionPanel
            // 
            this.PaletteActionPanel.AutoSize = true;
            this.PaletteActionPanel.Controls.Add(this.btn_add);
            this.PaletteActionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PaletteActionPanel.Location = new System.Drawing.Point(0, 0);
            this.PaletteActionPanel.Name = "PaletteActionPanel";
            this.PaletteActionPanel.Size = new System.Drawing.Size(218, 20);
            this.PaletteActionPanel.TabIndex = 0;
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
            // PaletteDock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 174);
            this.Controls.Add(this.pnl_palette);
            this.Controls.Add(this.PaletteActionPanel);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaletteDock";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Color Palette";
            this.PaletteActionPanel.ResumeLayout(false);
            this.PaletteActionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel pnl_palette;
        public System.Windows.Forms.FlowLayoutPanel PaletteActionPanel;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ToolTip tip_layer;
    }
}