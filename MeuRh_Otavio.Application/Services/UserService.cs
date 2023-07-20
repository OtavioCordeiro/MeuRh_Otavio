using MeuRh_Otavio.Application.Interfaces;
using MeuRh_Otavio.Domain.Entities;
using MeuRh_Otavio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BCrypt.Net;
using MeuRh_Otavio.Application.ViewModel;
using AutoMapper;
using MeuRh_Otavio.Application.ViewModel.Requests;

namespace MeuRh_Otavio.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task AddUser(CreateUserViewModel uservm)
        {
            uservm.PasswordHash = BCrypt.Net.BCrypt.HashPassword(uservm.PasswordHash);

            var user = _mapper.Map<User>(uservm);
            await _userRepository.Add(user);
        }

        public async Task UpdateUser(UserViewModel uservm)
        {
            var user = _mapper.Map<User>(uservm);
            await _userRepository.Update(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();

            return _mapper.Map<List<UserViewModel>>(users);
        }
    }
}
