using MagGestion.Model.Employe;

namespace MagGestion.Helper
{
    public static class Constant
    {

        public static Employe CurrentEmploye { get; set; }
        public static bool isAuth { get; set; } = false;

        public static bool isEnabled { get; set; } = true;

        public const int SaltByteSize = 16;
        public const int HashByteSize = 20;
        public const int HashingIterationsCount = 1000;


        //public static string BaseUrl = @"https://192.168.2.80:45456/api/";

        public static string BaseUrl = @"http://54.209.117.31/api/";

        public static string ClientsUrl = @"Clients/";

        public static string ClientUrl = @"client/";

        public static string ErrorUrl = @"Logs/";

        public static string EmployersUrl = @"Employers/";

        public static string EmployerUrl = @"employer/";

        public static string LoginUrl = @"Authenticate";

        public static string MagazineUrl = @"magazines/";

        public static string AbonnementUrl = @"abonnements/";


        public static string HistoriqueUrl = @"historiques/";



    }
}
