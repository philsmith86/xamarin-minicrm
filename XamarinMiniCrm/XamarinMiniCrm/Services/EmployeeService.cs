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
    public class EmployeeService : IEmployeeService
    {
        //Ref: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/consuming/rest

        const string serviceUrl = "https://webservice20190204092207.azurewebsites.net/api/employees";
        HttpClient client;

        public EmployeeService()
        {
            client = new System.Net.Http.HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var uri = new Uri(serviceUrl);  
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Employee>>(content);
            }
            return new List<Employee>();
        }
    }
}
