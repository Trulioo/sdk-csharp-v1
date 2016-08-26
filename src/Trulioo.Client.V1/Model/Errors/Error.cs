namespace Trulioo.Client.V1.Model.Errors
{
    /// <summary>
    /// Provides a class that represents a Trulioo service response error message.
    /// </summary>
    public class Error
    {
        #region Properties

        /// <summary>
        /// Gets the code of the current <see cref="Error"/>.
        /// </summary>
        /// <value>
        /// Code of the current <see cref="Error"/>.
        /// </value>
        public int Code { get; set; }

        /// <summary>
        /// Gets the reason of the current <see cref="Error"/>.
        /// </summary>
        /// <value>
        /// Reason of the current <see cref="Error"/>.
        /// </value>
        public string Reason { get; set; }

        /// <summary>
        /// Gets the message of the current <see cref="Error"/>.
        /// </summary>
        /// <value>
        /// Message of the current <see cref="Error"/>.
        /// </value>
        public string Message { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a string representation for the current <see cref="Error"/>.
        /// </summary>
        /// <returns>
        /// A string representation of the current <see cref="Error"/>.
        /// </returns>
        /// <seealso cref="M:System.Object.ToString()"/>
        public override string ToString()
        {
            return $"{Code}:{Message}";
        }

        #endregion
    }
}
