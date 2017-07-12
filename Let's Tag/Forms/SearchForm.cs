using System;
using System.Windows.Forms;

namespace LetsTag
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text.Length < 3)
            {
                MessageBox.Show("Please enter at least 3 characters.", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchTextBox.Focus();
                return;
            }

            Form form = new SearchProgressForm(searchTextBox.Text);
            form.ShowDialog();
            form.Dispose();
            Close();
        }
    }
}
