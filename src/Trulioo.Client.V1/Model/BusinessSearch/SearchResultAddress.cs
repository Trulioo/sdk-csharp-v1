namespace Trulioo.Client.V1.Model.BusinessSearch
{
    /// <summary>
    /// Name value pairs of address found from business search
    /// </summary>
    public class SearchResultAddress
    {
        /// <summary>
        /// Flat/Unit/Apartment number of address
        /// </summary>
        public string UnitNumber { get; set; }
        /// <summary>
        /// House / Civic / Building number of address
        /// </summary>
        public string BuildingNumber { get; set; }
        /// <summary>
        /// 	Name of building
        /// </summary>
        public string BuildingName { get; set; }
        /// <summary>
        /// Street name
        /// </summary>
        public string StreetName { get; set; }
        /// <summary>
        /// 	Street type of address (Typically St, Rd etc)
        /// </summary>
        public string StreetType { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Suburb / Subdivision / Municipality
        /// </summary>
        public string Suburb { get; set; }
        /// <summary>
        /// State or province of address. US sources expect 2 characters. Australian sources expect 2 or 3 characters.
        /// </summary>
        public string StateProvinceCode { get; set; }
        /// <summary>
        /// ZIP Code or Postal Code
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// Address1
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// Address Type
        /// </summary>
        public string AddressType { get; set; }
        /// <summary>
        /// State Province
        /// </summary>
        public string StateProvince { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string CountryCode { get; set; }
    }
}
