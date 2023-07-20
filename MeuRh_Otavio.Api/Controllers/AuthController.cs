using MediatR;
using MeuRh_Otavio.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MeuRh_Otavio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var token = await _mediator.Send(command);

            if (token == null)
            {
                return Unauthorized(new { Message = "Invalid email or password." });
            }

            return Ok(new { Token = token });
        }
    }
}
