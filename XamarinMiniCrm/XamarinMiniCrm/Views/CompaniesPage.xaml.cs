using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMiniCrm.Models;
using XamarinMiniCrm.ViewModels;

namespace XamarinMiniCrm.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompaniesPage : ContentPage
	{
        CompaniesViewModel viewModel;

		public CompaniesPage ()
		{
			InitializeComponent ();
            viewModel = new CompaniesViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();          
            viewModel.LoadCompaniesCommand.Execute(null);
        }

        async void OnCompanySelected(object sender, SelectedItemChangedEventArgs args)
        {
            var company = args.SelectedItem as Company;
            if (company == null)
                return;

            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            //ItemsListView.SelectedItem = null;
        }
    }
}