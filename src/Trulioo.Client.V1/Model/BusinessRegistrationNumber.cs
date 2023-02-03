using System.Collections.Generic;

namespace Trulioo.Client.V1.Model
{
    public class BusinessRegistrationNumber
    {
        /// <summary>
        /// The name of the business registration number
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Brief description of the business registration number
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Country to which the business registration number applies
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Optional jurisdiction to which the business registration number applies
        /// </summary>
        public string Jurisdiction { get; set; }
        /// <summary>
        /// Whether the business registration number is supported by Trulioo's systems
        /// </summary>
        public bool Supported { get; set; }
        /// <summary>
        /// The specified type of this business registration number
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The mask(s) describing this business registration number
        /// </summary>
        public List<BusinessRegistrationNumberMask> Masks { get; set; }
    }
}
