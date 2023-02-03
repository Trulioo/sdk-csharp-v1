namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Communication
    {
        /// <summary>
        /// Mobile phone number
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Telephone number of the individual to be verified
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Additional Phone/Mobile Number of the individual to be verified
        /// </summary>
        public string Telephone2 { get; set; }

        /// <summary>
        /// Email address of the individual to be verified
        /// </summary>
        public string EmailAddress { get; set; }
    }
}
