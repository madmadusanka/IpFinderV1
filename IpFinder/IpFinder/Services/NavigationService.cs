using IpFinder.Services;
using IpFinder.ViewModels;
using IpFinder.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(NavigationService))]
namespace IpFinder.Services
{
    public class NavigationService
    {
        public bool NavigateBack()
        {
            
            Page page = Activator.CreateInstance(typeof(HomeView)) as Page;
            HomeViewModel homeViewModel = DependencyService.Get<HomeViewModel>(DependencyFetchTarget.NewInstance);
            page.BindingContext = homeViewModel;
            if(Application.Current.MainPage.ToString() == "IpFinder.Views.HomeView")
            {
                return false;    
            }
            else 
            {
                Application.Current.MainPage = page;
                return true;
            }
        }
    }
}
