namespace Trulioo.Client.V1.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the resource is not found.
    /// </summary>
    /// <seealso cref="T:Trulioo.Client.RequestException"/>
    public sealed class ResourceNotFoundException : RequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// An object representing an HTTP response message including the status code and data.
        /// </param>
        /// <param name="code"></param>
        /// <param name="reason"></param>
        internal ResourceNotFoundException(string message, int code, string reason) 
            : base(message, code, reason)
        {
        }
    }
}
