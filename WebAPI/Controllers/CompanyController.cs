using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebAPI.Data.DTOs;
using WebAPI.Models.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _CompanyService;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger, ICompanyService CompanyService)
        {
            _CompanyService = CompanyService;
            _logger = logger;
        }


        [HttpPost("AddCompany")]
        public IActionResult Post([FromBody] CompanyDTO Company) //if the given id isn't 0 (auto increment) or it hasn't been used yet this won't do anything since its a POST request
        {
            if (ModelState.IsValid)
            {
                var newCompany = _CompanyService.CreateCompany(Company);
                return Created($"Company with id {newCompany.CompanyId} is created", newCompany.CompanyId);
            }
            return UnprocessableEntity(ModelState);
        }


        [HttpGet]
        [Route("GetAllCompanies")]
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var Companies = await _CompanyService.GetCompanies();

            return Companies;
        }

        [HttpDelete("RemoveCompany/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _CompanyService.DeleteCompany(id));
            }
            return BadRequest();
        }

        [HttpPut("UpdateCompany/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] CompanyDTO Company)
        {
            if (ModelState.IsValid)
            {
                Company.CompanyId = id;
                var result = _CompanyService.UpdateCompany(Company);

                return result != null
                    ? Ok(result)
                    : NoContent();
            }
            return BadRequest();
        }
    }
}
