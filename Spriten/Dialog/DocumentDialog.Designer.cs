namespace Spriten.Dialog
{
    partial class DocumentDialog
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.chk_lockRatio = new System.Windows.Forms.CheckBox();
            this.lbl_width = new System.Windows.Forms.Label();
            this.lbl_height = new System.Windows.Forms.Label();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.cmb_background = new System.Windows.Forms.ComboBox();
            this.lbl_background = new System.Windows.Forms.Label();
            this.num_width = new System.Windows.Forms.NumericUpDown();
            this.num_height = new System.Windows.Forms.NumericUpDown();
            this.label_backgroundColor = new System.Windows.Forms.Label();
            this.chk_useMask = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_height)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(64, 266);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 23);
            this.btn_ok.TabIndex = 7;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(159, 266);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(80, 23);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // chk_lockRatio
            // 
            this.chk_lockRatio.AutoSize = true;
            this.chk_lockRatio.Location = new System.Drawing.Point(102, 145);
            this.chk_lockRatio.Name = "chk_lockRatio";
            this.chk_lockRatio.Size = new System.Drawing.Size(108, 17);
            this.chk_lockRatio.TabIndex = 4;
            this.chk_lockRatio.Text = "Lock aspect ratio";
            this.chk_lockRatio.UseVisualStyleBackColor = true;
            this.chk_lockRatio.CheckedChanged += new System.EventHandler(this.chk_lockRatio_CheckedChanged);
            // 
            // lbl_width
            // 
            this.lbl_width.AutoSize = true;
            this.lbl_width.Location = new System.Drawing.Point(47, 96);
            this.lbl_width.Name = "lbl_width";
            this.lbl_width.Size = new System.Drawing.Size(38, 13);
            this.lbl_width.TabIndex = 6;
            this.lbl_width.Text = "Width:";
            this.lbl_width.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_height
            // 
            this.lbl_height.AutoSize = true;
            this.lbl_height.Location = new System.Drawing.Point(44, 122);
            this.lbl_height.Name = "lbl_height";
            this.lbl_height.Size = new System.Drawing.Size(41, 13);
            this.lbl_height.TabIndex = 6;
            this.lbl_height.Text = "Height:";
            this.lbl_height.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(102, 24);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(137, 20);
            this.txt_title.TabIndex = 0;
            this.txt_title.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterKeyDown);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(55, 27);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(30, 13);
            this.lbl_name.TabIndex = 6;
            this.lbl_name.Text = "Title:";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_background
            // 
            this.cmb_background.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_background.FormattingEnabled = true;
            this.cmb_background.Items.AddRange(new object[] {
            "White",
            "Transparent",
            "Background Color",
            "Custom"});
            this.cmb_background.Location = new System.Drawing.Point(102, 196);
            this.cmb_background.Name = "cmb_background";
            this.cmb_background.Size = new System.Drawing.Size(111, 21);
            this.cmb_background.TabIndex = 5;
            this.cmb_background.SelectedIndexChanged += new System.EventHandler(this.cmb_background_SelectedIndexChanged);
            // 
            // lbl_background
            // 
            this.lbl_background.AutoSize = true;
            this.lbl_background.Location = new System.Drawing.Point(17, 199);
            this.lbl_background.Name = "lbl_background";
            this.lbl_background.Size = new System.Drawing.Size(68, 13);
            this.lbl_background.TabIndex = 6;
            this.lbl_background.Text = "Background:";
            this.lbl_background.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_width
            // 
            this.num_width.Location = new System.Drawing.Point(102, 94);
            this.num_width.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_width.Name = "num_width";
            this.num_width.Size = new System.Drawing.Size(101, 20);
            this.num_width.TabIndex = 2;
            this.num_width.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.num_width.ValueChanged += new System.EventHandler(this.num_width_ValueChanged);
            this.num_width.Enter += new System.EventHandler(this.NumericUpDownHasFocus);
            this.num_width.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterKeyDown);
            // 
            // num_height
            // 
            this.num_height.Location = new System.Drawing.Point(102, 120);
            this.num_height.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_height.Name = "num_height";
            this.num_height.Size = new System.Drawing.Size(101, 20);
            this.num_height.TabIndex = 3;
            this.num_height.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.num_height.ValueChanged += new System.EventHandler(this.num_height_ValueChanged);
            this.num_height.Enter += new System.EventHandler(this.NumericUpDownHasFocus);
            this.num_height.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterKeyDown);
            // 
            // label_backgroundColor
            // 
            this.label_backgroundColor.BackColor = System.Drawing.Color.White;
            this.label_backgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_backgroundColor.Location = new System.Drawing.Point(218, 196);
            this.label_backgroundColor.Name = "label_backgroundColor";
            this.label_backgroundColor.Size = new System.Drawing.Size(21, 22);
            this.label_backgroundColor.TabIndex = 6;
            this.label_backgroundColor.Click += new System.EventHandler(this.label_backgroundColor_Click);
            // 
            // chk_useMask
            // 
            this.chk_useMask.AutoSize = true;
            this.chk_useMask.Location = new System.Drawing.Point(102, 50);
            this.chk_useMask.Name = "chk_useMask";
            this.chk_useMask.Size = new System.Drawing.Size(73, 17);
            this.chk_useMask.TabIndex = 1;
            this.chk_useMask.Text = "Use mask";
            this.chk_useMask.UseVisualStyleBackColor = true;
            this.chk_useMask.CheckedChanged += new System.EventHandler(this.chk_useMask_CheckedChanged);
            // 
            // DocumentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 301);
            this.Controls.Add(this.chk_useMask);
            this.Controls.Add(this.label_backgroundColor);
            this.Controls.Add(this.num_height);
            this.Controls.Add(this.num_width);
            this.Controls.Add(this.cmb_background);
            this.Controls.Add(this.lbl_background);
            this.Controls.Add(this.lbl_height);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_width);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.chk_lockRatio);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocumentDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "New Document";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocumentDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.num_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_height)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.CheckBox chk_lockRatio;
        private System.Windows.Forms.Label lbl_width;
        private System.Windows.Forms.Label lbl_height;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.ComboBox cmb_background;
        private System.Windows.Forms.Label lbl_background;
        private System.Windows.Forms.NumericUpDown num_width;
        private System.Windows.Forms.NumericUpDown num_height;
        private System.Windows.Forms.Label label_backgroundColor;
        private System.Windows.Forms.CheckBox chk_useMask;
    }
}