using MediatR;

namespace MeuRh_Otavio.Application.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int UserId { get; set; }
    }
}
