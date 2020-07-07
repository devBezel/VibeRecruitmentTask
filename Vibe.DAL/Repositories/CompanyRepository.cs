using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vibe.DAL.Database;
using Vibe.DAL.Database.Models;
using Vibe.DAL.Repositories.IRepositories;

namespace Vibe.DAL.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DatabaseContext _context;
        public CompanyRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<CompanyModel> FindByIdAsync(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<CompanyModel>> JoinAndGetAllAsync(Expression<Func<CompanyModel, bool>> expression)
        {
            IQueryable<CompanyModel> companies = expression != null ?
                _context.Companies.Where(expression) :
                _context.Companies;

            return await companies.Include(company => company.Employees).ToArrayAsync();
        }
    }
}
