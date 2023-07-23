using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebAPI.Services.Interfaces;
using WebAPI.Models.Entities;
using WebAPI.Data.DTOs;

namespace WebAPI.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly WebAPIDbContext _dataContext;
        private readonly IMapper _mapper;

        public CompanyService(WebAPIDbContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }


        public CompanyDTO CreateCompany(CompanyDTO Company)
        {
            Company newCompany = _mapper.Map<Company>(Company);

            if (_dataContext.Companies.FirstOrDefault(s => s.CompanyId == Company.CompanyId) == null)
            {
                _dataContext.Companies.Add(newCompany);
                _dataContext.SaveChanges();
            }
            return _mapper.Map<CompanyDTO>(newCompany);
        }

        public CompanyDTO UpdateCompany(CompanyDTO Company)
        {
            Company newCompany = _mapper.Map<Company>(Company);
            Company oldCompany = _dataContext.Companies.FirstOrDefault(s => s.CompanyId == newCompany.CompanyId);

            if (oldCompany != null)
            {
                _dataContext.Entry(oldCompany).CurrentValues.SetValues(newCompany);
                _dataContext.SaveChanges();
            }
            return _mapper.Map<CompanyDTO>(newCompany);
        }

        public async Task<bool> DeleteCompany(int CompanyId)
        {
            var CompanyEntity = await _dataContext.Companies.FindAsync(CompanyId);

            _dataContext.Companies.Remove(CompanyEntity);
            return await _dataContext.SaveChangesAsync() > 0; // saves if affected rows > 0
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _dataContext.Companies.ToListAsync();
        }
    }
}
