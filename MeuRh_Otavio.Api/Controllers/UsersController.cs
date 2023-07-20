using MediatR;
using MeuRh_Otavio.Application.Commands;
using MeuRh_Otavio.Application.Queries;
using MeuRh_Otavio.Application.ViewModel;
using MeuRh_Otavio.Application.ViewModel.Requests;
using MeuRh_Otavio.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuRh_Otavio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUser(int id)
        {
            var query = new GetUserQuery { UserId = id };
            var user = await _mediator.Send(query);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserViewModel>>> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserViewModel user)
        {
            var command = new CreateUserCommand { User = user };
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserViewModel user)
        {
            user.Id = id;
            var command = new UpdateUserCommand { User = user };
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand { UserId = id };
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("{userId}/companies")]
        public async Task<IActionResult> GetCompanyByUser(int userId)
        {
            var command = new GetCompanyByUserQuery() { UserId = userId };
            var companies = await _mediator.Send(command);
            if (companies == null)
                return NotFound();

            return Ok(companies);
        }

        [HttpPost("{userId}/companies")]
        public async Task<IActionResult> AddCompanyToUser(int userId, [FromBody] CompanyViewModel companyViewModel)
        {
            // Utilize o MediatR para enviar um comando para adicionar a empresa ao usuário
            var command = new AddCompanyToUserCommand(userId, companyViewModel);
            await _mediator.Send(command);

            // Retorne uma resposta de sucesso
            return Ok(new { Message = "Empresa adicionada ao usuário com sucesso." });
        }
    }
}
