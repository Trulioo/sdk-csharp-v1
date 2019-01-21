using System.Net;
using Xunit;

namespace Trulioo.Client.V1.Tests
{
    public class Connection_Facts
    {
        [Theory(Skip = "Calls API")]
        [InlineData("username", "password", "api.globaldatacompany.com")]
        public async void SayHello_Success(string username, string password, string hostEndPoint)
        {
            //Arrange
            using (var client = new TruliooApiClient(new Context(username, password) { Host = hostEndPoint }))
            {
                var response = await client.Connection.SayHelloAsync(username);
                Assert.Contains(username, response);
            }
        }

        [Theory(Skip = "Calls API")]
        [InlineData("username", "password", "api.globaldatacompany.com")]
        public async void Authentication_Success(string username, string password, string hostEndPoint)
        {
            //Arrange
            using (var client = new TruliooApiClient(new Context(username, password) { Host = hostEndPoint }))
            {
                var response = await client.Connection.TestAuthenticationAsync();
                Assert.Contains(username, response);
            }
        }
    }
}
