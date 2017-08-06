namespace Spriten.Dialog
{
    partial class DocInfoDialog
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_author = new System.Windows.Forms.Label();
            this.lbl_dateCreated = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_lastSaved = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_resolution = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(156, 207);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(80, 23);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(61, 207);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(58, 28);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(30, 13);
            this.lbl_name.TabIndex = 12;
            this.lbl_name.Text = "Title:";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(97, 25);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(137, 20);
            this.txt_title.TabIndex = 0;
            this.txt_title.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_title_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Date Created:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Author:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_author
            // 
            this.lbl_author.AutoSize = true;
            this.lbl_author.Location = new System.Drawing.Point(94, 72);
            this.lbl_author.Name = "lbl_author";
            this.lbl_author.Size = new System.Drawing.Size(10, 13);
            this.lbl_author.TabIndex = 12;
            this.lbl_author.Text = "-";
            this.lbl_author.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_dateCreated
            // 
            this.lbl_dateCreated.AutoSize = true;
            this.lbl_dateCreated.Location = new System.Drawing.Point(94, 96);
            this.lbl_dateCreated.Name = "lbl_dateCreated";
            this.lbl_dateCreated.Size = new System.Drawing.Size(10, 13);
            this.lbl_dateCreated.TabIndex = 12;
            this.lbl_dateCreated.Text = "-";
            this.lbl_dateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Last Saved:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_lastSaved
            // 
            this.lbl_lastSaved.AutoSize = true;
            this.lbl_lastSaved.Location = new System.Drawing.Point(94, 120);
            this.lbl_lastSaved.Name = "lbl_lastSaved";
            this.lbl_lastSaved.Size = new System.Drawing.Size(10, 13);
            this.lbl_lastSaved.TabIndex = 12;
            this.lbl_lastSaved.Text = "-";
            this.lbl_lastSaved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Resolution:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_resolution
            // 
            this.lbl_resolution.AutoSize = true;
            this.lbl_resolution.Location = new System.Drawing.Point(94, 161);
            this.lbl_resolution.Name = "lbl_resolution";
            this.lbl_resolution.Size = new System.Drawing.Size(10, 13);
            this.lbl_resolution.TabIndex = 12;
            this.lbl_resolution.Text = "-";
            this.lbl_resolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DocInfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 242);
            this.Controls.Add(this.lbl_author);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_dateCreated);
            this.Controls.Add(this.lbl_resolution);
            this.Controls.Add(this.lbl_lastSaved);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocInfoDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Document Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_author;
        private System.Windows.Forms.Label lbl_dateCreated;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_lastSaved;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_resolution;
    }
}