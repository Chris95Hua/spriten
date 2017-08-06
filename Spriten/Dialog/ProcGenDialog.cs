using Spriten.Data;
using Spriten.Drawing;
using Spriten.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static Spriten.Utility.SpriteHelper;

namespace Spriten.Dialog
{
    public partial class ProcGenDialog : Form
    {
        public SpriteSettings Settings;
        private List<DrawableMask> mDrawables;
        private Image mPreview;
        private TextureBrush mBrush;
        private Graphics mGraphics;
        private int mPreviewCount, mSpritePerAxis;
        private int mProjectWidth, mProjectHeight;
        private int mSpriteWidth, mSpriteHeight;
        private int mOriPreviewWidth, mOriPreviewHeight;
        private int mPreviewWidth, mPreviewHeight;
        private bool mLockUpdate;

        #region Constructor

        public ProcGenDialog(List<DrawableMask> drawables)
        {
            InitializeComponent();

            Settings = new SpriteSettings();
            
            DrawableMask layer = drawables[0];
            mProjectWidth = layer.Project.Width;
            mProjectHeight = layer.Project.Height;

            mBrush = new TextureBrush(ImageHelper.CreateTiledBackground(20), WrapMode.Tile);

            mDrawables = drawables;

            mLockUpdate = true;
            lbl_fillColor.BackColor = User.BackgroundColor;
            lbl_edgeColor.BackColor = User.ForegroundColor;
            cmb_fill.SelectedIndex = 0;
            cmb_edgeType.SelectedIndex = 0;
            cmb_shading.SelectedIndex = 0;
            cmb_previewCount.SelectedIndex = 0;
            mLockUpdate = false;

            SaveSettings();
            CalculatePreviewResolution();
            CreatePreviewImage();
            UpdatePreview();
        }

        #endregion

        #region Events

