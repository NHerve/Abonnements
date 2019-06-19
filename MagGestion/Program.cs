using MagGestion.DataServices;
using MagGestion.DataServices.Deserializer;
using MagGestion.DataServices.Interface;
using MagGestion.Forms;
using MagGestion.Forms.Interface;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using SimpleInjector;
using System;
using System.Windows.Forms;

namespace MagGestion
{
    internal static class Program
    {
        private static Container container;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            DependecyInjection();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            container.GetInstance<LoginForm>().Show();
            Application.Run();
        }

        private static void DependecyInjection()
        {
            container = new Container();
            container.Register<ICacheService, InMemoryCache>();
            container.Register<IErrorLogger, ErrorLogger>();
            container.Register<IDeserializer, JsonSerializer>();
            container.Register<ISerializer, JsonSerializer>();
            container.Register<ClientDataService>();
            container.Register<ErrorDataService>();
            container.Register<EmployeDataService>();
            container.Register<MagazineDataService>();
        
            container.RegisterSingleton<IFormOpener, FormOpener>();

            container.Verify();
        }
    }
}
