using MeuRh_Otavio.Application.ViewModel;
using MeuRh_Otavio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyViewModel> GetCompanyById(int id);
        Task AddCompany(CompanyViewModel company);
        Task UpdateCompany(CompanyViewModel company);
        Task DeleteCompany(int id);
        Task<List<CompanyViewModel>> GetAllCompanies();
    }
}
