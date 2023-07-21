using MediatR;

namespace MeuRh_Otavio.Application.Commands
{
    public class LoginUserCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
