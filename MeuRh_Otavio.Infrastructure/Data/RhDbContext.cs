using MeuRh_Otavio.Domain.Entities;
using MeuRh_Otavio.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MeuRh_Otavio.Infrastructure.Data
{
    public class RhDbContext : DbContext
    {
        public RhDbContext(DbContextOptions<RhDbContext> options) : base(options)
        {
            base.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());

            modelBuilder.ApplyConfiguration(new UserCompanyConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
