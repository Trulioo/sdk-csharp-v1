namespace Trulioo.Client.V1
{
    /// <summary>
    /// Provides an operational interface to the Trulioo API V1.
    /// </summary>
    public interface ITruliooApiClient
    {
        #region Properties

        /// <summary>
        /// Gets the <see cref="Configuration"/> instance for this <see cref="ITruliooApiClient"/>.
        /// </summary>
        Configuration Configuration { get; }

        /// <summary>
        /// Gets the <see cref="Verification"/> instance for this <see cref="ITruliooApiClient"/>.
        /// </summary>
        Verification Verification { get; }

        /// <summary>
        /// Gets the <see cref="Connection"/> instance for this <see cref="ITruliooApiClient"/>.
        /// </summary>
        Connection Connection { get; }

        #endregion Properties
    }
}
