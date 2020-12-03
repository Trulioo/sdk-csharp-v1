namespace Trulioo.Client.V1.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trulioo.Client.V1.Model;
    using Xunit;
    using System.Text.Json;

    public class VerificationFacts
    {
        [Theory(Skip = "Calls API")]
        [MemberData(nameof(TransactionRecordVerboseTestData))]
        public async Task GetTransactionRecordVerbose(string transactionRecordID, TransactionRecordResult expectedTransactionRecordResult)
        {
            using (var client = Common.Basefact.GetTruliooClient())
            {
                var response = await client.Verification.GetTransactionRecordVerboseAsync(transactionRecordID);

                Assert.Equal(expectedTransactionRecordResult.TransactionID, response.TransactionID);

                Assert.Equal(expectedTransactionRecordResult.Errors.Count(), response.Errors.Count());

                Assert.Equal(expectedTransactionRecordResult.InputFields.Count(), response.InputFields.Count());

                List<string> expectedInputFieldNames = expectedTransactionRecordResult.InputFields.Select(x => x.FieldName).ToList();
                List<string> actualInputFieldNames = response.InputFields.Select(x => x.FieldName).ToList();
                Assert.True(expectedInputFieldNames.All(actualInputFieldNames.Contains));

                List<string> expectedInputFieldValues = expectedTransactionRecordResult.InputFields.Select(x => x.Value).ToList();
                List<string> actualInputFieldValues = response.InputFields.Select(x => x.Value).ToList();
                Assert.True(expectedInputFieldValues.All(actualInputFieldValues.Contains));

                Assert.Equal(expectedTransactionRecordResult.Record.RecordStatus, response.Record.RecordStatus);
                Assert.Equal(expectedTransactionRecordResult.Record.DatasourceResults.Count(), response.Record.DatasourceResults.Count());
            }
        }

        public static IEnumerable<object[]> TransactionRecordVerboseTestData()
        {
            TransactionRecordResult transactionRecordResult;

            if (string.IsNullOrWhiteSpace(Common.Basefact.TransactionResult))
            {
                transactionRecordResult = new TransactionRecordResult()
                {
                    InputFields = new List<DataField>() { new DataField { FieldName = "", Value = "" } },
                    TransactionID = "",
                    Record = new Model.Record()
                    {
                        RecordStatus = "",
                        DatasourceResults = new List<DatasourceResult>()
                        {
                            new DatasourceResult()
                            {
                                DatasourceName = "",
                                DatasourceFields = new List<DatasourceField>() { new DatasourceField() { FieldName = "", Status = "" },
                                                                                 new DatasourceField() { FieldName = "", Status = "" } }
                            }
                        }
                    },
                    Errors = new List<Model.Errors.ServiceError> { }
                };
            }
            else
            {
                transactionRecordResult = JsonSerializer.Deserialize<TransactionRecordResult>(Common.Basefact.TransactionResult);
            }

            yield return new object[] { Common.Basefact.TransactionRecordId, transactionRecordResult };
        }

        [Theory(Skip = "Calls API")]
        [MemberData(nameof(TransactionStatusTestData))]
        public async Task GetTransactionStatus(string transactionID, TransactionStatus expectedTransactionStatus)
        {
            using (var client = Common.Basefact.GetTruliooClient())
            {
                var response = await client.Verification.GetTransactionStatusAsync(transactionID);
                Assert.Equal(expectedTransactionStatus.Status, response.Status);
                Assert.Equal(expectedTransactionStatus.TransactionId, response.TransactionId);
                Assert.Equal(expectedTransactionStatus.TransactionRecordId, response.TransactionRecordId);
                Assert.Equal(expectedTransactionStatus.IsTimedOut, response.IsTimedOut);
            }
        }

        public static IEnumerable<object[]> TransactionStatusTestData()
        {
            TransactionStatus transactionStatus;

            if (string.IsNullOrWhiteSpace(Common.Basefact.TransactionStatus))
            {
                transactionStatus = new TransactionStatus()
                {
                    TransactionId = "",
                    TransactionRecordId = "",
                    Status = "",
                    IsTimedOut = false
                };
            }
            else
            {
                transactionStatus = JsonSerializer.Deserialize<TransactionStatus>(Common.Basefact.TransactionStatus);
            }

            yield return new object[] 
            {
                Common.Basefact.TransactionId, transactionStatus
            };
        }

        // Tests if ApiClient throws Exception when parsing WatchListDetails in AppendedField
        // This needs an account which has ComplyAdvantage V3 configured in Germany (or any country)
        [Fact(Skip = "Calls API")]
        public async Task WatchlistDetailsResponseNoExceptionThrownTest_TECH9_103()
        {
            using (var client = Common.Basefact.GetTruliooClient())
            {
                var request = new VerifyRequest
                {
                    AcceptTruliooTermsAndConditions = true,
                    VerboseMode = true,
                    Demo = false,
                    ConfigurationName = "Identity Verification",
                    CountryCode = "DE",
                    DataFields = new DataFields
                    {
                        PersonInfo = new PersonInfo
                        {
                            FirstGivenName = "test",
                            FirstSurName = "test",
                            YearOfBirth = 1980
                        }
                    }
                };

                var response = await client.Verification.VerifyAsync(request);
                Assert.NotNull(response);
            }
        }

        [Theory(Skip = "Calls API")]
        [MemberData(nameof(DownloadDocData))]
        public async Task GetDocumentDownload(string transactionRecordId, string fieldName)
        {
            using (var client = Common.Basefact.GetTruliooClient())
            {
                var response = await client.Verification.GetDocumentDownloadAsync(transactionRecordId, fieldName);
                Assert.NotNull(response);
            }
        }

        public static IEnumerable<object[]> DownloadDocData()
        {
            yield return new object[] { "transactionRecordId", "fieldName" };
        }
    }
}
