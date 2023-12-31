﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebAPI.Data.DTOs;
using WebAPI.Models.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactController(ILogger<ContactController> logger, IContactService ContactService)
        {
            _ContactService = ContactService;
        }


        [HttpPost("AddContact")]
        public IActionResult Post([FromBody] ContactDTO Contact) //if the given id isn't 0 (auto increment) or it hasn't been used yet this won't do anything since its a POST request
        {
            if (ModelState.IsValid)
            {
                var newContact = _ContactService.CreateContact(Contact);
                return Created($"Contact with id {newContact.ContactId} is created", newContact.ContactId);
            }
            return UnprocessableEntity(ModelState);
        }


        [HttpGet]
        [Route("GetAllContacts")]
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var Contacts = await _ContactService.GetContacts();

            return Contacts;
        }   

        [HttpDelete("RemoveContact/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _ContactService.DeleteContact(id));
            }
            return BadRequest();
        }

        [HttpPut("UpdateContact/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] ContactDTO Contact)
        {
            if (ModelState.IsValid)
            {
                Contact.ContactId = id;
                var result = _ContactService.UpdateContact(Contact);

                return result != null
                    ? Ok(result)
                    : NoContent();
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetAllContactsWithCompanyAndCountry")]
        public async Task<IEnumerable<Contact>> GetContactsWithCompanyAndCountry()
        {
            var Contacts = await _ContactService.GetContactsWithCompanyAndCountry();

            return Contacts;
        }

        [HttpGet]
        [Route("GetAllFilteredContacts/{companyId:int}/{countryId:int}")]
        public async Task<IEnumerable<Contact>> FilterContact([FromRoute] int companyId = 0, [FromRoute] int countryId = 0) 
        {
            var Contacts = await _ContactService.FilterContact(companyId, countryId);

            return Contacts;
        }
    }
}
