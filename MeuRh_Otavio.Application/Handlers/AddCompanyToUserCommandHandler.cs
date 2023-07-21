using AutoMapper;
using MediatR;
using MeuRh_Otavio.Application.Commands;
using MeuRh_Otavio.Domain.Entities;
using MeuRh_Otavio.Domain.Interfaces;

namespace MeuRh_Otavio.Application.Handlers
{
    public class AddCompanyToUserCommandHandler : IRequestHandler<AddCompanyToUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public AddCompanyToUserCommandHandler(IUserRepository userRepository, ICompanyRepository companyRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task Handle(AddCompanyToUserCommand request, CancellationToken cancellationToken)
        {
            // Obtenha o usuário pelo UserId
            var user = await _userRepository.GetById(request.UserId);
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            // Mapeie a CompanyViewModel para a entidade Company
            var company = _mapper.Map<Company>(request.CompanyViewModel);

            var existingCompany = await _companyRepository.GetById(company.Id);
            if (existingCompany != null)
                company = existingCompany;
            else
                await _companyRepository.Add(company);

            user.Companies = new List<UserCompany>();

            user.Companies.Add(new UserCompany { User = user, Company = company });

            await _userRepository.Update(user);

            return;
        }
    }
}
