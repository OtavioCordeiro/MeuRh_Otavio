using MeuRh_Otavio.Application.Interfaces;
using MeuRh_Otavio.Application.ViewModel;
using RestSharp;

namespace MeuRh_Otavio.Application.Services
{
    public class CepService : ICepService
    {
        private readonly IRestClient _restClient;

        public CepService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<AddressCepViewModel> GetAddressByCep(string cep)
        {
            string apiUrl = $"https://viacep.com.br/ws/{cep}/json/";

            var request = new RestRequest(apiUrl, Method.Get);

            var response = await _restClient.ExecuteAsync<AddressCepViewModel>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            return null;
        }
    }
}
