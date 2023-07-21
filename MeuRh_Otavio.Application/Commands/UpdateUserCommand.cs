using MediatR;
using MeuRh_Otavio.Application.ViewModel;

namespace MeuRh_Otavio.Application.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public UserViewModel User { get; set; }
    }
}
