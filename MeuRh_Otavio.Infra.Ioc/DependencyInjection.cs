using MeuRh_Otavio.Application.Handlers;
using MeuRh_Otavio.Application.Interfaces;
using MeuRh_Otavio.Application.Mappings;
using MeuRh_Otavio.Application.Services;
using MeuRh_Otavio.Domain.Interfaces;
using MeuRh_Otavio.Infra.Data.Contexts;
using MeuRh_Otavio.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace MeuRh_Otavio.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrasctructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RhDbContext>(options => options.UseInMemoryDatabase("RhDb"));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<ICepService, CepService>();
            services.AddScoped<IRestClient, RestClient>();

            services.AddScoped<IJwtService, JwtService>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCompanyCommandHandler).Assembly));

            return services;
        }
    }
}
