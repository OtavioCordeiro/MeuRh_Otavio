using MediatR;
using MeuRh_Otavio.Application.Interfaces;
using MeuRh_Otavio.Application.Queries;
using MeuRh_Otavio.Application.ViewModel;
using MeuRh_Otavio.Domain.Entities;
using MeuRh_Otavio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
