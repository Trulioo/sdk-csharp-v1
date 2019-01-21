namespace Trulioo.Client.V1.Model
{
    public class Business
    {
        /// <summary>
        /// Name of the business to be verified.
        /// </summary>
        public string BusinessName { get; set; }

        /// <summary>
        /// Registration number of business to be verified.
        /// </summary>
        public string BusinessRegistrationNumber { get; set; }

        /// <summary>
        /// Day of incorporation of the business to be verified.
        /// </summary>
        public int? DayOfIncorporation { get; set; }

        /// <summary>
        /// Month of incorporation of the business to be verified.
        /// </summary>
        public int? MonthOfIncorporation { get; set; }

        /// <summary>
        /// Year of incorporation of the business to be verified.
        /// </summary>
        public int? YearOfIncorporation { get; set; }

        /// <summary>
        /// Jurisdiction Of Incorporation of the business to be verified. This is to be given as an ISO2 country code.
        /// </summary>
        public string JurisdictionOfIncorporation { get; set; }

        /// <summary>
        /// Whether or not to retrieve shareholderList document.
        /// </summary>
        public bool ShareholderListDocument { get; set; }

        /// <summary>
        /// Whether or not to retrieve financial information document.
        /// </summary>
        public bool FinancialInformationDocument { get; set; }
    }
}