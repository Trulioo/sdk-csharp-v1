
namespace Trulioo.Client.V1.Exceptions
{
    /// <summary>
    /// The exception that is thrown when invalid credentials are passed to <see cref="TruliooApiClient"/> or a request fails because the session timed out.
    /// </summary>
    /// <seealso cref="T:Trulioo.Client.RequestException"/>
    public sealed class AuthenticationFailureException : RequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationFailureException"/> class.
        /// </summary>
        /// <param name="message">
        /// An object representing an HTTP response message including the status code and data.
        /// </param>
        /// <param name="code"></param>
        /// <param name="reason"></param>
        internal AuthenticationFailureException(string message, int code, string reason)
            : base(message, code, reason)
        {
        }
    }
}
