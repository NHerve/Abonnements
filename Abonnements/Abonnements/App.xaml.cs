using Abonnements.Model;
using Abonnements.Services.Interfaces;
using Abonnements.ViewModel.Base;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Abonnements
{
    public partial class App : Application
    {
        public App()
        { 
                InitializeComponent();
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            await InitNavigation();
        
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override async void OnResume()
        {
            // Handle when your app resumes
            await InitNavigation();
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }
    
    }
}
