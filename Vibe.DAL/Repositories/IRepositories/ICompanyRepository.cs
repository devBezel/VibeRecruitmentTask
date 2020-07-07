using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vibe.DAL.Database.Models;

namespace Vibe.DAL.Repositories.IRepositories
{
    public interface ICompanyRepository
    {
        Task<CompanyModel> FindByIdAsync(int id);
        Task<IEnumerable<CompanyModel>> JoinAndGetAllAsync(Expression<Func<CompanyModel, bool>> expression);
    }
}
