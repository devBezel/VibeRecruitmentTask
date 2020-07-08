using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vibe.DAL.Repositories.IRepositories;

namespace Vibe.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository GenericRepository { get; set; }
        ICompanyRepository CompanyRepository { get; set; }
        Task SaveChanges();
    }
}
