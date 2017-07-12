using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace LetsTag
{
    public partial class ResultSelectorForm : Form
    {
        readonly static Regex regex = new Regex(
            @"<span\s+class\s*=\s*" + "[\\\'\\\"]catalog[\\\'\\\"]" + @".*?>(.*?)</span>" + // Catalog number
            @"(.*?<img\s+.*?alt\s*=\s*" + "[\\\'\\\"](.*?)[\\\'\\\"]" + @")?" + // Reprint info, etc.
            @".*?<a\s+href\s*=\s*" + "[\\\'\\\"].*?album/(.*?)[\\\'\\\"]" + @">" + // Album number
            @".*?<span\s+class\s*=\s*" + "[\\\'\\\"]albumtitle[\\\'\\\"]" + @".*?lang\s*=\s*" + "[\\\'\\\"]en[\\\'\\\"]" + @".*?>(.*?)</span>", // Album title
            RegexOptions.IgnoreCase);

        string resultsString;
        IList<AlbumData> albumsList = new List<AlbumData>();

        public ResultSelectorForm(string resultsString)
        {
            this.resultsString = resultsString;
            InitializeComponent();
        }

        private void ResultSelectorForm_Load(object sender, EventArgs e)
        {
            Match match = regex.Match(resultsString);
            while (match.Success)
            {
                AlbumData albumData = new AlbumData();
                albumData.CatalogNumber = HttpUtility.HtmlDecode(match.Groups[1].Value);
                albumData.ExtraInfo = HttpUtility.HtmlDecode(match.Groups[3].Value);
                albumData.AlbumNumber = HttpUtility.HtmlDecode(match.Groups[4].Value);
                albumData.AlbumTitle = HttpUtility.HtmlDecode(match.Groups[5].Value);
                albumsList.Add(albumData);
                
                match = match.NextMatch();
            }
            Populate();
        }

        private void Populate()
        {
            foreach (AlbumData album in albumsList)
            {
                resultsListView.Items.Add(new ListViewItem(new string[] { album.CatalogNumber, album.AlbumTitle, album.ExtraInfo }));
            }
        }

        private void ShowAlbum()
        {
            string url = string.Format("http://vgmdb.net/album/{0}", albumsList[resultsListView.SelectedIndices[0]].AlbumNumber);
            Form form = new AlbumProgressForm(url);
            form.ShowDialog();
            form.Dispose();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resultsListView_DoubleClick(object sender, EventArgs e)
        {
            ShowAlbum();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            ShowAlbum();
        }
    }

    public class AlbumData
    {
        public string CatalogNumber;
        public string ExtraInfo;
        public string AlbumNumber;
        public string AlbumTitle;
    }
}
