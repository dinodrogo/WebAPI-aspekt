using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.DTOs;
using WebAPI.Models.Entities;

namespace WebAPI.Services.Interfaces
{
    public interface ICompanyService
    {
        CompanyDTO CreateCompany(CompanyDTO Company);
        CompanyDTO UpdateCompany(CompanyDTO Company);
        Task<bool> DeleteCompany(int id);
        Task<IEnumerable<Company>> GetCompanies();
    }
}
