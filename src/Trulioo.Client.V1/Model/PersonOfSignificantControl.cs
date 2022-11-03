namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// Person of significant control (PSC) for the business to be verified
    /// </summary>
    public class PersonOfSignificantControl
    {
        /// <summary>
        /// Optional first given name for the PSC
        /// </summary>
        public string FirstGivenName { get; set; }
        /// <summary>
        /// Optional middle name for the PSC
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Optional first surname for the PSC
        /// </summary>
        public string FirstSurName { get; set; }
        /// <summary>
        /// Optional second surname for the PSC
        /// </summary>
        public string SecondSurname { get; set; }
        /// <summary>
        /// Optional full name for the PSC
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Optional business name for the PSC
        /// </summary>
        public string BusinessName { get; set; }
        /// <summary>
        /// Optional year of birth for the PSC
        /// </summary>
        public string YearOfBirth { get; set; }
        /// <summary>
        /// Optional month of birth for the PSC
        /// </summary>
        public string MonthOfBirth { get; set; }
        /// <summary>
        /// Optional day of birth for the PSC
        /// </summary>
        public string DayOfBirth { get; set; }
    }
}