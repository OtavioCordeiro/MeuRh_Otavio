using MediatR;
using MeuRh_Otavio.Application.Interfaces;
using MeuRh_Otavio.Application.Queries;
using MeuRh_Otavio.Application.ViewModel;

namespace MeuRh_Otavio.Application.Handlers
{
    public class GetAddressByCepQueryHandler : IRequestHandler<GetAddressByCepQuery, AddressCepViewModel>
    {
        private readonly ICepService _cepService;

        public GetAddressByCepQueryHandler(ICepService cepService)
        {
            _cepService = cepService;
        }

        public async Task<AddressCepViewModel> Handle(GetAddressByCepQuery request, CancellationToken cancellationToken)
        {
            var address = await _cepService.GetAddressByCep(request.Cep);

            return address;
        }
    }
}
