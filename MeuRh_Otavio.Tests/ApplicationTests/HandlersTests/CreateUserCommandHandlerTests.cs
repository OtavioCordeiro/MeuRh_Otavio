using AutoFixture;
using MeuRh_Otavio.Application.Commands;
using MeuRh_Otavio.Application.Handlers;
using MeuRh_Otavio.Application.Interfaces;
using MeuRh_Otavio.Application.ViewModel.Requests;
using MeuRh_Otavio.Domain.Entities;
using NSubstitute;

namespace MeuRh_Otavio.Tests.ApplicationTests.HandlersTests
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task CreateUserCommandHandler_Handle_ShouldCreateUser()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var command = fixture.Create<CreateUserCommand>();
            var user = fixture.Create<User>();

            var userServiceMock = Substitute.For<IUserService>();
            userServiceMock.AddUser(Arg.Any<CreateUserViewModel>());

            var handler = new CreateUserCommandHandler(userServiceMock);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert            
            await userServiceMock.Received(1).AddUser(Arg.Is<CreateUserViewModel>(u => u.FullName == command.User.FullName &&
                                                                             u.Email == command.User.Email &&
                                                                             u.PasswordHash == command.User.PasswordHash));
        }
    }
}
