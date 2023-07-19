using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController
    {
        private readonly ICompanyService _CompanyService;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger, ICompanyService CompanyService)
        {
            _CompanyService = CompanyService;
            _logger = logger;
        }
        [HttpGet]
        [Route("GetAllCompanies")]
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var Companies = await _CompanyService.GetCompanies();

            return Companies;
        }
    }
}
