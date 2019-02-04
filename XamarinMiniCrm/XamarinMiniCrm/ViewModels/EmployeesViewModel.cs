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
    class EmployeesViewModel : BaseViewModel
    {
        readonly IEmployeeService employeeService;

        public ObservableCollection<Employee> Employees { get; set; }
        public Command LoadEmployeesCommand { get; set; }

        public EmployeesViewModel()
        {
            Title = "Employees";
            employeeService = new EmployeeService();
            Employees = new ObservableCollection<Employee>();
            LoadEmployeesCommand = new Command(async () => await LoadEmployees());
        }

        async Task LoadEmployees()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Employees.Clear();
                var employeeList = (await employeeService.GetEmployeesAsync());
                
                foreach (var employee in employeeList)
                {
                    employee.FullName = employee.FirstName + " " + employee.LastName;
                    Employees.Add(employee);
                    Debug.WriteLine(employee);
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
