namespace Trulioo.Client.V1.Model
{
    public class Business
    {
        public string BusinessName { get; set; }
        public string BusinessRegistrationNumber { get; set; }
        public int DayOfIncorporation { get; set; }
        public int MonthOfIncorporation { get; set; }
        public int YearOfIncorporation { get; set; }
        public string JurisdictionOfIncorporation { get; set; }
        public bool ShareholderListDocument { get; set; }
        public bool FinancialInformationDocument { get; set; }
    }
}