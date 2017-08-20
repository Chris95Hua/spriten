namespace Spriten.Dock
{
    partial class ToolDock
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
            this.lbl_foreColor = new System.Windows.Forms.Label();
            this.lbl_backColor = new System.Windows.Forms.Label();
            this.rad_pen = new System.Windows.Forms.RadioButton();
            this.rad_eraser = new System.Windows.Forms.RadioButton();
            this.ToolPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.rad_fill = new System.Windows.Forms.RadioButton();
            this.rad_colorPicker = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_switchColor = new System.Windows.Forms.Button();
            this.tip_tool = new System.Windows.Forms.ToolTip(this.components);
            this.ToolPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_foreColor
            // 
            this.lbl_foreColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_foreColor.BackColor = System.Drawing.Color.White;
            this.lbl_foreColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_foreColor.Location = new System.Drawing.Point(0, 0);
            this.lbl_foreColor.Name = "lbl_foreColor";
            this.lbl_foreColor.Size = new System.Drawing.Size(17, 17);
            this.lbl_foreColor.TabIndex = 3;
            this.lbl_foreColor.Click += new System.EventHandler(this.label_primaryColor_Click);
            // 
            // lbl_backColor
            // 
            this.lbl_backColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_backColor.BackColor = System.Drawing.Color.White;
            this.lbl_backColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_backColor.Location = new System.Drawing.Point(10, 10);
            this.lbl_backColor.Name = "lbl_backColor";
            this.lbl_backColor.Size = new System.Drawing.Size(17, 17);
            this.lbl_backColor.TabIndex = 3;
            this.lbl_backColor.Click += new System.EventHandler(this.label_secondaryColor_Click);
            // 
            // rad_pen
            // 
            this.rad_pen.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad_pen.AutoSize = true;
            this.rad_pen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rad_pen.FlatAppearance.BorderSize = 0;
            this.rad_pen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_pen.Location = new System.Drawing.Point(3, 3);
            this.rad_pen.Name = "rad_pen";
            this.rad_pen.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.rad_pen.Size = new System.Drawing.Size(8, 8);
            this.rad_pen.TabIndex = 4;
            this.rad_pen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tip_tool.SetToolTip(this.rad_pen, "Pencil (B)");
            this.rad_pen.UseVisualStyleBackColor = true;
            this.rad_pen.CheckedChanged += new System.EventHandler(this.ToolSelected);
            // 
            // rad_eraser
            // 
            this.rad_eraser.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad_eraser.AutoSize = true;
            this.rad_eraser.FlatAppearance.BorderSize = 0;
            this.rad_eraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_eraser.Location = new System.Drawing.Point(17, 3);
            this.rad_eraser.Name = "rad_eraser";
            this.rad_eraser.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.rad_eraser.Size = new System.Drawing.Size(8, 8);
            this.rad_eraser.TabIndex = 4;
            this.rad_eraser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tip_tool.SetToolTip(this.rad_eraser, "Eraser (E)");
            this.rad_eraser.UseVisualStyleBackColor = true;
            this.rad_eraser.CheckedChanged += new System.EventHandler(this.ToolSelected);
            // 
            // ToolPanel
            // 
            this.ToolPanel.Controls.Add(this.rad_pen);
            this.ToolPanel.Controls.Add(this.rad_eraser);
            this.ToolPanel.Controls.Add(this.rad_fill);
            this.ToolPanel.Controls.Add(this.rad_colorPicker);
            this.ToolPanel.Controls.Add(this.panel1);
            this.ToolPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolPanel.MinimumSize = new System.Drawing.Size(32, 128);
            this.ToolPanel.Name = "ToolPanel";
            this.ToolPanel.Size = new System.Drawing.Size(120, 262);
            this.ToolPanel.TabIndex = 5;
            // 
            // rad_fill
            // 
            this.rad_fill.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad_fill.AutoSize = true;
            this.rad_fill.FlatAppearance.BorderSize = 0;
            this.rad_fill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_fill.Location = new System.Drawing.Point(31, 3);
            this.rad_fill.Name = "rad_fill";
            this.rad_fill.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.rad_fill.Size = new System.Drawing.Size(8, 8);
            this.rad_fill.TabIndex = 4;
            this.rad_fill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tip_tool.SetToolTip(this.rad_fill, "Bucket fill (G)");
            this.rad_fill.UseVisualStyleBackColor = true;
            this.rad_fill.CheckedChanged += new System.EventHandler(this.ToolSelected);
            // 
            // rad_colorPicker
            // 
            this.rad_colorPicker.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad_colorPicker.AutoSize = true;
            this.rad_colorPicker.FlatAppearance.BorderSize = 0;
            this.rad_colorPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_colorPicker.Location = new System.Drawing.Point(45, 3);
            this.rad_colorPicker.Name = "rad_colorPicker";
            this.rad_colorPicker.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.rad_colorPicker.Size = new System.Drawing.Size(8, 8);
            this.rad_colorPicker.TabIndex = 4;
            this.rad_colorPicker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tip_tool.SetToolTip(this.rad_colorPicker, "Color pipette (I)");
            this.rad_colorPicker.UseVisualStyleBackColor = true;
            this.rad_colorPicker.CheckedChanged += new System.EventHandler(this.ToolSelected);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_foreColor);
            this.panel1.Controls.Add(this.btn_switchColor);
            this.panel1.Controls.Add(this.lbl_backColor);
            this.panel1.Location = new System.Drawing.Point(59, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(27, 27);
            this.panel1.TabIndex = 6;
            // 
            // btn_switchColor
            // 
            this.btn_switchColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_switchColor.FlatAppearance.BorderSize = 0;
            this.btn_switchColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_switchColor.Location = new System.Drawing.Point(15, 0);
            this.btn_switchColor.Name = "btn_switchColor";
            this.btn_switchColor.Size = new System.Drawing.Size(10, 10);
            this.btn_switchColor.TabIndex = 4;
            this.btn_switchColor.UseVisualStyleBackColor = true;
            this.btn_switchColor.Click += new System.EventHandler(this.btn_switchColor_Click);
            // 
            // ToolDock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 262);
            this.Controls.Add(this.ToolPanel);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(54, 256);
            this.Name = "ToolDock";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Tools";
            this.ToolPanel.ResumeLayout(false);
            this.ToolPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_foreColor;
        private System.Windows.Forms.Label lbl_backColor;
        private System.Windows.Forms.RadioButton rad_pen;
        private System.Windows.Forms.RadioButton rad_eraser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rad_fill;
        private System.Windows.Forms.RadioButton rad_colorPicker;
        private System.Windows.Forms.Button btn_switchColor;
        private System.Windows.Forms.ToolTip tip_tool;
        private System.Windows.Forms.FlowLayoutPanel ToolPanel;
    }
}
