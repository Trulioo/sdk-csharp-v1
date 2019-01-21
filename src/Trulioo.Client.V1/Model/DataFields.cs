namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// The data field name-value pairs for the data elements on which the verification is to be performed
    /// </summary>
    public class DataFields
    {
        /// <summary>
        /// Personal Information
        /// </summary>
        public PersonInfo PersonInfo { get; set; }

        /// <summary>
        /// Location Information
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Communication Information
        /// </summary>
        public Communication Communication { get; set; }

        /// <summary>
        /// Driver Licence Information
        /// </summary>
        public DriverLicence DriverLicence { get; set; }

        /// <summary>
        /// National Identification Information
        /// Supported Types: NationalID, Health, SocialService
        /// </summary>
        public NationalId[] NationalIds { get; set; }

        /// <summary>
        /// Passport information
        /// </summary>
        public Passport Passport { get; set; }

        /// <summary>
        /// CountrySpecific fields
        /// {"CountryCode" : "Field1" : "Value",
        /// "Field2" : "Value"
        /// }
        /// </summary>
        public CountrySpecific CountrySpecific { get; set; }

        /// <summary>
        /// Document Information for Document Verification
        /// </summary>
        public Document Document { get; set; }

        /// <summary>
        /// Business information for Business Verification
        /// </summary>
        public Business Business { get; set; }
    }
}
