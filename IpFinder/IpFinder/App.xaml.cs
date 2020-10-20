using IpFinder.ViewModels;
using IpFinder.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IpFinder
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           
            Page page=Activator.CreateInstance(typeof(HomeView)) as Page;
            page.BindingContext = new HomeViewModel();
            MainPage = page;
            
        }

       
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
