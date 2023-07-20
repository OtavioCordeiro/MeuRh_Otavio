using MediatR;
using MeuRh_Otavio.Application.ViewModel;
using MeuRh_Otavio.Application.ViewModel.Requests;
using MeuRh_Otavio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Application.Commands
{
    public class CreateUserCommand : IRequest
    {
        public CreateUserViewModel User { get; set; }
    }
}