        private void LabelColorChanged(object sender, EventArgs e)
        {
            using (ColorDialog colDialog = new ColorDialog(lbl_edgeColor.BackColor))
            {
                if (colDialog.ShowDialog() == DialogResult.OK)
                {
                    if(sender == lbl_fillColor)
                    {
                        Settings.FillColor = lbl_fillColor.BackColor = colDialog.SelectedColor;
                        cmb_fill.SelectedIndex = 2;
                    }
                    else
                    {
                        Settings.EdgeColor = lbl_edgeColor.BackColor = colDialog.SelectedColor;
                        cmb_edgeType.SelectedIndex = 1;
                    }
                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            SaveSettings();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SpriteSettingsChanged(object sender, EventArgs e)
        {
            // update preview
            SaveSettings();
            if (chk_preview.Checked)
                UpdatePreview();
        }

        private void chk_separate_CheckedChanged(object sender, EventArgs e)
        {
            num_paddingX.Enabled = !chk_separate.Checked;
            num_paddingY.Enabled = !chk_separate.Checked;
        }

        private void GenerationDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            // cleanup
            mBrush.Dispose();
            mGraphics.Dispose();
            mPreview.Dispose();
        }

        private void PreviewResolutionChanged(object sender, EventArgs e)
        {
            SaveSettings();
            
            if (chk_preview.Checked)
            {
                CalculatePreviewResolution();
                CreatePreviewImage();
                UpdatePreview();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (chk_preview.Checked)
                UpdatePreview();
        }

        #endregion

        private void chk_separate_CheckedChanged_1(object sender, EventArgs e)
        {
            num_paddingX.Enabled = num_paddingY.Enabled = !chk_separate.Checked;
        }

        private void chk_preview_CheckedChanged(object sender, EventArgs e)
        {
            if (!chk_preview.Checked)
                pic_preview.Image = null;
            else
            {
                CalculatePreviewResolution();
                CreatePreviewImage();
                UpdatePreview();
            }

            btn_update.Enabled = chk_preview.Checked;
            cmb_previewCount.Enabled = chk_preview.Checked;
        }

        private void SaveSettings()
        {
            Settings.SpriteCount = (int)num_count.Value;
            Settings.Scale = (int)num_scale.Value;
            Settings.OuterMargin = (int)num_margin.Value;
            Settings.Noise = (double)num_noise.Value;
            Settings.FillBrightness = (double)num_fillBrightness.Value;
            Settings.EdgeBrightness = 1 - (double)num_edgeBrightness.Value;
            Settings.MirrorX = chk_mirrorX.Checked;
            Settings.MirrorY = chk_mirrorY.Checked;
            Settings.RandomFromGroup = chk_randomGroup.Checked;
            Settings.UseLayerSeed = chk_byLayer.Checked;
            Settings.ExportIndividual = chk_separate.Checked;

            switch (cmb_shading.SelectedIndex)
            {
                case 1:
                    Settings.Shading = Shading.Vertical;
                    break;
                case 2:
                    Settings.Shading = Shading.Horizontal;
                    break;
                case 3:
                    Settings.Shading = Shading.None;
                    break;
                default:
                    Settings.Shading = Shading.Default;
                    break;
            }

            switch (cmb_edgeType.SelectedIndex)
            {
                case 1:
                    Settings.EdgeColor = lbl_edgeColor.BackColor;
                    break;
                default:
                    Settings.EdgeColor = Color.Empty;
                    break;
            }

            switch (cmb_fill.SelectedIndex)
            {
                case 1:
                    Settings.ColorMode = SpriteHelper.ColorMode.Random;
                    break;
                case 2:
                    Settings.ColorMode = SpriteHelper.ColorMode.Fill;
                    Settings.FillColor = lbl_fillColor.BackColor;
                    break;
                default:
                    Settings.ColorMode = SpriteHelper.ColorMode.Default;
                    break;
            }

            Settings.PaddingX = (int)num_paddingX.Value;
            Settings.PaddingY = (int)num_paddingY.Value;

            switch (cmb_previewCount.SelectedIndex)
            {
                case 1:
                    mPreviewCount = 1;
                    break;
                default:
                    mPreviewCount = 4;
                    break;
            }
        }

        private void CalculatePreviewResolution()
        {
            if (!mLockUpdate)
            {
                int picBoxWidth = pic_preview.ClientRectangle.Width;
                int picBoxHeight = pic_preview.ClientRectangle.Height;

                // sprite width and height
                mSpriteWidth = Settings.MirrorX ? mProjectWidth * 2 * Settings.Scale : mProjectWidth * Settings.Scale;
                mSpriteHeight = Settings.MirrorY ? mProjectHeight * 2 * Settings.Scale : mProjectHeight * Settings.Scale;

                mSpritePerAxis = (int)Math.Ceiling((double)mPreviewCount / 2);

                mOriPreviewWidth = (Settings.OuterMargin * 2) + (Settings.PaddingX * (mSpritePerAxis - 1)) + (mSpriteWidth * mSpritePerAxis);
                mOriPreviewHeight = (Settings.OuterMargin * 2) + (Settings.PaddingY * (mSpritePerAxis - 1)) + (mSpriteHeight * mSpritePerAxis);

                // resolution of image preview
                double aspectRatio, scaleFactor;

                aspectRatio = mOriPreviewWidth / mOriPreviewHeight;
                if (1 > aspectRatio)
                    scaleFactor = (double)picBoxHeight / mOriPreviewHeight;
                else
                    scaleFactor = (double)picBoxWidth / mOriPreviewWidth;

                // final width and height
                mPreviewWidth = (int)Math.Floor(mOriPreviewWidth * scaleFactor);
                mPreviewHeight = (int)Math.Floor(mOriPreviewHeight * scaleFactor);
            }
        }

        private void CreatePreviewImage()
        {
            if (!mLockUpdate)
            {
                if (mPreview != null)
                {
                    mPreview.Dispose();
                    mGraphics.Dispose();
                }

                mPreview = new Bitmap(mPreviewWidth, mPreviewHeight, PixelFormat.Format32bppPArgb);

                mGraphics = Graphics.FromImage(mPreview);
                mGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                mGraphics.SmoothingMode = SmoothingMode.None;
                mGraphics.PixelOffsetMode = PixelOffsetMode.Half;
            }
        }

        private void UpdatePreview()
        {
            if (!mLockUpdate)
            {
                Image preview = SpriteHelper.GenerateSpriteAtlas(mDrawables, Settings, mPreviewCount, 0);
                mGraphics.FillRectangle(mBrush, 0, 0, mPreview.Width, mPreview.Height);
                mGraphics.DrawImage(preview, 0, 0, mPreviewWidth, mPreviewHeight);
                preview.Dispose();
                pic_preview.Image = mPreview;
            }
        }
    }
}
