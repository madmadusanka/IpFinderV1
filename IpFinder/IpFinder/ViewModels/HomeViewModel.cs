using IpFinder.ViewModels;
using IpFinder.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

[assembly: Dependency(typeof(HomeViewModel))]
namespace IpFinder.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private string _ipAddrress;
        public string IpAddrress
        {
            get { return _ipAddrress; }
            set { SetProperty(ref _ipAddrress, value); }
        }

        private ICommand _navigateCommand = null;
        public ICommand NavigateCommand => _navigateCommand = _navigateCommand ?? new Command(async () => await navigateCommand());

        private ICommand _myIpNavigateCommand = null;
        public ICommand MyIpNavigateCommand => _myIpNavigateCommand = _myIpNavigateCommand ?? new Command(async () => await DoMyIpNavigate());

        private async Task DoMyIpNavigate()
        {
            Page page = Activator.CreateInstance(typeof(DetailView)) as Page;
            DetailViewModel detailViewModel = DependencyService.Get<DetailViewModel>(DependencyFetchTarget.NewInstance);
            page.BindingContext = detailViewModel;
            Application.Current.MainPage = page;
            detailViewModel.InitialWith(_ipAddrress);

        }

        private async Task navigateCommand()
        {
            if (string.IsNullOrEmpty(_ipAddrress))
            {
                await Application.Current.MainPage.DisplayAlert("Alert!", "Please enter a valid ip address.", "Ok");
            }
            else
            {
                Page page = Activator.CreateInstance(typeof(DetailView)) as Page;
                DetailViewModel detailViewModel = DependencyService.Get<DetailViewModel>(DependencyFetchTarget.NewInstance);
                page.BindingContext = detailViewModel;
                Application.Current.MainPage = page;

                detailViewModel.InitialWith(_ipAddrress);
            }
        }

    }
}
