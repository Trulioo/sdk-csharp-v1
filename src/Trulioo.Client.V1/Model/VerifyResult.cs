﻿using System;
using System.Collections.Generic;
using Trulioo.Client.V1.Model.Errors;

namespace Trulioo.Client.V1.Model
{
    public class VerifyResult
    {
        /// <summary>
        /// The id for the transaction it will be a GUID
        /// </summary>
        public string TransactionID { get; set; }

        /// <summary>
        /// Time in UTC
        /// </summary>
        public DateTime UploadedDt { get; set; }

        /// <summary>
        /// Time in UTC
        /// </summary>
        public DateTime? CompletedDt { get; set; }
        /// <summary>
        /// Country Code 
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        public string ProductName { get; set; }

        public Record Record { get; set; }

        /// <summary>
        /// Customer Reference Id
        /// </summary>
        public string CustomerReferenceID { get; set; }

        /// <summary>
        ////<ul>
        ////<li>1000 : Provider Error - There was an error connecting to the source</li>
        ////<li>1001 : Missing Required Field</li>
        ////<li>1002 : Datasource Unavailable - The source did not respond</li>
        ////<li>1003 : Datasource Error - The source returned an error</li>
        ////<li>1004 : State not supported (AU driver licence)</li>
        ////<li>1005 : Missing Consent - consent not sent for the source</li>
        ////<li>1008 : Invalid Field Format</li>
        ////<li>2000 : Unrecognized Error</li>
        ////</ul>
        /// </summary>
        public IEnumerable<ServiceError> Errors { get; set; }
    }
}
