using System;
using System.Text;
using System.Windows.Forms;
using LetsTag.Common;

namespace LetsTag
{
    public partial class AlbumProgressForm : Form
    {
        delegate void ShowAlbumHandler();
        delegate void SetTextHandler(string text);
        delegate void CloseHandler();

        public static event AlbumSelectedHandler AlbumSelected;

        HttpGetRequest request;

        public AlbumProgressForm(string url)
        {
            InitializeComponent();
            request = new HttpGetRequest(url, new HttpRequestHandler(OnRequestStatusChange));
        }

        private void AlbumProgressForm_Load(object sender, EventArgs e)
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
                    Invoke(new ShowAlbumHandler(ShowAlbum));
                    break;
            }
        }

        void SetText(string text)
        {
            Text = text;
        }

        void ShowAlbum()
        {
            AlbumSelected(UTF8Encoding.UTF8.GetString(request.Response));
            Close();
        }
    }
}
