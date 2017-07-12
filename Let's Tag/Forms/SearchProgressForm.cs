using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LetsTag.Common;

namespace LetsTag
{
    public partial class SearchProgressForm : Form
    {
        delegate void ShowResultsHandler();
        delegate void SetTextHandler(string text);
        delegate void CloseHandler();

        public static event AlbumSelectedHandler AlbumSelected;

        readonly static Regex isAlbumRegex = new Regex(@"\>\s*Album\s+Stats\s*\<");
        readonly static Regex isNoResultsRegex = new Regex(@"\>\s*No\s+results\s+found\s*\.\s*\<");

        HttpPostRequest request;

        public SearchProgressForm(string searchText)
        {
            InitializeComponent();
            request = new HttpPostRequest("http://vgmdb.net/db/albums-search.php?do=results", new HttpRequestHandler(OnRequestStatusChange));
            request.PostData.Add("action", "simplesearch");
            request.PostData.Add("formalbumtitle", searchText);
        }

        private void SearchProgressForm_Load(object sender, EventArgs e)
        {
            request.Execute();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            request.Abort();
            Close();
        }

        void OnRequestStatusChange(AbstractHttpRequest request, HttpRequestStatus status)
        {
            switch (status)
            {
                case HttpRequestStatus.Downloading:
                    Invoke(new SetTextHandler(SetText), string.Format("Downloading... ({0} bytes)", request.Response.Length));
                    break;

                case HttpRequestStatus.Error:
                    MessageBox.Show(request.Error, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Invoke(new CloseHandler(Close));
                    break;

                case HttpRequestStatus.Done:
                    Invoke(new ShowResultsHandler(ShowResults));
                    break;
            }
        }

        void SetText(string text)
        {
            Text = text;
        }

        void ShowResults()
        {
            string responseString = UTF8Encoding.UTF8.GetString(request.Response);

            if (isAlbumRegex.IsMatch(responseString))
            {
                // There was a single result -- web service returned album
                AlbumSelected(responseString);
            }
            else if (isNoResultsRegex.IsMatch(responseString))
            {
                // There are no results
                MessageBox.Show("No results found.", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // There are multiple results
                Form form = new ResultSelectorForm(responseString);
                form.ShowDialog();
                form.Dispose();
            }

            Close();
        }
    }
}
