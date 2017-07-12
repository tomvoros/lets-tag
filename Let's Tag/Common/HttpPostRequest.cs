using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LetsTag.Common
{
    public class HttpPostRequest : AbstractHttpRequest
    {
        IDictionary<string, object> postData;

        public IDictionary<string, object> PostData
        {
            get { return postData; }
            set { postData = value; }
        }

        public HttpPostRequest(string uri)
            : this(uri, new Dictionary<string, object>(), null) { }

        public HttpPostRequest(string uri, HttpRequestHandler handler)
            : this(uri, new Dictionary<string, object>(), handler) { }

        public HttpPostRequest(string uri, IDictionary<string, object> postData)
            : this(uri, postData, null) { }

        public HttpPostRequest(string uri, IDictionary<string, object> postData, HttpRequestHandler handler)
            : base(uri, handler)
        {
            this.postData = postData;
        }

        public override void Execute()
        {
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.BeginGetRequestStream(new AsyncCallback(OnGetRequestStream), null);
        }

        void OnGetRequestStream(IAsyncResult result)
        {
            try
            {
                if (status == HttpRequestStatus.Aborted)
                    return;

                Stream requestStream = request.EndGetRequestStream(result);
                StreamWriter requestStreamWriter = new StreamWriter(requestStream);
                requestStreamWriter.Write(BuildPostDataString());
                requestStreamWriter.Close();

                base.Execute();
            }
            catch (Exception ex)
            {
                UpdateError(ex.Message);
            }
        }

        string BuildPostDataString()
        {
            StringBuilder postDataBuilder = new StringBuilder();
            foreach (KeyValuePair<string, object> pair in postData)
                postDataBuilder.AppendFormat("{0}={1}&", pair.Key, Uri.EscapeDataString(pair.Value.ToString()));
            return postDataBuilder.ToString();
        }
    }
}
