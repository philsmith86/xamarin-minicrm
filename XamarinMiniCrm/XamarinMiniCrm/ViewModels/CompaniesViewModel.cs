using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMiniCrm.Interfaces;
using XamarinMiniCrm.Models;
using XamarinMiniCrm.Services;

namespace XamarinMiniCrm.ViewModels
{
    class CompaniesViewModel : BaseViewModel
    {
        readonly ICompanyService companyService;

        public ObservableCollection<Company> Companies { get; set; }
        public Command LoadCompaniesCommand { get; set; }

        public CompaniesViewModel()
        {
            Title = "Companies";
            companyService = new CompanyService();
            Companies = new ObservableCollection<Company>();
            LoadCompaniesCommand = new Command(async () => await LoadCompanies());
        }

        async Task LoadCompanies()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Companies.Clear();
                var companyList = (await companyService.GetCompaniesAsync());

                foreach (var company in companyList)
                {
                    Companies.Add(company);
                    Debug.WriteLine(company);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
