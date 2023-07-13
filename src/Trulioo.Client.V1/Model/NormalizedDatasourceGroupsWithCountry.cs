using System.Collections.Generic;
namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// Model for information returned on multiple datasources
    /// </summary>
    public class NormalizedDatasourceGroupsWithCountry
    {
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Datasources
        /// </summary>
        public List<NormalizedDatasourceGroupCountry> Datasources { get; set; }
    }
}