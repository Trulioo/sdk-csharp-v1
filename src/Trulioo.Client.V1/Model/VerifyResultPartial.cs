using System.Collections.Generic;

namespace Trulioo.Client.V1.Model
{
    public class VerifyResultPartial : VerifyResult
    {
        public List<string> DatasourcesAwaitingResult { get; set; }
        public string Status { get; set; }
    }
}
