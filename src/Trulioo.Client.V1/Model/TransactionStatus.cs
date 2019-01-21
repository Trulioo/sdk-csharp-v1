using System;

namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// Metadata on transaction status
    /// </summary>
    public class TransactionStatus
    {
        /// <summary>
        /// Transaction ID of the transaction
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        /// Transaction Record ID of the transaction available once the transaction has finished processing
        /// </summary>
        public string TransactionRecordId { get; set; }
        /// <summary>
        /// Status of the transaction. Possible Values: Uploading, Processing, Completed, InProgress, Failed, WaitAsync, ToBeResumed, Canceled, TimeoutCanceled. Call GetTransactionRecord when status changes to Completed, Failed, Canceled or TimeoutCanceled to get the verification results.
        /// </summary>
        public String Status { get; set; }
        /// <summary>
        /// Uploaded date for transaction
        /// </summary>
        public DateTime UploadedDt { get; set; }
        /// <summary>
        /// Set to true when transaction has timed out
        /// </summary>
        public bool IsTimedOut { get; set; }
    }
}
