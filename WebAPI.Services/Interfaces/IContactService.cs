using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.DTOs;
using WebAPI.Models.Entities;

namespace WebAPI.Services.Interfaces
{
    public interface IContactService
    {
        ContactDTO CreateContact(ContactDTO Contact);
        ContactDTO UpdateContact(ContactDTO Contact);
        Task<bool> DeleteContact(int id);
        Task<IEnumerable<Contact>> GetContacts();
        Task<IEnumerable<Contact>> GetContactsWithCompanyAndCountry();
        Task<IEnumerable<Contact>> FilterContact(int countryId, int companyId);

    }
}
