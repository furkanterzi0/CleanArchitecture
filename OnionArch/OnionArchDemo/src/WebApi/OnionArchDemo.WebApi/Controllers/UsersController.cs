using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchDemo.Application.Features.Commands;
using OnionArchDemo.Application.Features.Queries;

namespace OnionArchDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await mediator.Send(new GetAllUserQuery());
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            var id = await mediator.Send(createUserCommand);
            return Ok(id);
        }
    }
}
