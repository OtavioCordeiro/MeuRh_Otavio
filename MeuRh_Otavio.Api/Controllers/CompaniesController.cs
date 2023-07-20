using MediatR;
using MeuRh_Otavio.Application.Commands;
using MeuRh_Otavio.Application.Queries;
using MeuRh_Otavio.Application.ViewModel;
using MeuRh_Otavio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MeuRh_Otavio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddCompanyToUser/{userId}")]
        public async Task<ActionResult> AddCompanyToUser(int userId, [FromBody] CompanyViewModel companyViewModel)
        {
            var command = new AddCompanyToUserCommand(userId, companyViewModel);
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyViewModel>> GetCompany(int id)
        {
            var query = new GetCompanyQuery { CompanyId = id };
            var company = await _mediator.Send(query);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyViewModel>>> GetAllCompanies()
        {
            var query = new GetAllCompaniesQuery();
            var companies = await _mediator.Send(query);

            return Ok(companies);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany([FromBody] CompanyViewModel company)
        {
            var command = new CreateCompanyCommand { Company = company };
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompany(int id, [FromBody] CompanyViewModel company)
        {
            company.Id = id;
            var command = new UpdateCompanyCommand { Company = company };
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var command = new DeleteCompanyCommand { CompanyId = id };
            await _mediator.Send(command);

            return Ok();
        }
    }
}
