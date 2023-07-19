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
        CompanyDTO CreateCompany(CompanyDTO Player);
        CompanyDTO UpdateCompany(CompanyDTO Player);
        Task<bool> DeleteCompany(int id);
        Task<IEnumerable<Company>> GetCompanies();
    }
}
