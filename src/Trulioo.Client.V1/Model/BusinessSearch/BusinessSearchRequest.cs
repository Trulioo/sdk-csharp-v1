using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trulioo.Client.V1.Model.BusinessSearch
{
    /// <summary>
    /// The request to be passed to Client for a business search
    /// </summary>
    public class BusinessSearchRequest
    {
        /// <summary>
        /// Indicate that Trulioo terms and conditions are accepted
        /// The Verification request will be executed only if the value of this header is passed as 'true'.
        /// </summary>
        public bool AcceptTruliooTermsAndConditions { get; set; }

        /// <summary>
        /// If set, the transaction will run asyncronously and trulioo will try to update the client with transaction state updates until completed.
        /// </summary>
        public string CallBackUrl { get; set; }

        /// <summary>
        /// The consent for the data sources which will be interrogated as a part of the request.
        /// Included only for the data sources which explicitly require consent
        /// </summary>
        public string[] ConsentForDataSources { get; set; }

        /// <summary>
        /// The country code for which the verification needs to be performed
        /// Two-letter alpha code for the country for which the verification needs to be performed. 
        /// Call configuration/v1/countrycodes/{configurationname} to get the countries that are valid for you.
        /// </summary>
        public string CountryCode { get; set; }

        public BusinessSearchModel Business { get; set; }
    }
}
