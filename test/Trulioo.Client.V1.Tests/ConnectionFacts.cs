using System.Net;
using System.Configuration;
using System.Collections.Generic;
using Xunit;

namespace Trulioo.Client.V1.Tests
{
    public class Connection_Facts
    {
        private readonly string _username = ConfigurationManager.AppSettings["username"];
        private readonly string _password = ConfigurationManager.AppSettings["password"];
        private readonly string _hostEndpoint = ConfigurationManager.AppSettings["host"];

        [Fact(Skip = "Calls API")]
        public async void SayHello_Success()
        {
            //Arrange
            using (var client = new TruliooApiClient(new Context(_username, _password) { Host = _hostEndpoint }))
            {
                var response = await client.Connection.SayHelloAsync(_username);
                Assert.Contains(_username, response);
            }
        }

        [Fact(Skip = "Calls API")]
        public async void Authentication_Success()
        {
            //Arrange
            using (var client = new TruliooApiClient(new Context(_username, _password) { Host = _hostEndpoint }))
            {
                var response = await client.Connection.TestAuthenticationAsync();
                Assert.Contains(_username, response);
            }
        }
    }
}
