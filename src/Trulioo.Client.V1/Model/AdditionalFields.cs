namespace Trulioo.Client.V1.Model
{
    public class AdditionalFields
    {
        /// <summary>
        /// Full name of the individual to be verified. 
        /// Available only for countries where a person's name can not be resolved into FirstGivenName, MiddleName and FirstSurname. 
        /// Use the GET configuration/v1/fields/{configurationname}/{countrycode} to determine if this field is available for the country in question. 
        /// Data in this field will supersede information provided in FirstGivenName, MiddleName and FirstSurname
        /// </summary>
        public string FullName { get; set; }
    }
}
