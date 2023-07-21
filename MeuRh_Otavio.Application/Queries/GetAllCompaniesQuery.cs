using MediatR;
using MeuRh_Otavio.Application.ViewModel;

namespace MeuRh_Otavio.Application.Queries
{
    public class GetAllCompaniesQuery : IRequest<List<CompanyViewModel>>
    {
    }
}
