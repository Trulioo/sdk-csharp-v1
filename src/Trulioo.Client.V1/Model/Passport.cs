namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Passport
    {
        /// <summary>
        /// Line 1 of the passport MRZ
        /// </summary>
        public string Mrz1 { get; set; }

        /// <summary>
        /// line 2 of the passport MRZ
        /// </summary>
        public string Mrz2 { get; set; }

        /// <summary>
        /// Passport Number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Passport's Licence day of expiry of the individual to be verified
        /// </summary>
        public int? DayOfExpiry { get; set; }

        /// <summary>
        /// Passport's Licence month of expiry of the individual to be verified
        /// </summary>
        public int? MonthOfExpiry { get; set; }

        /// <summary>
        /// Passport's Licence year of expiry of the individual to be verified
        /// </summary>
        public int? YearOfExpiry { get; set; }
    }
}
