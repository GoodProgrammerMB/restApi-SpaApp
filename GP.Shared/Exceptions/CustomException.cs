using System;
using System.Net;

namespace GP.Shared.Exceptions
{
    public abstract class CustomException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }
        public string[] TranslationParams { get; set; }

        protected CustomException(HttpStatusCode statusCode, string message, params string[] messageParameters)
            : base(message)
        {
            this.HttpStatusCode = statusCode;
            TranslationParams = messageParameters;
        }

        protected CustomException(HttpStatusCode statusCode, Exception exception, params string[] messageParameters)
            : this(statusCode, exception.Message, messageParameters)
        {
        }
    }
}
