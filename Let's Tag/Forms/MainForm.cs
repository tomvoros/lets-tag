using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using LetsTag.DragAndDrop;

namespace LetsTag
{
    public delegate void AlbumSelectedHandler(string albumDetailsString);

    public partial class MainForm : Form
    {
        Album album = new Album();

        bool coverDrag = false;
        int coverMouseDownX;
        int coverMouseDownY;

        ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
        ImageCodecInfo dragAndDropImageEncoder;
        EncoderParameters imageEncoderParams = new EncoderParameters(1);
        
        public MainForm()
        {
            AlbumProgressForm.AlbumSelected += new AlbumSelectedHandler(OnAlbumSelected);
            SearchProgressForm.AlbumSelected += new AlbumSelectedHandler(OnAlbumSelected);

            InitializeComponent();

            // Load title strings
            ResourceManager resourceManager = new ResourceManager("LetsTag.Resources.TitleStrings", Assembly.GetExecutingAssembly());
            IList<string> titleStrings = new List<string>();
            foreach (DictionaryEntry resource in resourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true))
                titleStrings.Add((string)resource.Value);

            // Choose one at random and append it to the title
            Random random = new Random();
            Text += string.Format(" - {0}", titleStrings[random.Next(titleStrings.Count)]);

            // Initialize imageEncoderParams
            imageEncoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

            // Initialize dragAndDropImageEncoder
            foreach (ImageCodecInfo encoder in imageEncoders)
            {
                if (encoder.FormatID == ImageFormat.Jpeg.Guid)
                {
                    dragAndDropImageEncoder = encoder;
                    break;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new SearchForm();
            form.ShowDialog();
            form.Dispose();
        }

        private void grabAlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AlbumGrabForm();
            form.ShowDialog();
            form.Dispose();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ExportForm(album);
            form.ShowDialog();
            form.Dispose();
        }

        private void aboutVGMdbDataGrabberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AboutForm();
            form.ShowDialog();
            form.Dispose();
        }

        private void albumCoverPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (!coverDrag)
            {
                bool enabled = (this.album.Cover != null);
                copyCoverToolStripMenuItem.Enabled = enabled;
                saveCoverAsToolStripMenuItem.Enabled = enabled;
                albumCoverContextMenuStrip.Show(albumCoverPanel.PointToScreen(e.Location));
            }
        }

        private void albumCoverPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.album.Cover != null)
            {
                coverDrag = false;
                coverMouseDownX = e.X;
                coverMouseDownY = e.Y;
            }
        }

        private void albumCoverPanel_MouseMove(object sender, MouseEventArgs e)
        {
            // Start a drag if:
            // - album cover is not null
            // - a drag is not already started
            // - user pressed left or right mouse buttons
            // - mouse moved from starting position
            if (this.album.Cover != null && !coverDrag && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && (e.X != coverMouseDownX || e.Y != coverMouseDownY))
            {
                coverDrag = true;
                ImageFileDataObject dataObject = new ImageFileDataObject("folder.jpg", this.album.Cover, dragAndDropImageEncoder, imageEncoderParams);
                new DragAndDropDelegate(albumCoverPanel, dataObject, DragDropEffects.Copy);
            }
        }

        private void copyCoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(this.album.Cover);
        }

        private void saveCoverAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (coverSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = coverSaveFileDialog.FileName;
                    string extension = Path.GetExtension(filename).ToLower();

                    // Look for a matching encoder to save with
                    foreach (ImageCodecInfo encoder in imageEncoders)
                    {
                        if (encoder.FilenameExtension.ToLower().Contains(extension))
                        {
                            album.Cover.Save(filename, encoder, imageEncoderParams);
                            return;
                        }
                    }

                    // No codec was found -- save in native format
                    album.Cover.Save(filename);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnAlbumSelected(string albumDetailsString)
        {
            try
            {
                Album album = new Album();

                // Split data string where the tracklist starts
                int tracklistIndex = albumDetailsString.IndexOf(">Tracklist</h");
                if (tracklistIndex < 0)
                    throw new Exception("There was a problem parsing the album data.");

                string detailsString = albumDetailsString.Substring(0, tracklistIndex);
                AlbumParser.Parse(album, detailsString);

                string tracklistString = albumDetailsString.Substring(tracklistIndex);
                TracklistParser.Parse(album, tracklistString);

                // Populate form
                Populate(album);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Populate(Album album)
        {
            this.album = album;

            albumCoverPanel.BackgroundImage = album.Cover;
            albumCoverPanel.Width = album.Cover.Width;
            albumCoverPanel.Height = album.Cover.Height;

            detailsListView.Items.Clear();
            foreach(KeyValuePair<string, string> detail in album.Details)
                detailsListView.Items.Add(new ListViewItem(new string[] {detail.Key, detail.Value}));

            tracksListView.Items.Clear();
            tracksListView.Groups.Clear();
            foreach (Disc disc in album.Discs)
            {
                tracksListView.Groups.Add(disc.Number, string.Format("Disc {0}", disc.Number));
                foreach (Track track in disc.Tracks)
                    tracksListView.Items.Add(new ListViewItem(new string[] {track.Number, track.Name}, tracksListView.Groups[disc.Number]));
            }
        }
    }
}
