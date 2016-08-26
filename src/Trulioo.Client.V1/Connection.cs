using System;
using System.Threading.Tasks;
using Trulioo.Client.V1.URI;

namespace Trulioo.Client.V1
{
    /// <summary>
    /// Provides a class for working with Trulioo Connection.
    /// </summary>
    public class Connection
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="service">
        /// An object representing the root of Trulioo configuration service.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="service"/> is <c>null</c>.
        /// </exception>
        protected internal Connection(TruliooApiClient service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            _service = service;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// Test connection to the API, Authentication is not required
        /// </summary>
        /// <param name="userName"></param>
        public async Task<string> SayHelloAsync(string userName)
        {
            var resource = new ResourceName("sayhello", userName);
            var response = await _context.GetAsync<string>(_connectionNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Test connection to the API, Authentication is required
        /// </summary>
        public async Task<string> TestAuthenticationAsync()
        {
            var resource = new ResourceName("testauthentication");
            var response = await _context.GetAsync<string>(_connectionNamespace, resource).ConfigureAwait(false);
            return response;
        }

        #endregion

        #region Privates/internals

        private readonly TruliooApiClient _service;

        private Context _context { get { return _service?.Context; } }

        private readonly Namespace _connectionNamespace = new Namespace("connection");

        #endregion
    }
}
