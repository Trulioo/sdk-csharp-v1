using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// Datasource model for information returned on a specific datasource
    /// </summary>
    public class NormalizedDatasourceGroupCountry
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Required Fields
        /// </summary>
        public List<NormalizedDatasourceField> RequiredFields { get; set; }

        /// <summary>
        /// Optional Fields
        /// </summary>
        public List<NormalizedDatasourceField> OptionalFields { get; set; }

        /// <summary>
        /// Appended Fields
        /// </summary>
        public List<NormalizedDatasourceField> AppendedFields { get; set; }

        /// <summary>
        /// Output Fields
        /// </summary>
        public List<NormalizedDatasourceField> OutputFields { get; set; }

        /// <summary>
        /// Source Type
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// Update Frequency
        /// </summary>
        public string UpdateFrequency { get; set; }

        /// <summary>
        /// Coverage
        /// </summary>
        public string Coverage { get; set; }
    }
}
