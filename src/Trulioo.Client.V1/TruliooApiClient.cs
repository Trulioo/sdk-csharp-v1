using System;

namespace Trulioo.Client.V1
{
    /// <summary>
    /// Provides access to the Trulioo API V1 offered.
    /// </summary>
    /// <seealso cref="T:System.IDisposable"/>
    /// <seealso cref="T:Trulioo.Client.IService"/>
    /// <seealso cref="T:Trulioo.Client.IContextAware"/>
    public class TruliooApiClient : ITruliooApiClient, IContextAware, IDisposable
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TruliooApiClient"/> class.
        /// </summary>
        /// <param name="context">
        /// The context for requests by the new <see cref="TruliooApiClient"/>.
        /// </param>
        /// ### <exception cref="ArgumentNullException">
        /// <paramref name="context"/> is <c>null</c>.
        /// </exception>
        public TruliooApiClient(Context context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            Context = context;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="TruliooApiClient"/> class.
        /// </summary>
        /// <param name="userName">
        ///  The username for the new <see cref="TruliooApiClient"/>.
        /// </param>
        /// <param name="password">
        ///  The password for the new <see cref="TruliooApiClient"/>.
        /// </param>
        /// ### <exception name="ArgumentException">
        /// <paramref name="userName"/> is <c>null</c>.
        /// <paramref name="password"/> is <c>null</c>.
        /// </exception>
        public TruliooApiClient(string userName, string password)
             : this(new Context(userName, password))
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the <see cref="Context"/> instance for this <see cref="TruliooApiClient"/>.
        /// </summary>
        public Context Context { get; }

        /// <summary>
        /// Gets the <see cref="Configuration"/> instance for this <see cref="TruliooApiClient"/>.
        /// </summary>
        public Configuration Configuration
        {
            get { return _configuration ?? (_configuration = new Configuration(this)); }
        }

        /// <summary>
        /// Gets the <see cref="Verification"/> instance for this <see cref="TruliooApiClient"/>.
        /// </summary>
        public Verification Verification
        {
            get { return _verification ?? (_verification = new Verification(this)); }
        }

        /// <summary>
        /// Gets the <see cref="Connection"/> instance for this <see cref="TruliooApiClient"/>.
        /// </summary>
        public Connection Connection
        {
            get { return _connection ?? (_connection = new Connection(this)); }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Releases all resources used by the <see cref="TruliooApiClient"/>.
        /// </summary>
        /// <remarks>
        /// Do not override this method. Override <see cref="TruliooApiClient.Dispose(bool)"/> instead.
        /// </remarks>
        /// <seealso cref="M:System.IDisposable.Dispose()"/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the <see cref="TruliooApiClient"/>.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources; 
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        /// <remarks>
        /// Subclasses should implement the disposable pattern as follows:
        /// <list type="bullet">
        /// <item><description>
        ///     Override this method and call it from the override.
        ///     </description></item>
        /// <item><description>
        ///     Provide a finalizer, if needed, and call this method from it.
        ///     </description></item>
        /// <item><description>
        ///     To help ensure that resources are always cleaned up appropriately,
        ///     ensure that the override is callable multiple times without throwing
        ///     an exception.
        ///     </description></item>
        /// </list>
        /// There is no performance benefit in overriding this method on types that
        /// use only managed resources (such as arrays) because they are
        /// automatically reclaimed by the garbage collector. See
        /// <a href="http://tiny.cc/8kzuzx">Implementing a Dispose Method</a>.
        /// </remarks>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _disposed = true;
                if (Context != null)
                {
                    Context.Dispose();
                }
            }
        }

        /// <summary>
        /// Gets the URI string for this <see cref="TruliooApiClient"/> instance.
        /// </summary>
        /// <returns>
        /// A string that represents this object.
        /// </returns>
        /// <seealso cref="M:System.Object.ToString()"/>
        public override string ToString()
        {
            return Context.ToString();
        }

        #endregion Methods

        #region Privates/internals

        private Configuration _configuration;

        private Verification _verification;

        private Connection _connection;

        private bool _disposed;

        #endregion Privates/internals
    }
}
