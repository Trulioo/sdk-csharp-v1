using System;
using System.Threading.Tasks;
using Trulioo.Client.V1.Model.BusinessSearch;
using Trulioo.Client.V1.URI;

namespace Trulioo.Client.V1
{
    public class BusinessSearch
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessSearch"/> class.
        /// </summary>
        /// <param name="service">
        /// An object representing the root of Trulioo configuration service.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="service"/> is <c>null</c>.
        /// </exception>
        protected internal BusinessSearch(TruliooApiClient service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            _service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Business Search call for Trulioo API Client V1
        /// </summary>
        /// <param name="request"> Request object containing parameters to search for </param>
        /// <returns> Contains the List of possible businesses from search </returns>
        public async Task<BusinessSearchResponse> BusinessSearchAsync(BusinessSearchRequest request)
        {
            var resource = new ResourceName("search");
            var response = await _context.PostAsync<BusinessSearchResponse>(_businessNamespace, resource, request).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Gets Business Search transaction information
        /// </summary>
        /// <param name="transactionId"> TransactionRecordID of Business Search to retreive </param>
        /// <returns> Contains the Business Search transaction result </returns>
        public async Task<BusinessSearchResponse> BusinessSearchResultAsync(string id)
        {
            var resource = new ResourceName("search", "transactionrecord",id);
            var response = await _context.GetAsync<BusinessSearchResponse>(_businessNamespace, resource).ConfigureAwait(false);
            return response;
        }

        #endregion

        #region Privates/internals

        private readonly TruliooApiClient _service;

        private Context _context { get { return _service?.Context; } }

        private readonly Namespace _businessNamespace = new Namespace("business");

        #endregion
    }
}
