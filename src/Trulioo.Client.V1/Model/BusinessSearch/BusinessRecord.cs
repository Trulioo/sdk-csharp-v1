using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trulioo.Client.V1.Model.Errors;

namespace Trulioo.Client.V1.Model.BusinessSearch
{
    /// <summary>
    /// Business Record containing information on Business Search Results
    /// </summary>
    public class BusinessRecord
    {
        /// <summary>
        /// Business Record Constructor
        /// </summary>
        public BusinessRecord()
        {
            Errors = new List<ServiceError>();
            DatasourceResults = new List<BusinessSearchResult>();
        }

        /// <summary>
        /// The TransactionRecordID, this is the ID you will use to fetch the transaction again.
        /// </summary>
        public string TransactionRecordID { get; set; }
        /// <summary>
        /// 'match' or 'nomatch' if the verification passed the rules configured on your account this will be 'match'.
        /// </summary>
        public string RecordStatus { get; set; }
        /// <summary>
        /// Results for each datasource that was queried
        /// </summary>
        public List<BusinessSearchResult> DatasourceResults { get; set; }
        /// <summary>
        /// Errors that occurred, refer to Service Errors to see the errors that appear
        /// </summary>
        public List<ServiceError> Errors { get; set; }
    }
}
