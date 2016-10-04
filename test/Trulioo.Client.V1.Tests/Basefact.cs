using System.Configuration;
using System.Net;

namespace Trulioo.Client.V1.Tests
{
    public abstract class Basefact
    {
        protected const string IdentityVerificationConfigurationName = "Identity Verification";

        static Basefact()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
#if DEBUG
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
#endif
        }

        protected TruliooApiClient GetTruliooClient()
        {
            var username = ConfigurationManager.AppSettings["username"];
            var password = ConfigurationManager.AppSettings["password"];

            Context context = new Context(username, password);
            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["host"]))
            {
                context.Host = ConfigurationManager.AppSettings["host"];
            }

            return new TruliooApiClient(context);
        }
    }
}
