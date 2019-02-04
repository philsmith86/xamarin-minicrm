using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinMiniCrm.Models;

namespace XamarinMiniCrm.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeesAsync();
    }
}
