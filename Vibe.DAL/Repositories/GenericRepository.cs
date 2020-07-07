using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vibe.DAL.Database;
using Vibe.DAL.Repositories.IRepositories;

namespace Vibe.DAL.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly DatabaseContext _context;
        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
