using Abonnements.Helpers.Interface;
using Abonnements.Services.Interfaces;
using Abonnements.ViewModel.Base;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abonnements.ViewModel
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;
        protected readonly IErrorLogger ErrorLogger;
        protected readonly IDeserializer Serializer;

        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public ViewModelBase()
        {
            DialogService = ViewModelLocator.Instance.Resolve<IDialogService>();
            NavigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
            ErrorLogger = ViewModelLocator.Instance.Resolve<IErrorLogger>();
            Serializer = ViewModelLocator.Instance.Resolve<IDeserializer>();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
