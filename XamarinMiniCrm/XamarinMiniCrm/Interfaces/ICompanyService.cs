using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinMiniCrm.Models;

namespace XamarinMiniCrm.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetCompaniesAsync();
    }
}
