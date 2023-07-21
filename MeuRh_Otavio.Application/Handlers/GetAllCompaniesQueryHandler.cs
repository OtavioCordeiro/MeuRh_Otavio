using MediatR;
using MeuRh_Otavio.Application.Interfaces;
using MeuRh_Otavio.Application.Queries;
using MeuRh_Otavio.Application.ViewModel;

namespace MeuRh_Otavio.Application.Handlers
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyViewModel>>
    {
        private readonly ICompanyService _companyService;

        public GetAllCompaniesQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<List<CompanyViewModel>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            return await _companyService.GetAllCompanies();
        }
    }
}
