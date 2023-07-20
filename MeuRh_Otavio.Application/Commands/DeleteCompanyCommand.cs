using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Application.Commands
{
    public class DeleteCompanyCommand : IRequest
    {
        public int CompanyId { get; set; }
    }
}
