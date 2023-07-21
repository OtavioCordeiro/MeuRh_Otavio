using MediatR;
using MeuRh_Otavio.Application.ViewModel;

namespace MeuRh_Otavio.Application.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
        public int id { get; set; }
    }
}
