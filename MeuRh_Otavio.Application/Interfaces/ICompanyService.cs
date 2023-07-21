using MeuRh_Otavio.Application.ViewModel;

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
