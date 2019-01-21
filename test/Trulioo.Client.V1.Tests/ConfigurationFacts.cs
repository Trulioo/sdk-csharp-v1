using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Trulioo.Client.V1.Model;
using Xunit;

namespace Trulioo.Client.V1.Tests
{
    public class ConfigurationFacts
    {
        
        [Theory(Skip = "Calls API")]
        [MemberData(nameof(TestEntitiesTestData))]
        public async Task GetTestEntitiesTest(string username, string password, string hostEndpoint, string countryCode, List<DataFields> expectedTestEntities)
        {
            using (var client = new TruliooApiClient(new Context(username, password) { Host = hostEndpoint }))
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
            yield return new object[] { "username", "password", "api.globaldatacompany.com", "AU",
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
                        } }
                    }
                };
        }

        [Theory(Skip = "Calls API")]
        [MemberData(nameof(DatasourcesTestData))]
        public async Task GetDatasourcesTest(string username, string password, string hostEndpoint, string countryCode, List<string> expectedDatasources)
        {
            using (var client = new TruliooApiClient(new Context(username, password) { Host = hostEndpoint }))
            {
                var response = await client.Configuration.GetDatasourcesAsync(countryCode, "Identity Verification");
                List<string> datasources = response.Select(datasource => datasource.Name).ToList();
                Assert.Equal(expectedDatasources.Count(), datasources.Count());
                Assert.True(expectedDatasources.All(datasources.Contains));
            }
        }

        public static IEnumerable<object[]> DatasourcesTestData()
        {
            yield return new object[] { "username", "password", "api.globaldatacompany.com", "AU", new List<string>() {} };
        }


        [Theory(Skip = "Calls API")]
        [InlineData("username", "password", "api.globaldatacompany.com", 222)]
        public async Task GetDocumentTypeAllCountries(string username, string password, string hostEndpoint, int expectedNumberOfCountries)
        {
            using (var client = new TruliooApiClient(new Context(username, password) { Host = hostEndpoint }))
            {
                var response = await client.Configuration.GetDocumentTypesAsync();
                Assert.Equal(expectedNumberOfCountries, response.Count());
            }
        }

        [Theory(Skip = "Calls API")]
        [MemberData(nameof(DocumentTypeTestData))]
        public async Task GetDocumentTypeSpecificCountry(string username, string password, string hostEndpoint, string countryCode, List<string> expectedDocumentTypes)
        {
            using (var client = new TruliooApiClient(new Context(username, password) { Host = hostEndpoint }))
            {
                var response = await client.Configuration.GetDocumentTypesAsync(countryCode);
                Assert.Equal(expectedDocumentTypes.Count(), response[countryCode].Count());
                Assert.True(expectedDocumentTypes.All(response[countryCode].Contains));
            }
        }

        public static IEnumerable<object[]> DocumentTypeTestData()
        {
            yield return new object[] { "username", "password", "api.globaldatacompany.com", "CA", new List<string>() {} };
        }
        
    }
}
