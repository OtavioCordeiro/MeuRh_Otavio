using MediatR;
using MeuRh_Otavio.Application.Commands;
using MeuRh_Otavio.Application.Interfaces;
using MeuRh_Otavio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Application.Handlers
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            await _companyService.AddCompany(request.Company);
            return;
        }
    }
}
