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
    public class CountryService : ICountryService
    {
        private readonly WebAPIDbContext _dataContext;
        private readonly IMapper _mapper;

        public CountryService(WebAPIDbContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }


        public CountryDTO CreateCountry(CountryDTO Country)
        {
            Country newCountry = _mapper.Map<Country>(Country);

            if (_dataContext.Countries
                .FirstOrDefault(s => s.CountryId == Country.CountryId) == null)
            {
                _dataContext.Countries.Add(newCountry);
                _dataContext.SaveChanges();
            }
            return _mapper.Map<CountryDTO>(newCountry);
        }

        public CountryDTO UpdateCountry(CountryDTO Country)
        {
            Country newCountry = _mapper.Map<Country>(Country);
            Country oldCountry = _dataContext.Countries.FirstOrDefault(s => s.CountryId == newCountry.CountryId);

            if (oldCountry != null)
            {
                _dataContext.Entry(oldCountry).CurrentValues.SetValues(newCountry);
                _dataContext.SaveChanges();
            }
            return _mapper.Map<CountryDTO>(newCountry);
        }

        public async Task<bool> DeleteCountry(int CountryId)
        {
            var CountryEntity = await _dataContext.Countries.FindAsync(CountryId);

            _dataContext.Countries.Remove(CountryEntity);
            return await _dataContext.SaveChangesAsync() > 0; // saves if affected rows > 0
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _dataContext.Countries.ToListAsync();
        }
    }
}
