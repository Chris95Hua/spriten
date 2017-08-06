using Spriten.Data;
using Spriten.Utility;
using System;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Spriten.Dock
{
    public partial class MaskDock : DockContent
    {
        public Action<byte, int> ReplaceMaskColor;
        public Action<bool> UseMask;
        public Action RefreshDocuments;
        public Action RefreshActiveDocument;
        private bool mFreezeUseMaskCheckChange;
        
        public MaskDock()
        {
            InitializeComponent();

            lbl_border.BackColor = User.MaskBorder;
            lbl_body.BackColor = User.MaskBody;
            lbl_borderBody.BackColor = User.MaskBorderBody;
            lbl_emptyBody.BackColor = User.MaskEmptyBody;
            
            EnableControls(false);
            LoadTheme();
        }

        private void LoadTheme()
        {
            BackColor = ThemeHelper.Background;
                
            chk_maskMode.FlatAppearance.MouseDownBackColor = chk_useMask.FlatAppearance.MouseDownBackColor = ThemeHelper.Pressed;
            chk_maskMode.FlatAppearance.MouseOverBackColor = chk_useMask.FlatAppearance.MouseOverBackColor = ThemeHelper.Hovered;
            chk_maskMode.FlatAppearance.BorderColor = chk_useMask.FlatAppearance.BorderColor = ThemeHelper.DockBackColor;
            chk_maskMode.FlatAppearance.CheckedBackColor = chk_useMask.FlatAppearance.CheckedBackColor = ThemeHelper.Pressed;
            chk_maskMode.ForeColor = chk_useMask.ForeColor = ThemeHelper.Foreground;
            chk_maskMode.BackColor = chk_useMask.BackColor = ThemeHelper.TreeListBackground;

            rad_border.ForeColor = rad_body.ForeColor = rad_emptyBody.ForeColor = rad_borderBody.ForeColor = ThemeHelper.Foreground;
        }

        public void SetMaskControls(bool enable)
        {
            mFreezeUseMaskCheckChange = true;

            if (!enable)
                chk_useMask.Checked = chk_maskMode.Checked = User.IsMaskingMode = false;

            mFreezeUseMaskCheckChange = false;

            chk_maskMode.Enabled = enable;
            EnableControls(enable);
        }

        public void SetUseMask(bool enable)
        {
            chk_useMask.Enabled = enable;
        }

        public void CheckUseMask(bool check)
        {
            EnableControls(check);

            mFreezeUseMaskCheckChange = true;

            if (!chk_useMask.Enabled)
                chk_useMask.Enabled = true;

            chk_useMask.Checked = check;

            mFreezeUseMaskCheckChange = false;

        }

        public void CheckMaskMode(bool check)
        {
            chk_maskMode.Checked = check;
        }

        private void chk_maskMode_CheckedChanged(object sender, EventArgs e)
        {
            // toggle state
            User.IsMaskingMode = chk_maskMode.Checked;
            if (!mFreezeUseMaskCheckChange)
                RefreshDocuments();
        }

        private void chk_useMask_CheckedChanged(object sender, EventArgs e)
        {
            bool useMask = chk_useMask.Checked;
            
            // destroy mask
            if (!mFreezeUseMaskCheckChange && !useMask)
            {
                if(MessageBox.Show("This operation will destroy the mask data and cannot be undone. Proceed anyway?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    UseMask(false);
                    CheckUseMask(useMask);
                    CheckMaskMode(useMask);
                    RefreshActiveDocument();
                }
            }
            // create mask
            else
            {
                if(!mFreezeUseMaskCheckChange)
                    UseMask(useMask);

                CheckUseMask(useMask);
            }
        }

        private void EnableControls(bool enable)
        {
            rad_border.Enabled = lbl_border.Enabled = enable;
            rad_body.Enabled = lbl_body.Enabled = enable;
            rad_borderBody.Enabled = lbl_borderBody.Enabled = enable;
            rad_emptyBody.Enabled = lbl_emptyBody.Enabled = enable;

            chk_maskMode.Enabled = chk_useMask.Enabled = enable;
        }

        private void ChangeMaskColor(object sender, EventArgs e)
        {
            Label label = sender as Label;

            using (Dialog.ColorDialog colDialog = new Dialog.ColorDialog(label.BackColor))
            {
                if (colDialog.ShowDialog() == DialogResult.OK)
                {
                    Color oldColor = label.BackColor;
                    Color newColor = colDialog.SelectedColor;

                    label.BackColor = newColor;
                    RefreshDocuments();

                    if (sender == lbl_border)
                    {
                        User.MaskBorder = newColor;
                        ReplaceMaskColor(SpriteHelper.BORDER, newColor.ToArgb());
                        rad_border.Checked = true;
                    }
                    else if(sender == lbl_emptyBody)
                    {
                        User.MaskEmptyBody = newColor;
                        ReplaceMaskColor(SpriteHelper.EMPTY_BODY, newColor.ToArgb());
                        rad_emptyBody.Checked = true;
                    }
                    else if(sender == lbl_borderBody)
                    {
                        User.MaskBorderBody = newColor;
                        ReplaceMaskColor(SpriteHelper.BORDER_BODY, newColor.ToArgb());
                        rad_borderBody.Checked = true;
                    }
                    else if(sender == lbl_body)
                    {
                        User.MaskBody = newColor;
                        ReplaceMaskColor(SpriteHelper.BODY, newColor.ToArgb());
                        rad_body.Checked = true;
                    }
                }
            }
        }

        private void MaskMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_borderBody.Checked)
                User.MaskMode = SpriteHelper.Mask.BorderBody;
            else if (rad_emptyBody.Checked)
                User.MaskMode = SpriteHelper.Mask.EmptyBody;
            else if (rad_body.Checked)
                User.MaskMode = SpriteHelper.Mask.Body;
            else
                User.MaskMode = SpriteHelper.Mask.Border;
        }
    }
}
