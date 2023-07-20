using MeuRh_Otavio.Application.ViewModel;
using MeuRh_Otavio.Application.ViewModel.Requests;
using MeuRh_Otavio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
