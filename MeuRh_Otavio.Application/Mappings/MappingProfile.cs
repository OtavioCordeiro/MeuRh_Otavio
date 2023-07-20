using AutoMapper;
using MeuRh_Otavio.Application.ViewModel;
using MeuRh_Otavio.Application.ViewModel.Requests;
using MeuRh_Otavio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, CreateUserViewModel>().ReverseMap();
            CreateMap<CompanyViewModel, Company>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new CompanyAddress
                {
                    CEP = src.CEP,
                    Street = src.Street,
                    Neighborhood = src.Neighborhood,
                    State = src.State,
                    City = src.City,
                    Complement = src.Complement
                }))
                .ForMember(dest => dest.Administrator, opt => opt.MapFrom(src => new CompanyAdministrator
                {
                    Name = src.AdministratorName,
                    CPF = src.AdministratorNameCPF,
                    Email = src.AdministratorNameEmail,
                    Phone = src.AdministratorNamePhone
                })).ReverseMap();
        }
    }
}
