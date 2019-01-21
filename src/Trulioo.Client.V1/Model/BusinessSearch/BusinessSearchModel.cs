using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trulioo.Client.V1.Model.BusinessSearch
{
    /// <summary>
    /// Search Model containing name-value pairs to be used for Business Search
    /// </summary>
    public class BusinessSearchModel
    {
        /// <summary>
        /// Name of the business to be verified
        /// </summary>
        public string BusinessName { get; set; }
        /// <summary>
        /// Jurisdiction Of Incorporation of the business to be verified
        /// </summary>
        public string JurisdictionOfIncorporation { get; set; }
        /// <summary>
        /// Duns Number
        /// </summary>
        public string DUNSNumber { get; set; }
        /// <summary>
        /// Location of the Business
        /// </summary>
        public Location Location { get; set; }
    }
}
