using MeuRh_Otavio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetById(int id);
        Task Add(Company company);
        Task Update(Company company);
        Task Delete(int id);
        Task<List<Company>> GetAllCompanies();
    }
}
