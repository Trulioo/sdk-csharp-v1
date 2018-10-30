using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trulioo.Client.V1.Model
{
    public class BusinessResult
    {
        public string Index { get; set; }
        public string BusinessName { get; set; }
        public string MatchingScore { get; set; }
        public string BusinessRegistrationNumber { get; set; }
        public string JurisdictionOfIncorporation { get; set; }
        public string FullAddress { get; set; }
        public Dictionary<string, string> Address { get; set; }
    }
}
