using MeuRh_Otavio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(int id, bool includeCompanies = false);
        Task<User> GetByEmail(string email);
        Task Add(User user);
        Task Update(User user);
        Task Delete(int id);
        Task<List<User>> GetAllUsers();

    }
}
