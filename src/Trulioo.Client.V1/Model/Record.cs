using System.Collections.Generic;
using Trulioo.Client.V1.Model.Errors;

namespace Trulioo.Client.V1.Model
{
    public class Record
    {
        public string TransactionRecordID { get; set; }

        /// <summary>
        /// 'match' or 'nomatch' if the verification passed the rules configured on your account this will be 'match'.
        /// </summary>
        public string RecordStatus { get; set; }

        /// <summary>
        /// 'match' or 'nomatch' if the secondary verification was run and passed the rules configured on your account this will be 'match'.
        /// </summary>
        public string SecondaryRecordStatus { get; set; }

        /// <summary>
        /// Results for each datasource that was queried
        /// </summary>
        public IEnumerable<DatasourceResult> DatasourceResults { get; set; }

        /// <summary>
        ////<ul>
        ////<li>1002 : Datasource Unavailable - The source did not respond</li>
        ////<li>1006 : Unrecognized Field Name</li>
        ////<li>1007 : Consent datasource not recognized</li>
        ////<li>1008 : Invalid Field Format</li>
        ////<li>1009 : Unrecognized Field group</li>
        ////<li>1010 : Request Timed Out</li>
        ////<li>1011 : Duplicate Field received</li>
        ////<li>2000 : Unrecognized Error</li>
        ////</ul>
        /// </summary>
        public IEnumerable<ServiceError> Errors { get; set; }

        /// <summary>
        /// Rule used for record
        /// </summary>
        public RecordRule Rule { get; set; }
    }
}
