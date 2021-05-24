using System;

namespace AngularTemplate.Web.API.Models
{
    public class GenericResult
    {
        /// <summary>
        /// True if Login success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Information message about login failed or success
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Information message about login failed or success
        /// </summary>
        public Exception Error { get; set; }
    }

    public class GenericResult<T> : GenericResult
    {
        //Any kind of object that you might want to send back as the result of a request
        public T Payload { get; set; }

        public GenericResult()
        {
        }

        public GenericResult(T payload, bool success)
        {
            Payload = payload;
            Success = success;
        }

        public GenericResult(T payload, bool success, string message, Exception error)
        {
            Payload = payload;
            Success = success;
            Message = message;
            Error = error;
        }
    }
}