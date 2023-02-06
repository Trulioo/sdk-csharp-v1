using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
            var response = await _context.PostAsync<VerifyResult>(_verificationNamespace, resource, request).ConfigureAwait(false);
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
            var response = await _context.GetAsync<TransactionRecordResult>(_verificationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Gets verbose transaction record information
        /// </summary>
        /// <param name="id"> TransactionRecordID of Transaction Record to be retreived </param>
        /// <returns> Verbose Transaction Record Result of the TransactionRecordID </returns>
        public async Task<TransactionRecordResult> GetTransactionRecordVerboseAsync(string id)
        {
            var resource = new ResourceName("transactionrecord", id, "verbose");
            var response = await _context.GetAsync<TransactionRecordResult>(_verificationNamespace, resource).ConfigureAwait(false);
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
            var response = await _context.GetAsync<TransactionRecordResult>(_verificationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Gets the status of a transaction
        /// </summary>
        /// <param name="id">TransactionID of the Transaction Status to be retreived </param>
        /// <returns> Transaction Status of the transactionID </returns>
        public async Task<TransactionStatus> GetTransactionStatusAsync(string id)
        {
            var resource = new ResourceName("transaction", id, "status");
            var response = await _context.GetAsync<TransactionStatus>(_verificationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// This method is used to retrieve the partial result of an asynchronous transaction.
        /// </summary>
        /// <param name="transactionId">id of the asynchronous transaction, this will be a GUID</param>
        /// <returns>Partial Verify Result</returns>
        public async Task<VerifyResultPartial> GetPartialResultAsync(string transactionId)
        {
            var resource = new ResourceName("transaction", transactionId, "partialresult");
            var response = await _context.GetAsync<VerifyResultPartial>(_verificationNamespace, resource).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Download Document
        /// </summary>
        /// <param name="transactionRecordId">id of the transactionrecord, this will be a GUID</param>
        /// <param name="fieldName">document field name</param>
        /// <returns>document</returns>
        public async Task<DownloadDocument> GetDocumentDownloadAsync(string transactionRecordId, string fieldName)
        {
            var resource = new ResourceName("documentdownload", transactionRecordId, fieldName);
            var response = await _context.GetAsync(_verificationNamespace, resource, processResponse: parseDownloadDocumentResponse).ConfigureAwait(false);
            return await response;
        }


    #endregion

    #region Privates/internals
    
        private async Task<DownloadDocument> parseDownloadDocumentResponse(HttpResponseMessage response)
        {
            var rawMessage = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

            var filename = "downloadDocument.pdf";
            if (response.Content.Headers.ContentDisposition?.FileName != null)
            {
                filename = response.Content.Headers.ContentDisposition.FileName;
            }

            return new DownloadDocument
            {
                DocumentName = filename,
                DocumentContent = rawMessage
            };
        }

    private readonly TruliooApiClient _service;

        private Context _context { get { return _service?.Context; } }

        private readonly Namespace _verificationNamespace = new Namespace("verifications");

        #endregion
    }
}
