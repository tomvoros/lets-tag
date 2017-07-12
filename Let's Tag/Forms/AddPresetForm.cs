using System;
using System.Windows.Forms;
using LetsTag.Common;

namespace LetsTag
{
    public partial class AddPresetForm : Form
    {
        string presetName;

        public string PresetName
        {
            get { return presetName; }
        }

        public AddPresetForm(string presetName)
        {
            InitializeComponent();
            presetNameTextBox.Text = presetName;
            presetNameTextBox.SelectAll();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            presetName = presetNameTextBox.Text.Trim();
            if (presetName.Length == 0)
            {
                MessageBox.Show("Please enter a preset name.", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                presetNameTextBox.Focus();
                return;
            }

            if (PresetManager.PresetFileExists(string.Format("{0}.xml", presetName)))
            {
                if (MessageBox.Show(string.Format("Preset {0} already exists.  Overwrite?", presetName), Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    presetNameTextBox.Focus();
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
