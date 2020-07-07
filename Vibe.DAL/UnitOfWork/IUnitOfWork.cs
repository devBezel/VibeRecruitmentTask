using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vibe.DAL.Repositories.IRepositories;

namespace Vibe.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository GenericRepository { get; set; }
        ICompanyRepository CompanyRepository { get; set; }
        Task Dispose();
    }
}
