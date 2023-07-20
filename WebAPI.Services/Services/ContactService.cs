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
    public class ContactService : IContactService
    {
        private readonly WebAPIDbContext _dataContext;
        private readonly IMapper _mapper;

        public ContactService(WebAPIDbContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }


        public ContactDTO CreateContact(ContactDTO Contact)
        {
            Contact newContact = _mapper.Map<Contact>(Contact);

            if (_dataContext.Contacts.FirstOrDefault(s => s.ContactId == Contact.ContactId) == null)
            {
                if(newContact.CompanyId == 0) {
                    newContact.CompanyId = null;
                }

                if(newContact.CountryId ==0)
                {
                    newContact.CountryId = null;
                }

                _dataContext.Contacts.Add(newContact);
                _dataContext.SaveChanges();
            }
            return _mapper.Map<ContactDTO>(newContact);
        }

        public ContactDTO UpdateContact(ContactDTO Contact)
        {
            Contact newContact = _mapper.Map<Contact>(Contact);
            Contact oldContact = _dataContext.Contacts.FirstOrDefault(s => s.ContactId == newContact.ContactId);

            if (oldContact != null)
            {
                _dataContext.Entry(oldContact).CurrentValues.SetValues(newContact);
                _dataContext.SaveChanges();
            }
            return _mapper.Map<ContactDTO>(newContact);
        }

        public async Task<bool> DeleteContact(int ContactId)
        {
            var ContactEntity = await _dataContext.Contacts.FindAsync(ContactId);

            _dataContext.Contacts.Remove(ContactEntity);
            return await SaveAsync() > 0;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _dataContext.Contacts.ToListAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Contact>> GetContactsWithCompanyAndCountry()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> FilterContact()
        {
            throw new NotImplementedException();
        }
    }
}
