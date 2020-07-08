using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibe.BLL.Dto;
using Vibe.BLL.Services.IService;
using Vibe.DAL.Database.Models;
using Vibe.DAL.UnitOfWork;

namespace Vibe.BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CompanyDto> CreateCompany(CompanyDto companyDto)
        {
            CompanyModel company = _mapper.Map<CompanyModel>(companyDto);

            _unitOfWork.GenericRepository.Add(company);
            await _unitOfWork.SaveChanges();

            companyDto.Id = company.Id;
            return companyDto;
        }

        public async Task<CompanyDto> UpdateCompany(int id, CompanyDto companyDto)
        {
            CompanyModel company = await _unitOfWork.CompanyRepository.FindByIdAsync(id);
            if (company == null)
                return null;

            _mapper.Map(companyDto, company);
            await _unitOfWork.SaveChanges();

            return companyDto;

        }

        public async Task<bool> DeleteCompany(int id)
        {
            CompanyModel company = await _unitOfWork.CompanyRepository.FindByIdAsync(id);
            if (company == null)
                return false;

            _unitOfWork.GenericRepository.Delete(company);
            await _unitOfWork.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<CompanyDto>> SearchCompanies(SearchDto searchDto)
        {
            string searchingKeyword = searchDto.Keyword == string.Empty ? null : searchDto.Keyword;
            IEnumerable<CompanyModel> companies = await _unitOfWork.CompanyRepository.JoinAndGetAllAsync(x => x.Name.Contains(searchingKeyword) ||
                                                                                                  x.Employees.Any(y => y.Salary >= searchDto.EmployeeSalaryFrom &&
                                                                                                  y.Salary <= searchDto.EmployeeSalaryTo));
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);

        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
