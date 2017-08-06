namespace Spriten.Dock
{
    partial class GenerationPreviewDock
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
            this.pic_preview = new System.Windows.Forms.PictureBox();
            this.GenerationPreviewPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pic_preview)).BeginInit();
            this.GenerationPreviewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_preview
            // 
            this.pic_preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_preview.Location = new System.Drawing.Point(0, 0);
            this.pic_preview.Name = "pic_preview";
            this.pic_preview.Size = new System.Drawing.Size(284, 261);
            this.pic_preview.TabIndex = 0;
            this.pic_preview.TabStop = false;
            // 
            // GenerationPreviewPanel
            // 
            this.GenerationPreviewPanel.Controls.Add(this.pic_preview);
            this.GenerationPreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenerationPreviewPanel.Location = new System.Drawing.Point(0, 0);
            this.GenerationPreviewPanel.Name = "GenerationPreviewPanel";
            this.GenerationPreviewPanel.Size = new System.Drawing.Size(284, 261);
            this.GenerationPreviewPanel.TabIndex = 1;
            // 
            // GenerationPreviewDock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.GenerationPreviewPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerationPreviewDock";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Generation Preview";
            ((System.ComponentModel.ISupportInitialize)(this.pic_preview)).EndInit();
            this.GenerationPreviewPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_preview;
        private System.Windows.Forms.Panel GenerationPreviewPanel;
    }
}