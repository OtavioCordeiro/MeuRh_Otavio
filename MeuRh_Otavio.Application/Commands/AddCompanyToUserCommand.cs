using MediatR;
using MeuRh_Otavio.Application.ViewModel;

namespace MeuRh_Otavio.Application.Commands
{
    public class AddCompanyToUserCommand : IRequest
    {
        public int UserId { get; set; }
        public CompanyViewModel CompanyViewModel { get; set; }

        public AddCompanyToUserCommand(int userId, CompanyViewModel companyViewModel)
        {
            UserId = userId;
            CompanyViewModel = companyViewModel;
        }
    }
}
