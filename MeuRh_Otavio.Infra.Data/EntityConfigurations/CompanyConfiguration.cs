using MeuRh_Otavio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuRh_Otavio.Infra.Data.EntityConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.CNPJ).IsRequired();

            builder.OwnsOne(c => c.Administrator, admin =>
            {
                admin.Property(a => a.Name).IsRequired();
                admin.Property(a => a.Phone).IsRequired();
                admin.Property(a => a.Email).IsRequired();
            });
        }
    }
}
