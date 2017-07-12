using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LetsTag.Common;

namespace LetsTag
{
    public partial class ExportForm : Form
    {
        Album album;
        Preset currentPreset;
        Preset blankPreset;

        public ExportForm(Album album)
        {
            this.album = album;
            InitializeComponent();

            blankPreset = new Preset("Blank");
            presetComboBox.DisplayMember = "Name";
            ReloadPresets();

            foreach (string key in album.Details.Keys.Reverse<string>())
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(key);
                menuItem.Click += new EventHandler(albumFieldMenuItem_Click);
                toolStripDropDownButton1.DropDownItems.Insert(0, menuItem);
            }
        }

        private void presetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPreset = ((Preset)presetComboBox.SelectedItem).Clone();
            Populate();
        }

        private void addPresetToolStripButton_Click(object sender, EventArgs e)
        {
            string presetName = presetComboBox.Text;
            if (presetComboBox.SelectedItem == blankPreset)
                presetName = "New Preset";

            AddPresetForm addPresetForm = new AddPresetForm(presetName);
            if (addPresetForm.ShowDialog() == DialogResult.OK)
            {
                currentPreset.Name = addPresetForm.PresetName;

                try
                {
                    PresetWriter.SavePreset(currentPreset);
                    ReloadPresets(currentPreset.Name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            addPresetForm.Dispose();
        }

        private void removePresetToolStripButton_Click(object sender, EventArgs e)
        {
            if (presetComboBox.SelectedItem != blankPreset)
            {
                if (MessageBox.Show(string.Format("Delete preset {0}?", currentPreset.Name), "Delete Preset", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    try
                    {
                        PresetManager.DeletePresetFile(string.Format("{0}.xml", currentPreset.Name));
                        ReloadPresets();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        void albumFieldMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            string mp3tagFormat;
            switch (menuItem.Text.ToLower())
            {
                case "album name":
                    mp3tagFormat = "%album%";
                    break;
                case "catalog number":
                    mp3tagFormat = "%comment%";
                    break;
                case "published by":
                    mp3tagFormat = "%copyright%";
                    break;
                case "composed by":
                    mp3tagFormat = "%artist%";
                    break;
                default:
                    mp3tagFormat = "%dummy%";
                    break;
            }

            AddField(new SimpleField(new AlbumFieldValue(menuItem.Text), mp3tagFormat));
        }

        private void discNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddField(new SimpleField(new DiscNumberValue(), "%discnumber%"));
        }

        private void trackNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddField(new SimpleField(new TrackNumberValue(), "%track%"));
        }

        private void trackNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddField(new SimpleField(new TrackNameValue(), "%title%"));
        }

        private void customStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomStringFieldForm form = new CustomStringFieldForm();
            if (form.ShowDialog() == DialogResult.OK)
                AddField(new SimpleField(new StringValue(form.Value), form.Mp3tagFormat));
            form.Dispose();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (fieldsListBox.SelectedIndex != -1)
                RemoveField(fieldsListBox.SelectedIndex);
        }

        private void moveUpToolStripButton_Click(object sender, EventArgs e)
        {
            if (fieldsListBox.SelectedIndex > 0)
                MoveUp(fieldsListBox.SelectedIndex);
        }

        private void moveDownToolStripButton_Click(object sender, EventArgs e)
        {
            if (fieldsListBox.SelectedIndex != -1 && fieldsListBox.SelectedIndex < fieldsListBox.Items.Count - 1)
                MoveDown(fieldsListBox.SelectedIndex);
        }

        private void delimiterTextBox_TextChanged(object sender, EventArgs e)
        {
            currentPreset.Delimiter = delimiterTextBox.Text;
        }

        private void mp3tagFormatStringLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new Mp3tagFormatStringForm(currentPreset);
            form.ShowDialog();
            form.Dispose();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (exportSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = exportSaveFileDialog.OpenFile();
                    StreamWriter streamWriter = new StreamWriter(stream, new UTF8Encoding(true));
                    Exporter.Export(album, currentPreset, streamWriter);
                    streamWriter.Close();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        void ReloadPresets()
        {
            ReloadPresets("Default");
        }

        void ReloadPresets(string defaultPresetName)
        {
            presetComboBox.Items.Clear();
            presetComboBox.Items.Add(blankPreset);

            Preset defaultPreset = blankPreset;

            defaultPresetName = defaultPresetName.ToLower();
            string[] presetFiles = PresetManager.GetPresetFiles();
            foreach (string presetFile in presetFiles)
            {
                try
                {
                    Preset preset = PresetReader.LoadPreset(presetFile);
                    presetComboBox.Items.Add(preset);

                    if (preset.Name.ToLower() == defaultPresetName)
                        defaultPreset = preset;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("{0} is not a valid preset file:\n{1}", presetFile, ex.Message), null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
            presetComboBox.SelectedItem = defaultPreset;
        }

        void Populate()
        {
            fieldsListBox.Items.Clear();
            foreach (IField field in currentPreset.Fields)
                fieldsListBox.Items.Add(field.GetName());
            delimiterTextBox.Text = currentPreset.Delimiter;
        }

        void AddField(IField field)
        {
            currentPreset.Fields.Add(field);
            fieldsListBox.Items.Add(field.GetName());
        }

        void RemoveField(int index)
        {
            currentPreset.Fields.RemoveAt(index);
            fieldsListBox.Items.RemoveAt(index);
            if(fieldsListBox.Items.Count > 0)
                fieldsListBox.SelectedIndex = (index < fieldsListBox.Items.Count ? index : fieldsListBox.Items.Count - 1);
        }

        void MoveUp(int index)
        {
            IField field = currentPreset.Fields[index];
            currentPreset.Fields.RemoveAt(index);
            currentPreset.Fields.Insert(index - 1, field);

            object item = fieldsListBox.Items[index];
            fieldsListBox.Items.RemoveAt(index);
            fieldsListBox.Items.Insert(index - 1, item);
            fieldsListBox.SelectedIndex = index - 1;
        }

        void MoveDown(int index)
        {
            IField field = currentPreset.Fields[index];
            currentPreset.Fields.RemoveAt(index);
            currentPreset.Fields.Insert(index + 1, field);

            object item = fieldsListBox.Items[index];
            fieldsListBox.Items.RemoveAt(index);
            fieldsListBox.Items.Insert(index + 1, item);
            fieldsListBox.SelectedIndex = index + 1;
        }
    }
}
