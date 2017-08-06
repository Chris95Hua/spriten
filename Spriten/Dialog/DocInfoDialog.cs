using Spriten.Data;
using System;
using System.Windows.Forms;

namespace Spriten.Dialog
{
    public partial class DocInfoDialog : Form
    {
        public string DocTitle { get; set; }

        public DocInfoDialog(Project project)
        {
            InitializeComponent();
            
            string author = project.Author;
            DateTime dCreated = project.DateCreated;
            DateTime dSaved = project.LastSaved;

            txt_title.Text = DocTitle = project.Title;
            lbl_author.Text = string.IsNullOrEmpty(author) ? "-" : author;
            lbl_dateCreated.Text = dCreated == DateTime.MinValue ? "-" : dCreated.ToShortDateString() + " " + dCreated.ToLongTimeString();
            lbl_lastSaved.Text = dSaved == DateTime.MinValue ? "-" : dSaved.ToShortDateString() + " " + dSaved.ToLongTimeString();
            lbl_resolution.Text = project.Width + " x " + project.Height + " (pixel)";
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            DocTitle = txt_title.Text;

            if (string.IsNullOrWhiteSpace(DocTitle))
            {
                MessageBox.Show("The project title cannot be empty or consists of white spaces only", "Invalid Operation");
            }
            else
            {
                DocTitle = DocTitle.Trim();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txt_title_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_ok_Click(sender, e);
        }
    }
}
