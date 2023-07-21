using MeuRh_Otavio.Application.ViewModel;
using MeuRh_Otavio.Application.ViewModel.Requests;

namespace MeuRh_Otavio.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserById(int id);
        Task AddUser(CreateUserViewModel user);
        Task UpdateUser(UserViewModel user);
        Task DeleteUser(int id);
        Task<List<UserViewModel>> GetAllUsers();
    }
}
