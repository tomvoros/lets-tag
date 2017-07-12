namespace LetsTag.Common
{
    public class HttpGetRequest : AbstractHttpRequest
    {
        public HttpGetRequest(string uri)
            : base(uri) { }

        public HttpGetRequest(string uri, HttpRequestHandler handler)
            : base(uri, handler) { }

        public override void Execute()
        {
            request.Method = "GET";
            base.Execute();
        }
    }
}
