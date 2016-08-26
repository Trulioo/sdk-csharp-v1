namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class DriverLicence
    {
        /// <summary>
        /// Driver's Licence Number of the individual to be verified
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// State of issue for driver's Licence 
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Driver's Licence day of expiry of the individual to be verified
        /// </summary>
        public int? DayOfExpiry { get; set; }

        /// <summary>
        /// Driver's Licence month of expiry of the individual to be verified
        /// </summary>
        public int? MonthOfExpiry { get; set; }

        /// <summary>
        /// Driver's Licence year of expiry of the individual to be verified
        /// </summary>
        public int? YearOfExpiry { get; set; }
    }
}
