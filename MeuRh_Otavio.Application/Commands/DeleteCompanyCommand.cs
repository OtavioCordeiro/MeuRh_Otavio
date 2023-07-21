using MediatR;

namespace MeuRh_Otavio.Application.Commands
{
    public class DeleteCompanyCommand : IRequest
    {
        public int CompanyId { get; set; }
    }
}
