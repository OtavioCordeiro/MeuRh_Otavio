using MeuRh_Otavio.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Application.Interfaces
{
    public interface ICepService
    {
        Task<AddressCepViewModel> GetAddressByCep(string cep);
    }
}
