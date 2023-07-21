using MeuRh_Otavio.Domain.Entities;

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
