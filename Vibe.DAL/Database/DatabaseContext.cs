using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vibe.DAL.Database.Models;

namespace Vibe.DAL.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


        public DbSet<CompanyModel> Companies { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }

    }
}
