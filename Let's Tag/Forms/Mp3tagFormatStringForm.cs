using System;
using System.Windows.Forms;
using LetsTag.Common;

namespace LetsTag
{
    public partial class Mp3tagFormatStringForm : Form
    {
        public Mp3tagFormatStringForm(Preset preset)
        {
            InitializeComponent();

            string formatString = "";
            bool isFirstField = true;
            foreach(IField field in preset.Fields)
            {
                if (isFirstField)
                    isFirstField = false;
                else
                    formatString += preset.Delimiter;

                formatString += field.GetMp3tagFormat();
            }
            formatStringTextBox.Text = formatString;
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(formatStringTextBox.Text);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
