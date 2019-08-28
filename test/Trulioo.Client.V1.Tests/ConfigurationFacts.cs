using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Trulioo.Client.V1.Model;
using Xunit;

namespace Trulioo.Client.V1.Tests
{
    public class ConfigurationFacts
    {
        private readonly string _username = ConfigurationManager.AppSettings["username"];
        private readonly string _password = ConfigurationManager.AppSettings["password"];
        private readonly string _hostEndpoint = ConfigurationManager.AppSettings["host"];

        [Theory(Skip = "Calls API")]
        [MemberData(nameof(TestEntitiesTestData))]
        public async Task GetTestEntitiesTest(string countryCode, List<DataFields> expectedTestEntities)
        {
            using (var client = new TruliooApiClient(new Context(_username, _password) { Host = _hostEndpoint }))
            {
                var response = await client.Configuration.GetTestEntitiesAsync(countryCode, "Identity Verification");
          
                Assert.Equal(expectedTestEntities.Count(), response.Count());

                List<string> expectedFirstNames = expectedTestEntities.Where(f => f?.PersonInfo?.FirstGivenName != null).Select(f => f.PersonInfo.FirstGivenName).ToList();
                List<string> actualFirstNames = response.Where(f => f?.PersonInfo?.FirstGivenName != null).Select(f => f.PersonInfo.FirstGivenName).ToList();
                Assert.Equal(expectedFirstNames.Count(), actualFirstNames.Count());
                Assert.True(expectedFirstNames.All(actualFirstNames.Contains));
               
                List<string> expectedFirstSurnames = expectedTestEntities.Where(testEntity => testEntity?.PersonInfo?.FirstSurName != null).Select(f => f.PersonInfo.FirstSurName).ToList();
                List<string> actualFirstSurnames = response.Where(testEntity => testEntity?.PersonInfo?.FirstSurName != null).Select(f => f.PersonInfo.FirstSurName).ToList();
                Assert.Equal(expectedFirstSurnames.Count(), actualFirstSurnames.Count());
                Assert.True(expectedFirstSurnames.All(actualFirstSurnames.Contains));

                List<int?> expectedYearOfBirth = expectedTestEntities.Where(f => f?.PersonInfo?.YearOfBirth != null).Select(f => f.PersonInfo.YearOfBirth).ToList();
                List<int?> actualYearOfBirth = expectedTestEntities.Where(f => f?.PersonInfo?.YearOfBirth != null).Select(f => f.PersonInfo.YearOfBirth).ToList();
                Assert.Equal(expectedYearOfBirth.Count(), actualYearOfBirth.Count());
                Assert.True(expectedYearOfBirth.All(actualYearOfBirth.Contains));

                List<string> expectedTelephone = expectedTestEntities.Where(f => f?.Communication?.Telephone != null).Select(f => f.Communication.Telephone).ToList();
                List<string> actualTelephone = response.Where(f => f?.Communication?.Telephone != null).Select(f => f.Communication.Telephone).ToList();
                Assert.Equal(expectedTelephone.Count(), actualTelephone.Count());
                Assert.True(expectedTelephone.All(actualTelephone.Contains));
            }
        }

        public static IEnumerable<object[]> TestEntitiesTestData()
        {
            yield return new object[] {"AU",
                new List<DataFields>() {
                    new DataFields() {
                        PersonInfo = new PersonInfo() {
                            FirstGivenName = "",
                            MiddleName = "",
                            FirstSurName = "",
                            DayOfBirth = 0,
                            MonthOfBirth = 0,
                            YearOfBirth = 0000,
                            Gender = ""
                        },
                        Location = new Location()
                        {
                            BuildingNumber = "",
                            UnitNumber= "",
                            StreetName = "",
                            StreetType = "",
                            Suburb = "",
                            StateProvinceCode = "",
                            PostalCode = "",
                        },
                        Communication = new Communication()
                        {
                            Telephone = ""
                        },
                        DriverLicence = new DriverLicence
                        {
                            Number = "",
                            State = "",
                            DayOfExpiry = 0,
                            MonthOfExpiry = 0
                        }
                    }
                }
            };
        }

        [Theory(Skip = "Calls API")]
        [MemberData(nameof(DatasourcesTestData))]
        public async Task GetDatasourcesTest(string countryCode, List<string> expectedDatasources)
        {
            using (var client = new TruliooApiClient(new Context(_username, _password) { Host = _hostEndpoint }))
            {
                var response = await client.Configuration.GetDatasourcesAsync(countryCode, "Identity Verification");
                List<string> datasources = response.Select(datasource => datasource.Name).ToList();
                Assert.Equal(expectedDatasources.Count(), datasources.Count());
                Assert.True(expectedDatasources.All(datasources.Contains));
            }
        }

        public static IEnumerable<object[]> DatasourcesTestData()
        {
            yield return new object[] { "AU", new List<string>() { "" } };
        }


        [Fact(Skip = "Calls API")]
        public async Task GetDocumentTypeAllCountries()
        {
            var expectedNumberOfCountries = 223;
            using (var client = new TruliooApiClient(new Context(_username, _password) { Host = _hostEndpoint }))
            {
                var response = await client.Configuration.GetDocumentTypesAsync();
                Assert.Equal(expectedNumberOfCountries, response.Count());
            }
        }

        [Theory(Skip = "Calls API")]
        [MemberData(nameof(DocumentTypeTestData))]
        public async Task GetDocumentTypeSpecificCountry(string countryCode, List<string> expectedDocumentTypes)
        {
            using (var client = new TruliooApiClient(new Context(_username, _password) { Host = _hostEndpoint }))
            {
                var response = await client.Configuration.GetDocumentTypesAsync(countryCode);
                Assert.Equal(expectedDocumentTypes.Count(), response[countryCode].Count());
                Assert.True(expectedDocumentTypes.All(response[countryCode].Contains));
            }
        }

        [Theory(Skip = "Calls API")]
        [MemberData(nameof(ConsentsData))]
        public async Task GetConsents(string countryCode, string configurationName, List<string> results)
        {
            using (var client = new TruliooApiClient(new Context(_username, _password) { Host = _hostEndpoint }))
            {
                var response = await client.Configuration.GetСonsentsAsync(countryCode, configurationName);
                Assert.NotNull(response);
                Assert.Equal(results.Count(), response.Count());
            }
        }

        [Theory(Skip = "Calls API")]
        [MemberData(nameof(ConsentsData))]
        public async Task GetDetailedConsents(string countryCode, string configurationName, List<string> results)
        {
            using (var client = new TruliooApiClient(new Context(_username, _password) { Host = _hostEndpoint }))
            {
                var response = await client.Configuration.GetDetailedСonsentsAsync(countryCode, configurationName);
                Assert.NotNull(response);
                Assert.Equal(results.Count(), response.Count());
            }
        }


        [Theory(Skip = "Calls API")]
        [MemberData(nameof(ConsentsData))]
        public async Task GetRecommendedFields(string countryCode, string configurationName, List<string> results)
        {
            using (var client = new TruliooApiClient(new Context(_username, _password) { Host = _hostEndpoint }))
            {
                var response = await client.Configuration.GetRecommendedFieldsAsync(countryCode, configurationName);
                Assert.NotNull(response);
            }
        }

        public static IEnumerable<object[]> DocumentTypeTestData()
        {
            yield return new object[] { "countryCode", new List<string>() { ""} };
        }

        public static IEnumerable<object[]> ConsentsData()
        {
            yield return new object[] { "countryCode", "Identity Verification", new List<string> { "" } };
        }

    }
}
