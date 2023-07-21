using MediatR;
using MeuRh_Otavio.Application.ViewModel;

namespace MeuRh_Otavio.Application.Queries
{
    public class GetCompanyQuery : IRequest<CompanyViewModel>
    {
        public int CompanyId { get; set; }
    }
}
