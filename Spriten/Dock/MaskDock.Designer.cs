namespace Spriten.Dock
{
    partial class MaskDock
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
            this.lbl_border = new System.Windows.Forms.Label();
            this.lbl_emptyBody = new System.Windows.Forms.Label();
            this.lbl_borderBody = new System.Windows.Forms.Label();
            this.rad_borderBody = new System.Windows.Forms.RadioButton();
            this.rad_emptyBody = new System.Windows.Forms.RadioButton();
            this.rad_border = new System.Windows.Forms.RadioButton();
            this.chk_maskMode = new System.Windows.Forms.CheckBox();
            this.MaskPanel = new System.Windows.Forms.Panel();
            this.lbl_body = new System.Windows.Forms.Label();
            this.rad_body = new System.Windows.Forms.RadioButton();
            this.chk_useMask = new System.Windows.Forms.CheckBox();
            this.MaskPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_border
            // 
            this.lbl_border.BackColor = System.Drawing.Color.Salmon;
            this.lbl_border.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_border.Location = new System.Drawing.Point(178, 55);
            this.lbl_border.Name = "lbl_border";
            this.lbl_border.Size = new System.Drawing.Size(24, 24);
            this.lbl_border.TabIndex = 4;
            this.lbl_border.Click += new System.EventHandler(this.ChangeMaskColor);
            // 
            // lbl_emptyBody
            // 
            this.lbl_emptyBody.BackColor = System.Drawing.Color.LightGreen;
            this.lbl_emptyBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_emptyBody.Location = new System.Drawing.Point(178, 166);
            this.lbl_emptyBody.Name = "lbl_emptyBody";
            this.lbl_emptyBody.Size = new System.Drawing.Size(24, 24);
            this.lbl_emptyBody.TabIndex = 6;
            this.lbl_emptyBody.Click += new System.EventHandler(this.ChangeMaskColor);
            // 
            // lbl_borderBody
            // 
            this.lbl_borderBody.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_borderBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_borderBody.Location = new System.Drawing.Point(178, 129);
            this.lbl_borderBody.Name = "lbl_borderBody";
            this.lbl_borderBody.Size = new System.Drawing.Size(24, 24);
            this.lbl_borderBody.TabIndex = 8;
            this.lbl_borderBody.Click += new System.EventHandler(this.ChangeMaskColor);
            // 
            // rad_borderBody
            // 
            this.rad_borderBody.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rad_borderBody.Location = new System.Drawing.Point(25, 125);
            this.rad_borderBody.Name = "rad_borderBody";
            this.rad_borderBody.Size = new System.Drawing.Size(105, 30);
            this.rad_borderBody.TabIndex = 7;
            this.rad_borderBody.Text = "Border/Body";
            this.rad_borderBody.UseVisualStyleBackColor = true;
            this.rad_borderBody.CheckedChanged += new System.EventHandler(this.MaskMode_CheckedChanged);
            // 
            // rad_emptyBody
            // 
            this.rad_emptyBody.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rad_emptyBody.Location = new System.Drawing.Point(25, 162);
            this.rad_emptyBody.Name = "rad_emptyBody";
            this.rad_emptyBody.Size = new System.Drawing.Size(105, 30);
            this.rad_emptyBody.TabIndex = 5;
            this.rad_emptyBody.Text = "Empty/Body";
            this.rad_emptyBody.UseVisualStyleBackColor = true;
            this.rad_emptyBody.CheckedChanged += new System.EventHandler(this.MaskMode_CheckedChanged);
            // 
            // rad_border
            // 
            this.rad_border.Checked = true;
            this.rad_border.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rad_border.Location = new System.Drawing.Point(25, 51);
            this.rad_border.Name = "rad_border";
            this.rad_border.Size = new System.Drawing.Size(105, 30);
            this.rad_border.TabIndex = 3;
            this.rad_border.TabStop = true;
            this.rad_border.Text = "Border";
            this.rad_border.UseVisualStyleBackColor = true;
            this.rad_border.CheckedChanged += new System.EventHandler(this.MaskMode_CheckedChanged);
            // 
            // chk_maskMode
            // 
            this.chk_maskMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_maskMode.AutoSize = true;
            this.chk_maskMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_maskMode.Location = new System.Drawing.Point(25, 15);
            this.chk_maskMode.Name = "chk_maskMode";
            this.chk_maskMode.Size = new System.Drawing.Size(73, 23);
            this.chk_maskMode.TabIndex = 0;
            this.chk_maskMode.Text = "Mask Mode";
            this.chk_maskMode.UseVisualStyleBackColor = true;
            this.chk_maskMode.CheckedChanged += new System.EventHandler(this.chk_maskMode_CheckedChanged);
            // 
            // MaskPanel
            // 
            this.MaskPanel.Controls.Add(this.lbl_body);
            this.MaskPanel.Controls.Add(this.rad_body);
            this.MaskPanel.Controls.Add(this.chk_useMask);
            this.MaskPanel.Controls.Add(this.chk_maskMode);
            this.MaskPanel.Controls.Add(this.lbl_emptyBody);
            this.MaskPanel.Controls.Add(this.lbl_borderBody);
            this.MaskPanel.Controls.Add(this.lbl_border);
            this.MaskPanel.Controls.Add(this.rad_border);
            this.MaskPanel.Controls.Add(this.rad_borderBody);
            this.MaskPanel.Controls.Add(this.rad_emptyBody);
            this.MaskPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskPanel.Location = new System.Drawing.Point(0, 0);
            this.MaskPanel.Name = "MaskPanel";
            this.MaskPanel.Size = new System.Drawing.Size(226, 206);
            this.MaskPanel.TabIndex = 28;
            // 
            // lbl_body
            // 
            this.lbl_body.BackColor = System.Drawing.Color.NavajoWhite;
            this.lbl_body.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_body.Location = new System.Drawing.Point(178, 92);
            this.lbl_body.Name = "lbl_body";
            this.lbl_body.Size = new System.Drawing.Size(24, 24);
            this.lbl_body.TabIndex = 10;
            this.lbl_body.Click += new System.EventHandler(this.ChangeMaskColor);
            // 
            // rad_body
            // 
            this.rad_body.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rad_body.Location = new System.Drawing.Point(25, 88);
            this.rad_body.Name = "rad_body";
            this.rad_body.Size = new System.Drawing.Size(105, 30);
            this.rad_body.TabIndex = 9;
            this.rad_body.Text = "Body";
            this.rad_body.UseVisualStyleBackColor = true;
            // 
            // chk_useMask
            // 
            this.chk_useMask.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_useMask.AutoSize = true;
            this.chk_useMask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_useMask.Location = new System.Drawing.Point(137, 15);
            this.chk_useMask.Name = "chk_useMask";
            this.chk_useMask.Size = new System.Drawing.Size(65, 23);
            this.chk_useMask.TabIndex = 2;
            this.chk_useMask.Text = "Use Mask";
            this.chk_useMask.UseVisualStyleBackColor = true;
            this.chk_useMask.CheckedChanged += new System.EventHandler(this.chk_useMask_CheckedChanged);
            // 
            // MaskDock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 206);
            this.Controls.Add(this.MaskPanel);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(235, 230);
            this.Name = "MaskDock";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Mask";
            this.MaskPanel.ResumeLayout(false);
            this.MaskPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_border;
        private System.Windows.Forms.Label lbl_emptyBody;
        private System.Windows.Forms.Label lbl_borderBody;
        private System.Windows.Forms.RadioButton rad_borderBody;
        private System.Windows.Forms.RadioButton rad_emptyBody;
        private System.Windows.Forms.RadioButton rad_border;
        private System.Windows.Forms.CheckBox chk_maskMode;
        private System.Windows.Forms.CheckBox chk_useMask;
        private System.Windows.Forms.Panel MaskPanel;
        private System.Windows.Forms.Label lbl_body;
        private System.Windows.Forms.RadioButton rad_body;
    }
}