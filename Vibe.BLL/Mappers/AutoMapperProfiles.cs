using AutoMapper;
using AutoMapper.EquivalencyExpression;
using System;
using System.Collections.Generic;
using System.Text;
using Vibe.BLL.Dto;
using Vibe.DAL.Database.Models;

namespace Vibe.BLL.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CompanyDto, CompanyModel>();
            CreateMap<CompanyModel, CompanyDto>();
            CreateMap<EmployeeDto, EmployeeModel>();
            CreateMap<EmployeeModel, EmployeeDto>();
            CreateMap<CompanyDto, CompanyModel>()
                .ForMember(x => x.Id, y => y.Ignore());

        }
    }
}
