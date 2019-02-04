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
	public partial class EmployeesPage : ContentPage
	{
        EmployeesViewModel viewModel;

        public EmployeesPage()
        {
            InitializeComponent();
            viewModel = new EmployeesViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadEmployeesCommand.Execute(null);
        }

        async void OnEmployeeSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var employee = args.SelectedItem as Employee;
            if (employee == null)
                return;

            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            //ItemsListView.SelectedItem = null;
        }
    }
}