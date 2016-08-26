namespace Trulioo.Client.V1.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a request is rejected by Trulioo because it is poorly formed.
    /// </summary>
    /// <seealso cref="T:Trulioo.Client.RequestException"/>
    public sealed class BadRequestException : RequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="message">
        /// An object representing an HTTP response message including the status code and data.
        /// </param>
        /// <param name="code"></param>
        /// <param name="reason"></param>
        internal BadRequestException(string message, int code, string reason) 
            : base(message, code, reason)
        {
        }
    }
}
