using System.Collections.Generic;
using Trulioo.Client.V1.Model.Errors;

namespace Trulioo.Client.V1.Model
{
    public class Record
    {
        public string TransactionRecordID { get; set; }

        public string RecordStatus { get; set; }

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

        public RecordRule Rule { get; set; }
    }
}
