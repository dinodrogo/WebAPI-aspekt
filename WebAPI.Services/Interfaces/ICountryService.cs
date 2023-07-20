using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.DTOs;
using WebAPI.Models.Entities;

namespace WebAPI.Services.Interfaces
{
    public interface ICountryService
    {
        CountryDTO CreateCountry(CountryDTO Country);
        CountryDTO UpdateCountry(CountryDTO Country);
        Task<bool> DeleteCountry(int id);
        Task<IEnumerable<Country>> GetCountries();
    }
}
