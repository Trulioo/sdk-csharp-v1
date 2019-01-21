using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// Name value pairs of document information to be passed for verification
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Front of the document
        /// </summary>
        public byte[] DocumentFrontImage { get; set; }

        /// <summary>
        /// Back of the document
        /// </summary>
        public byte[] DocumentBackImage { get; set; }

        /// <summary>
        /// Selfie image
        /// </summary>
        public byte[] LivePhoto { get; set; }

        /// <summary>
        /// Document type 
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        /// Accept Incomplete Document.
        /// </summary>
        public bool? AcceptIncompleteDocument { get; set; }

        /// <summary>
        /// Validate Document Image Quality.
        /// </summary>
        public bool? ValidateDocumentImageQuality { get; set; }
    }
}
