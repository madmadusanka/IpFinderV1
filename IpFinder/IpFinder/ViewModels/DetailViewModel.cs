using IpFinder.Models;
using IpFinder.Services;
using IpFinder.ViewModels;
using IpFinder.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

[assembly: Dependency(typeof(DetailViewModel))]
namespace IpFinder.ViewModels 
{ 
    public class DetailViewModel : BaseViewModel
    {
        public DetailViewModel()
        {
            _apiAccessService = DependencyService.Get<ApiAccessService>();
            _mapService = DependencyService.Get<MapService>();
        }

        #region Service
        private ApiAccessService _apiAccessService;

        private MapService _mapService;
        #endregion

        #region Properties
        private bool _isBusy;
        public bool IsBusy { get => _isBusy; set => SetProperty(ref _isBusy, value); }

        private string _searchKey;
        public string SearchKey { get => _searchKey; set => SetProperty(ref _searchKey, value); }

        private string _country;
        public string Country{get => _country;set => SetProperty(ref _country, value); }

        private string _countryCode;
        public string CountryCode { get => _countryCode; set => SetProperty(ref _countryCode, value); }

        private string _region;
        public string Region { get => _region; set => SetProperty(ref _region, value); }

        private string _city;
        public string City { get => _city; set => SetProperty(ref _city, value); }

        private string _zip;
        public string Zip { get => _zip; set => SetProperty(ref _zip, value); }

        private double _lat;
        public double Lat { get => _lat; set => SetProperty(ref _lat, value); }

        private double _lon;
        public double Lon { get => _lon; set => SetProperty(ref _lon, value); }

        private string _timeZone;
        public string TimeZone { get => _timeZone; set => SetProperty(ref _timeZone, value); }

        private string _isp;
        public string ISP { get => _isp; set => SetProperty(ref _isp, value); }

        private string _org;
        public string Org { get => _org; set => SetProperty(ref _org, value); }

        private string _as;
        public string As { get => _as; set => SetProperty(ref _as, value); }

        private string _ip;
        public string Ip { get => _ip; set => SetProperty(ref _ip, value); }


        #endregion

        private ICommand _navigateCommand = null;
        public ICommand SearchCommand => _navigateCommand = _navigateCommand ?? new Command(async () => await DoSeachCommand());
        
        private ICommand _openMapCommand = null;
        public ICommand OpenMapCommand => _openMapCommand = _openMapCommand ?? new Command(async () => await OpenMap());

        #region Methods

        private async Task OpenMap()
        {
            _mapService.OpenMap(_lon,_lat,_ip);
        }
        private async Task DoSeachCommand()
        {
            GetIpDetail();
        }
        private async Task GetIpDetail()
        {
            IsBusy = true;
            IpAddressResponse response = null;
            try
            {
                response = await _apiAccessService.GetIpDetail(_searchKey);
                if (response.Status == "success")
                {
                    Ip = response.Query;
                    Country = response.Country;
                    Region = response.Region;
                    City = response.City;
                    Zip = response.Zip;
                    Lat = response.Lat;
                    Lon = response.Lon;
                    TimeZone = response.Timezone;
                    ISP = response.Isp;
                    Org = response.Org;
                    As = response.As;


                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Alert!", response.Status, "OK");
                    Page page = Activator.CreateInstance(typeof(HomeView)) as Page;
                    HomeViewModel homeViewModel = DependencyService.Get<HomeViewModel>(DependencyFetchTarget.NewInstance);
                    page.BindingContext = homeViewModel;
                    Application.Current.MainPage = page;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);  
            }
            IsBusy = false;

        }
        public async Task InitialWith(Object parameter)
        {
            _searchKey = (string)parameter;
            await GetIpDetail();
        }
        #endregion
    }
}
