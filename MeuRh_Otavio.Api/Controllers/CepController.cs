using MediatR;
using MeuRh_Otavio.Application.Interfaces;
using MeuRh_Otavio.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MeuRh_Otavio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CepController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult> GetEndereco(string cep)
        {
            var query = new GetAddressByCepQuery { Cep = cep };
            var address = await _mediator.Send(query);
            
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }
    }
}
