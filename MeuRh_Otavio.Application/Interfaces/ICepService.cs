using MeuRh_Otavio.Application.ViewModel;

namespace MeuRh_Otavio.Application.Interfaces
{
    public interface ICepService
    {
        Task<AddressCepViewModel> GetAddressByCep(string cep);
    }
}
