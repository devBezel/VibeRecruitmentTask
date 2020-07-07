using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vibe.DAL.Database
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        private readonly string _connString;
        public DatabaseContext Create() => this.CreateDbContext(new[] { "" });
        public DatabaseContextFactory() : this("Server=localhost;Database=vibe;User=root;Password=; convert zero datetime=True") { }


        public DatabaseContextFactory(string connString)
        {
            _connString = connString;
        }

        public DatabaseContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder <DatabaseContext> opt = new DbContextOptionsBuilder<DatabaseContext>();

            opt.UseMySql(_connString);

            return new DatabaseContext(opt.Options);
        }
    }
}
