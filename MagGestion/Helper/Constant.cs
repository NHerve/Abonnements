namespace MagGestion.Helper
{
    public static class Constant
    {
        public static bool isAuth { get; set; } = false;

        public static bool isEnabled { get; set; } = true;

        public const int SaltByteSize = 16;
        public const int HashByteSize = 20;
        public const int HashingIterationsCount = 1000;


        public static string BaseUrl = @"https://192.168.2.80:45456/api/";

        public static string ClientUrl = @"Clients/";

        public static string ErrorUrl = @"Logs/";

        public static string EmployerUrl = @"Employers/";

        public static string LoginUrl = @"Login";

        public static string MagazineUrl = @"magazines";

        public static string HistoriqueUrl = @"historiques";



    }
}
