namespace Trulioo.Client.V1.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trulioo.Client.V1.Model;
    using Xunit;
    using System.Text.Json;
    using System;

    public class ConfigurationFacts
    {
        [Theory(Skip = "Calls API")]
        [MemberData(nameof(TestEntitiesTestData))]
        public async Task GetTestEntitiesTest(string countryCode, List<TestEntityDataFields> expectedTestEntities)
        {
            using (var client = Common.Basefact.GetTruliooClient())
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

        [Theory(Skip = "Calls API")]
        [MemberData(nameof(DatasourcesTestData))]
        public async Task GetDatasourcesTest(string countryCode, List<string> expectedDatasources)
        {
            using (var client = Common.Basefact.GetTruliooClient())
            {
                var response = await client.Configuration.GetDatasourcesAsync(countryCode, "Identity Verification");
                List<string> datasources = response.Select(datasource => datasource.Name).ToList();
                Assert.Equal(expectedDatasources.Count(), datasources.Count());
                Assert.True(expectedDatasources.All(datasources.Contains));
            }
        }

        [Fact(Skip = "Calls API")]
        public async Task GetAllDatasourcesTest()
        {
            using (var client = Common.Basefact.GetTruliooClient())
            {
                var response = await client.Configuration.GetAllDatasourcesAsync("Identity Verification");
                var datasources = new List<string>();
                foreach (var r in response)
                {
                    datasources.AddRange(r.Datasources.Select(d => d.Name));
                }
                Assert.NotEmpty(response);
                Assert.NotEmpty(datasources);
            }
        }

        [Fact(Skip = "Calls API")]
        public async Task GetDocumentTypeAllCountries()
        {
            var expectedNumberOfCountries = 223;
            using (var client = Common.Basefact.GetTruliooClient())
            {
                var response = await client.Configuration.GetDocumentTypesAsync();
                Assert.Equal(expectedNumberOfCountries, response.Count());
            }
        }

        [Theory(Skip = "Calls API")]
        [MemberData(nameof(DocumentTypeTestData))]
        public async Task GetDocumentTypeSpecificCountry(string countryCode, List<string> expectedDocumentTypes)
        {
            using (var client = Common.Basefact.GetTruliooClient())
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
            using (var client = Common.Basefact.GetTruliooClient())
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
            using (var client = Common.Basefact.GetTruliooClient())
            {
                var response = await client.Configuration.GetDetailedСonsentsAsync(countryCode, configurationName);
                Assert.NotNull(response);
                Assert.Equal(results.Count(), response.Count());
            }
        }

        [Theory(Skip = "Calls API")]
        [MemberData(nameof(RecommendedData))]
        public async Task GetRecommendedFields(string countryCode, string configurationName)
        {
            using (var client = Common.Basefact.GetTruliooClient())
            {
                var response = await client.Configuration.GetRecommendedFieldsAsync(countryCode, configurationName);
                Assert.NotNull(response);
            }
        }

        [Theory(Skip = "Calls API")]
        [InlineData("CA", null)]
        [InlineData("CA", "BC")]
        [InlineData(null, null)]
        [InlineData(" ", "")]
        [InlineData("", "BC")]
        [InlineData(null, "BC")]
        public async Task GetBusinessRegistrationNumbers(string countryCode, string jurisdiction)
        {
            using (var client = Common.Basefact.GetTruliooClient())
            {
                if (string.IsNullOrWhiteSpace(countryCode) && !string.IsNullOrWhiteSpace(jurisdiction))
                {
                    await Assert.ThrowsAsync<ArgumentException>(async () => await client.Configuration.GetBusinessRegistrationNumbersAsync(countryCode, jurisdiction));
                }
                else
                {
                    var response = await client.Configuration.GetBusinessRegistrationNumbersAsync(countryCode, jurisdiction);
                    Assert.NotNull(response);
                }
            }
        }

        [Theory(Skip = "Calls API")]
        [InlineData("CA")]
        [InlineData(null)]
        [InlineData(" ")]
        public async Task GetCountryJOI(string countryCode)
        {
            using (var client = Common.Basefact.GetTruliooClient())
            {
                var response = await client.Configuration.GetCountryJOI(countryCode);
                Assert.NotNull(response);
            }
        }

        public static IEnumerable<object[]> DatasourcesTestData()
        {
            yield return new object[] { Common.Basefact.CountryCode, Common.Basefact.DatasourcesTestList.Split(',').ToList() };
        }

        public static IEnumerable<object[]> DocumentTypeTestData()
        {
            yield return new object[] { Common.Basefact.CountryCode, Common.Basefact.DocumentTypeList.Split(',').ToList() };
        }

        public static IEnumerable<object[]> ConsentsData()
        {
            yield return new object[] { Common.Basefact.CountryCode, "Identity Verification", Common.Basefact.ConsentsList.Split(',').ToList() };
        }

        public static IEnumerable<object[]> RecommendedData()
        {
            yield return new object[] { Common.Basefact.CountryCode, "Identity Verification" };
        }

        public static IEnumerable<object[]> TestEntitiesTestData()
        {
            List<TestEntityDataFields> testEntities;

            if (string.IsNullOrWhiteSpace(Common.Basefact.TestEntities))
            {
                testEntities = new List<TestEntityDataFields>() {
                    new TestEntityDataFields() {
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
                            UnitNumber = "",
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

                };
            }
            else
            {
                testEntities = JsonSerializer.Deserialize<List<TestEntityDataFields>>(Common.Basefact.TestEntities);
            }


            yield return new object[] { Common.Basefact.CountryCode, testEntities };
        }

    }
}
