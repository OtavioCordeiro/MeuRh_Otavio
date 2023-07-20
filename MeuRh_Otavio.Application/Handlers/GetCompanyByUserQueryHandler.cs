using AutoMapper;
using MediatR;
using MeuRh_Otavio.Application.Queries;
using MeuRh_Otavio.Application.ViewModel;
using MeuRh_Otavio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Application.Handlers
{
    public class GetCompanyByUserQueryHandler : IRequestHandler<GetCompanyByUserQuery, List<CompanyViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetCompanyByUserQueryHandler(IUserRepository userRepository, ICompanyRepository companyRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyViewModel>> Handle(GetCompanyByUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.UserId, true);
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            var userCompanies = user.Companies.Select(uc => _mapper.Map<CompanyViewModel>(uc.Company)).ToList();
            return userCompanies;
        }
    }
}
