using MediatR;
using MeuRh_Otavio.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Application.Queries
{
    public class GetAddressByCepQuery : IRequest<AddressCepViewModel>
    {
        public string Cep { get; set; }
    }
}
