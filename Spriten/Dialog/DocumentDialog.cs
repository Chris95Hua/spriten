using Spriten.Data;
using Spriten.Utility;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spriten.Dialog
{
    public partial class DocumentDialog : Form
    {
        public Project Project { get; private set; }
        public Color DocBackground { get; private set; }
        private string mDocTitle;
        private int mDocWidth;
        private int mDocHeight;
        private bool mUseMask;
        private decimal mAspectRatio;
        private bool mBlockEvent;
        private Image mTiledBackground;

        #region Constructor

        public DocumentDialog(string title)
        {
            InitializeComponent();

            //TODO: load previous settings for background and resolution
            cmb_background.SelectedIndex = 0;

            mTiledBackground = ImageHelper.CreateTiledBackground(20);

            txt_title.Text = title;
            txt_title.SelectAll();
        }

        #endregion

        #region Events

        private void chk_useMask_CheckedChanged(object sender, EventArgs e)
        {
            mUseMask = chk_useMask.Enabled;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (IsProjectValid())
            {
                Project = new Project(mDocWidth, mDocHeight, mDocTitle, mUseMask);
                Project.Author = Environment.UserName;
                Project.DateCreated = DateTime.Now;

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("The project title cannot be empty or consists of white spaces only", "Invalid Operation");
            }
        }

        private bool IsProjectValid()
        {
            mDocTitle = txt_title.Text.Trim();
            mDocWidth = (int)num_width.Value;
            mDocHeight = (int)num_height.Value;

            return !string.IsNullOrWhiteSpace(mDocTitle);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chk_lockRatio_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_lockRatio.Checked)
            {
                mAspectRatio = num_width.Value / num_height.Value;
            }
        }

        private void num_width_ValueChanged(object sender, EventArgs e)
        {
            if (chk_lockRatio.Checked && !mBlockEvent)
            {
                mBlockEvent = true;
                num_height.Value = ClampValue((int)(num_width.Value / mAspectRatio), (int)num_height.Minimum, (int)num_height.Maximum);
                mBlockEvent = false;
            }
        }

        private void num_height_ValueChanged(object sender, EventArgs e)
        {
            if (chk_lockRatio.Checked && !mBlockEvent)
            {
                mBlockEvent = true;
                num_width.Value = ClampValue((int)(num_height.Value * mAspectRatio), (int)num_width.Minimum, (int)num_width.Maximum);
                mBlockEvent = false;
            }
        }

        private int ClampValue(int val, int min, int max)
        {
            if (val < min)
                return min;
            else if (val > max)
                return max;

            return val;
        }

        private void label_backgroundColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colDialog = new ColorDialog(label_backgroundColor.BackColor))
            {
                if (colDialog.ShowDialog() == DialogResult.OK)
                {
                    // use custom color
                    DocBackground = label_backgroundColor.BackColor = colDialog.SelectedColor;
                    cmb_background.SelectedIndex = 3;
                }
            }
        }

        private void cmb_background_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_backgroundColor.Image = null;

            // preview and set selected color
            switch (cmb_background.SelectedIndex)
            {
                case 0:
                    // white
                    DocBackground = label_backgroundColor.BackColor = Color.White;
                    break;
                case 1:
                    // transparent
                    DocBackground = label_backgroundColor.BackColor = Color.Transparent;
                    label_backgroundColor.Image = mTiledBackground;
                    break;
                case 2:
                    // background/secondary color
                    DocBackground = label_backgroundColor.BackColor = User.BackgroundColor;
                    break;
                default:
                    break;
            }
        }

        private void DocumentDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            mTiledBackground.Dispose();
        }

        // Select all text in numeric up down controls when gained focus
        private void NumericUpDownHasFocus(object sender, EventArgs e)
        {
            if (sender == num_width)
                num_width.Select(0, num_width.Text.Length);
            else
                num_height.Select(0, num_height.Text.Length);
        }

        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_ok_Click(sender, e);
        }

        #endregion
    }
}
