using Spriten.Data;
using Spriten.Utility;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static Spriten.Utility.TexSynHelper;

namespace Spriten.Dialog
{
    public partial class TexSynDialog : Form
    {
        public TexSynSettings Settings;
        private Image mPreview;
        private Graphics mGraphics;
        private TextureBrush mBrush;
        private int mImageWidth, mImageHeight;
        private int mPreviewWidth, mPreviewHeight;
        private int[] mImage;
        private bool mLockUpdate;

        public TexSynDialog(int[] bitmapArr, int width, int height)
        {
            InitializeComponent();

            mBrush = new TextureBrush(ImageHelper.CreateTiledBackground(20), WrapMode.Tile);

            mImage = bitmapArr;

            mLockUpdate = true;
            num_width.Minimum = num_width.Value = mImageWidth = width;
            num_height.Minimum = num_height.Value = mImageHeight = height;
            cmb_mode.SelectedIndex = 0;
            mLockUpdate = false;
            

            SaveSettings();
            CalculatePreviewResolution();
            CreatePreviewImage();
            UpdatePreview();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Settings.GenerateCount = (int)num_count.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TexSynDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            // cleanup
            mBrush.Dispose();
            mGraphics.Dispose();
            mPreview.Dispose();
        }

        private void CalculatePreviewResolution()
        {
            if (!mLockUpdate)
            {
                int picBoxWidth = pic_preview.ClientRectangle.Width;
                int picBoxHeight = pic_preview.ClientRectangle.Height;

                // resolution of image preview
                double aspectRatio, scaleFactor;

                aspectRatio = Settings.OutputWidth / Settings.OutputHeight;
                if (1 > aspectRatio)
                    scaleFactor = (double)picBoxHeight / Settings.OutputHeight;
                else
                    scaleFactor = (double)picBoxWidth / Settings.OutputWidth;

                // final width and height
                mPreviewWidth = (int)Math.Floor(Settings.OutputWidth * scaleFactor);
                mPreviewHeight = (int)Math.Floor(Settings.OutputHeight * scaleFactor);
            }
        }

        private void num_width_ValueChanged(object sender, EventArgs e)
        {
            Settings.OutputWidth = (int)num_width.Value;

            if (chk_preview.Checked)
            {
                CalculatePreviewResolution();
                CreatePreviewImage();
                UpdatePreview();
            }
        }

        private void num_height_ValueChanged(object sender, EventArgs e)
        {
            Settings.OutputHeight = (int)num_height.Value;

            if (chk_preview.Checked)
            {
                CalculatePreviewResolution();
                CreatePreviewImage();
                UpdatePreview();
            }
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
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void SaveSettings()
        {
            Settings.OutputWidth = (int)num_width.Value;
            Settings.OutputHeight = (int)num_height.Value;
            Settings.Scale = (int)num_scale.Value;
            Settings.M = (int)num_M.Value;
            Settings.N = (int)num_N.Value;
            Settings.K = (int)num_K.Value;
            Settings.Temperature = (double)num_temp.Value;
            Settings.Polish = (int)num_polish.Value;
            Settings.Indexed = chk_index.Checked;
            switch (cmb_mode.SelectedIndex)
            {
                case 1:
                    Settings.Mode = SynMode.Coherent;
                    num_N.Enabled = true;
                    num_M.Enabled = false;
                    num_K.Enabled = true;
                    num_temp.Enabled = true;
                    num_polish.Enabled = false;
                    break;
                case 2:
                    Settings.Mode = SynMode.Harrison;
                    num_N.Enabled = true;
                    num_M.Enabled = true;
                    num_K.Enabled = false;
                    num_temp.Enabled = false;
                    num_polish.Enabled = true;
                    break;
                default:
                    Settings.Mode = SynMode.Full;
                    num_N.Enabled = true;
                    num_M.Enabled = false;
                    num_K.Enabled = false;
                    num_temp.Enabled = true;
                    num_polish.Enabled = false;
                    break;
            }
        }

        private void SettingsChanged(object sender, EventArgs e)
        {
            SaveSettings();

            if (chk_preview.Checked)
                UpdatePreview();
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
                int[] preview;

                switch (Settings.Mode)
                {
                    case SynMode.Coherent:
                        preview = TexSynHelper.CoherentSynthesis(mImage, mImageWidth, mImageHeight, Settings.K, Settings.N, Settings.OutputWidth, Settings.OutputHeight, Settings.Temperature, Settings.Indexed);
                        break;
                    case SynMode.Harrison:
                        preview = TexSynHelper.ReSynthesis(mImage, mImageWidth, mImageHeight, Settings.N, Settings.M, Settings.Polish, Settings.OutputWidth, Settings.OutputHeight, Settings.Indexed);
                        break;
                    default:
                        preview = TexSynHelper.FullSynthesis(mImage, mImageWidth, mImageHeight, Settings.N, Settings.OutputWidth, Settings.OutputHeight, Settings.Temperature, Settings.Indexed);
                        break;
                }

                Image previewImage = ImageHelper.GetBmpFromArgb(preview, Settings.OutputWidth, Settings.OutputHeight);

                mGraphics.FillRectangle(mBrush, 0, 0, mPreview.Width, mPreview.Height);
                mGraphics.DrawImage(previewImage, 0, 0, mPreviewWidth * Settings.Scale, mPreviewHeight * Settings.Scale);
                previewImage.Dispose();
                pic_preview.Image = mPreview;
            }
        }
    }
}
