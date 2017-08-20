using Spriten.Data;
using Spriten.Dialog;
using Spriten.Tool;
using Spriten.Utility;
using System;
using System.Drawing;

using WeifenLuo.WinFormsUI.Docking;

namespace Spriten.Dock
{
    public partial class ToolDock : DockContent
    {
        public Action<Color> SetColorDockColor;
        public Action<Color> SetToolStripForeColor;
        public Action<Color> SetToolStripBackColor;
        public Action UpdateBrush;

        private bool mLockUpdate;

        public ToolDock()
        {
            InitializeComponent();

            LoadIconsAndTheme();

            lbl_foreColor.BackColor = User.ForegroundColor;
            lbl_backColor.BackColor = User.BackgroundColor;

            SelectTool(User.ToolMode);
        }

        public void SelectTool(ToolMode mode)
        {
            mLockUpdate = true;

            switch (mode)
            {
                case ToolMode.Draw:
                    rad_pen.Checked = true;
                    break;
                case ToolMode.Erase:
                    rad_eraser.Checked = true;
                    break;
                case ToolMode.Fill:
                    rad_fill.Checked = true;
                    break;
                case ToolMode.ColorPicker:
                    rad_colorPicker.Checked = true;
                    break;
            }

            UpdateBrush?.Invoke();

            mLockUpdate = false;
        }

        private void LoadIconsAndTheme()
        {
            BackColor = ThemeHelper.Background;

            if(ThemeHelper.Style == ThemeHelper.ThemeStyle.Dark)
            {
                rad_pen.Image = Properties.Resources.dark_pencil_20;
                rad_eraser.Image = Properties.Resources.dark_eraser_20;
                rad_fill.Image = Properties.Resources.dark_bucket_20;
                rad_colorPicker.Image = Properties.Resources.dark_pipette_20;
                btn_switchColor.Image = Properties.Resources.dark_switch_10;
            }
            else
            {
                rad_pen.Image = Properties.Resources.light_pencil_20;
                rad_eraser.Image = Properties.Resources.light_eraser_20;
                rad_fill.Image = Properties.Resources.light_bucket_20;
                rad_colorPicker.Image = Properties.Resources.light_pipette_20;
                btn_switchColor.Image = Properties.Resources.light_switch_10;
            }
            
            rad_pen.FlatAppearance.MouseOverBackColor = ThemeHelper.Hovered;
            rad_pen.FlatAppearance.MouseDownBackColor = ThemeHelper.Pressed;
            rad_pen.FlatAppearance.CheckedBackColor = ThemeHelper.Pressed;
            rad_eraser.FlatAppearance.MouseOverBackColor = ThemeHelper.Hovered;
            rad_eraser.FlatAppearance.MouseDownBackColor = ThemeHelper.Pressed;
            rad_eraser.FlatAppearance.CheckedBackColor = ThemeHelper.Pressed;
            rad_fill.FlatAppearance.MouseOverBackColor = ThemeHelper.Hovered;
            rad_fill.FlatAppearance.MouseDownBackColor = ThemeHelper.Pressed;
            rad_fill.FlatAppearance.CheckedBackColor = ThemeHelper.Pressed;
            rad_colorPicker.FlatAppearance.MouseOverBackColor = ThemeHelper.Hovered;
            rad_colorPicker.FlatAppearance.MouseDownBackColor = ThemeHelper.Pressed;
            rad_colorPicker.FlatAppearance.CheckedBackColor = ThemeHelper.Pressed;
            btn_switchColor.FlatAppearance.MouseOverBackColor = ThemeHelper.Hovered;
            btn_switchColor.FlatAppearance.MouseDownBackColor = ThemeHelper.Pressed;
        }

        public void SetForegroundColor(Color color)
        {
            lbl_foreColor.BackColor = color;
        }

        public void SetBackgroundColor(Color color)
        {
            lbl_backColor.BackColor = color;
        }

        private void ToolSelected(object sender, EventArgs e)
        {
            if (rad_pen.Checked)
                User.ToolMode = ToolMode.Draw;
            else if (rad_eraser.Checked)
                User.ToolMode = ToolMode.Erase;
            else if (rad_fill.Checked)
                User.ToolMode = ToolMode.Fill;
            else if (rad_colorPicker.Checked)
                User.ToolMode = ToolMode.ColorPicker;

            if (!mLockUpdate)
                UpdateBrush();
        }

        private void label_primaryColor_Click(object sender, EventArgs e)
        {
            using(ColorDialog colDialog = new ColorDialog(User.ForegroundColor))
            {
                if(colDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lbl_foreColor.BackColor = colDialog.SelectedColor;
                    SetToolStripForeColor.Invoke(colDialog.SelectedColor);
                    SetColorDockColor.Invoke(lbl_foreColor.BackColor);
                }
            }
        }

        private void label_secondaryColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colDialog = new ColorDialog(User.BackgroundColor))
            {
                if (colDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lbl_backColor.BackColor = colDialog.SelectedColor;
                    SetToolStripBackColor.Invoke(colDialog.SelectedColor);
                }
            }
        }

        private void btn_switchColor_Click(object sender, EventArgs e)
        {
            Color temp = User.ForegroundColor;
            lbl_foreColor.BackColor = User.BackgroundColor;
            lbl_backColor.BackColor = temp;
            SetToolStripForeColor.Invoke(lbl_foreColor.BackColor);
            SetToolStripBackColor.Invoke(lbl_backColor.BackColor);
            SetColorDockColor?.Invoke(lbl_foreColor.BackColor);
        }
    }
}
