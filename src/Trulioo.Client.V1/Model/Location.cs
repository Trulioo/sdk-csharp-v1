namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Location
    {
        /// <summary>
        /// House / Civic / Building number of home address
        /// </summary>
        public string BuildingNumber { get; set; }

        /// <summary>
        /// Name of building of home address
        /// </summary>
        public string BuildingName { get; set; }

        /// <summary>
        /// Flat/Unit/Apartment number of home address
        /// </summary>
        public string UnitNumber { get; set; }

        /// <summary>
        /// Street name of primary residence
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street type of primary residence (Typically St, Rd etc)
        /// </summary>
        public string StreetType { get; set; }

        /// <summary>
        /// City of home address
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Suburb / Subdivision / Municipality of home address
        /// </summary>
        public string Suburb { get; set; }

        /// <summary>
        /// County / District of home address
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// State of primary residence. US sources expect 2 characters. Australian sources expect 2 or 3 characters.
        /// </summary>
        public string StateProvinceCode { get; set; }

        /// <summary>
        /// Country of physical address (ISO 3166-1 alpha-2 code)
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// ZIP Code or Postal Code of home address
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Post Office Box
        /// </summary>
        public string POBox { get; set; }

        /// <summary>
        /// Not normalized fields
        /// </summary>
        public LocationFields.AdditionalFields AdditionalFields { get; set; }
    }
}
