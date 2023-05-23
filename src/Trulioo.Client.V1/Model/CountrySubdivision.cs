namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// ISO 3166-2 break down of the country
    /// </summary>
    public class CountrySubdivision
    {
        /// <summary>
        /// Name of the area, in English or one of the languages of the country
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Code for the area
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// Code of the parent entity
        /// </summary>
        public string ParentCode { get; set; }

        /// <summary>
        /// Code for the country
        /// </summary>
        public string CountryCode { get; set; }
        
    }
}
