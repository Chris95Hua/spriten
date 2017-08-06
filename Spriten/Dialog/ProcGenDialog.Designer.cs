namespace Spriten.Dialog
{
    partial class ProcGenDialog
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.num_count = new System.Windows.Forms.NumericUpDown();
            this.cmb_fill = new System.Windows.Forms.ComboBox();
            this.lbl_background = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_preview = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_edgeColor = new System.Windows.Forms.Label();
            this.chk_mirrorX = new System.Windows.Forms.CheckBox();
            this.chk_mirrorY = new System.Windows.Forms.CheckBox();
            this.num_scale = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.num_paddingX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.num_paddingY = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_shading = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_edgeType = new System.Windows.Forms.ComboBox();
            this.chk_separate = new System.Windows.Forms.CheckBox();
            this.chk_byLayer = new System.Windows.Forms.CheckBox();
            this.chk_randomGroup = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.lbl_fillColor = new System.Windows.Forms.Label();
            this.num_margin = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_previewCount = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.num_noise = new System.Windows.Forms.NumericUpDown();
            this.num_fillBrightness = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.num_edgeBrightness = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.pic_preview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_paddingX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_paddingY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_margin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_noise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fillBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_edgeBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_preview)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(436, 386);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(80, 23);
            this.btn_cancel.TabIndex = 22;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(341, 386);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 23);
            this.btn_ok.TabIndex = 21;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // num_count
            // 
            this.num_count.Location = new System.Drawing.Point(125, 55);
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
            this.num_count.TabIndex = 2;
            this.num_count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmb_fill
            // 
            this.cmb_fill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_fill.FormattingEnabled = true;
            this.cmb_fill.Items.AddRange(new object[] {
            "Default",
            "Random",
            "Custom"});
            this.cmb_fill.Location = new System.Drawing.Point(125, 156);
            this.cmb_fill.Name = "cmb_fill";
            this.cmb_fill.Size = new System.Drawing.Size(79, 21);
            this.cmb_fill.TabIndex = 6;
            this.cmb_fill.SelectedIndexChanged += new System.EventHandler(this.SpriteSettingsChanged);
            // 
            // lbl_background
            // 
            this.lbl_background.AutoSize = true;
            this.lbl_background.Location = new System.Drawing.Point(59, 159);
            this.lbl_background.Name = "lbl_background";
            this.lbl_background.Size = new System.Drawing.Size(49, 13);
            this.lbl_background.TabIndex = 13;
            this.lbl_background.Text = "Fill Color:";
            this.lbl_background.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sprite Count:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Preview:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk_preview
            // 
            this.chk_preview.AutoSize = true;
            this.chk_preview.Checked = true;
            this.chk_preview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_preview.Location = new System.Drawing.Point(266, 300);
            this.chk_preview.Name = "chk_preview";
            this.chk_preview.Size = new System.Drawing.Size(100, 17);
            this.chk_preview.TabIndex = 18;
            this.chk_preview.Text = "Enable Preview";
            this.chk_preview.UseVisualStyleBackColor = true;
            this.chk_preview.CheckedChanged += new System.EventHandler(this.chk_preview_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Edge Color:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_edgeColor
            // 
            this.lbl_edgeColor.BackColor = System.Drawing.Color.White;
            this.lbl_edgeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_edgeColor.Location = new System.Drawing.Point(210, 182);
            this.lbl_edgeColor.Name = "lbl_edgeColor";
            this.lbl_edgeColor.Size = new System.Drawing.Size(22, 22);
            this.lbl_edgeColor.TabIndex = 9;
            this.lbl_edgeColor.BackColorChanged += new System.EventHandler(this.SpriteSettingsChanged);
            this.lbl_edgeColor.Click += new System.EventHandler(this.LabelColorChanged);
            // 
            // chk_mirrorX
            // 
            this.chk_mirrorX.AutoSize = true;
            this.chk_mirrorX.Location = new System.Drawing.Point(125, 108);
            this.chk_mirrorX.Name = "chk_mirrorX";
            this.chk_mirrorX.Size = new System.Drawing.Size(54, 17);
            this.chk_mirrorX.TabIndex = 4;
            this.chk_mirrorX.Text = "X-axis";
            this.chk_mirrorX.UseVisualStyleBackColor = true;
            this.chk_mirrorX.CheckedChanged += new System.EventHandler(this.PreviewResolutionChanged);
            // 
            // chk_mirrorY
            // 
            this.chk_mirrorY.AutoSize = true;
            this.chk_mirrorY.Location = new System.Drawing.Point(125, 131);
            this.chk_mirrorY.Name = "chk_mirrorY";
            this.chk_mirrorY.Size = new System.Drawing.Size(54, 17);
            this.chk_mirrorY.TabIndex = 5;
            this.chk_mirrorY.Text = "Y-axis";
            this.chk_mirrorY.UseVisualStyleBackColor = true;
            this.chk_mirrorY.CheckedChanged += new System.EventHandler(this.PreviewResolutionChanged);
            // 
            // num_scale
            // 
            this.num_scale.Location = new System.Drawing.Point(125, 82);
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
            this.num_scale.TabIndex = 3;
            this.num_scale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_scale.ValueChanged += new System.EventHandler(this.PreviewResolutionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Sprite Scale:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_paddingX
            // 
            this.num_paddingX.Location = new System.Drawing.Point(125, 285);
            this.num_paddingX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_paddingX.Name = "num_paddingX";
            this.num_paddingX.Size = new System.Drawing.Size(107, 20);
            this.num_paddingX.TabIndex = 13;
            this.num_paddingX.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.num_paddingX.ValueChanged += new System.EventHandler(this.PreviewResolutionChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Padding X:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_paddingY
            // 
            this.num_paddingY.Location = new System.Drawing.Point(125, 311);
            this.num_paddingY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_paddingY.Name = "num_paddingY";
            this.num_paddingY.Size = new System.Drawing.Size(107, 20);
            this.num_paddingY.TabIndex = 14;
            this.num_paddingY.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.num_paddingY.ValueChanged += new System.EventHandler(this.PreviewResolutionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Padding Y:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_shading
            // 
            this.cmb_shading.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_shading.FormattingEnabled = true;
            this.cmb_shading.Items.AddRange(new object[] {
            "Default",
            "Vertical",
            "Horizontal",
            "None"});
            this.cmb_shading.Location = new System.Drawing.Point(125, 210);
            this.cmb_shading.Name = "cmb_shading";
            this.cmb_shading.Size = new System.Drawing.Size(107, 21);
            this.cmb_shading.TabIndex = 10;
            this.cmb_shading.SelectedIndexChanged += new System.EventHandler(this.SpriteSettingsChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Shading:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_edgeType
            // 
            this.cmb_edgeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_edgeType.FormattingEnabled = true;
            this.cmb_edgeType.Items.AddRange(new object[] {
            "Default",
            "Custom"});
            this.cmb_edgeType.Location = new System.Drawing.Point(125, 183);
            this.cmb_edgeType.Name = "cmb_edgeType";
            this.cmb_edgeType.Size = new System.Drawing.Size(79, 21);
            this.cmb_edgeType.TabIndex = 8;
            this.cmb_edgeType.SelectedIndexChanged += new System.EventHandler(this.SpriteSettingsChanged);
            // 
            // chk_separate
            // 
            this.chk_separate.AutoSize = true;
            this.chk_separate.Location = new System.Drawing.Point(125, 237);
            this.chk_separate.Name = "chk_separate";
            this.chk_separate.Size = new System.Drawing.Size(110, 17);
            this.chk_separate.TabIndex = 11;
            this.chk_separate.Text = "Export individually";
            this.chk_separate.UseVisualStyleBackColor = true;
            this.chk_separate.CheckedChanged += new System.EventHandler(this.chk_separate_CheckedChanged_1);
            // 
            // chk_byLayer
            // 
            this.chk_byLayer.AutoSize = true;
            this.chk_byLayer.Location = new System.Drawing.Point(125, 9);
            this.chk_byLayer.Name = "chk_byLayer";
            this.chk_byLayer.Size = new System.Drawing.Size(90, 17);
            this.chk_byLayer.TabIndex = 0;
            this.chk_byLayer.Text = "Seed by layer";
            this.chk_byLayer.UseVisualStyleBackColor = true;
            this.chk_byLayer.CheckedChanged += new System.EventHandler(this.SpriteSettingsChanged);
            // 
            // chk_randomGroup
            // 
            this.chk_randomGroup.AutoSize = true;
            this.chk_randomGroup.Location = new System.Drawing.Point(125, 32);
            this.chk_randomGroup.Name = "chk_randomGroup";
            this.chk_randomGroup.Size = new System.Drawing.Size(119, 17);
            this.chk_randomGroup.TabIndex = 1;
            this.chk_randomGroup.Text = "Random from group";
            this.chk_randomGroup.UseVisualStyleBackColor = true;
            this.chk_randomGroup.CheckedChanged += new System.EventHandler(this.SpriteSettingsChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(72, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Mirror:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(441, 296);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 19;
            this.btn_update.Text = "Regenerate";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // lbl_fillColor
            // 
            this.lbl_fillColor.BackColor = System.Drawing.Color.White;
            this.lbl_fillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_fillColor.Location = new System.Drawing.Point(210, 156);
            this.lbl_fillColor.Name = "lbl_fillColor";
            this.lbl_fillColor.Size = new System.Drawing.Size(22, 22);
            this.lbl_fillColor.TabIndex = 7;
            this.lbl_fillColor.BackColorChanged += new System.EventHandler(this.SpriteSettingsChanged);
            this.lbl_fillColor.Click += new System.EventHandler(this.LabelColorChanged);
            // 
            // num_margin
            // 
            this.num_margin.Location = new System.Drawing.Point(125, 259);
            this.num_margin.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_margin.Name = "num_margin";
            this.num_margin.Size = new System.Drawing.Size(107, 20);
            this.num_margin.TabIndex = 12;
            this.num_margin.ValueChanged += new System.EventHandler(this.PreviewResolutionChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(66, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Margin:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_previewCount
            // 
            this.cmb_previewCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_previewCount.FormattingEnabled = true;
            this.cmb_previewCount.Items.AddRange(new object[] {
            "Quad",
            "Single"});
            this.cmb_previewCount.Location = new System.Drawing.Point(441, 323);
            this.cmb_previewCount.Name = "cmb_previewCount";
            this.cmb_previewCount.Size = new System.Drawing.Size(75, 21);
            this.cmb_previewCount.TabIndex = 20;
            this.cmb_previewCount.SelectedIndexChanged += new System.EventHandler(this.PreviewResolutionChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(263, 326);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Preview Sprite Count:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_noise
            // 
            this.num_noise.DecimalPlaces = 2;
            this.num_noise.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_noise.Location = new System.Drawing.Point(125, 337);
            this.num_noise.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_noise.Name = "num_noise";
            this.num_noise.Size = new System.Drawing.Size(107, 20);
            this.num_noise.TabIndex = 15;
            this.num_noise.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.num_noise.ValueChanged += new System.EventHandler(this.PreviewResolutionChanged);
            // 
            // num_fillBrightness
            // 
            this.num_fillBrightness.DecimalPlaces = 2;
            this.num_fillBrightness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_fillBrightness.Location = new System.Drawing.Point(125, 363);
            this.num_fillBrightness.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_fillBrightness.Name = "num_fillBrightness";
            this.num_fillBrightness.Size = new System.Drawing.Size(107, 20);
            this.num_fillBrightness.TabIndex = 16;
            this.num_fillBrightness.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            this.num_fillBrightness.ValueChanged += new System.EventHandler(this.PreviewResolutionChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(56, 339);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Fill Noise:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 365);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Fill Brightness:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_edgeBrightness
            // 
            this.num_edgeBrightness.DecimalPlaces = 2;
            this.num_edgeBrightness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_edgeBrightness.Location = new System.Drawing.Point(125, 389);
            this.num_edgeBrightness.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_edgeBrightness.Name = "num_edgeBrightness";
            this.num_edgeBrightness.Size = new System.Drawing.Size(107, 20);
            this.num_edgeBrightness.TabIndex = 17;
            this.num_edgeBrightness.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.num_edgeBrightness.ValueChanged += new System.EventHandler(this.PreviewResolutionChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 391);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Edge Brightness:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pic_preview
            // 
            this.pic_preview.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pic_preview.Location = new System.Drawing.Point(266, 41);
            this.pic_preview.Name = "pic_preview";
            this.pic_preview.Size = new System.Drawing.Size(250, 250);
            this.pic_preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_preview.TabIndex = 15;
            this.pic_preview.TabStop = false;
            // 
            // ProcGenDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 421);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.chk_mirrorY);
            this.Controls.Add(this.chk_mirrorX);
            this.Controls.Add(this.chk_randomGroup);
            this.Controls.Add(this.chk_byLayer);
            this.Controls.Add(this.chk_separate);
            this.Controls.Add(this.chk_preview);
            this.Controls.Add(this.lbl_fillColor);
            this.Controls.Add(this.lbl_edgeColor);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbl_background);
            this.Controls.Add(this.num_edgeBrightness);
            this.Controls.Add(this.num_fillBrightness);
            this.Controls.Add(this.num_noise);
            this.Controls.Add(this.num_paddingY);
            this.Controls.Add(this.num_margin);
            this.Controls.Add(this.num_paddingX);
            this.Controls.Add(this.cmb_shading);
            this.Controls.Add(this.num_scale);
            this.Controls.Add(this.cmb_edgeType);
            this.Controls.Add(this.cmb_previewCount);
            this.Controls.Add(this.cmb_fill);
            this.Controls.Add(this.num_count);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.pic_preview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcGenDialog";
            this.ShowInTaskbar = false;
            this.Text = "Sprite Generation Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GenerationDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.num_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_paddingX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_paddingY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_margin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_noise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fillBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_edgeBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.NumericUpDown num_count;
        private System.Windows.Forms.ComboBox cmb_fill;
        private System.Windows.Forms.Label lbl_background;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk_preview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_edgeColor;
        private System.Windows.Forms.CheckBox chk_mirrorX;
        private System.Windows.Forms.CheckBox chk_mirrorY;
        private System.Windows.Forms.NumericUpDown num_scale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_paddingX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown num_paddingY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_shading;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pic_preview;
        private System.Windows.Forms.ComboBox cmb_edgeType;
        private System.Windows.Forms.CheckBox chk_separate;
        private System.Windows.Forms.CheckBox chk_byLayer;
        private System.Windows.Forms.CheckBox chk_randomGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Label lbl_fillColor;
        private System.Windows.Forms.NumericUpDown num_margin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_previewCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown num_noise;
        private System.Windows.Forms.NumericUpDown num_fillBrightness;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown num_edgeBrightness;
        private System.Windows.Forms.Label label13;
    }
}