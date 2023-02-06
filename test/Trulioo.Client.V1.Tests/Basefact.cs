using System;
using Trulioo.Client.V1.Model;

namespace Trulioo.Client.V1.Tests.Common
{
    using Microsoft.Extensions.Configuration;
    using System.IO;
    using System.Net;

    public static class Basefact
    {
        private static readonly string _password;
        private static readonly string _kyb_UserName;
        private static readonly string _kyb_Password;

        public static readonly string _host;


        static Basefact()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddUserSecrets("b1e68995-257c-4e64-adb7-6d0a22b9c819").Build();

            UserName = config["UserName"];
            TransactionRecordId = config["TransactionRecordId"];
            TransactionResult = config["Json_TransactionResult"];

            TransactionId = config["TransactionId"];
            TransactionStatus = config["Json_TransactionStatus"];

            TestEntities = config["Json_TestEntities"];

            CountryCode = config["CountryCode"];
            DocumentTypeList = config["DocumentTypeList"];
            DatasourcesTestList = config["DatasourcesTestList"];
            ConsentsList = config["ConsentsList"];

            _password = config["Password"];
            _kyb_UserName = config["KYB_UserName"];
            _kyb_Password = config["KYB_Password"];

            _host = config["Host"];
        }

        public static TruliooApiClient GetTruliooClient()
        {
            var context = new Context(UserName, _password)
            {
                Host = _host
            };
            return new TruliooApiClient(context);
        }

        public static TruliooApiClient GetTruliooKYBClient()
        {
            var context = new Context(_kyb_UserName, _kyb_Password)
            {
                Host = _host
            };
            return new TruliooApiClient(context);
        }

        public static TransactionStatus GetTransactionStatus()
        {
            return new TransactionStatus
            {
                TransactionId = TransactionId,
                TransactionRecordId = TransactionRecordId,
                Status = TransactionStatus,
                UploadedDt = DateTime.Now,
                IsTimedOut = false,
            };
        }

        public static string UserName { get; private set; }
        public static string CountryCode { get; private set; }
        public static string TransactionRecordId { get; private set; }
        public static string TransactionResult { get; private set; }
        public static string TransactionId { get; private set; }
        public static string TransactionStatus { get; private set; }
        public static string TestEntities { get; private set; }

        public static string DocumentTypeList { get; private set; }
        public static string DatasourcesTestList { get; private set; }
        public static string ConsentsList { get; private set; }
    }
}
