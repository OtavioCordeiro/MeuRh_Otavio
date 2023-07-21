using MediatR;
using MeuRh_Otavio.Application.ViewModel;

namespace MeuRh_Otavio.Application.Queries
{
    public class GetCompanyByUserQuery : IRequest<List<CompanyViewModel>>
    {
        public int UserId { get; set; }
    }
}
