using AutoFixture.Xunit2;
using AutoFixture.AutoNSubstitute;
using AutoMapper;
using FluentAssertions;
using MeuRh_Otavio.Application.Services;
using MeuRh_Otavio.Application.ViewModel;
using MeuRh_Otavio.Domain.Entities;
using MeuRh_Otavio.Domain.Interfaces;
using NSubstitute;
using AutoFixture;

namespace MeuRh_Otavio.Tests.ApplicationTests.Services
{
    public class UserServiceTests
    {
        IUserRepository _userRepositoryMock;
        IMapper _mapperMock;
        UserService _sut;

        public UserServiceTests()
        {
            _userRepositoryMock = Substitute.For<IUserRepository>();
            _mapperMock = Substitute.For<IMapper>();
            _sut = new UserService(_userRepositoryMock, _mapperMock);
        }

        [Fact]
        public async Task UserService_GetUserById_ShouldReturnUser()
        {
            // Arrange            
            var userId = 1;
            var user = new User();
            var userViewModel = new UserViewModel();

            IUserRepository _userRepositoryMock = Substitute.For<IUserRepository>();
            IMapper _mapperMock = Substitute.For<IMapper>();

            _userRepositoryMock.GetById(userId).Returns(user);
            _mapperMock.Map<UserViewModel>(user).Returns(userViewModel);

            UserService _sut = new UserService(_userRepositoryMock, _mapperMock);

            // Act
            var result = await _sut.GetUserById(userId);

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(userViewModel);
        }

        [Theory, AutoData]
        public async Task UserService_GetUserById_ShouldReturnUser_AutoData(
            int userId,
            UserViewModel userViewModel)
        {
            // Arrange
            var user = new User();

            _userRepositoryMock.GetById(userId).Returns(user);
            _mapperMock.Map<UserViewModel>(user).Returns(userViewModel);

            // Act
            var result = await _sut.GetUserById(userId);

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(userViewModel);
        }

        public int somar(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
