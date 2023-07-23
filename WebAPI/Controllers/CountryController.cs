using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebAPI.Data.DTOs;
using WebAPI.Models.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _CountryService;

        public CountryController(ILogger<CountryController> logger, ICountryService CountryService)
        {
            _CountryService = CountryService;
        }


        [HttpPost("AddCountry")]
        public IActionResult Post([FromBody] CountryDTO Country) //if the given id isn't 0 (auto increment) or it hasn't been used yet this won't do anything since its a POST request
        {
            if (ModelState.IsValid)
            {
                var newCountry = _CountryService.CreateCountry(Country);
                return Created($"Country with id {newCountry.CountryId} is created", newCountry.CountryId);
            }
            return UnprocessableEntity(ModelState);
        }


        [HttpGet]
        [Route("GetAllCountries")]
        public async Task<IEnumerable<Country>> GetCountries()
        {
            var Countries = await _CountryService.GetCountries();

            return Countries;
        }   

        [HttpDelete("RemoveCountry/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _CountryService.DeleteCountry(id));
            }
            return BadRequest();
        }

        [HttpPut("UpdateCountry/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] CountryDTO Country)
        {
            if (ModelState.IsValid)
            {
                Country.CountryId = id;
                var result = _CountryService.UpdateCountry(Country);

                return result != null
                    ? Ok(result)
                    : NoContent();
            }
            return BadRequest();
        }
    }
}
