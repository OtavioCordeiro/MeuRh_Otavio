using MediatR;
using MeuRh_Otavio.Application.Interfaces;
using MeuRh_Otavio.Application.Queries;
using MeuRh_Otavio.Application.ViewModel;

namespace MeuRh_Otavio.Application.Handlers
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyViewModel>
    {
        private readonly ICompanyService _companyService;

        public GetCompanyQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<CompanyViewModel> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            return await _companyService.GetCompanyById(request.CompanyId);
        }
    }
}
