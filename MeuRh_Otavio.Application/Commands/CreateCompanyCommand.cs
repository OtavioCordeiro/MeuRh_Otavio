﻿using MediatR;
using MeuRh_Otavio.Application.ViewModel;

namespace MeuRh_Otavio.Application.Commands
{
    public class CreateCompanyCommand : IRequest
    {
        public CompanyViewModel Company { get; set; }
    }
}
