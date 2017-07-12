using System;
using System.Windows.Forms;

namespace LetsTag
{
    public partial class AlbumGrabForm : Form
    {
        public AlbumGrabForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grabButton_Click(object sender, EventArgs e)
        {
            Form form = null;
            try
            {
                form = new AlbumProgressForm(urlTextBox.Text);
                form.ShowDialog();
                form.Dispose();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(form != null)
                    form.Dispose();
            }
        }
    }
}
