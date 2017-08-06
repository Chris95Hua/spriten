using MechanikaDesign.WinForms.UI.ColorPicker;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Spriten.Dialog
{
    public partial class ColorDialog : Form
    {
        public Color SelectedColor { get; private set; }
        private HslColor mColorHsl = HslColor.FromAhsl(0xff);
        private ColorModes mColorMode = ColorModes.Hue;
        private bool mLockUpdates = false;
        private Regex mHexRegex = new Regex("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
        private string mHexBuffer;

        public ColorDialog(Color color)
        {
            InitializeComponent();

            this.SelectedColor = color;
            lbl_currentColor.BackColor = color;
            UpdateRgbFields(color);
        }

        private void btn_ok_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void colorSlider_ColorChanged(object sender, MechanikaDesign.WinForms.UI.ColorPicker.ColorChangedEventArgs args)
        {
            if (!this.mLockUpdates)
            {
                HslColor colorHSL = this.colorSlider.ColorHSL;
                mColorHsl = colorHSL;
                this.SelectedColor = mColorHsl.RgbValue;
                mLockUpdates = true;
                this.colorBox2D.ColorHSL = mColorHsl;
                mLockUpdates = false;
                UpdateColorFields();
            }
        }

        private void colorBox2D_ColorChanged(object sender, ColorChangedEventArgs args)
        {
            if (!this.mLockUpdates)
            {
                HslColor colorHSL = this.colorBox2D.ColorHSL;
                mColorHsl = colorHSL;
                this.SelectedColor = mColorHsl.RgbValue;
                mLockUpdates = true;
                this.colorSlider.ColorHSL = mColorHsl;
                mLockUpdates = false;
                UpdateColorFields();
            }
        }

        private void ColorModeChangedHandler(object sender, EventArgs e)
        {
            if (sender == rad_red)
            {
                mColorMode = ColorModes.Red;
            }
            else if (sender == rad_green)
            {
                mColorMode = ColorModes.Green;
            }
            else if (sender == rad_blue)
            {
                mColorMode = ColorModes.Blue;
            }
            else if (sender == rad_hue)
            {
                mColorMode = ColorModes.Hue;
            }
            else if (sender == rad_saturation)
            {
                mColorMode = ColorModes.Saturation;
            }
            else if (sender == rad_luminance)
            {
                mColorMode = ColorModes.Luminance;
            }
            this.colorSlider.ColorMode = mColorMode;
            this.colorBox2D.ColorMode = mColorMode;
        }

        private void UpdateColorFields()
        {
            mLockUpdates = true;
            num_red.Value = this.SelectedColor.R;
            num_green.Value = this.SelectedColor.G;
            num_blue.Value = this.SelectedColor.B;
            num_hue.Value = (int)(((decimal)mColorHsl.H) * 360M);
            num_saturation.Value = (int)(((decimal)mColorHsl.S) * 100M);
            num_luminance.Value = (int)(((decimal)mColorHsl.L) * 100M);
            mLockUpdates = false;

            lbl_newColor.BackColor = this.SelectedColor;
            txt_hex.Text = ColorTranslator.ToHtml(this.SelectedColor);
            mHexBuffer = txt_hex.Text;
        }

        private void UpdateRgbFields(Color newColor)
        {
            mColorHsl = HslColor.FromColor(newColor);
            this.SelectedColor = newColor;
            mLockUpdates = true;
            num_hue.Value = (int)(((decimal)mColorHsl.H) * 360M);
            num_saturation.Value = (int)(((decimal)mColorHsl.S) * 100M);
            num_luminance.Value = (int)(((decimal)mColorHsl.L) * 100M);
            mLockUpdates = false;
            this.colorSlider.ColorHSL = mColorHsl;
            this.colorBox2D.ColorHSL = mColorHsl;

            lbl_newColor.BackColor = this.SelectedColor;
            txt_hex.Text = ColorTranslator.ToHtml(this.SelectedColor);
            mHexBuffer = txt_hex.Text;
        }

        private void UpdateHslFields(HslColor newColor)
        {
            mColorHsl = newColor;
            this.SelectedColor = newColor.RgbValue;
            mLockUpdates = true;
            num_red.Value = this.SelectedColor.R;
            num_green.Value = this.SelectedColor.G;
            num_blue.Value = this.SelectedColor.B;
            mLockUpdates = false;
            this.colorSlider.ColorHSL = mColorHsl;
            this.colorBox2D.ColorHSL = mColorHsl;

            lbl_newColor.BackColor = this.SelectedColor;
            txt_hex.Text = ColorTranslator.ToHtml(this.SelectedColor);
            mHexBuffer = txt_hex.Text;
        }

        private void num_red_ValueChanged(object sender, EventArgs e)
        {
            if (!mLockUpdates)
            {
                UpdateRgbFields(Color.FromArgb((int)this.num_red.Value, (int)this.num_green.Value, (int)this.num_blue.Value));
            }
        }

        private void num_green_ValueChanged(object sender, EventArgs e)
        {
            if (!mLockUpdates)
            {
                UpdateRgbFields(Color.FromArgb((int)this.num_red.Value, (int)this.num_green.Value, (int)this.num_blue.Value));
            }
        }

        private void num_blue_ValueChanged(object sender, EventArgs e)
        {
            if (!mLockUpdates)
            {
                UpdateRgbFields(Color.FromArgb((int)this.num_red.Value, (int)this.num_green.Value, (int)this.num_blue.Value));
            }
        }

        private void num_hue_ValueChanged(object sender, EventArgs e)
        {
            if (!mLockUpdates)
            {
                HslColor newColor = HslColor.FromAhsl((double)(((float)((int)this.num_hue.Value)) / 360f), mColorHsl.S, mColorHsl.L);
                this.UpdateHslFields(newColor);
            }
        }

        private void num_saturation_ValueChanged(object sender, EventArgs e)
        {
            if (!mLockUpdates)
            {
                HslColor newColor = HslColor.FromAhsl(mColorHsl.A, mColorHsl.H, (double)(((float)((int)this.num_saturation.Value)) / 100f), mColorHsl.L);
                this.UpdateHslFields(newColor);
            }

        }

        private void num_luminance_ValueChanged(object sender, EventArgs e)
        {
            if (!mLockUpdates)
            {
                HslColor newColor = HslColor.FromAhsl(mColorHsl.A, mColorHsl.H, mColorHsl.S, (double)(((float)((int)this.num_luminance.Value)) / 100f));
                this.UpdateHslFields(newColor);
            }
        }

        private void txt_hex_Leave(object sender, EventArgs e)
        {
            //regex
            if(mHexRegex.Match(txt_hex.Text).Success)
            {
                UpdateRgbFields(ColorTranslator.FromHtml(txt_hex.Text));
            }
            else
            {
                txt_hex.Text = mHexBuffer;
            }
        }

        private void txt_hex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_hex_Leave(this, new EventArgs());
            }
        }

        private void txt_hex_Enter(object sender, EventArgs e)
        {
            mHexBuffer = txt_hex.Text;
        }
    }
}
