using AutoFixture;
using AutoMapper;
using MeuRh_Otavio.Application.Commands;
using MeuRh_Otavio.Application.Handlers;
using MeuRh_Otavio.Domain.Entities;
using MeuRh_Otavio.Domain.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Tests.ApplicationTests.HandlersTests
{
    public class AddCompanyToUserCommandHandlerTests
    {
        [Fact]
        public async Task AddCompanyToUserCommandHandler_Handle_ShouldAddCompanyToUser()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var command = fixture.Create<AddCompanyToUserCommand>();
            var user = fixture.Create<User>();
            var company = fixture.Create<Company>();

            var userRepositoryMock = Substitute.For<IUserRepository>();
            var companyRepositoryMock = Substitute.For<ICompanyRepository>();
            var mapperMock = Substitute.For<IMapper>();

            userRepositoryMock.GetById(command.UserId, false).Returns(user);
            companyRepositoryMock.GetById(user.Companies.FirstOrDefault().CompanyId).Returns(company);

            mapperMock.Map<Company>(command.CompanyViewModel).Returns(company);

            var handler = new AddCompanyToUserCommandHandler(userRepositoryMock, companyRepositoryMock, mapperMock);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert                        
            await companyRepositoryMock.Received(1).Add(company);
        }
    }
}
