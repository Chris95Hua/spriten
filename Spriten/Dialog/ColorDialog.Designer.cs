namespace Spriten.Dialog
{
    partial class ColorDialog
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
            this.colorSlider = new MechanikaDesign.WinForms.UI.ColorPicker.ColorSliderVertical();
            this.colorBox2D = new MechanikaDesign.WinForms.UI.ColorPicker.ColorBox2D();
            this.num_luminance = new System.Windows.Forms.NumericUpDown();
            this.rad_luminance = new System.Windows.Forms.RadioButton();
            this.num_saturation = new System.Windows.Forms.NumericUpDown();
            this.rad_saturation = new System.Windows.Forms.RadioButton();
            this.num_hue = new System.Windows.Forms.NumericUpDown();
            this.rad_hue = new System.Windows.Forms.RadioButton();
            this.num_blue = new System.Windows.Forms.NumericUpDown();
            this.rad_blue = new System.Windows.Forms.RadioButton();
            this.num_green = new System.Windows.Forms.NumericUpDown();
            this.rad_green = new System.Windows.Forms.RadioButton();
            this.num_red = new System.Windows.Forms.NumericUpDown();
            this.rad_red = new System.Windows.Forms.RadioButton();
            this.txt_hex = new System.Windows.Forms.TextBox();
            this.labelHex = new System.Windows.Forms.Label();
            this.lbl_newColor = new System.Windows.Forms.Label();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.lbl_currentColor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_luminance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_saturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_hue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_red)).BeginInit();
            this.SuspendLayout();
            // 
            // colorSlider
            // 
            this.colorSlider.ColorMode = MechanikaDesign.WinForms.UI.ColorPicker.ColorModes.Hue;
            this.colorSlider.ColorRGB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorSlider.Location = new System.Drawing.Point(268, 26);
            this.colorSlider.Name = "colorSlider";
            this.colorSlider.NubColor = System.Drawing.Color.White;
            this.colorSlider.Position = 142;
            this.colorSlider.Size = new System.Drawing.Size(40, 250);
            this.colorSlider.TabIndex = 5;
            this.colorSlider.ColorChanged += new MechanikaDesign.WinForms.UI.ColorPicker.ColorSliderVertical.ColorChangedEventHandler(this.colorSlider_ColorChanged);
            // 
            // colorBox2D
            // 
            this.colorBox2D.ColorMode = MechanikaDesign.WinForms.UI.ColorPicker.ColorModes.Hue;
            this.colorBox2D.ColorRGB = System.Drawing.Color.Red;
            this.colorBox2D.Location = new System.Drawing.Point(12, 26);
            this.colorBox2D.Name = "colorBox2D";
            this.colorBox2D.Size = new System.Drawing.Size(250, 250);
            this.colorBox2D.TabIndex = 4;
            this.colorBox2D.ColorChanged += new MechanikaDesign.WinForms.UI.ColorPicker.ColorBox2D.ColorChangedEventHandler(this.colorBox2D_ColorChanged);
            // 
            // num_luminance
            // 
            this.num_luminance.Location = new System.Drawing.Point(362, 186);
            this.num_luminance.Name = "num_luminance";
            this.num_luminance.Size = new System.Drawing.Size(54, 20);
            this.num_luminance.TabIndex = 29;
            this.num_luminance.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_luminance.ValueChanged += new System.EventHandler(this.num_luminance_ValueChanged);
            // 
            // rad_luminance
            // 
            this.rad_luminance.AutoSize = true;
            this.rad_luminance.Location = new System.Drawing.Point(319, 186);
            this.rad_luminance.Name = "rad_luminance";
            this.rad_luminance.Size = new System.Drawing.Size(34, 17);
            this.rad_luminance.TabIndex = 28;
            this.rad_luminance.Text = "L:";
            this.rad_luminance.UseVisualStyleBackColor = true;
            this.rad_luminance.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // num_saturation
            // 
            this.num_saturation.Location = new System.Drawing.Point(362, 160);
            this.num_saturation.Name = "num_saturation";
            this.num_saturation.Size = new System.Drawing.Size(54, 20);
            this.num_saturation.TabIndex = 27;
            this.num_saturation.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_saturation.ValueChanged += new System.EventHandler(this.num_saturation_ValueChanged);
            // 
            // rad_saturation
            // 
            this.rad_saturation.AutoSize = true;
            this.rad_saturation.Location = new System.Drawing.Point(319, 160);
            this.rad_saturation.Name = "rad_saturation";
            this.rad_saturation.Size = new System.Drawing.Size(35, 17);
            this.rad_saturation.TabIndex = 26;
            this.rad_saturation.Text = "S:";
            this.rad_saturation.UseVisualStyleBackColor = true;
            this.rad_saturation.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // num_hue
            // 
            this.num_hue.Location = new System.Drawing.Point(362, 134);
            this.num_hue.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.num_hue.Name = "num_hue";
            this.num_hue.Size = new System.Drawing.Size(54, 20);
            this.num_hue.TabIndex = 25;
            this.num_hue.ValueChanged += new System.EventHandler(this.num_hue_ValueChanged);
            // 
            // rad_hue
            // 
            this.rad_hue.AutoSize = true;
            this.rad_hue.Checked = true;
            this.rad_hue.Location = new System.Drawing.Point(319, 134);
            this.rad_hue.Name = "rad_hue";
            this.rad_hue.Size = new System.Drawing.Size(36, 17);
            this.rad_hue.TabIndex = 24;
            this.rad_hue.TabStop = true;
            this.rad_hue.Text = "H:";
            this.rad_hue.UseVisualStyleBackColor = true;
            this.rad_hue.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // num_blue
            // 
            this.num_blue.Location = new System.Drawing.Point(362, 81);
            this.num_blue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_blue.Name = "num_blue";
            this.num_blue.Size = new System.Drawing.Size(54, 20);
            this.num_blue.TabIndex = 23;
            this.num_blue.ValueChanged += new System.EventHandler(this.num_blue_ValueChanged);
            // 
            // rad_blue
            // 
            this.rad_blue.AutoSize = true;
            this.rad_blue.Location = new System.Drawing.Point(319, 81);
            this.rad_blue.Name = "rad_blue";
            this.rad_blue.Size = new System.Drawing.Size(35, 17);
            this.rad_blue.TabIndex = 22;
            this.rad_blue.Text = "B:";
            this.rad_blue.UseVisualStyleBackColor = true;
            this.rad_blue.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // num_green
            // 
            this.num_green.Location = new System.Drawing.Point(362, 55);
            this.num_green.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_green.Name = "num_green";
            this.num_green.Size = new System.Drawing.Size(54, 20);
            this.num_green.TabIndex = 21;
            this.num_green.ValueChanged += new System.EventHandler(this.num_green_ValueChanged);
            // 
            // rad_green
            // 
            this.rad_green.AutoSize = true;
            this.rad_green.Location = new System.Drawing.Point(319, 55);
            this.rad_green.Name = "rad_green";
            this.rad_green.Size = new System.Drawing.Size(36, 17);
            this.rad_green.TabIndex = 19;
            this.rad_green.Text = "G:";
            this.rad_green.UseVisualStyleBackColor = true;
            this.rad_green.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // num_red
            // 
            this.num_red.Location = new System.Drawing.Point(362, 29);
            this.num_red.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_red.Name = "num_red";
            this.num_red.Size = new System.Drawing.Size(54, 20);
            this.num_red.TabIndex = 17;
            this.num_red.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_red.ValueChanged += new System.EventHandler(this.num_red_ValueChanged);
            // 
            // rad_red
            // 
            this.rad_red.AutoSize = true;
            this.rad_red.Location = new System.Drawing.Point(319, 29);
            this.rad_red.Name = "rad_red";
            this.rad_red.Size = new System.Drawing.Size(36, 17);
            this.rad_red.TabIndex = 15;
            this.rad_red.Text = "R:";
            this.rad_red.UseVisualStyleBackColor = true;
            this.rad_red.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // txt_hex
            // 
            this.txt_hex.Location = new System.Drawing.Point(319, 256);
            this.txt_hex.Name = "txt_hex";
            this.txt_hex.Size = new System.Drawing.Size(68, 20);
            this.txt_hex.TabIndex = 20;
            this.txt_hex.Text = "FFFFFF";
            this.txt_hex.Enter += new System.EventHandler(this.txt_hex_Enter);
            this.txt_hex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_hex_KeyDown);
            this.txt_hex.Leave += new System.EventHandler(this.txt_hex_Leave);
            // 
            // labelHex
            // 
            this.labelHex.AutoSize = true;
            this.labelHex.Location = new System.Drawing.Point(316, 240);
            this.labelHex.Name = "labelHex";
            this.labelHex.Size = new System.Drawing.Size(26, 13);
            this.labelHex.TabIndex = 18;
            this.labelHex.Text = "Hex";
            // 
            // lbl_newColor
            // 
            this.lbl_newColor.BackColor = System.Drawing.Color.White;
            this.lbl_newColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_newColor.Location = new System.Drawing.Point(440, 43);
            this.lbl_newColor.Name = "lbl_newColor";
            this.lbl_newColor.Size = new System.Drawing.Size(68, 32);
            this.lbl_newColor.TabIndex = 16;
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Location = new System.Drawing.Point(458, 25);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(29, 13);
            this.labelCurrent.TabIndex = 14;
            this.labelCurrent.Text = "New";
            // 
            // lbl_currentColor
            // 
            this.lbl_currentColor.BackColor = System.Drawing.Color.White;
            this.lbl_currentColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_currentColor.Location = new System.Drawing.Point(440, 74);
            this.lbl_currentColor.Name = "lbl_currentColor";
            this.lbl_currentColor.Size = new System.Drawing.Size(68, 32);
            this.lbl_currentColor.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(454, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Current";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(432, 296);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(80, 23);
            this.btn_cancel.TabIndex = 31;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(336, 296);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 23);
            this.btn_ok.TabIndex = 30;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // ColorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 331);
            this.Controls.Add(this.colorSlider);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.num_luminance);
            this.Controls.Add(this.rad_luminance);
            this.Controls.Add(this.num_saturation);
            this.Controls.Add(this.rad_saturation);
            this.Controls.Add(this.num_hue);
            this.Controls.Add(this.rad_hue);
            this.Controls.Add(this.num_blue);
            this.Controls.Add(this.rad_blue);
            this.Controls.Add(this.num_green);
            this.Controls.Add(this.rad_green);
            this.Controls.Add(this.num_red);
            this.Controls.Add(this.rad_red);
            this.Controls.Add(this.txt_hex);
            this.Controls.Add(this.labelHex);
            this.Controls.Add(this.lbl_currentColor);
            this.Controls.Add(this.lbl_newColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCurrent);
            this.Controls.Add(this.colorBox2D);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Color Picker";
            ((System.ComponentModel.ISupportInitialize)(this.num_luminance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_saturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_hue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_red)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MechanikaDesign.WinForms.UI.ColorPicker.ColorSliderVertical colorSlider;
        private MechanikaDesign.WinForms.UI.ColorPicker.ColorBox2D colorBox2D;
        private System.Windows.Forms.NumericUpDown num_luminance;
        private System.Windows.Forms.RadioButton rad_luminance;
        private System.Windows.Forms.NumericUpDown num_saturation;
        private System.Windows.Forms.RadioButton rad_saturation;
        private System.Windows.Forms.NumericUpDown num_hue;
        private System.Windows.Forms.RadioButton rad_hue;
        private System.Windows.Forms.NumericUpDown num_blue;
        private System.Windows.Forms.RadioButton rad_blue;
        private System.Windows.Forms.NumericUpDown num_green;
        private System.Windows.Forms.RadioButton rad_green;
        private System.Windows.Forms.NumericUpDown num_red;
        private System.Windows.Forms.RadioButton rad_red;
        private System.Windows.Forms.TextBox txt_hex;
        private System.Windows.Forms.Label labelHex;
        private System.Windows.Forms.Label lbl_newColor;
        private System.Windows.Forms.Label labelCurrent;
        private System.Windows.Forms.Label lbl_currentColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
    }
}