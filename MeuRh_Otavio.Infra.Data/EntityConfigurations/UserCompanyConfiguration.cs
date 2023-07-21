using MeuRh_Otavio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuRh_Otavio.Infra.Data.EntityConfigurations
{
    public class UserCompanyConfiguration : IEntityTypeConfiguration<UserCompany>
    {
        public void Configure(EntityTypeBuilder<UserCompany> builder)
        {
            builder.ToTable("UserCompany");

            builder.HasKey(uc => new { uc.UserId, uc.CompanyId });

            builder
                .HasKey(uc => new { uc.UserId, uc.CompanyId });

            builder
                .HasOne(uc => uc.User)
                .WithMany(u => u.Companies)
                .HasForeignKey(uc => uc.UserId);

            builder
                .HasOne(uc => uc.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(uc => uc.CompanyId);
        }
    }
}
