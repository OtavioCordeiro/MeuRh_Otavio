using AutoMapper;
using MeuRh_Otavio.Application.Interfaces;
using MeuRh_Otavio.Application.ViewModel;
using MeuRh_Otavio.Domain.Entities;
using MeuRh_Otavio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CompanyViewModel> GetCompanyById(int id)
        {
            var company = await _companyRepository.GetById(id);
            return _mapper.Map<CompanyViewModel>(company);
        }

        public async Task AddCompany(CompanyViewModel companyvw)
        {
            var company = _mapper.Map<Company>(companyvw);
            await _companyRepository.Add(company);
        }

        public async Task UpdateCompany(CompanyViewModel companyvw)
        {
            var company = _mapper.Map<Company>(companyvw);
            await _companyRepository.Update(company);
        }

        public async Task DeleteCompany(int id)
        {
            await _companyRepository.Delete(id);
        }

        public async Task<List<CompanyViewModel>> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllCompanies();
            return _mapper.Map<List<CompanyViewModel>>(companies);
        }
    }
}
