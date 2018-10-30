using System.Collections.Generic;

namespace Trulioo.Client.V1.Model
{
    public class SearchRequest
    {
        /// <summary>
        /// Indicate that Trulioo terms and conditions are accepted
        /// The Verification request will be executed only if the value of this header is passed as 'true'.
        /// </summary>
        public bool AcceptTruliooTermsAndConditions { get; set; }

        /// <summary>
        /// The country code for which the verification needs to be performed
        /// Two-letter alpha code for the country for which the verification needs to be performed. 
        /// Call configuration/v1/countrycodes/{configurationname} to get the countries that are valid for you.
        /// </summary>
        public string CountryCode { get; set; }

        public Dictionary<string, string> Business { get; set; }
    }
}
