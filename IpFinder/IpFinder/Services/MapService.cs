using IpFinder.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(MapService))]
namespace IpFinder.Services
{
    public class MapService
    {

        public async Task OpenMap(Double lon, Double lat,string name)
        {
            var location = new Location(lat, lon);
            var options = new MapLaunchOptions { Name = name};

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

