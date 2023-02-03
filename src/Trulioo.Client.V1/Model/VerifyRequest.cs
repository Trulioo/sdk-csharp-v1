
using System;

namespace Trulioo.Client.V1.Model
{
    public class VerifyRequest
    {
        /// <summary>
        /// Indicate that Trulioo terms and conditions are accepted
        /// The Verification request will be executed only if the value of this header is passed as 'true'.
        /// </summary>
        [Obsolete("Field no longer in use.", false)]
        public bool AcceptTruliooTermsAndConditions { get; set; }

        /// <summary>
        ///  This field is not used anymore.  If provided it must match the setting on your account or you will get an error.
        ///  Indicate a demo verifications
        ///  If the value of pair is 'true', then the data passed will be matched against pre-configured test entities defined 
        ///  through the Trulioo web portal, the verification will not be charged to the customer. Default value for those pairs will be false.
        /// </summary>
        public bool Demo { get; set; }

        /// <summary>
        /// If set, the transaction will run asyncronously and trulioo will try to update the client with transaction state updates until completed.
        /// </summary>
        public string CallBackUrl { get; set; }

        /// <summary>
        /// Will update the client within the timeout in seconds. If failed to accomplish, the transaction will be cancelled.
        /// </summary>
        public int? Timeout { get; set; }

        /// <summary>
        /// Set to true if you want to receive address cleanse information,
        /// This will only change the response if you have address cleansing enabled for the country you are querying for.
        /// </summary>
        public bool CleansedAddress { get; set; }

        /// <summary>
        /// Indicate the type of verification
        /// Default value will be 'Identity Verification'
        /// </summary>
        public string ConfigurationName { get; set; }

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

        /// <summary>
        /// Used to send a Customer Reference ID which will be returned back in the response
        /// </summary>
        public string CustomerReferenceID { get; set; }

        /// <summary>
        /// The data field name-value pairs for the data elements on which the verification is to be performed
        /// </summary>
        public DataFields DataFields { get; set; }

        /// <summary>
        /// Verbose Mode output flag. Default value will be false.
        /// </summary>
        public bool VerboseMode { get; set; }

        /// <summary>
        /// Used to send an ID which will be stored against the job to allow batch entries to be correlated 
        /// </summary>
        public string BatchRecordID { get; set; }
    }
}
