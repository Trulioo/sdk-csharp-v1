using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// Business class to hold name value pair to be passed for verification
    /// </summary>
    public class DownloadDocument
    {
        /// <summary>
        /// Name of the document
        /// </summary>
        public string DocumentName { get; set; }
        /// <summary>
        /// The content of the document
        /// </summary>   
        public byte[] DocumentContent { get; set; }
    }
}
