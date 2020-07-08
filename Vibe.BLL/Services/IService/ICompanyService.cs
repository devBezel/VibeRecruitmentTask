using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vibe.BLL.Dto;
using Vibe.DAL.Database.Models;

namespace Vibe.BLL.Services.IService
{
    public interface ICompanyService : IDisposable
    {
        Task<CompanyDto> CreateCompany(CompanyDto company);
        Task<CompanyDto> UpdateCompany(int id, CompanyDto companyDto);
        Task<IEnumerable<CompanyDto>> SearchCompanies(SearchDto searchDto);
        Task<bool> DeleteCompany(int id);
    }
}
