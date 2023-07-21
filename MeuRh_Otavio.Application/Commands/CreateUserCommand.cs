using MediatR;
using MeuRh_Otavio.Application.ViewModel.Requests;

namespace MeuRh_Otavio.Application.Commands
{
    public class CreateUserCommand : IRequest
    {
        public CreateUserViewModel User { get; set; }
    }
}
