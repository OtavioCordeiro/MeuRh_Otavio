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
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly ICompanyService _companyService;

        public DeleteCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            await _companyService.DeleteCompany(request.CompanyId);
            return;
        }
    }
}
