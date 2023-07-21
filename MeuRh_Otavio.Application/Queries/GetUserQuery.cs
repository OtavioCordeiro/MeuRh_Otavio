using MediatR;
using MeuRh_Otavio.Application.ViewModel;

namespace MeuRh_Otavio.Application.Queries
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public int UserId { get; set; }
    }
}
