using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Vibe.DAL.Repositories.IRepositories
{
    public interface IGenericRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveAll();
    }
}
