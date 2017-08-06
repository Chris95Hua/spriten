namespace Spriten.Dialog
{
    partial class TexSynDialog
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
            this.btn_update = new System.Windows.Forms.Button();
            this.chk_preview = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.pic_preview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.num_count = new System.Windows.Forms.NumericUpDown();
            this.num_N = new System.Windows.Forms.NumericUpDown();
            this.num_K = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.num_width = new System.Windows.Forms.NumericUpDown();
            this.num_height = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_mode = new System.Windows.Forms.ComboBox();
            this.num_M = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.num_temp = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.num_polish = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.chk_index = new System.Windows.Forms.CheckBox();
            this.num_scale = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_N)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_K)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_M)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_temp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_polish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scale)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(367, 241);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 13;
            this.btn_update.Text = "Regenerate";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // chk_preview
            // 
            this.chk_preview.AutoSize = true;
            this.chk_preview.Checked = true;
            this.chk_preview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_preview.Location = new System.Drawing.Point(242, 245);
            this.chk_preview.Name = "chk_preview";
            this.chk_preview.Size = new System.Drawing.Size(100, 17);
            this.chk_preview.TabIndex = 12;
            this.chk_preview.Text = "Enable Preview";
            this.chk_preview.UseVisualStyleBackColor = true;
            this.chk_preview.CheckedChanged += new System.EventHandler(this.chk_preview_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Preview:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(362, 296);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(80, 23);
            this.btn_cancel.TabIndex = 15;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(267, 296);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 23);
            this.btn_ok.TabIndex = 14;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // pic_preview
            // 
            this.pic_preview.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pic_preview.Location = new System.Drawing.Point(242, 36);
            this.pic_preview.Name = "pic_preview";
            this.pic_preview.Size = new System.Drawing.Size(200, 200);
            this.pic_preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_preview.TabIndex = 23;
            this.pic_preview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Count:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_count
            // 
            this.num_count.Location = new System.Drawing.Point(107, 16);
            this.num_count.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_count.Name = "num_count";
            this.num_count.Size = new System.Drawing.Size(107, 20);
            this.num_count.TabIndex = 1;
            this.num_count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_N
            // 
            this.num_N.Location = new System.Drawing.Point(107, 196);
            this.num_N.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_N.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_N.Name = "num_N";
            this.num_N.Size = new System.Drawing.Size(107, 20);
            this.num_N.TabIndex = 8;
            this.num_N.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_N.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // num_K
            // 
            this.num_K.Location = new System.Drawing.Point(107, 222);
            this.num_K.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_K.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_K.Name = "num_K";
            this.num_K.Size = new System.Drawing.Size(107, 20);
            this.num_K.TabIndex = 9;
            this.num_K.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_K.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "N:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "K:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_width
            // 
            this.num_width.Location = new System.Drawing.Point(107, 68);
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
            this.num_width.Size = new System.Drawing.Size(107, 20);
            this.num_width.TabIndex = 3;
            this.num_width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_width.ValueChanged += new System.EventHandler(this.num_width_ValueChanged);
            // 
            // num_height
            // 
            this.num_height.Location = new System.Drawing.Point(107, 94);
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
            this.num_height.Size = new System.Drawing.Size(107, 20);
            this.num_height.TabIndex = 4;
            this.num_height.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_height.ValueChanged += new System.EventHandler(this.num_height_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Output Width:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Output Height:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(54, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Mode:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_mode
            // 
            this.cmb_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_mode.FormattingEnabled = true;
            this.cmb_mode.Items.AddRange(new object[] {
            "Full",
            "Coherent",
            "Harrison"});
            this.cmb_mode.Location = new System.Drawing.Point(107, 120);
            this.cmb_mode.Name = "cmb_mode";
            this.cmb_mode.Size = new System.Drawing.Size(107, 21);
            this.cmb_mode.TabIndex = 5;
            this.cmb_mode.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // num_M
            // 
            this.num_M.Location = new System.Drawing.Point(107, 170);
            this.num_M.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_M.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_M.Name = "num_M";
            this.num_M.Size = new System.Drawing.Size(107, 20);
            this.num_M.TabIndex = 7;
            this.num_M.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.num_M.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "M:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_temp
            // 
            this.num_temp.DecimalPlaces = 2;
            this.num_temp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_temp.Location = new System.Drawing.Point(107, 248);
            this.num_temp.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_temp.Name = "num_temp";
            this.num_temp.Size = new System.Drawing.Size(107, 20);
            this.num_temp.TabIndex = 10;
            this.num_temp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_temp.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Temperature:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_polish
            // 
            this.num_polish.Location = new System.Drawing.Point(107, 274);
            this.num_polish.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_polish.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_polish.Name = "num_polish";
            this.num_polish.Size = new System.Drawing.Size(107, 20);
            this.num_polish.TabIndex = 11;
            this.num_polish.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num_polish.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Polish:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk_index
            // 
            this.chk_index.AutoSize = true;
            this.chk_index.Checked = true;
            this.chk_index.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_index.Location = new System.Drawing.Point(107, 147);
            this.chk_index.Name = "chk_index";
            this.chk_index.Size = new System.Drawing.Size(64, 17);
            this.chk_index.TabIndex = 6;
            this.chk_index.Text = "Indexed";
            this.chk_index.UseVisualStyleBackColor = true;
            this.chk_index.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // num_scale
            // 
            this.num_scale.Location = new System.Drawing.Point(107, 42);
            this.num_scale.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_scale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_scale.Name = "num_scale";
            this.num_scale.Size = new System.Drawing.Size(107, 20);
            this.num_scale.TabIndex = 2;
            this.num_scale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_scale.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Scale:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TexSynDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 331);
            this.Controls.Add(this.chk_index);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmb_mode);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_height);
            this.Controls.Add(this.num_width);
            this.Controls.Add(this.num_M);
            this.Controls.Add(this.num_temp);
            this.Controls.Add(this.num_scale);
            this.Controls.Add(this.num_polish);
            this.Controls.Add(this.num_K);
            this.Controls.Add(this.num_N);
            this.Controls.Add(this.num_count);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.chk_preview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.pic_preview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TexSynDialog";
            this.ShowIcon = false;
            this.Text = "Texture Synthesis Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TexSynDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pic_preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_N)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_K)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_M)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_temp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_polish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.CheckBox chk_preview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.PictureBox pic_preview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_count;
        private System.Windows.Forms.NumericUpDown num_N;
        private System.Windows.Forms.NumericUpDown num_K;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown num_width;
        private System.Windows.Forms.NumericUpDown num_height;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_mode;
        private System.Windows.Forms.NumericUpDown num_M;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown num_temp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown num_polish;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chk_index;
        private System.Windows.Forms.NumericUpDown num_scale;
        private System.Windows.Forms.Label label4;
    }
}