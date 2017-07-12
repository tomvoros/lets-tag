using System;
using System.Windows.Forms;

namespace LetsTag
{
    public partial class CustomStringFieldForm : Form
    {
        public string Value
        {
            get { return valueTextBox.Text; }
        }

        public string Mp3tagFormat
        {
            get { return mp3tagFormatTextBox.Text; }
        }

        public CustomStringFieldForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
