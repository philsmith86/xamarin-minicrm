using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinMiniCrm.Interfaces;
using XamarinMiniCrm.Models;

namespace XamarinMiniCrm.Services
{
    class CompanyService : ICompanyService
    {
        const string serviceUrl = "https://webservice20190204092207.azurewebsites.net/api/companies";
        HttpClient client;

        public CompanyService()
        {
            client = new System.Net.Http.HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            var uri = new Uri(serviceUrl);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Company>>(content);
            }
            return new List<Company>();
        }
    }
}
