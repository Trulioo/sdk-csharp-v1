namespace Trulioo.Client.V1.Tests
{
    using Xunit;

    public class Connection_Facts
    {

        [Fact(Skip = "Calls API")]
        public async void SayHello_Success()
        {
            //Arrange
            using (var client = Common.Basefact.GetTruliooClient())
            {
                var response = await client.Connection.SayHelloAsync(Common.Basefact.UserName);
                Assert.Contains(Common.Basefact.UserName, response);
            }
        }

        [Fact(Skip = "Calls API")]
        public async void Authentication_Success()
        {
            //Arrange
            using (var client = Common.Basefact.GetTruliooClient())
            {
                var response = await client.Connection.TestAuthenticationAsync();
                Assert.Contains(Common.Basefact.UserName, response);
            }
        }
    }
}
