using System.Collections.Generic;
using Trulioo.Client.V1.Model.Errors;

namespace Trulioo.Client.V1.Model
{
    /// <summary>
    /// A result from a particular datasource
    /// </summary>
    public class DatasourceResult
    {
        public string DatasourceStatus { get; set; }

        public string DatasourceName { get; set; }

        public IEnumerable<DatasourceField> DatasourceFields { get; set; }

        public IEnumerable<AppendedField> AppendedFields { get; set; }

        public IEnumerable<ServiceError> Errors { get; set; }

        public IEnumerable<string> FieldGroups { get; set; }

        public IEnumerable<BusinessResult> Results { get; set; }
    }
}
