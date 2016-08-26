using System;

namespace Trulioo.Client.V1.URI
{
    /// <summary>
    /// Specifies the name space context for a resource.
    /// </summary>
    internal class Namespace
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Namespace"/> class.
        /// </summary>
        /// <param name="value"></param>
        public Namespace(string value)
        {
            Value = value;
        }

        private Namespace()
        {
            Value = "";
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the user of the current <see cref="Namespace"/>.
        /// </summary>
        /// <value>
        /// The user of the current <see cref="Namespace"/>.
        /// </value>
        public string Value  { get; private set; }

        #endregion

        #region Fields

        /// <summary>
        /// The default.
        /// </summary>
        public static readonly Namespace Empty = new Namespace();

        #endregion

        #region Methods

        /// <summary>
        /// Converts the value of the current <see cref="Namespace"/> object to its equivalent URI encoded string representation.
        /// </summary>
        /// <remarks>
        /// The value is converted using <see cref="Uri.EscapeUriString"/>.
        /// </remarks>
        /// <returns>
        /// A string representation of the current <see cref="Namespace"/>
        /// </returns>
        public string ToUriString()
        {
            return ToString(Uri.EscapeDataString);
        }

        #endregion

        #region Privates

        string ToString(Func<string, string> encode)
        {
            return string.Concat("/", encode(Value));
        }

        #endregion
    }
}
