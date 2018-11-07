using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Trulioo.Client.V1.Model;
using Xunit;

namespace Trulioo.Client.V1.Tests
{
    public class Verifications : Basefact
    {
        [Fact]
        public async Task BusinessVerification_Success()
        {
            //Arrange
            using (var service = GetTruliooClient())
            {
                var request = new VerifyRequest
                {
                    AcceptTruliooTermsAndConditions = true,
                    CountryCode = "CA",
                    DataFields = new DataFields
                    {
                        Business = new Model.Business
                        {
                            BusinessName = ConfigurationManager.AppSettings["businessname"],
                            BusinessRegistrationNumber = ConfigurationManager.AppSettings["businessregistrationnumber"],
                            JurisdictionOfIncorporation = ConfigurationManager.AppSettings["businessjurisdiction"]
                        }
                    }
                };

                //Act
                var response = await service.Verification.VerifyAsync(request);

                //Assert
                Assert.NotNull(response);
            }
        }
    }
}
