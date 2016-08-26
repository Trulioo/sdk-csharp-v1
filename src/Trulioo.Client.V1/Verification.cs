using System;
using System.Threading.Tasks;
using Trulioo.Client.V1.Model;
using Trulioo.Client.V1.URI;

namespace Trulioo.Client.V1
{
    /// <summary>
    /// Provides a class for working with Trulioo Verification.
    /// </summary>
    public class Verification
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Verification"/> class.
        /// </summary>
        /// <param name="service">
        /// An object representing the root of Trulioo configuration service.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="service"/> is <c>null</c>.
        /// </exception>
        protected internal Verification(TruliooApiClient service)
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
        /// The verification call for the Trulioo API V1
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<VerifyResult> VerifyAsync(VerifyRequest request)
        {
            var resource = new ResourceName("verify");
            var response = await Context.PostAsync<VerifyResult>(_verificationNamespace, resource, request).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Gets transaction record information
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TransactionRecordResult> GetTransactionRecordAsync(string id)
        {
            var resource = new ResourceName("transactionrecord", id);
            var response = await Context.GetAsync<TransactionRecordResult>(_verificationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Gets a transaction record with address cleansing information
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TransactionRecordResult> GetTransactionRecordAddressAsync(string id)
        {
            var resource = new ResourceName("transactionrecord", id, "withaddress");
            var response = await Context.GetAsync<TransactionRecordResult>(_verificationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        #endregion

        #region Privates/internals

        private readonly TruliooApiClient _service;

        private Context Context { get { return _service?.Context; } }

        private readonly Namespace _verificationNamespace = new Namespace("verifications");

        #endregion
    }
}
