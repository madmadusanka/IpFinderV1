using IpFinder.Models;
using IpFinder.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ApiAccessService))]
namespace IpFinder.Services
{
    public class ApiAccessService
    {
        public ApiAccessService()
        {
            httpConection = DependencyService.Get<HttpConection>();
        }

        private HttpConection httpConection;

        public async Task<IpAddressResponse> GetIpDetail(string ipAddress)
        {
            IpAddressResponse response = null;
            response = await httpConection.GetAsync<IpAddressResponse>("http://ip-api.com/json/"+ipAddress);
            return response;
        }
   
    }
}
