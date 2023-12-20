using System;
using System.Collections.Generic;
using System.Text;

namespace Trulioo.Client.V1.Model
{
    public class RiskMonitorSettings
    {
        /// <summary>
        /// Frequency to run a fraud check on the enrolled entity 
        /// </summary>
        public string Frequency { get; set; }

        /// <summary>
        /// Callback Url for Fraud product
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// The IP address of the end user
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Email of end user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Contextual input for datasource
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// User Agent of end user
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Device ID of end user
        /// </summary>
        public string DeviceID { get; set; }

        /// <summary>
        /// Phone number of end user
        /// </summary>
        public string Phone { get; set; }
    }
}
