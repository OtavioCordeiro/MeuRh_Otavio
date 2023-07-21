using MeuRh_Otavio.Domain.Entities;
using MeuRh_Otavio.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace MeuRh_Otavio.Infra.Data.Contexts
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
