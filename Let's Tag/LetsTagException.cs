using System;

namespace LetsTag
{
    public class LetsTagException : Exception
    {
        string message;
        Exception nestedException;

        public LetsTagException(string message)
            : this(message, null) { }

        public LetsTagException(string message, Exception nestedException)
        {
            this.message = message;
            this.nestedException = nestedException;
        }

        public override string ToString()
        {
            return message + (nestedException == null ? "" : "\r\n" + nestedException.ToString());
        }
    }
}
