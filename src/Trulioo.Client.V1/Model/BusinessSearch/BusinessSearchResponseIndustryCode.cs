namespace Trulioo.Client.V1.Model.BusinessSearch
{
    public class BusinessSearchResponseIndustryCode
    {
        public BusinessSearchResponseIndustryCode(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; set; }
        public string Description { get; set; }
    }
}
