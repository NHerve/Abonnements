using Abonnements.DataServices;
using Abonnements.DataServices.Base;
using Abonnements.DataServices.Interface;
using Abonnements.Services;
using Abonnements.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Lifetime;

namespace Abonnements.ViewModel.Base
{
    public class ViewModelLocator
    {
        private readonly IUnityContainer _unityContainer;

        private static readonly ViewModelLocator _instance = new ViewModelLocator();

        public static ViewModelLocator Instance
        {
            get
            {
                return _instance;
            }
        }

        protected ViewModelLocator()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.AddExtension(new Diagnostic());

            // Providers
            _unityContainer.RegisterType<IRequestProvider, RequestProvider>();


            // Services
            _unityContainer.RegisterType<IDialogService, DialogService>();
            RegisterSingleton<INavigationService, NavigationService>();


            //DataServices
            _unityContainer.RegisterType<IAuthenticationService, AuthenticationService>();


            // View models
            _unityContainer.RegisterType<LoginViewModel>();
            _unityContainer.RegisterType<AccountViewModel>();

            _unityContainer.RegisterType<AbonnementsViewModel>();
            _unityContainer.RegisterType<MagazineViewModel>();
            _unityContainer.RegisterType<ButtonSubscribedMagazineViewModel>();
            _unityContainer.RegisterType<ButtonSubscribeMagazineViewModel>();

            _unityContainer.RegisterType<MainViewModel>();

        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _unityContainer.Resolve(type);
        }

        public void Register<T>(T instance)
        {
            _unityContainer.RegisterInstance<T>(instance);
        }

        public void Register<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>();
        }

        public void RegisterSingleton<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>(new ContainerControlledLifetimeManager());
        }
    }
}
