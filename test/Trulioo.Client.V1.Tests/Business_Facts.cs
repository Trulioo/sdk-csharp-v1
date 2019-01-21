using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Trulioo.Client.V1.Model;
using Xunit;

namespace Trulioo.Client.V1.Tests
{
    public class Business : Basefact
    {
        [Fact]
        public async Task Search_Success()
        {
            //Arrange
            using (var service = GetTruliooClient())
            {
                var request = new SearchRequest
                {
                    AcceptTruliooTermsAndConditions = true,
                    CountryCode = "CA",
                    Business = new Dictionary<string, string>
                    {
                        {"BusinessName", ConfigurationManager.AppSettings["businessname"] },
                        {"JurisdictionOfIncorporation", ConfigurationManager.AppSettings["businessjurisdiction"] }
                    }
                };

                //Act
                var response = await service.Business.SearchAsync(request);

                //Assert
                Assert.NotNull(response);
            }
        }
    }
}
