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
        [Obsolete("This field is not used anymore. If provided, nothing will be affected.", false)]
        public bool AcceptTruliooTermsAndConditions { get; set; }

        /// <summary>
        /// If set, the transaction will run asyncronously and trulioo will try to update the client with transaction state updates until completed.
        /// </summary>
        public string CallBackUrl { get; set; }

        /// <summary>
        /// The consent for the data sources which will be interrogated as a part of the request.
        /// If set, trulioo will try to update the client syncronously within the timeout in seconds. If failed to accomplish, the transaction will be canceled.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Some datasources required your customer provide consent to access them.  Set that the customer has provided consent for each
        /// datasource that requires one.  If consent is not provided the datasource will not be queried.
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
