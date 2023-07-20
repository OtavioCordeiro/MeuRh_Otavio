using MediatR;
using MeuRh_Otavio.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
