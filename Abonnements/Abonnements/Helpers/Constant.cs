using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Abonnements.Helpers
{
    public static class Constant
    {
        public const int SaltByteSize = 16;
        public const int HashByteSize = 20;
        public const int HashingIterationsCount = 1000;


        public static string BaseUrl = @"https://192.168.2.80:45456/api/";
        public const string ErrorUrl = @"errors";
        public const string ClientUrl = @"clients/";
        public const string MagazineUrl = @"magazines/";
        public const string Authenticate = @"authenticate/";
        public const string AbonnementUrl = @"abonnements/";
        public const string AbonnementClientUrl = @"client/{0}"; // /id.
        public const string NonAbonnementClientUrl = @"clientnonabo/{0}"; // /id

    }
}
