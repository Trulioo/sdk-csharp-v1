namespace Trulioo.Client.V1.Model
{
    public class PersonInfo
    {
        /// <summary>
        /// First name of the individual to be verified 
        /// Dual purpose First Name or Initial
        /// </summary>
        public string FirstGivenName { get; set; }

        /// <summary>
        /// Second given name of the individual to be verified
        /// Dual purpose Middle Name or Initial
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// First (paternal) family name of the individual to be verified
        /// </summary>
        public string FirstSurName { get; set; }

        /// <summary>
        /// second family name of the individual to be verified
        /// </summary>
        public string SecondSurname { get; set; }

        /// <summary>
        /// Enter full name in ISO Latin-1 character set
        /// Used for data sources that require the person’s name in ISO Latin-1 format (i.e. as Passport MRZ)
        /// </summary>
        public string ISOLatin1Name { get; set; }

        /// <summary>
        /// Day of birth date (i.e. 23 for a date of birth of 23/11/1975)
        /// </summary>
        public int? DayOfBirth { get; set; }

        /// <summary>
        /// Month of birth date (i.e. 11 for a date of birth of 23/11/1975)
        /// </summary>
        public int? MonthOfBirth { get; set; }

        /// <summary>
        /// Year of birth date (i.e. 1975 for a date of birth of 23/11/1975)
        /// </summary>
        public int? YearOfBirth { get; set; }

        /// <summary>
        /// Minimum permitted age of the individual 
        /// GlobalGateway calculates age of individual and compares it to this number
        /// </summary>
        public int? MinimumAge { get; set; }

        /// <summary>
        /// Single character M / F (M = Male, F = Female)
        /// </summary>
        public string Gender { get; set; }

        public PersonalInfoFields.AdditionalFields AdditionalFields { get; set; }
    }
}
