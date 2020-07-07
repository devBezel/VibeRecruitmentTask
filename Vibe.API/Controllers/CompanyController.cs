using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vibe.BLL.Dto;
using Vibe.BLL.Services.IService;
using Vibe.DAL.Database.Models;


namespace Vibe.API.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]CompanyDto company)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            CompanyDto companyAdded = await _companyService.CreateCompany(company);
            return Ok(new CompanyCreatedResult() { Id = companyAdded.Id });
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody]SearchDto searchDto) => Ok(new CompanySearchResult() { Results = await _companyService.SearchCompanies(searchDto) });


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute]int id, [FromBody]CompanyDto company)
        {
            if (await _companyService.UpdateCompany(id, company) == null)
                return NotFound(id);
            return Ok(company);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id)
        {
            if (!await _companyService.DeleteCompany(id))
                return NotFound(id);

            return Ok();
        }
    }

    public class CompanyCreatedResult
    {
        public int Id { get; set; }
    }

    public class CompanySearchResult
    {
        public IEnumerable<CompanyDto> Results { get; set; }
    }
}
