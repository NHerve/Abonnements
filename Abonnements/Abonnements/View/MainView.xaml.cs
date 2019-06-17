using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Abonnements.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : TabbedPage
    {
        public MainView ()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            this.CurrentPage = this.Children[1];
        }
    }
}