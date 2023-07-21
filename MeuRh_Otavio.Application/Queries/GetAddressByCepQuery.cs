using MediatR;
using MeuRh_Otavio.Application.ViewModel;

namespace MeuRh_Otavio.Application.Queries
{
    public class GetAddressByCepQuery : IRequest<AddressCepViewModel>
    {
        public string Cep { get; set; }
    }
}
