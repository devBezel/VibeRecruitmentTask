using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vibe.DAL.Database;
using Vibe.DAL.Repositories;
using Vibe.DAL.Repositories.IRepositories;

namespace Vibe.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            GenericRepository = new GenericRepository(_context);
            CompanyRepository = new CompanyRepository(_context);
        }

        public IGenericRepository GenericRepository { get; set; }
        public ICompanyRepository CompanyRepository { get; set; }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
