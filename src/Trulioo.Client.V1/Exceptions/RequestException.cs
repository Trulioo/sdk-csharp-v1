using System;

namespace Trulioo.Client.V1.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a Trulioo service request fails.
    /// </summary>
    /// <seealso cref="T:System.Exception"/>
    public class RequestException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestException"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <param name="reason"></param>
        protected internal RequestException(string message, int code, string reason)
            : base(message)
        {
            Code = code;
            Reason = reason;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the code of the current <see cref="RequestException"/>.
        /// </summary>
        /// <value>
        /// Code of the current <see cref="RequestException"/>.
        /// </value>
        public int Code { get; set; }

        /// <summary>
        /// Gets the reason of the current <see cref="RequestException"/>.
        /// </summary>
        /// <value>
        /// Reason of the current <see cref="RequestException"/>.
        /// </value>
        public string Reason { get; set; }

        /// <summary>
        /// Gets the message of the current <see cref="RequestException"/>.
        /// </summary>
        /// <value>
        /// Message of the current <see cref="RequestException"/>.
        /// </value>
        public override string Message
        {
            get
            {
                return string.IsNullOrEmpty(base.Message) ? Reason : base.Message;
            }
        }

        #endregion
    }
}
