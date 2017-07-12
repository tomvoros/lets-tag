using System;
using System.IO;
using System.Net;

namespace LetsTag.Common
{
    public enum HttpRequestStatus { Initializing, Connecting, Downloading, Done, Aborted, Error }

    public delegate void HttpRequestHandler(AbstractHttpRequest request, HttpRequestStatus status);

    public abstract class AbstractHttpRequest
    {
        const int BUFFER_SIZE = 8192;

        protected WebRequest request;
        HttpRequestHandler handler;
        protected HttpRequestStatus status;
        byte[] responseBuffer;
        byte[] responseCompleteBuffer = new byte[0];
        string error;

        public byte[] Response
        {
            get { return responseCompleteBuffer; }
        }

        public string Error
        {
            get { return error; }
        }

        public HttpRequestStatus Status
        {
            get { return status; }
        }

        public AbstractHttpRequest(string uri)
            : this(uri, null) { }

        public AbstractHttpRequest(string uri, HttpRequestHandler handler)
        {
            request = WebRequest.Create(uri);
            this.handler = handler;
            UpdateStatus(HttpRequestStatus.Initializing);
        }

        public void Abort()
        {
            UpdateStatus(HttpRequestStatus.Aborted);
            request.Abort();
        }

        public virtual void Execute()
        {
            if (status == HttpRequestStatus.Aborted)
                return;

            UpdateStatus(HttpRequestStatus.Connecting);
            request.BeginGetResponse(new AsyncCallback(OnGetResponse), null);
        }

        void OnGetResponse(IAsyncResult result)
        {
            try
            {
                if (status == HttpRequestStatus.Aborted)
                    return;

                UpdateStatus(HttpRequestStatus.Downloading);

                WebResponse response = request.EndGetResponse(result);

                Stream responseStream = response.GetResponseStream();
                BufferedStream responseBufferedStream = new BufferedStream(responseStream, BUFFER_SIZE);

                responseBuffer = new byte[BUFFER_SIZE];

                responseBufferedStream.BeginRead(responseBuffer, 0, BUFFER_SIZE, new AsyncCallback(OnRead), responseBufferedStream);
            }
            catch (Exception ex)
            {
                UpdateError(ex.Message);
            }
        }

        void OnRead(IAsyncResult result)
        {
            try
            {
                if (status == HttpRequestStatus.Aborted)
                    return;

                BufferedStream responseBufferedStream = (BufferedStream)result.AsyncState;
                int length = responseBufferedStream.EndRead(result);

                byte[] newBuffer = new byte[responseCompleteBuffer.Length + length];
                Array.Copy(responseCompleteBuffer, newBuffer, responseCompleteBuffer.Length);
                Array.Copy(responseBuffer, 0, newBuffer, responseCompleteBuffer.Length, length);
                responseCompleteBuffer = newBuffer;

                // Update status since responseCompleteBuffer size has changed
                UpdateStatus(HttpRequestStatus.Downloading);

                if (length > 0)
                {
                    responseBufferedStream.BeginRead(responseBuffer, 0, BUFFER_SIZE, new AsyncCallback(OnRead), responseBufferedStream);
                }
                else
                {
                    responseBufferedStream.Close();
                    UpdateStatus(HttpRequestStatus.Done);
                }
            }
            catch (Exception ex)
            {
                UpdateError(ex.Message);
            }
        }

        protected void UpdateStatus(HttpRequestStatus status)
        {
            this.status = status;

            if(handler != null)
                handler(this, status);
        }

        protected void UpdateError(string error)
        {
            this.error = error;
            UpdateStatus(HttpRequestStatus.Error);
        }
    }
}
